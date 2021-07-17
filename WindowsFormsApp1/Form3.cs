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
            textBoxName.Text = (string)this.personaForm3["Nombre y apellido"];
            textBoxID.Text = (string)this.personaForm3["N° afiliado"];
            textBoxPhoneNumber.Text =(string)this.personaForm3["Telefono"];
            textBoxJob.Text = (string)this.personaForm3["Mail"];
            richTextBoxCursos.Text = (string)this.personaForm3["Cursos"];
            richTextBoxCuotas.Text = (string)this.personaForm3["Cuota"];
        
        }

        async void Replace_A_Document_Deleting_All_Previous_Field()
        {
            
            
            Dictionary<string, object> data = new Dictionary<string, object>()
             {
                 {"Nombre y apellido" , textBoxName.Text},
                 {"N° afiliado" , textBoxID.Text},
                 {"Telefono" , textBoxPhoneNumber.Text},
                 {"Mail" , textBoxEmail.Text},
                 {"Ocupacion actual" , textBoxJob.Text },
                 {"Cursos" , richTextBoxCursos.Text },
                 {"Cuota" , richTextBoxCuotas.Text }
             };
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data1 = new Dictionary<string, object>()
            {
                // se agrega nuevo diccionario con los datos del nuevo afiliado
                 {"Nombre y apellido" , textBoxName.Text},
                 {"N° afiliado" , textBoxID.Text},
                 {"Telefono" , textBoxPhoneNumber.Text},
                 {"Mail" , textBoxEmail.Text },
                 {"Ocupacion actual" , textBoxJob.Text },
                 {"Cursos" , richTextBoxCursos.Text },
                 {"Cuota" , richTextBoxCuotas.Text }
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
