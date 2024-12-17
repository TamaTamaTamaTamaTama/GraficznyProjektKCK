using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class CollectionModel
{
    public List<Card> MyCollection { get; set; }
    public List<string> SortingOptions { get; set; } = new List<string>
    {
       "0. Sorting alphabetically",
       "1. Sorting by ID",
       "2. Sorting alphabetically backwards",
       "3. Sorting by cost, lowest to highest",
       "4. Sorting by cost, highest to lowest",
       "5. Sorting by dust cost, cheapest to craft",
       "6. Sorting by dust cost, most expensive discards",
       "7. Sorting to show the cards you don't own first",
        "8. Sorting to show the cards you do own first", 
       "0. Sorting alphabetically"

    };
    public List<string> MyCollectionOptions { get; set; } = new List<string>
    {
       "S: Sort |",
       "Q: Quit |",
        "<-: Previous Page |",
        "->: Next Page |",
        "Down: Next Card |",
        "Up: Previous Card |"
    };


    public CollectionModel()
    {
        MyCollection = new List<Card>();
        
        
    }


    public void LoadFromFile(string fileName)
    {
        MyCollection.Clear();
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"File not found: {fileName}");
        }
       
            string[] lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                var card = Card.FromString(line);
                MyCollection.Add(card);
               
            }
    }

    public void SaveToFile(string fileName)
    {   var lines = MyCollection.Select(card => card.ToString()).ToList();
        File.WriteAllLines(fileName, lines);
        
        Console.WriteLine($"Collection saved to {fileName}");

    }

    public int SortCollection(int TypeSort)
    {
        switch (TypeSort)
        {
            case 0:
                MyCollection = MyCollection
                        .OrderBy(card => card.Name, StringComparer.OrdinalIgnoreCase)
                        .ToList();
                TypeSort++;
                return TypeSort;
                
            case 1:
                MyCollection = MyCollection
                        .OrderBy(card => card.ID)
                        .ToList();
                TypeSort++;
                return TypeSort;
                
            case 2:
                MyCollection = MyCollection
                        .OrderByDescending(card => card.Name, StringComparer.OrdinalIgnoreCase)
                        .ToList();
                TypeSort++;
                return TypeSort;
                
            case 3:
                MyCollection = MyCollection
                        .OrderBy(card => card.Cost)
                        .ToList();
                TypeSort++;
                return TypeSort;
               
            case 4:
                MyCollection = MyCollection
                        .OrderByDescending(card => card.Cost)
                        .ToList();
                TypeSort++;
                return TypeSort;
                
            case 5:
                MyCollection = MyCollection
                        .OrderBy(card => card.DustCraft)
                        .ToList();
                TypeSort++;
                return TypeSort;
               
            case 6:
                MyCollection = MyCollection
                        .OrderByDescending(card => card.DustDisenchant)
                        .ToList();
                TypeSort++;
                return TypeSort;
               
            case 7:
                MyCollection = MyCollection
                        .OrderBy(card => card.isOwned).ThenBy(card => card.ID)
                        .ToList();
                TypeSort++;
                return TypeSort;
               
            case 8:
                MyCollection = MyCollection
                        .OrderByDescending(card => card.isOwned).ThenBy(card => card.ID)
                        .ToList();
                TypeSort++;
                return TypeSort;
                
            case 9:
                MyCollection = MyCollection
                    .OrderBy(card => card.Name, StringComparer.OrdinalIgnoreCase)
                    .ToList();
                TypeSort = 1;
                return TypeSort;
              
        }
        return TypeSort;

    }

}

