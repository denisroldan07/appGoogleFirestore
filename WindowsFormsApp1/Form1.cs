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
    public partial class Form1 : Form
    {
        public static FirestoreDb database;
        bool edit = false;
        string dni;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"farmaceutica.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            database = FirestoreDb.Create("farmaceutica-c35e1");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dni = textBox1.Text;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form agregar = new Form2();
            
            agregar.Show();
        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.edit = true;
            GetAllData_Of_A_Document();
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.edit = false;
            GetAllData_Of_A_Document();
        }

        // agregar informacion
        public static void addNewData(Dictionary<string, object> data , string dni)
        {
            // Ingresa nombre o dni que va a ser el titulo del documento a buscar.
            
            DocumentReference docs = database.Collection("farmaceuticos").Document(dni);

            docs.SetAsync(data);
            MessageBox.Show("data added succesfully");
        }
        // termina agregar informacion

        async void GetAllData_Of_A_Document() 
        {
            //Se deberia ingresar una variable en una burbuja de texto con el dni o numero de matricula del afiliado


            // Reemplazar "Denis" por dni o numero de matricula del afiliado
            DocumentReference docref = database.Collection("farmaceuticos").Document(dni);
            DocumentSnapshot snap = await docref.GetSnapshotAsync();

            Dictionary<string, object> persona = null;
            if (snap.Exists)
            {
                persona = snap.ToDictionary();
                if(this.edit == true)
                {
                    Form modificar = new Form3(persona,dni);
                    modificar.Show();
                } else
                {
                    Form buscar = new Form4(persona);
                    buscar.Show();
                }


            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
            
        }

        async public static void Delete_An_Entire_Document(string dni)
        {
        
            DocumentReference docref = database.Collection("farmaceuticos").Document(dni);
        
            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                
                docref.DeleteAsync();
                MessageBox.Show("done");

            } else
            {
                MessageBox.Show("usuario no encontrado");
            }
        }




        // modificar informacion





    }
}
