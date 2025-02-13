using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
using System.Drawing.Text;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Expr;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Tafelbezetting
{

    public partial class frmTafelBezetting : Form
    {
        string mstrConnectionString; //= "server=77.61.6.211;database=Tafelbezetting;uid=admin;pwd=";
        bool mbooTab0New = false;
        bool mbooTab1New = false;
        bool mbooTab2New = false;

        class IniFile
        {
            private string path;


            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder returnValue, int size, string path);

            public IniFile(string iniPath)
            {
                path = iniPath;
            }

            public void Write(string section, string key, string value)
            {
                WritePrivateProfileString(section, key, value, path);
            }

            public string Read(string section, string key, string defaultValue = "")
            {
                StringBuilder result = new StringBuilder(255);
                GetPrivateProfileString(section, key, defaultValue, result, result.Capacity, path);
                return result.ToString();
            }
        }

        //Gebruikers data in geheugen
        private clsGebruikers mclsgebruikers;
        private class clsGebruiker
        {
            private int intID;
            public int ID
            {
                get { return intID; }
                set { intID = value; }
            }

            private string strNaam;
            public string Naam
            {
                get { return strNaam; }
                set { strNaam = value; }
            }

            private int intHasLaptop;
            public int HasLaptop
            {
                get { return intHasLaptop; }
                set { intHasLaptop = value; }
            }
        }

        private class clsGebruikers
        {
            private List<clsGebruiker> mclsGebruikers = new List<clsGebruiker>();

            public void AddItem(clsGebruiker mclsgebruiker)
            {
                mclsGebruikers.Add(mclsgebruiker);
            }

            //Dit is een property (geen parameter)
            public int Count
            {
                get => mclsGebruikers.Count;
            }

            //Vind de gebruikersnaam behorende bij een ID
            public string GebruikersNaam(int intZoekID)
            {
                string strGebruikersNaam = "";
                for (int i = 0; i < Count; i++)
                {
                    if (Item(i).ID == intZoekID) { strGebruikersNaam = Item(i).Naam; }
                }
                return strGebruikersNaam;
            }

            // Property met parameter is niet mogelijk in C#. Daarom is het hier een functie.
            public clsGebruiker Item(int index)
            {
                return mclsGebruikers[index];
            }
        }

        //Tafel data in geheugen
        private clsTafels mclstafels;
        private class clsTafel
        {
            private int intID;
            public int ID
            {
                get { return intID; }
                set { intID = value; }
            }

            private int intHasNUC;
            public int HasNUC
            {
                get { return intHasNUC; }
                set { intHasNUC = value; }
            }
        }

        private class clsTafels
        {
            private List<clsTafel> mclsTafels = new List<clsTafel>();

            public void AddItem(clsTafel mclstafel)
            {
                mclsTafels.Add(mclstafel);
            }

            //Dit is een property (geen parameter)
            public int Count
            {
                get => mclsTafels.Count;
            }

            // Property met parameter is niet mogelijk in C#. Daarom is het hier een functie.
            public clsTafel Item(int index)
            {
                return mclsTafels[index];
            }
        }

        //Tafel data in geheugen
        private clsTafelGebruikers mclstafelgebruikers;
        private class clsTafelGebruiker
        {
            private int intTafelNr;
            public int TafelNr
            {
                get { return intTafelNr; }
                set { intTafelNr = value; }
            }

            private int intGebruikerID;
            public int GebruikerID
            {
                get { return intGebruikerID; }
                set { intGebruikerID = value; }
            }

            // 0 Empty / NULL in db
            // 1 Monday
            // 2 Tuesday
            // 3 Wednesday
            // 4 Thursday
            // 5 Friday
            // 6 Saturday 
            // 7 Sunday
            private int intWeekDay;
            public int WeekDay
            {
                get { return intWeekDay; }
                set { intWeekDay = value; }
            }
            public string DayName
            {
                get
                {
                    string strDay;
                    strDay = "";
                    if (intWeekDay == 1) { strDay = "Maandag"; }
                    if (intWeekDay == 2) { strDay = "Dinsdag"; }
                    if (intWeekDay == 3) { strDay = "Woensdag"; }
                    if (intWeekDay == 4) { strDay = "Donderdag"; }
                    if (intWeekDay == 5) { strDay = "Vrijdag"; }
                    if (intWeekDay == 6) { strDay = "Zaterdag"; }
                    if (intWeekDay == 7) { strDay = "Zondag"; }

                    return strDay;
                }
            }


            // 0 Empty / NULL in db
            // 1 Morning
            // 2 Afternoon
            // 3 Evening
            // 4 Night
            private int intPeriod;
            public int Period
            {
                get { return intPeriod; }
                set { intPeriod = value; }
            }
            public string PeriodName
            {
                get
                {
                    string strPeriod;
                    strPeriod = "";
                    if (intPeriod == 1) { strPeriod = "Ochtend"; }
                    if (intPeriod == 2) { strPeriod = "Middag"; }
                    if (intPeriod == 3) { strPeriod = "Avond"; }
                    if (intPeriod == 4) { strPeriod = "Nacht"; }

                    return strPeriod;
                }
            }
        }

        private class clsTafelGebruikers
        {
            private List<clsTafelGebruiker> mclsTafelGebruikers = new List<clsTafelGebruiker>();

            public void AddItem(clsTafelGebruiker clstafelgebruiker)
            {
                mclsTafelGebruikers.Add(clstafelgebruiker);
            }

            //Dit is een property (geen parameter)
            public int Count
            {
                get => mclsTafelGebruikers.Count;
            }

            // Property met parameter is niet mogelijk in C#. Daarom is het hier een functie.
            public clsTafelGebruiker Item(int index)
            {
                return mclsTafelGebruikers[index];
            }
        }

        public frmTafelBezetting()
        {
            InitializeComponent();
            ReadIniFile();
            if (ConnectDB() == true)
            {
                lblMessage.Text = "Connection to database succeeded.";
                tabGebruikers.Enabled = true;
                tabTafels.Enabled = true;
                tabTafelGebruikers.Enabled = true;
                LockTab0();
                LoadGebruikers();
                FillGebruikers();
                LockTab1();
                LoadTafels();
                FillTafels();
                LockTab2();
                LoadTafelGebruikers();
                FillTafelGebruikers();
            }
            else
            {
                lblMessage.Text = "Could not connect to database.";
                tabGebruikers.Enabled = false;
                tabTafels.Enabled = false;
                tabTafelGebruikers.Enabled = false;
            }
        }

        private void ReadIniFile()
        {
            IniFile ini = new IniFile(Application.StartupPath + "\\config.ini");
            string strIPAddress = ini.Read("Settings", "IPADDRESS");
            txtIPAddress.Text = strIPAddress;
            string strUserName = ini.Read("Settings", "Value2");
            txtUser.Text = strUserName;
            string strPassword = ini.Read("Settings", "Value3");
            txtPassword.Text = strPassword;
        }

        private void WriteIniFile()
        {
            IniFile ini = new IniFile(Application.StartupPath + "\\config.ini");
            ini.Write("Settings", "IPADDRESS", txtIPAddress.Text);
            ini.Write("Settings", "Value2", txtUser.Text);
            ini.Write("Settings", "Value3", txtPassword.Text);
        }

        private bool ConnectDB()
        {
            mstrConnectionString = "server=" + txtIPAddress.Text + ";";
            mstrConnectionString = mstrConnectionString + "database=Tafelbezetting;uid=" + txtUser.Text + ";pwd=" + txtPassword.Text;
            bool booConnect = false;

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = mstrConnectionString;

            try
            {
                conn.Open();
                booConnect = true;
                conn.Close();
            }
            catch
            {
                booConnect = false;
            }
            return booConnect;
        }

        private void CreateDatabase()
        {
            string strConnectionString;
            string strSQL;
            string strSQL2;
            string strSQL3;
            string strSQL4;

            strConnectionString = "server=" + txtIPAddress.Text + ";";
            strConnectionString = strConnectionString + ";uid=" + txtUser.Text + ";pwd=" + txtPassword.Text;

            strSQL = "CREATE DATABASE IF NOT EXISTS `Tafelbezetting`;USE `Tafelbezetting`;";
            strSQL2 = "CREATE TABLE IF NOT EXISTS `Gebruikers` (`GebruikersID` int NOT NULL, `Naam` varchar(50) NOT NULL DEFAULT '', `HasLaptop` bit(1) DEFAULT NULL, PRIMARY KEY (`GebruikersID`));";
            strSQL3 = "CREATE TABLE IF NOT EXISTS `Tafels` ( `TafelID` int NOT NULL, `ComputerPresent` bit(1) DEFAULT b'0', PRIMARY KEY (`TafelID`));";
            strSQL4 = "CREATE TABLE IF NOT EXISTS `TafelGebruikers` ( `TafelID` int NOT NULL, `DagInDeWeek` smallint NOT NULL, `Periode` smallint NOT NULL, `UserID` smallint NOT NULL, UNIQUE KEY `TafelID_UserID_DagInDeWeek_Periode` (`TafelID`,`DagInDeWeek`,`Periode`));";

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = strConnectionString;

            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(strSQL, conn);
                command.ExecuteNonQuery();
                command = new MySqlCommand(strSQL2, conn);
                command.ExecuteNonQuery();
                command = new MySqlCommand(strSQL3, conn);
                command.ExecuteNonQuery();
                command = new MySqlCommand(strSQL4, conn);
                command.ExecuteNonQuery();

                conn.Close();
            }
            catch (MySqlException e)
            {
                e = e;
            }

        }

        private void LoadGebruikers()
        {
            string strSQL;

            strSQL = "SELECT GebruikersID, Naam, HasLaptop FROM Gebruikers";

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = mstrConnectionString;

            try
            {
                mclsgebruikers = new clsGebruikers();
                conn.Open();
                MySqlCommand command = new MySqlCommand(strSQL, conn);
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            clsGebruiker clsgebruiker = new clsGebruiker();
                            clsgebruiker.ID = reader.GetInt32(0);
                            clsgebruiker.Naam = reader.GetString(1);
                            clsgebruiker.HasLaptop = reader.GetInt32(2);
                            mclsgebruikers.AddItem(clsgebruiker);
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                e = e;
            }
        }

        //Fill gebruikers
        private void FillGebruikers()
        {
            FillGebruikersGrid();
            FillGebruikersCombo();
        }

        private void FillGebruikersGrid()
        {
            //Disable extra row voor nieuwe
            grdUsers.AllowUserToAddRows = false;
            grdUsers.ReadOnly = true;
            //Clear the datagridview before refilling it
            grdUsers.Rows.Clear();
            //Selecteer hele rijen, geen cellen
            grdUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < mclsgebruikers.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(grdUsers);
                newRow.Cells[0].Value = mclsgebruikers.Item(i).ID.ToString();
                newRow.Cells[1].Value = mclsgebruikers.Item(i).Naam;
                newRow.Cells[2].Value = mclsgebruikers.Item(i).HasLaptop;

                grdUsers.Rows.Add(newRow);
            }
        }

        private void FillGebruikersCombo()
        {
            cboUser.Items.Clear();
            cboUser.Items.Add("");
            for (int i = 0; i < mclsgebruikers.Count; i++)
            {
                cboUser.Items.Add(mclsgebruikers.Item(i).Naam);
            }

        }

        private void LoadTafels()
        {
            string strSQL;

            strSQL = "SELECT TafelID, ComputerPresent FROM Tafels";

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = mstrConnectionString;

            try
            {
                mclstafels = new clsTafels();
                conn.Open();
                MySqlCommand command = new MySqlCommand(strSQL, conn);
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            clsTafel clstafel = new clsTafel();
                            clstafel.ID = reader.GetInt32(0);
                            clstafel.HasNUC = reader.GetInt32(1);
                            mclstafels.AddItem(clstafel);
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                e = e;
            }
        }

        private void FillTafels()
        {
            FillTafelsGrid();
            FillTafelsCombo();
        }

        private void FillTafelsGrid()
        {
            //Selecteer hele rijen, geen cellen
            grdTafels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Disable extra row voor nieuwe
            grdTafels.AllowUserToAddRows = false;
            grdTafels.ReadOnly = true;
            grdTafels.Rows.Clear();
            for (int i = 0; i < mclstafels.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(grdTafels);
                newRow.Cells[0].Value = mclstafels.Item(i).ID.ToString();
                newRow.Cells[1].Value = mclstafels.Item(i).HasNUC;

                grdTafels.Rows.Add(newRow);
            }
        }

        private void FillTafelsCombo()
        {
            cboTafel.Items.Clear();
            cboTafel.Items.Add("");
            for (int i = 0; i < mclstafels.Count; i++)
            {
                cboTafel.Items.Add(mclstafels.Item(i).ID);
            }

        }

        private void LoadTafelGebruikers()
        {
            string strSQL;

            strSQL = "SELECT TafelID, DagInDeWeek, Periode, UserID FROM TafelGebruikers ORDER BY TafelID ASC, DAgInDeWeek ASC, Periode ASC";

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = mstrConnectionString;

            try
            {
                mclstafelgebruikers = new clsTafelGebruikers();
                conn.Open();
                MySqlCommand command = new MySqlCommand(strSQL, conn);
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            clsTafelGebruiker clstafelgebruiker = new clsTafelGebruiker();
                            clstafelgebruiker.TafelNr = reader.GetInt32(0);
                            clstafelgebruiker.WeekDay = reader.GetInt32(1);
                            clstafelgebruiker.Period = reader.GetInt32(2);
                            clstafelgebruiker.GebruikerID = reader.GetInt32(3);
                            mclstafelgebruikers.AddItem(clstafelgebruiker);
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                e = e;
            }
        }

        //Fill gebruikers
        private void FillTafelGebruikers()
        {
            FillTafelGebruikersGrid();
        }

        private void FillTafelGebruikersGrid()
        {
            //Selecteer hele rijen, geen cellen
            grdTableUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Disable extra row voor nieuwe
            grdTableUsers.AllowUserToAddRows = false;
            grdTableUsers.ReadOnly = true;
            grdTableUsers.Rows.Clear();
            for (int i = 0; i < mclstafelgebruikers.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(grdTableUsers);
                newRow.Cells[0].Value = mclstafelgebruikers.Item(i).TafelNr.ToString();
                //Gebruikersnaam ophalen met ID in mclsgebruikers
                newRow.Cells[1].Value = mclstafelgebruikers.Item(i).DayName;
                newRow.Cells[2].Value = mclstafelgebruikers.Item(i).PeriodName;
                int intGebruikersID;
                string strGebruikersNaam;

                intGebruikersID = mclstafelgebruikers.Item(i).GebruikerID;
                strGebruikersNaam = mclsgebruikers.GebruikersNaam(intGebruikersID);
                newRow.Cells[3].Value = strGebruikersNaam;

                grdTableUsers.Rows.Add(newRow);
            }
        }

        private void UnlockTab0()
        {
            //UserId is automatically generated, and with an update it stays the same
            txtUserID.Enabled = false;
            txtUserID.BackColor = Color.LightGray;
            txtUserName.Enabled = true;
            txtUserName.BackColor = Color.White;
            chkNo.Enabled = true;
            chkYes.Enabled = true;
        }

        private void LockTab0()
        {
            //UserId is automatically generated, and with an update it stays the same
            txtUserID.Enabled = false;
            txtUserID.BackColor = Color.LightGray;
            txtUserName.Enabled = false;
            txtUserName.BackColor = Color.LightGray;
            chkNo.Enabled = false;
            chkYes.Enabled = false;
        }

        private void ClearTab0()
        {
            txtUserID.Text = "";
            txtUserName.Text = "";
            chkNo.Checked = false;
            chkYes.Checked = false;
        }

        private void UnlockTab1()
        {
            //TableNr is automatically generated, and with an update it stays the same
            txtTafelNr.Enabled = false;
            txtTafelNr.BackColor = Color.LightGray;
            chkNo2.Enabled = true;
            chkYes2.Enabled = true;
        }

        private void LockTab1()
        {
            //TableNr is automatically generated, and with an update it stays the same
            txtTafelNr.Enabled = false;
            txtTafelNr.BackColor = Color.LightGray;
            chkNo2.Enabled = false;
            chkYes2.Enabled = false;
        }

        private void ClearTab1()
        {
            txtTafelNr.Text = "";
            chkNo2.Checked = false;
            chkYes2.Checked = false;
        }

        private void UnlockTab2()
        {
            cboTafel.Enabled = true;
            cboTafel.BackColor = Color.White;
            cboUser.Enabled = true;
            cboUser.BackColor = Color.White;
            cboWeekDay.Enabled = true;
            cboWeekDay.BackColor = Color.White;
            cboDagdeel.Enabled = true;
            cboDagdeel.BackColor = Color.White;
        }

        private void LockTab2()
        {
            cboTafel.Enabled = false;
            cboTafel.BackColor = Color.LightGray;
            cboUser.Enabled = false;
            cboUser.BackColor = Color.LightGray;
            cboWeekDay.Enabled = false;
            cboWeekDay.BackColor = Color.LightGray;
            cboDagdeel.Enabled = false;
            cboDagdeel.BackColor = Color.LightGray;
        }

        private void ClearTab2()
        {
            cboTafel.SelectedIndex = 0;
            cboUser.SelectedIndex = 0;
            cboWeekDay.SelectedIndex = 0;
            cboDagdeel.SelectedIndex = 0;
        }

        private string GetQueryValue(bool booCheckYes, bool booCheckNo)
        {
            string strTemp;
            if (booCheckNo == true && booCheckYes == false)
            {
                strTemp = "FALSE";
            }
            else if (booCheckYes == true && booCheckNo == false)
            {
                strTemp = "TRUE";
            }
            else if (booCheckNo == false && booCheckYes == false)
            {
                strTemp = "NULL";
            }
            else
            {
                //Error, cant be both true, it is either yes or no or NULL
                strTemp = "NULL";
            }

            return strTemp;
        }
        private void btnChange0_Click(object sender, EventArgs e)
        {
            int intRow;
            if (grdUsers.SelectedRows.Count == 0)
            {
                intRow = -1;
            }
            else
            {
                intRow = grdUsers.SelectedRows[0].Index;
            }

            if (intRow > -1)
            {
                mbooTab0New = false;
                UnlockTab0();

                //Get data of selected row to the form controls
                txtUserID.Text = mclsgebruikers.Item(intRow).ID.ToString();
                txtUserName.Text = mclsgebruikers.Item(intRow).Naam.ToString();
                if (mclsgebruikers.Item(intRow).HasLaptop == 0)
                {
                    chkNo.Checked = true;
                    chkYes.Checked = false;
                }
                else
                {
                    chkNo.Checked = false;
                    chkYes.Checked = true;
                }
            }
        }

        private void btnChange1_Click(object sender, EventArgs e)
        {
            int intRow;
            if (grdTafels.SelectedRows.Count == 0)
            {
                intRow = -1;
            }
            else
            {
                intRow = grdTafels.SelectedRows[0].Index;
            }

            if (intRow > -1)
            {
                mbooTab1New = false;
                UnlockTab1();

                //Get data of selected row and put it in the form
                txtTafelNr.Text = mclstafels.Item(intRow).ID.ToString();
                if (mclstafels.Item(intRow).HasNUC == 0)
                {
                    chkNo2.Checked = true;
                    chkYes2.Checked = false;
                }
                else
                {
                    chkNo2.Checked = false;
                    chkYes2.Checked = true;
                }
            }
        }

        private void btnChange2_Click(object sender, EventArgs e)
        {
            int intRow;
            if (grdTableUsers.SelectedRows.Count == 0)
            {
                intRow = -1;
            }
            else
            {
                intRow = grdTableUsers.SelectedRows[0].Index;
            }

            if (intRow > -1)
            {
                mbooTab2New = false;
                UnlockTab2();

                //Get data of selected row and put it in the form
                cboTafel.SelectedIndex = cboTafel.FindString(mclstafelgebruikers.Item(intRow).TafelNr.ToString());
                cboWeekDay.SelectedIndex = cboWeekDay.FindString(mclstafelgebruikers.Item(intRow).DayName);
                cboDagdeel.SelectedIndex = cboDagdeel.FindString(mclstafelgebruikers.Item(intRow).PeriodName);
                string strUserName;
                int intUserID;

                intUserID = mclstafelgebruikers.Item(intRow).GebruikerID;
                strUserName = mclsgebruikers.GebruikersNaam(intUserID);
                cboUser.SelectedIndex = cboUser.FindString(strUserName);
            }

        }

        private void btnSave0_Click(object sender, EventArgs e)
        {
            if (mbooTab0New == false)
            {
                int intRow;
                if (grdUsers.SelectedRows.Count == 0)
                {
                    intRow = -1;
                }
                else
                {
                    intRow = grdUsers.SelectedRows[0].Index;
                }

                //Update Query
                string strQuery;
                strQuery = "UPDATE Gebruikers SET Naam='" + txtUserName.Text + "', HasLaptop=";
                strQuery = strQuery + GetQueryValue(chkYes.Checked, chkNo.Checked);
                strQuery = strQuery + " WHERE GebruikersID=" + txtUserID.Text;

                //Execute Query
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = mstrConnectionString;

                try
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(strQuery, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                catch (MySqlException er)
                {
                    er = er;
                }
                ClearTab0();
                LockTab0();
                LoadGebruikers();
                FillGebruikers();
                LoadTafelGebruikers();
                FillTafelGebruikers();
            }
        }

        private void btnDelete0_Click(object sender, EventArgs e)
        {
            int intRow;
            if (grdUsers.SelectedRows.Count == 0)
            {
                intRow = -1;
            }
            else
            {
                intRow = grdUsers.SelectedRows[0].Index;
            }

            if (intRow > -1)
            {
                //Get data of selected row to the form controls
                int intUserID;

                intUserID = mclsgebruikers.Item(intRow).ID;
                //Update Query
                string strQuery;
                string strQuery2;

                strQuery = "DELETE FROM Gebruikers WHERE GebruikersID='" + intUserID.ToString() + "'";
                //Ook wissen van Tafelgebruikers. die user bestaat nu niet meer.
                strQuery2 = "DELETE FROM TafelGebruikers WHERE UserID='" + intUserID.ToString() + "'";

                //Execute Query
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = mstrConnectionString;

                try
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(strQuery, conn);
                    command.ExecuteNonQuery();
                    command = new MySqlCommand(strQuery2, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                catch (MySqlException er)
                {
                    er = er;
                }
                LoadGebruikers();
                FillGebruikers();
                LoadTafelGebruikers();
                FillTafelGebruikers();

            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            int intRow;
            if (grdTafels.SelectedRows.Count == 0)
            {
                intRow = -1;
            }
            else
            {
                intRow = grdTafels.SelectedRows[0].Index;
            }

            if (intRow > -1)
            {
                //Get data of selected row to the form controls
                int intTafelID;

                intTafelID = mclstafels.Item(intRow).ID;
                //Update Query
                string strQuery;
                string strQuery2;

                strQuery = "DELETE FROM Tafels WHERE TafelID=" + intTafelID.ToString();
                //Ook wissen van Tafelgebruikers. die tafel bestaat nu niet meer.
                strQuery2 = "DELETE FROM TafelGebruikers WHERE TafelID=" + intTafelID.ToString();

                //Execute Query
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = mstrConnectionString;

                try
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(strQuery, conn);
                    command.ExecuteNonQuery();
                    command = new MySqlCommand(strQuery2, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                catch (MySqlException er)
                {
                    er = er;
                }
                LoadTafels();
                FillTafels();
                LoadTafelGebruikers();
                FillTafelGebruikers();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            int intRow;
            if (grdTableUsers.SelectedRows.Count == 0)
            {
                intRow = -1;
            }
            else
            {
                intRow = grdTableUsers.SelectedRows[0].Index;
            }

            if (intRow > -1)
            {
                //Get data of selected row to the form controls
                int intTafelID;
                int intDagVDWeek;
                int intDagdeel;

                intTafelID = mclstafelgebruikers.Item(intRow).TafelNr;
                intDagVDWeek = mclstafelgebruikers.Item(intRow).WeekDay;
                intDagdeel = mclstafelgebruikers.Item(intRow).Period;
                //Update Query
                string strQuery;

                strQuery = "DELETE FROM TafelGebruikers WHERE TafelID=" + intTafelID.ToString();
                strQuery = strQuery + " AND WeekDay=" + intDagVDWeek.ToString();
                strQuery = strQuery + " AND Dagdeel=" + intDagdeel.ToString();

                //Execute Query
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = mstrConnectionString;

                try
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(strQuery, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                catch (MySqlException er)
                {
                    er = er;
                }
                LoadTafelGebruikers();
                FillTafelGebruikers();
            }

        }

        bool mbooIPChanged = false;

        private void txtIPAddress_TextChanged(object sender, EventArgs e)
        {
            mbooIPChanged = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (ConnectDB() == true)
            {
                lblMessage.Text = "Connection to database succeeded.";
                tabGebruikers.Enabled = true;
                tabTafels.Enabled = true;
                tabTafelGebruikers.Enabled = true;
                WriteIniFile();
                LockTab0();
                LoadGebruikers();
                FillGebruikers();
                LockTab1();
                LoadTafels();
                FillTafels();
                LockTab2();
                LoadTafelGebruikers();
                FillTafelGebruikers();
            }
            else
            {
                lblMessage.Text = "Could not connect to database.";
                tabGebruikers.Enabled = false;
                tabTafels.Enabled = false;
                tabTafelGebruikers.Enabled = false;
            }
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            CreateDatabase();
        }
    }
}
