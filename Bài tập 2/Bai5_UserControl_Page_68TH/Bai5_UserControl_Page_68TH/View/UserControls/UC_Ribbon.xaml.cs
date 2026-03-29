using Bai5_UserControl_Page_68TH.View.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Bai5_UserControl_Page_68TH.View.UserControls
{
    /// <summary>
    /// Interaction logic for UC_Ribbon.xaml
    /// </summary>
    // khai báo biến MainFrame để truyền vào khi khởi tạo UC_Ribbon
    public partial class UC_Ribbon : UserControl
    {
        // khai báo biến MainFrame để truyền vào khi khởi tạo UC_Ribbon
        private Frame _mainframe;
        public UC_Ribbon(Frame mainframe)
        {
            InitializeComponent();
            _mainframe=mainframe;
        }

        private void rbt_2dplan_Click(object sender, RoutedEventArgs e)
        {
           _mainframe.Content = new Plan2DPage();
        }
        private void rbt_cotthep_Click(object sender, RoutedEventArgs e)
        {
            Steel Steel = new Steel();
            Steel.Show();
        }
        private void rbt_betong_Click(object sender, RoutedEventArgs e)
        {
            Betong Betong = new Betong();
            Betong.Show();
        }
    }
}
