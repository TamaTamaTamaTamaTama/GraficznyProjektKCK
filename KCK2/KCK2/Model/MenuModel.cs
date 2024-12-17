using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MenuModel
{
    public List<string> Options { get; set; } = new List<string>
    {
       "1. Click",
       "2. Shop",
       "3. Collection",
       "4. Savedata",
       "5/q. Exit",
    
    };

    public int Selected { get; set; } = 0;
    public int SelectedPrev { get; set; } = -1;
    public bool didReboot { get; set; } = false;
    public bool wasPlayed { get; set; } = false;


    public static List<string> MyArt = new List<string>
    {
        @"
               _                             
              | |                         
 __      _____| | ___ ___  _ __ ___   ___ 
 \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \
  \ V  V /  __/ | (_| (_) | | | | | |  __/
   \_/\_/ \___|_|\___\___/|_| |_| |_|\___|
                                            
        ", 

        @"
   _        
 | |       
 | |_ ___  
 | __/ _ \ 
 | || (_) |
  \__\___/ 
                                               
        ",

        @"
    
   _____              _               _                 _                  
  / ____|            | |     /\      | |               | |                 
 | |     __ _ _ __ __| |    /  \   __| |_   _____ _ __ | |_ _   _ _ __ ___ 
 | |    / _` | '__/ _` |   / /\ \ / _` \ \ / / _ \ '_ \| __| | | | '__/ _ \
 | |___| (_| | | | (_| |  / ____ \ (_| |\ V /  __/ | | | |_| |_| | | |  __/
  \_____\__,_|_|  \__,_| /_/    \_\__,_| \_/ \___|_| |_|\__|\__,_|_|  \___|
                                                                           
        "
    };



}