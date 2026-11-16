#nullable enable

namespace HotelRooms;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;

    private Label lblTitle = null!;
    private Label lblSubtitle = null!;
    private Label lblSearch = null!;
    private TextBox txtSearch = null!;
    private Button btnSearch = null!;
    private Label lblRoomTypeFilter = null!;
    private ComboBox cmbRoomTypeFilter = null!;
    private Button btnClear = null!;
    private Button btnAdd = null!;
    private Button btnEdit = null!;
    private Button btnDelete = null!;
    private Button btnRefresh = null!;
    private Button btnExport = null!;
    private Label lblLegend = null!;
    private DataGridView dgvRooms = null!;
    private Label lblStatus = null!;
    private Label lblCount = null!;
    private DataGridViewTextBoxColumn colId = null!;
    private DataGridViewTextBoxColumn colRoomNumber = null!;
    private DataGridViewTextBoxColumn colRoomType = null!;
    private DataGridViewTextBoxColumn colFloor = null!;
    private DataGridViewTextBoxColumn colPricePerNight = null!;
    private DataGridViewTextBoxColumn colStatus = null!;
    private DataGridViewTextBoxColumn colBalcony = null!;
    private DataGridViewTextBoxColumn colDescription = null!;

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
        lblTitle = new Label();
        lblSubtitle = new Label();
        lblSearch = new Label();
        txtSearch = new TextBox();
        btnSearch = new Button();
        lblRoomTypeFilter = new Label();
        cmbRoomTypeFilter = new ComboBox();
        btnClear = new Button();
        btnAdd = new Button();
        btnEdit = new Button();
        btnDelete = new Button();
        btnRefresh = new Button();
        btnExport = new Button();
        lblLegend = new Label();
        dgvRooms = new DataGridView();
        lblStatus = new Label();
        lblCount = new Label();
        colId = new DataGridViewTextBoxColumn();
        colRoomNumber = new DataGridViewTextBoxColumn();
        colRoomType = new DataGridViewTextBoxColumn();
        colFloor = new DataGridViewTextBoxColumn();
        colPricePerNight = new DataGridViewTextBoxColumn();
        colStatus = new DataGridViewTextBoxColumn();
        colBalcony = new DataGridViewTextBoxColumn();
        colDescription = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
        SuspendLayout();

        // lblTitle
        lblTitle.Name = "lblTitle";
        lblTitle.Text = "HOTEL ROOMS";
        lblTitle.Location = new Point(24, 18);
        lblTitle.Size = new Size(650, 36);
        lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(25, 55, 66);

        // lblSubtitle
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Text = "Room inventory  /  KIU C# Midterm  /  Giorgi Svanidze";
        lblSubtitle.Location = new Point(26, 60);
        lblSubtitle.Size = new Size(900, 24);
        lblSubtitle.ForeColor = Color.FromArgb(80, 95, 105);

        // lblSearch
        lblSearch.Name = "lblSearch";
        lblSearch.Text = "Search room number or description";
        lblSearch.Location = new Point(24, 104);
        lblSearch.Size = new Size(390, 24);

        // txtSearch
        txtSearch.Name = "txtSearch";
        txtSearch.Text = "";
        txtSearch.Location = new Point(24, 130);
        txtSearch.Size = new Size(394, 28);
        txtSearch.TabIndex = 0;
        txtSearch.MaxLength = 150;

        // btnSearch
        btnSearch.Name = "btnSearch";
        btnSearch.Text = "&Search";
        btnSearch.Location = new Point(428, 126);
        btnSearch.Size = new Size(100, 34);
        btnSearch.TabIndex = 1;

        // lblRoomTypeFilter
        lblRoomTypeFilter.Name = "lblRoomTypeFilter";
        lblRoomTypeFilter.Text = "Room type";
        lblRoomTypeFilter.Location = new Point(550, 104);
        lblRoomTypeFilter.Size = new Size(150, 24);

        // cmbRoomTypeFilter
        cmbRoomTypeFilter.Name = "cmbRoomTypeFilter";
        cmbRoomTypeFilter.Text = "";
        cmbRoomTypeFilter.Location = new Point(550, 130);
        cmbRoomTypeFilter.Size = new Size(180, 28);
        cmbRoomTypeFilter.TabIndex = 2;
        cmbRoomTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbRoomTypeFilter.Items.AddRange(new object[] { "All", "Single", "Double", "Suite" });

        // btnClear
        btnClear.Name = "btnClear";
        btnClear.Text = "&Clear";
        btnClear.Location = new Point(744, 126);
        btnClear.Size = new Size(100, 34);
        btnClear.TabIndex = 3;

        // btnAdd
        btnAdd.Name = "btnAdd";
        btnAdd.Text = "&Add room";
        btnAdd.Location = new Point(24, 181);
        btnAdd.Size = new Size(114, 34);
        btnAdd.TabIndex = 4;

        // btnEdit
        btnEdit.Name = "btnEdit";
        btnEdit.Text = "&Edit room";
        btnEdit.Location = new Point(148, 181);
        btnEdit.Size = new Size(114, 34);
        btnEdit.TabIndex = 5;

        // btnDelete
        btnDelete.Name = "btnDelete";
        btnDelete.Text = "&Delete room";
        btnDelete.Location = new Point(272, 181);
        btnDelete.Size = new Size(114, 34);
        btnDelete.TabIndex = 6;

        // btnRefresh
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Text = "&Refresh";
        btnRefresh.Location = new Point(398, 181);
        btnRefresh.Size = new Size(110, 34);
        btnRefresh.TabIndex = 7;

        // btnExport
        btnExport.Name = "btnExport";
        btnExport.Text = "Export CS&V";
        btnExport.Location = new Point(520, 181);
        btnExport.Size = new Size(124, 34);
        btnExport.TabIndex = 8;

        // lblLegend
        lblLegend.Name = "lblLegend";
        lblLegend.Text = "Free: green   |   Occupied: red   |   Cleaning: yellow";
        lblLegend.Location = new Point(670, 188);
        lblLegend.Size = new Size(490, 25);
        lblLegend.ForeColor = Color.FromArgb(80, 95, 105);

        // dgvRooms
        dgvRooms.Name = "dgvRooms";
        dgvRooms.Text = "";
        dgvRooms.Location = new Point(24, 232);
        dgvRooms.Size = new Size(1136, 360);
        dgvRooms.TabIndex = 9;
        dgvRooms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvRooms.ReadOnly = true;
        dgvRooms.AutoGenerateColumns = false;
        dgvRooms.AllowUserToAddRows = false;
        dgvRooms.AllowUserToDeleteRows = false;
        dgvRooms.AllowUserToResizeRows = false;
        dgvRooms.MultiSelect = false;
        dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRooms.RowHeadersVisible = false;
        dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvRooms.BackgroundColor = Color.White;
        dgvRooms.BorderStyle = BorderStyle.FixedSingle;
        dgvRooms.ColumnHeadersHeight = 38;
        dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgvRooms.RowTemplate.Height = 30;

        // lblStatus
        lblStatus.Name = "lblStatus";
        lblStatus.Text = "Loading rooms...";
        lblStatus.Location = new Point(24, 608);
        lblStatus.Size = new Size(910, 52);
        lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        // lblCount
        lblCount.Name = "lblCount";
        lblCount.Text = "";
        lblCount.Location = new Point(946, 608);
        lblCount.Size = new Size(214, 28);
        lblCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        lblCount.TextAlign = ContentAlignment.TopRight;

        colId.Name = "colId";
        colId.DataPropertyName = nameof(Room.Id);
        colId.HeaderText = "Id";
        colId.FillWeight = 20F;
        colId.MinimumWidth = 25;
        colId.SortMode = DataGridViewColumnSortMode.NotSortable;
        colId.Visible = false;

        colRoomNumber.Name = "colRoomNumber";
        colRoomNumber.DataPropertyName = nameof(Room.RoomNumber);
        colRoomNumber.HeaderText = "Room number";
        colRoomNumber.FillWeight = 90F;
        colRoomNumber.MinimumWidth = 85;
        colRoomNumber.SortMode = DataGridViewColumnSortMode.NotSortable;

        colRoomType.Name = "colRoomType";
        colRoomType.DataPropertyName = nameof(Room.RoomType);
        colRoomType.HeaderText = "Room type";
        colRoomType.FillWeight = 85F;
        colRoomType.MinimumWidth = 80;
        colRoomType.SortMode = DataGridViewColumnSortMode.NotSortable;

        colFloor.Name = "colFloor";
        colFloor.DataPropertyName = nameof(Room.Floor);
        colFloor.HeaderText = "Floor";
        colFloor.FillWeight = 50F;
        colFloor.MinimumWidth = 50;
        colFloor.SortMode = DataGridViewColumnSortMode.NotSortable;

        colPricePerNight.Name = "colPricePerNight";
        colPricePerNight.DataPropertyName = nameof(Room.PricePerNight);
        colPricePerNight.HeaderText = "Price per night (GEL)";
        colPricePerNight.FillWeight = 120F;
        colPricePerNight.MinimumWidth = 130;
        colPricePerNight.SortMode = DataGridViewColumnSortMode.NotSortable;
        colPricePerNight.DefaultCellStyle.Format = "N2";

        colStatus.Name = "colStatus";
        colStatus.DataPropertyName = nameof(Room.Status);
        colStatus.HeaderText = "Status";
        colStatus.FillWeight = 90F;
        colStatus.MinimumWidth = 85;
        colStatus.SortMode = DataGridViewColumnSortMode.NotSortable;

        colBalcony.Name = "colBalcony";
        colBalcony.DataPropertyName = nameof(Room.Balcony);
        colBalcony.HeaderText = "Balcony";
        colBalcony.FillWeight = 65F;
        colBalcony.MinimumWidth = 65;
        colBalcony.SortMode = DataGridViewColumnSortMode.NotSortable;

        colDescription.Name = "colDescription";
        colDescription.DataPropertyName = nameof(Room.Description);
        colDescription.HeaderText = "Description";
        colDescription.FillWeight = 390F;
        colDescription.MinimumWidth = 240;
        colDescription.SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvRooms.Columns.AddRange(new DataGridViewColumn[] { colId, colRoomNumber, colRoomType, colFloor, colPricePerNight, colStatus, colBalcony, colDescription });

        // Form
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Font = new Font("Segoe UI", 9F);
        Name = "MainForm";
        Text = "Hotel Rooms — Giorgi Svanidze";
        ClientSize = new Size(1184, 674);
        MinimumSize = new Size(1080, 620);
        StartPosition = FormStartPosition.CenterScreen;
        Load += MainForm_Load;
        btnSearch.Click += btnSearch_Click;
        txtSearch.KeyDown += txtSearch_KeyDown;
        cmbRoomTypeFilter.SelectedIndexChanged += cmbRoomTypeFilter_SelectedIndexChanged;
        btnClear.Click += btnClear_Click;
        btnAdd.Click += btnAdd_Click;
        btnEdit.Click += btnEdit_Click;
        btnDelete.Click += btnDelete_Click;
        btnRefresh.Click += btnRefresh_Click;
        btnExport.Click += btnExport_Click;
        dgvRooms.CellDoubleClick += dgvRooms_CellDoubleClick;
        dgvRooms.CellFormatting += dgvRooms_CellFormatting;
        Controls.AddRange(new Control[] { lblTitle, lblSubtitle, lblSearch, txtSearch, btnSearch, lblRoomTypeFilter, cmbRoomTypeFilter, btnClear, btnAdd, btnEdit, btnDelete, btnRefresh, btnExport, lblLegend, dgvRooms, lblStatus, lblCount });
        ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
