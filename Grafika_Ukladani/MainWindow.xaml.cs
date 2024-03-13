using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Grafika_Ukladani
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board board;

        public MainWindow()
        {
            InitializeComponent();
            board = new Board();
        }

        private void canvasBoard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            board.Add(e.GetPosition(canvasBoard));
            board.Draw(canvasBoard);
        }
    }
}