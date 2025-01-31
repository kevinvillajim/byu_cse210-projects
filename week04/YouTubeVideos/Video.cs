class Video
{
    private string title;
    private string author;
    private int length;
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {title}, Author: {author}, Length: {length} sec");
        Console.WriteLine($"Comments ({GetCommentCount()}):");
        foreach (var comment in comments)
        {
            comment.DisplayComment();
        }
    }
}