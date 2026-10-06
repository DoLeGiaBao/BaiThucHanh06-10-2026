using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bai5_4
{
    public partial class Form1 : Form
    {
        // Danh sách nhân viên
        private List<Employee> employees = new List<Employee>();

        public Form1()
        {
            InitializeComponent();

            // =====================================================
            // GẮN SỰ KIỆN CLICK CHO TREEVIEW
            // =====================================================

            tvDepartments.NodeMouseClick +=
                tvDepartments_NodeMouseClick;

            // =====================================================
            // CẤU HÌNH LISTVIEW
            // =====================================================

            SetupListView();

            // =====================================================
            // TẠO DỮ LIỆU MẪU
            // =====================================================

            CreateSampleData();

            // =====================================================
            // TẠO CÂY TREEVIEW
            // =====================================================

            CreateTreeView();

            // =====================================================
            // CẤU HÌNH COMBOBOX
            // =====================================================

            cboViewMode.Items.Clear();

            cboViewMode.Items.Add("Details");
            cboViewMode.Items.Add("SmallIcon");
            cboViewMode.Items.Add("LargeIcon");
            cboViewMode.Items.Add("Tile");

            // Mặc định Details
            cboViewMode.SelectedIndex = 0;

            // Ban đầu hiện tất cả nhân viên
            LoadEmployees(employees);
        }

        // =========================================================
        // FORM LOAD
        // =========================================================

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // =========================================================
        // CẤU HÌNH LISTVIEW
        // =========================================================

        private void SetupListView()
        {
            // Xóa các cột cũ
            lsvEmployees.Columns.Clear();

            // Chế độ Details
            lsvEmployees.View = View.Details;

            // Chọn cả dòng
            lsvEmployees.FullRowSelect = true;

            // Hiện đường kẻ
            lsvEmployees.GridLines = true;

            // Chỉ chọn 1 dòng
            lsvEmployees.MultiSelect = false;

            // Không mất lựa chọn khi ListView mất focus
            lsvEmployees.HideSelection = false;

            // ListView chiếm toàn bộ Panel2
            lsvEmployees.Dock = DockStyle.Fill;

            // =====================================================
            // CÁC CỘT
            // =====================================================

            lsvEmployees.Columns.Add(
                "Mã NV",
                90);

            lsvEmployees.Columns.Add(
                "Họ Tên",
                190);

            lsvEmployees.Columns.Add(
                "Chức vụ",
                160);

            lsvEmployees.Columns.Add(
                "Ngày vào làm",
                120);
        }

        // =========================================================
        // TẠO DỮ LIỆU MẪU
        // =========================================================

        private void CreateSampleData()
        {
            // =====================================================
            // PHÒNG KỸ THUẬT
            // =====================================================

            employees.Add(
                new Employee(
                    "NV001",
                    "Nguyễn Văn An",
                    "Developer",
                    new DateTime(2022, 3, 15),
                    "Phòng Kỹ thuật",
                    "Developer"
                )
            );

            employees.Add(
                new Employee(
                    "NV002",
                    "Trần Thị Bình",
                    "Tester",
                    new DateTime(2021, 7, 20),
                    "Phòng Kỹ thuật",
                    "Tester"
                )
            );

            employees.Add(
                new Employee(
                    "NV003",
                    "Lê Văn Cường",
                    "Developer",
                    new DateTime(2023, 1, 10),
                    "Phòng Kỹ thuật",
                    "Developer"
                )
            );

            // =====================================================
            // PHÒNG KINH DOANH
            // =====================================================

            employees.Add(
                new Employee(
                    "NV004",
                    "Phạm Thị Dung",
                    "Sales",
                    new DateTime(2020, 5, 12),
                    "Phòng Kinh doanh",
                    "Sales"
                )
            );

            employees.Add(
                new Employee(
                    "NV005",
                    "Hoàng Văn Em",
                    "Marketing",
                    new DateTime(2022, 9, 1),
                    "Phòng Kinh doanh",
                    "Marketing"
                )
            );

            employees.Add(
                new Employee(
                    "NV006",
                    "Vũ Thị Hoa",
                    "Sales",
                    new DateTime(2021, 11, 5),
                    "Phòng Kinh doanh",
                    "Sales"
                )
            );

            // =====================================================
            // PHÒNG NHÂN SỰ
            // =====================================================

            employees.Add(
                new Employee(
                    "NV007",
                    "Đỗ Văn Khánh",
                    "HR Manager",
                    new DateTime(2019, 4, 20),
                    "Phòng Nhân sự",
                    "HR Manager"
                )
            );

            employees.Add(
                new Employee(
                    "NV008",
                    "Nguyễn Thị Lan",
                    "HR Staff",
                    new DateTime(2023, 6, 15),
                    "Phòng Nhân sự",
                    "HR Staff"
                )
            );
        }

        // =========================================================
        // TẠO CÂY TREEVIEW
        // =========================================================

        private void CreateTreeView()
        {
            // Xóa dữ liệu cũ
            tvDepartments.Nodes.Clear();

            // =====================================================
            // CÔNG TY
            // =====================================================

            TreeNode companyNode =
                new TreeNode("Công ty AutoSpeed");

            companyNode.Tag = "COMPANY";

            // =====================================================
            // PHÒNG KINH DOANH
            // =====================================================

            TreeNode kinhDoanhNode =
                new TreeNode("Phòng Kinh doanh");

            kinhDoanhNode.Tag =
                "DEPARTMENT|Phòng Kinh doanh";

            // ----- Sales -----

            TreeNode salesNode =
                new TreeNode("Sales");

            salesNode.Tag =
                "POSITION|Sales";

            // ----- Marketing -----

            TreeNode marketingNode =
                new TreeNode("Marketing");

            marketingNode.Tag =
                "POSITION|Marketing";

            // Thêm chức vụ vào phòng
            kinhDoanhNode.Nodes.Add(salesNode);
            kinhDoanhNode.Nodes.Add(marketingNode);

            // =====================================================
            // PHÒNG KỸ THUẬT
            // =====================================================

            TreeNode kyThuatNode =
                new TreeNode("Phòng Kỹ thuật");

            kyThuatNode.Tag =
                "DEPARTMENT|Phòng Kỹ thuật";

            // ----- Developer -----

            TreeNode developerNode =
                new TreeNode("Developer");

            developerNode.Tag =
                "POSITION|Developer";

            // ----- Tester -----

            TreeNode testerNode =
                new TreeNode("Tester");

            testerNode.Tag =
                "POSITION|Tester";

            // Thêm chức vụ vào phòng
            kyThuatNode.Nodes.Add(developerNode);
            kyThuatNode.Nodes.Add(testerNode);

            // =====================================================
            // PHÒNG NHÂN SỰ
            // =====================================================

            TreeNode nhanSuNode =
                new TreeNode("Phòng Nhân sự");

            nhanSuNode.Tag =
                "DEPARTMENT|Phòng Nhân sự";

            // ----- HR Manager -----

            TreeNode hrManagerNode =
                new TreeNode("HR Manager");

            hrManagerNode.Tag =
                "POSITION|HR Manager";

            // ----- HR Staff -----

            TreeNode hrStaffNode =
                new TreeNode("HR Staff");

            hrStaffNode.Tag =
                "POSITION|HR Staff";

            // Thêm chức vụ vào phòng
            nhanSuNode.Nodes.Add(hrManagerNode);
            nhanSuNode.Nodes.Add(hrStaffNode);

            // =====================================================
            // THÊM CÁC PHÒNG VÀO CÔNG TY
            // =====================================================

            companyNode.Nodes.Add(kinhDoanhNode);
            companyNode.Nodes.Add(kyThuatNode);
            companyNode.Nodes.Add(nhanSuNode);

            // Thêm công ty vào TreeView
            tvDepartments.Nodes.Add(companyNode);

            // =====================================================
            // MỞ CÂY
            // =====================================================

            companyNode.Expand();
            kinhDoanhNode.Expand();
            kyThuatNode.Expand();
            nhanSuNode.Expand();
        }

        // =========================================================
        // HIỂN THỊ DANH SÁCH NHÂN VIÊN
        // =========================================================

        private void LoadEmployees(
            List<Employee> employeeList)
        {
            // Xóa danh sách cũ
            lsvEmployees.Items.Clear();

            // Thêm danh sách mới
            foreach (Employee employee in employeeList)
            {
                // Cột Mã NV
                ListViewItem item =
                    new ListViewItem(employee.MaNV);

                // Cột Họ Tên
                item.SubItems.Add(
                    employee.HoTen);

                // Cột Chức vụ
                item.SubItems.Add(
                    employee.ChucVu);

                // Cột Ngày vào làm
                item.SubItems.Add(
                    employee.NgayVaoLam
                    .ToString("dd/MM/yyyy"));

                // Thêm vào ListView
                lsvEmployees.Items.Add(item);
            }
        }

        // =========================================================
        // CLICK VÀO TREEVIEW
        // =========================================================

        private void tvDepartments_NodeMouseClick(
            object sender,
            TreeNodeMouseClickEventArgs e)
        {
            // Lấy node vừa click
            TreeNode node = e.Node;

            // Nếu node không có Tag
            if (node.Tag == null)
            {
                return;
            }

            // Lấy Tag
            string tag =
                node.Tag.ToString();

            // =====================================================
            // CLICK VÀO CÔNG TY
            // =====================================================

            if (tag == "COMPANY")
            {
                // Hiện toàn bộ nhân viên
                LoadEmployees(employees);

                return;
            }

            // =====================================================
            // CLICK VÀO PHÒNG BAN
            // =====================================================

            if (tag.StartsWith("DEPARTMENT|"))
            {
                string[] parts =
                    tag.Split('|');

                string phongBan =
                    parts[1];

                // Lọc theo phòng ban
                List<Employee> result =
                    employees.FindAll(
                        employee =>
                            employee.PhongBan == phongBan
                    );

                LoadEmployees(result);

                return;
            }

            // =====================================================
            // CLICK VÀO CHỨC VỤ
            // =====================================================

            if (tag.StartsWith("POSITION|"))
            {
                string[] parts =
                    tag.Split('|');

                // Lấy tên chức vụ
                string chucVu =
                    parts[1];

                // =================================================
                // CHỈ LẤY NHÂN VIÊN ĐÚNG CHỨC VỤ
                // =================================================

                List<Employee> result =
                    employees.FindAll(
                        employee =>
                            employee.ChucVu == chucVu
                    );

                // Hiển thị lên ListView
                LoadEmployees(result);

                return;
            }
        }

        // =========================================================
        // GIỮ LẠI HÀM AFTERSELECT
        // =========================================================
        // Designer của bạn hiện tại có thể đang gọi hàm này.
        // Để tránh lỗi CS1061, giữ hàm này nhưng không xử lý gì.

        private void tvDepartments_AfterSelect(
            object sender,
            TreeViewEventArgs e)
        {
        }

        // =========================================================
        // ĐỔI CHẾ ĐỘ HIỂN THỊ LISTVIEW
        // =========================================================

        private void cboViewMode_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            switch (cboViewMode.SelectedIndex)
            {
                // -----------------------------
                // Details
                // -----------------------------

                case 0:

                    lsvEmployees.View =
                        View.Details;

                    break;

                // -----------------------------
                // SmallIcon
                // -----------------------------

                case 1:

                    lsvEmployees.View =
                        View.SmallIcon;

                    break;

                // -----------------------------
                // LargeIcon
                // -----------------------------

                case 2:

                    lsvEmployees.View =
                        View.LargeIcon;

                    break;

                // -----------------------------
                // Tile
                // -----------------------------

                case 3:

                    lsvEmployees.View =
                        View.Tile;

                    break;
            }
        }
    }
}