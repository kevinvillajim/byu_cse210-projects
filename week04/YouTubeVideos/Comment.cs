class Comment
{
    private string author;
    private string text;

    public Comment(string author, string text)
    {
        this.author = author;
        this.text = text;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"- {author}: {text}");
    }
}