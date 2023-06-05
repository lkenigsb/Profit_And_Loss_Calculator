using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.Data.SqlTypes;
using System.Linq;

namespace FinanceTermProjectS23
{
    public partial class P_L_Calc : Form
    {
        Object tickerSelected;
        public P_L_Calc()
        {
            InitializeComponent();
            //call method to fill data
            //Cal method to fill ticker list box using select statement (selecting distinct tickers from tableName)
            fillTickerList();
            fillPositions();
        }

        private void fillTickerList()
        {
            SqlConnection sqlCon = null;  // connection to DB

            try
            {
                /* get database parameters from App.config file */
                String strServer = ConfigurationManager.AppSettings["server"];
                String strDatabase = ConfigurationManager.AppSettings["database"];

                /* open a connection to database */
                //  typical connection string:
                //      sqlCon = new SqlConnection("Server=DESKTOP-17VOE83;Database=Finance;Trusted_Connection=True;");
                String strConnect = $"Server={strServer};Database={strDatabase};Trusted_Connection=True;";
                SqlConnection con;
                using (con = new SqlConnection(strConnect))
                {
                    con.Open();
                    string query = "SELECT DISTINCT Ticker FROM Stock";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ticker_list.Items.Add(reader[0]);
                               
                            }
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        static DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ticker", typeof(String));
            return dt;
        }

        //create method to link sql server
        private void fillPositions()
        {
            SqlConnection sqlCon = null;  // connection to DB

            try
            {
                /* get database parameters from App.config file */
                String strServer = ConfigurationManager.AppSettings["server"];
                String strDatabase = ConfigurationManager.AppSettings["database"];

                /* open a connection to database */
                //  typical connection string:
                //      sqlCon = new SqlConnection("Server=DESKTOP-17VOE83;Database=Finance;Trusted_Connection=True;");
                String strConnect = $"Server={strServer};Database={strDatabase};Trusted_Connection=True;";
                SqlConnection sqlConnection = new SqlConnection(strConnect);

                sqlConnection.Open();

                SqlCommand cmd = null;

                cmd = new SqlCommand("GetAllStockInformation", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                
                   
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                da.Fill(dataset, "Positions");
                    
                Positions.DataSource = dataset.Tables["Positions"];

                Positions.AutoGenerateColumns = true;

                Positions.Columns["Ticker"].DefaultCellStyle.Format = "c";

                Positions.Columns["Shares"].DefaultCellStyle.Format = "#,###";

                Positions.Columns["Values"].DefaultCellStyle.Format = "#,###";

                Positions.AllowUserToAddRows = false;
            }

            catch (Exception ex)

            {
                MessageBox.Show(" " + DateTime.Now.ToLongTimeString() + "  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally

            {

                if (sqlCon != null && sqlCon.State == System.Data.ConnectionState.Open)

                    sqlCon.Close();

            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void P_L_Calc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'final_Project_S23DataSet.Stock' table. You can move, or remove it, as needed.
            this.stockTableAdapter.Fill(this.final_Project_S23DataSet.Stock);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tickerSelected = ticker_list.SelectedItem;

            SqlConnection sqlCon = null;  // connection to DB
            Double d = 0.0;

            try
            {
                /* get database parameters from App.config file */
                String strServer = ConfigurationManager.AppSettings["server"];
                String strDatabase = ConfigurationManager.AppSettings["database"];

                /* open a connection to database */
                //  typical connection string:
                //      sqlCon = new SqlConnection("Server=DESKTOP-17VOE83;Database=Finance;Trusted_Connection=True;");
                String strConnect = $"Server={strServer};Database={strDatabase};Trusted_Connection=True;";

                Object ogHedgePrice;

                using (SqlConnection con = new SqlConnection(strConnect))
                {
                    con.Open();
                    string query = "SELECT TOP (1) Closing_Price FROM Stock WHERE Ticker = '" + tickerSelected + "' ORDER BY Stock_Date DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ogHedgePrice = reader[0];
                                if (ogHedgePrice is IConvertible)
                                {
                                    d = ((IConvertible)ogHedgePrice).ToDouble(null);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            PriceTextBox.Clear();
            PriceTextBox.AppendText(d + "");

            //ImpliedChanges.Rows.Add(tickerSelected, "0000", "999");

            //ImpliedChanges.AutoGenerateColumns = true;

            //ImpliedChanges.Columns["Ticker"].DefaultCellStyle.Format = "c";

            //ImpliedChanges.Columns["Values"].DefaultCellStyle.Format = "#,###";

            //ImpliedChanges.Columns["Profit_Loss"].DefaultCellStyle.Format = "#,###";
            //ImpliedChanges.AllowUserToAddRows = false;
        }
         

        private void button1_Click(object sender, EventArgs e)
        {
            //Put the code to make calculations using Ticker + Price and give us implied changes
            //And manually add columns and rows to DGV (LOOK AT DGV documentation
            //https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview?view=windowsdesktop-7.0

            //double hedgeFromUser = 4100.00;
            double hedgeFromUser = Double.Parse(PriceTextBox.Text);

            //With 100 shares valued at 17257, a current hedge or 4136
            // now the user wants to know what will happen when the hedge drops to 4100 

            //GET LATEST CLOSING PRICE
            SqlConnection sqlCon = null;  // connection to DB
            Double d = 0.0;

            try
            {
                /* get database parameters from App.config file */
                String strServer = ConfigurationManager.AppSettings["server"];
                String strDatabase = ConfigurationManager.AppSettings["database"];

                /* open a connection to database */
                //  typical connection string:
                //      sqlCon = new SqlConnection("Server=DESKTOP-17VOE83;Database=Finance;Trusted_Connection=True;");
                String strConnect = $"Server={strServer};Database={strDatabase};Trusted_Connection=True;";

                Object ogHedgePrice;

                SqlConnection con = new SqlConnection(strConnect);
                
                con.Open();
                string query = "SELECT TOP (1) Closing_Price FROM Stock WHERE Ticker = '" + tickerSelected + "' ORDER BY Stock_Date DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ogHedgePrice = reader[0];
                            if (ogHedgePrice is IConvertible)
                            {
                                d = ((IConvertible)ogHedgePrice).ToDouble(null);
                            }
                        }
                    }
                }
                

                //STEP 1:  Δ𝐻 = 𝑛𝑒𝑤 ℎ𝑒𝑑𝑔𝑒 𝑝𝑟𝑖𝑐𝑒 ― 𝑜𝑟𝑖𝑔𝑖𝑛𝑎𝑙 ℎ𝑒𝑑𝑔𝑒 𝑝𝑟𝑖𝑐𝑒
                double hedgeDifference = hedgeFromUser - d;


                //STEP 2: δH = Relative Change in hedge price 𝛿𝐻 = 𝛥𝐻
                //      𝑜𝑟𝑖𝑔𝑖𝑛𝑎𝑙 ℎ𝑒𝑑𝑔𝑒 𝑝𝑟𝑖𝑐𝑒 
                double relativeChange = hedgeDifference / d;

                for (int i = 0; i < Positions.RowCount; i++)
                {
                    String strTicker = Positions.Rows[i].Cells[0].Value.ToString();

                    if (strTicker.CompareTo(tickerSelected) != 0)
                    {

                        /* set up a call to spGetPrcForSymbol stored procedure */
                        SqlCommand sqlCmd = new SqlCommand("spCalculateBeta1", con);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add("@Ticker1", System.Data.SqlDbType.VarChar).Value = tickerSelected;
                        sqlCmd.Parameters.Add("@Ticker2", System.Data.SqlDbType.VarChar).Value = strTicker;


                        string str = sqlCmd.ExecuteScalar().ToString();
                        float beta = (float)System.Convert.ToSingle(str);


                        //STEP 3: 𝛿𝑃 = 𝛿𝐻 ⋅ 𝛽 (𝑟𝑒𝑙𝑎𝑡𝑖𝑣𝑒 𝑐ℎ𝑎𝑛𝑔𝑒 𝑖𝑛 𝑡ℎ𝑒 𝑝𝑟𝑖𝑐𝑒 𝑜𝑓 𝑒𝑞𝑢𝑖𝑡𝑦)
                        //Suppose calculated 𝛽 = 1.244 - can we use this?
                        //TODO: Emailed Dr. K to ask about this 
                        double sP = relativeChange * beta;


                        //STEP 4: Find expected new price of the equity 
                        //𝑃1 = (1 + 𝛿𝑃) ⋅ [𝐿𝑎𝑡𝑒𝑠𝑡 𝐶𝑙𝑜𝑠𝑒 𝑃𝑟𝑖𝑐𝑒 = 𝑃]
                        //en 𝑃1 = 𝐸𝑥𝑝𝑒𝑐𝑡𝑒𝑑 𝑝𝑟𝑖𝑐𝑒 𝑜𝑓 𝐴𝑃𝑃𝐿 = (1 ― 1.097%) ⋅ 172.573≅170.68
                        Double ogValue = Convert.ToDouble(Positions.Rows[i].Cells[2].Value);
                        double expectedPrice = (1 + sP) * ogValue;

                        //STEP 5: Fill the values column 
                        //multiply this times num shares to populate the Values column 
                        //double impliedValues = expectedPrice * posShares;


                        //STEP 6: Fill the P/L column 
                        //𝑃/ 𝐿 = (𝑃1 ― 𝑃) 𝑝𝑒𝑟𝑠ℎ𝑎𝑟𝑒 WHERE P = Latest Close Price 
                        //𝑃 / 𝐿 = 100 (𝑠ℎ𝑎𝑟𝑒𝑠) ∗ (170.68 – 172.57)≅ ― 189.00
                        //     double pL = posShares * (expectedPrice - originalPricePerShare);
                        double pL = expectedPrice - ogValue;

                        ImpliedChanges.Rows.Add(strTicker, expectedPrice, pL);


                        sqlCmd.Parameters.Clear();
                    }
                }
                ////Double valueTickerAapl = Convert.ToDouble(Positions.Rows[0].Cells[2].Value);
                //Double valueTickerGld = Convert.ToDouble(Positions.Rows[1].Cells[2].Value);
                //Double valueTickerNflx = Convert.ToDouble(Positions.Rows[2].Cells[2].Value);
                //Double valueTickerTsla = Convert.ToDouble(Positions.Rows[3].Cells[2].Value);
                ////Double valueTickerAapl = Convert.ToDouble(Positions.Rows[0].Cells[2].Value);




                //format ImpliedChanges data grid view
                ImpliedChanges.Columns["Ticker"].DefaultCellStyle.Format = "c";

                ImpliedChanges.Columns["Values"].DefaultCellStyle.Format = "#,###";

                ImpliedChanges.Columns["Profit_Loss"].DefaultCellStyle.Format = "#,###";
                ImpliedChanges.AllowUserToAddRows = false;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void impliedChangeLabel_Click(object sender, EventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            //Clear's the price, selected ticker, and implied changes data grid view
            PriceTextBox.Clear();
            ticker_list.ClearSelected();
            ImpliedChanges.Rows.Clear();

        }
    }
}
