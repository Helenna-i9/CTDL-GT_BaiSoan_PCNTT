using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THB3_CayNhiPhan
{
    //B3: TRƯƠNG TRÌNH=========================
    
    internal class Program
    {
        static void Main(string[] args)
        {
            CayTKNhiPhan cay = new CayTKNhiPhan();
            cay.Insert(5);
            cay.Insert(3);
            cay.Insert(7);
            cay.Insert(2);
            cay.Insert(4);

            //Xem thêm cây chạy từng bước
            //đặt BreakPoint -> Start(F5) -> Debug/Window/Autos -> F10

            Console.WriteLine("Duyet NLR (tien tu): ");
            cay.NLR(cay.root); // duyet tu node goc

            Console.WriteLine("Duyet LNR (trung tu): ");
            cay.LNR(cay.root); 

            Console.WriteLine("Duyet LRN (hau tu): ");
            cay.LRN(cay.root);


            Console.Write("Nhap gia tri muon tim: ");
            int x = int.Parse(Console.ReadLine());

            if (cay.TimX(x) == null)
                Console.WriteLine("Khong tim thay (0) trong cay!", x);
            else
                Console.WriteLine("Tim thay (0) trong cay!", cay.TimX(x).data);

            Console.WriteLine("\n Gia tri min la: "+ cay.TimGiaTriNhoNhat());
            //Console.WriteLine("\n Gia tri max la: " + cay.TimGiaTriLonNhat());


            //Console.WriteLine("Tong so node trong cay la: "+ cay.CountNodes(cay.root));
            //Console.WriteLine("So node La trong cay la: "+ cay.CountLeaf(cay.root));


            //gọi hàm xóa giá trị 3
            //Chú ý: Phải gán lại cay.root = cay.DelNode(...)
            //vì sau khi xóa cây con có thể thay đổi gốc 
            cay.root = cay.DelNode(cay.root, 3);

            Console.WriteLine("Duyet NLR (tien tu) sau khi xoa:");
            cay.NLR(cay.root);
        }
    }
}
