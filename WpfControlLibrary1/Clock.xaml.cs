using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfControlLibrary1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            StartClock();
        }

        private void StartClock()
        {
            // Get current time
            DateTime currentTime = DateTime.Now;
            double centerX = Circle.ActualWidth / 1;
            double centerY = Circle.ActualHeight / 1;
            // Hour Hand
            DoubleAnimation hourAnimation = new DoubleAnimation();
            hourAnimation.From = (currentTime.Hour % 12) * 30; // Calculate hour angle (12 hours * 30 degrees)
            hourAnimation.To = hourAnimation.From + 360; // Add a full rotation (12 hours * 30 degrees)
            hourAnimation.Duration = new Duration(TimeSpan.FromHours(12));
            hourAnimation.RepeatBehavior = RepeatBehavior.Forever;
            RotateTransform hourTransform = new RotateTransform();
            hourTransform.CenterX = centerX / 60;
            hourTransform.CenterY = centerY / 60;
            ArrowHour.RenderTransform = hourTransform;
            hourTransform.BeginAnimation(RotateTransform.AngleProperty, hourAnimation);

            // Minute Hand
            DoubleAnimation minuteAnimation = new DoubleAnimation();
            minuteAnimation.From = currentTime.Minute * 6; // Calculate minute angle (60 minutes * 6 degrees)
            minuteAnimation.To = minuteAnimation.From + 360; // Add a full rotation (60 minutes * 6 degrees)
            minuteAnimation.Duration = new Duration(TimeSpan.FromMinutes(60));
            minuteAnimation.RepeatBehavior = RepeatBehavior.Forever;
            RotateTransform minuteTransform = new RotateTransform();
            minuteTransform.CenterX = centerX / 60;
            minuteTransform.CenterY = centerY / 60;
            ArrowMinute.RenderTransform = minuteTransform;
            minuteTransform.BeginAnimation(RotateTransform.AngleProperty, minuteAnimation);

            // Second Hand
            DoubleAnimation secondAnimation = new DoubleAnimation();
            secondAnimation.From = currentTime.Second * 6; // Calculate second angle (60 seconds * 6 degrees)
            secondAnimation.To = secondAnimation.From + 360; // Add a full rotation (60 seconds * 6 degrees)
            secondAnimation.Duration = new Duration(TimeSpan.FromSeconds(60));
            secondAnimation.RepeatBehavior = RepeatBehavior.Forever;
            RotateTransform secondTransform = new RotateTransform();
            secondTransform.CenterX = centerX / 600;
            secondTransform.CenterY = centerY / 600;
            ArrowSecond.RenderTransform = secondTransform;
            secondTransform.BeginAnimation(RotateTransform.AngleProperty, secondAnimation);
        }
    }
}
