using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                if (openFileDialog.ShowDialog() == true)
                {
                    string text = File.ReadAllText(openFileDialog.FileName);
                    board.FromString(text);
                    board.Draw(canvasBoard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Soubor nebyl otevřen z důvodu chyby: \r\n{ex.Message}");
            }
        }




        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("data.csv", board.ToString());
            Console.BackgroundColor = ConsoleColor.Red;
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            board.Clear();
            board.Draw(canvasBoard);
        }
    }
}