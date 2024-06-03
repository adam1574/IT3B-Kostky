using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;


namespace IT3B_Kostky
{
 /// <summary>
 /// Interaction logic for MainWindow.xaml
 /// </summary>
    public partial class MainWindow : Window
    {
        private Die[] dice;
        public MainWindow()
        {
            InitializeComponent();
            dice = new Die[6];
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = new Die(DiceCanvas, i * 70 + 10, 10, 60);
            }
        }
        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            foreach (var die in dice)
            {
                die.Roll();
            }
        }
    }
}
