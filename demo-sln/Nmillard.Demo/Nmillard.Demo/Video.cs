public class Video {
    public string Title { get; set; }
    public int Rating { get; private set; }

    public void UpVote() => Rating++;
}