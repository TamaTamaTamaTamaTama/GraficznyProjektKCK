using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KCK2.Viewpf
{

    

    public partial class Clicker : Window
    {   
        private readonly ClickerController clicker;
        int _AccLevel;
        int _Coins;
        int _NextLevelReq;
        int _CurrentProgress;
        int _Gain;

        public Clicker(int AccLevel, int Coins, int NextLevelReq, int CurrentProgress, int gain, ClickerController clickerController)
        {  
            InitializeComponent();


            LevelLabel.Content = $"Level: {AccLevel}";
            CoinsLabel.Content = $"Coins: {Coins}";
            ProgressLabel.Content = $"Clicks: {CurrentProgress}/{NextLevelReq}";
            _AccLevel = AccLevel;
            _Coins = Coins;
            _NextLevelReq = NextLevelReq;
            _CurrentProgress = CurrentProgress;

            _Gain = gain ;
            clicker = clickerController;
        }
        private void THEbutton_Click(object sender, RoutedEventArgs e)
        {
            clicker.mechanic("2");
            
        }

        public void Update(int AccLevel, int Coins, int NextLevelReq, int CurrentProgress, int gain)
        {

            LevelLabel.Content = $"Level: {AccLevel}";
            CoinsLabel.Content = $"Coins: {Coins}";
            ProgressLabel.Content = $"Clicks: {CurrentProgress}/{NextLevelReq}";
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            clicker.Exit();
        }


    }
}
