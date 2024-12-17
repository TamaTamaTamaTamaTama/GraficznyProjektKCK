using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Card
{
    private static int index = -1;
    public int ID { get; set; }
    public string Name { get; set; }
    public int Attack { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int Cost { get; set; }
    public bool isOwned { get; set; } = false;
    public int DustCraft { get; set; } = 1200;
    public int DustDisenchant { get; set; } = 600;



    public Card(string name, int attack, int health, int cost, bool isowned, int dustcraft, int dustdisenchant)
    {
        ID = ++index;
        Name = name;
        Cost = cost;
        Attack = attack;
        MaxHealth = health;
        CurrentHealth = health;
        isOwned = isowned;
        DustDisenchant = dustdisenchant;
        DustCraft = dustcraft;
      
    }

    public static void ResetID()
    {
        index = -1;
    }

    public int Disenchant(Card card)
    {
        card.isOwned = false;
        return card.DustDisenchant;
    }

    public int Craft(Card card)
    {
        card.isOwned = true;
        return card.DustCraft;

    }

  

    public override string ToString()
    {
        return $"{Name},{Attack},{MaxHealth},{Cost},{isOwned},{DustCraft},{DustDisenchant}";
    }


    public static Card FromString(string line)
    {
        try
        {
            var parts = line.Split(',');
            if (parts.Length != 7)
            {
                throw new FormatException("Invalid card format.");
            }
           
            string name = parts[0];
            int attack = int.Parse(parts[1]);
            int maxHealth = int.Parse(parts[2]);
            int cost = int.Parse(parts[3]);
            if(cost > 10)
            {
                cost = 10;
            }
            if(cost < 0)
            {
                cost = 0;
            }
            bool isOwned = bool.Parse(parts[4]);
            int dustcraft = int.Parse(parts[5]);
            int dustdisenchant = int.Parse(parts[6]);

           
                var card = new Card(name, attack, maxHealth, cost, isOwned, dustcraft, dustdisenchant)
                {

                    ID = index,
                    Name = name,
                    Cost = cost,
                    Attack = attack,
                    MaxHealth = maxHealth,
                    CurrentHealth = maxHealth,
                    DustCraft = dustcraft,
                    DustDisenchant = dustdisenchant,
                    isOwned = isOwned

                    
                };
                
                return card;
            
            
            
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error parsing card from string: {ex.Message}", ex);
        }

    } 
}

