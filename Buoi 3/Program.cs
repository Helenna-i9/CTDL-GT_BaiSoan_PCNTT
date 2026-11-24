using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buoi3
{  
    //Bước 1: Định nghĩa cấu trúc phân số 
    public class Phanso
    {
        public int tuSo;
        public int mauSo;
        // Bước 1.1 : Viết hàm khởi tạo không tham số
        // hàm khởi tạo tên hàm trùng tên class
        //không có kiểu trả về
        public Phanso()
        {
            tuSo = 0;
            mauSo = 1;
        }
        // bước 1.2 : Viết hàm khởi tạo 2 tham số
        public Phanso(int ts, int ms)
        {
            tuSo = ts;
            mauSo = ms;
        }
        // bước 1.3 : Viết hàm xuất phân số
        public void XuatPs()
        {
            Console.Write("{0}/{1}", tuSo , mauSo);
        }
        // Bước 1.4 : Viết hàm nhập phân số
        public void NhapPs()
        {
            Console.WriteLine("Nhap tu so: ");
            tuSo = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap mau so: ");
            mauSo = int.Parse(Console.ReadLine());
        }

    }// đóng class Phanso
    //==========================================
    //Bước 6 : định nghĩa cấu trúc 1 node trong danh sách liên kết
    public class Node
    {
        public Phanso data; // dữ liệu chứa trong node
        public Node pNext;
        // Bước 6.1 : Viết hàm khởi tạo không tham số
        public Node()
        {
        }
        // Bước 6.2 : Viết hàm khởi tạo có tham số
        public Node(Phanso ps)
        {
            data = ps;
            pNext = null;
        }
    }// đóng class
     //==========================================
     //Bước 7 : Định nghĩa cấu trúc danh sách liên kết
     public class DSLK
     {
        public Node pHead;
        public Node pTail;
        //Viết hàm khởi tạo không tham số 
        public DSLK() 
        { 
            pHead = null;
            pTail = null;

        }
        //Bước 8 : chèn danh sách liên kết 
        public void AddFirst(Node p)
        {
            if(pHead == null)
            {
                pHead = p;    // ds rỗng
                pTail = p;
                //pTail = pHead
            }
            else//
            {
                p.pNext = pHead;  // 1.cho con trỏ của Node p liên kết đến Node đầu (pHead)
                pHead = p;        // 2. Cập nhật lại Node đầu cho (pHead) là Node P
            }
        }
        public void InsertTail(Phanso x)      //tham số là 1 phân số 
        {
            Node p = new Node(x);
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
        //Viết hàm chen 1 Node sau node q
        //Viết hàm tìm 1 phân số k trong danh sách , trả về Node được tìm thấy
        public Node Search(Phanso k)
        {
            Node p = pHead;
            while ((p != null) && (p.data.tuSo != k.tuSo || p.data.mauSo != k.mauSo));
            p = p.pNext;
            return p;
        }
        //Viết hàm Chèn phân số x vào sau vị trí q
        public void InsertAfter(Node q , Phanso x)  // q:là Node tìm được , p:giá trị cần chèn
        {
                       //khia báo node p chứa giá trị x
            Node p = new Node(x);
            if(q != null)                 // nếu tìm thấy node q
            {
                p.pNext = q.pNext;         //1.node mới p trỏ đến node kế là node à q đang trỏ đến 
                q.pNext = p;          
                     //2. cập nhật lại node q trỏ đến Node mới p
                if(q == pTail)               //  Nếu tìm thấy node q 
                { 
                    pTail = p;               // cập nhật lại phần tử cuối là node mới p
                }
            }
            else
            {
                AddFirst(p);                // ngược lại không tìm thấy k trong danh sách : chèn vào đầu danh sách 
            }
        }
        // Viết hàm nhập danh sách liên kết phân số 
        public void NhapDSLK()
        {
            Boolean kiemtra = false;
            Phanso ps;               // khai báo biến đối tượng ps kiểu Phanso
            do
            {
                ps = new Phanso();  // khởi tạo giá trị rỗng cho biến đối tượng ps 
                ps.NhapPs();
                //Node p = new Node(ps); //tạo Node chứa phân số ps 
                //AddFirst(p);         // gọi hàm chèn đầu danh sách 
                InsertTail(ps);        // gọi hàm chèn cuối danh sách
                Console.Write("Ban muon tiep tuc nhap phan so khong (true/false): ");
                kiemtra = Boolean.Parse(Console.ReadLine());
            } while (kiemtra == true);
        } 
        
        // Viết hàm Xuất danh sách liên kết 
        public void Xuat_DSLK()
        {
            Node p = pHead;  // tạo Node p cho p chạy từ đầu đến cuối danh sách 
            while (p != null) 
            {
                p.data.XuatPs();   // xuất thông tin của Node
                Console.Write( "--->");  
                p = p.pNext;        // dịch chuyển sang phải 1 Node
            }
        }
  
        
 
     }// đóng danh sách liên kết 
      
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Bước 2: khai báo và khởi tạo đối tượng phân số
            //Phanso ps1 = new Phanso();
            //ps1.tuSo = 10;
            //ps1.mauSo = 20;

            //// Bước 3: Xuất phân số ps1
            //Console.WriteLine(ps1.tuSo);
            //Console.WriteLine(ps1.mauSo);
            //// xuất phân số ps1
            //Console.WriteLine("Phan so: "+ ps1.tuSo+ "/" +ps1.mauSo);
            //// Bước 4:Khai báo và khởi tạo đối tượng phân số ps2
            //Phanso ps2 = new Phanso(5, 9);
            //// Xuất phân số ps2
            //Console.WriteLine("Phan so 2 la: " + ps2.XuatPs());
            //// Bước 5: Khai báo và khởi tạo đối tượng phân số ps3
            //Phanso ps3 = new Phanso();
            //// Nhập phân số ps3
            //ps3.NhapPs();
            //// Xuất phân số ps3
            //Console.WriteLine("Phan so 3 la: " + ps3.XuatPs());
            //Bước 9 : Khai báo và khởi tạo danh sách liên kết 
            DSLK ds = new DSLK();
                ds.NhapDSLK();
                ds.Xuat_DSLK();
            // nhập phân số cần tìm và trả về Node tìm được 
            Console.WriteLine("\n nhap phan so can tim: ");
            Phanso k = new Phanso();
            Node q = ds.Search(k);
            Console.WriteLine("nhap phan so can them: ");
            Phanso psthem = new Phanso();
            psthem.NhapPs();
            ds.InsertAfer(q, psthem);
            Console.WriteLine("----------- DANH SACH PHAN SO SAU KHI CHEN VAO ------------");
            ds.Xuat_DSLK();

        }
    }
}
