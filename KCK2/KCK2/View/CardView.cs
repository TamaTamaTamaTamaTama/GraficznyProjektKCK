using System;
using Spectre.Console;

    public class CardView
    {

        public void DisplayCard(Card card)
        {
            AnsiConsole.Write(new Markup($"[blue]{card.Cost}:[/]"));
            AnsiConsole.Write(new Markup($"[purple] {card.Attack}[/]"));
            Console.Write($"~[{card.Name}]~");

            if (card.CurrentHealth == card.MaxHealth)
            {
                AnsiConsole.Write(new Markup($"[green]{card.CurrentHealth}[/]"));

            }
            else
            {
                AnsiConsole.Write(new Markup($"[red]{card.CurrentHealth}[/]"));
            }
            Console.WriteLine($"#{card.ID}");

            Console.WriteLine();
        }


    }










