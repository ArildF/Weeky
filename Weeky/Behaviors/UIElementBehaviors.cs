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

        public static readonly DependencyProperty DragWindowOnMouseDownProperty =
            DependencyProperty.RegisterAttached("DragWindowOnMouseDown", typeof (bool),
                                                typeof (UIElementBehaviors),
                                                new PropertyMetadata(DragWindowOnMouseDownPropertyChanged));


        public static void SetDragWindowOnMouseDown(UIElement element, bool value)
        {
            element.SetValue(DragWindowOnMouseDownProperty, value);
        }

        public static bool GetDragWindowOnMouseDown(UIElement element)
        {
            return (bool) element.GetValue(DragWindowOnMouseDownProperty);
        }

        private static void DragWindowOnMouseDownPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var element = (UIElement) dependencyObject;
            element.MouseDown -= ElementOnMouseDown;

            if ((bool)e.NewValue)
            {
                element.MouseDown += ElementOnMouseDown;
            }
        }

        private static void ElementOnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var element = (DependencyObject) mouseButtonEventArgs.Source;
            while (!(element is Window))
            {
                element = LogicalTreeHelper.GetParent(element);
            }

            ((Window)element).DragMove();
        }
    }
}
