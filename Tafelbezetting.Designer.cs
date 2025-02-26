namespace Tafelbezetting
{
    partial class frmTafelBezetting
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabMain = new TabControl();
            tabDBConnection = new TabPage();
            btnCreateDB = new Button();
            btnConnect = new Button();
            lblMessage = new Label();
            txtPassword = new TextBox();
            txtUser = new TextBox();
            lblPassword = new Label();
            lblUserName = new Label();
            txtIPAddress = new TextBox();
            lblIPAddress = new Label();
            tabGebruikers = new TabPage();
            btnCancel0 = new Button();
            btnSave0 = new Button();
            btnNew0 = new Button();
            btnDelete0 = new Button();
            btnChange0 = new Button();
            chkNo = new CheckBox();
            chkYes = new CheckBox();
            lblHasLaptop = new Label();
            lblName = new Label();
            lblUserID = new Label();
            txtUserName = new TextBox();
            txtUserID = new TextBox();
            grdUsers = new DataGridView();
            clmUserID = new DataGridViewTextBoxColumn();
            clmNaam = new DataGridViewTextBoxColumn();
            clmHasLaptop = new DataGridViewCheckBoxColumn();
            tabTafels = new TabPage();
            btnCancel1 = new Button();
            btnSave1 = new Button();
            btnNew1 = new Button();
            btnDelete1 = new Button();
            btnChange1 = new Button();
            picOfficeLayout = new PictureBox();
            chkNo2 = new CheckBox();
            chkYes2 = new CheckBox();
            txtTafelNr = new TextBox();
            lblHasNuc = new Label();
            lblTafelNr = new Label();
            grdTafels = new DataGridView();
            clmTafelNr = new DataGridViewTextBoxColumn();
            clmHasNUC = new DataGridViewCheckBoxColumn();
            tabTafelGebruikers = new TabPage();
            btnCancel2 = new Button();
            btnSave2 = new Button();
            btnNew2 = new Button();
            btnDelete2 = new Button();
            btnChange2 = new Button();
            cboUser = new ComboBox();
            cboTafel = new ComboBox();
            cboDagdeel = new ComboBox();
            cboWeekDay = new ComboBox();
            lblDagdeel = new Label();
            lblDag = new Label();
            lblGebruiker2 = new Label();
            lblTafelNr2 = new Label();
            grdTableUsers = new DataGridView();
            clmTafelNr2 = new DataGridViewTextBoxColumn();
            clmDagVDWeek = new DataGridViewTextBoxColumn();
            clmDagdeel = new DataGridViewTextBoxColumn();
            clmGebruiker2 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            tabMain.SuspendLayout();
            tabDBConnection.SuspendLayout();
            tabGebruikers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdUsers).BeginInit();
            tabTafels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picOfficeLayout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdTafels).BeginInit();
            tabTafelGebruikers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdTableUsers).BeginInit();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabDBConnection);
            tabMain.Controls.Add(tabGebruikers);
            tabMain.Controls.Add(tabTafels);
            tabMain.Controls.Add(tabTafelGebruikers);
            tabMain.Location = new Point(7, 12);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(778, 433);
            tabMain.TabIndex = 1;
            // 
            // tabDBConnection
            // 
            tabDBConnection.Controls.Add(btnCreateDB);
            tabDBConnection.Controls.Add(btnConnect);
            tabDBConnection.Controls.Add(lblMessage);
            tabDBConnection.Controls.Add(txtPassword);
            tabDBConnection.Controls.Add(txtUser);
            tabDBConnection.Controls.Add(lblPassword);
            tabDBConnection.Controls.Add(lblUserName);
            tabDBConnection.Controls.Add(txtIPAddress);
            tabDBConnection.Controls.Add(lblIPAddress);
            tabDBConnection.Location = new Point(4, 24);
            tabDBConnection.Name = "tabDBConnection";
            tabDBConnection.Padding = new Padding(3);
            tabDBConnection.Size = new Size(770, 405);
            tabDBConnection.TabIndex = 3;
            tabDBConnection.Text = "DB-Connection";
            tabDBConnection.UseVisualStyleBackColor = true;
            // 
            // btnCreateDB
            // 
            btnCreateDB.Location = new Point(99, 326);
            btnCreateDB.Name = "btnCreateDB";
            btnCreateDB.Size = new Size(153, 26);
            btnCreateDB.TabIndex = 8;
            btnCreateDB.Text = "Create MySQL Database";
            btnCreateDB.UseVisualStyleBackColor = true;
            btnCreateDB.Click += btnCreateDB_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(108, 281);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 7;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // lblMessage
            // 
            lblMessage.BorderStyle = BorderStyle.FixedSingle;
            lblMessage.Location = new Point(400, 75);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(300, 200);
            lblMessage.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(200, 150);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 5;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(200, 110);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(100, 23);
            txtUser.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(75, 155);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(75, 115);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(63, 15);
            lblUserName.TabIndex = 2;
            lblUserName.Text = "User name";
            // 
            // txtIPAddress
            // 
            txtIPAddress.Location = new Point(200, 70);
            txtIPAddress.Name = "txtIPAddress";
            txtIPAddress.Size = new Size(100, 23);
            txtIPAddress.TabIndex = 1;
            txtIPAddress.TextChanged += txtIPAddress_TextChanged;
            // 
            // lblIPAddress
            // 
            lblIPAddress.AutoSize = true;
            lblIPAddress.Location = new Point(75, 75);
            lblIPAddress.Name = "lblIPAddress";
            lblIPAddress.Size = new Size(123, 15);
            lblIPAddress.TabIndex = 0;
            lblIPAddress.Text = "IP-Address MySQL DB";
            // 
            // tabGebruikers
            // 
            tabGebruikers.Controls.Add(btnCancel0);
            tabGebruikers.Controls.Add(btnSave0);
            tabGebruikers.Controls.Add(btnNew0);
            tabGebruikers.Controls.Add(btnDelete0);
            tabGebruikers.Controls.Add(btnChange0);
            tabGebruikers.Controls.Add(chkNo);
            tabGebruikers.Controls.Add(chkYes);
            tabGebruikers.Controls.Add(lblHasLaptop);
            tabGebruikers.Controls.Add(lblName);
            tabGebruikers.Controls.Add(lblUserID);
            tabGebruikers.Controls.Add(txtUserName);
            tabGebruikers.Controls.Add(txtUserID);
            tabGebruikers.Controls.Add(grdUsers);
            tabGebruikers.Location = new Point(4, 24);
            tabGebruikers.Name = "tabGebruikers";
            tabGebruikers.Padding = new Padding(3);
            tabGebruikers.Size = new Size(770, 405);
            tabGebruikers.TabIndex = 0;
            tabGebruikers.Text = "Gebruikers";
            tabGebruikers.UseVisualStyleBackColor = true;
            // 
            // btnCancel0
            // 
            btnCancel0.Location = new Point(608, 376);
            btnCancel0.Name = "btnCancel0";
            btnCancel0.Size = new Size(75, 23);
            btnCancel0.TabIndex = 12;
            btnCancel0.Text = "Cancel";
            btnCancel0.UseVisualStyleBackColor = true;
            // 
            // btnSave0
            // 
            btnSave0.Location = new Point(689, 376);
            btnSave0.Name = "btnSave0";
            btnSave0.Size = new Size(75, 23);
            btnSave0.TabIndex = 11;
            btnSave0.Text = "Save";
            btnSave0.UseVisualStyleBackColor = true;
            btnSave0.Click += btnSave0_Click;
            // 
            // btnNew0
            // 
            btnNew0.Location = new Point(445, 377);
            btnNew0.Name = "btnNew0";
            btnNew0.Size = new Size(75, 23);
            btnNew0.TabIndex = 10;
            btnNew0.Text = "New";
            btnNew0.UseVisualStyleBackColor = true;
            btnNew0.Click += btnNew0_Click;
            // 
            // btnDelete0
            // 
            btnDelete0.Location = new Point(445, 348);
            btnDelete0.Name = "btnDelete0";
            btnDelete0.Size = new Size(75, 23);
            btnDelete0.TabIndex = 9;
            btnDelete0.Text = "Delete";
            btnDelete0.UseVisualStyleBackColor = true;
            btnDelete0.Click += btnDelete0_Click;
            // 
            // btnChange0
            // 
            btnChange0.Location = new Point(445, 319);
            btnChange0.Name = "btnChange0";
            btnChange0.Size = new Size(75, 23);
            btnChange0.TabIndex = 8;
            btnChange0.Text = "Change";
            btnChange0.UseVisualStyleBackColor = true;
            btnChange0.Click += btnChange0_Click;
            // 
            // chkNo
            // 
            chkNo.AutoSize = true;
            chkNo.Enabled = false;
            chkNo.Location = new Point(167, 373);
            chkNo.Name = "chkNo";
            chkNo.Size = new Size(42, 19);
            chkNo.TabIndex = 7;
            chkNo.Text = "No";
            chkNo.UseVisualStyleBackColor = true;
            // 
            // chkYes
            // 
            chkYes.AutoSize = true;
            chkYes.Enabled = false;
            chkYes.Location = new Point(118, 373);
            chkYes.Name = "chkYes";
            chkYes.Size = new Size(43, 19);
            chkYes.TabIndex = 6;
            chkYes.Text = "Yes";
            chkYes.UseVisualStyleBackColor = true;
            // 
            // lblHasLaptop
            // 
            lblHasLaptop.AutoSize = true;
            lblHasLaptop.Location = new Point(15, 374);
            lblHasLaptop.Name = "lblHasLaptop";
            lblHasLaptop.Size = new Size(62, 15);
            lblHasLaptop.TabIndex = 5;
            lblHasLaptop.Text = "has laptop";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(15, 348);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 4;
            lblName.Text = "Name";
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Location = new Point(15, 319);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(72, 15);
            lblUserID.TabIndex = 3;
            lblUserID.Text = "Gebruiker ID";
            // 
            // txtUserName
            // 
            txtUserName.Enabled = false;
            txtUserName.Location = new Point(118, 344);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(309, 23);
            txtUserName.TabIndex = 2;
            // 
            // txtUserID
            // 
            txtUserID.Enabled = false;
            txtUserID.Location = new Point(118, 315);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(100, 23);
            txtUserID.TabIndex = 1;
            // 
            // grdUsers
            // 
            grdUsers.AllowUserToAddRows = false;
            grdUsers.AllowUserToDeleteRows = false;
            grdUsers.AllowUserToResizeColumns = false;
            grdUsers.AllowUserToResizeRows = false;
            grdUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdUsers.Columns.AddRange(new DataGridViewColumn[] { clmUserID, clmNaam, clmHasLaptop });
            grdUsers.Location = new Point(15, 20);
            grdUsers.Name = "grdUsers";
            grdUsers.ReadOnly = true;
            grdUsers.ScrollBars = ScrollBars.Vertical;
            grdUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdUsers.Size = new Size(749, 289);
            grdUsers.TabIndex = 0;
            // 
            // clmUserID
            // 
            clmUserID.HeaderText = "Gebruiker ID";
            clmUserID.Name = "clmUserID";
            clmUserID.ReadOnly = true;
            clmUserID.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // clmNaam
            // 
            clmNaam.HeaderText = "Naam";
            clmNaam.Name = "clmNaam";
            clmNaam.ReadOnly = true;
            clmNaam.SortMode = DataGridViewColumnSortMode.NotSortable;
            clmNaam.Width = 200;
            // 
            // clmHasLaptop
            // 
            clmHasLaptop.HeaderText = "has laptop";
            clmHasLaptop.Name = "clmHasLaptop";
            clmHasLaptop.ReadOnly = true;
            clmHasLaptop.Width = 70;
            // 
            // tabTafels
            // 
            tabTafels.Controls.Add(btnCancel1);
            tabTafels.Controls.Add(btnSave1);
            tabTafels.Controls.Add(btnNew1);
            tabTafels.Controls.Add(btnDelete1);
            tabTafels.Controls.Add(btnChange1);
            tabTafels.Controls.Add(picOfficeLayout);
            tabTafels.Controls.Add(chkNo2);
            tabTafels.Controls.Add(chkYes2);
            tabTafels.Controls.Add(txtTafelNr);
            tabTafels.Controls.Add(lblHasNuc);
            tabTafels.Controls.Add(lblTafelNr);
            tabTafels.Controls.Add(grdTafels);
            tabTafels.Location = new Point(4, 24);
            tabTafels.Name = "tabTafels";
            tabTafels.Padding = new Padding(3);
            tabTafels.Size = new Size(770, 405);
            tabTafels.TabIndex = 1;
            tabTafels.Text = "Tafels";
            tabTafels.UseVisualStyleBackColor = true;
            // 
            // btnCancel1
            // 
            btnCancel1.Location = new Point(469, 379);
            btnCancel1.Name = "btnCancel1";
            btnCancel1.Size = new Size(75, 23);
            btnCancel1.TabIndex = 17;
            btnCancel1.Text = "Cancel";
            btnCancel1.UseVisualStyleBackColor = true;
            // 
            // btnSave1
            // 
            btnSave1.Location = new Point(550, 379);
            btnSave1.Name = "btnSave1";
            btnSave1.Size = new Size(75, 23);
            btnSave1.TabIndex = 16;
            btnSave1.Text = "Save";
            btnSave1.UseVisualStyleBackColor = true;
            btnSave1.Click += btnSave1_Click;
            // 
            // btnNew1
            // 
            btnNew1.Location = new Point(306, 379);
            btnNew1.Name = "btnNew1";
            btnNew1.Size = new Size(75, 23);
            btnNew1.TabIndex = 15;
            btnNew1.Text = "New";
            btnNew1.UseVisualStyleBackColor = true;
            btnNew1.Click += btnNew1_Click;
            // 
            // btnDelete1
            // 
            btnDelete1.Location = new Point(306, 350);
            btnDelete1.Name = "btnDelete1";
            btnDelete1.Size = new Size(75, 23);
            btnDelete1.TabIndex = 14;
            btnDelete1.Text = "Delete";
            btnDelete1.UseVisualStyleBackColor = true;
            btnDelete1.Click += btnDelete1_Click;
            // 
            // btnChange1
            // 
            btnChange1.Location = new Point(306, 321);
            btnChange1.Name = "btnChange1";
            btnChange1.Size = new Size(75, 23);
            btnChange1.TabIndex = 13;
            btnChange1.Text = "Change";
            btnChange1.UseVisualStyleBackColor = true;
            btnChange1.Click += btnChange1_Click;
            // 
            // picOfficeLayout
            // 
            picOfficeLayout.Location = new Point(262, 6);
            picOfficeLayout.Name = "picOfficeLayout";
            picOfficeLayout.Size = new Size(505, 301);
            picOfficeLayout.TabIndex = 6;
            picOfficeLayout.TabStop = false;
            // 
            // chkNo2
            // 
            chkNo2.AutoSize = true;
            chkNo2.Enabled = false;
            chkNo2.Location = new Point(134, 353);
            chkNo2.Name = "chkNo2";
            chkNo2.Size = new Size(42, 19);
            chkNo2.TabIndex = 5;
            chkNo2.Text = "No";
            chkNo2.UseVisualStyleBackColor = true;
            // 
            // chkYes2
            // 
            chkYes2.AutoSize = true;
            chkYes2.Enabled = false;
            chkYes2.Location = new Point(85, 353);
            chkYes2.Name = "chkYes2";
            chkYes2.Size = new Size(43, 19);
            chkYes2.TabIndex = 4;
            chkYes2.Text = "Yes";
            chkYes2.UseVisualStyleBackColor = true;
            // 
            // txtTafelNr
            // 
            txtTafelNr.Enabled = false;
            txtTafelNr.Location = new Point(85, 324);
            txtTafelNr.Name = "txtTafelNr";
            txtTafelNr.Size = new Size(100, 23);
            txtTafelNr.TabIndex = 3;
            // 
            // lblHasNuc
            // 
            lblHasNuc.AutoSize = true;
            lblHasNuc.Location = new Point(7, 353);
            lblHasNuc.Name = "lblHasNuc";
            lblHasNuc.Size = new Size(53, 15);
            lblHasNuc.TabIndex = 2;
            lblHasNuc.Text = "has NUC";
            // 
            // lblTafelNr
            // 
            lblTafelNr.AutoSize = true;
            lblTafelNr.Location = new Point(7, 327);
            lblTafelNr.Name = "lblTafelNr";
            lblTafelNr.Size = new Size(47, 15);
            lblTafelNr.TabIndex = 1;
            lblTafelNr.Text = "Tafel Nr";
            // 
            // grdTafels
            // 
            grdTafels.AllowUserToAddRows = false;
            grdTafels.AllowUserToDeleteRows = false;
            grdTafels.AllowUserToResizeColumns = false;
            grdTafels.AllowUserToResizeRows = false;
            grdTafels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdTafels.Columns.AddRange(new DataGridViewColumn[] { clmTafelNr, clmHasNUC });
            grdTafels.Location = new Point(6, 6);
            grdTafels.Name = "grdTafels";
            grdTafels.ReadOnly = true;
            grdTafels.Size = new Size(250, 301);
            grdTafels.TabIndex = 0;
            // 
            // clmTafelNr
            // 
            clmTafelNr.HeaderText = "Tafel Nr";
            clmTafelNr.Name = "clmTafelNr";
            clmTafelNr.ReadOnly = true;
            // 
            // clmHasNUC
            // 
            clmHasNUC.HeaderText = "has NUC";
            clmHasNUC.Name = "clmHasNUC";
            clmHasNUC.ReadOnly = true;
            // 
            // tabTafelGebruikers
            // 
            tabTafelGebruikers.Controls.Add(btnCancel2);
            tabTafelGebruikers.Controls.Add(btnSave2);
            tabTafelGebruikers.Controls.Add(btnNew2);
            tabTafelGebruikers.Controls.Add(btnDelete2);
            tabTafelGebruikers.Controls.Add(btnChange2);
            tabTafelGebruikers.Controls.Add(cboUser);
            tabTafelGebruikers.Controls.Add(cboTafel);
            tabTafelGebruikers.Controls.Add(cboDagdeel);
            tabTafelGebruikers.Controls.Add(cboWeekDay);
            tabTafelGebruikers.Controls.Add(lblDagdeel);
            tabTafelGebruikers.Controls.Add(lblDag);
            tabTafelGebruikers.Controls.Add(lblGebruiker2);
            tabTafelGebruikers.Controls.Add(lblTafelNr2);
            tabTafelGebruikers.Controls.Add(grdTableUsers);
            tabTafelGebruikers.Location = new Point(4, 24);
            tabTafelGebruikers.Name = "tabTafelGebruikers";
            tabTafelGebruikers.Size = new Size(770, 405);
            tabTafelGebruikers.TabIndex = 2;
            tabTafelGebruikers.Text = "Gebruikers aan tafel";
            tabTafelGebruikers.UseVisualStyleBackColor = true;
            // 
            // btnCancel2
            // 
            btnCancel2.Location = new Point(609, 225);
            btnCancel2.Name = "btnCancel2";
            btnCancel2.Size = new Size(75, 23);
            btnCancel2.TabIndex = 17;
            btnCancel2.Text = "Cancel";
            btnCancel2.UseVisualStyleBackColor = true;
            // 
            // btnSave2
            // 
            btnSave2.Location = new Point(690, 225);
            btnSave2.Name = "btnSave2";
            btnSave2.Size = new Size(75, 23);
            btnSave2.TabIndex = 16;
            btnSave2.Text = "Save";
            btnSave2.UseVisualStyleBackColor = true;
            // 
            // btnNew2
            // 
            btnNew2.Location = new Point(690, 179);
            btnNew2.Name = "btnNew2";
            btnNew2.Size = new Size(75, 23);
            btnNew2.TabIndex = 15;
            btnNew2.Text = "New";
            btnNew2.UseVisualStyleBackColor = true;
            // 
            // btnDelete2
            // 
            btnDelete2.Location = new Point(609, 179);
            btnDelete2.Name = "btnDelete2";
            btnDelete2.Size = new Size(75, 23);
            btnDelete2.TabIndex = 14;
            btnDelete2.Text = "Delete";
            btnDelete2.UseVisualStyleBackColor = true;
            btnDelete2.Click += btnDelete2_Click;
            // 
            // btnChange2
            // 
            btnChange2.Location = new Point(528, 179);
            btnChange2.Name = "btnChange2";
            btnChange2.Size = new Size(75, 23);
            btnChange2.TabIndex = 13;
            btnChange2.Text = "Change";
            btnChange2.UseVisualStyleBackColor = true;
            btnChange2.Click += btnChange2_Click;
            // 
            // cboUser
            // 
            cboUser.Enabled = false;
            cboUser.FormattingEnabled = true;
            cboUser.Location = new Point(635, 118);
            cboUser.Name = "cboUser";
            cboUser.Size = new Size(130, 23);
            cboUser.TabIndex = 10;
            // 
            // cboTafel
            // 
            cboTafel.Enabled = false;
            cboTafel.FormattingEnabled = true;
            cboTafel.Location = new Point(635, 22);
            cboTafel.Name = "cboTafel";
            cboTafel.Size = new Size(130, 23);
            cboTafel.TabIndex = 9;
            // 
            // cboDagdeel
            // 
            cboDagdeel.Enabled = false;
            cboDagdeel.FormattingEnabled = true;
            cboDagdeel.Items.AddRange(new object[] { "Ochtend 9:00-13:00", "Middag 13:00-17:00" });
            cboDagdeel.Location = new Point(635, 88);
            cboDagdeel.Name = "cboDagdeel";
            cboDagdeel.Size = new Size(130, 23);
            cboDagdeel.TabIndex = 8;
            // 
            // cboWeekDay
            // 
            cboWeekDay.Enabled = false;
            cboWeekDay.FormattingEnabled = true;
            cboWeekDay.Items.AddRange(new object[] { "Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag" });
            cboWeekDay.Location = new Point(635, 55);
            cboWeekDay.Name = "cboWeekDay";
            cboWeekDay.Size = new Size(130, 23);
            cboWeekDay.TabIndex = 7;
            // 
            // lblDagdeel
            // 
            lblDagdeel.AutoSize = true;
            lblDagdeel.Location = new Point(550, 91);
            lblDagdeel.Name = "lblDagdeel";
            lblDagdeel.Size = new Size(50, 15);
            lblDagdeel.TabIndex = 6;
            lblDagdeel.Text = "Dagdeel";
            // 
            // lblDag
            // 
            lblDag.AutoSize = true;
            lblDag.Location = new Point(550, 58);
            lblDag.Name = "lblDag";
            lblDag.Size = new Size(79, 15);
            lblDag.TabIndex = 5;
            lblDag.Text = "Dag v/d week";
            // 
            // lblGebruiker2
            // 
            lblGebruiker2.AutoSize = true;
            lblGebruiker2.Location = new Point(550, 121);
            lblGebruiker2.Name = "lblGebruiker2";
            lblGebruiker2.Size = new Size(58, 15);
            lblGebruiker2.TabIndex = 4;
            lblGebruiker2.Text = "Gebruiker";
            // 
            // lblTafelNr2
            // 
            lblTafelNr2.AutoSize = true;
            lblTafelNr2.Location = new Point(550, 22);
            lblTafelNr2.Name = "lblTafelNr2";
            lblTafelNr2.Size = new Size(47, 15);
            lblTafelNr2.TabIndex = 3;
            lblTafelNr2.Text = "Tafel Nr";
            // 
            // grdTableUsers
            // 
            grdTableUsers.AllowUserToAddRows = false;
            grdTableUsers.AllowUserToDeleteRows = false;
            grdTableUsers.AllowUserToResizeColumns = false;
            grdTableUsers.AllowUserToResizeRows = false;
            grdTableUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdTableUsers.Columns.AddRange(new DataGridViewColumn[] { clmTafelNr2, clmDagVDWeek, clmDagdeel, clmGebruiker2 });
            grdTableUsers.Location = new Point(3, 3);
            grdTableUsers.Name = "grdTableUsers";
            grdTableUsers.Size = new Size(519, 399);
            grdTableUsers.TabIndex = 0;
            // 
            // clmTafelNr2
            // 
            clmTafelNr2.HeaderText = "Tafel Nr";
            clmTafelNr2.Name = "clmTafelNr2";
            clmTafelNr2.Width = 70;
            // 
            // clmDagVDWeek
            // 
            clmDagVDWeek.HeaderText = "Dag van de week";
            clmDagVDWeek.MaxInputLength = 15;
            clmDagVDWeek.Name = "clmDagVDWeek";
            clmDagVDWeek.Width = 120;
            // 
            // clmDagdeel
            // 
            clmDagdeel.HeaderText = "Dagdeel";
            clmDagdeel.Name = "clmDagdeel";
            // 
            // clmGebruiker2
            // 
            clmGebruiker2.HeaderText = "Gebruiker";
            clmGebruiker2.Name = "clmGebruiker2";
            clmGebruiker2.Width = 200;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // frmTafelBezetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(tabMain);
            Name = "frmTafelBezetting";
            Text = "Tafelbezetting";
            tabMain.ResumeLayout(false);
            tabDBConnection.ResumeLayout(false);
            tabDBConnection.PerformLayout();
            tabGebruikers.ResumeLayout(false);
            tabGebruikers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdUsers).EndInit();
            tabTafels.ResumeLayout(false);
            tabTafels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picOfficeLayout).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdTafels).EndInit();
            tabTafelGebruikers.ResumeLayout(false);
            tabTafelGebruikers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdTableUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabMain;
        private TabPage tabGebruikers;
        private TabPage tabTafels;
        private TabPage tabTafelGebruikers;
        private CheckBox chkNo;
        private CheckBox chkYes;
        private Label lblHasLaptop;
        private Label lblName;
        private Label lblUserID;
        private TextBox txtUserName;
        private TextBox txtUserID;
        private DataGridView grdUsers;
        private CheckBox chkNo2;
        private CheckBox chkYes2;
        private TextBox txtTafelNr;
        private Label lblHasNuc;
        private Label lblTafelNr;
        private DataGridView grdTafels;
        private PictureBox picOfficeLayout;
        private DataGridView grdTableUsers;
        private ComboBox cboDagdeel;
        private ComboBox cboWeekDay;
        private Label lblDagdeel;
        private Label lblDag;
        private Label lblGebruiker2;
        private Label lblTafelNr2;
        private ComboBox cboUser;
        private ComboBox cboTafel;
        private Button btnCancel0;
        private Button btnSave0;
        private Button btnNew0;
        private Button btnDelete0;
        private Button btnChange0;
        private Button btnCancel1;
        private Button btnSave1;
        private Button btnNew1;
        private Button btnDelete1;
        private Button btnChange1;
        private Button btnCancel2;
        private Button btnSave2;
        private Button btnNew2;
        private Button btnDelete2;
        private Button btnChange2;
        private DataGridViewTextBoxColumn clmTafelNr;
        private DataGridViewCheckBoxColumn clmHasNUC;
        private DataGridViewTextBoxColumn clmTafelNr2;
        private DataGridViewTextBoxColumn clmDagVDWeek;
        private DataGridViewTextBoxColumn clmDagdeel;
        private DataGridViewTextBoxColumn clmGebruiker2;
        private DataGridViewTextBoxColumn clmUserID;
        private DataGridViewTextBoxColumn clmNaam;
        private DataGridViewCheckBoxColumn clmHasLaptop;
        private TabPage tabDBConnection;
        private TextBox txtPassword;
        private TextBox txtUser;
        private Label lblPassword;
        private Label lblUserName;
        private TextBox txtIPAddress;
        private Label lblIPAddress;
        private Label label1;
        private Label lblMessage;
        private Button btnConnect;
        private Button btnCreateDB;
    }
}
