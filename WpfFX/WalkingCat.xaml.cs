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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfFX
{
    /// <summary>
    /// WalkingCat.xaml 的交互逻辑
    /// </summary>
    public partial class WalkingCat : UserControl
    {
        public WalkingCat()
        {
            InitializeComponent();
        }

        private void OnCatLoaded(object sender, RoutedEventArgs e)
        {
            var transform = (sender as Image).RenderTransform as TranslateTransform;
            var storyboard = new Storyboard
            {
                FillBehavior = FillBehavior.Stop,
                RepeatBehavior = RepeatBehavior.Forever
            };

            var keyFrames = new DoubleAnimationUsingKeyFrames();
            Storyboard.SetTarget(keyFrames, sender as Image);
            Storyboard.SetTargetProperty(keyFrames, new PropertyPath("RenderTransform.Y"));
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
