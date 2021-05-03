using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering_System
{
    public partial class Form1 : Form
    {
        String operation;
        Double firstnum;
        Double secondnum;
        Double answer;

        Double gst = 5.0;

        Double cheese_burger;
        Double grilled_burger;
        Double ham_burger;
        Double main_currency;

        Double US_Dollar = 0.0135;
        Double British_Pound = 0.0097;
        Double Euro = 0.0112;
        Double Chinese_Yuan = 0.0872;
        Double Riyal = 0.0505;
        Double Yen = 1.4760;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'orderDataSet.Order' table. You can move, or remove it, as needed.
            comboBox1.Text = "Choose One";
            comboBox1.Items.Add("US Dollars (USA)");
            comboBox1.Items.Add("British Pounds (UK)");
            comboBox1.Items.Add("Euro (EU)");
            comboBox1.Items.Add("Chinese Yuan (China)");
            comboBox1.Items.Add("Riyal (Saudi Arabia)");
            comboBox1.Items.Add("Yen (Japan)");
            this.orderTableAdapter.Fill(this.orderDataSet.Order);

        }


        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {

        }

        private void Button4_Click_1(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void Button23_Click(object sender, EventArgs e)
        {

        }

        private void Button22_Click(object sender, EventArgs e)
        {

        }

        private void Button26_Click(object sender, EventArgs e)
        {

        }

        private void Button25_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        

        private void OrderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.orderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.orderDataSet);
        }

        private void OrderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void Order_Ref_NoLabel_Click(object sender, EventArgs e)
        {

        }

        private void Order_Ref_NoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customer_NameLabel_Click(object sender, EventArgs e)
        {

        }

        private void Customer_NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customer_PhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customer_PhoneLabel_Click(object sender, EventArgs e)
        {

        }

        private void Order_DateLabel_Click(object sender, EventArgs e)
        {

        }

        private void Order_DateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Order_TimeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Order_TimeLabel_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Unit_Price_2Label_Click(object sender, EventArgs e)
        {

        }

        private void Unit_Price_2TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Qty2Label_Click(object sender, EventArgs e)
        {

        }

        private void Qty2TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Unit_Price_2TextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Sub_Total_3TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Net_Sub_TotalTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Net_Sub_TotalLabel_Click(object sender, EventArgs e)
        {

        }

        private void GSTTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void GSTLabel_Click(object sender, EventArgs e)
        {

        }

        private void Net_TotalTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            Console.WriteLine(num.Text);
            if (lblDisplay.Text == "0")
               lblDisplay.Text = num.Text;
            else
               lblDisplay.Text += num.Text;
        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Calc_Operators(object sender, EventArgs e)
        {
            Button ops = (Button)sender;
            firstnum = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "";
            operation = ops.Text;
            lblShowCal.Text = System.Convert.ToString(firstnum) + " " + operation;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void getResult(object sender, EventArgs e)
        {
            lblShowCal.Text = "";
            secondnum = Double.Parse(lblDisplay.Text);
            switch (operation)
            {
                case "+":
                    answer = firstnum + secondnum;
                    lblDisplay.Text = System.Convert.ToString(answer);
                    break;

                case "*":
                    answer = firstnum * secondnum;
                    lblDisplay.Text = System.Convert.ToString(answer);
                    break;

                case "-":
                    answer = firstnum - secondnum;
                    lblDisplay.Text = System.Convert.ToString(answer);
                    break;

                case "/":
                    answer = firstnum / secondnum;
                    lblDisplay.Text = System.Convert.ToString(answer);
                    break;

                default: break;
            }
        }

        private void backspace(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 0)
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);
            if (lblDisplay.Text.Length == 0)
                lblDisplay.Text = "0";

        }

        private void dotButton(object sender, EventArgs e)
        {
            Button dot = (Button)sender;
            if(dot.Text == ".")
            {
                if (!lblDisplay.Text.Contains("."))
                {
                    lblDisplay.Text += dot.Text;
                }
            }
        }

        private void clear(object sender, EventArgs e)
        {
            Button cls = (Button)sender;
            Console.WriteLine(cls);
            if (cls.Text == "C")
                lblDisplay.Text = "0";
        }

        private void Button17_Click(object sender, EventArgs e)
        {

        }

        private void Button27_Click(object sender, EventArgs e)
        {

        }

        private void converterCurrency(object sender, EventArgs e)
        {
            textBox2.Text = "";
            main_currency = Double.Parse(textBox1.Text);
            switch (comboBox1.Text)
            {
                
                case "US Dollars (USA)":
                    textBox2.Text = System.Convert.ToString(main_currency * US_Dollar);
                    break;

                case "British Pounds (UK)":
                    textBox2.Text = System.Convert.ToString(main_currency * British_Pound);
                    break;

                case "Euro (EU)":
                    textBox2.Text = System.Convert.ToString(main_currency * Euro);
                    break;

                case "Chinese Yuan (China)":
                    textBox2.Text = System.Convert.ToString(main_currency * Chinese_Yuan);
                    break;

                case "Riyal (Saudi Arabia)":
                    textBox2.Text = System.Convert.ToString(main_currency * Riyal);
                    break;

                case "Yen (Japan)":
                    textBox2.Text = System.Convert.ToString(main_currency * Yen);
                    break;
                default: break;
                 
            }
        }
        
        private void convertFrom(object sender, KeyPressEventArgs e)
        {
            
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        
            
        }

        private void Clear_Converter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "Choose One";
        }
    }
}
