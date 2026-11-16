namespace HotelRooms;

public partial class RoomForm : Form
{
    public Room CurrentRoom { get; private set; } = new Room();

    public RoomForm()
    {
        InitializeComponent();
        cmbRoomType.SelectedIndex = 0;
        cmbStatus.SelectedIndex = 0;
    }

    // : this() first creates the same controls used in Add mode.
    public RoomForm(Room room) : this()
    {
        Text = "Edit room";
        lblHeading.Text = "Edit room";
        // Make a new object: Cancel must never modify the selected grid object.
        CurrentRoom = new Room
        {
            Id = room.Id,
            RoomNumber = room.RoomNumber,
            RoomType = room.RoomType,
            Floor = room.Floor,
            PricePerNight = room.PricePerNight,
            Status = room.Status,
            HasBalcony = room.HasBalcony,
            Description = room.Description
        };
        txtRoomNumber.Text = room.RoomNumber;
        cmbRoomType.SelectedItem = room.RoomType;
        numFloor.Value = room.Floor;
        numPricePerNight.Value = room.PricePerNight;
        cmbStatus.SelectedItem = room.Status;
        chkHasBalcony.Checked = room.HasBalcony;
        txtDescription.Text = room.Description;
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
        {
            ShowValidation("Enter a room number.", txtRoomNumber);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtDescription.Text))
        {
            ShowValidation("Enter a short room description.", txtDescription);
            return;
        }

        string roomNumber = txtRoomNumber.Text.Trim();
        bool containsOnlyDigits = true;
        foreach (char character in roomNumber)
        {
            if (character < '0' || character > '9')
            {
                containsOnlyDigits = false;
            }
        }

        if (!containsOnlyDigits || roomNumber.Length < 3 || roomNumber.Length > 4 ||
            roomNumber[0] == '0' || !int.TryParse(roomNumber, out int number))
        {
            ShowValidation("Room number must contain 3 or 4 digits and cannot start with 0 (for example, 101 or 1205).", txtRoomNumber);
            return;
        }

        // Hotel rule: 101 is room 01 on floor 1; 1205 is room 05 on floor 12.
        if (number / 100 != (int)numFloor.Value || number % 100 == 0)
        {
            ShowValidation("Room number must match the floor, and its last two digits must be 01–99.\nExamples: 101 on floor 1; 1205 on floor 12.", txtRoomNumber);
            return;
        }

        if (cmbRoomType.SelectedIndex < 0 || cmbStatus.SelectedIndex < 0)
        {
            ShowValidation("Choose a room type and status.", cmbRoomType);
            return;
        }

        CurrentRoom = new Room
        {
            Id = CurrentRoom.Id,
            RoomNumber = roomNumber,
            RoomType = cmbRoomType.SelectedItem!.ToString()!,
            Floor = (int)numFloor.Value,
            PricePerNight = numPricePerNight.Value,
            Status = cmbStatus.SelectedItem!.ToString()!,
            HasBalcony = chkHasBalcony.Checked,
            Description = txtDescription.Text.Trim()
        };

        DialogResult = DialogResult.OK;
        Close();
    }

    private void ShowValidation(string message, Control control)
    {
        MessageBox.Show(this, message, "Check room details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        control.Focus();
    }
}
