namespace Domain.Model;

public class AlbumDto
{
    public int AlbumId { get; set; }
    public string? Title { get; set; }
    public int ArtistId { get; set; }
}

public class GetJoinedAlbums
{
    public int ALbumId { get; set; }
    public string? Title { get; set; }
    public int ArtistId { get; set; }
    public string? ArtistName { get; set; }
    public int TrackId { get; set; }
    public string? TrackName { get; set; }
}