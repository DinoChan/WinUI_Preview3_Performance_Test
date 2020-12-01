using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIDesktop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
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
