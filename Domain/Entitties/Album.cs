namespace Domain.Entitties;

public class Album
{
    public int ALbumId { get; set; }
    public string? Title { get; set; }
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
    public List<Track> Tracks { get; set; }
}