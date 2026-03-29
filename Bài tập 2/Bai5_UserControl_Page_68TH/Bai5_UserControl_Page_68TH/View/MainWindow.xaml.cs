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
using Bai5_UserControl_Page_68TH.View.UserControls;
namespace Bai5_UserControl_Page_68TH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Load the HomePage when the application starts
            MainFrame.Content = new HomePage();
            // laod UC_Ribbon when the application starts
            UC_Ribbon ucRibbon = new UC_Ribbon(MainFrame);
            // gán lại uc ribbon
            Panel0.Children.Add(ucRibbon);
            // gán lại uc status bar
            UC_StatusBar ucStatusBar = new UC_StatusBar();
        }
    }
}
