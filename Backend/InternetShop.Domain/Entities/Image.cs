namespace InternetShop.Domain.Entities;

public class Image : BaseEntity
{
    public string Url { get; set; } = string.Empty;

    public Guid AnnouncementId { get; set; }

    public Announcement? Announcement { get; set; }
}
