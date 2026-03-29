using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bai5_UserControl_Page_68TH.View.Pages
{
    /// <summary>
    /// Interaction logic for Steel.xaml
    /// </summary>
    public partial class Steel : Window
    {
        public Steel()
        {
            InitializeComponent();
            // Ví dụ: 4Ø16
            string rebar = $"{soLuong}Ø{duongKinh}"; 
        }

        public object soLuong { get; set; }
        public object duongKinh { get; set; }
    }
}
