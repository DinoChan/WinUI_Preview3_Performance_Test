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
using System.Windows.Threading;

namespace WpfCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
            Root.Loaded += OnLoaded;
        }



        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var rows = 10;
            var columns = 10;
            for (int i = 0; i < rows; i++)
            {
                Root.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < columns; i++)
            {
                Root.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    var walkingCat = new WalkingCat();
                    Root.Children.Add(walkingCat);
                    Grid.SetRow(walkingCat, row);
                    Grid.SetColumn(walkingCat, column);
                }
            }
        }
    }
}
