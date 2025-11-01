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
            else if (tabControl1.SelectedTab == tabPage3) { }
            else if (tabControl1.SelectedTab == tabPage4) { }
            else if (tabControl1.SelectedTab == tabPage5) { }
            else if (tabControl1.SelectedTab == tabPage6) { }
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
            else if (tabControl1.SelectedTab == tabPage3) {command.CommandText = "DELETE FROM Writer WHERE WriterId = ('" + list[listind] + "')"; }
            else if (tabControl1.SelectedTab == tabPage4) {command.CommandText = "DELETE FROM Writer WHERE WriterId = ('" + list[listind] + "')"; }
            else if (tabControl1.SelectedTab == tabPage5) {command.CommandText = "DELETE FROM Writer WHERE WriterId = ('" + list[listind] + "')"; }
            else if (tabControl1.SelectedTab == tabPage6) {command.CommandText = "DELETE FROM Writer WHERE WriterId = ('" + list[listind] + "')"; }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            command.ExecuteNonQuery();
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
                else if (tabControl1.SelectedTab == tabPage3) { }
                else if (tabControl1.SelectedTab == tabPage4) { }
                else if (tabControl1.SelectedTab == tabPage5) { }
                else if (tabControl1.SelectedTab == tabPage6) { }
            }
            catch (SQLiteException ex)
            {
                label25.Text = ex.ToString();
            }
        }
    }
}
