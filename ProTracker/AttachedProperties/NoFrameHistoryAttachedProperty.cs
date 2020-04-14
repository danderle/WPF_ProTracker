
using System.Windows;
using System.Windows.Controls;

namespace ProTracker
{
    /// <summary>
    /// A base class to run any animation method when a bool is set to true
    /// and reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public class NoFrameHistoryAttachedProperty : BaseAttachedProperty<NoFrameHistoryAttachedProperty, bool>
    {
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            var frame = sender as Frame;

            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            frame.Navigated += (s, e) =>
            {
                (s as Frame).NavigationService.RemoveBackEntry();
            };
        }
    }
}
