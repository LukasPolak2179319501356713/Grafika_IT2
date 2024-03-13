using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Grafika_IT2
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
      var text = File.ReadAllText("data.csv");
      board.FromString(text);
      board.Draw(canvasBoard);
    }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "";
                save.FilterIndex = 0;
                save.RestoreDirectory = true;

                if (save.ShowDialog() == true)
                {
                    string path=save.FileName;
                    File.WriteAllText(path,board.ToString());
                    MessageBox.Show("Soubor uložen");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Soubor nebyl uložen z důvodu chyby: \r\n" + ex.Message);
            }
        }
    private void ButtonClear_Click(object sender, RoutedEventArgs e)
    {
      board.Clear();
      board.Draw(canvasBoard);
    }
  }
}
