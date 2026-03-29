
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BT_GITHUP.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private double _taiTrongP;
        public double TaiTrongP
        {
            get => _taiTrongP;
            set { _taiTrongP = value; OnPropertyChanged(); }
        }

        private double _cuongDoR;
        public double CuongDoR
        {
            get => _cuongDoR;
            set { _cuongDoR = value; OnPropertyChanged(); }
        }
        private double _ketQuaArea;
        public double KetQuaArea
        {
            get => _ketQuaArea;
            set { _ketQuaArea = value; OnPropertyChanged(); }
        }
        public ICommand TinhMongCommand { get; }

        public MainViewModel()
        {
            TinhMongCommand = new RelayCommand(ThucHienTinhToan);
        }

        private void ThucHienTinhToan()
        {
            if (CuongDoR > 0)
            {
                KetQuaArea = TaiTrongP / CuongDoR;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    // Command dùng ICommand
    public class RelayCommand : ICommand
    {
        private Action _execute;
        public RelayCommand(Action execute) => _execute = execute;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _execute();
        public event EventHandler CanExecuteChanged;
    }
}
