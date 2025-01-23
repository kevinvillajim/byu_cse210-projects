using System;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        _words = new List<Word>();
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            Word wordObject = new Word(word);
            _words.Add(wordObject);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        var random = new Random();
        var wordsToHide = _words.Where(word => !word.IsHidden()).OrderBy(_ => random.Next()).Take(numberToHide);

        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()}   {scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }


}