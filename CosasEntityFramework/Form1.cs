using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CosasEntityFramework.Modelos;

namespace CosasEntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /*
             Microsoft.EntityFrameworkCore
            Microsoft.EntityFrameworkCore.Tools
            Microsoft.EntityFrameworkCore.SqlServer
            Microsoft.EntityFrameworkCore.SqlServer.Design
            Microsoft.EntityFrameworkCore.Proxies
            Microsoft.Extensions.Configuration.JSON
             */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var telefonos = ddbb.Telefonos.ToList();
            string texto = "";
            foreach (var telf in telefonos)
                texto += $"{telf.codigoEst}: {telf.numero} - {telf.estudiante.nombre} {telf.estudiante.apellido}\n";
            richTextBox1.Text = texto;
        }
    }
}
