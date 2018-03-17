using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DockPanelExample
{
    public partial class MainWindow : Window
    {
        enum Sides { Left, Right, Top, Bottom }

        Stack<Button> buttonsStack;
        Sides selectedSide;

        public MainWindow()
        {
            InitializeComponent();

            buttonsStack = new Stack<Button>();
        }

        private void RadioButton_Left_Checked(object sender, RoutedEventArgs e)
        {
            selectedSide = Sides.Left;
        }
        private void RadioButton_Right_Checked(object sender, RoutedEventArgs e)
        {
            selectedSide = Sides.Right;
        }
        private void RadioButton_Top_Checked(object sender, RoutedEventArgs e)
        {
            selectedSide = Sides.Top;
        }
        private void RadioButton_Bottom_Checked(object sender, RoutedEventArgs e)
        {
            selectedSide = Sides.Bottom;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Button newButton = new Button();

            buttonsStack.Push(newButton);

            switch (selectedSide)
            {
                case Sides.Left:
                    {
                        dockPanel.Children.Add(newButton);
                        DockPanel.SetDock(newButton, Dock.Left);
                    }
                    break;
                case Sides.Right:
                    {
                        dockPanel.Children.Add(newButton);
                        DockPanel.SetDock(newButton, Dock.Right);
                    }
                    break;
                case Sides.Top:
                    {
                        dockPanel.Children.Add(newButton);
                        DockPanel.SetDock(newButton, Dock.Top);
                    }
                    break;
                case Sides.Bottom:
                    {
                        dockPanel.Children.Add(newButton);
                        DockPanel.SetDock(newButton, Dock.Bottom);
                    }
                    break;
            }
        }
        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (buttonsStack.Count > 0)
                dockPanel.Children.Remove(buttonsStack.Pop());
        }
        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            if (buttonsStack.Count > 0)
            {
                dockPanel.Children.Clear();
                buttonsStack.Clear();
            }
        }
    }
}
