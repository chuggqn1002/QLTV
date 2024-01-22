using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BTL_QLTV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string str = "Data Source=LAPTOP-5A80NJ70\\SQLEXPRESS; " +
                            " Initial Catalog=QLTV1; " +
                            " Integrated Security=True;";
        SqlConnection conn = null;
        private void Form1_Load(object sender, EventArgs e)
        {   
            //Nhan vien
            conn = new SqlConnection(str);
            conn.Open();
            string sqlNV = "select * from NhanVien";
            SqlDataAdapter daNV = new SqlDataAdapter(sqlNV ,conn);
            DataTable dtNV = new DataTable();
            daNV.Fill(dtNV);
            dgvNhanVien.DataSource = dtNV;

            //Sach
            string sqlSach = "select Sach.MaSach ,Sach.TenSach ,Sach.Gia ,Sach.NamXuatBan ,TheLoai.TenTL,NhaXuatBan.TenNXB,NhaCungCap.TenNCC from Sach, TheLoai, NhaXuatBan, NhaCungCap where Sach.MaTL = TheLoai.MaTL and Sach.MaNXB = NhaXuatBan.MaNXB and Sach.MaNCC = NhaCungCap.MaNCC;";
            SqlDataAdapter daSach = new SqlDataAdapter(sqlSach, conn);
            DataTable dtSach = new DataTable();
            daSach.Fill(dtSach);
            dgvSach.DataSource = dtSach;

            //Phieu muon
            string sqlPM = "select PhieuMuon.MaPM as Stt ,SinhVien.HoTen as TenSV, SinhVien.MsSV, PhieuMuon.NgayMuon, PhieuMuon.NgayHenTra, NhanVien.HoTen as TenNV, Sach.MaSach from PhieuMuon, SinhVien, NhanVien, Sach where PhieuMuon.MaNV = NhanVien.MaNV and PhieuMuon.MsSV = SinhVien.MsSV and PhieuMuon.MaSach = Sach.MaSach;";
            SqlDataAdapter daPM = new SqlDataAdapter(sqlPM, conn);
            DataTable dtPM = new DataTable();
            daPM.Fill(dtPM);
            dgvPhieuMuon.DataSource = dtPM;
            cbTenNV.DataSource = dtNV;
            cbTenNV.DisplayMember = "HoTen";
            cbMaSach.DataSource = dtSach;
            cbMaSach.DisplayMember = "MaSach";

            //Thong ke

        }
        RadioButton rb = null;

        private void rbPhieuMuon_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                rb = (RadioButton)sender;
            }
        }

        private void btHT_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(rb.Text);
            if(rb != null)
            {
                switch (rb.Text)
                {
                    case "Phiếu mượn":
                        {
                            string sqlPM = "select PhieuMuon.MaPM as Stt ,SinhVien.HoTen as TenSV, SinhVien.MsSV, PhieuMuon.NgayMuon, PhieuMuon.NgayHenTra, NhanVien.HoTen as TenNV, Sach.MaSach from PhieuMuon, SinhVien, NhanVien, Sach where PhieuMuon.MaNV = NhanVien.MaNV and PhieuMuon.MsSV = SinhVien.MsSV and PhieuMuon.MaSach = Sach.MaSach;";
                            SqlDataAdapter daPM = new SqlDataAdapter(sqlPM, conn);
                            DataTable dtPM = new DataTable();
                            daPM.Fill(dtPM);
                            dgvThongKe.DataSource = dtPM;
                            break;
                        }
                    case "Nhà xuất bản":
                        {
                            string sqlNXB = "select * from NhaXuatBan";
                            SqlDataAdapter daNXB = new SqlDataAdapter(sqlNXB, conn);
                            DataTable dtNXB = new DataTable();
                            daNXB.Fill(dtNXB);
                            dgvThongKe.DataSource = dtNXB;
                            break;
                        }
                    case "Nhân viên":
                        {
                            string sqlNV = "select * from NhanVien";
                            SqlDataAdapter daNV = new SqlDataAdapter(sqlNV, conn);
                            DataTable dtNV = new DataTable();
                            daNV.Fill(dtNV);
                            dgvThongKe.DataSource = dtNV;
                            break;
                        }
                    case "Nhà cung cấp":
                        {
                            string sqlNCC = "select * from NhaCungCap";
                            SqlDataAdapter daNCC = new SqlDataAdapter(sqlNCC, conn);
                            DataTable dtNCC = new DataTable();
                            daNCC.Fill(dtNCC);
                            dgvThongKe.DataSource = dtNCC;
                            break;
                        }
                    case "Sinh viên":
                        {
                            string sqlSV = "select * from SinhVien";
                            SqlDataAdapter daSV = new SqlDataAdapter(sqlSV, conn);
                            DataTable dtSV = new DataTable();
                            daSV.Fill(dtSV);
                            dgvThongKe.DataSource = dtSV;
                            break;
                        }
                    case "Sách":
                        {
                            string sqlSach = "select Sach.MaSach ,Sach.TenSach ,Sach.Gia ,Sach.NamXuatBan ,TheLoai.TenTL,NhaXuatBan.TenNXB,NhaCungCap.TenNCC from Sach, TheLoai, NhaXuatBan, NhaCungCap where Sach.MaTL = TheLoai.MaTL and Sach.MaNXB = NhaXuatBan.MaNXB and Sach.MaNCC = NhaCungCap.MaNCC;";
                            SqlDataAdapter daSach = new SqlDataAdapter(sqlSach, conn);
                            DataTable dtSach = new DataTable();
                            daSach.Fill(dtSach);
                            dgvThongKe.DataSource = dtSach;
                            break;
                        }
                    case "Tác giả":
                        {
                            string sqlTG = "select * from TacGia";
                            SqlDataAdapter daTG = new SqlDataAdapter(sqlTG, conn);
                            DataTable dtTG = new DataTable();
                            daTG.Fill(dtTG);
                            dgvThongKe.DataSource = dtTG;
                            break;
                        }
                    default: { break; }
                }
            }
            
        }
    }
}
