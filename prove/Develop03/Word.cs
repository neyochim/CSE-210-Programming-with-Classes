public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Return underscores matching the length of the word
            return new string('_', _text.Length);
        }
        return _text;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetText()
    {
        return _text;
    }
}
