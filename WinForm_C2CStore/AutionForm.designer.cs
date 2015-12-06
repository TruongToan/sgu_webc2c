namespace WinForm_C2CStore
{
    partial class AutionForm
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
            this.UserTab = new System.Windows.Forms.TabPage();
            this.userGridView = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisableUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AuctionTab = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AllAution = new System.Windows.Forms.TabPage();
            this.allAutionGridView = new System.Windows.Forms.DataGridView();
            this.AutionChecking = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.IDCheking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameChecking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryChecking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreateChecking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutionOpening = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.AutionSold = new System.Windows.Forms.TabPage();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.User = new System.Windows.Forms.TabControl();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPriceAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTimeAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailsAll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.AuctionTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.AllAution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allAutionGridView)).BeginInit();
            this.AutionChecking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.AutionOpening.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.AutionSold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.User.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserTab
            // 
            this.UserTab.BackColor = System.Drawing.Color.Transparent;
            this.UserTab.Controls.Add(this.userGridView);
            this.UserTab.Controls.Add(this.dataGridView1);
            this.UserTab.Location = new System.Drawing.Point(4, 22);
            this.UserTab.Name = "UserTab";
            this.UserTab.Padding = new System.Windows.Forms.Padding(3);
            this.UserTab.Size = new System.Drawing.Size(911, 439);
            this.UserTab.TabIndex = 1;
            this.UserTab.Text = "Manage User";
            // 
            // userGridView
            // 
            this.userGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.userGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.UserName,
            this.Email,
            this.Address,
            this.PhoneNumber,
            this.DisableUser});
            this.userGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userGridView.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.userGridView.Location = new System.Drawing.Point(3, 3);
            this.userGridView.Name = "userGridView";
            this.userGridView.Size = new System.Drawing.Size(905, 433);
            this.userGridView.TabIndex = 1;
            this.userGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // UserID
            // 
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Address
            // 
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.HeaderText = "Phone Number";
            this.PhoneNumber.Name = "PhoneNumber";
            // 
            // DisableUser
            // 
            this.DisableUser.HeaderText = "Disable User";
            this.DisableUser.Name = "DisableUser";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1050, 391);
            this.dataGridView1.TabIndex = 0;
            // 
            // AuctionTab
            // 
            this.AuctionTab.Controls.Add(this.tabControl1);
            this.AuctionTab.Location = new System.Drawing.Point(4, 22);
            this.AuctionTab.Name = "AuctionTab";
            this.AuctionTab.Padding = new System.Windows.Forms.Padding(3);
            this.AuctionTab.Size = new System.Drawing.Size(1486, 439);
            this.AuctionTab.TabIndex = 0;
            this.AuctionTab.Text = "Manage Auction";
            this.AuctionTab.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AllAution);
            this.tabControl1.Controls.Add(this.AutionChecking);
            this.tabControl1.Controls.Add(this.AutionOpening);
            this.tabControl1.Controls.Add(this.AutionSold);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1480, 433);
            this.tabControl1.TabIndex = 1;
            // 
            // AllAution
            // 
            this.AllAution.BackColor = System.Drawing.Color.Gainsboro;
            this.AllAution.Controls.Add(this.allAutionGridView);
            this.AllAution.Location = new System.Drawing.Point(4, 22);
            this.AllAution.Name = "AllAution";
            this.AllAution.Size = new System.Drawing.Size(1472, 407);
            this.AllAution.TabIndex = 0;
            this.AllAution.Text = "AllAution";
            // 
            // allAutionGridView
            // 
            this.allAutionGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.allAutionGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.allAutionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allAutionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.NameAll,
            this.CategoryAll,
            this.CurrentPriceAll,
            this.EndTimeAll,
            this.StatusAll,
            this.DetailsAll});
            this.allAutionGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allAutionGridView.Location = new System.Drawing.Point(0, 0);
            this.allAutionGridView.Name = "allAutionGridView";
            this.allAutionGridView.Size = new System.Drawing.Size(1472, 407);
            this.allAutionGridView.TabIndex = 0;
            this.allAutionGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allAutionGridView_CellContentClick);
            // 
            // AutionChecking
            // 
            this.AutionChecking.BackColor = System.Drawing.Color.Gainsboro;
            this.AutionChecking.Controls.Add(this.dataGridView3);
            this.AutionChecking.Location = new System.Drawing.Point(4, 22);
            this.AutionChecking.Name = "AutionChecking";
            this.AutionChecking.Size = new System.Drawing.Size(1039, 365);
            this.AutionChecking.TabIndex = 1;
            this.AutionChecking.Text = "Aution Checking";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCheking,
            this.NameChecking,
            this.CategoryChecking,
            this.DateCreateChecking,
            this.EndTime});
            this.dataGridView3.Location = new System.Drawing.Point(0, 1);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(1039, 365);
            this.dataGridView3.TabIndex = 1;
            // 
            // IDCheking
            // 
            this.IDCheking.HeaderText = "ID";
            this.IDCheking.Name = "IDCheking";
            // 
            // NameChecking
            // 
            this.NameChecking.HeaderText = "Name";
            this.NameChecking.Name = "NameChecking";
            // 
            // CategoryChecking
            // 
            this.CategoryChecking.HeaderText = "Category";
            this.CategoryChecking.Name = "CategoryChecking";
            // 
            // DateCreateChecking
            // 
            this.DateCreateChecking.HeaderText = "DateCreate";
            this.DateCreateChecking.Name = "DateCreateChecking";
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "EndTimeChecking";
            this.EndTime.Name = "EndTime";
            // 
            // AutionOpening
            // 
            this.AutionOpening.BackColor = System.Drawing.Color.Gainsboro;
            this.AutionOpening.Controls.Add(this.dataGridView4);
            this.AutionOpening.Location = new System.Drawing.Point(4, 22);
            this.AutionOpening.Name = "AutionOpening";
            this.AutionOpening.Size = new System.Drawing.Size(1039, 365);
            this.AutionOpening.TabIndex = 2;
            this.AutionOpening.Text = "Aution Opening";
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(0, 2);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(1039, 365);
            this.dataGridView4.TabIndex = 1;
            // 
            // AutionSold
            // 
            this.AutionSold.BackColor = System.Drawing.Color.Gainsboro;
            this.AutionSold.Controls.Add(this.dataGridView5);
            this.AutionSold.Location = new System.Drawing.Point(4, 22);
            this.AutionSold.Name = "AutionSold";
            this.AutionSold.Size = new System.Drawing.Size(1039, 365);
            this.AutionSold.TabIndex = 3;
            this.AutionSold.Text = "Aution Sold";
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(0, 1);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(1039, 365);
            this.dataGridView5.TabIndex = 1;
            // 
            // User
            // 
            this.User.Controls.Add(this.UserTab);
            this.User.Controls.Add(this.AuctionTab);
            this.User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.User.Location = new System.Drawing.Point(0, 0);
            this.User.Name = "User";
            this.User.SelectedIndex = 0;
            this.User.Size = new System.Drawing.Size(919, 465);
            this.User.TabIndex = 1;
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // NameAll
            // 
            this.NameAll.DataPropertyName = "Name";
            this.NameAll.HeaderText = "Name";
            this.NameAll.Name = "NameAll";
            // 
            // CategoryAll
            // 
            this.CategoryAll.DataPropertyName = "Category";
            this.CategoryAll.HeaderText = "Category";
            this.CategoryAll.Name = "CategoryAll";
            // 
            // CurrentPriceAll
            // 
            this.CurrentPriceAll.DataPropertyName = "CurrentPrice";
            this.CurrentPriceAll.HeaderText = "Current Price";
            this.CurrentPriceAll.Name = "CurrentPriceAll";
            // 
            // EndTimeAll
            // 
            this.EndTimeAll.DataPropertyName = "EndTime";
            this.EndTimeAll.HeaderText = "End Time";
            this.EndTimeAll.Name = "EndTimeAll";
            // 
            // StatusAll
            // 
            this.StatusAll.DataPropertyName = "Status";
            this.StatusAll.HeaderText = "Status";
            this.StatusAll.Name = "StatusAll";
            // 
            // DetailsAll
            // 
            this.DetailsAll.DataPropertyName = "Details";
            this.DetailsAll.HeaderText = "Detail";
            this.DetailsAll.Name = "DetailsAll";
            // 
            // AutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 465);
            this.Controls.Add(this.User);
            this.Name = "AutionForm";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.UserTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.AuctionTab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.AllAution.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allAutionGridView)).EndInit();
            this.AutionChecking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.AutionOpening.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.AutionSold.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.User.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage UserTab;
        private System.Windows.Forms.TabPage AuctionTab;
        private System.Windows.Forms.TabControl User;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView userGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisableUser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AllAution;
        private System.Windows.Forms.TabPage AutionChecking;
        private System.Windows.Forms.TabPage AutionOpening;
        private System.Windows.Forms.TabPage AutionSold;
        private System.Windows.Forms.DataGridView allAutionGridView;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCheking;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameChecking;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryChecking;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreateChecking;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPriceAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTimeAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailsAll;
    }
}

