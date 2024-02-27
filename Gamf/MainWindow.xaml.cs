using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gamf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<long> numberList = new();
        public MainWindow()
        {
            
            InitializeComponent();
            ReadNumberTxtFile();
            
        }

        public void ReadNumberTxtFile()
        {
            StreamReader sr = new("szamok.txt");
            while (!sr.EndOfStream)
            {
                numberList.Add(long.Parse(sr.ReadLine()));
            //return numberList.Count(x => IsRealativePrimeNumbers(x, 1310438493) == 1);
            }
        }

        //public int CountRelativePrimes()
        //{
        //    int count = 0;
        //    foreach (long number in numberList)
        //    {
        //        if (IsRealativePrimeNumbers(number, 1310438493) == 1)
        //        {
        //            count++;
        //        }
        //    }
        //    return count;
        //}

        //public long IsRealativePrimeNumbers(long firstNumber, long secondNumber)
        //{
        //    while(secondNumber != 0)
        //    {
        //        long temp = secondNumber;
        //        secondNumber = firstNumber % secondNumber;
        //        firstNumber = temp;
        //    }
        //    return firstNumber;
        //}

        public int CountRelativePrimes()
        {
            int count = 0;
            foreach (long number in numberList)
            {
                long secondNumber = 1310438493;
                long firstNumber = number;
                while (secondNumber != 0)
                {
                    long temp = secondNumber;
                    secondNumber = firstNumber % secondNumber;
                    firstNumber = temp;
                    if (firstNumber == 1)
                    {
                        count++;
                    }
                }
                
            }
            return count;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ora = Stopwatch.StartNew();
            firstLabel.Content = $"{CountRelativePrimes()}";
            ora.Stop();
            timeLabel.Content = $"{ora.Elapsed}";
        }
    }
}
