// SessionLog.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class SessionLog
{
    private readonly string _path;
    private readonly List<SessionLogEntry> _entries = new();

    public SessionLog(string path)
    {
        _path = path;
        LoadIfExists();
    }

    public void Append(SessionLogEntry entry) => _entries.Add(entry);

    public void Save()
    {
        var sb = new StringBuilder();
        sb.AppendLine("dateUtc,activity,durationSeconds,extra");
        foreach (var e in _entries)
        {
            sb.AppendLine($"{e.DateUtc:o},{Escape(e.ActivityName)},{e.DurationSeconds},{Escape(e.ExtraMetric)}");
        }
        File.WriteAllText(_path, sb.ToString());
    }

    public void LoadIfExists()
    {
        if (!File.Exists(_path)) return;
        var lines = File.ReadAllLines(_path).Skip(1);
        _entries.Clear();
        foreach (var line in lines)
        {
            var parts = SplitCsv(line);
            if (parts.Length < 4) continue;
            if (DateTime.TryParse(parts[0], null, System.Globalization.DateTimeStyles.RoundtripKind, out var dt))
            {
                _entries.Add(new SessionLogEntry
                {
                    DateUtc = dt,
                    ActivityName = parts[1],
                    DurationSeconds = int.TryParse(parts[2], out var d) ? d : 0,
                    ExtraMetric = parts[3]
                });
            }
        }
    }

    public string GetSummaryText()
    {
        if (_entries.Count == 0) return "No entries yet.";

        var totalSeconds = _entries.Sum(e => e.DurationSeconds);
        var byActivity = _entries
            .GroupBy(e => e.ActivityName)
            .Select(g => $"{g.Key}: {g.Count()} times, {g.Sum(x => x.DurationSeconds)} seconds")
            .ToList();

        var sb = new StringBuilder();
        sb.AppendLine($"Total sessions: {_entries.Count}");
        sb.AppendLine($"Total time: {totalSeconds} seconds");
        sb.AppendLine("By activity:");
        foreach (var line in byActivity) sb.AppendLine($"- {line}");
        return sb.ToString();
    }

    private static string Escape(string? s) => s == null ? "" :
        s.Contains(',') ? $"\"{s.Replace("\"", "\"\"")}\"" : s;

    private static string[] SplitCsv(string line)
    {
        var result = new List<string>();
        bool inQuotes = false;
        var sb = new StringBuilder();

        foreach (char c in line)
        {
            if (c == '\"')
            {
                inQuotes = !inQuotes;
                continue;
            }
            if (c == ',' && !inQuotes)
            {
                result.Add(sb.ToString());
                sb.Clear();
            }
            else
            {
                sb.Append(c);
            }
        }
        result.Add(sb.ToString());
        return result.ToArray();
    }
}

public class SessionLogEntry
{
    public DateTime DateUtc { get; set; }
    public string ActivityName { get; set; } = "";
    public int DurationSeconds { get; set; }
    public string ExtraMetric { get; set; } = "";
}