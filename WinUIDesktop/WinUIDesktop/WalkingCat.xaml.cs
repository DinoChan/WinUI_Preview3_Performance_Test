
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
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
    public sealed partial class WalkingCat : UserControl
    {
        public WalkingCat()
        {
            this.InitializeComponent();
        }

        private void OnCatLoaded(object sender, RoutedEventArgs e)
        {
            var transform = (sender as Image).RenderTransform as CompositeTransform;
            var storyboard = new Storyboard
            {
                FillBehavior = FillBehavior.Stop,
                RepeatBehavior = RepeatBehavior.Forever
            };

            var keyFrames = new DoubleAnimationUsingKeyFrames();
            Storyboard.SetTarget(keyFrames, transform);
            Storyboard.SetTargetProperty(keyFrames, nameof(CompositeTransform.TranslateY));
            for (var i = 0; i < 12; i++)
            {
                var keyFrame = new DiscreteDoubleKeyFrame
                {
                    KeyTime = TimeSpan.FromSeconds((i + 1d) / 12d),
                    Value = -(i + 1) * 2391d / 12d
                };
                keyFrames.KeyFrames.Add(keyFrame);
            }
            storyboard.Children.Add(keyFrames);
            storyboard.Begin();
        }
    }
}
