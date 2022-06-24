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
        private void button2_Click(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes.Where(es => DateTime.Now.Year - es.fecha_nac.Year >= 18).ToList();
            string texto = "";
            foreach (var est in estudiantes)
                texto += $"{est.nombre}: {est.apellido} -\n";
            richTextBox1.Text = texto;
        }

        private void boton3(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes
                .Where(es => DateTime.Now.Year - es.fecha_nac.Year > 20 && es.direccion != null).ToList();
            string texto = "";
            foreach (var est in estudiantes)
                texto += $"{est.nombre}: {est.apellido} -\n";
            richTextBox1.Text = texto;
        }

        private void boton4(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes
                .Where(es => DateTime.Now.Year - es.fecha_nac.Year > 20 || es.direccion != null).ToList();
            string texto = "";
            foreach (var est in estudiantes)
                texto += $"{est.nombre}: {est.apellido} -\n";
            richTextBox1.Text = texto;
        }

        private void botonLike(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes
                .Where(es => es.nombre.StartsWith("P")).ToList();//Valor al inicio
            string texto = "";
            foreach (var est in estudiantes)
                texto += $"{est.nombre}: {est.apellido} -\n";
            richTextBox1.Text = texto;
        }

        private void botonLike2(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes
                .Where(es => es.nombre.EndsWith("a")).ToList();//Valor al inicio
            string texto = "";
            foreach (var est in estudiantes)
                texto += $"{est.nombre}: {est.apellido} -\n";
            richTextBox1.Text = texto;
        }

        private void botonLike3(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes
                .Where(es => es.nombre.Contains("o")).ToList();//Valor al inicio
            string texto = "";
            foreach (var est in estudiantes)
                texto += $"{est.nombre}: {est.apellido} -\n";
            richTextBox1.Text = texto;
        }

        private void botonOrderBy(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes
                .OrderBy(est => est.apellido).ToList();//Valor al inicio
            string texto = "";
            foreach (var est in estudiantes)
                texto += $"{est.nombre}: {est.apellido} -\n";
            richTextBox1.Text = texto;
        }

        private void botonOrderByDesc(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes
                .OrderByDescending(est => est.apellido).ToList();//Valor al inicio
            string texto = "";
            foreach (var est in estudiantes)
                texto += $"{est.nombre}: {est.apellido} -\n";
            richTextBox1.Text = texto;
        }

        private void botonWhereOrderBy(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes
                .Where(es => es.direccion != null)
                .OrderBy(est => est.apellido).ToList();//Valor al inicio
            string texto = "";
            foreach (var est in estudiantes)
                texto += $"{est.nombre}: {est.apellido} -\n";
            richTextBox1.Text = texto;
        }

        private void botonLimit(object sender, EventArgs e)
        {//Los dos estudiantes más jóvenes
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes
                .OrderByDescending(est => est.fecha_nac).Skip(0).Take(2).ToList();//Valor al inicio
            string texto = "";
            foreach (var est in estudiantes)
                texto += $"{est.nombre}: {est.apellido} -\n";
            richTextBox1.Text = texto;
        }

        private void botonWhereLimit(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes
                .Where(est => est.ci > 1000)
                .OrderByDescending(est => est.fecha_nac).Skip(0).Take(2).ToList();//Valor al inicio
            string texto = "";
            foreach (var est in estudiantes)
                texto += $"{est.nombre}: {est.apellido} -\n";
            richTextBox1.Text = texto;
            /* ¿Cómo lo haríamos para, habiendo rescatado a los 2 más jóvenes, mostrar a los que tengan ci > 1000?
             * 
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes
                .OrderByDescending(est => est.fecha_nac).Skip(0).Take(2).Where(est => est.ci > 1000).ToList();//Valor al inicio
            string texto = "";
            foreach (var est in estudiantes)
                texto += $"{est.nombre}: {est.apellido} -\n";
            richTextBox1.Text = texto;*/
        }

        private void botonBusquedaPK(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            int carnet = int.Parse(richTextBox1.Text);
            Estudiante est = ddbb.Estudiantes.SingleOrDefault(e => e.ci == carnet);
            string texto = "";
            if (est != null)
            {
                texto = $"Estudiante: {est.nombre} {est.apellido}\nCI: {est.ci}\n" +
                    $"Dirección: {est.direccion}";
            }
            richTextBox1.Text = texto;
        }

        private void botonProyeccion(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var estudiantesMutados = ddbb.Estudiantes.Select( e => new
                {
                    carnet = e.ci,
                    nombre = e.nombre,
                    apellido = e.apellido,
                    numero = e.ci * 2
                }).ToList();
            string texto = "";
            foreach (var est in estudiantesMutados)
                texto += $"CI: {est.carnet}, {est.nombre}: {est.apellido}; numero: {est.numero}-\n";
            richTextBox1.Text = texto;
        }
    }
}
