using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THB3_CayNhiPhan
{
    //B1:ĐỊNH NGHĨA CẤU TRÚC MỘT NODE
    internal class Node
    {
        //B1.1:Khai báo các biến để lưu thông tin 1 node
        public int data;    //Lưu thông tin 
        public Node left;    // trỏ đến node bên trái
        public Node right;   //trỏ đến node bên phải

        //B1.2: Hàm khởi tạo có một tham số là số nguyên
        public Node(int dt)
        {
            data = dt;
            left = null;
            right = null;
        }
        //B1.3: Hàm hiển thị thông tin node
        public void HienThiNode()
        {
            Console.Write(data);
        }
    }
}
