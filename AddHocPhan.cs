using System;
using BaiTap_CShap.DAO;
using System.Windows.Forms;
using BaiTap_CShap.EF;

namespace BaiTap_CShap
{
    public partial class AddHocPhan : Form
    {
        public AddHocPhan()
        {
            InitializeComponent();
        }
        public void Deletetextbox()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        public string MaKhoa(string s)
        {
            if ("CongNgheThongTin".CompareTo(s) == 0)
            {
                return "NVB123";
            }
            if ("Toan".CompareTo(s) == 0)
            {
                return "NVB124";
            }
            if ("Sinh".CompareTo(s) == 0)
            {
                return "NVB125";
            }
            if ("Hoa".CompareTo(s) == 0)
            {
                return "NVB126";
            }
            return "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataDAO dataDAO = new DataDAO();
            HocPhan hocPhan = new HocPhan();
            hocPhan.Ma_HP = textBox1.Text;
            hocPhan.Ten_HP = textBox2.Text;
            hocPhan.Ma_D = "";
            hocPhan.Ma_SV = "";
            hocPhan.ID_Khoa = MaKhoa(comboBox1.Text);
            dataDAO.Insert(hocPhan);
            Deletetextbox();
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void AddHocPhan_Load(object sender, EventArgs e)
        {
            DataDAO dataDAO = new DataDAO();
            comboBox1.Items.Clear();
            foreach (var item in dataDAO.GetTenK())
            {
                comboBox1.Items.Add(item.TenKhoa);
            }
        }
    }
}
