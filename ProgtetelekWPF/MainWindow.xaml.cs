using System;
using System.Collections;
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

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private List<int> sumItemSource;
        public MainWindow()
        {
            InitializeComponent();
            sumItemSource = new List<int>();
            LB_SUM.ItemsSource = sumItemSource;
        }

        private void PrintError(string message, string header = "Hiba!")
        {
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private int Összegzés(IEnumerable<int> collection)
        {
            int output = 0;
            foreach (var item in collection)
            {
                output += item;
            }
            return output;
        }

        private void LBL_SUM_Result_Refresh()
        {
            LBL_SUM_Result.Content = Összegzés(sumItemSource);
        }
        
        private void TB_SUM_KeyDown(object sender, KeyEventArgs e)
        {
            string input = TB_SUM.Text;
            if (e.Key == Key.Enter && input != "")
            {
                try
                {
                    int num = int.Parse(input);

                    sumItemSource.Add(num);
                    LB_SUM.Items.Refresh();

                    TB_SUM.Clear();
                    LBL_SUM_Result_Refresh();
                }
                catch (ArgumentNullException)
                {
                    PrintError("Nem adott meg semmit!");
                }
                catch (FormatException)
                {
                    PrintError("Nem számot adott meg!");
                }
                catch (OverflowException)
                {
                    PrintError($"Túl nagy számot adott meg. Maximális érték: {int.MaxValue}");
                }
                catch (Exception exception)
                {
                    PrintError($"Ismeretlen hiba!\n{exception.Message}");
                }
            }
        }
    }
}
