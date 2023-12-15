using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABS;
using Services;
using Services.Multilanguage;
using BE;
using Services.SecurityAndValidation;

namespace UI
{
    public partial class FormHistorialCambios : Form, IObserver
    {
        public void InitializeComboBoxs()
        {
            try
            {
                cboxUsuario.AutoCompleteMode = AutoCompleteMode.Suggest;
                cboxUsuario.AutoCompleteSource = AutoCompleteSource.ListItems;

                cboxUsuario.DataSource = bllUsr.GetAll();
                cboxUsuario.ValueMember = "Id";
                cboxUsuario.DisplayMember = "NombreApellido";

                cboxUsuario.SelectedItem = null;
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = ex.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                MessageBox.Show(ex.Message);
            }

        }
        public void InitializeDTPicker()
        {
            dtDesde.MinDate = new DateTime(2023, 1, 1);
            dtDesde.Checked = false;
            dtHasta.MinDate = new DateTime(2023, 1, 1);
            dtHasta.Checked = false;
        }
        private void TraducirForm(IIdioma idioma = null)
        {
            try
            {
                BLL_Traductor traductor = new BLL_Traductor();
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
                var bitacora = new Bitacora();
                bitacora.Detalle = ex.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                MessageBox.Show(ex.Message);
            }

        }

        public void Notify(Idioma idioma)
        {
            TraducirForm(idioma);
        }

        public FormHistorialCambios()
        {
            InitializeComponent();
            bllUsr = new BLL_User();
            pageNumber = 1;

            InitializeComboBoxs();
            InitializeDTPicker();
            TraducirForm(Session.IdiomaActual);
        }

        BLL_User bllUsr;
        private int pageNumber;

        DateTime? fromDate = null;
        DateTime? toDate = null;
        int? usr = null;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                if (dtDesde.Checked)
                {
                    fromDate = dtDesde.Value;
                }

                if (dtHasta.Checked)
                {
                    toDate = dtHasta.Value;
                }

                if (cboxUsuario.SelectedItem != null)
                {
                    User aux = (User)cboxUsuario.SelectedItem;
                    usr = aux.Id;
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bllUsr.GetAllUserHistory(usr,fromDate,toDate,pageNumber);

            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = ex.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboxUsuario.SelectedItem = null;
            dtDesde.Checked = false;
            dtHasta.Checked = false;
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.DataBoundItem != null)
                {
                    DTO_UserHistory dtoUser = (DTO_UserHistory)dataGridView1.CurrentRow.DataBoundItem;
                    User user = bllUsr.Get(dtoUser.Id);

                    user.Id = dtoUser.Id;
                    user.Nombre = dtoUser.Nombre;
                    user.Apellido = dtoUser.Apellido;
                    user.Clave = dtoUser.Clave;
                    user.Email = dtoUser.Mail;
                    user.Telefono = dtoUser.Telefono;
                    user.DNI = dtoUser.DNI;
                    user.DV = GestorDigitoVerificador.CalcularDV(user);

                    if (bllUsr.Update(user))
                    {
                        cboxUsuario.SelectedItem = null;
                        dtDesde.Checked = false;
                        dtHasta.Checked = false;
                        dataGridView1.DataSource = null;
                        MessageBox.Show("Se ha restablecido el estado previo del usuario");
                        
                    }
                    
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un estado del usuario");
                }
                

            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = ex.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                MessageBox.Show(ex.Message);
            }
        }

        private void FormHistorialCambios_Load(object sender, EventArgs e)
        {

        }
    }
}
