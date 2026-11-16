using System.Globalization;
using System.Text;

namespace HotelRooms;

public static class CsvExporter
{
    public static void Export(string path, List<Room> rooms)
    {
        // BOM helps Excel detect UTF-8 and display Georgian correctly.
        using (StreamWriter writer = new StreamWriter(path, false, new UTF8Encoding(true)))
        {
            writer.WriteLine("Room number,Room type,Floor,Price per night (GEL),Status,Balcony,Description");
            foreach (Room room in rooms)
            {
                writer.WriteLine(string.Join(",", new string[]
                {
                    Escape(room.RoomNumber),
                    Escape(room.RoomType),
                    Escape(room.Floor.ToString(CultureInfo.InvariantCulture)),
                    Escape(room.PricePerNight.ToString("0.00", CultureInfo.InvariantCulture)),
                    Escape(room.Status),
                    Escape(room.Balcony),
                    Escape(room.Description)
                }));
            }
        }
    }

    private static string Escape(string value)
    {
        // User-entered descriptions must remain text when opened in Excel.
        string trimmedValue = value.TrimStart();
        if (trimmedValue.Length > 0 && "=+-@".Contains(trimmedValue[0]))
        {
            value = "'" + value;
        }
        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }
}
