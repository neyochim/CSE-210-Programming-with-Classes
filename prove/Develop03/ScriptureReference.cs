public class ScriptureReference
{
    private string ney_book;
    private int ney_chapter;
    private int ney_startVerse;
    private int ney_endVerse;

    // Constructor for single verse (e.g., "John 3:16")
    public ScriptureReference(string ney_book, int ney_chapter, int ney_verse)
    {
        this.ney_book = ney_book;
        this.ney_chapter = ney_chapter;
        ney_startVerse = ney_verse;
        ney_endVerse = ney_verse;
    }

    // Constructor for verse range (e.g., "Proverbs 3:5-6")
    public ScriptureReference(string ney_book, int ney_chapter, int ney_startVerse, int ney_endVerse)
    {
        this.ney_book = ney_book;
        this.ney_chapter = ney_chapter;
        this.ney_startVerse = ney_startVerse;
        this.ney_endVerse = ney_endVerse;
    }

    public override string ToString()
    {
        if (ney_startVerse == ney_endVerse)
        {
            return $"{ney_book} {ney_chapter}:{ney_startVerse}";
        }
        else
        {
            return $"{ney_book} {ney_chapter}:{ney_startVerse}-{ney_endVerse}";
        }
    }
}
