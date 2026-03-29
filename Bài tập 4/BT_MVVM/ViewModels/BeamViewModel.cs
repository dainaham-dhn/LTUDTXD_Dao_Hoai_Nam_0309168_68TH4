using BT_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BT_MVVM.ViewModels
{
    public class BeamViewModel : INotifyPropertyChanged
    {
        //1. Triển khai INotifyPropertyChanged để thông báo khi có sự thay đổi dữ liệu
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //2. Khai báo danh sách dầm để binding với view
        public ObservableCollection<Beam> Beams { get; set; } = new ObservableCollection<Beam>();
        //3. Khai báo các properties của dầm để binding với view
        #region khai báo fields
        private string _id;
        private string _mark;
        private string _story;
        private string _length;
        private string _volume;
        #endregion

        #region khai báo properties
        public string Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }
        public string Mark
        {
            get => _mark;
            set { _mark = value; OnPropertyChanged(); }
        }

        public string Story
        {
            get => _story;
            set { _story = value; OnPropertyChanged(); }
        }
        public string Length
        {
            get => _length;
            set { _length = value; OnPropertyChanged(); }
        }
        public string Volume
        {
            get => _volume;
            set { _volume = value; OnPropertyChanged(); }
        }
        #endregion

        //4. Khai báo các command để xử lý sự kiện từ view (nếu cần)
        public ICommand AddBeamCommand { get; }

        //5. Khai báo hàm khởi tạo
        public BeamViewModel()
        {
            //7.Khởi tạo command trong constructor (hàm khởi tạo)
            AddBeamCommand = new RelayCommand(AddBeam);
        }
        //6. khai báo hàm xử lý sự kiện (hàm thêm dầm)
        private void AddBeam()
        {
            //tạo một đối tượng dầm mới và thêm vào danh sách Beams
            Beam Dam = new Beam
            {
                Id = (Beams.Count + 1).ToString(),
                Mark = $"D{Beams.Count + 1}",
                Story = "Tầng 1",
                Volume = 0.5,
                Length = 3.0
            };
            //thêm Dam vào danh sách dầm "Beams"
            Beams.Add(Dam);
        }
    }
}
