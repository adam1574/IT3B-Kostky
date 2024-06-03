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
using System.IO;
using Microsoft.Win32;

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
                dice[i] = new Die(i * 70 + 10, 10, 60);
            }
            DrawDice();
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            foreach (var die in dice)
            {
                die.Roll();
            }
            DrawDice();
            UpdateHistory();
        }

        private void SaveHistory_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, HistoryTextBox.Text);
            }
        }

        private void DrawDice()
        {
            DiceCanvas.Children.Clear();
            foreach (var die in dice)
            {
                foreach (var element in die.GetDrawingElements())
                {
                    if (element != null)
                    {
                        DiceCanvas.Children.Add(element);
                    }
                }
            }
        }

        private void UpdateHistory()
        {
            string rollResult = "Roll: ";
            foreach (var die in dice)
            {
                rollResult += die.Value + " ";
            }
            HistoryTextBox.Text += rollResult.Trim() + "\n";
            HistoryTextBox.ScrollToEnd();
        }
    }
}
