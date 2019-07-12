using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace dictionary
{
    public partial class AddWord : Form
    {
      
        public AddWord()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string line;
            StreamReader sr = new StreamReader("bookmark.txt");
            List<string> list = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                listBox1.Items.Add(line);
                list.Add(line);
              
            }
            string[] arr = list.ToArray();
            Array.Sort(arr);
           
            foreach(string item in arr)
            {
                listBox2.Items.Add(item);
            }
        } 

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void AddWord_Load(object sender, EventArgs e)
        {

        }
    }
}
