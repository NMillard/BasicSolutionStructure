using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class VideoCollection : IEnumerable<Video> {
    private readonly List<Video> videos = new();

    // Need to have an 'Add' method.
    public void Add(Video video) {
        if (video is null) throw new ArgumentException();
        videos.Add(video);
    }

    public Video MostPopular => videos.Aggregate((first, next) 
        => first.Rating > next.Rating ? first : next);
    
    public IEnumerator<Video> GetEnumerator() => videos.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}