using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH4
{
    internal class Program
    {
        //Định nghĩa cấu trúc MonAn
        public class MonAn{

            public int id;
            public string ten;
            public double giatien;

            //Hàm khởi tạo không tham số
            public MonAn(){
                id = 0;
                ten = "";
                giatien = 0;
            }

            //Hàm khởi tạo có tham số
            public MonAn(int Id, string Ten, double Giatien){
                id = Id;
                ten = Ten;
                giatien = Giatien;
            }


            public void NhapMonAn(){

                Console.Write("Nhap id: ");
                id = int.Parse(Console.ReadLine());

                Console.Write("Nhap ten: ");
                ten = Console.ReadLine();

                Console.Write("Nhap gia tien: ");
                giatien =double.Parse(Console.ReadLine());

            }

            public void XuatMonAn(){

                Console.WriteLine("Id: {0}, Ten: {1}, Gia tien: {2}", id, ten, giatien);
            }
        }

        //Định nghĩa cấu trúc Node
        public class Node {

            public MonAn data;
            public Node pNext;

            //Hàm khởi tạo không tham số
            public Node(MonAn x)
            {
                data = x;
                pNext = null;
            }
        }


        //Định nghĩa Danh sách liên kết ngăn xếp (STACK)
        public class StackMonAn {

            //khai báo biến
            private Node pHead;  //Đỉnh Stack

            //========================================//

            //Hàm khởi tạo không tham số
            public StackMonAn() {
                pHead = null;
            }

            //Hàm kiểm tra Stack rỗng
            public bool IsEmpty() {
                return pHead == null;
            }

            //Ham add MonAn vào Stack - thêm 1 MonAn vào đầu danh sách liên kết
            public void Push(MonAn x) {

                //Tạo 1 Node với tham số là MonAn x
                Node p = new Node(x);

                //thêm node vào stack
                p.pNext = pHead;    //nối node p vào đầu danh sách liên kết
                pHead = p;  // node p trở thành đỉnh mới
            }

            public void XuatStack() {

                Console.WriteLine("Stack (top -> bottom): ");

                Node p = pHead; // duyệt stack từ đỉnh đến đáy
                while (p != null) {
                    p.data.XuatMonAn();
                    p = p.pNext;
                }
            }

            // Pop - lấy 1 MonAn ra khỏi đỉnh stack
            public MonAn Pop()
            {
                if (IsEmpty())
                {
                    return null;  // Stack rỗng, không thể pop
                }

                //stack không rỗng, lấy MonAn từ đỉnh stack
                Node p = pHead;  // lưu node đỉnh stack
                MonAn value = p.data;  // lấy giá trị MonAn từ node đỉnh stack

                pHead = pHead.pNext;  // cập nhật đỉnh stack thành node tiếp theo
                return value;  // trả về giá trị MonAn đã pop
            }

            // Peek - lấy MonAn ở đỉnh stack mà không xóa nó
            public MonAn Peek() { 
                return IsEmpty() ? null : pHead.data;  // trả về MonAn ở đỉnh stack mà không xóa nó
            }

            // hàm nhập stack từ bàn phím
            public void NhapStack() {
                String kiemtra = "";
                MonAn mon;
                do
                {
                    mon = new MonAn();
                    mon.NhapMonAn ();

                    Push(mon);

                    Console.WriteLine("Ban muon tiep tuc nhap mon an khong (y/n): ");
                    kiemtra = Console.ReadLine();
                } while (kiemtra == "y");
            }
        }
        static void Main(string[] args)
        {
            //tạo biến đối tượng thuộc lớp stackMonAn
            StackMonAn st = new StackMonAn();
           
            //MonAn monAn1 = new MonAn(1, "Pho", 30000);
            //st.Push(monAn1);
            //MonAn monAn2 = new MonAn(2, "Bun", 25000);
            //st.Push(monAn2);
            //MonAn monAn3 = new MonAn(3, "Com", 20000);
            //st.Push(monAn3);
            //st.XuatStack();

            //Nhap stack mon an
            st.NhapStack();

            Console.WriteLine();

            // Pop (lấy) 1 món ăn ra khỏi đỉnh stack
            Console.WriteLine("---Mon an bi xoa o dau dinh stack la: ---");
            st.Pop().XuatMonAn();

            Console.WriteLine("\n---Danh sach mon an con lai trong stack: ---");
            st.XuatStack();

            //xuất thông tin dinh stack
            Console.WriteLine("\n---Mon an o dinh stack la: ---");
            st.Peek().XuatMonAn();

        }
    }
}
