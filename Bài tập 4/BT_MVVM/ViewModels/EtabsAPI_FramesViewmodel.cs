using BT_MVVM.Models;
using ETABSv1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BT_MVVM.ViewModels
{
    public class EtabsAPI_FramesViewmodel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //khai báo danh sách phần tử thanh (Frames) để binding với view
        public ObservableCollection<EtabsAPI_Frame> EtabsFrames { get; set; } = new ObservableCollection<EtabsAPI_Frame>();

        #region fields 
        private int _numberNames;
        private string _label;
        private string _myName;
        private string _propName;
        private string _storyName;
        private string _pointName1;
        private string _pointName2;
        private double _point1X;
        private double _point1Y;
        private double _point1Z;
        private double _point2X;
        private double _point2Y;
        private double _point2Z;
        private double _angle;
        private double _offset1X;
        private double _offset2X;
        private double _offset1Y;
        private double _offset2Y;
        private double _offset1Z;
        private double _offset2Z;
        private int _cardinalPoint;
        private double _length;
        #endregion
        #region properties

        public int NumberNames
        {
            get
            {
                return _numberNames;
            }
            set
            {
                _numberNames = value; OnPropertyChanged();
            }
        }

        public string Label
        {
            get { return _label; }
            set { _label = value; OnPropertyChanged(); }

        }
        public string MyName
        {
            get { return _myName; }
            set { _myName = value; OnPropertyChanged(); }

        }

        public string StoryName
        {
            get { return _storyName; }
            set { _storyName = value; OnPropertyChanged(); }
        }

        public string PropName
        {
            get { return _propName; }
            set { _propName = value; OnPropertyChanged(); }
        }

        public string PointName1
        {
            get { return _pointName1; }
            set { _pointName1 = value; OnPropertyChanged(); }
        }

        public string PointName2
        {
            get { return _pointName2; }
            set { _pointName2 = value; OnPropertyChanged(); }
        }

        public double Point1X
        {
            get { return _point1X; }
            set { _point1X = value; OnPropertyChanged(); }
        }

        public double Point1Y
        {
            get { return _point1Y; }
            set { _point1Y = value; OnPropertyChanged(); }
        }

        public double Point1Z
        {
            get { return _point1Z; }
            set { _point1Z = value; OnPropertyChanged(); }
        }


        public double Point2X
        {
            get { return _point2X; }
            set { _point2X = value; OnPropertyChanged(); }
        }

        public double Point2Y
        {
            get { return _point2Y; }
            set { _point2Y = value; OnPropertyChanged(); }
        }

        public double Point2Z
        {
            get { return _point2Z; }
            set { _point2Z = value; OnPropertyChanged(); }
        }

        public double Angle
        {
            get { return _angle; }
            set { _angle = value; OnPropertyChanged(); }
        }


        public double Offset1X
        {
            get { return _offset1X; }
            set { _offset1X = value; OnPropertyChanged(); }
        }


        public double Offset2X
        {
            get { return _offset2X; }
            set { _offset2X = value; OnPropertyChanged(); }
        }

        public double Offset1Y
        {
            get { return _offset1Y; }
            set { _offset1Y = value; OnPropertyChanged(); }
        }

        public double Offset2Y
        {
            get { return _offset2Y; }
            set { _offset2Y = value; OnPropertyChanged(); }
        }

        public double Offset1Z
        {
            get { return _offset1Z; }
            set { _offset1Z = value; OnPropertyChanged(); }
        }


        public double Offset2Z
        {
            get { return _offset2Z; }
            set { _offset2Z = value; OnPropertyChanged(); }
        }

        public int CardinalPoint
        {
            get { return _cardinalPoint; }
            set { _cardinalPoint = value; OnPropertyChanged(); }
        }

        public double Length
        {
            get
            {

                return Math.Sqrt(Math.Pow((Point2X - Point1X), 2) + Math.Pow((Point2Y - Point1Y), 2) + Math.Pow((Point2Z - Point1Z), 2)); ;
            }
            set { _length = value; OnPropertyChanged(); }
        }

        //khai báo command

        //hàm khởi tạo của EtabsAPI_FramesViewmodel
        public EtabsAPI_FramesViewmodel()
        {
            //gọi hàm lấy dữ liệu Frame từ Etabs API
            ETABSAPI_GetallFrame();
        }
        //Viết phương thức lấy dữ liệu từ Etabs API
        public void ETABSAPI_GetallFrame()
        {
            string trangthai = "";
            cSapModel SapModel;
            cOAPI EtabsObject;

            //danh sách biến của getallframe
            int ret = -1;
            int NumberNames = 0;
            string[] MyName = { };

            string[] PropName = { };

            string[] StoryName = { };

            string[] PointName1 = { };

            string[] PointName2 = { };

            double[] Point1X = { };

            double[] Point1Y = { };

            double[] Point1Z = { };

            double[] Point2X = { };

            double[] Point2Y = { };

            double[] Point2Z = { };

            double[] Angle = { };

            double[] Offset1X = { };

            double[] Offset2X = { };

            double[] Offset1Y = { };

            double[] Offset2Y = { };

            double[] Offset1Z = { };

            double[] Offset2Z = { };

            int[] CardinalPoint = { };

            string csys = "Global";

            //danh sách biến của GetLableNameList
            int NumberNames2 = 0;
            string[] MyName2 = { };
            string[] MyLabel2 = { };
            string[] MyStory2 = { };

            //Khởi tạo Etabs Object
            //EtabsObject = CreateObject("CSI.ETABS.API.ETABSObject");
            EtabsObject = null;

            // TƯơng tác với Etabs
            try
            {
                //Lấy Etabs Object đang hoạt động
                EtabsObject = (ETABSv1.cOAPI)System.Runtime.InteropServices.Marshal.GetActiveObject("CSI.ETABS.API.ETABSObject");
                //mô hinh Sapmodel
                SapModel = EtabsObject.SapModel;

                //Đặt đơn vị cho mô hình
                SapModel.SetPresentUnits(eUnits.kN_m_C);

                //GetAllFrames - lấy toàn bộ thông tin phần tử Thanh
                ret = SapModel.FrameObj.GetAllFrames(ref NumberNames, ref MyName, ref PropName, ref StoryName, ref PointName1, ref PointName2, ref Point1X, ref Point1Y, ref Point1Z, ref Point2X, ref Point2Y, ref Point2Z,
                                                     ref Angle, ref Offset1X, ref Offset2X, ref Offset1Y, ref Offset2Y, ref Offset1Z, ref Offset2Z, ref CardinalPoint);

                ret = SapModel.FrameObj.GetLabelNameList(ref NumberNames2, ref MyName2, ref MyLabel2, ref MyStory2);


                //Đưa thông tin  vừa đọc vào đối tượng Etabs_Frame
                for (int i = 0; i < (NumberNames - 1); i++)
                {
                    //1.lấy từng thông tin của đối tượng  Frame một trong Etabs API
                    //khởi tạo đối tượng _frame
                    EtabsAPI_Frame _frame = new EtabsAPI_Frame();
                    //gán giá trị thuộc tính vào trong đối tượng frame
                    _frame.MyName = MyName[i];
                    _frame.Label = MyLabel2[i];
                    _frame.PropName = PropName[i];
                    _frame.StoryName = StoryName[i];
                    _frame.PointName1 = PointName1[i];
                    _frame.PointName2 = PointName2[i];
                    _frame.Point1X = Point1X[i];
                    _frame.Point1Y = Point1Y[i];
                    _frame.Point1Z = Point1Z[i];
                    _frame.Point2X = Point2X[i];
                    _frame.Point2Y = Point2Y[i];
                    _frame.Point2Z = Point2Z[i];
                    _frame.Angle = Angle[i];
                    _frame.Offset1X = Offset1X[i];
                    _frame.Offset2X = Offset2X[i];
                    _frame.Offset1Y = Offset1Y[i];
                    _frame.Offset2Y = Offset2Y[i];
                    _frame.Offset1Z = Offset1Z[i];
                    _frame.Offset2Z = Offset2Z[i];
                    _frame.CardinalPoint = CardinalPoint[i];
                    EtabsFrames.Add(_frame);
                }





                trangthai = ("Lấy thông tin phần tử thanh thành công");
            }
            catch (Exception ex)
            {
                trangthai = ("Không tìm thấy chương trình Etabs nào đang hoạt động.");
                return;
            }
        }


        #endregion
    }
}
