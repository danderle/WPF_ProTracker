
using System.Windows;
using System.Windows.Controls;

namespace ProTracker
{
    /// <summary>
    /// Focuses (keyboard focus) this element on load
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if(!(sender is Control control))
            {
                return;
            }

            //Focus this control once loaded
            control.Loaded += (s, ee) => control.Focus();
        }
    }
}
