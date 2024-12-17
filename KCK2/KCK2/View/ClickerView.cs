using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class ClickerView
    {
    public void DisplayClickCount(int AccLevel, int Coins, int NextLevelReq, int CurrentProgress, int gain)
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"You are level: {AccLevel}");
        Console.WriteLine($"Your coins: {Coins}");
        Console.WriteLine($"{CurrentProgress}/{NextLevelReq}");
        Console.WriteLine("Press Enter to click, or 'q' to quit.");
    }

    public void UpdateClick(int coins, int CurrentProgress, int NextLevelReq)
    {
        int bottomLine = Console.CursorTop;
        Console.SetCursorPosition(12, 1);
        Console.WriteLine($"{coins} ");

        Console.SetCursorPosition(0, 2);
        Console.WriteLine($"{CurrentProgress}/{NextLevelReq}");

        Console.SetCursorPosition(0, bottomLine);
    }

    public void NotifyLevelUp(int accLevel, int gain)
    {
        int bottomLine = Console.CursorTop;
        Console.SetCursorPosition(15, 0);
        Console.Write($"{accLevel}");
        Console.SetCursorPosition(0, bottomLine);
      
    }


    public void animation(List<string> messages, int startframe, int endframe)
    {
        
        for (int i = startframe; i<= endframe; i++)
        {
            Console.SetCursorPosition(0, 4);
            Thread.Sleep(500);
            Console.SetCursorPosition(0, 5);
            Console.WriteLine($"{messages[messages.Count - 1]}");
            Console.SetCursorPosition(0, 5);
            Console.WriteLine($"{messages[i]}");
            Console.Beep();
            Thread.Sleep(500);
        }
        Console.SetCursorPosition(0, 5);
        Console.WriteLine($"{messages[messages.Count-1]}");


    }

    public string GetUserInput()
    {
        var key = Console.ReadKey(true);
        
        return key.Key.ToString();  
    }


}
