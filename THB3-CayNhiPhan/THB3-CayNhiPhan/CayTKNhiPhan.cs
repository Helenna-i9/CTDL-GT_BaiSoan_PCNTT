using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THB3_CayNhiPhan
{
    internal class CayTKNhiPhan
    {
        public Node root;
        public CayTKNhiPhan()
        {
            root = null;
        }
        //==================================================
        //Hàm thêm node
        public Node Insert(int dt)
        {
            Node newNode = new Node(dt);
            if (root == null) // Nếu cây rỗng thì node mới trở thành gốc (root)
            {
                root = newNode;
                return root;
            }
            Node nodeHienTai = root; //dùng để duyệt cây, bắt đầu từ gốc
            Node nodeCha = null; //giữ node cha của nodeHientai, để thêm node vào cây 
            while (nodeHienTai != null) //Vòng lập duyệt xuống cây để tìm kiếm vị trí thích hợp đến Node
            {
                nodeCha = nodeHienTai; //Lưu cha của hiện tại
                //nếu dt nhỏ hiện tại thì di chuyển nodeHientai về bên trái
                if (dt < nodeHienTai.data)
                    nodeHienTai = nodeHienTai.left;
                else //Di chuyển nodeHientai về bên phải
                    nodeHienTai = nodeHienTai.right;
            }
            //Khi nodeHientai trở thành null, nghĩa là đã đi xuống vị trí lá (khoảng trống)
            //và nodeCha là node sẽ gắn node mới làm con trái hoặc phải của nó
            //so sánh lại dt với nodeCha.data để quyết định gắn newNode vào con trái hay con phải của parent.
            if (dt < nodeCha.data)
                nodeCha.left = newNode;
            else
                nodeCha.right = newNode;

            return root;
        }//Đóng hàm insert
        //----------------------------------------------------
        public void NLR(Node nodeRoot)
        {
            if (nodeRoot != null)
            {
                nodeRoot.HienThiNode(); //xuất hiện thông tin node
                Console.Write("-->");
                NLR(nodeRoot.left); //duyệt tiền tự bên trái 
                NLR(nodeRoot.right); // duyệt tiền tự bên phải

            }
        }
        //Duyệt cây theo thứ tự giữa (trung tự - Left Node right)========================
        public void LNR(Node nodeRoot)
        {
            if (nodeRoot != null)
            {
                LNR(nodeRoot.left);            //Duyệt tiền tự con trái
                nodeRoot.HienThiNode();        //Xuất thông tin node
                Console.Write("->");
                LNR(nodeRoot.right);         //Duyệt tiền tự con phải
            }
        }
        //Duyệt cây theo thứ tự sau (hậu tự - Left right Node)========================
        public void LRN(Node nodeRoot)
        {
            if (nodeRoot != null)
            {
                LNR(nodeRoot.left);            //Duyệt tiền tự con trái
                LNR(nodeRoot.right);         //Duyệt tiền tự con phải
                nodeRoot.HienThiNode();        //Xuất thông tin node
                Console.Write("->");
            }
        }
        //======================================
        //tìm kiếm giá trị X trong cây
        public Node TimX(int x)
        {
            Node nodeHienTai = root; //gắn node gôcs vào nodeHientai
            while (nodeHienTai.data != x) // trong khi chưa tìm thấy
            {
                if (x < nodeHienTai.data)
                    nodeHienTai = nodeHienTai.left; // gắn node bên trái vào nodeHienTai
                else
                    nodeHienTai = nodeHienTai.right;
                if (nodeHienTai == null) //duyệt đến cuối cây, không tìm thấy
                    return null;
            }
            return nodeHienTai; // tìm thấy 
        }
        //=====================================================
        //Hàm tìm giá trij nhỏ nhất trong cây
        public int TimGiaTriNhoNhat()
        {
            Node nodeHienTai = root;
            while (!(nodeHienTai.left == null))
                nodeHienTai = nodeHienTai.left;
            return nodeHienTai.data;
        }
        //Hàm tìm giá trị nhỏ nhất tẻong cây con (đi hết bên trái)
        public Node FinMin(Node node)
        {
            if (node == null) return null; // de tranh loi null

            while (node.left != null)
                node = node.left;
            return node;
        }
        //xóa một phần tử có giá trij x
        public Node DelNode(Node T, int x)
        {
            if (T == null)
                return null;
            //1. tìm vị trí cần xóa 
            if (x < T.data)
                T.left = DelNode(T.left, x);
            else if (x > T.data)
                T.right = DelNode(T.right, x);
            else //T.data == x(xoa T)        
            {
                //1 hoac 0 co
                if (T.left == null)
                    return T.right;
                if (T.right == null)
                    return T.left;
                //2 con: tim successor o cay con phai
                Node succ = FinMin(T.right);
                T.data = succ.data;
                //xoa successor trong cây con phải (gán lại T.Right)
                T.right = DelNode(T.right, succ.data);

            }
            return T;
        }
    }
}
    
