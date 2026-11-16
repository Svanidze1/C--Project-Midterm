namespace HotelRooms;

public class Room
{
    public int Id { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public string RoomType { get; set; } = "Single";
    public int Floor { get; set; }
    public decimal PricePerNight { get; set; }
    public string Status { get; set; } = "Free";
    public bool HasBalcony { get; set; }
    public string Description { get; set; } = string.Empty;

    // Calculated in C#: this is NOT a database column.
    public string Balcony
    {
        get { return HasBalcony ? "Yes" : "No"; }
    }
}
