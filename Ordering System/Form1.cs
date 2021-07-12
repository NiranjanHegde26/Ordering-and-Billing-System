using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ordering_System
{
    public partial class Form1 : Form
    {
        String operation;
        Double firstnum;
        Double secondnum;
        Double answer;

        Double gst = 5.0;

        int cheese_burger_quantity;
        int grilled_burger_quantity;
        int ham_burger_quantity;

        Double cheese_burger_price = 60.0;
        Double grilled_burger_price = 85.0;
        Double ham_burger_price = 125.0;

        Double cheese_burger_price = 60.0;
        Double grilled_burger_price = 85.0;
        Double ham_burger_price = 125.0;

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

            DateTime today = DateTime.Now;

            order_DateTextBox.Text = today.ToString("dd/MM/yy");
            order_TimeTextBox.Text = today.ToString("HH:mm:ss");

            unit_Price_1TextBox.Text = cheese_burger_price.ToString();
            unit_Price_2TextBox.Text = grilled_burger_price.ToString();
            unit_Price_3TextBox.Text = ham_burger_price.ToString();
            unit_Price_1TextBox.ReadOnly= true;
            unit_Price_2TextBox.ReadOnly = true;
            unit_Price_3TextBox.ReadOnly = true;

            qty1TextBox.Text = "0";
            qty2TextBox.Text = "0";
            qty3TextBox.Text = "0";

            sub_Total_1TextBox.Text = "0";
            sub_Total_2TextBox.Text = "0";
            sub_Total_3TextBox.Text = "0";

            net_Sub_TotalTextBox.Text = "0";
            net_TotalTextBox.Text = "0";
            gstTextBox.Text = "0";

        }

        private void OrderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.orderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.orderDataSet);
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

        
        private void Calc_Operators(object sender, EventArgs e)
        {
            Button ops = (Button)sender;
            firstnum = Double.Parse(lblDisplay.Text);
            lblDisplay.Text = "";
            operation = ops.Text;
            lblShowCal.Text = System.Convert.ToString(firstnum) + " " + operation;
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

        private void Reset_Click(object sender, EventArgs e)
        {
            customer_NameTextBox.Text = "";
            customer_PhoneTextBox.Text = "";
            order_Ref_NoTextBox.Text = "";

            unit_Price_1TextBox.Text = "60";
            unit_Price_2TextBox.Text = "85";
            unit_Price_3TextBox.Text = "125";

            qty1TextBox.Text = "0";
            qty2TextBox.Text = "0";
            qty3TextBox.Text = "0";

            sub_Total_1TextBox.Text = "0";
            sub_Total_2TextBox.Text = "0";
            sub_Total_3TextBox.Text = "0";

            net_Sub_TotalTextBox.Text = "0";
            net_TotalTextBox.Text = "0";
            gstTextBox.Text = "0";
        }
        
        private void Calc_Click(object sender, EventArgs e)
        {
            tabController.SelectedTab = tabPage1;
        }

        private void receiptGenerate(object sender, EventArgs e)
        {
            tabController.SelectedTab = tabPage2;
        }

        private void Order_Click(object sender, EventArgs e)
        {
            tabController.SelectedTab = tabPage3;
        }

        private void AddToCart(object sender, EventArgs e)
        {
            
            receiptBox.ReadOnly = true;

            receiptBox.AppendText("\t \t" + "Our Fast Food Chain Name" + "\t");
            receiptBox.AppendText("\t \t " + "===================================" + "\t" + Environment.NewLine);
            receiptBox.AppendText(" " + Environment.NewLine);

            receiptBox.AppendText("Name:" + customer_NameTextBox.Text + "\t" + "Ph.No:" + customer_PhoneTextBox.Text + "\t"  + "Ref No:" + order_Ref_NoTextBox.Text + Environment.NewLine);
            receiptBox.AppendText("Order Date:" + order_DateTextBox.Text + "\t" + "Time:" + order_TimeTextBox.Text + Environment.NewLine);

            receiptBox.AppendText(Environment.NewLine + "Item Type" + "\t" + "Quantity" + "\t" + "Unit Price" + "\t" + "Subtotal" + Environment.NewLine);
            if(cheese_burger_quantity > 0)
                receiptBox.AppendText(Environment.NewLine + "Cheese Burger" + "\t" + qty1TextBox.Text + "\t" + cheese_burger_price.ToString() + "\t" + sub_Total_1TextBox.Text + Environment.NewLine);
            if (grilled_burger_quantity > 0)
                receiptBox.AppendText(Environment.NewLine + "Grilled Burger" + "\t" + qty2TextBox.Text + "\t" + grilled_burger_price.ToString() + "\t" + sub_Total_2TextBox.Text + Environment.NewLine);
            if (ham_burger_quantity > 0)
                receiptBox.AppendText(Environment.NewLine + "Ham Burger" + "\t" + qty3TextBox.Text + "\t" + ham_burger_price.ToString() + "\t" + sub_Total_3TextBox.Text + Environment.NewLine);

            receiptBox.AppendText("\t \t " + "Order Sub Total:" + net_Sub_TotalTextBox.Text + "\t" + Environment.NewLine);
            receiptBox.AppendText("\t \t " + "GST:" + gstTextBox.Text + "\t" + Environment.NewLine);
            receiptBox.AppendText("\t \t " + "Total:" + net_TotalTextBox.Text + "\t" + Environment.NewLine);

            receiptBox.AppendText("\t \t " + "===================================" + "\t" + Environment.NewLine);

            string box_msg = "Successfully Added to Cart!";

            string box_title = "Cart Confirmation";

            MessageBox.Show(box_msg, box_title);
            
            history.ReadOnly = true;
            history.AppendText("TODAY'S SALES HISTORY.");
            history.AppendText("\t \t " + "===================================" + "\t" + Environment.NewLine);
            history.AppendText(" " + Environment.NewLine);
            history.AppendText("Cheese burger \t Grilled burger \t Ham burger \t Total amount ");
            history.AppendText(" " + Environment.NewLine);

            DateTime today = DateTime.Now;

            String currDate = today.ToString("dd/MM/yy");

            SqlConnection openCon = new SqlConnection();
            String filePath = "C:\\Users\\R Vishwas\\Desktop\\Ordering-and-Billing-System\\Ordering System\\Order.mdf"; // Add your DB File path here.
            String connectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + filePath + ";Integrated Security=True";
            openCon.ConnectionString = connectString;
            openCon.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT SUM(CAST(Qty1 AS int)), SUM(CAST(Qty2 AS int)), SUM(CAST(Qty3 AS int)), SUM(CAST(Net_Total AS decimal)) FROM [dbo].[ORDER] WHERE Order_Date=";
            sql = sql + string.Format("\'{0}\'", currDate) + ";";
            
            command = new SqlCommand(sql, openCon);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                history.AppendText("         " + dataReader.GetValue(0) + " \t \t" + "         " + dataReader.GetValue(1) + " \t \t" + "         " + dataReader.GetValue(2) + "\t \t" + "         " + dataReader.GetValue(3));
            }

        }

        private void saveOrderInfo(object sender, EventArgs e)
        {
            Console.WriteLine(qty1TextBox.Text);
            cheese_burger_quantity = int.Parse(qty1TextBox.Text);
            grilled_burger_quantity = int.Parse(qty2TextBox.Text);
            ham_burger_quantity = int.Parse(qty3TextBox.Text);
            
            this.Validate();
            this.orderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.orderDataSet);
        }

        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

            SqlConnection openCon = new SqlConnection();
            String filePath = "C:\\Users\\R Vishwas\\Desktop\\Ordering System\\Ordering System\\Order.mdf"; // Add your DB File path here.
            String connectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + filePath + ";Integrated Security=True";
            openCon.ConnectionString = connectString;
            openCon.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT TOP 1 Order_Ref_No FROM [dbo].[ORDER] ORDER BY Order_Ref_No DESC";
            command = new SqlCommand(sql, openCon);
            dataReader = command.ExecuteReader();

            while(dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0);
            }

            customer_NameTextBox.Text = "";
            customer_PhoneTextBox.Text = "";
            order_Ref_NoTextBox.Text = (int.Parse(Output)+1).ToString();
          
            customer_NameTextBox.Text = "";
            customer_PhoneTextBox.Text = "";
            order_Ref_NoTextBox.Text = "";
            
            unit_Price_1TextBox.Text = "60";
            unit_Price_2TextBox.Text = "85";
            unit_Price_3TextBox.Text = "125";

            qty1TextBox.Text = "0";
            qty2TextBox.Text = "0";
            qty3TextBox.Text = "0";

            sub_Total_1TextBox.Text = "0";
            sub_Total_2TextBox.Text = "0";
            sub_Total_3TextBox.Text = "0";

            net_Sub_TotalTextBox.Text = "0";
            net_TotalTextBox.Text = "0";
            gstTextBox.Text = "0";
            receiptBox.Text = "";

            DateTime today = DateTime.Now;

            order_DateTextBox.Text = today.ToString("dd/MM/yy");
            order_TimeTextBox.Text = today.ToString("HH:mm:ss");
        }

        private void orderTotal(object sender, EventArgs e)
        {
            int cheese_burger = int.Parse(qty1TextBox.Text);
            int grilled_burger = int.Parse(qty2TextBox.Text);
            int ham_burger = int.Parse(qty3TextBox.Text);

            sub_Total_1TextBox.Text = System.Convert.ToString(cheese_burger_price * cheese_burger);
            sub_Total_2TextBox.Text = System.Convert.ToString(grilled_burger_price * grilled_burger);
            sub_Total_3TextBox.Text = System.Convert.ToString(ham_burger_price * ham_burger);

            Double subTotal = Double.Parse(sub_Total_1TextBox.Text) + Double.Parse(sub_Total_2TextBox.Text) + Double.Parse(sub_Total_3TextBox.Text);
            net_Sub_TotalTextBox.Text = System.Convert.ToString(subTotal);

            Double gstAmount = (subTotal * gst) / 100.0;
            gstTextBox.Text = System.Convert.ToString(gstAmount);

            Double grandTotal = gstAmount + subTotal;
            
            net_TotalTextBox.Text = System.Convert.ToString(grandTotal);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            net_TotalTextBox.Text = System.Convert.ToString(grandTotal);
        }
    }
}
