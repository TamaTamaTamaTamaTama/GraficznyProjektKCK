using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MenuView
{
    public void DisplayMenu(List<string> options)
    {
        Console.Clear();
        int bottomLine = Console.CursorTop;
        Console.SetCursorPosition(0,0);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine($"{options[0]}");
        Console.ResetColor();
        for (int i = 1; i < options.Count; i++) 
            {
              Console.WriteLine(options[i]);
            }
    }


    public string GetUserInput()
    {
        var key = Console.ReadKey(true);

        return key.Key.ToString().ToLower();
    }

    public void AdjustSelection(int selected, int prev, string x, string y)
    {
        int bottomLine = Console.CursorTop;
        Console.SetCursorPosition(0, selected);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine($"{x}");
        Console.SetCursorPosition(0, prev);
        Console.ResetColor();
        Console.WriteLine($"{y}");
        Console.SetCursorPosition(0, bottomLine);
    }

    public void Warn()
    {
        Console.WriteLine("Do you want to save your progress before quitting?");
        Console.WriteLine("(Y/n)");
    }

    public void ExtraWarn()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You started a new save, if you save now old data will be lost. Press N to keep old save");
        Console.WriteLine("(y/N)");
        Console.ResetColor ();
    }


    public void animation(List<string> messages)
    {
        Console.Clear();
        for (int i = 0; i < messages.Count; i++)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"{messages[i]}");
            Console.Beep();
        }
        Thread.Sleep(2500);
    }

}