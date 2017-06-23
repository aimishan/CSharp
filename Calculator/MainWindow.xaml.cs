using System;
using System.Collections.Generic;
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

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string oprand1, oprand2;
        public char oprator;
        public bool isInputFirstParaMode, sndParaHasVal;
        public string latestAnswer;
        public MainWindow()
        {
            InitializeComponent();
            oprator = ' ';
            oprand1 = "0";
            oprand2 = "";
            latestAnswer = "";
            isInputFirstParaMode = true;
            sndParaHasVal = false;
        }

        private void calculate(string op1, string op2, char oprand)
        {
            double op1_D = Convert.ToDouble(op1), op2_D = Convert.ToDouble(op2), result = 0;
            switch (oprand)
            {
                case '+':
                    result = op1_D + op2_D;
                    break;
                case '-':
                    result = op1_D - op2_D;
                    break;
                case '*':
                    result = op1_D * op2_D;
                    break;
                case '/':
                    {
                        if(op2_D != 0)
                            result = op1_D / op2_D;
                        else
                        {
                            item.Content = "Error : Cannot divided by 0";
                            oprand1 = "0";
                            oprand2 = "";
                            oprator = ' ';
                        }
                            
                        break;
                    }
                case '^':
                    result = Math.Pow(op1_D, op2_D);
                    break;
            }
            oprand1 = result.ToString();
            sndParaHasVal = false;
            latestAnswer = oprand1;
            item.Content = oprand1;
        }

        private void calControl(string character)
        {
            if (isInputFirstParaMode)
            {
                if (oprand1[0] == '0')
                    oprand1 = character;
                else
                    oprand1 += character;
                item.Content = oprand1;
            }
            else
            {
                sndParaHasVal = true;
                oprand2 += character;
                item.Content += oprand2;
            }
        }

        private void calWhenSndParaHasVal()
        {
            if (sndParaHasVal)
            {
                buttonEq_Click(new object(), new RoutedEventArgs());
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            calControl("1");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            calControl("2");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            calControl("3");
        }

        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            calWhenSndParaHasVal();
            oprator = '+';
            isInputFirstParaMode = false;
            item.Content += oprator.ToString();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            calControl("4");
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            calControl("5");
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            calControl("6");
        }

        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            calWhenSndParaHasVal();
            oprator = '-';
            isInputFirstParaMode = false;
            item.Content += oprator.ToString();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            calControl("7");
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            calControl("8");
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            calControl("9");
        }

        private void buttonMul_Click(object sender, RoutedEventArgs e)
        {
            calWhenSndParaHasVal();
            oprator = '*';
            isInputFirstParaMode = false;
            item.Content += oprator.ToString();
        }

        private void buttonDot_Click(object sender, RoutedEventArgs e)
        {
            calControl(".");
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            calControl("0");
        }

        private void buttonEq_Click(object sender, RoutedEventArgs e)
        {
            isInputFirstParaMode = true;
            calculate(oprand1, oprand2, oprator);
            oprand2 = "";
            oprator = ' ';
        }

        private void buttonDIv_Click(object sender, RoutedEventArgs e)
        {
            calWhenSndParaHasVal();
            oprator = '/';
            isInputFirstParaMode = false;
            item.Content += oprator.ToString();
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            oprand1 = oprand2 = "";
            oprator = ' ';
            item.Content = "";
        }

        private void buttonLatestAnswer_Click(object sender, RoutedEventArgs e)
        {
            item.Content = latestAnswer;
        }

        private void buttonPercent_Click(object sender, RoutedEventArgs e)
        {
            oprand1 = Convert.ToString(Convert.ToDouble(oprand1) / 100);
            item.Content = oprand1;
        }

        private void buttonSquare_Click(object sender, RoutedEventArgs e)
        {
            oprand1 = Convert.ToString(Math.Sqrt(Convert.ToDouble(oprand1)));
            item.Content = oprand1;
        }

        private void buttonPower_Click(object sender, RoutedEventArgs e)
        {
            calWhenSndParaHasVal();
            oprator = '^';
            isInputFirstParaMode = false;
            item.Content += oprator.ToString();
        }

        private void buttonLn_Click(object sender, RoutedEventArgs e)
        {
            oprand1 = Convert.ToString(Math.Log(Convert.ToDouble(oprand1)));
            item.Content = oprand1;
        }

        private void buttonFib_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(oprand1);
            for (int i = n - 1; i > 0; i--)
                n *= i;
            oprand1 = n.ToString();
            item.Content = oprand1;
        }

        private void buttonUnknown_Click(object sender, RoutedEventArgs e)
        {
            item.Content = "I Love You";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            item.Content = "Code : Aimishan 2017-6-24 Version: 0.0.2";
        }

    }
}
