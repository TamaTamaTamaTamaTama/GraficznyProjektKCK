using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KCK2.Viewpf
{
    public partial class MainWindow : Window
    {


        private readonly MenuController _menuController;


        public MainWindow(List<string> options, MenuController menuController, int coins, int cost)
        {
            InitializeComponent();
            _menuController = menuController;
            Click.Content = options[0];
            Shop.Content = options[1];
            Collection.Content = options[2];
            Save.Content = options[3];
            Exit.Content = options[4];

            if (coins / cost > 0)
            {
                GotMoney.Foreground = new SolidColorBrush(Colors.Orange);
                GotMoney.Content = $"<--- You can buy {coins / cost} packs!!!";

            }
            else
            {
                NeedMoney.Foreground = new SolidColorBrush(Colors.Orange);
            }

            NeedMoney.Content = $"<--- You need just {cost - coins % cost} more coins for one more pack";

            CurrSave.Content = $"<--- Save {_menuController.currentsave}";
           

        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _menuController.CollectStartup("2");

        }
        private void Button_Shop(object sender, RoutedEventArgs e)
        {
            _menuController.ShopStartup("2");
        }
        private void Button_Collection(object sender, RoutedEventArgs e)
        {
            _menuController.CollectionStartUp("2");
        }


        private void Button_Save(object sender, RoutedEventArgs e)
        {
            _menuController.GoToSaves();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



    }
}
