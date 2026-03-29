using Bài_tập_3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauDuAn_CTThietKeDam.Models
{
    // 2. Class lưu trữ thông tin phần tử thanh từ ETABS
    public class EtabsAPI_Frame
    {
        public string MyName { get; set; }
        public string PropName { get; set; }
        public string PointName1 { get; set; }
        public string PointName2 { get; set; }
        public double Point1X { get; set; }
        public double Point1Y { get; set; }
        public double Point1Z { get; set; }
        public double Point2X { get; set; }
        public double Point2Y { get; set; }
        public double Point2Z { get; set; }

        public EtabsAPI_Frame(string label)
        {
            MyName = label;
        }

        public void GetCoordinates()
        {
            // Logic lấy tọa độ từ ETABS
        }

        public EtabsAPI_PropFrame GetSectionProperty()
        {
            // Khởi tạo và trả về tiết diện
            var prop = new EtabsAPI_PropFrame(PropName);
            prop.GetSectionDimension();
            return prop;
        }
    }
}
