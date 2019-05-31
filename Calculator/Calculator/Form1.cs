using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }
        enum Operator{Add,Substract,Multiply,Division}
        Operator operate = Operator.Add;
        int phase = 0;
        decimal no1 = 0, no2 = 0;
        private void numberButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            resultLabel.Text += button.Tag.ToString();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            resultLabel.Text = " ";
        }

        private void operator_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            switch (button.Tag)
            {
                case "0":
                    operate = Operator.Add;
                    break;
                case "1":
                    operate = Operator.Substract;
                    break;
                case "2":
                    operate = Operator.Multiply;
                    break;
                case "3":
                    operate = Operator.Division;
                    break;
            }
            decimal.TryParse(resultLabel.Text, out no1);
            resultLabel.Text = " ";
            phase = 1;
        }

        private void result_Click(object sender, EventArgs e)
        {
            decimal.TryParse(resultLabel.Text, out no2);
            switch (operate)
            {
                case Operator.Add:
                    no1 = no1 + no2;
                    break;
                case Operator.Substract:
                    no1 = no1 - no2;
                    break;
                case Operator.Multiply:
                    no1 = no1 * no2;
                    break;
                case Operator.Division:
                    try
                    {
                        no1 = no1 / no2;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
            resultLabel.Text = no1.ToString();
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            no1 = 0;
            no2 = 0;
            resultLabel.Text = " ";
        }
    }
}
