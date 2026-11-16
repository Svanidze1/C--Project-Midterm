namespace HotelRooms;

public partial class MainForm : Form
{
    private readonly RoomRepository repository = new RoomRepository();
    private List<Room> displayedRooms = new List<Room>();
    private bool changingFilters;

    public MainForm()
    {
        InitializeComponent();
        changingFilters = true;
        cmbRoomTypeFilter.SelectedIndex = 0;
        changingFilters = false;
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        LoadRooms();
    }

    private void LoadRooms(string actionMessage = "")
    {
        try
        {
            string roomType = cmbRoomTypeFilter.SelectedIndex <= 0
                ? string.Empty : cmbRoomTypeFilter.SelectedItem!.ToString()!;
            List<Room> rooms = repository.Search(txtSearch.Text.Trim(), roomType);
            int totalCount = repository.CountAll();
            displayedRooms = rooms;
            dgvRooms.DataSource = displayedRooms;
            dgvRooms.ClearSelection();
            dgvRooms.CurrentCell = null;
            lblCount.Text = $"Shown {displayedRooms.Count} of {totalCount}";
            string resultMessage = displayedRooms.Count == 0
                ? "No rooms match your search or filter. Clear them, or add a room."
                : "Select a room to edit or delete. Double-click a row to edit.";
            lblStatus.Text = string.IsNullOrEmpty(actionMessage)
                ? resultMessage : actionMessage + "  " + resultMessage;
        }
        catch (Exception exception)
        {
            displayedRooms = new List<Room>();
            dgvRooms.DataSource = displayedRooms;
            lblCount.Text = "Not connected";
            lblStatus.Text = string.IsNullOrEmpty(actionMessage)
                ? "Could not load rooms. Check setup, then click Refresh."
                : actionMessage + " The list could not be refreshed. Click Refresh after checking the connection.";
            MessageBox.Show(this,
                "Could not load rooms. Run database.sql on (localdb)\\MSSQLLocalDB as described in README.md, then click Refresh.\n\n" + exception.Message,
                "Database connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSearch_Click(object? sender, EventArgs e)
    {
        LoadRooms();
    }

    private void txtSearch_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            LoadRooms();
        }
    }

    private void cmbRoomTypeFilter_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (!changingFilters)
        {
            LoadRooms();
        }
    }

    private void ClearFilters()
    {
        changingFilters = true;
        txtSearch.Clear();
        cmbRoomTypeFilter.SelectedIndex = 0;
        changingFilters = false;
    }

    private void btnClear_Click(object? sender, EventArgs e)
    {
        ClearFilters();
        LoadRooms();
    }

    private void btnRefresh_Click(object? sender, EventArgs e)
    {
        LoadRooms();
    }

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        using (RoomForm form = new RoomForm())
        {
            while (form.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    repository.Add(form.CurrentRoom);
                }
                catch (Exception exception)
                {
                    ShowActionError("save the room", exception);
                    // Reopen the same dialog with the entered values intact.
                    form.DialogResult = DialogResult.None;
                    continue;
                }

                ClearFilters();
                LoadRooms("Room " + form.CurrentRoom.RoomNumber + " added. Filters cleared.");
                break;
            }
        }
    }

    private Room? GetSelectedRoom()
    {
        if (dgvRooms.CurrentRow == null || !dgvRooms.CurrentRow.Selected ||
            dgvRooms.CurrentRow.DataBoundItem is not Room selectedRoom)
        {
            MessageBox.Show(this, "Select a room first.", "No room selected",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }
        return selectedRoom;
    }

    private void btnEdit_Click(object? sender, EventArgs e)
    {
        Room? selectedRoom = GetSelectedRoom();
        if (selectedRoom == null)
        {
            return;
        }

        using (RoomForm form = new RoomForm(selectedRoom))
        {
            while (form.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    repository.Update(form.CurrentRoom);
                }
                catch (Exception exception)
                {
                    ShowActionError("update the room", exception);
                    form.DialogResult = DialogResult.None;
                    continue;
                }

                ClearFilters();
                LoadRooms("Room " + form.CurrentRoom.RoomNumber + " updated. Filters cleared.");
                break;
            }
        }
    }

    private void dgvRooms_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            btnEdit_Click(sender, EventArgs.Empty);
        }
    }

    private void btnDelete_Click(object? sender, EventArgs e)
    {
        Room? selectedRoom = GetSelectedRoom();
        if (selectedRoom == null)
        {
            return;
        }

        DialogResult confirmation = MessageBox.Show(this,
            "Delete room " + selectedRoom.RoomNumber + "? This removes it from the database.",
            "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2);
        if (confirmation != DialogResult.Yes)
        {
            return;
        }

        try
        {
            repository.Delete(selectedRoom.Id);
        }
        catch (Exception exception)
        {
            ShowActionError("delete the room", exception);
            return;
        }

        LoadRooms("Room " + selectedRoom.RoomNumber + " deleted.");
    }

    private void dgvRooms_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || dgvRooms.Rows[e.RowIndex].DataBoundItem is not Room room)
        {
            return;
        }

        if (room.Status == "Occupied")
        {
            e.CellStyle.BackColor = Color.FromArgb(252, 232, 231);
        }
        else if (room.Status == "Cleaning")
        {
            e.CellStyle.BackColor = Color.FromArgb(255, 246, 215);
        }
        else
        {
            e.CellStyle.BackColor = Color.FromArgb(233, 246, 238);
        }
    }

    private void btnExport_Click(object? sender, EventArgs e)
    {
        if (displayedRooms.Count == 0)
        {
            MessageBox.Show(this, "There are no displayed rooms to export.", "Export CSV",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using (SaveFileDialog dialog = new SaveFileDialog())
        {
            dialog.Title = "Export displayed rooms";
            dialog.Filter = "CSV files (*.csv)|*.csv";
            dialog.FileName = "HotelRooms.csv";
            dialog.DefaultExt = "csv";
            dialog.AddExtension = true;
            dialog.OverwritePrompt = true;
            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                CsvExporter.Export(dialog.FileName, displayedRooms);
                lblStatus.Text = $"Exported {displayedRooms.Count} displayed rooms to {dialog.FileName}";
            }
            catch (Exception exception)
            {
                ShowActionError("export the CSV file", exception);
            }
        }
    }

    private void ShowActionError(string action, Exception exception)
    {
        MessageBox.Show(this, "Could not " + action + ".\n\n" + exception.Message,
            "Operation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
