using System.Windows;
using System.Windows.Controls;

namespace Weeky.Behaviors
{
    public class WrapPanelBehaviors
    {
        public static readonly DependencyProperty NumberOfColumns =
            DependencyProperty.RegisterAttached("NumberOfColumns", typeof (int),
                                                typeof (WrapPanelBehaviors), 
                                                new PropertyMetadata(OnNumberOfColumnsChanged));

        public static int GetNumberOfColumns(WrapPanel panel)
        {
            return (int) panel.GetValue(NumberOfColumns);
        }

        public static void SetNumberOfColumns(WrapPanel panel, int value)
        {
            panel.SetValue(NumberOfColumns, value);
        }

        private static void OnNumberOfColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var panel = d as WrapPanel;
            if (panel != null)
            {
                panel.SizeChanged -= PanelOnSizeChanged;
                panel.SizeChanged += PanelOnSizeChanged;
            }
        }

        private static void PanelOnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            var panel = sender as WrapPanel;
            if (panel == null)
            {
                return;
            }

            var columns = (int) panel.GetValue(NumberOfColumns);
            panel.ItemWidth = panel.ActualWidth/columns;
        }
    }
}
