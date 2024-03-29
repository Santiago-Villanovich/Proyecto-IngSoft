﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using BE;
using Services;
using System.Text.RegularExpressions;
using Services.Multilanguage;

namespace UI
{
    public partial class FormPermisos : Form,IObserver
    {
        List<Componente> _permisos = new List<Componente>();
        List<Componente> componentesSeleccionados = new List<Componente>();
        BLL_Traductor traductor;

        private void TraducirForm(IIdioma idioma = null)
        {
            try
            {
                var traducciones = traductor.ObtenerTraducciones(idioma);

                foreach (Control control in this.Controls)
                {

                    if (control is Button)
                    {
                        Button boton = (Button)control;
                        if (boton.Tag != null && traducciones.ContainsKey(boton.Tag.ToString()))
                            boton.Text = traducciones[boton.Tag.ToString()].texto;
                    }
                    else if (control is Label)
                    {
                        Label label = (Label)control;
                        if (label.Tag != null && traducciones.ContainsKey(label.Tag.ToString()))
                            label.Text = traducciones[label.Tag.ToString()].texto;

                    }

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public FormPermisos()
        {
            InitializeComponent();
            traductor = new BLL_Traductor();
            TraducirForm(Session.IdiomaActual);

            Session._publisherIdioma.Subscribe(this);
        }



        private void Permisos_Load(object sender, EventArgs e)
        {

            List<Familia> _familias = new BLL_Permisos().GetFamilias();
            List<Patente> _patentes = new BLL_Permisos().ObtenerPatentes();

            dataGridView1.DataSource = _patentes;
            dataGridView3.DataSource = _familias;
            
            foreach (var familia in _familias)
            {
                _permisos = new BLL_Permisos().GetPermisosFamilia(familia.Id);
                TreeNode padre = new TreeNode(familia.Nombre);
                cargarTreeView(_permisos, padre);
                treeView1.Nodes.Add(padre);
            }

        }

        public void cargarTreeView(IList<Componente> list, TreeNode parent)
        {
            foreach (var item in list)
            {
                TreeNode newNode = new TreeNode(item.Nombre);
                parent.Nodes.Add(newNode);
                if (item.Hijos != null && item.Hijos.Count != 0) cargarTreeView(item.Hijos, newNode);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!RegexValidation.validarPalabra(textBox1.Text))
                {
                    MessageBox.Show("El permiso debe tener un nombre ingresado valido");
                    return;
                }

                Familia c = new Familia();

                c.Nombre = textBox1.Text;

                componentesSeleccionados.ForEach(p =>
                {
                    c.AgregarHijo(p);
                });

                new BLL_Permisos().AgregarPermiso(c);

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    

            }finally
            {
                componentesSeleccionados.Clear();   
                dataGridView3.DataSource = null;
                dataGridView2.DataSource = null;
                List<Familia> _familias =  new BLL_Permisos().GetFamilias();
                dataGridView3.DataSource = _familias;

                treeView1.Nodes.Clear();

                foreach (var familia in _familias)
                {
                    _permisos = new BLL_Permisos().GetPermisosFamilia(familia.Id);
                    TreeNode padre = new TreeNode(familia.Nombre);
                    cargarTreeView(_permisos, padre);
                    treeView1.Nodes.Add(padre);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1 == null)
                {
                    MessageBox.Show("Debe seleccionar un permiso");
                    return;
                }

                if(treeView1.SelectedNode== null)
                {
                    MessageBox.Show("Debe seleccionar un permiso");
                    return;
                }
               
                var selectedPermiso = new BLL_Permisos().GetComponentePorNombre(treeView1.SelectedNode.Text);
                
                var permisosFamilia = new BLL_Permisos().GetPermisosFamilia(selectedPermiso.Id);

                new BLL_Permisos().Delete(selectedPermiso);

                MessageBox.Show("Se elimino el permiso");

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                treeView1.Nodes.Clear();
                Permisos_Load(this, null);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Debe seleccionar una patente");
                return;
            }

            Patente seleccion = (Patente)dataGridView1.CurrentRow.DataBoundItem;

            if (componentesSeleccionados.Contains(seleccion)) {
                MessageBox.Show("Este permiso ya fue agregado");
                return;
            } 

            componentesSeleccionados.Add(seleccion);

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = componentesSeleccionados;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Debe seleccionar una patente");
                return;
            }

            Familia seleccion = (Familia)dataGridView3.CurrentRow.DataBoundItem;


            if (componentesSeleccionados.Contains(seleccion))
            {
                MessageBox.Show("Este componente ya fue agregado");
                return;
            }

            componentesSeleccionados.Add(seleccion);

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = componentesSeleccionados;
        }

        public void Notify(Idioma idioma)
        {
            TraducirForm(idioma);
        }
    }
}
