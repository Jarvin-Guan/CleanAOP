using CleanAOP;
using CleanAOP.Intercepts;
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

namespace Test.WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = InterceptClassFactory.GetInterceptClass<MainWindowVM>("1","2");

            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainWindowVM).Name = "Jarvin Changed";
            (this.DataContext as MainWindowVM).DoWord();
        }
    }
}
