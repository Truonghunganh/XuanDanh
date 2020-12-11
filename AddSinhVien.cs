using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTap_CShap.DAO;
using BaiTap_CShap.EF;

namespace BaiTap_CShap
{
    public partial class AddSinhVien : Form
    {
        public AddSinhVien()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
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
        public string MaKhoa()
        {
            if ("CongNgheThongTin".CompareTo(comboBox1.Text)==0) 
            {
                return "NVB123";
            }
            if ("Toan".CompareTo(comboBox1.Text) == 0) 
            {
                return "NVB124";
            }
            if ("Sinh".CompareTo(comboBox1.Text) == 0) 
            {
                return "NVB125";
            }
            if ("Hoa".CompareTo(comboBox1.Text) == 0)
            {
                return "NVB126";
            }
            return "";
        }
        public bool checkGT() 
        {
            if (radioButton1.Checked == true)
            {
                return true;
            }
            else return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SinhVien sinh = new SinhVien();
            Khoa khoa = new Khoa();
            DataDAO data = new DataDAO();
            sinh.Ma_SV = textBox2.Text;
            sinh.Ten_SV = textBox3.Text;
            sinh.NgaySinh = Convert.ToDateTime(dateTimePicker1.Text);
            sinh.QueQuan = textBox4.Text;
            sinh.HoKhauTT = textBox5.Text;
            sinh.GioiTinh = checkGT();
            sinh.DiemTB = float.Parse(textBox6.Text);
            sinh.MaKhoa = MaKhoa();
            khoa.ID_Khoa = MaKhoa();
            khoa.TenKhoa = comboBox1.Text;
            Deletetextbox();
            data.AddSV(sinh);
            Close();
        }

        private void AddSinhVien_Load(object sender, EventArgs e)
        {
            DataDAO dataDAO = new DataDAO();
            foreach (var item in dataDAO.GetTenK())
            {
                comboBox1.Items.Add(item.TenKhoa);
            }
        }
    }
}
