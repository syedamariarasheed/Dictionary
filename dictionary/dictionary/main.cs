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
using System.IO;

namespace dictionary
{
    public partial class main : Form
    {
        
        Stack<string> mystack = new Stack<string>();
        Queue<string> que = new Queue<string>();
        OleDbConnection connection = new OleDbConnection();


        //  public static Dictionary<string, string> mydic = new Dictionary<string, string>();

        public main()
        {
          
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        

        private void main_Load(object sender, EventArgs e)
        {
            back.BringToFront();
            try
            {
              //  OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\dictionary.accdb;
Persist Security Info=False;";
                connection.Open();
                //label1.Text = "connect";
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("no");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddWord ad = new AddWord();
            ad.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panel3.Width == 41)
            { panel3.Width = 221;
               

               
            }
            else
            {
                panel3.Width = 41;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           back.BringToFront();
            Recent.BringToFront();
            foreach (string i in mystack)
            {
                listBox1.Items.Insert(0, i);
            }
            foreach (string i in que)
            {
                listBox2.Items.Insert(0, i);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            mystack.Push(textBox1.Text);
             que.Enqueue(textBox1.Text);     
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from Dictionary where Word_='" + textBox1.Text + "'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                flowLayoutPanel1.BringToFront();
                while (reader.Read())
                {
                    back.BringToFront();
                    search.BringToFront();
                    label2.Text = reader["Meaning_"].ToString();
                    label3.Text = reader["Synonyms_"].ToString();
                    label4.Text = reader["Antonyms_"].ToString();
                    label5.Text = reader["Examples_"].ToString();
                }
                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("No Search Result\n Click Add Word To Add this Word"+ex);
            }
             

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            back.BringToFront();
            AddWord.BringToFront();
        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "insert into Dictionary (Word_,Meaning_,Synonyms_,Antonyms_,Examples_) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";

                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show("Saved");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No" + ex);
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void deletion_Click(object sender, EventArgs e)
        {
            if (panel1.Enabled == true)
            {
                string ab = listBox1.SelectedItem.ToString();
                ab = Convert.ToString(mystack.Pop());
                this.listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                string ac = listBox2.SelectedItem.ToString();
                ac = Convert.ToString(que.Dequeue());
                this.listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (fifo.Enabled == true)
            {
                panel1.BringToFront();
                fifo.Enabled = false;
                panel1.Enabled = true;
            }
            else
            {
                fifo.BringToFront();
                fifo.Enabled = true;
                panel1.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          /*  string text = textBox1.Text;
            StreamReader sr = new StreamReader("bookmarkfile.txt");
            string line;
            if ((line = sr.ReadLine()) == text)
            {
                checkBox1.Checked = true;
            
                MessageBox.Show("Already bookmmarked");
            }
            else
            {
                sr.Close();*/
               StreamWriter sw = new StreamWriter("bookmark.txt");
                sw.WriteLine(textBox1.Text);
                sw.Close();
        }

        private void back_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Recent_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
