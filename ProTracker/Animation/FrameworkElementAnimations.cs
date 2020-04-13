using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ProTracker
{
    /// <summary>
    /// Helpers to animate framework elements in specific ways
    /// </summary>
    public static class FrameworkElementAnimations
    {
        /// <summary>
        /// Slides and fades a framework element in from the right
        /// </summary>
        /// <param name="element">the element to animate</param>
        /// <param name="seconds">the time the animation takes</param>
        /// <param name="keeepMargin">Whether to keep the element at the same width during animations</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add the slide from right
            sb.AddSlideFromRight(seconds, element.ActualWidth, keepMargin: keepMargin);

            //Adds the fade in
            sb.AddsFadeIn(seconds);

            //Star animation
            sb.Begin(element);

            // Make page visible
            element.Visibility = System.Windows.Visibility.Visible;

            //Wait for the animation to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides and fades a framework element in from the left
        /// </summary>
        /// <param name="element">the element to animate</param>
        /// <param name="seconds">the time the animation takes</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animations</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add the slide from right
            sb.AddSlideFromLeft(seconds, element.ActualWidth, keepMargin: keepMargin);

            //Adds the fade in
            sb.AddsFadeIn(seconds);

            //Star animation
            sb.Begin(element);

            // Make page visible
            element.Visibility = System.Windows.Visibility.Visible;

            //Wait for the animation to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides a framework element out to the left
        /// </summary>
        /// <param name="element">the element to animate</param>
        /// <param name="seconds">the time the animation takes</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animations</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add custom animation
            sb.AddSlideOutLeft(seconds, element.ActualWidth, keepMargin: keepMargin);

            //Adds the fade out
            sb.AddsFadeOut(seconds);

            //Star animation
            sb.Begin(element);

            // Make page visible
            element.Visibility = System.Windows.Visibility.Visible;

            //Wait for the animation to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides a framework element out to the right
        /// </summary>
        /// <param name="element">the element to animate</param>
        /// <param name="seconds">the time the animation takes</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animations</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true)
        {
            //Create the storyboard
            var sb = new Storyboard();

            //Add custom animation
            sb.AddSlideOutRight(seconds, element.ActualWidth, keepMargin: keepMargin);

            //Adds the fade out
            sb.AddsFadeOut(seconds);

            //Star animation
            sb.Begin(element);

            // Make page visible
            element.Visibility = System.Windows.Visibility.Visible;

            //Wait for the animation to finish
            await Task.Delay((int)(seconds * 1000));
        }
    }
}
