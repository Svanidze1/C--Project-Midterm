using Microsoft.Data.SqlClient;

namespace HotelRooms;

public class RoomRepository
{
    // The only connection string in the application.
    private readonly string connectionString =
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelRoomsDb;" +
        "Integrated Security=True;TrustServerCertificate=True;Connect Timeout=10";

    public List<Room> Search(string text, string roomType)
    {
        List<Room> rooms = new List<Room>();
        string sql =
            "SELECT Id, RoomNumber, RoomType, Floor, PricePerNight, Status, HasBalcony, Description " +
            "FROM dbo.Rooms " +
            "WHERE (@text = N'' OR RoomNumber LIKE @pattern ESCAPE N'~' " +
            "OR Description LIKE @pattern ESCAPE N'~') " +
            "AND (@roomType = N'' OR RoomType = @roomType) " +
            "ORDER BY Floor, RoomNumber";

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            // Treat %, _ and [ as literal search characters, not LIKE wildcards.
            string literalText = text.Replace("~", "~~").Replace("%", "~%")
                .Replace("_", "~_").Replace("[", "~[");
            command.Parameters.AddWithValue("@text", text);
            command.Parameters.AddWithValue("@pattern", "%" + literalText + "%");
            command.Parameters.AddWithValue("@roomType", roomType);
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Room room = new Room();
                    room.Id = (int)reader["Id"];
                    room.RoomNumber = (string)reader["RoomNumber"];
                    room.RoomType = (string)reader["RoomType"];
                    room.Floor = (int)reader["Floor"];
                    room.PricePerNight = (decimal)reader["PricePerNight"];
                    room.Status = (string)reader["Status"];
                    room.HasBalcony = (bool)reader["HasBalcony"];
                    room.Description = (string)reader["Description"];
                    rooms.Add(room);
                }
            }
        }

        return rooms;
    }

    public int CountAll()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Rooms", connection))
        {
            connection.Open();
            return (int)command.ExecuteScalar()!;
        }
    }

    public void Add(Room room)
    {
        string sql =
            "INSERT INTO dbo.Rooms " +
            "(RoomNumber, RoomType, Floor, PricePerNight, Status, HasBalcony, Description) " +
            "VALUES (@roomNumber, @roomType, @floor, @pricePerNight, @status, @hasBalcony, @description)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            AddRoomParameters(command, room);
            connection.Open();
            ExecuteSave(command);
        }
    }

    public void Update(Room room)
    {
        string sql =
            "UPDATE dbo.Rooms SET RoomNumber = @roomNumber, RoomType = @roomType, " +
            "Floor = @floor, PricePerNight = @pricePerNight, Status = @status, " +
            "HasBalcony = @hasBalcony, Description = @description WHERE Id = @id";

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            AddRoomParameters(command, room);
            command.Parameters.AddWithValue("@id", room.Id);
            connection.Open();
            if (ExecuteSave(command) == 0)
            {
                throw new InvalidOperationException("This room no longer exists. Click Refresh and try again.");
            }
        }
    }

    public void Delete(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand("DELETE FROM dbo.Rooms WHERE Id = @id", connection))
        {
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            if (command.ExecuteNonQuery() == 0)
            {
                throw new InvalidOperationException("This room no longer exists. Click Refresh to update the list.");
            }
        }
    }

    private static void AddRoomParameters(SqlCommand command, Room room)
    {
        command.Parameters.AddWithValue("@roomNumber", room.RoomNumber);
        command.Parameters.AddWithValue("@roomType", room.RoomType);
        command.Parameters.AddWithValue("@floor", room.Floor);
        command.Parameters.AddWithValue("@pricePerNight", room.PricePerNight);
        command.Parameters.AddWithValue("@status", room.Status);
        command.Parameters.AddWithValue("@hasBalcony", room.HasBalcony);
        command.Parameters.AddWithValue("@description", room.Description);
    }

    private static int ExecuteSave(SqlCommand command)
    {
        try
        {
            return command.ExecuteNonQuery();
        }
        catch (SqlException exception) when (exception.Number == 2601 || exception.Number == 2627)
        {
            throw new InvalidOperationException("A room with this room number already exists. Use a different number.", exception);
        }
    }
}
