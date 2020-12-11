namespace BaiTap_CShap.EF
{
    using System;

    public class SinhVien
    {
        public string Ma_SV { get; set; }
        public string Ten_SV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QueQuan { get; set; }
        public string HoKhauTT { get; set; }
        public bool GioiTinh { get; set; }
        public float DiemTB { get; set; }
        public string MaKhoa { get; set; }
        public string TenKhoa { set; get; }
    }
}
