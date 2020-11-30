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
            var rows = 60;
            var columns = 40;
            for (int i = 0; i < rows; i++)
            {
                Root.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < columns; i++)
            {
                Root.ColumnDefinitions.Add(new ColumnDefinition());
            }

            var source = string.Empty;

            var binding = new Binding();
            binding.Mode = BindingMode.OneWay;


            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    var textBlock = new TextBlock();
                    textBlock.SetBinding(TextBlock.TextProperty, binding);
                    textBlock.Opacity = .5;
                    textBlock.FontSize = 12;
                    Root.Children.Add(textBlock);
                    Grid.SetRow(textBlock, row);
                    Grid.SetColumn(textBlock, column);
                }
            }

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += (s, args) => Root.DataContext = DateTime.Now.ToString("mm fff");
            timer.Start();
        }
    }
}
