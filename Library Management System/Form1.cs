using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += new EventHandler(listBox2_Load);
            Load += new EventHandler(listBox3_Load);
            Load += new EventHandler(listBox4_Load);
        }    
            
        private void listBox2_Load(object sender, System.EventArgs e)
        {
            /*Connect with Database.*/
            OleDbConnection dbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data source=C:\\Users\\Dell\\Documents\\Library-db.mdb; Persist Security Info=False;");
            dbcon.Open();

            OleDbCommand sqlcommand = new OleDbCommand("select * from tblArtifacts where Type = 'Book'", dbcon);
            OleDbDataReader rd = sqlcommand.ExecuteReader(); // Execute the sql command and store the results in a reader object

            while (rd.Read())
            {
                listBox2.Items.Add(rd.GetString(1) + "                              " + rd.GetString(10));
            }
        }

        private void listBox3_Load(object sender, System.EventArgs e)
        {
            /*Connect with Database.*/
            OleDbConnection dbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data source=C:\\Users\\Dell\\Documents\\Library-db.mdb; Persist Security Info=False;");
            dbcon.Open();

            OleDbCommand sqlcommand = new OleDbCommand("select * from tblArtifacts where Type = 'Journal'", dbcon);
            OleDbDataReader rd = sqlcommand.ExecuteReader(); // Execute the sql command and store the results in a reader object

            while (rd.Read())
            {
                listBox3.Items.Add(rd.GetString(1) + "                              " + rd.GetString(10));
            }
        }

        private void listBox4_Load(object sender, System.EventArgs e)
        {
            /*Connect with Database.*/
            OleDbConnection dbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data source=C:\\Users\\Dell\\Documents\\Library-db.mdb; Persist Security Info=False;");
            dbcon.Open();

            OleDbCommand sqlcommand = new OleDbCommand("select * from tblArtifacts where Type = 'DVD'", dbcon);
            OleDbDataReader rd = sqlcommand.ExecuteReader(); // Execute the sql command and store the results in a reader object

            while (rd.Read())
            {
                listBox4.Items.Add(rd.GetString(1) + "                              " + rd.GetString(10));
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Get user input*/
            string option = comboBox1.Text;           

            if(option=="Author")
            {
                label2.Visible = true;
                textBox1.Visible = true;
            }

            else if(option == "Title")
            {
                label4.Visible = true;
                textBox2.Visible = true;
            }

            else if(option == "Genre")
            {
                label5.Visible = true;
                textBox3.Visible = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string option = comboBox1.Text;

            /*Connect with Database.*/
            OleDbConnection dbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data source=C:\\Users\\Dell\\Documents\\Library-db.mdb; Persist Security Info=False;");
            dbcon.Open();
            
      
            if (option=="Author")
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Title                                     Status");
                OleDbCommand sqlcommand = new OleDbCommand("select * from tblArtifacts where Author = '" + textBox1.Text + "'", dbcon);
                OleDbDataReader rd = sqlcommand.ExecuteReader(); // Execute the sql command and store the results in a reader object
                listBox1.Visible = true;

                while (rd.Read())
                {
                    listBox1.Items.Add(rd.GetString(1)+"                              "+ rd.GetString(10));
                }
            }

            else if (option == "Title")
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Title                                     Status");
                OleDbCommand sqlcommand = new OleDbCommand("select * from tblArtifacts where Title = '" + textBox2.Text + "'", dbcon);
                OleDbDataReader rd = sqlcommand.ExecuteReader(); // Execute the sql command and store the results in a reader object
                listBox1.Visible = true;

                while (rd.Read())
                {
                    listBox1.Items.Add(rd.GetString(1) + "                              " + rd.GetString(10));
                }
            }

            else if(option == "Genre")
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Title                                     Status");
                OleDbCommand sqlcommand = new OleDbCommand("select * from tblArtifacts where Genre = '" + textBox3.Text + "'", dbcon);
                OleDbDataReader rd = sqlcommand.ExecuteReader(); // Execute the sql command and store the results in a reader object
                listBox1.Visible = true;

                while (rd.Read())
                {
                    listBox1.Items.Add(rd.GetString(1) + "                           " + rd.GetString(10));
                }
            }


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        //function to update fine
        //needs to be called when a user logs in and pass userID into it
        public void update_fine(string user_id)
        {
            /*Connect with Database.*/
            OleDbConnection dbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data source=C:\\Users\\Zara\\Downloads\\SC-Lab2-master\\SC-Lab2-master\\Library-db.mdb; Persist Security Info=False;");
            dbcon.Open();
            OleDbCommand my_command = new OleDbCommand("select * from tblIssue where UserID = 'CG905'", dbcon);
            DateTime Issue_Date;
            DateTime Last_Updated;
            var dateAndTime = DateTime.Now;
            var current_date = dateAndTime.Date;
            OleDbCommand sqlcommand = new OleDbCommand("select * from tblArtifacts where Type = 'Book'", dbcon);
            OleDbDataReader rd = my_command.ExecuteReader(); // Execute the sql command and store the results in a reader object

            while (rd.Read())
            {
                Issue_Date = rd.GetDateTime(2);
                Last_Updated = rd.GetDateTime(4);
                var fine = rd.GetDecimal(3);
                var artifact = rd.GetString(0);


                if (Last_Updated.Month < current_date.Month && (current_date - Issue_Date).Days > 30)
                {
                    //find out if book orjournal
                    OleDbCommand command1 = new OleDbCommand("select Type from tblArtifacts where ArtifactID = '" + artifact + "'", dbcon);
                    OleDbDataReader r = command1.ExecuteReader();
                    while (r.Read())
                    {

                        if (r.GetString(0) == "Journal")
                        {
                            fine = fine + 100;
                        }
                        else if (r.GetString(0) == "Book")
                        {
                            fine = fine + 50;
                        }
                    }


                    //update cost
                    OleDbCommand command = new OleDbCommand(@"UPDATE tblIssue
                                                    SET LastUpdated = @p1,
                                                        Fines = @p2
                                                    WHERE UserID = @p3", dbcon);

                    command.Parameters.AddWithValue("@p1", current_date);
                    command.Parameters.AddWithValue("@p2", fine);
                    command.Parameters.AddWithValue("@p3", user_id);
                    command.ExecuteNonQuery();
                }
            }
        
    }
}
