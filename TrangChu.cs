using System;
using BaiTap_CShap.EF;
using BaiTap_CShap.DAO;
using System.Windows.Forms;

namespace BaiTap_CShap
{

    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddSinhVien add = new AddSinhVien();
            add.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataDAO dataDAO = new DataDAO();
            dataGridView1.Rows.Clear();
            foreach (var item in dataDAO.Data())
            {
                DataGridViewRow row1 = new DataGridViewRow();
                DataGridViewCell _cell;

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.Ma_SV;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.Ten_SV;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.NgaySinh;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.QueQuan;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewCheckBoxCell();
                _cell.Value = item.GioiTinh;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.HoKhauTT;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.DiemTB;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.MaKhoa;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.TenKhoa;
                row1.Cells.Add(_cell);

                dataGridView1.Rows.Add(row1);
            }
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
        public void CheckGT(bool s)
        {
            if (s)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
        }
        public bool radiobutton()
        {
            if (radioButton1.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string getMaSV(string s)
        {
            return s;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Deletetextbox();
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox1.Enabled = false;
            textBox2.Text = row.Cells[1].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(row.Cells[2].Value.ToString());
            CheckGT(Convert.ToBoolean(row.Cells[4].Value.ToString()));
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox4.Text = row.Cells[5].Value.ToString();
            textBox5.Text = row.Cells[6].Value.ToString();
            comboBox1.Text = row.Cells[8].Value.ToString();
        }
        private void TrangChu_Load(object sender, EventArgs e)
        {
            DataDAO dataDAO = new DataDAO();
            foreach (var item in dataDAO.GetTenK())
            {
                comboBox1.Items.Add(item.TenKhoa);
            }
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
        private void button3_Click(object sender, EventArgs e)
        {
            SinhVien sinhVien = new SinhVien();
            DataDAO dataDAO = new DataDAO();
            sinhVien.Ma_SV = textBox1.Text;
            sinhVien.Ten_SV = textBox2.Text;
            sinhVien.NgaySinh = Convert.ToDateTime(dateTimePicker1.Value);
            sinhVien.QueQuan = textBox3.Text;
            sinhVien.HoKhauTT = textBox4.Text;
            sinhVien.DiemTB = float.Parse(textBox5.Text);
            sinhVien.GioiTinh = radiobutton();
            sinhVien.MaKhoa = MaKhoa(comboBox1.Text);
            dataDAO.Update(sinhVien);
            Deletetextbox();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DataDAO dataDAO = new DataDAO();
            dataGridView1.Rows.Clear();
            foreach (var item in dataDAO.Search(textBox6.Text))
            {
                DataGridViewRow row1 = new DataGridViewRow();
                DataGridViewCell _cell;

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.Ma_SV;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.Ten_SV;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.NgaySinh;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.QueQuan;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewCheckBoxCell();
                _cell.Value = item.GioiTinh;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.HoKhauTT;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.DiemTB;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.MaKhoa;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.TenKhoa;
                row1.Cells.Add(_cell);

                dataGridView1.Rows.Add(row1);
            }
            Deletetextbox();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DataDAO dataDAO = new DataDAO();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[9].Value != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Ban Chac Chan Xoa !", "Xoa", MessageBoxButtons.YesNo);
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            dataDAO.Delete(dataGridView1.Rows[i].Cells[0].Value.ToString());
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
            }
        }
        private void comboBox4_Click(object sender, EventArgs e)
        {
            DataDAO dataDAO = new DataDAO();
            comboBox4.Items.Clear();
            foreach (var item in dataDAO.GetTenK())
            {
                comboBox4.Items.Add(item.TenKhoa);
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            DataDAO dataDAO = new DataDAO();
            dataGridView2.DataSource = dataDAO.GetHP(MaKhoa(comboBox4.Text));
            dataGridView3.Rows.Clear();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.Rows.Clear();
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            DataDAO dataDAO = new DataDAO();
            textBox8.Text = row.Cells[0].Value.ToString();
            textBox9.Text = row.Cells[1].Value.ToString();
            foreach (var item in dataDAO.GetSVHP(row.Cells[0].Value.ToString()))
            {

                DataGridViewRow row1 = new DataGridViewRow();
                DataGridViewCell _cell;

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.Ma_SV;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.Ten_SV;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.NgaySinh;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewCheckBoxCell();
                _cell.Value = item.GioiTinh;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.HoKhauTT;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.QueQuan;
                row1.Cells.Add(_cell);

                _cell = new DataGridViewTextBoxCell();
                _cell.Value = item.DiemTB;
                row1.Cells.Add(_cell);

                dataGridView3.Rows.Add(row1);
            }
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddHocPhan addHocPhan = new AddHocPhan();
            addHocPhan.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataDAO dataDAO = new DataDAO();
            HocPhan hocPhan = new HocPhan();
            hocPhan.Ma_HP = textBox8.Text;
            hocPhan.Ten_HP = textBox9.Text;
            dataDAO.UpdateHP(textBox8.Text,hocPhan);
            Deletetextbox();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            DataDAO dataDAO = new DataDAO();
            dataGridView2.DataSource =  dataDAO.SearchHP(textBox7.Text);
           
        }
    }
}
