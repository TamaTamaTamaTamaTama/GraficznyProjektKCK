using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class CollectionView
{
    public void DisplayCollection(List<Card> MyCollection)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 0);
        if (MyCollection[0].isOwned == true)
        {
            DisplayOwned(MyCollection[0]);
        }
        else
        {
            DisplayUnowned(MyCollection[0]);
        }
        Console.ResetColor();


        for (int i = 1; i < MyCollection.Count; i++)
        {

            if (MyCollection[i].isOwned == true)
            {
                DisplayOwned(MyCollection[i]);
            }
            else
            {
                DisplayUnowned(MyCollection[i]);
            }


        }
    }

    public void DisplayCollectionPage(List<Card> MyCollection, int x, int y)
    {

        if (y > MyCollection.Count)
        {
            y = MyCollection.Count;
        }
        if (x < 0)
        {
            x = 0;
        }
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 0);
        if (MyCollection[x].isOwned == true)
        {
            DisplayOwned(MyCollection[x]);
        }
        else
        {
            DisplayUnowned(MyCollection[x]);
        }

        Console.ResetColor();




        for (int i = x + 1; i < y; i++)
        {

            if (MyCollection[i].isOwned == true)
            {
                DisplayOwned(MyCollection[i]);
            }
            else
            {
                DisplayUnowned(MyCollection[i]);
            }


        }

    }




    public void DisplayOwned(Card card)
    {

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write($"ID: #{card.ID} ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write($"Name:{card.Name} ");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write($"Mana cost:{card.Cost} ");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write($"Attack: {card.Attack} ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write($"Health: {card.MaxHealth} ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write($"[Press Enter to Discard: +{card.DustDisenchant} dust]                        \n");

        Console.ForegroundColor = ConsoleColor.White;


    }

    public void DisplayUnowned(Card card)
    {

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write($"ID: #{card.ID} ");
        Console.Write($"????:? ");
        Console.Write($"???? ????:? ");
        Console.Write($"??????: ? ");
        Console.Write($"??????: ? ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        int consoleWidth = Console.WindowWidth;
        Console.Write($"Press Enter to [Craft: -{card.DustCraft} dust]                             \n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void DisplayCollectionMenu(List<string> MyCollectionOptions, int dust, int currPage, int maxPage)
    {

        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(0, 25);
        for (int i = 0; i < MyCollectionOptions.Count; i++)
        {
            Console.Write($"{MyCollectionOptions[i]} ");
        }
        Console.Write($"CURRENT PAGE: {currPage}/{maxPage}");
        Console.ResetColor();
        Console.WriteLine("");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"Dust: {dust}");
        Console.ResetColor();


    }
    public string GetUserInput()
    {
        var key = Console.ReadKey(true);

        return key.Key.ToString().ToLower();
    }

    public void AdjustSelection(int selected, int prev, Card x, Card y, int z, int index, int superprev)
    {

        Console.SetCursorPosition(0, selected);

        Console.BackgroundColor = ConsoleColor.White;

        if (x.isOwned == true)
        {
            DisplayOwned(x);
        }
        else
        {
            DisplayUnowned(x);
        }
        Console.SetCursorPosition(0, prev);
        Console.ResetColor();
        if (y.isOwned == true)
        {
            DisplayOwned(y);
        }
        else
        {
            DisplayUnowned(y);
        }

    }


    public bool AskDisenchant(Card card)
    {
        Console.SetCursorPosition(0, 27);
        Console.WriteLine($"Nice card, wanna destroy it? You will get {card.DustDisenchant} dust! (Y/n)");
        var key = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (key == "y")
        {
            Console.WriteLine($"Grinded into +{card.DustDisenchant} dust!                 ");
            return true;
        }
        else
        {
            Console.WriteLine($"Good idea, you should keep this one!                     ");
            return false;
        }
    }

    public bool AskCraft(Card card)
    {
        Console.SetCursorPosition(0, 27);
        Console.WriteLine($"Wanna craft this card for {card.DustCraft} dust? (Y/n)       ");
        var key = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (key == "y")
        {
            Console.WriteLine($"Well spent {card.DustCraft}!                           ");
            return true;
        }
        else
        {
            Console.WriteLine($"It's okay, you can always do it some other time!       ");
            return false;
        }
    }

    public void DeleteNotification()
    {
        Console.SetCursorPosition(0, 27);
        Console.WriteLine("                                                                       ");
        Console.WriteLine("                                                                       ");
    }

    public void NotEnoughDust(int difrence)
    {
        Console.WriteLine($"You need {difrence} more dust to be able to craft this card (Press anything)");
    }


    public void UpdateOne(Card card, int index, int dust)
    {
        Console.SetCursorPosition(0, index);
        if (card.isOwned == false)
        {
            DisplayUnowned(card);
            
        }
        else
        {
            DisplayOwned(card);
        }
        Console.SetCursorPosition(6, 26);
        Console.Write("                ");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.SetCursorPosition(6, 26);
        Console.WriteLine(dust);
        Console.ResetColor();
    }
}



   






