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
            command.CommandText = "SELECT * FROM Genres";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(reader["GenresID"]));
                    
                }
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
                        DataTable data = new DataTable();
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        adapter.Fill(data);
                        InfoBox.Text = "Данные успешно добавлены";
                    }
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    if (textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
                    {
                        command.CommandText = "INSERT INTO Genres (GenreName, GenreInfo) VALUES ('" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "')";
                        DataTable data = new DataTable();
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        adapter.Fill(data);
                        InfoBox.Text = "Данные успешно добавлены";
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void InfoBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
