using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UD
{
    public partial class AddForm : Form
    {
        static SQLiteConnection connection;
        static SQLiteCommand command;
        public AddForm()
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
                InfoBox.Text = "Ошибка: "+ex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    if (textBox1.Text.Length > 0)
                    {
                        command.CommandText = "INSERT INTO Writer (WriterFIO) VALUES ('" + textBox1.Text.ToString() + "')";
                        
                    }
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    if (textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
                    {
                        command.CommandText = "INSERT INTO Genres (GenreName, GenreInfo) VALUES ('" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "')";
                        
                    }
                }else if(tabControl1.SelectedTab == tabPage3)
                {
                    if (textBox4.Text.Length > 0 && textBox7.Text.Length > 0 && comboBox1.Text.Length>0 && comboBox2.Text.Length > 0)
                    {
                        command.CommandText = "INSERT INTO Books (BookName, IdGenre, IdWriter, WriteDate, PublishDate, Publisher, Pages, BooksNum, BookInfo, AgeLimit) VALUES ('" + textBox4.Text.ToString() + "', (SELECT GenresID FROM Genres WHERE GenreName='" + comboBox1.Text.ToString() + "'),(SELECT WriterId FROM Writer WHERE WriterFIO='"+comboBox2.Text.ToString()+ "'),'" + textBox5.Text.ToString() + "','"+ textBox6.Text.ToString() + "','"+ textBox7.Text.ToString() + "','"+ textBox8.Text.ToString() + "','"+ textBox9.Text.ToString() + "','"+ textBox11.Text.ToString() + "','"+comboBox7.Text.ToString()+"')";
                        
                    }
                }
                else if (tabControl1.SelectedTab == tabPage4)
                {
                    if (textBox12.Text.Length > 0 && textBox13.Text.Length > 0)
                    {
                            command.CommandText = "INSERT INTO Employer (EmplFIO, EmplDateOfBirth) VALUES ('" + textBox12.Text.ToString() + "','" + textBox13.Text.ToString() + "')";
                            
                    }
                }
                else if (tabControl1.SelectedTab == tabPage5)
                {
                    if (textBox15.Text.Length > 0 && textBox14.Text.Length > 0)
                    {
                        
                            command.CommandText = "INSERT INTO Reader (ReaderFIO, ReaderDateOfBirth, ReadTicket) VALUES ('" + textBox15.Text.ToString() + "','" + textBox14.Text.ToString() + "','" + (checkBox1.Checked ? "1" : "0") + "')";
                            
                    }
                }
                else if (tabControl1.SelectedTab == tabPage6)
                {
                    if (textBox21.Text.Length > 0 && comboBox5.Text.Length > 0 && comboBox3.Text.Length > 0 && comboBox4.Text.Length > 0 && comboBox6.Text.Length > 0)
                    {
                        
                            command.CommandText = "INSERT INTO Extradition (IDBook, DateOut, DateIn, BookState, IdEmployer, ReaderT) VALUES ((SELECT BookID FROM Books WHERE BookName='" + comboBox5.Text.ToString() + "'),'" + textBox21.Text.ToString() + "','" + textBox20.Text.ToString() + "','" + comboBox3.Text.ToString() + "',(SELECT EmplID FROM Employer WHERE EmplFIO = '" + comboBox6.Text + "'), (SELECT ReaderID FROM Reader WHERE ReaderFIO = '" + comboBox4.Text+"'))";
                            
                    }
                }
                DataTable data = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(data);
            }
            catch (Exception ex)
            {
                InfoBox.Text = "Данные не добавлены: "+ex.Message;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            command.CommandText = "SELECT * FROM Genres";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(reader["GenreName"]));

                }
            }
            command.CommandText = "SELECT * FROM Writer";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox2.Items.Add(Convert.ToString(reader["WriterFIO"]));

                }
            }
            command.CommandText = "SELECT * FROM Books";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox5.Items.Add(Convert.ToString(reader["BookName"]));

                }
            }
            command.CommandText = "SELECT * FROM Reader";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox4.Items.Add(Convert.ToString(reader["ReaderFIO"]));

                }
            }
            command.CommandText = "SELECT * FROM Employer";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox6.Items.Add(Convert.ToString(reader["EmplFIO"]));

                }
            }
        }
    }
}
