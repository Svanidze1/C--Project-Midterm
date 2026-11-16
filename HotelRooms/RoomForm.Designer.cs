#nullable enable

namespace HotelRooms;

partial class RoomForm
{
    private System.ComponentModel.IContainer? components = null;

    private Label lblHeading = null!;
    private Label lblSubtitle = null!;
    private Label lblRoomNumber = null!;
    private TextBox txtRoomNumber = null!;
    private Label lblRoomType = null!;
    private ComboBox cmbRoomType = null!;
    private Label lblFloor = null!;
    private NumericUpDown numFloor = null!;
    private Label lblPricePerNight = null!;
    private NumericUpDown numPricePerNight = null!;
    private Label lblRoomStatus = null!;
    private ComboBox cmbStatus = null!;
    private CheckBox chkHasBalcony = null!;
    private Label lblDescription = null!;
    private TextBox txtDescription = null!;
    private Label lblNumberHint = null!;
    private Button btnSave = null!;
    private Button btnCancel = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblHeading = new Label();
        lblSubtitle = new Label();
        lblRoomNumber = new Label();
        txtRoomNumber = new TextBox();
        lblRoomType = new Label();
        cmbRoomType = new ComboBox();
        lblFloor = new Label();
        numFloor = new NumericUpDown();
        lblPricePerNight = new Label();
        numPricePerNight = new NumericUpDown();
        lblRoomStatus = new Label();
        cmbStatus = new ComboBox();
        chkHasBalcony = new CheckBox();
        lblDescription = new Label();
        txtDescription = new TextBox();
        lblNumberHint = new Label();
        btnSave = new Button();
        btnCancel = new Button();
        ((System.ComponentModel.ISupportInitialize)numFloor).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numPricePerNight).BeginInit();
        SuspendLayout();

        // lblHeading
        lblHeading.Name = "lblHeading";
        lblHeading.Text = "Add room";
        lblHeading.Location = new Point(24, 20);
        lblHeading.Size = new Size(500, 32);
        lblHeading.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
        lblHeading.ForeColor = Color.FromArgb(25, 55, 66);

        // lblSubtitle
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Text = "Enter room details. Prices are in Georgian lari (GEL).";
        lblSubtitle.Location = new Point(26, 60);
        lblSubtitle.Size = new Size(500, 24);

        // lblRoomNumber
        lblRoomNumber.Name = "lblRoomNumber";
        lblRoomNumber.Text = "Room number";
        lblRoomNumber.Location = new Point(26, 101);
        lblRoomNumber.Size = new Size(150, 24);

        // txtRoomNumber
        txtRoomNumber.Name = "txtRoomNumber";
        txtRoomNumber.Text = "";
        txtRoomNumber.Location = new Point(186, 96);
        txtRoomNumber.Size = new Size(342, 26);
        txtRoomNumber.TabIndex = 0;
        txtRoomNumber.MaxLength = 4;

        // lblRoomType
        lblRoomType.Name = "lblRoomType";
        lblRoomType.Text = "Room type";
        lblRoomType.Location = new Point(26, 141);
        lblRoomType.Size = new Size(150, 24);

        // cmbRoomType
        cmbRoomType.Name = "cmbRoomType";
        cmbRoomType.Text = "";
        cmbRoomType.Location = new Point(186, 136);
        cmbRoomType.Size = new Size(342, 26);
        cmbRoomType.TabIndex = 1;
        cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbRoomType.Items.AddRange(new object[] { "Single", "Double", "Suite" });

        // lblFloor
        lblFloor.Name = "lblFloor";
        lblFloor.Text = "Floor";
        lblFloor.Location = new Point(26, 181);
        lblFloor.Size = new Size(150, 24);

        // numFloor
        numFloor.Name = "numFloor";
        numFloor.Text = "";
        numFloor.Location = new Point(186, 176);
        numFloor.Size = new Size(342, 26);
        numFloor.TabIndex = 2;
        numFloor.Minimum = 1;
        numFloor.Maximum = 20;
        numFloor.Value = 1;

        // lblPricePerNight
        lblPricePerNight.Name = "lblPricePerNight";
        lblPricePerNight.Text = "Price per night (GEL)";
        lblPricePerNight.Location = new Point(26, 221);
        lblPricePerNight.Size = new Size(150, 24);

        // numPricePerNight
        numPricePerNight.Name = "numPricePerNight";
        numPricePerNight.Text = "";
        numPricePerNight.Location = new Point(186, 216);
        numPricePerNight.Size = new Size(342, 26);
        numPricePerNight.TabIndex = 3;
        numPricePerNight.Minimum = 1;
        numPricePerNight.Maximum = 10000;
        numPricePerNight.DecimalPlaces = 2;
        numPricePerNight.Increment = 5;
        numPricePerNight.Value = 100;
        numPricePerNight.ThousandsSeparator = true;

        // lblRoomStatus
        lblRoomStatus.Name = "lblRoomStatus";
        lblRoomStatus.Text = "Status";
        lblRoomStatus.Location = new Point(26, 261);
        lblRoomStatus.Size = new Size(150, 24);

        // cmbStatus
        cmbStatus.Name = "cmbStatus";
        cmbStatus.Text = "";
        cmbStatus.Location = new Point(186, 256);
        cmbStatus.Size = new Size(342, 26);
        cmbStatus.TabIndex = 4;
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbStatus.Items.AddRange(new object[] { "Free", "Occupied", "Cleaning" });

        // chkHasBalcony
        chkHasBalcony.Name = "chkHasBalcony";
        chkHasBalcony.Text = "Has a balcony";
        chkHasBalcony.Location = new Point(186, 296);
        chkHasBalcony.Size = new Size(342, 26);
        chkHasBalcony.TabIndex = 5;

        // lblDescription
        lblDescription.Name = "lblDescription";
        lblDescription.Text = "Description";
        lblDescription.Location = new Point(26, 341);
        lblDescription.Size = new Size(150, 24);

        // txtDescription
        txtDescription.Name = "txtDescription";
        txtDescription.Text = "";
        txtDescription.Location = new Point(186, 336);
        txtDescription.Size = new Size(342, 26);
        txtDescription.TabIndex = 6;
        txtDescription.MaxLength = 150;

        // lblNumberHint
        lblNumberHint.Name = "lblNumberHint";
        lblNumberHint.Text = "Room rule: 101 = floor 1, room 01; 1205 = floor 12, room 05.\nUse room suffixes 01–99. All fields are required.";
        lblNumberHint.Location = new Point(26, 378);
        lblNumberHint.Size = new Size(508, 42);
        lblNumberHint.ForeColor = Color.FromArgb(90, 100, 110);

        // btnSave
        btnSave.Name = "btnSave";
        btnSave.Text = "&Save";
        btnSave.Location = new Point(314, 440);
        btnSave.Size = new Size(102, 34);
        btnSave.TabIndex = 7;

        // btnCancel
        btnCancel.Name = "btnCancel";
        btnCancel.Text = "&Cancel";
        btnCancel.Location = new Point(426, 440);
        btnCancel.Size = new Size(102, 34);
        btnCancel.TabIndex = 8;
        btnCancel.DialogResult = DialogResult.Cancel;

        // Form
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Segoe UI", 9F);
        Name = "RoomForm";
        Text = "Add room";
        ClientSize = new Size(558, 496);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        AcceptButton = btnSave;
        CancelButton = btnCancel;
        
        btnSave.Click += btnSave_Click;
        Controls.AddRange(new Control[] { lblHeading, lblSubtitle, lblRoomNumber, txtRoomNumber, lblRoomType, cmbRoomType, lblFloor, numFloor, lblPricePerNight, numPricePerNight, lblRoomStatus, cmbStatus, chkHasBalcony, lblDescription, txtDescription, lblNumberHint, btnSave, btnCancel });
        ((System.ComponentModel.ISupportInitialize)numFloor).EndInit();
        ((System.ComponentModel.ISupportInitialize)numPricePerNight).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
