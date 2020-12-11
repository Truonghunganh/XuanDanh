using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTap_CShap.EF;

namespace BaiTap_CShap.DAO
{
    public class DataDAO
    {
        SqlConnection sqlConnection;
        string Connect = @"Data Source=DESKTOP-0M6RQB0\DNX;Initial Catalog=SinhVien_BT;Integrated Security=True";

        public void AddSV(SinhVien sinhVien)
        {
            string sql = @"insert into [SinhVien_BT].[dbo].[SinhVien] values(@Ma_SV,@Ten_SV,@NgaySinh,@GioiTinh,@HoKhauTT,@QueQuan,@DiemTB,@MaKhoa)";
            using (sqlConnection = new SqlConnection(Connect))
            {
                sqlConnection.Open();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Ma_SV", sinhVien.Ma_SV);
                    sqlCommand.Parameters.AddWithValue("Ten_SV", sinhVien.Ten_SV);
                    sqlCommand.Parameters.AddWithValue("NgaySinh", sinhVien.NgaySinh);
                    sqlCommand.Parameters.AddWithValue("QueQuan", sinhVien.QueQuan);
                    sqlCommand.Parameters.AddWithValue("HoKhauTT", sinhVien.HoKhauTT);
                    sqlCommand.Parameters.AddWithValue("GioiTinh", sinhVien.GioiTinh);
                    sqlCommand.Parameters.AddWithValue("DiemTB", sinhVien.DiemTB);
                    sqlCommand.Parameters.AddWithValue("MaKhoa", sinhVien.MaKhoa);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nhap Lai Thong Tin");
                }
            }
        }
        public void Insert(HocPhan hocPhan)
        {
            var sql = @"insert into [SinhVien_BT].[dbo].[HocPhan] values(@Ma_HP,@Ten_HP,@Ma_SV,@Ma_D,@ID_Khoa)";
            using (sqlConnection = new SqlConnection(Connect))
            {
                sqlConnection.Open();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Ma_HP", hocPhan.Ma_HP);
                    sqlCommand.Parameters.AddWithValue("Ten_HP", hocPhan.Ten_HP);
                    sqlCommand.Parameters.AddWithValue("Ma_SV", hocPhan.Ma_SV);
                    sqlCommand.Parameters.AddWithValue("Ma_D", hocPhan.Ma_D);
                    sqlCommand.Parameters.AddWithValue("ID_Khoa", hocPhan.ID_Khoa);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nhap Lai Thong Tin ");
                }
            }
        }
        public void UpdateHP(string s,HocPhan hocPhan)
        {
            var sql = "Update [SinhVien_BT].[dbo].[HocPhan] set Ten_HP = @Ten_HP ,Ma_HP = @Ma_HP where Ma_HP = '" + s + "'";
            using (sqlConnection = new SqlConnection(Connect))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("Ten_HP", hocPhan.Ten_HP);
                    sqlCommand.Parameters.AddWithValue("Ma_HP", hocPhan.Ma_HP);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nhap Lai Thong Tin");
                }
            }
        }
        public List<SinhVien> Data()
        {
            DataTable dataTable = new DataTable();
            List<SinhVien> list = new List<SinhVien>();
            list.Clear();
            using (sqlConnection = new SqlConnection(Connect))
            {
                sqlConnection.Open();
                var sql = "select Ma_SV,Ten_SV,NgaySinh,HoKhauTT,GioiTinh,DiemTB,QueQuan,MaKhoa,TenKhoa from [SinhVien_BT].[dbo].[SinhVien] " +
                           "inner join [SinhVien_BT].[dbo].[Khoa] on ID_Khoa = MaKhoa";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    SinhVien sinhVien = new SinhVien();
                    sinhVien.Ma_SV = row["Ma_SV"].ToString();
                    sinhVien.Ten_SV = row["Ten_SV"].ToString();
                    sinhVien.NgaySinh = Convert.ToDateTime(row["NgaySinh"].ToString());
                    sinhVien.GioiTinh = bool.Parse(row["GioiTinh"].ToString());
                    sinhVien.HoKhauTT = row["HoKhauTT"].ToString();
                    sinhVien.QueQuan = row["QueQuan"].ToString();
                    sinhVien.DiemTB = float.Parse((row["DiemTB"].ToString()));
                    sinhVien.MaKhoa = row["MaKhoa"].ToString();
                    sinhVien.TenKhoa = row["TenKhoa"].ToString();
                    list.Add(sinhVien);
                }
            }
            return list;
        }
        public void Update(SinhVien sinhVien)
        {
            var sql = "update SinhVien set Ten_SV = @TenSV,NgaySinh = @NgaySinh,GioiTinh = @GioiTinh,HoKhauTT = @HoKhauTT,QueQuan = @QueQuan,MaKhoa = @MaKhoa where Ma_SV = @MaSV";
            using (sqlConnection = new SqlConnection(Connect))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("MaSV", sinhVien.Ma_SV);
                    sqlCommand.Parameters.AddWithValue("TenSV", sinhVien.Ten_SV);
                    sqlCommand.Parameters.AddWithValue("NgaySinh", sinhVien.NgaySinh);
                    sqlCommand.Parameters.AddWithValue("GioiTinh", sinhVien.GioiTinh);
                    sqlCommand.Parameters.AddWithValue("HoKhauTT", sinhVien.HoKhauTT);
                    sqlCommand.Parameters.AddWithValue("QueQuan", sinhVien.QueQuan);
                    sqlCommand.Parameters.AddWithValue("MaKhoa", sinhVien.MaKhoa);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Kiem tra thong tin");
                }
            }
        }
        public List<SinhVien> Search(string s)
        {
            DataTable dataTable = new DataTable();
            List<SinhVien> list = new List<SinhVien>();
            list.Clear();
            var sql = "select Ma_SV,Ten_SV,NgaySinh,HoKhauTT,GioiTinh,DiemTB,QueQuan,MaKhoa,TenKhoa from [SinhVien_BT].[dbo].[SinhVien]" +
                      "inner join[SinhVien_BT].[dbo].[Khoa] on ID_Khoa = MaKhoa where Ma_SV like '%" + s + "%'";
            using (sqlConnection = new SqlConnection(Connect))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    SinhVien sinhVien = new SinhVien();
                    sinhVien.Ma_SV = row["Ma_SV"].ToString();
                    sinhVien.Ten_SV = row["Ten_SV"].ToString();
                    sinhVien.NgaySinh = Convert.ToDateTime(row["NgaySinh"].ToString());
                    sinhVien.GioiTinh = bool.Parse(row["GioiTinh"].ToString());
                    sinhVien.HoKhauTT = row["HoKhauTT"].ToString();
                    sinhVien.QueQuan = row["QueQuan"].ToString();
                    sinhVien.DiemTB = float.Parse((row["DiemTB"].ToString()));
                    sinhVien.MaKhoa = row["MaKhoa"].ToString();
                    sinhVien.TenKhoa = row["TenKhoa"].ToString();
                    list.Add(sinhVien);
                }
            }
            return list;
        }
        public List<HocPhanN> SearchHP(string s) 
        {
            DataTable dataTable = new DataTable();
            List<HocPhanN> list = new List<HocPhanN>();
            var sql = "select Ma_HP,Ten_HP from HocPhan where Ma_HP like '%" + s + "%'";
            list.Clear();
            using (sqlConnection = new SqlConnection(Connect))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    HocPhanN hocPhan = new HocPhanN();
                    hocPhan.Ma_HP = row["Ma_HP"].ToString();
                    hocPhan.Ten_HP = row["Ten_HP"].ToString();
                    list.Add(hocPhan);
                }
            }
            return list;
        }
        public void Delete(string s)
        {
            var sql = "delete from SinhVien where Ma_SV = '" + s + "'";
            using (sqlConnection = new SqlConnection(Connect))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public List<HocPhanN> GetHP(string s)
        {
            List<HocPhanN> list = new List<HocPhanN>();
            DataTable dataTable = new DataTable();
            using (sqlConnection = new SqlConnection(Connect))
            {
                var sql = "select * from HocPhan where ID_Khoa = '" + s + "'";
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    HocPhanN hocPhan = new HocPhanN();
                    //hocPhan.ID_Khoa = row["ID_Khoa"].ToString();
                    hocPhan.Ten_HP = row["Ten_HP"].ToString();
                    //hocPhan.Ma_SV = row["Ma_SV"].ToString();
                    //hocPhan.Ma_D = row["Ma_D"].ToString();
                    hocPhan.Ma_HP = row["Ma_HP"].ToString();
                    list.Add(hocPhan);
                }
            }
            return list;
        }
        public List<SinhVien> GetSVHP(string s)
        {
            DataTable dataTable = new DataTable();
            List<SinhVien> list = new List<SinhVien>();
            SinhVien sinhVien = new SinhVien();
            var sql = "select a.Ma_SV,Ten_SV,NgaySinh,HoKhauTT,GioiTinh,QueQuan,DiemTB from SinhVien as a inner join HocPhan as b on a.Ma_SV = b.Ma_SV where Ma_HP = '" + s + "'";
            using (sqlConnection = new SqlConnection(Connect))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    sinhVien.Ma_SV = row["Ma_SV"].ToString();
                    sinhVien.Ten_SV = row["Ten_SV"].ToString();
                    sinhVien.NgaySinh = DateTime.Parse(row["NgaySinh"].ToString());
                    sinhVien.HoKhauTT = row["HoKhauTT"].ToString();
                    sinhVien.GioiTinh = Convert.ToBoolean(row["GioiTinh"].ToString());
                    sinhVien.QueQuan = row["QueQuan"].ToString();
                    sinhVien.DiemTB = float.Parse(row["DiemTB"].ToString());
                    list.Add(sinhVien);
                }
            }
            return list;
        }

        public List<Khoa> GetTenK()
        {
            List<Khoa> list = new List<Khoa>();
            DataTable dataTable = new DataTable();
            using (sqlConnection = new SqlConnection(Connect))
            {
                var sql = "select * from Khoa";
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    Khoa khoa = new Khoa();
                    khoa.ID_Khoa = row["ID_Khoa"].ToString();
                    khoa.TenKhoa = row["TenKhoa"].ToString();
                    list.Add(khoa);
                }
            }
            return list;
        }
    }
}
