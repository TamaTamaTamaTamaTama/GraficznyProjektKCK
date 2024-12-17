using KCK2.Viewpf;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



public class MenuController
{

 

    private MenuModel model;

    private Card card;
    private AccModel accModel;
    private ClickerView clickerView;
    private ClickerController clickerController;

    private CollectionModel collectionModel;
    private CollectionView CollectionView;
    private CollectionController collectionController;
    
    private ShopView ShopView;
    private ShopModel ShopModel;
    private ShopController shopController;
    private MainWindow MainWindow;
    private SaveData saveData;
    private MenuView view;

    private string x;
    private bool checker = false;
    public int currentsave = 1;
    public MenuController(MenuModel model, string choice)
    {
        this.model = model;
        this.x = choice;
       
        view = new MenuView();
        saveData = new SaveData(this);
        accModel = new AccModel();
        clickerView = new ClickerView();
        clickerController = new ClickerController(accModel, clickerView, this);

        collectionModel = new CollectionModel();
        CollectionView = new CollectionView();
        collectionController = new CollectionController(collectionModel, CollectionView, this, accModel);

        ShopModel = new ShopModel();
        ShopView = new ShopView();
        shopController = new ShopController(ShopView, ShopModel, accModel, collectionModel, this);

      
    }




    


    public void GetSave(int which)
    { switch(which)
        {
             case 1:
             collectionModel.LoadFromFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Cards1.txt");
             accModel.FromSaveString("C:\\Users\\Dominik\\source\\repos\\KCK2\\Acc1.txt");
                currentsave = 1;
            break;
            case 2:
                collectionModel.LoadFromFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Cards2.txt");
                accModel.FromSaveString("C:\\Users\\Dominik\\source\\repos\\KCK2\\Acc2.txt");
                currentsave = 2;
                break;
            case 3:
                collectionModel.LoadFromFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Cards3.txt");
                accModel.FromSaveString("C:\\Users\\Dominik\\source\\repos\\KCK2\\Acc3.txt");
                currentsave = 3;
                break;
            case 4:
                 collectionModel.LoadFromFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Cards4.txt");
                accModel.FromSaveString("C:\\Users\\Dominik\\source\\repos\\KCK2\\Acc4.txt");
                currentsave = 4;
                break;
        }
     
    }


    public void GoToSaves()
    {
        saveData = new KCK2.Viewpf.SaveData(this);

       saveData.Show();

        foreach (Window window in Application.Current.Windows)
        {
            if (window is KCK2.Viewpf.MainWindow)
            {
                window.Close();
                break;
            }
        }
    }

    public void StartNew()
    {
        Card.ResetID();
        model.didReboot = true;
        collectionModel.LoadFromFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Cards2.txt");
        accModel.FromSaveString("C:\\Users\\Dominik\\source\\repos\\KCK2\\Acc2.txt");
        Boot();
    }

    public void Boot()
    {
        if (this.x == "1")
        {



            if (model.wasPlayed == false)
            {

                view.animation(MenuModel.MyArt);
                model.wasPlayed = true;
            }



            view.DisplayMenu(model.Options);
            bool isRunning = true;
            model.Selected = 0;
            model.SelectedPrev = -1;

            while (isRunning)
            {
                string userInput = view.GetUserInput();

                switch (userInput)
                {
                    case "downarrow":
                        {
                            if (model.Selected + 1 <= model.Options.Count)
                            {
                                MoveDown();
                                view.AdjustSelection(model.Selected, model.SelectedPrev, model.Options[model.Selected], model.Options[model.SelectedPrev]);
                            }

                            break;
                        }
                    case "uparrow":
                        {
                            if (model.Selected - 1 >= 0)
                            {
                                MoveUp();
                                view.AdjustSelection(model.Selected, model.SelectedPrev, model.Options[model.Selected], model.Options[model.SelectedPrev]);
                            }

                            break;
                        }
                    case "q":
                        {
                            isRunning = false;
                            SaveToFile(1);
                            break;
                        }
                    case "d1":
                        CollectStartup(this.x);
                        break;
                    case "enter":
                        {

                            isRunning = false;
                            switch (model.Selected)
                            {
                                case 0:
                                    CollectStartup(this.x);
                                    break;
                                case 1:
                                    ShopStartup(this.x);
                                    break;
                                case 2:
                                    CollectionStartUp(this.x);

                                    break;
                                case 3:
                                    StartNew();
                                    break;
                                case 4:
                                    SaveToFile(1);
                                    break;
                           
                              

                            }

                            break;
                        }

                    case "d2":
                        ShopStartup(this.x);
                        break;

                    case "d3":
                        CollectionStartUp(this.x);
                        break;

                    case "d4":
                        StartNew();
                        break;

                    case "d5":
                        SaveToFile(1);
                        break;

                

                }


            }
        }
        else if(this.x == "2")
        {
         
            if (Application.Current == null)
            {
                    Application app = new Application();
                    MainWindow mainWindow = new MainWindow(model.Options, this, accModel.Coins, ShopModel.price);
                    app.Run(mainWindow);
            }
            else
            {
                MainWindow mainWindow = new MainWindow(model.Options, this, accModel.Coins, ShopModel.price);
                mainWindow.Show();
            }
              
        }
    }
    



    public void SaveToFile(int selectedfile)
    {
        string data;
        if(model.didReboot == false && this.x=="1")
        {
        view.Warn();
        }
        if (model.didReboot == true && this.x == "1")
        {
            view.ExtraWarn();
        }
        if (this.x == "1")
        {
            string userinput = view.GetUserInput();
            switch (userinput)
            {
                case "y":
                    collectionModel.SaveToFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Cards1.txt");
                     data = accModel.ToSaveString();
                    accModel.SaveToFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Acc1.txt", data);
                    break;
                case "n":
                    Console.WriteLine("Saving cancelled");
                    break;

            }
        }
        else
        if (this.x == "2")
         {
            switch(selectedfile)
            {
                case 1:
                    collectionModel.SaveToFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Cards1.txt");
                    data = accModel.ToSaveString();
                    accModel.SaveToFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Acc1.txt", data);
                    break;
                case 2:
                    collectionModel.SaveToFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Cards2.txt");
                     data = accModel.ToSaveString();
                    accModel.SaveToFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Acc2.txt", data);
                    break;
                case 3:
                    collectionModel.SaveToFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Cards3.txt");
                     data = accModel.ToSaveString();
                    accModel.SaveToFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Acc3.txt", data);
                    break;
                case 4:
                    collectionModel.SaveToFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Cards4.txt");
                     data = accModel.ToSaveString();
                    accModel.SaveToFile("C:\\Users\\Dominik\\source\\repos\\KCK2\\Acc4.txt", data);
                    break;
            }
         }
      
        }
    public int GetDust()
    {
        return accModel.dust;
    }


    public void MoveUp()
    {
       if(model.Selected -1 >= 0)
        {
            model.SelectedPrev = model.Selected;
            model.Selected--;

        }

    }

    public void MoveDown()
    {
        
        if (model.Selected + 1 < model.Options.Count)
        {
            model.SelectedPrev = model.Selected;
            model.Selected++;
        }
    }

    public void CollectStartup(string choice)
    {
       
        clickerController.StartClicking(choice);
        
        
    }

    public void ShopStartup(string choice)
    {
        shopController.OpenShop(choice);
    }

    public void CollectionStartUp(string choice)
    {
        
        collectionController.Boot(choice);
       
        
    }



}
