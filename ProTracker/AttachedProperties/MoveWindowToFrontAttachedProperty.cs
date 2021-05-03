
using System.Windows;

namespace ProTracker
{
    /// <summary>
    /// Moves the window to the front
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public class MoveWindowToFrontProperty : BaseAttachedProperty<MoveWindowToFrontProperty, bool>
    {
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if(!(sender is BasePage basePage))
            {
                return;
            }

            var window = Window.GetWindow(basePage);
            if(window != null)
            {
                window.Activate();
            }
        }
    }
}
