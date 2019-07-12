using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                panel1.Width += 2;
                if(panel1.Width >= 379)
                {
                    timer1.Stop();
                    main m = new main();
                    m.Show();
                    this.Hide();

                }
            }
            catch(Exception)
            {
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
