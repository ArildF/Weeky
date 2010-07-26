using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Weeky.Behaviors
{
    public class ItemsControlBehaviors
    {
        public static readonly DependencyProperty CurrentlyInViewProperty =
            DependencyProperty.RegisterAttached("CurrentlyInView", typeof (object),
                                                typeof (ItemsControlBehaviors),
                                                new PropertyMetadata(CurrentlyInViewChanged));

        public static void SetCurrentlyInView(ItemsControl control, object value)
        {
            control.SetValue(CurrentlyInViewProperty, value);
        }

        public static object GetCurrentlyInView(ItemsControl control)
        {
            return control.GetValue(CurrentlyInViewProperty);
        }

        private static void CurrentlyInViewChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var ic = (ItemsControl) dependencyObject;
            var newValue = e.NewValue;

            if (ic.IsLoaded)
            {
                BringIntoView(ic, newValue);
            }
            else
            {
                RoutedEventHandler handler = null;
                handler = (sender, args) =>
                    {
                        BringIntoView(ic, newValue);
                        ic.Loaded -= handler;
                    };
                ic.Loaded += handler; 
            }
            
        }

        private static void BringIntoView(ItemsControl ic, object newValue)
        {
            var presenter = (ContentPresenter) ic.ItemContainerGenerator.ContainerFromItem(newValue);
            if (presenter != null)
            {
                presenter.BringIntoView();
            }
        }
    }
}
