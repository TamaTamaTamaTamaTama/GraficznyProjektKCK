using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace KCK2.Viewpf
{
    public partial class Collection : Window
    {   private readonly CollectionController _controller;
        private ObservableCollection<Card> MyCollection;
        public Collection(CollectionController collection, List<Card> myCollection, int dust)
        {
            InitializeComponent();
            _controller = collection;
            MyCollection = new ObservableCollection<Card>(myCollection);
            CardItemsControl.ItemsSource = MyCollection;
            DustCounter.Content = $"{dust} dust";
        }

        private void SortComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedItem = SortComboBox.SelectedItem as System.Windows.Controls.ComboBoxItem;

            if (selectedItem != null)
            {
                int sortingOption = 0;
             
                switch(selectedItem.Content.ToString()) 
                {
                    case "0. Sorting alphabetically":
                        sortingOption = 0;
                        break;
                    case "1. Sorting by ID":
                        sortingOption = 1;
                        break;
                    case "2. Sorting alphabetically backwards":
                        sortingOption = 2;
                        break;
                    case "3. Sorting by cost, lowest to highest":
                        sortingOption = 3;
                        break;
                    case "4. Sorting by cost, highest to lowest":
                        sortingOption = 4;
                        break;
                    case "5. Sorting by dust cost, cheapest to craft":
                        sortingOption = 5;
                        break;
                    case "6. Sorting by dust cost, most expensive discards":
                        sortingOption = 6;
                        break;
                    case "7. Sorting to show the cards you don't own first":
                        sortingOption = 7;
                        break;
                    case "8. Sorting to show the cards you do own first":
                        sortingOption = 8;
                        break;
                }
                var filteredCards = _controller.sortenhanced(sortingOption);
                MyCollection.Clear();
                foreach (var card in filteredCards)
                {
                    MyCollection.Add(card);
                }
                CardItemsControl.Items.Refresh();

            }
        }


        public void UpdateDust(int dust)
        {
            DustCounter.Content = dust;
        }


        private void CardSelect_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

          
            var selectedCard = button?.CommandParameter as Card; 

            if (selectedCard != null)
            {
               if(selectedCard.isOwned)
                {
                    MessageBoxResult result = MessageBox.Show(
                        $"You own this card. You can destroy it and gain {selectedCard.DustDisenchant} dust",
                                $"{selectedCard.Name}",
                          MessageBoxButton.YesNo);
                         

                    if (result == MessageBoxResult.Yes)
                    {
                        MessageBox.Show("Time to destroy");
                        _controller.Disenchant(selectedCard);
                    }
                    else
                    {
                        MessageBox.Show("Cancelled");
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(
                         $"You DON'T own this card. You can craft it, but it will cost you {selectedCard.DustDisenchant} dust",
                                 $"{selectedCard.Name}",
                           MessageBoxButton.YesNo);


                    if (result == MessageBoxResult.Yes)
                    {
                        MessageBox.Show("Time to craft");
                        _controller.Craft(selectedCard);
                    }
                    else
                    {
                        MessageBox.Show("Cancelled");
                    }
                }
            }
        }


        private void FilterX(object sender, RoutedEventArgs e)
        {

            var allCards = _controller.ShowAll();

            MyCollection.Clear();
           foreach(var card in allCards) 
            {
                MyCollection.Add(card);
            }


            CardItemsControl.Items.Refresh();

        }

        private void Filter0(object sender, RoutedEventArgs e)
        {
            var filteredCards = _controller.FilterByCost(0);
            MyCollection.Clear();
            foreach (var card in filteredCards)
            {
                MyCollection.Add(card);
            }

            CardItemsControl.Items.Refresh();


        }


      

        private void Filter1(object sender, RoutedEventArgs e)
        {
            var filteredCards = _controller.FilterByCost(1);
            MyCollection.Clear();
            foreach (var card in filteredCards)
            {
                MyCollection.Add(card);
            }

            CardItemsControl.Items.Refresh();
        }

        private void Filter2(object sender, RoutedEventArgs e)
        {
            var filteredCards = _controller.FilterByCost(2);
            MyCollection.Clear();
            foreach (var card in filteredCards)
            {
                MyCollection.Add(card);
            }

            CardItemsControl.Items.Refresh();
        }

        private void Filter3(object sender, RoutedEventArgs e)
        {
            var filteredCards = _controller.FilterByCost(3);
            MyCollection.Clear();
            foreach (var card in filteredCards)
            {
                MyCollection.Add(card);
            }

            CardItemsControl.Items.Refresh();
        }

        private void Filter4(object sender, RoutedEventArgs e)
        {
            var filteredCards = _controller.FilterByCost(4);
            MyCollection.Clear();
            foreach (var card in filteredCards)
            {
                MyCollection.Add(card);
            }

            CardItemsControl.Items.Refresh();
        }

        private void Filter5(object sender, RoutedEventArgs e)
        {
            var filteredCards = _controller.FilterByCost(5);
            MyCollection.Clear();
            foreach (var card in filteredCards)
            {
                MyCollection.Add(card);
            }

            CardItemsControl.Items.Refresh();
        }

        private void Filter6(object sender, RoutedEventArgs e)
        {
            var filteredCards = _controller.FilterByCost(6);
            MyCollection.Clear();
            foreach (var card in filteredCards)
            {
                MyCollection.Add(card);
            }

            CardItemsControl.Items.Refresh();
        }

        private void Filter7(object sender, RoutedEventArgs e)
        {
            var filteredCards = _controller.FilterByCost(7);
            MyCollection.Clear();
            foreach (var card in filteredCards)
            {
                MyCollection.Add(card);
            }

            CardItemsControl.Items.Refresh();
        }

        private void Filter8(object sender, RoutedEventArgs e)
        {
            var filteredCards = _controller.FilterByCost(8);
            MyCollection.Clear();
            foreach (var card in filteredCards)
            {
                MyCollection.Add(card);
            }

            CardItemsControl.Items.Refresh();
        }

        private void Filter9(object sender, RoutedEventArgs e)
        {
            var filteredCards = _controller.FilterByCost(9);
            MyCollection.Clear();
            foreach (var card in filteredCards)
            {
                MyCollection.Add(card);
            }

            CardItemsControl.Items.Refresh();
        }

        private void Filter10(object sender, RoutedEventArgs e)
        {
            var filteredCards = _controller.FilterByCost(10);
            MyCollection.Clear();
            foreach (var card in filteredCards)
            {
                MyCollection.Add(card);
            }

            CardItemsControl.Items.Refresh();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
           _controller.LeaveCollection("2");
        }
    }
}
