public class Word
{
    private string ney_text;
    private bool ney_isHidden;

    public Word(string ney_text)
    {
        this.ney_text = ney_text;
        ney_isHidden = false;
    }

    public void Hide()
    {
        ney_isHidden = true;
    }

    public string GetDisplayText()
    {
        if (ney_isHidden)
        {
            // Return underscores matching the length of the word
            return new string('_', ney_text.Length);
        }
        return ney_text;
    }

    public bool IsHidden()
    {
        return ney_isHidden;
    }

    public string GetText()
    {
        return ney_text;
    }
}
