using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi
{
    public class phanSo
    {
        public int tuSo;
        public int mauSo;

        // Hàm khởi tạo không tham số
        public phanSo()
        {
            tuSo = 0;
            mauSo = 1;
        }

        // Hàm khởi tạo 2 tham số.
        public phanSo(int ts, int ms)
        {
            tuSo = ts;
            mauSo = ms;
        }

        // Hàm nhập phân số
        public void nhapPS()
        {
            Console.Write("Nhập tử số: ");
            tuSo = int.Parse(Console.ReadLine());
            Console.Write("Nhập mẫu số: ");
            mauSo = int.Parse(Console.ReadLine());

            while (mauSo == 0)
            {
                Console.Write("Mẫu phải khác 0: ");
                mauSo = int.Parse(Console.ReadLine());
            }
        }
        public void xuatPS()
        {
            Console.WriteLine($"{tuSo} / {mauSo}");
        }
    }

    public class Node
    {
        public phanSo data;
        public Node pNext;

        public Node(phanSo ps)
        {
            data = ps;
            pNext = null;
        }
    }

    // Định nghĩa cấu trúc danh sách liên kết
    public class danhSachLienKet
    {
        // Khởi tạo biến 
        public Node pHead;
        public Node pTail;

        // Khởi tạo danh sách liên kết không tham số.
        public danhSachLienKet()
        {
            pHead = null;
            pTail = null;
        }     
        // Hàm thêm phần tử vào danh sách liên kết
        public void addFirst(Node p)
        {
            if (pHead == null)
            {
                pHead = p;
                pTail = p;
            }
            else
            {
                p.pNext = pHead;
                pHead = p;
            }
        }

        public void addLast(Node p)
        {
            if (pHead == null)
            {
                pHead = p;
                pTail = p;
            }
            else
            {
                pTail.pNext = p;
                pTail = p;
            }
        }

        public void nhapDSLK()
        {
            String kiemtra = "";
            phanSo ps;
            do
            {
                ps = new phanSo();
                ps.nhapPS();

                //Node p = new Node(ps);
                //addLast(p);
                insertTail(searsh(ps), ps);
                Console.Write("Bạn có muốn nhập tiếp không (y/n): ");
                kiemtra = Console.ReadLine();
            } while (kiemtra == "y");
        }

        public void xuatDSLK()
        {
            if (pHead == null)
            {
                Console.WriteLine("Danh sách rỗng");
                return;
            }

            Node p = pHead;
            while (p != null)
            {
                p.data.xuatPS();
                p = p.pNext;
            }
        }

        //chèn 1 phân số vào cuối danh sách liên kết
        public void insertTail(Node q, phanSo x)
        {
            Node p = new Node(x);
            if (q != null)
            {
                p.pNext = q.pNext;
                q.pNext = p;
                if (q == pTail)
                    pTail = p;
            }
            addFirst(p);
        }

        public Node searsh(phanSo x)
        {
            Node p = pHead;
            while ((p != null) && (p.data.tuSo != x.tuSo || p.data.mauSo != x.mauSo))
                p = p.pNext;
            return p;

        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //phanSo ps = new phanSo();
            //Console.WriteLine("Nhập phân số");
            //ps.nhapPS();

            //Console.WriteLine("Kết quả");
            //ps.xuatPS();


            danhSachLienKet dslk = new danhSachLienKet();
            Console.WriteLine("Nhập danh sách liên kết");
            dslk.nhapDSLK();
            dslk.xuatDSLK();

            Console.WriteLine("\n Nhập phân số cần tìm: ");
            phanSo ps1 = new phanSo();
            ps1.nhapPS();
            Node q = dslk.searsh(ps1);

            Console.WriteLine("\n Nhập phân số cần thêm: ");
            phanSo ps2 = new phanSo();
            ps2.nhapPS();
            dslk.insertTail(q, ps2);

            // Xuất danh sách liên kết sau khi thêm
            dslk.xuatDSLK();
        }
    }

}
