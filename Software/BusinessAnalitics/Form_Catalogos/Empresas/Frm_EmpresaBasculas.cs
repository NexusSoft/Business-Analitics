using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CapaDeDatos;

namespace Business_Analitics
{
    
    public partial class Frm_EmpresaBasculas : DevExpress.XtraEditors.XtraForm
    {
        public Boolean PaSel { get; set; }
        public string IdProveedor { get; set; }
        public string Proveedor { get; set; }
        const string idTipoPersona = "0003";
        public string UsuariosLogin { get; set; }

        private static Frm_EmpresaBasculas m_FormDefInstance;
        public static Frm_EmpresaBasculas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_EmpresaBasculas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        

        public Frm_EmpresaBasculas()
        {
            InitializeComponent();
        }

        private void CargarEmpresas()
        {
            dtgEmpBascula.DataSource = null;
            CLS_EmpresasBascula Empresas = new CLS_EmpresasBascula();

            Empresas.MtdSeleccionarEmpresas();
            if (Empresas.Exito)
            {
                dtgEmpBascula.DataSource = Empresas.Datos;
            }
        }

        private void CargarDomicilio()
        {
            dtgDomicilio.DataSource = null;
            CLS_Domicilios Domicilio = new CLS_Domicilios();
            Domicilio.Id_Empleado = textId.Text.Trim();
            Domicilio.id_TipoPersona = idTipoPersona;
            Domicilio.MtdSeleccionarDomicilio();
            if (Domicilio.Exito)
            {
                dtgDomicilio.DataSource = Domicilio.Datos;
            }
        }

        private void InsertarProveedores()
        {
            CLS_EmpresasBascula Empresas = new CLS_EmpresasBascula();
            Empresas.Id_EmpresaBascula = textId.Text.Trim();
            Empresas.Nombre_EmpresaBascula = textProveedor.Text.Trim();
            Empresas.Telefono1 = textTelefono.Text.Trim();
            Empresas.Telefono2 = textTelefono2.Text.Trim();
            Empresas.Email = textCorreo.Text.Trim();
            Empresas.Contacto = textContacto.Text.Trim();
            Empresas.RFC = txtRFC.Text.Trim();

            Empresas.Usuario = UsuariosLogin.Trim();
            Empresas.MtdInsertarEmpresas();
            if (Empresas.Exito)
            {

                CargarEmpresas();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Empresas.Mensaje);
            }
        }

        private void iniciarTags()
        {
            textTipoDomicilio.Tag = "";
            textEstado.Tag = "";
        }

        private void InsertarDomicilio()
        {
            if (txtCiudad.Text != string.Empty && textTipoDomicilio.Text != string.Empty)
            {
                CLS_Domicilios Domicilio = new CLS_Domicilios();
                Domicilio.Id_Domicilio = textIdDomicilio.Text.Trim();
                Domicilio.Calle = textCalle.Text.Trim();
                Domicilio.NoInterior = textNoInterior.Text.Trim();
                Domicilio.NoExterior = textNoExterior.Text.Trim();
                Domicilio.Colonia = textColonia.Text.Trim();
                Domicilio.Codigo_Postal = textCodigoPostal.Text.Trim();
                Domicilio.Id_Ciudad = txtCiudad.Tag.ToString().Trim();
                Domicilio.Id_TipoDomicilio = textTipoDomicilio.Tag.ToString().Trim();
                Domicilio.Id_Empleado = textId.Text.Trim();
                Domicilio.id_TipoPersona = idTipoPersona;
                Domicilio.Usuario = UsuariosLogin;
                Domicilio.MtdInsertarDomicilio();
                if (Domicilio.Exito)
                {

                    CargarDomicilio();
                    XtraMessageBox.Show("Se ha Insertado el registro con exito");
                    LimpiarCamposDomicilio();
                }
                else
                {
                    XtraMessageBox.Show(Domicilio.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("Faltan datos por completar Ciudad o Tipo de Domicilio");
            }
        }

        private void EliminarEmpresas()
        {
            CLS_EmpresasBascula Empresas = new CLS_EmpresasBascula();
            Empresas.Id_EmpresaBascula = textId.Text.Trim();
            Empresas.MtdEliminarEmpresas();
            if (Empresas.Exito)
            {
                EliminarDomicilioPersona();
                CargarEmpresas();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Empresas.Mensaje);
            }
        }

        private void EliminarDomicilio()
        {
            CLS_Domicilios Domicilio = new CLS_Domicilios();
            Domicilio.Id_Domicilio = textIdDomicilio.Text.Trim();
            Domicilio.MtdEliminarDomicilio();
            if (Domicilio.Exito)
            {
                CargarDomicilio();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCamposDomicilio();
            }
            else
            {
                XtraMessageBox.Show(Domicilio.Mensaje);
            }
        }

        private void EliminarDomicilioPersona()
        {
            CLS_Domicilios Domicilio = new CLS_Domicilios();
            Domicilio.Id_Empleado = textId.Text.Trim();
            Domicilio.id_TipoPersona = idTipoPersona;
            Domicilio.MtdEliminarDomicilioPersona();
            if (Domicilio.Exito)
            {
                CargarDomicilio();

                LimpiarCamposDomicilio();
            }
            else
            {
                XtraMessageBox.Show(Domicilio.Mensaje);
            }
        }

        private void LimpiarCampos()
        {
            textId.Text = "";
            textProveedor.Text = "";
            textTelefono.Text = "";
            textTelefono2.Text = "";
            textCorreo.Text = "";
            textContacto.Text = "";
            txtRFC.Text = "";
        }

        private void LimpiarCamposDomicilio()
        {
            textIdDomicilio.Text = "";
            textCalle.Text = "";
            textNoInterior.Text = "";
            textNoExterior.Text = "";
            textEstado.Tag = "";
            textEstado.Text = "";
            txtCiudad.Tag = "";
            txtCiudad.Text = "";
            textCodigoPostal.Text = "";
            textColonia.Text = "";
            textTipoDomicilio.Tag = "";
            textTipoDomicilio.Text = "";
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValEmpBascula.GetSelectedRows())
                {
                    DataRow row = this.dtgValEmpBascula.GetDataRow(i);
                    textId.Text = row["Id_EmpresaBascula"].ToString();
                    textProveedor.Text = row["Nombre_EmpresaBascula"].ToString();
                    textTelefono.Text = row["Telefono1"].ToString();
                    textTelefono2.Text = row["Telefono2"].ToString();
                    textCorreo.Text = row["Email"].ToString();
                    textContacto.Text = row["Contacto"].ToString();
                    txtRFC.Text = row["RFC"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            CargarDomicilio();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                if (textProveedor.Text.ToString().Trim().Length > 0)
                {
                    InsertarProveedores();
                }
                else
                {
                    XtraMessageBox.Show("Es necesario Agregar un nombre a la Empresa.");
                }
            }
            else
            {
                if (textCalle.Text.ToString().Trim().Length > 0)
                {
                    if (textNoExterior.Text.Trim().Length > 0 || textNoInterior.Text.Trim().Length > 0)
                    {
                        InsertarDomicilio();
                    }
                    else
                    {
                        XtraMessageBox.Show("Es necesario agregar un numero exterior o interior.");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Es necesario Agregar una calle.");
                }
            }
        }
        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar el dato seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
                {
                    if (textId.Text.Trim().Length > 0)
                    {
                        EliminarEmpresas();
                    }
                    else
                    {
                        XtraMessageBox.Show("Es necesario seleccionar una Empresa.");
                    }
                }
                else
                {
                    if (textIdDomicilio.Text.Trim().Length > 0)
                    {
                        EliminarDomicilio();
                    }
                    else
                    {
                        XtraMessageBox.Show("Es necesario seleccionar un Domicilio.");
                    }
                }
            }
        }
        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                LimpiarCampos();
                LimpiarCamposDomicilio();
            }
            else
            {
                LimpiarCamposDomicilio();
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Frm_Empresa_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarEmpresas();
            CargarDomicilio();
            iniciarTags();
            LimpiarCampos();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValDomicilio.GetSelectedRows())
                {
                    DataRow row = this.dtgValDomicilio.GetDataRow(i);
                    textIdDomicilio.Text = row["Id_Domicilio"].ToString();
                    textCalle.Text = row["Calle"].ToString();
                    textNoInterior.Text = row["NoInterior"].ToString();
                    textNoExterior.Text = row["NoExterior"].ToString();
                    textCodigoPostal.Text = row["Codigo_Postal"].ToString();
                    textColonia.Text = row["Colonia"].ToString();
                    textEstado.Tag = row["Id_Estado"].ToString();
                    textEstado.Text = row["Nombre_Estado"].ToString();
                    txtCiudad.Tag = row["Id_Ciudad"].ToString();
                    txtCiudad.Text = row["Nombre_Ciudad"].ToString();
                    textTipoDomicilio.Tag = row["Id_TipoDomicilio"].ToString();
                    textTipoDomicilio.Text = row["Nombre_TipoDomicilio"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnBusqEstado_Click(object sender, EventArgs e)
        {
            Frm_Ciudad Clase = new Frm_Ciudad();
            Clase.UsuariosLogin = UsuariosLogin.Trim();
            Clase.PaSel = true;
            Clase.ShowDialog();

            txtCiudad.Tag = Clase.IdCiudad;
            txtCiudad.Text = Clase.Ciudad;
            textEstado.Tag = Clase.IdEstado;
            textEstado.Text = Clase.Estado;
        }

        private void btnBusqTipoDomicilio_Click(object sender, EventArgs e)
        {
            Frm_Tipo_Domicilio tipoDomicilio = new Frm_Tipo_Domicilio();
            tipoDomicilio.UsuariosLogin = UsuariosLogin.Trim();
            tipoDomicilio.PaSel = true;
            tipoDomicilio.ShowDialog();

            textTipoDomicilio.Tag = tipoDomicilio.IdTipoDomicilio;
            textTipoDomicilio.Text = tipoDomicilio.TipoDomicilio;
        }

        private void textIdProveedor_EditValueChanged(object sender, EventArgs e)
        {
            if (textId.Text == String.Empty)
            {
                xtraTabPage2.PageEnabled = false;

            }
            else
            {
                xtraTabPage2.PageEnabled = true;
            }
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdProveedor = textId.Text.Trim();
            Proveedor = textProveedor.Text.Trim();
            this.Close();
        }
    }
}