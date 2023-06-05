namespace FinanceTermProjectS23
{
    partial class P_L_Calc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Positions = new System.Windows.Forms.DataGridView();
            this.stockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.final_Project_S23DataSet = new FinanceTermProjectS23.Final_Project_S23DataSet();
            this.ImpliedChanges = new System.Windows.Forms.DataGridView();
            this.Ticker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Values = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit_Loss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.PositionsLabel = new System.Windows.Forms.Label();
            this.impliedChangeLabel = new System.Windows.Forms.Label();
            this.Hedge = new System.Windows.Forms.Label();
            this.ticker_list = new System.Windows.Forms.ListBox();
            this.TickerSelectLabel = new System.Windows.Forms.Label();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.stockTableAdapter = new FinanceTermProjectS23.Final_Project_S23DataSetTableAdapters.StockTableAdapter();
            this.submitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Positions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.final_Project_S23DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpliedChanges)).BeginInit();
            this.SuspendLayout();
            // 
            // Positions
            // 
            this.Positions.AllowUserToOrderColumns = true;
            this.Positions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Positions.Location = new System.Drawing.Point(2, 72);
            this.Positions.Name = "Positions";
            this.Positions.RowHeadersVisible = false;
            this.Positions.RowHeadersWidth = 62;
            this.Positions.RowTemplate.Height = 28;
            this.Positions.Size = new System.Drawing.Size(450, 433);
            this.Positions.TabIndex = 0;
            this.Positions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // stockBindingSource
            // 
            this.stockBindingSource.DataMember = "Stock";
            this.stockBindingSource.DataSource = this.final_Project_S23DataSet;
            // 
            // final_Project_S23DataSet
            // 
            this.final_Project_S23DataSet.DataSetName = "Final_Project_S23DataSet";
            this.final_Project_S23DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ImpliedChanges
            // 
            this.ImpliedChanges.AllowUserToAddRows = false;
            this.ImpliedChanges.AllowUserToDeleteRows = false;
            this.ImpliedChanges.AllowUserToResizeColumns = false;
            this.ImpliedChanges.AllowUserToResizeRows = false;
            this.ImpliedChanges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ImpliedChanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ImpliedChanges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ticker,
            this.Values,
            this.Profit_Loss});
            this.ImpliedChanges.Location = new System.Drawing.Point(782, 72);
            this.ImpliedChanges.Name = "ImpliedChanges";
            this.ImpliedChanges.RowHeadersVisible = false;
            this.ImpliedChanges.RowHeadersWidth = 62;
            this.ImpliedChanges.RowTemplate.Height = 28;
            this.ImpliedChanges.Size = new System.Drawing.Size(450, 433);
            this.ImpliedChanges.TabIndex = 1;
            // 
            // Ticker
            // 
            this.Ticker.HeaderText = "Ticker";
            this.Ticker.MinimumWidth = 8;
            this.Ticker.Name = "Ticker";
            // 
            // Values
            // 
            this.Values.HeaderText = "Values";
            this.Values.MinimumWidth = 8;
            this.Values.Name = "Values";
            // 
            // Profit_Loss
            // 
            this.Profit_Loss.HeaderText = "P/L";
            this.Profit_Loss.MinimumWidth = 8;
            this.Profit_Loss.Name = "Profit_Loss";
            // 
            // PositionsLabel
            // 
            this.PositionsLabel.Location = new System.Drawing.Point(141, 27);
            this.PositionsLabel.Name = "PositionsLabel";
            this.PositionsLabel.Size = new System.Drawing.Size(137, 42);
            this.PositionsLabel.TabIndex = 2;
            this.PositionsLabel.Text = "Positions";
            this.PositionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PositionsLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // impliedChangeLabel
            // 
            this.impliedChangeLabel.Location = new System.Drawing.Point(947, 27);
            this.impliedChangeLabel.Name = "impliedChangeLabel";
            this.impliedChangeLabel.Size = new System.Drawing.Size(137, 42);
            this.impliedChangeLabel.TabIndex = 3;
            this.impliedChangeLabel.Text = "Implied Changes";
            this.impliedChangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.impliedChangeLabel.Click += new System.EventHandler(this.impliedChangeLabel_Click);
            // 
            // Hedge
            // 
            this.Hedge.Location = new System.Drawing.Point(542, 27);
            this.Hedge.Name = "Hedge";
            this.Hedge.Size = new System.Drawing.Size(137, 42);
            this.Hedge.TabIndex = 4;
            this.Hedge.Text = "Hedge";
            this.Hedge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ticker_list
            // 
            this.ticker_list.FormattingEnabled = true;
            this.ticker_list.ItemHeight = 20;
            this.ticker_list.Location = new System.Drawing.Point(491, 139);
            this.ticker_list.Name = "ticker_list";
            this.ticker_list.Size = new System.Drawing.Size(109, 124);
            this.ticker_list.TabIndex = 5;
            this.ticker_list.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // TickerSelectLabel
            // 
            this.TickerSelectLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TickerSelectLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TickerSelectLabel.Location = new System.Drawing.Point(487, 72);
            this.TickerSelectLabel.Name = "TickerSelectLabel";
            this.TickerSelectLabel.Size = new System.Drawing.Size(113, 42);
            this.TickerSelectLabel.TabIndex = 6;
            this.TickerSelectLabel.Text = "Ticker";
            this.TickerSelectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(621, 80);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(142, 26);
            this.PriceTextBox.TabIndex = 7;
            this.PriceTextBox.Text = "Price";
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.RefreshButton.Location = new System.Drawing.Point(546, 289);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(124, 62);
            this.RefreshButton.TabIndex = 8;
            this.RefreshButton.Text = "REFRESH";
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // stockTableAdapter
            // 
            this.stockTableAdapter.ClearBeforeFill = true;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(555, 372);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(102, 53);
            this.submitButton.TabIndex = 9;
            this.submitButton.Text = "Submit Changes";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // P_L_Calc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1241, 516);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.TickerSelectLabel);
            this.Controls.Add(this.ticker_list);
            this.Controls.Add(this.Hedge);
            this.Controls.Add(this.impliedChangeLabel);
            this.Controls.Add(this.PositionsLabel);
            this.Controls.Add(this.ImpliedChanges);
            this.Controls.Add(this.Positions);
            this.Name = "P_L_Calc";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.P_L_Calc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Positions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.final_Project_S23DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpliedChanges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Positions;
        private System.Windows.Forms.DataGridView ImpliedChanges;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label PositionsLabel;
        private System.Windows.Forms.Label impliedChangeLabel;
        private System.Windows.Forms.Label Hedge;
        private System.Windows.Forms.ListBox ticker_list;
        private System.Windows.Forms.Label TickerSelectLabel;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Button RefreshButton;
        private Final_Project_S23DataSet final_Project_S23DataSet;
        private System.Windows.Forms.BindingSource stockBindingSource;
        private Final_Project_S23DataSetTableAdapters.StockTableAdapter stockTableAdapter;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ticker;
        private System.Windows.Forms.DataGridViewTextBoxColumn Values;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit_Loss;
    }
}

