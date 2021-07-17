using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        FirestoreDb database2;
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            database2 = Form1.database;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addNewData();
        }


        void addNewData()
        {
            // Ingresa nombre o dni que va a ser el titulo del documento a buscar.
            String dni = textBoxDNI.Text;

          
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


            Form1.addNewData(data1 , dni);
            
        }


    }
}
