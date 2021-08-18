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
            Form2.ActiveForm.Controls.Clear();
            InitializeComponent();
        }


        void addNewData()
        {
            // Ingresa nombre o dni que va a ser el titulo del documento a buscar.
            String dni = textBoxDNI.Text;

          
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


            Form1.addNewData(data1 , dni);
            
        }


    }
}
