using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShopModel
{

    public int price { get; set; } = 100;
    public int bundle { get; set; } = 5;
   

    public string Offer()
    {
        string x = $"Cena: {price}, ilość kart w paczce: {bundle}";
        return x;
    }




}