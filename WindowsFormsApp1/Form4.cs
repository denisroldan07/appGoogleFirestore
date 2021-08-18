using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {

        Dictionary<string, object> personaForm4;
        public Form4(Dictionary<string,object> persona)
        {
            InitializeComponent();
            //persona del form1
            this.personaForm4 = persona;
        }


        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (var item in personaForm4)
            {
                richTextBox1.Text += string.Format("{0}: {1}\n", item.Key, item.Value);
            }
        }

    }
}
