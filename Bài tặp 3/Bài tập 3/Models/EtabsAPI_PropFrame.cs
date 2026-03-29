using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_tập_3.Models
{
    // 1. Class lưu trữ thông tin tiết diện từ ETABS
    public class EtabsAPI_PropFrame
    {
        public int NumberNames { get; set; }
        public string MyName { get; set; }
        public string PropType { get; set; }

        // Kích thước tiết diện (Ví dụ dầm chữ nhật)
        public double t3 { get; set; } // Chiều cao (h)
        public double t2 { get; set; } // Chiều rộng (b)
        public double tf { get; set; }
        public double tw { get; set; }
        public double t2b { get; set; }
        public double tfb { get; set; }

        public EtabsAPI_PropFrame(string sectionName)
        {
            MyName = sectionName;
        }

        public void GetSectionDimension()
        {
            // Logic gọi API ETABS để gán giá trị cho t3, t2...
            t3 = 0.5; // 500mm
            t2 = 0.22; // 220mm
        }
    }
}
