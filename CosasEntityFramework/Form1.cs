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

        private void botonPrueba(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var mat_curs = ddbb.MateriasCursadas.ToList();
            string texto = "";
            foreach (var mc in mat_curs)
                texto += $"{mc.estudiante.apellido}: {mc.calificacion} -\n";
            richTextBox1.Text = texto;
        }

        private void botonFA_SUM(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            //var sum = ddbb.MateriasCursadas.Sum(mc => mc.calificacion);
            var sum = ddbb.MateriasCursadas.Where(mc => mc.estudiante.apellido.Equals("Perales")).Sum(mc => mc.calificacion);
            richTextBox1.Text = sum+"";
        }

        private void botonFA_COUNT(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            //var sum = ddbb.MateriasCursadas.Count();
            var sum = ddbb.MateriasCursadas.Count(mc => mc.calificacion > 50);
            richTextBox1.Text = sum + "";
        }

        private void botonFA_MIN(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var min = ddbb.MateriasCursadas.Min(mc => mc.calificacion);
            richTextBox1.Text = min + "";
        }

        private void botonFA_MAX(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var max = ddbb.MateriasCursadas.Max(mc => mc.calificacion);
            richTextBox1.Text = max + "";
        }

        private void botonFA_AVG(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var media = ddbb.MateriasCursadas.Average(mc => mc.calificacion);
            richTextBox1.Text = media + "";
        }

        private void boton_fechas(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var estudiantes = ddbb.Estudiantes
                .Where(es => es.fecha_nac.Year == 2000 
                && es.fecha_nac.Month == 12).ToList();
            string texto = "";
            foreach (var es in estudiantes)
                texto += $"{es.apellido}: {es.fecha_nac.ToString("dd/MM/yyyy")} -\n";
            richTextBox1.Text = texto;
        }

        private void boton_JOIN(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var listaNueva = ddbb.Estudiantes.Join(
                ddbb.Telefonos,
                est => est.ci, tel => tel.codigoEst,
                (est, tel) => new
                {
                    ci = est.ci,
                    nom = est.nombre,
                    ap = est.apellido,
                    num = tel.numero
                }).ToList();
            string texto = "";
            foreach (var est in listaNueva)
                texto += $"CI: {est.ci}, {est.nom}: {est.ap}; numero: {est.num}-\n";
            richTextBox1.Text = texto;
        }

        private void boton_JOIN_WHERE(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var listaNueva = ddbb.Estudiantes.Join(
                ddbb.Telefonos,
                est => est.ci, tel => tel.codigoEst,
                (est, tel) => new
                {
                    ci = est.ci,
                    nom = est.nombre,
                    ap = est.apellido,
                    num = tel.numero
                })
                .Where(estTotal => estTotal.ci > 300)
                .ToList();
            string texto = "";
            foreach (var est in listaNueva)
                texto += $"CI: {est.ci}, {est.nom}: {est.ap}; numero: {est.num}\n";
            richTextBox1.Text = texto;
        }

        private void boton_GROUP(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var listaGrupo = ddbb.MateriasCursadas.GroupBy(mc => mc.idMat)
                .Select( g => new
                {
                    g.Key,
                    conteo = g.Count(),
                    media = g.Average(mc => mc.calificacion)
                })
                .ToList();
            string texto = "";
            foreach (var est in listaGrupo)
                texto += $" {est.media}: {est.Key}, {est.conteo}\n";
            richTextBox1.Text = texto;
        }

        private void boton_GROUP_HAVING(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var listaGrupo = ddbb.MateriasCursadas.GroupBy(mc => mc.idMat)
                .Select(g => new
                {
                    g.Key,
                    conteo = g.Count(),
                    media = g.Average(mc => mc.calificacion)
                })
                .Where(g => g.conteo > 1) //Having
                .ToList();
            string texto = "";
            foreach (var est in listaGrupo)
                texto += $" {est.media}: {est.Key}, {est.conteo}\n";
            richTextBox1.Text = texto;
        }

        private void boton_INSERT(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var materiacursada = new MateriaCursada()
            {
                idEst = 321, // mi va id_m_c pues es IDENTITY(1,1) en la tabla
                idMat = "MAT123",
                calificacion = 100
            };
            ddbb.MateriasCursadas.Add(materiacursada);
            ddbb.SaveChanges();
            richTextBox1.Text = "Creado";
        }

        private void boton_UPDATE(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var mat_cursada = ddbb.MateriasCursadas.SingleOrDefault(mc => mc.id_m_c == 6);
            mat_cursada.calificacion = 95;
            ddbb.SaveChanges();
            richTextBox1.Text = "Modificado";
        }

        private void boton_DELETE(object sender, EventArgs e)
        {
            var ddbb = new GestionEmpresaXDB();
            var mat_cursada = ddbb.MateriasCursadas.SingleOrDefault(mc => mc.id_m_c == 6);
            ddbb.MateriasCursadas.Remove(mat_cursada);
            ddbb.SaveChanges();
            richTextBox1.Text = "Eliminado";
        }
    }
}
