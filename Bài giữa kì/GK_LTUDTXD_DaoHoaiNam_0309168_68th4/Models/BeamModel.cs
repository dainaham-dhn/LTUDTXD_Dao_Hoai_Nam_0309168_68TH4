using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace GK_LTUDTXD_DaoHoaiNam_0309168_68th4.Models
{
    public class BeamModel
    {
        public string Mark { get; set; }  ///Mã hiệu Dầm
        public int Id { get; set; }
        public double b { get; set; } // Chiều rộng của dầm
        public double h { get; set; }
        public double a { get; set; }
        public double h0 { get; set; }
        public double M { get; set; }
        public ConcreteMaterialModel ConcreteMaterial { get; set; } //Vật liệu của dầm  - quan hệ 1-1 (1 dầm chỉ có 1 vật liệu)
        public RebarMaterialModel RebarMaterial { get; set; }
        public double AlphaM { get; set; }
        public double AlphaR { get; set; }
        public double Xi { get; set; }
        public double XiR { get; set; }
        public double As { get; set; }
        public double Mu { get; set; }

        public string BaiToan { get; set; } //"Cốt đơn"/"Cốt kép"/"Không thỏa mãn".
        public string Note { get; set; } //Ghi chú thêm nếu cần
    }
}
