using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Weeky.Behaviors
{
    public class UIElementBehaviors
    {
        public static readonly DependencyProperty SingleClickCommandProperty =
            DependencyProperty.RegisterAttached("SingleClickCommand", typeof (ICommand),
                                                typeof (UIElementBehaviors),
                                                new PropertyMetadata(SingleClickCommandPropertyChanged));


        public static void SetSingleClickCommand(UIElement element, ICommand value)
        {
            element.SetValue(SingleClickCommandProperty, value);
        }

        public static ICommand GetSingleClickCommandProperty(UIElement element)
        {
            return (ICommand) element.GetValue(SingleClickCommandProperty);
        }

        private static void SingleClickCommandPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var element = (UIElement) dependencyObject;
            element.MouseUp -= ElementOnMouseUp;
            element.MouseUp += ElementOnMouseUp;
        }

        private static void ElementOnMouseUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var element = (UIElement) sender;
            var command = GetSingleClickCommandProperty(element);
            if (command.CanExecute(null))
            {
                command.Execute(null);
            }
        }
    }
}
