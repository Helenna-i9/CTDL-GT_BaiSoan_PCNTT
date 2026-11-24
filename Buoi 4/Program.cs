using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buoi4
{
    //BƯỚC 1: ĐỊNH NGHĨA CẤU TRÚC MÓN ĂN
    public class MonAn
    {
        //Bước 1.1: Khai báo các biến (thuộc tính món ăn)
        public int Id;
        public string Ten;
        public double GiaTien;
        //----------------
        //Buốc 1.2: hàm khởi tạo không tham số
        public MonAn()
        {
            Id = 0;
            Ten = "";
            GiaTien = 0;
        }
        //Bước 1.3: hàm khởi tạo có 3 tham số
        public MonAn(int id, string ten, double giaTien)
        {
            Id = id;
            Ten = ten;
            GiaTien = giaTien;
        }
        //----------------
        //Bước 1.4: Hàm nhập món ăn
        public void NhapMonAn()
        {
            //Nhập thông tin món ăn từ bàn phím
            Console.Write("Nhap ma mon an: ");
            Id = int.Parse(Console.ReadLine());
            //Nhập tên món ăn
            Console.Write("Nhap ten mon an: ");
            Ten = Console.ReadLine();
            //Nhập giá tiền món ăn
            Console.Write("Nhap gia tien mon an: ");
            GiaTien = double.Parse(Console.ReadLine());
        }
        //Bước 1.5: Hàm xuất món ăn
        public void XuatMonAn()
        {
            //Xuất thông tin món ăn ra màn hình
            Console.WriteLine(Id + " - " + Ten + " - " + GiaTien);
        }


    }//Đóng class MonAn

    //==============================
    //Bước 3: Định nghĩa 1 NODE (nút)
    public class Node
    {
        //Bước 3.1: Khai báo biến dữ liệu kiểu MonAn
        public MonAn Data;
        //Bước 3.2: Khai báo biến trỏ tới nút tiếp theo
        public Node Next;

        //----------------------------
        //Bước 3.3: Hàm khởi tạo 1 tham số (tham số là 1 MonAn)
        public Node(MonAn x)
        {
            Data = x ;
            Next = null;
        }

    }//Đóng class Node

    //=============================
    //Bước 4: Định nghĩa lớp danh sách liên kết ngăn xếp (stack)
    public class StackMonAn
    {
        //Bước 4.1: Khai báo biến
        private Node pHead;                //Đỉnh stack
        //Bước 4.2: Hàm khởi tạo không tham số
        public StackMonAn()
        {
            pHead = null;
        }
        //Bước 4.3: Hàm kiểm tra stack rỗng
        public bool IsEmpty()             //kiểm tra stack rỗng trả về true nếu rỗng, false nếu không rỗng
        {
            return pHead == null;
        }
        //Bước 4.4: Hàm đưa 1 món ăn vào đỉnh stack
        public void Push(MonAn x)         //Đưa 1 món ăn vào đỉnh stack
        {
            //Tạo node với tham số là 1 món ăn
            Node p = new Node(x);

            //Thềm node vào danh sách
            p.Next = pHead;                //Nối p vào đầu danh sách
            pHead = p;                    // p trở thành đỉnh mới

        }//Đóng hàm Push
        //Bước 4.5: Hàm xuất món ăn từ đỉnh xuống đáy
        public void XuatStack()
        {
            Console.WriteLine("Stack(Top -> Bottom):");
            Node p = pHead;                      //Tạo con trỏ p trỏ tới đỉnh stack
            while (p != null)                    //Duyệt danh sách liên kết
            {
                //Console.Write(p.Data + "   "); //Xuất thông tin món ăn
                p.Data.XuatMonAn();              //Xuất thông tin món ăn
                p = p.Next;                      //Di chuyển con trỏ p tới nút tiếp theo
            }
            Console.WriteLine();
        }//Đóng hàm XuatStack 
         //Bước 4.6: Pop - Hàm lấy 1 món ăn từ đỉnh stack và xóa nó khỏi stack
        public MonAn Pop()
        {
            if (IsEmpty()) // kiểm tra stack có rỗng không
            {
                Console.WriteLine("Stack rong!");//Nếu stack rỗng thì thông báo và trả về null
                return null;
            }
            //stack không rỗng, lấy món ăn từ đỉnh stack
            Node p = pHead;                     //Tạo con trỏ p trỏ tới đỉnh stack
            MonAn value = p.Data;               //Lấy giá trị món ăn tại node p
            pHead = pHead.Next;                 //Cập nhật đỉnh stack mới
            return value;                       //Trả về giá trị món ăn

        }//Đóng hàm Pop
        // Buoc 4.7: peak - xem món ăn ở dỉnh stack nhưng không xóa nó khỏi stack
        public MonAn Peak()
        {
            return IsEmpty() ? null : pHead.Data; //Nếu stack rỗng thì trả về null, nếu không rỗng thì trả về món ăn ở đỉnh stack

        }//Đóng hàm Peak
        //Bước 4.8: Hàm nhập stack từ bàn phím
       public void NhapStack()
        {
            string kiemtra = "";
            MonAn mon;
            do
            {
                mon = new MonAn();               // Khởi tạo món ăn
                mon.NhapMonAn();                 //Nhập thông tin món ăn từ bàn phím
                Push(mon);                       //Gọi hàm push thêm món ăn vào đỉnh stack
                Console.Write("Ban co muon nhap tiep khong (yes/no): ");
                kiemtra = Console.ReadLine();
            }while (kiemtra.ToLower() == "yes");
        }//Đóng hàm NhapStack

    }//Đóng class StackMonAn
    internal class Program
    {

        static void Main(string[] args)
        {
            //Bước 2: Tạo biến đối tượng thuộc lớp MonAn
            //MonAn monAn1 = new MonAn( 1,"Lau ga", 250000);
            //monAn1.XuatMonAn();
            //Bước 5: Tạo biến đối tượng thuộc lớp StackMonAn
            StackMonAn st = new StackMonAn(); //Khai báo biến đối tượng
            //MonAn monAn1 = new MonAn(1, "Lau ga", 250000);
            //st.Push(monAn1);                       //Đưa món ăn vào đỉnh stack
            //MonAn monAn2 = new MonAn(2, "Tom", 300000);
            //st.Push(monAn2);                       //Đưa món ăn vào đỉnh stack
            //MonAn monAn3 = new MonAn(3, "Cua", 400000);
            //st.Push(monAn3);                       //Đưa món ăn vào đỉnh stack

            //Nhập stack từ bàn phím
            st.NhapStack();

            //Xuất stack
            st.XuatStack();
            //---------------------
            //Bước 6: pop lấy 1 phần tử đầu và xóa
            Console.WriteLine("Mon an bi xoa o dau dinh stack là: ");
            st.Pop().XuatMonAn();                  //Lấy 1 món ăn từ đỉnh stack và xóa nó khỏi stack
            //xuất món ăn sau khi xóa stack
            Console.WriteLine("---Stack sau khi xoa 1 mon an o dinh stack---");
            st.XuatStack();
            //Bước 7: gọi hàm Peak để xem món ăn ở đỉnh stack nhưng không xóa nó khỏi stack
            Console.WriteLine("Mon an o dinh stack la: ");
            st.Peak().XuatMonAn();                 //Xem món ăn ở đỉnh stack nhưng không xóa nó khỏi stack
            //Bước 8: Push thêm món ăn
            MonAn monAn4 = new MonAn();
            Console.WriteLine("Nhap thong tin monan4: ");
            monAn4.NhapMonAn();                    //Nhập thông tin món ăn từ bàn phím
            //thêm Monan4 vào stack
            st.Push(monAn4);                       //Đưa món ăn vào đỉnh stack
            Console.WriteLine("\n---Stack sau khi Them monan4 o dinh: ---");
            st.XuatStack();                        //Xuất stack
            //Pop(xuất và xóa) tất cả các món ăn trong stack
            Console.WriteLine("\n---Pop tất cả các món ăn trong stack---");
            while (!st.IsEmpty())                  //Trong khi stack không rỗng
            {
                st.Pop().XuatMonAn();              //Lấy 1 món ăn từ đỉnh stack và xóa nó khỏi stack
            }
        }
    }
}
