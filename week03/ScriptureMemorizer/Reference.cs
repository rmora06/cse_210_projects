public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int? VerseEnd { get; private set; }

    public Reference(string book, int chapter, int verseStart)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = null;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public static Reference Parse(string input)
    {
        // Example: "Proverbs 3:5-6"
        var bookAndRest = input.Split(' ');
        var book = bookAndRest[0];
        var chapterAndVerse = bookAndRest[1].Split(':');
        int chapter = int.Parse(chapterAndVerse[0]);

        if (chapterAndVerse[1].Contains("-"))
        {
            var verses = chapterAndVerse[1].Split('-');
            return new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
        }
        else
        {
            return new Reference(book, chapter, int.Parse(chapterAndVerse[1]));
        }
    }

    public override string ToString()
    {
        return VerseEnd.HasValue
            ? $"{Book} {Chapter}:{VerseStart}-{VerseEnd}"
            : $"{Book} {Chapter}:{VerseStart}";
    }
}