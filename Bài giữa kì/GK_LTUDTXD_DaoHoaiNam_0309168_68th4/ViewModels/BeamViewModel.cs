using GK_LTUDTXD_DaoHoaiNam_0309168_68th4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace GK_LTUDTXD_DaoHoaiNam_0309168_68th4.ViewModels
{
    public class BeamViewModel : INotifyPropertyChanged
    {
        //Bước 1
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //Bước 2. khai báo các biến để binding với view
        //1. khai danh sách dầm BeamList
        public ObservableCollection<BeamModel> BeamList { get; set; } = new ObservableCollection<BeamModel>();
        //2. khai báo dầm hiện tại CurrentBeam
        public BeamModel CurrentBeam { get; set; } = new BeamModel();
        //3. khai báo các danh sách vật liệu để binding với combobox trong view
        public ObservableCollection<ConcreteMaterialModel> ConcreteMaterialList { get; set; } = new ObservableCollection<ConcreteMaterialModel>();
        public ObservableCollection<RebarMaterialModel> RebarMaterialList { get; set; } = new ObservableCollection<RebarMaterialModel>();
        //Bước 3. Khai báo các thành phần (fields, properties, methods) để xử lý logic cho view

        #region Khai báo fields 
        private int _id;
        private double _b;
        private double _h;
        private double _a;
        private double _h0;
        private double _m;
        private ConcreteMaterialModel _concreteMaterial;
        private RebarMaterialModel _rebarMaterial;
        private double _alphaM;
        private double _alphaR;
        private double _xi;
        private double _xiR;
        private double _as;
        private double _mu;
        private string _baitoan;
        #endregion
        #region Khai báo properties
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }
        private string _mark;
        public string Mark
        {
            get => _mark;
            set { _mark = value; OnPropertyChanged(); }
        }
        public double b
        {
            get => _b;
            set { _b = value; OnPropertyChanged(); }
        }
        public double h
        {
            get => _h;
            set { _h = value; OnPropertyChanged(); }
        }
        public double a
        {
            get => _a;
            set { _a = value; OnPropertyChanged(); }
        }
        public double h0
        {
            get => _h0;
            set { _h0 = value; OnPropertyChanged(); }
        }
        public double Xi
        {
            get => _xi;
            set { _xi = value; OnPropertyChanged(); }
        }
        public double XiR
        {
            get => _xiR;
            set { _xiR = value; OnPropertyChanged(); }
        }
        public double M
        {
            get => _m;
            set { _m = value; OnPropertyChanged(); }
        }
        public ConcreteMaterialModel ConcreteMaterial
        {
            get => _concreteMaterial;
            set { _concreteMaterial = value; OnPropertyChanged(); }
        }
        public RebarMaterialModel RebarMaterial
        {
            get => _rebarMaterial;
            set { _rebarMaterial = value; OnPropertyChanged(); }
        }
        public double AlphaM
        {
            get => _alphaM;
            set { _alphaM = value; OnPropertyChanged(); }
        }
        public double AlphaR
        {
            get => _alphaR;
            set { _alphaR = value; OnPropertyChanged(); }
        }
        public double As
        {
            get => _as;
            set { _as = value; OnPropertyChanged(); }
        }
        public double Mu
        {
            get => _mu;
            set { _mu = value; OnPropertyChanged(); }
        }
        public string BaiToan
        {
            get => _baitoan;
            set { _baitoan = value; OnPropertyChanged(); }
        }
        #endregion

        //Khai báo Command
        public ICommand AddBeamCommand { get; }
        public ICommand CalBeamCommand { get; }
        public ICommand DeleteBeamCommand { get; }

        //constructor-hàm khởi tạo
        public BeamViewModel()
        {
            //Khởi tạo danh sách vật liệu bê tông
            ConcreteMaterialList.Add(new ConcreteMaterialModel { Name = "B20", Rb = 10, Rbt = 0.8, Eb = 3000 });
            ConcreteMaterialList.Add(new ConcreteMaterialModel { Name = "B25", Rb = 12.5, Rbt = 0.9, Eb = 3500 });
            ConcreteMaterialList.Add(new ConcreteMaterialModel { Name = "B30", Rb = 13, Rbt = 0.95, Eb = 3500 });
            //khởi tạo danh sách vật liệu cốt thép
            RebarMaterialList.Add(new RebarMaterialModel { Name = "CB300-V", Rs = 300, Rsc = 270 });
            RebarMaterialList.Add(new RebarMaterialModel { Name = "CB400", Rs = 320, Rsc = 280 });
            //Khởi tạo Command
            AddBeamCommand = new RelayCommand(AddBeamMethod);
            CalBeamCommand = new RelayCommand(CalBeamMethod);
            DeleteBeamCommand = new RelayCommand(DeleteBeamMethod);
        }

        #region khai báo các  phương thức thực thi command
        private void AddBeamMethod()
        {
            // Khởi tạo một đối tượng mới 
            BeamModel _newbeam = new BeamModel();

            // Gán các giá trị từ giao diện (VM) cho các thuộc tính dầm cột 
            _newbeam.Mark = Mark;
            _newbeam.b = b;
            _newbeam.h = h;
            _newbeam.a = a;
            _newbeam.M = M;
            _newbeam.ConcreteMaterial = ConcreteMaterial;
            _newbeam.RebarMaterial = RebarMaterial;
            _newbeam.Id = BeamList.Count + 1;
            _newbeam.h0 = _newbeam.h - _newbeam.a;
            _newbeam.AlphaR = 0.371;
            _newbeam.XiR = 0.493;

            // Kiểm tra xem mã hiệu dầm đã tồn tại trong danh sách chưa
            // Hàm Any() sẽ duyệt qua BeamList xem có dầm nào (b) có Mark giống vơi Mark của _newbeam hay không
            // Cú pháp: (Ten_Danh_Sach.Any(b => b.Thuoc_Tinh_So_Sanh == Gia_Tri_So_Sanh)) 
            // b là một tên biến tạm dùng để đại diện cho từng đối tượng dầm (BeamModel) nằm bên trong danh sách BeamList khi hàm Any duyệt qua.
            if (BeamList.Any(b => b.Mark == _newbeam.Mark))
            {
                //hiển thị thông báo lỗi nếu mã hiệu trùng
                System.Windows.MessageBox.Show("Mã hiệu dầm đã tồn tại. Vui lòng nhập mã hiệu khác.", "Lỗi", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }
            else
            {
                //thêm dầm hiện tại vào danh sách dầm BeamList
                BeamList.Add(_newbeam);
            }
        }
        private void DeleteBeamMethod()
        {
            //dầm đang chọn select trong datagrid là CurrentBeam, nên ta sẽ xóa CurrentBeam khỏi BeamList
            // Cú pháp: (Doi_Tuong != null && Ten_Danh_Sach.Contains(Doi_Tuong))
            // "CurrentBeam != null": Đảm bảo người dùng đã bấm chọn một dầm trên giao diện (nếu chưa chọn gì thì CurrentBeam sẽ bị rỗng hay null).
            // "BeamList.Contains(CurrentBeam)": Kiểm tra xem đối tượng dầm đang được chọn (CurrentBeam) có thực sự tồn tại trong danh sách BeamList hay không.
            if (CurrentBeam != null && BeamList.Contains(CurrentBeam))
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa dầm {CurrentBeam.Mark}?",
                    "Xác nhận",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    BeamList.Remove(CurrentBeam);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn dầm cần xóa trong danh sách.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CalBeamMethod()
        {
            if (BeamList.Count > 0)
            {
                foreach (var beam in BeamList)
                {
                    //gọi hàm tính toán As dầm
                    TinhToanAs(beam);
                }
            }
        }

        private void TinhToanAs(BeamModel beam)
        {
            if (beam.ConcreteMaterial == null || beam.RebarMaterial == null) return;

            // --- BƯỚC 1: CHUẨN BỊ THÔNG SỐ ---
            double Rb = beam.ConcreteMaterial.Rb;
            double Rs = beam.RebarMaterial.Rs;
            double Rsc = beam.RebarMaterial.Rsc; // Thép nén
            double b = beam.b;
            double h0 = beam.h0;
            double aPrime = beam.a; // Giả thiết a' = a

            // Đổi đơn vị Momen sang N.mm
            double M = beam.M * 1e6;

            // --- BƯỚC 2: TÍNH TOÁN HỆ SỐ ALPHA_M ---
            beam.AlphaM = M / (Rb * b * Math.Pow(h0, 2)); // [cite: 23]

            // --- BƯỚC 3: BIỆN LUẬN THUẬT TOÁN [cite: 27, 28, 29] ---
            if (beam.AlphaM <= beam.AlphaR)
            {
                // 1. Bài toán cốt đơn [cite: 39, 41]
                beam.BaiToan = "Cốt đơn";
                double zeta = 0.5 * (1 + Math.Sqrt(1 - 2 * beam.AlphaM)); // [cite: 28]
                beam.As = M / (Rs * zeta * h0); // [cite: 28]
            }
            else
            {
                // 2. Bài toán cốt kép [cite: 33, 36]
                beam.BaiToan = "Cốt kép";

                // Tính diện tích cốt nén As' [cite: 29]
                double AsPrime = (M - beam.AlphaR * Rb * b * Math.Pow(h0, 2)) / (Rsc * (h0 - aPrime));

                // Tính diện tích cốt kéo As [cite: 29]
                beam.As = (beam.XiR * Rb * b * h0) / Rs + (Rsc / Rs) * AsPrime;
            }

            // --- BƯỚC 4: TÍNH HÀM LƯỢNG THÉP (%) ---
            beam.Mu = (beam.As / (b * h0)) * 100; // [cite: 28, 29]
        }
        #endregion
    }
}
