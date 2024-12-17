
using KCK2.Viewpf;
using System.Windows;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;
public class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Console.CursorVisible = false;



 bool first = true;
      


            Console.Clear();
            Console.WriteLine("Choose the interface to run:");
            Console.WriteLine("1. Terminal Interface");
            Console.WriteLine("2. WPF Interface");
            Console.WriteLine("3. EXIT");


            string choice = "";
           
            while (choice != "1" && choice != "2")
            {
                choice = Console.ReadLine();

                if(choice == "3" )
                {
                   Environment.Exit(0);
                }
                if (choice == "1" || choice == "2")
                {

                    MenuModel model1 = new MenuModel();
                    MenuController controller1 = new MenuController(model1, choice);
                    if(first)
                    {
                      controller1.GetSave(1);
                        first = false;
                    }
                  
                    controller1.Boot();


                }
                else
                {
                    Console.WriteLine("Please provide adequete number");
                }
            }


        }


    }


