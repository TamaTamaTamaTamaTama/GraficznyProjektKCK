using KCK2.Viewpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

public class CollectionController
{
    private CollectionModel model;
    private CollectionView view;
    private Collection _collection;
    private MenuController menu;
    private AccModel acc;


    private int selected = 0;
    private int selectedprev = 0;
    private int left = 0;
    private int right = 25;
    private int index = 0;
    private int indexprev = 0;
    private int TypeSort = 0;
    private int currPage = 1;
    private int maxPage = 0;
    public string choicex = "1";
    

    public CollectionController(CollectionModel model, CollectionView view, MenuController menu, AccModel acc)
    {
        this.model = model;
        this.view = view;
        this.menu = menu;
        this.acc = acc;

        
    }

    public void Boot(string choice)
    {   
        choicex=choice;
        if (choice == "1")
        {


            view.DisplayCollectionPage(model.MyCollection, left, right);
            if (model.MyCollection.Count % 25 == 0)
            {
                maxPage = model.MyCollection.Count / 25;
            }
            else
            {
                maxPage = 1 + model.MyCollection.Count / 25;
            }

            view.DisplayCollectionMenu(model.MyCollectionOptions, menu.GetDust(), currPage, maxPage);

            bool isRunning = true;
            while (isRunning)
            {
                string userInput = view.GetUserInput();
                switch (userInput)
                {
                    case "q":
                        LeaveCollection(choice);
                        break;
                    case "s":
                        SortCollection();
                        break;
                    case "downarrow":
                        MoveDown();
                        break;
                    case "uparrow":
                        MoveUp();
                        break;
                    case "enter":
                        SelectCard();
                        break;
                    case "rightarrow":
                        ChangePageRight();

                        break;
                    case "leftarrow":
                        ChangePageLeft();

                        break;
                }
            }
        }
        else if (choice == "2")
        {
            _collection = new KCK2.Viewpf.Collection(this, model.MyCollection, menu.GetDust());

           _collection.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window is KCK2.Viewpf.MainWindow)
                {
                    window.Close();
                    break;
                }
            }
        }

    }

    public void LeaveCollection(string choice)
    {
        
        menu.Boot();
  
        if (choice == "2")
        {
             foreach (Window window in Application.Current.Windows)
            {

                if (window is not KCK2.Viewpf.MainWindow)
                {
                    window.Close();
                }
            }
        }      
    }

 
    public List<Card> sortenhanced(int filteroption)
    {
        model.SortCollection(filteroption);
        return model.MyCollection;
    }

    public void SortCollection()
    {
        TypeSort = model.SortCollection(TypeSort);
        left = 0;
        right = Math.Min(25, model.MyCollection.Count);
        selected = 0;
        index = 0;
        currPage = 1;
        view.DisplayCollectionPage(model.MyCollection, left, right);
        view.DisplayCollectionMenu(model.MyCollectionOptions, menu.GetDust(), currPage, maxPage);
        Console.SetCursorPosition(0, 27);
        Console.WriteLine(model.SortingOptions[TypeSort-1]);
        
    }

    public void MoveDown()
    {
        if (selected + 1 < 25&& index + 1 < right)
        {
            selectedprev = selected;
            selected++;
            indexprev = index;
            index++;
            view.AdjustSelection(selected, selectedprev, model.MyCollection[index], model.MyCollection[indexprev], model.MyCollection.Count, index, indexprev);
            view.DeleteNotification();
        }
        else
        {
            if(selected == 24)
            {
                ChangePageRight();
            }
        }
        Console.SetCursorPosition(0, 27);
    }

    public void MoveUp()
    {
        if (selected - 1 >= 0 && index -1 >= left)
        {
            selectedprev = selected;
            selected--;
            indexprev = index;
            index--;
            view.AdjustSelection(selected, selectedprev, model.MyCollection[index], model.MyCollection[indexprev], model.MyCollection.Count, index, indexprev);
            view.DeleteNotification();
        }
        else
        {
            if(selected == 0 && index != 0)
            {
                ChangePageLeft();
            }
        }
        Console.SetCursorPosition(0, 27);
    }

    public void ChangePageRight()
    {
       
        if (right < model.MyCollection.Count)
        {
            left = right;
            right = Math.Min(right + 25, model.MyCollection.Count);
            selected = 0;
            selectedprev = selected;
            indexprev = index;
            index = left;
            currPage++;
            view.DisplayCollectionPage(model.MyCollection, left, right);
        }
         view.DisplayCollectionMenu(model.MyCollectionOptions, menu.GetDust(), currPage, maxPage);
        view.DeleteNotification();
        Console.SetCursorPosition(0, 27);
    }

    public void ChangePageLeft()
    {
       
        if (left > 0)
        {
            right = left;
            left = left - 25;
            selected = 0;
            selectedprev = selected;
            index = left;
            currPage--;
            view.DisplayCollectionPage(model.MyCollection, left, right);
        }
        view.DisplayCollectionMenu(model.MyCollectionOptions, menu.GetDust(), currPage, maxPage);
        view.DeleteNotification();
        Console.SetCursorPosition(0, 27);
    }



   public void Disenchant(Card selectedCard)
    {
        acc.dust = acc.dust + model.MyCollection[index].DustDisenchant;
        selectedCard.isOwned = false;
        if (choicex == "1")
        {
            view.UpdateOne(selectedCard, selected, acc.dust);
        }
        else
        if (choicex == "2")
        {
           _collection.UpdateDust(acc.dust); 
        }
       

    }

    public void Craft(Card selectedCard)
    {
        acc.dust = acc.dust - model.MyCollection[index].DustCraft;
        selectedCard.isOwned = true;
        if (choicex == "1")
        {
         view.UpdateOne(selectedCard, selected, acc.dust);
        }
        else
        {
            _collection.UpdateDust(acc.dust);
        }
       

    }

    public List<Card> ShowAll()
    {
        return model.MyCollection;
    }

    public List<Card> FilterByCost(int cost)
    {
       
        return model.MyCollection.Where(card => card.Cost == cost).ToList();
    }

    public void SelectCard()
    {
        
        var selectedCard = model.MyCollection[index];

        if (model.MyCollection[index].isOwned)
        {
           
           if( view.AskDisenchant(model.MyCollection[index]) == true )
            {
              Disenchant(selectedCard);
            }
        }
        else
        {
            if(acc.dust > model.MyCollection[index].DustCraft)
            {
                if (view.AskCraft(model.MyCollection[index]) == true)
                {
                   Craft(selectedCard); 
                  
                }
                
            }
            else
            {
                view.NotEnoughDust(model.MyCollection[index].DustCraft-acc.dust);    
            }
            
        }

    }



}
