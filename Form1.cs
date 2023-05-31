using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

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

                using (SqlConnection con = new SqlConnection(strConnect))
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

                //How to remove left column + sums from DGV using positions.

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

            //format ImpliedChanges data grid view
            ImpliedChanges.Columns["Ticker"].DefaultCellStyle.Format = "c";

            ImpliedChanges.Columns["Values"].DefaultCellStyle.Format = "#,###";

            ImpliedChanges.Columns["Profit_Loss"].DefaultCellStyle.Format = "#,###";
            ImpliedChanges.AllowUserToAddRows = false;
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
