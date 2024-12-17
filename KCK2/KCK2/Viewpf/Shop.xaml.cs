using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KCK2.Viewpf
{
    public partial class Shop : Window
    {
        private readonly ShopController shop;
        private int currentCoins; 
        private int packCost;
        private int amountperpack;

     
        public Shop(ShopController _shop, int coins, int cost, int amount)
        {
            InitializeComponent();
            shop = _shop;
            currentCoins = coins;  
            packCost = cost;     
            amountperpack = amount;
         
            CoinLabel.Content = $"You have: {currentCoins} coins";
            PackCost.Content = $"Cost of one pack: {packCost} coins";
            PackAmount.Content = $"Amount of cards in a pack: {amount} cards";

          
            Affordable.Content = $"You can afford {currentCoins / packCost} more packs";

            
            UpdateAffordabilityStatus();
        }

      
        private void UpdateAffordabilityStatus()
        {
   
            int packsAffordable = currentCoins / packCost;

     
            Affordable.Content = $"You can afford {packsAffordable} more packs";

          
            if (packsAffordable > 0)
            {
                Affordable.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                Affordable.Foreground = new SolidColorBrush(Colors.Red);
                BuyButton.IsEnabled = false; 
            }
        }

      
        public void DisplayLoot(List<Card> cards, int duplicatedDust, int duplicatesCount, int maxCards)
        {
         
            var cardsToDisplay = cards.Take(amountperpack).ToList();

           
            CardListBox.ItemsSource = cardsToDisplay;

       
        }

       
        private void Buy_Click(object sender, RoutedEventArgs e)
        {
         
            shop.Openning("2");
        }

        public void NoLeft()
        {
            BuyButton.IsEnabled = false;
        }

      
        public void Update_Coins(int coins, int cost)
        {
            currentCoins = coins;  
            CoinLabel.Content = $"You have {coins} coins";

       
            UpdateAffordabilityStatus();
        }

     
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            shop.Exit();  
        }
    }
}
