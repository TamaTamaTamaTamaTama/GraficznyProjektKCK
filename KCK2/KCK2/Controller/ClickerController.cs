using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

  public class ClickerController
{
    private AccModel model;
    private ClickerView view;
    private KCK2.Viewpf.Clicker clickerWindow;
    private MenuController menu;

    public ClickerController(AccModel model, ClickerView view, MenuController menu)
    {
        this.model = model;
        this.view = view;
        this.menu = menu;
    }
    public void StartClicking(string choice)
    {
        if (choice == "1")
        {


            bool isRunning = true;

            view.DisplayClickCount(model.AccLevel, model.Coins, model.NextLevelReq, model.CurrentProgress, model.gain);
            while (isRunning)
            {
                string userInput = view.GetUserInput();

                if (userInput == "Enter")
                {
                    mechanic(choice);
                }
                else if (userInput.ToLower() == "q")
                {
                    isRunning = false;
                    menu.Boot();
                    Environment.Exit(1);


                }
            }
        }
        else if (choice == "2")
        {
           clickerWindow = new KCK2.Viewpf.Clicker(model.AccLevel, model.Coins, model.NextLevelReq, model.CurrentProgress, model.gain, this);

            clickerWindow.Show();

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

    public void Exit()
    { menu.Boot();
        foreach (Window window in Application.Current.Windows)
        {
            
            if (window is not KCK2.Viewpf.MainWindow)
            {
                window.Close();
            }
        }
       
     
    }
   

    public void mechanic(string choice)
    {
        model.ClickCount();
        if (choice == "1")
        {
            view.UpdateClick(model.Coins, model.CurrentProgress, model.NextLevelReq);            
                if (model.IsLevelUp == true)
                {
                    if (model.AccLevel % 5 == 0)
                    {
                        view.animation(AccModel.MyArt, 0, 4);
                    }
                    else
                    {
                        view.animation(AccModel.MyArt, 0, 1);
                    }
                    view.NotifyLevelUp(model.AccLevel, model.gain);
                }

        }
        else if (choice == "2")
        {
           
            clickerWindow.Update(model.AccLevel, model.Coins, model.NextLevelReq, model.CurrentProgress, model.gain);
        }
    }
}