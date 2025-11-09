using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UD
{
    public partial class DelTakeForm : Form
    {
        List<string> list = new List<string>();
        static SQLiteConnection connection;
        static SQLiteCommand command;
        int numlist = 0, listind = 0;
        public DelTakeForm()
        {
            InitializeComponent();
            try
            {
                connection = new SQLiteConnection("Data Source=Library.sqlite;Version=3; FailIfMissing=False");
                connection.Open();
                command = new SQLiteCommand(connection);

            }
            catch (SQLiteException ex)
            {
            }
            command.CommandText = "SELECT * FROM Writer";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(Convert.ToString(reader["WriterId"]));
                    numlist++;
                }
            }
            ListIndChange();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            list.Clear();
            numlist = 0;
            listind = 0;
            if (tabControl1.SelectedTab == tabPage1)
            {
                command.CommandText = "SELECT * FROM Writer";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Convert.ToString(reader["WriterId"]));
                        numlist++;
                    }
                }
            }
            else if(tabControl1.SelectedTab ==tabPage2)
            {
                command.CommandText = "SELECT * FROM Genres";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Convert.ToString(reader["GenresID"]));
                        numlist++;
                    }
                }
            }
            else if (tabControl1.SelectedTab == tabPage3) {
                command.CommandText = "SELECT * FROM Books";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Convert.ToString(reader["BookID"]));
                        numlist++;
                    }
                }
            }
            else if (tabControl1.SelectedTab == tabPage4) {
                command.CommandText = "SELECT * FROM Employer";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Convert.ToString(reader["EmplID"]));
                        numlist++;
                    }
                }
            }
            else if (tabControl1.SelectedTab == tabPage5) {
                command.CommandText = "SELECT * FROM Reader";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Convert.ToString(reader["ReaderID"]));
                        numlist++;
                    }
                }
            }
            else if (tabControl1.SelectedTab == tabPage6) {
                command.CommandText = "SELECT * FROM Extradition";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Convert.ToString(reader["IDExtr"]));
                        numlist++;
                    }
                }
            }
            ListIndChange();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listind++;
            if (listind >= numlist)
            {
                listind=0;
            }
            ListIndChange();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1){command.CommandText = "DELETE FROM Writer WHERE WriterId = ('" + list[listind] + "')";}
            else if (tabControl1.SelectedTab == tabPage2) {command.CommandText = "DELETE FROM Genres WHERE GenresID = ('" + list[listind] + "')"; }
            else if (tabControl1.SelectedTab == tabPage3) {command.CommandText = "DELETE FROM Books WHERE BookID = ('" + list[listind] + "')"; }
            else if (tabControl1.SelectedTab == tabPage4) {command.CommandText = "DELETE FROM Employer WHERE EmplID = ('" + list[listind] + "')"; }
            else if (tabControl1.SelectedTab == tabPage5) {command.CommandText = "DELETE FROM Reader WHERE ReaderID = ('" + list[listind] + "')"; }
            else if (tabControl1.SelectedTab == tabPage6) {command.CommandText = "DELETE FROM Extradition WHERE IDExtr = ('" + list[listind] + "')"; }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            command.ExecuteNonQuery();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2) { 
                command.CommandText = "UPDATE Genres SET GenreInfo ='"+ textBox3.Text.ToString() +"' WHERE GenresID = ('" + list[listind] + "')"; 
            }
            else if (tabControl1.SelectedTab == tabPage3) { 
                command.CommandText = "UPDATE Books SET WriteDate ='"+ textBox5.Text.ToString()+"', PublishDate ='"+ textBox6.Text.ToString()+"', BooksNum = '"+ textBox9.Text.ToString() + "', Pages ='"+ textBox8.Text.ToString() + "' WHERE BookID = ('" + list[listind] + "')"
                    ; }
            else if (tabControl1.SelectedTab == tabPage4) { 
                command.CommandText = "Update Employer SET EmplFIO ='"+ textBox12.Text.ToString() +"', EmplDateOfBirth='"+ textBox13.Text.ToString()+"' WHERE EmplID = ('" + list[listind] + "')"; 
            }
            else if (tabControl1.SelectedTab == tabPage5) { 
                command.CommandText = "Update Reader SET ReaderFIO ='" + textBox15.Text.ToString() + "', ReaderDateOfBirth='" + textBox14.Text.ToString() + "', ReadTicket = '"+ (checkBox1.Checked ? "1" : "0") + "' WHERE ReaderID = ('" + list[listind] + "')"; 
            }
            else if (tabControl1.SelectedTab == tabPage6) { 
                command.CommandText = "Update Extradition SET DateOut ='"+textBox20.Text.ToString()+"', BookState ='"+comboBox3.Text.ToString()+"' WHERE IDExtr = ('" + list[listind] + "')";
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            command.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listind--;
            if (listind < 0)
            {
                listind = numlist-1;
            }
            ListIndChange();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listind=numlist-1;
            ListIndChange();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listind = 0;
            ListIndChange();
        }

        private void ListIndChange()
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    command.CommandText = "SELECT * FROM Writer WHERE WriterId='" + list[listind] + "'";

                    textBox10.Text = list[listind].ToString();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox1.Text = Convert.ToString(reader["WriterFIO"]);
                        }
                    }
                }
                else if (tabControl1.SelectedTab == tabPage2) {
                    command.CommandText = "SELECT * FROM Genres WHERE GenresID='" + list[listind] + "'";

                    textBox16.Text = list[listind].ToString();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox2.Text = Convert.ToString(reader["GenreName"]);
                            textBox3.Text = Convert.ToString(reader["GenreInfo"]);
                        }
                    }
                }
                else if (tabControl1.SelectedTab == tabPage3) {
                    command.CommandText = "SELECT b.*, w.WriterFIO, g.GenreName FROM 'Books' b LEFT JOIN 'Writer' w, 'Genres' g ON b.IdWriter = w.WriterId AND b.IdGenre = g.GenresID WHERE BookID ='" + list[listind] + "'";
                    textBox25.Text = list[listind].ToString();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox23.Text = Convert.ToString(reader["BookName"]);
                            textBox24.Text = Convert.ToString(reader["GenreName"]);
                            textBox19.Text = Convert.ToString(reader["WriterFIO"]);
                            textBox5.Text = Convert.ToString(reader["WriteDate"]);
                            textBox6.Text = Convert.ToString(reader["PublishDate"]);
                            textBox7.Text = Convert.ToString(reader["Publisher"]);
                            textBox8.Text = Convert.ToString(reader["Pages"]);
                            textBox9.Text = Convert.ToString(reader["BooksNum"]);
                            textBox11.Text = Convert.ToString(reader["BookInfo"]);
                            textBox17.Text = Convert.ToString(reader["AgeLimit"]);
                        }
                    }
                }
                else if (tabControl1.SelectedTab == tabPage4) {
                    command.CommandText = "SELECT * FROM Employer WHERE EmplID='" + list[listind] + "'";

                    textBox26.Text = list[listind].ToString();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox12.Text = Convert.ToString(reader["EmplFIO"]);
                            textBox13.Text = Convert.ToString(reader["EmplDateOfBirth"]);
                        }
                    }
                }
                else if (tabControl1.SelectedTab == tabPage5) {
                    command.CommandText = "SELECT * FROM Reader WHERE ReaderID='" + list[listind] + "'";

                    textBox27.Text = list[listind].ToString();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox15.Text = Convert.ToString(reader["ReaderFIO"]);
                            textBox14.Text = Convert.ToString(reader["ReaderDateOfBirth"]);
                            checkBox1.Checked= Convert.ToBoolean(reader["ReadTicket"]);
                        }
                    }
                }
                else if (tabControl1.SelectedTab == tabPage6) {
                    command.CommandText = "SELECT e.*, w.WriterFIO, b.BookName, r.ReaderFIO, em.EmplFIO FROM 'Extradition' e LEFT JOIN 'Reader' r, 'Employer' em, 'Writer' w, 'Books' b ON b.IdWriter = w.WriterId AND e.IDBook = b.BookID AND e.ReaderT=ReaderID AND e.IdEmployer=em.EmplId WHERE IDExtr ='" + list[listind] + "'";
                    textBox28.Text = list[listind].ToString();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox29.Text = Convert.ToString(reader["BookName"]);
                            textBox30.Text = Convert.ToString(reader["WriterFIO"]);
                            textBox21.Text = Convert.ToString(reader["DateOut"]);
                            textBox20.Text = Convert.ToString(reader["DateIn"]);
                            comboBox3.Text = Convert.ToString(reader["BookState"]);
                            textBox32.Text = Convert.ToString(reader["ReaderFIO"]); ;
                            textBox31.Text = Convert.ToString(reader["EmplFIO"]); ;
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                label25.Text = ex.ToString();
            }
        }
    }
}
