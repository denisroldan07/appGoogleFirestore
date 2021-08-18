using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using MessageBox = System.Windows.MessageBox;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        Dictionary<string, object> personaForm3;
        string dni;
        public Form3(Dictionary<string, object> persona , string dni)
        {
            InitializeComponent();
            this.personaForm3 = persona;
            this.dni = dni;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBoxName.Text = (string)this.personaForm3["1 - NOMBRE Y APELLIDO: "];
            textBoxID.Text = (string)this.personaForm3["2 - N° AFILIADO: "];
            textBoxPhoneNumber.Text =(string)this.personaForm3["3 - TELEFONO: "];
            textBoxEmail.Text = (string)this.personaForm3["4 - MAIL: "];
            textBoxJob.Text = (string)this.personaForm3["5 - OCUPACION ACTUAL: "];
            richTextBoxCursos.Text = (string)this.personaForm3["6 - CURSOS: "];
            richTextBoxCuotas.Text = (string)this.personaForm3["7 - CUOTAS: "];
        
        }

        async void Replace_A_Document_Deleting_All_Previous_Field()
        {
            
            
            Dictionary<string, object> data = new Dictionary<string, object>()
             {
                 {"1 - NOMBRE Y APELLIDO: " , textBoxName.Text},
                 {"2 - N° AFILIADO: " , textBoxID.Text},
                 {"3 - TELEFONO: " , textBoxPhoneNumber.Text},
                 {"4 - MAIL: " , textBoxEmail.Text },
                 {"5 - OCUPACION ACTUAL: " , textBoxJob.Text },
                 {"6 - CURSOS: " , richTextBoxCursos.Text },
                 {"7 - CUOTAS: " , richTextBoxCuotas.Text }
             };
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {
                // se agrega nuevo diccionario con los datos del nuevo afiliado
                 {"1 - NOMBRE Y APELLIDO: " , textBoxName.Text},
                 {"2 - N° AFILIADO: " , textBoxID.Text},
                 {"3 - TELEFONO: " , textBoxPhoneNumber.Text},
                 {"4 - MAIL: " , textBoxEmail.Text },
                 {"5 - OCUPACION ACTUAL: " , textBoxJob.Text },
                 {"6 - CURSOS: " , richTextBoxCursos.Text },
                 {"7 - CUOTAS: " , richTextBoxCuotas.Text }
            };

            Form1.addNewData(data1 , this.dni );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxResult confirmResult = MessageBox.Show("Are you sure to delete this item ??", "Confirm Delete!!", MessageBoxButton.YesNo);

            if (confirmResult == MessageBoxResult.Yes)
            {
                Form1.Delete_An_Entire_Document(this.dni);
                this.Close();
            }
            else
            {
                
            }
        }



    }
}
