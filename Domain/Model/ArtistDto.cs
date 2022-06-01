namespace Domain.Model;

public class ArtistDto
{
    public string? ArtistName { get; set; }
}

public partial class GetJoinedArtists
{
    public int ALbumId { get; set; }
    public string? Title { get; set; }
    public int ArtistId { get; set; }
    public string? ArtistName { get; set; }
    public int TrackId { get; set; }
    public string? TrackName { get; set; }
}