using Bài_tập_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauDuAn_CTThietKeDam.Models
{
    // 4. Class trung tâm (Model chính của cấu kiện Dầm)
    public class Beam
    {
        // Thuộc tính (Properties)
        public string ID { get; private set; }
        public string Mark { get; set; }
        public double Length { get; set; }
        public double Volume { get; set; }
        public string Material { get; set; }

        // Quan hệ Composition/Aggregation
        public EtabsAPI_Frame Frame { get; set; }
        public EtabsAPI_PropFrame SectionProperty { get; set; }
        public List<EtabsAPI_FrameForce> FrameForces { get; set; }

        // Biến lưu trữ kết quả tính toán thép
        public double As_Required { get; private set; }

        // Constructor
        public Beam(string mark, string id)
        {
            Mark = mark;
            ID = id;
            FrameForces = new List<EtabsAPI_FrameForce>();
        }

        // Phương thức kiểm tra Trạng thái giới hạn 1 (Khả năng chịu lực)
        public bool CheckULS()
        {
            // Lấy Moment lớn nhất từ danh sách nội lực để kiểm tra
            double maxM3 = 0;
            foreach (var force in FrameForces)
            {
                if (Math.Abs(force.M3) > maxM3)
                    maxM3 = Math.Abs(force.M3);
            }

            // Logic tính toán so sánh M_vu và M_max theo TCVN
            // Dummy logic: Giả sử giới hạn chịu uốn của tiết diện là 150 kNm
            double capacityM = 150.0;
            bool isSafe = maxM3 <= capacityM;

            Console.WriteLine($"[TTGH I - ULS] Kiểm tra khả năng chịu uốn Dầm {Mark}: {(isSafe ? "ĐẠT" : "KHÔNG ĐẠT")} (M_max = {maxM3} kNm)");
            return isSafe;
        }

        // Phương thức kiểm tra Trạng thái giới hạn 2 (Độ võng / Vết nứt)
        public bool CheckSLS()
        {
            // Lấy chiều dài nhịp tính toán độ võng cho phép (VD: L/250)
            double allowDeflection = Length / 250.0;

            // Dummy logic: Giả sử độ võng thực tế tính được là 12mm
            double actualDeflection = 12.0; // mm (sẽ được lấy từ ETABS hoặc tính tay)

            bool isSafe = actualDeflection <= (allowDeflection * 1000); // Đổi L ra mm

            Console.WriteLine($"[TTGH II - SLS] Kiểm tra độ võng Dầm {Mark}: {(isSafe ? "ĐẠT" : "KHÔNG ĐẠT")} (Võng thực tế = {actualDeflection}mm, Cho phép = {allowDeflection * 1000}mm)");
            return isSafe;
        }

        // Tính toán diện tích cốt thép
        public void CalculateReinforcement()
        {
            // Chèn thuật toán tính Dầm HCN (hình lưu đồ trước đó) vào đây
            // Giả lập kết quả:
            As_Required = 12.5; // cm2
            Console.WriteLine($"[Tính thép] Diện tích cốt thép yêu cầu cho dầm {Mark}: {As_Required} cm2");
        }
    }
}