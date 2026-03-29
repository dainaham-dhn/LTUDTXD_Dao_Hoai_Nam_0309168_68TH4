using BT_MVVM.Views.Pages;
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

namespace BT_MVVM.Views.UserControls
{
    /// <summary>
    /// Interaction logic for UC_Ribbon.xaml
    /// </summary>
    public partial class UC_Ribbon : UserControl
    {
        //khai báo biến 
        private Frame Mainframe;
        public UC_Ribbon(Frame mainFrame)
        {
            InitializeComponent();
            this.Mainframe = mainFrame;
        }

        private void rbt_2Dplan_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Content = new Plan2DPage();
        }

        private void rbt_Beams_Click(object sender, RoutedEventArgs e)
        {
            BeamView BeamView = new BeamView();
            BeamView.Show();
        }

        private void rbt_Frames_Click(object sender, RoutedEventArgs e)
        {
            EtabsAPI_FramesView EtabsFramesView = new EtabsAPI_FramesView();
            EtabsFramesView.Show();
        }
    }
}
