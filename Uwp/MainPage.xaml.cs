using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Uwp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var rows = 20;
            var columns = 20;
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
