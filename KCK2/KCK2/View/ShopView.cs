using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ShopView
{
    public void OpenUp(int x, int y, int z)
    {
 
        
            Console.Clear();

            int consoleWidth = Console.WindowWidth;


            string goldText = $"Your coins: {z}";
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(goldText.PadRight(consoleWidth - 1));


            string buyPackText = "Press ENTER to buy a pack, press Q to go back to the menu";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(buyPackText.PadRight(consoleWidth - 1));


            string packText = $"One pack costs: {x}, grants {y} cards";
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(packText.PadRight(consoleWidth - 1));


            Console.ResetColor();
        
    }

    public void ShowDrop(Card card)
    {
        
        Console.WriteLine($"{card.ID}: {card.Name}");
   
    }

    public void ShowCardsPopUp(List<Card> cards, int duplicatedDust, int duplicatesCount, int maxCards)
    {
        int cardWidth = 20;  
        int cardHeight = 7; 
        int gapWidth = 3;   
        int uiLines = 6;     
        

        Console.WriteLine($"\nOpening your pack...You got {duplicatedDust} Dust because you opened {duplicatesCount} duplicates\n");

      
      

    
        for (int row = 0; row < cardHeight; row++)
        {
            for (int i = 0; i < maxCards; i++) 
            {
                if (i < cards.Count) 
                {
                    var card = cards[i];

                  
                    if (row == 0 || row == cardHeight - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"|{new string(' ', cardWidth - 2)}|");
                        Console.ResetColor();
                    }
                    else
                    {
                      
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"|{new string(' ', cardWidth - 2)}|");
                        Console.ResetColor();
                    }
                }
                else
                {
                 
                    Console.BackgroundColor = ConsoleColor.Black; 
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"|{new string(' ', cardWidth - 2)}|");
                    Console.ResetColor();
                }

               
                if (i != maxCards - 1)
                {
                    Console.Write(new string(' ', gapWidth));
                }
            }
            Console.SetCursorPosition(0, Console.CursorTop + 1); 
        }

      
        for (int i = 0; i < maxCards; i++)
        {
            if (i < cards.Count)
            {
                var card = cards[i];

              
                Console.SetCursorPosition(gapWidth + i * (cardWidth + gapWidth) - 2, uiLines); 
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Mana: {card.Cost}");
                Console.ResetColor();

                Console.SetCursorPosition(gapWidth + i * (cardWidth + gapWidth)-1, uiLines+3);
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"{card.Name}");
                Console.ResetColor();


             
                Console.SetCursorPosition(cardWidth - 7 + (i * (cardWidth + gapWidth) + 4), uiLines);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"#{card.ID}");
                Console.ResetColor();

              
                Console.SetCursorPosition(gapWidth + i * (cardWidth + gapWidth) - 3, uiLines + cardHeight - 1); 
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Attack: {card.Attack}");
                Console.ResetColor();

               
                Console.SetCursorPosition(cardWidth - 7 + (i * (cardWidth + gapWidth)), uiLines + cardHeight - 1); 
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Health: {card.MaxHealth}");
                Console.ResetColor();
            }
            else
            {
            
                Console.SetCursorPosition(gapWidth + i * (cardWidth + gapWidth) - 2, uiLines);
                Console.BackgroundColor = ConsoleColor.Black;  
                Console.Write(new string(' ', cardWidth - 2)); 

                Console.SetCursorPosition(cardWidth - 7 + (i * (cardWidth + gapWidth) + 4), uiLines);
                Console.Write(new string(' ', 6));  

                Console.SetCursorPosition(gapWidth + i * (cardWidth + gapWidth) - 3, uiLines + cardHeight - 1);
                Console.Write(new string(' ', 8));  

                Console.SetCursorPosition(cardWidth - 7 + (i * (cardWidth + gapWidth)), uiLines + cardHeight - 1);
                Console.Write(new string(' ', 8)); 
            }
        }
    }










    public string GetUserInput()
    {
        var key = Console.ReadKey(true);

        return key.Key.ToString().ToLower();
    }

    public void NotEnoughCoins(int coins)
    {
        Console.SetCursorPosition(0, 3);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"You need {coins} more coins to buy this pack, you should go click more coins in option 1 of the menu!");
        Console.ResetColor();
        
    }



    public void UpdateCoins(int x)
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.SetCursorPosition(11, 0);
        Console.WriteLine($"{x}               ");
        Console.ResetColor();

    }

    public void DuplicateNotification(Card card)
    {
        Console.WriteLine($"You already own this card! +{card.DustDisenchant} dust");
    }

   

}