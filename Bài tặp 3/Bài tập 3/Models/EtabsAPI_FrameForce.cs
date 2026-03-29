using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauDuAn_CTThietKeDam.Models
{
    // 3. Class lưu trữ nội lực
    public class EtabsAPI_FrameForce
    {
        public int NumberResults { get; set; }
        public string Obj { get; set; }
        public double ObjSta { get; set; }
        public string Elm { get; set; }
        public string LoadCase { get; set; }
        public double P { get; set; } // Lực dọc
        public double V2 { get; set; } // Lực cắt
        public double V3 { get; set; }
        public double T { get; set; } // Xoắn
        public double M2 { get; set; }
        public double M3 { get; set; } // Momen uốn

        public EtabsAPI_FrameForce(string name)
        {
            Obj = name;
        }

        public List<EtabsAPI_FrameForce> GetFrameForces()
        {
            // Logic lấy danh sách nội lực (các tổ hợp, các mặt cắt) từ ETABS
            return new List<EtabsAPI_FrameForce>();
        }
    }
}
