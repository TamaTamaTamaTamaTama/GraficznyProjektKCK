using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KCK2.Viewpf
{
  
    public partial class SaveData : Window
    {   private readonly MenuController controller;
        public SaveData(MenuController _controller)
        {
            InitializeComponent();
            controller = _controller;
        }

        private void Over1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                            "You are about to overwrite savefile 1. Proceed?",
                            "Save 1",
                          MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                controller.SaveToFile(1);
            }

        }
        private void Select1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                           "You are about to load savefile 1. Proceed?",
                           "Save 1",
                         MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                controller.GetSave(1);
            }
        }

        private void Over2_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                            "You are about to overwrite savefile 2. Proceed?",
                            "Save 2",
                          MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                controller.SaveToFile(2);
            }
        }

        private void Select2_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                             "You are about to load savefile 2. Proceed?",
                             "Save 2",
                           MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                controller.GetSave(2);
            }
        }

        private void Over4_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                           "You are about to overwrite savefile 4. Proceed?",
                           "Save 4",
                         MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                controller.SaveToFile(4);
            }
         
        }

        private void Select4_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                            "You are about to load savefile 4. Proceed?",
                            "Save 4",
                          MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                controller.GetSave(4);
            }
        }

        private void Over3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                           "You are about to overwrite savefile 3. Proceed?",
                           "Save 3",
                         MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                controller.SaveToFile(3);
            }
        }

        private void Select3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                             "You are about to load savefile 3. Proceed?",
                             "Save 3",
                           MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                controller.GetSave(3);
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
             controller.Boot();
            foreach (Window window in Application.Current.Windows)
            {
               
                if (window is not KCK2.Viewpf.MainWindow)
                {
                    window.Close();
                }
            }
        }


    }
}
