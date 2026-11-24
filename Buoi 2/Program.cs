using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buoi2
{
    public struct Sinhvien
    {   //Bước 1 : Định nghĩa cấu trúc Sinhvien
        //Bước 1.1: khai báo các biến để lưu thông tin 1 sinh viên
        public string MaSV, TenSV, ngaysinh, diachi;
        public bool gioitinh;
        public int tinhtrang;

        //Bước 1.2: viết hàm khởi tạo cho đối tượng Sinhvien
        public Sinhvien(string ma, string ten, string ngay, string dc, bool gt, int tt)
        {
            MaSV = ma;
            TenSV = ten;
            ngaysinh = ngay;
            diachi = dc;
            gioitinh = gt;
            tinhtrang = tt;
        }
        //Bước 1.3: viết hàm xuất thông tin sinh viên
        public void XuatSv() 
        {
            Console.WriteLine(" - Ma sinh vien: " + MaSV);
            Console.WriteLine(" - Ten sinh vien: " + TenSV);
            Console.WriteLine(" - Ngay sinh: " + ngaysinh);
            if (gioitinh == true)
                Console.WriteLine(" - Gioi tinh: Nam");
            else
                Console.WriteLine(" - Gioi tinh: Nu");
            Console.WriteLine(" - Dia chi: " + diachi);

            //tình trạng: 0 - đang học, 1 - đã tốt nghiệp , 2 - thôi học
            if (tinhtrang == 0)
                Console.WriteLine(" - Tinh trang: Dang hoc ");
            else if (tinhtrang == 1)
                Console.WriteLine(" - Tinh trang: Da Tot nghiep");
            else
                Console.WriteLine(" - Tinh trang: Thoi hoc");
        }
        //Bước 1.4: viết hàm nhập thông tin sinh viên
        public void NhapSv()
        {
            Console.Write("Nhap ma sinh vien: ");
            MaSV = Console.ReadLine();

            Console.Write("Nhap ten sinh vien: ");
            TenSV = Console.ReadLine();

            Console.Write("Nhap ngay sinh: ");
            ngaysinh = Console.ReadLine();

            Console.Write("Nhap dia chi: ");
            diachi = Console.ReadLine();
           
            Console.Write("Nhap gioi tinh (True = Nam, False = Nu): ");
            gioitinh = bool.Parse(Console.ReadLine());

            Console.Write("Nhap tinh trang (0 - Dang hoc, 1 - Da Tot nghiep, 2 - Thoi hoc): ");
            tinhtrang = int.Parse(Console.ReadLine());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bước 2: Khai báo và khởi tạo 1 đối tượng sinh viên thuộc kiểu Sinhvien
            Sinhvien sv1 = new Sinhvien("123", "Bin", "01/01/2007", "Vinh Long", true, 0);
            // Bước 3 :Xuất đối tượng sinh viên 1
            Console.WriteLine("-------- Thong tin sinh vien 1 -------- ");
            sv1.XuatSv();
            //Bước 4:Tạo đối tượng Sv2
            Sinhvien sv2 = new Sinhvien();
            sv2.MaSV = "456";
            sv2.TenSV = "Huy";
            sv2.ngaysinh = "02/02/2007";
            sv2.diachi = "Vinh Long";
            sv2.gioitinh = true;
            sv2.tinhtrang = 0;
            // Bước 5 :Xuất đối tượng sinh viên 2
            Console.WriteLine("-------- Thong tin sinh vien 2 -------- ");
            sv2.XuatSv();
            // Bước 6: Tạo đối tượng sinh viên 3 
            Sinhvien sv3 = new Sinhvien();
            Console.WriteLine("-------- Nhap thong tin sinh vien 3 -------- ");
            sv3.NhapSv();
            // Bước 7 :Xuất đối tượng sinh viên 3
            Console.WriteLine("-------- Thong tin sinh vien 3 -------- ");
            sv3.XuatSv();
            // Bước 8: Nhập danh sách sinh viên
            Console.Write("Nhap so luong sinh vien: ");
            int n = int.Parse(Console.ReadLine());
            // Khai báo và cấp phát bộ nhớ cho mảng sinh viên
            Sinhvien[] A = new Sinhvien[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"-------- Nhap sinh vien thu {i} -------- ");
                A[i].NhapSv();
            }
            // Bước 9: Xuất danh sách sinh viên
            Console.WriteLine("-------- Danh sach sinh vien -------- ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"-------- Thong tin sinh vien thu {i} -------- ");
                A[i].XuatSv();
            }
        }

    }
}
