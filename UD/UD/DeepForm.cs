using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace UD
{
    public partial class DeepForm : Form
    {
        static SQLiteConnection connection;
        static SQLiteCommand command;
        DataTable dt;
        public DeepForm()
        {
            InitializeComponent();
            try
            {
                connection = new SQLiteConnection("Data Source=Library.sqlite;Version=3; FailIfMissing=False");
                connection.Open();
                command = new SQLiteCommand(connection);
                dt = new DataTable();
                dataGridView1.DataSource = dt;
            }
            catch (SQLiteException ex)
            {
                //InfoBox.Text = "Ошибка: " + ex;
            }
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dt = new DataTable();
                dataGridView1.DataSource = dt;
                
            }
            
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    command.CommandText = "SELECT * FROM Writer";
                    break;
                case 1:
                    command.CommandText = "SELECT * FROM Genres";
                    break;
                case 2:
                    command.CommandText = "SELECT * FROM Books";
                    break;
                case 3:
                    command.CommandText = "SELECT * FROM Employer";
                    break;
                case 4:
                    command.CommandText = "SELECT * FROM Reader";
                    break;
                case 5:
                    command.CommandText = "SELECT * FROM Extradition";
                    break;
                
                default:
                    break;
                }
            dt.Clear();
            dt.Load(command.ExecuteReader());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            command.CommandText = textBox1.Text;
            DataTable data = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            try
            {
                adapter.Fill(data);
                dt.Clear();
                dt.Load(command.ExecuteReader());
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dt = new DataTable();
                dataGridView1.DataSource = dt;

            }
        }
    }
}
