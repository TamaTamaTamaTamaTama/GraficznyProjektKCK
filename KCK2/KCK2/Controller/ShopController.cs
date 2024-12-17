using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

public class ShopController
{
    private ShopModel model;
    private ShopView view;
    private ShopController controller;
    private MenuController menuController;
    private AccModel accModel;
    private CollectionModel collectionModel;
    private KCK2.Viewpf.Shop shopWindow;


    public ShopController(ShopView view, ShopModel model, AccModel accmodel, CollectionModel collectionModel, MenuController menuController)
    {
        this.model = model;
        this.view = view;
        this.menuController = menuController;
        this.accModel = accmodel;
        this.collectionModel = collectionModel;
        

    }

    public void OpenShop(string choice)
    {
        if (choice == "1")
        {
            view.OpenUp(model.price, model.bundle, accModel.Coins);

            bool isRunning = true;
            while (isRunning)
            {
                string userInput = view.GetUserInput();
                switch (userInput)
                {
                    case "enter":
                        Openning(choice);
                        break;
                    case "q":
                        Quit();
                        break;
                }
            }
        }
        else if (choice == "2")
        {
            shopWindow = new KCK2.Viewpf.Shop(this, accModel.Coins, model.price, model.bundle);

            shopWindow.Show();

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
    public void Roll(string choice)
    {
        
        Random random = new Random();
        int decider;
        int gainedDust= 0;
        int duplicates = 0;

        Console.SetCursorPosition(0, 3);

        List<Card> cards = new List<Card>();
        for(int i = 0; i< model.bundle; i++)
        {
            
            decider= random.Next(0, collectionModel.MyCollection.Count);
            if (collectionModel.MyCollection[decider].isOwned == false)
            {
                collectionModel.MyCollection[decider].isOwned = true;
                cards.Add(collectionModel.MyCollection[decider]);
            }
            else
            {
               
                accModel.dust = accModel.dust + collectionModel.MyCollection[decider].DustDisenchant;
                gainedDust += collectionModel.MyCollection[decider].DustDisenchant;
                duplicates++;
            }
          
      
        }
        if(choice == "1")
        {
         view.ShowCardsPopUp(cards, gainedDust, duplicates, model.bundle);
        }
        if (choice == "2")
        {
            shopWindow.DisplayLoot(cards, gainedDust, duplicates, model.bundle);
        }
       
    }

    public void Openning(string choice)
    {
        if(accModel.Coins >= model.price)
        {
            accModel.Coins = accModel.Coins - model.price;
            if (choice == "1")
            {
                view.UpdateCoins(accModel.Coins);
            }
            else if (choice == "2")
            {
                shopWindow.Update_Coins(accModel.Coins, model.price);
            }
            Roll(choice);
        }
        else
        {
            if (choice == "1")
            {
                view.NotEnoughCoins(-(accModel.Coins - model.price));
            }
            else if (choice == "2")
            {
                shopWindow.NoLeft();
            }
              
        }
      
    }

    public void Quit()
    {
        menuController.Boot();
        Environment.Exit(1); 
    }



    public void Exit()
    {
        menuController.Boot();
        foreach (Window window in Application.Current.Windows)
        {

            if (window is not KCK2.Viewpf.MainWindow)
            {
                window.Close();
            }
        }


    }


}