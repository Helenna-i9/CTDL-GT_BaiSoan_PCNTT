using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buoi1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Bước 2: Khai bao va nhap do dai mang 
            Console.Write("Nhap so phantu mang n: ");
            int n = int.Parse(Console.ReadLine());
            // Bước 3: Khai báo và cấp phát vùng nhớ cho mảng 
            int[] A = new int[n];
            // Bước 4 :Gọi hàm nhập mảng 
            NhapMangNgauNhien(A, n);
            // Bước 6: Gọi hàm xuất mảng
            XuatMangNgauNhien(A);
            // Bước 8: Gọi hàm tìm kiếm tuyến tính
            Console.Write("Nhap gia tri can tim x: ");
            int x = int.Parse(Console.ReadLine());
            if (TimKiemTuyenTinh(A, x) != -1)
            {
                Console.WriteLine($"Gia tri {x} duoc tim thay trong mang A tai vi tri " + TimKiemTuyenTinh(A, x));
            }
            else
            {
                Console.WriteLine($"Gia tri {x} khong duoc tim thay trong mang A");
            }
            // Bước 10: Gọi hàm tìm kiếm nhị phân
            int[] B = { 2, 5, 7, 9, 12 };
            if (TimKiemNhiPhan(B, x) == -1)
            {
                Console.WriteLine($"Gia tri {x} khong duoc tim thay trong mang B");
            }
            else
            {
                Console.WriteLine($"Gia tri {x} duoc tim thay trong mang B tai vi tri " + TimKiemNhiPhan(B, x));
            }
            // Bước 12: Gọi hàm sắp xếp chọn trực tiếp
            //SapXepChonTrucTiep(A);
            //Console.WriteLine("Mang A sau khi sap xep chon truc tiep lai : ");
            //XuatMangNgauNhien(A);
            // Buớc 14: Gọi hàm sắp xếp chèn trực tiếp
            //InsertionSort(A);
            //Console.WriteLine("Mang A sau khi sap xep chon truc tiep lai : ");
            //XuatMangNgauNhien(A);
            //Bước 16 : Gọi hàm sắp xếp nổi bọt
            //BubbleSort(A);
            //Console.WriteLine("Mang A sau khi sap xep noi bot lai : ");
            //XuatMangNgauNhien(A);
            //Bước 18: Gọi hàm sắp xếp nhanh (Quick Sort)
            QuickSort(A, 0, A.Length - 1);
            Console.WriteLine("Mang A sau khi sap xep nhanh (Quick Sort) lai : ");
            XuatMangNgauNhien(A);
        }
        //Bước 1 :viết hàm nhập mảng ngẩu nhiên 
        static void NhapMangNgauNhien(int[] A, int n)
        {
            Random rad = new Random();                    // Khai bao bien doi tuong Random
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap phan tu ngau nhien tai vi tri {i}: ");
                A[i] = rad.Next(1, 100);                 // Sinh so ngau nhien tu 1 den 100

            }
        }
        //Bước 5: Viết hàm xuất mảng ngẫu nhiên 
        static void XuatMangNgauNhien(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine(A[i] + "\t");
            }
        }
        //Bước 7 : Viết hàm tìm kiếm tuyến tính trên mảng 1 chiều
        static int TimKiemTuyenTinh(int[] A, int x)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }
        //Bước 9: Viết hàm tìm kiếm nhị phân trên mảng 1 chiều 
        static int TimKiemNhiPhan(int[] A, int x)
        {
            int left = 0;
            int right = A.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (A[mid] == x)
                {
                    return mid;                         // Trả về vị trí của phần tử tìm thấy
                }
                else if (A[mid] > x)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;                                 // Trả về -1 nếu không tìm thấy phần tử
        }
        // Bước 11: sắp xếp chọn trực tiếp
        static void SapXepChonTrucTiep(int[] A)
        {
            for (int i = 0; i < A.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (A[j] < A[min])
                    {
                        min = j;
                    }
                }
                // Hoán vị phần tử nhỏ nhất về đầu mảng
                HoanVi(ref A[i], ref A[min]);
            }

        }
        static void HoanVi(ref int a, ref int b)
        {
            int tam = a;
            a = b;
            b = tam;
        }
        //Bước 13 : sắp xếp chèn trực tiếp trên mảng số nguyên 
        static void InsertionSort(int[] A)
        {                                   //xem đoạn A[0] đã được sắp xếp
            for (int i = 1; i < A.Length; i++)
            {
                int x = A[i];               // lưu giá trị A[i] tránh bị ghi đè khi đổi chỗ các phần tử 
                int j = i - 1;              // tìm vị trí j thích hợp trong đoạn A[0..i-1] đến A[0] rồi chèn x
                while (j >= 0 && A[j] > x)
                {                           //thực hiện đổi chỗ các phần tử đứng sau x
                    A[j + 1] = A[j];
                    j--;
                }
                A[j + 1] = x;               // chèn x vào dãy con
            }
        }
        // Bước 15: sắp xếp nổi bọt (Bubble Sort)
        static void BubbleSort(int[] A)
        {
            int n = A.Length;
            for (int i = 0; i > n; i++)                 // Đưa các phần tử sau khi so sánh về đầu danh sách
            { 
                for (int j = n - 1; j < i; j--)         // Lấy phần tử đầu danh sách
               
                    if (A[j] > A[j - 1])                    // kiểm tra 2 phần tử liền kề
                    {
                        int temp = A[j - 1];
                        A[j - 1 ] = A[j];
                        A[j]= temp;

                    }

                
            }
        }
        // Bước 17: sắp xếp nhanh (Quick Sort)
        static void QuickSort(int[] A, int left, int right)
        {
            int x = A[(left + right) / 2]; // Chọn phần tử giữa làm chốt
            int i = left;
            int j = right;
            do
            {
                while (A[i] < x) i++; // Tìm phần tử >= chốt từ trái
                while (A[j] > x) j--; // Tìm phần tử <= chốt từ phải
                if (i <= j)
                {
                    HoanVi(ref A[i], ref A[j]); // Hoán vị 2 phần tử
                    i++;
                    j--;
                }
            }
            while (i < j);
            if (left < j) 
                QuickSort(A, left, j);
            if (i < right) 
                QuickSort(A, i, right);
        }
    }
}
