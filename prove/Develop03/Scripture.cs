using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private ScriptureReference ney_reference;
    private List<Word> ney_words;

    public Scripture(ScriptureReference ney_reference, string ney_text)
    {
        this.ney_reference = ney_reference;
        ney_words = new List<Word>();

        // Split the text into words and create Word objects
        string[] ney_wordTexts = ney_text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string ney_wordText in ney_wordTexts)
        {
            ney_words.Add(new Word(ney_wordText));
        }
    }

    public void HideRandomWords(int ney_count = 3)
    {
        Random ney_random = new Random();

        // Build a list of indices that are not yet hidden
        List<int> ney_unhiddenIndices = new List<int>();
        for (int ney_i = 0; ney_i < ney_words.Count; ney_i++)
        {
            if (!ney_words[ney_i].IsHidden())
            {
                ney_unhiddenIndices.Add(ney_i);
            }
        }

        // Hide up to ney_count distinct unhidden words
        for (int ney_i = 0; ney_i < ney_count && ney_unhiddenIndices.Count > 0; ney_i++)
        {
            int ney_choice = ney_random.Next(ney_unhiddenIndices.Count);
            int ney_indexToHide = ney_unhiddenIndices[ney_choice];
            ney_words[ney_indexToHide].Hide();
            ney_unhiddenIndices.RemoveAt(ney_choice);
        }
    }

    public string GetDisplayText()
    {
        List<string> ney_displayWords = new List<string>();
        foreach (Word ney_word in ney_words)
        {
            ney_displayWords.Add(ney_word.GetDisplayText());
        }
        return string.Join(" ", ney_displayWords);
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word ney_word in ney_words)
        {
            if (!ney_word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public ScriptureReference GetReference()
    {
        return ney_reference;
    }
}
