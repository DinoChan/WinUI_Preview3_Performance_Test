﻿using System;
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

namespace WpfFX
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
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
            timer.Tick += (s, args) =>
            {
                Root.DataContext = DateTime.Now.ToString("mm fff");
            };
            timer.Start();


        }
    }
}