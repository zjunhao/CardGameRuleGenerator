using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;


namespace CardGameRuleGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _ruleArray;
        private const string ruleFilePath = @"..\..\Resources\CardGameRules.txt";

        public MainWindow()
        {
            InitializeComponent();

            InitializeRuleArray();
        }

        private void InitializeRuleArray()
        {
            string text = System.IO.File.ReadAllText(ruleFilePath);
            _ruleArray = Regex.Split(text, @"--\s*\r\n").Where(s => s != String.Empty).ToArray<string>();
        }

        private void ShowResultButton_Click(object sender, RoutedEventArgs e)
        {
            if (_ruleArray == null || _ruleArray.Length == 0)
                return;

            Random rnd = new Random();
            int ruleIdx = rnd.Next(0, _ruleArray.Length);
            
            resultLabel.Text = _ruleArray[ruleIdx];
        }


    }
}
