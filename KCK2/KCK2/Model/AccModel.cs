using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AccModel
{
    public int AccLevel { get; set; } = 1;
    public int Coins { get; set; } = 0;
    public int NextLevelReq { get; set; } = 10;
    public int CurrentProgress { get; set; } = 0;
    public int gain { get; set; } = 1;
    public int dust { get; set; } = 0;

    public bool IsLevelUp { get; set; } = false;


    public string ToSaveString()
    {
        return $"{AccLevel},{Coins},{NextLevelReq},{CurrentProgress},{gain},{dust}";
    }

    public void FromSaveString(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException($"File not found: {fileName}");
        }

            string line = File.ReadLines(fileName).First();

            
            if (line.Length > 0)
            {
                var parts = line.Split(',');

                if (parts.Length == 6)
                {
                    AccLevel = int.Parse(parts[0]);
                    Coins = int.Parse(parts[1]);
                    NextLevelReq = int.Parse(parts[2]);
                    CurrentProgress = int.Parse(parts[3]);
                    gain = int.Parse(parts[4]);
                    dust = int.Parse(parts[5]);

                    Console.WriteLine("Account data loaded successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid save data format.");
                }
            }
            else
            {
                Console.WriteLine("Save file is empty.");
            }
        }
    
    public void SaveToFile(string fileName, string x)
    {
        File.WriteAllText(fileName, x);

        Console.WriteLine($"Account saved to {fileName}");
    }

    public void ClickCount()
    {
        CurrentProgress++;
        Coins = Coins + gain;
        

        if (CurrentProgress >= NextLevelReq)
        {
            LevelUp();
            IsLevelUp = true;
        }
        else
        {
            IsLevelUp = false;
        }
    }

    public void LevelUp()
    {
        NextLevelReq = (int)(NextLevelReq * 1.7);
        gain += (int)(gain * 1.5);
        dust = dust + 200;
        AccLevel++;
        if (AccLevel % 5 == 0)
        {
            Coins = Coins + 20;
            dust = dust + 200;
        }
       
    }


    public string GetProgressInfo()
    {
        return $"Level: {AccLevel}, Coins: {Coins}, Progress: {CurrentProgress}/{NextLevelReq}, Gain: {gain}";
    }

    public static List<string> MyArt = new List<string>
    {

        @"


 __                                      __                            __  __  __ 
/  |                                    /  |                          /  |/  |/  |
$$ |        ______   __     __  ______  $$ |       __    __   ______  $$ |$$ |$$ |
$$ |       /      \ /  \   /  |/      \ $$ |      /  |  /  | /      \ $$ |$$ |$$ |
$$ |      /$$$$$$  |$$  \ /$$//$$$$$$  |$$ |      $$ |  $$ |/$$$$$$  |$$ |$$ |$$ |
$$ |      $$    $$ | $$  /$$/ $$    $$ |$$ |      $$ |  $$ |$$ |  $$ |$$/ $$/ $$/ 
$$ |_____ $$$$$$$$/   $$ $$/  $$$$$$$$/ $$ |      $$ \__$$ |$$ |__$$ | __  __  __ 
$$       |$$       |   $$$/   $$       |$$ |      $$    $$/ $$    $$/ /  |/  |/  |
$$$$$$$$/  $$$$$$$/     $/     $$$$$$$/ $$/        $$$$$$/  $$$$$$$/  $$/ $$/ $$/ 
                                                            $$ |                  
                                                            $$ |                  
                                                            $$/                   

        ",



        @"

           _______    ______   __    __                            __                      __ 
    __    /       |  /      \ /  |  /  |                          /  |                    /  |
   /  |   $$$$$$$/  /$$$$$$  |$$/  /$$/         _______   ______  $$/  _______    _______ $$ |
 __$$ |__ $$ |____  $$$  \$$ |    /$$/         /       | /      \ /  |/       \  /       |$$ |
/  $$    |$$      \ $$$$  $$ |   /$$/         /$$$$$$$/ /$$$$$$  |$$ |$$$$$$$  |/$$$$$$$/ $$ |
$$$$$$$$/ $$$$$$$  |$$ $$ $$ |  /$$/          $$ |      $$ |  $$ |$$ |$$ |  $$ |$$      \ $$/ 
   $$ |   /  \__$$ |$$ \$$$$ | /$$/  __       $$ \_____ $$ \__$$ |$$ |$$ |  $$ | $$$$$$  | __ 
   $$/    $$    $$/ $$   $$$/ /$$/  /  |      $$       |$$    $$/ $$ |$$ |  $$ |/     $$/ /  |
           $$$$$$/   $$$$$$/  $$/   $$/        $$$$$$$/  $$$$$$/  $$/ $$/   $$/ $$$$$$$/  $$/ 
                                                                                                     
                                                                                                     
                                                                                                     
                                                                                                                                                                      
        ",




        @"
  _______                                           __  __  __ 
/       \                                         /  |/  |/  |
$$$$$$$  |  ______   _______   __    __   _______ $$ |$$ |$$ |
$$ |__$$ | /      \ /       \ /  |  /  | /       |$$ |$$ |$$ |
$$    $$< /$$$$$$  |$$$$$$$  |$$ |  $$ |/$$$$$$$/ $$ |$$ |$$ |
$$$$$$$  |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$      \ $$/ $$/ $$/ 
$$ |__$$ |$$ \__$$ |$$ |  $$ |$$ \__$$ | $$$$$$  | __  __  __ 
$$    $$/ $$    $$/ $$ |  $$ |$$    $$/ /     $$/ /  |/  |/  |
$$$$$$$/   $$$$$$/  $$/   $$/  $$$$$$/  $$$$$$$/  $$/ $$/ $$/ 
                                                              
                                                                                                            
        ",
          @"

           ______    ______                             __                     
    __    /      \  /      \                           /  |                    
   /  |  /$$$$$$  |/$$$$$$  |        _______   ______  $$/  _______    _______ 
 __$$ |__$$____$$ |$$$  \$$ |       /       | /      \ /  |/       \  /       |
/  $$    |/    $$/ $$$$  $$ |      /$$$$$$$/ /$$$$$$  |$$ |$$$$$$$  |/$$$$$$$/ 
$$$$$$$$//$$$$$$/  $$ $$ $$ |      $$ |      $$ |  $$ |$$ |$$ |  $$ |$$      \ 
   $$ |  $$ |_____ $$ \$$$$ |      $$ \_____ $$ \__$$ |$$ |$$ |  $$ | $$$$$$  |
   $$/   $$       |$$   $$$/       $$       |$$    $$/ $$ |$$ |  $$ |/     $$/ 
         $$$$$$$$/  $$$$$$/         $$$$$$$/  $$$$$$/  $$/ $$/   $$/ $$$$$$$/  
                                                                                                                                                                                                                              
        ",
        @"

           ______    ______    ______               __                        __     
    __    /      \  /      \  /      \             /  |                      /  |    
   /  |  /$$$$$$  |/$$$$$$  |/$$$$$$  |        ____$$ | __    __   _______  _$$ |_   
 __$$ |__$$____$$ |$$$  \$$ |$$$  \$$ |       /    $$ |/  |  /  | /       |/ $$   |  
/  $$    |/    $$/ $$$$  $$ |$$$$  $$ |      /$$$$$$$ |$$ |  $$ |/$$$$$$$/ $$$$$$/   
$$$$$$$$//$$$$$$/  $$ $$ $$ |$$ $$ $$ |      $$ |  $$ |$$ |  $$ |$$      \   $$ | __ 
   $$ |  $$ |_____ $$ \$$$$ |$$ \$$$$ |      $$ \__$$ |$$ \__$$ | $$$$$$  |  $$ |/  |
   $$/   $$       |$$   $$$/ $$   $$$/       $$    $$ |$$    $$/ /     $$/   $$  $$/ 
         $$$$$$$$/  $$$$$$/   $$$$$$/         $$$$$$$/  $$$$$$/  $$$$$$$/     $$$$/  
                                                                                     
        ",

    @" 
                                                                                                       
                                                                                                     
                                                                                                     
                                                                                                     
                                                                                                     
                                                                                                     
                                                                                                     
                                                                                                     
                                                                                                     
                                                                                                     
                                                                                                         
                                                                                                              
                                                                                                     
                                                                                                     
                                                                                                     
    ",
    };



}
