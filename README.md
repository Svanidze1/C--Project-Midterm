# Hotel Rooms

Student: Giorgi Svanidze / გიორგი სვანიძე
University: Kutaisi International University (KIU)
Topic: 9 — Hotel Rooms

Windows Forms application with a single SQL Server LocalDB table. It lists rooms, searches by room number or description, filters by room type, and supports add, edit, delete and UTF-8 CSV export.

## Database
HotelRoomsDb, dbo.Rooms.
Columns: Id INT IDENTITY PRIMARY KEY, RoomNumber NVARCHAR(4), RoomType NVARCHAR(10), Floor INT, PricePerNight DECIMAL(8,2), Status NVARCHAR(10), HasBalcony BIT, Description NVARCHAR(150).
Balcony is a calculated C# property, not a database column.

## Run
1. Install Visual Studio 2026 with .NET desktop development, .NET 10 SDK and SQL Server Express LocalDB.
2. Open HotelRooms.sln. Allow NuGet restore to complete.
3. View -> SQL Server Object Explorer -> (localdb)\MSSQLLocalDB -> New Query.
4. Paste the complete HotelRooms/database.sql file and click Execute. Running it twice is safe.
5. Build -> Rebuild Solution, then F5. The grid initially contains 18 rooms.

