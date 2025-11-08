using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            entries.Add(Entry.FromFileString(line));
        }
    }

    public void SaveToCsvFile(string filename)
{
    using (StreamWriter writer = new StreamWriter(filename))
    {
        writer.WriteLine("Date, Question, Answer"); 

        foreach (Entry entry in entries)
        {
            string date = EscapeCsv(entry.Date);
            string question = EscapeCsv(entry.Prompt);
            string answer = EscapeCsv(entry.Response);

            writer.WriteLine($"{date},{question},{answer}");
        }
    }
}

private string EscapeCsv(string text)
{
    if (text.Contains(",") || text.Contains("\"") || text.Contains("\n"))
    {
        text = text.Replace("\"", "\"\"");
        return $"\"{text}\"";
    }
    return text;
}

}