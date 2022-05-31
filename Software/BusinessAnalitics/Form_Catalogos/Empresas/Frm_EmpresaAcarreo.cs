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
using System.Globalization;

namespace Business_Analitics
{
    
    public partial class Frm_EmpresaAcarreo : DevExpress.XtraEditors.XtraForm
    {
        public Boolean PaSel { get; set; }
        public string IdProveedor { get; set; }
        public string Proveedor { get; set; }
        const string idTipoPersona = "0001";
        public string UsuariosLogin { get; set; }
        public NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        public CultureInfo culture = CultureInfo.CreateSpecificCulture("es-MX");

        private static Frm_EmpresaAcarreo m_FormDefInstance;
        public static Frm_EmpresaAcarreo DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_EmpresaAcarreo();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public Frm_EmpresaAcarreo()
        {
            InitializeComponent();
        }

        private void CargarEmpresas()
        {
            dtgEmpAcarreo.DataSource = null;
            CLS_EmpresasAcarreo Empresas = new CLS_EmpresasAcarreo();

            Empresas.MtdSeleccionarEmpresas();
            if (Empresas.Exito)
            {
                dtgEmpAcarreo.DataSource = Empresas.Datos;
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
        private void CargarCamiones()
        {
            dtgCamiones.DataSource = null;
            CLS_Camiones camiones = new CLS_Camiones();
            camiones.Id_EmpresaAcarreo = textId.Text.Trim();
            camiones.MtdSeleccionarCamion();
            if (camiones.Exito)
            {
                dtgCamiones.DataSource = camiones.Datos;
            }
        }
        private void CargarChoferes()
        {
            dtgChoferes.DataSource = null;
            CLS_Choferes Choferes = new CLS_Choferes();
            Choferes.Id_EmpresaAcarreo = textId.Text.Trim();
            Choferes.MtdSeleccionarChoferes();
            if (Choferes.Exito)
            {
                dtgChoferes.DataSource = Choferes.Datos;
            }
        }

        private void InsertarEmpresaAcarreo()
        {
            CLS_EmpresasAcarreo Empresas = new CLS_EmpresasAcarreo();
            Empresas.Id_EmpresaAcarreo = textId.Text.Trim();
            Empresas.Nombre_EmpresaAcarreo = textProveedor.Text.Trim();
            Empresas.Telefono1 = textTelefono.Text.Trim();
            Empresas.Telefono2 = textTelefono2.Text.Trim();
            Empresas.Email = textCorreo.Text.Trim();
            Empresas.Contacto = textContacto.Text.Trim();
            Empresas.RFC = txtRFC.Text.Trim();
            Empresas.PrecioA =Convert.ToDecimal(txtPrecioA.EditValue);
            Empresas.PrecioB = Convert.ToDecimal(txtPrecioB.EditValue);
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
        private void InsertarCamiones()
        {
            if (txtNombreCamion.Text != string.Empty )
            {
                CLS_Camiones Camion = new CLS_Camiones();
                Camion.Id_Camion = txtIDCamion.Text.Trim();
                Camion.Nombre_Camion = txtNombreCamion.Text.Trim();
                Camion.Placas = txtPlacasCamion.Text.Trim();
                Camion.Id_EmpresaAcarreo = textId.Text.Trim();
                Camion.Usuario = UsuariosLogin;
                Camion.MtdInsertarCamion();
                if (Camion.Exito)
                {
                    CargarCamiones();
                    XtraMessageBox.Show("Se ha Insertado el registro con exito");
                    LimpiarCamposCamiones();
                }
                else
                {
                    XtraMessageBox.Show(Camion.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("Faltan datos por completar Ciudad o Tipo de Domicilio");
            }
        }
        private void InsertarChoferes()
        {
            if (txtNombreChofer.Text != string.Empty )
            {
                CLS_Choferes Chofer = new CLS_Choferes();
                Chofer.Id_Chofer = txtIDChofer.Text.Trim();
                Chofer.Id_EmpresaAcarreo = textId.Text.Trim();
                Chofer.Nombre_Chofer = txtNombreChofer.Text.Trim();
                Chofer.Usuario = UsuariosLogin;
                Chofer.MtdInsertarChoferes();
                if (Chofer.Exito)
                {
                    CargarChoferes();
                    XtraMessageBox.Show("Se ha Insertado el registro con exito");
                    LimpiarCamposChoferes();
                }
                else
                {
                    XtraMessageBox.Show(Chofer.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("Faltan datos por completar Ciudad o Tipo de Domicilio");
            }
        }
        private void EliminarEmpresas()
        {
            CLS_EmpresasAcarreo Empresas = new CLS_EmpresasAcarreo();
            Empresas.Id_EmpresaAcarreo = textId.Text.Trim();
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
        private void EliminarCamion()
        {
            CLS_Camiones Camion = new CLS_Camiones();
            Camion.Id_Camion = txtIDCamion.Text.Trim();
            Camion.MtdEliminarCamion();
            if (Camion.Exito)
            {
                CargarCamiones();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCamposCamiones();
            }
            else
            {
                XtraMessageBox.Show(Camion.Mensaje);
            }
        }
        private void EliminarChofer()
        {
            CLS_Choferes Chofer = new CLS_Choferes();
            Chofer.Id_Chofer = txtIDChofer.Text.Trim();
            Chofer.MtdEliminarChoferes();
            if (Chofer.Exito)
            {
                CargarChoferes();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCamposChoferes();
            }
            else
            {
                XtraMessageBox.Show(Chofer.Mensaje);
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
            txtPrecioA.Text = "0";
            txtPrecioB.Text = "0";
            txtPrecioServicio.Text = "0";
            txtPrecioCaja.Text = "0";
            txtPrecioSalidaForanea.Text = "0";
            labelControl23.Text = string.Empty;
            labelControl24.Text = string.Empty;
            labelControl26.Text = string.Empty;
            labelControl27.Text = string.Empty;
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
        private void LimpiarCamposCamiones()
        {
            txtIDCamion.Text = string.Empty;
            txtNombreCamion.Text = string.Empty;
            txtPlacasCamion.Text = string.Empty;
        }
        private void LimpiarCamposChoferes()
        {
            txtIDChofer.Text = string.Empty;
            txtNombreChofer.Text = string.Empty;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValEmpAcarreo.GetSelectedRows())
                {
                    DataRow row = this.dtgValEmpAcarreo.GetDataRow(i);
                    textId.Text = row["Id_EmpresaAcarreo"].ToString();
                    textProveedor.Text = row["Nombre_EmpresaAcarreo"].ToString();
                    textTelefono.Text = row["Telefono1"].ToString();
                    textTelefono2.Text = row["Telefono2"].ToString();
                    textCorreo.Text = row["Email"].ToString();
                    textContacto.Text = row["Contacto"].ToString();
                    txtRFC.Text = row["RFC"].ToString();
                    groupControl2.Text = "Domicilio - " + textProveedor.Text;
                    groupControl3.Text = "Camion - " + textProveedor.Text;
                    groupControl4.Text = "Chofeer - " + textProveedor.Text;
                    labelControl23.Text = row["Nombre_EmpresaAcarreo"].ToString();
                    labelControl24.Text = row["Nombre_EmpresaAcarreo"].ToString();
                    labelControl26.Text = row["Nombre_EmpresaAcarreo"].ToString();
                    labelControl27.Text = row["Nombre_EmpresaAcarreo"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            CargarDomicilio();
            CargarCamiones();
            CargarChoferes();
            CargarServicios();
        }
        private void CargarServicios()
        {
            CLS_EmpresasAcarreo sel = new CLS_EmpresasAcarreo();
            sel.Id_EmpresaAcarreo = textId.Text.Trim();
            sel.MtdSeleccionarEmpresasServicios();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    txtPrecioServicio.Text = sel.Datos.Rows[0]["Precio_Acarreo"].ToString();
                    txtPrecioCaja.Text = sel.Datos.Rows[0]["Precio_Caja"].ToString();
                    txtPrecioSalidaForanea.Text = sel.Datos.Rows[0]["Precio_SalidaForanea"].ToString();
                }   
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
        }
        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                if (textProveedor.Text.ToString().Trim().Length > 0)
                {
                    InsertarEmpresaAcarreo();
                }
                else
                {
                    XtraMessageBox.Show("Es necesario Agregar un nombre a la Empresa.");
                }
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
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
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                if (txtNombreCamion.Text.ToString().Trim().Length > 0)
                {
                    InsertarCamiones();
                }
                else
                {
                    XtraMessageBox.Show("Es necesario agregar un nombre del camion.");
                }
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
            {
                if (txtNombreChofer.Text.ToString().Trim().Length > 0)
                {

                    InsertarChoferes();
                }
                else
                {
                    XtraMessageBox.Show("Es necesario agregar un nombre del chofer.");
                }
            }
            else
            {
                InsertarServicios();
            }
        }
        private void InsertarServicios()
        {
            CLS_EmpresasAcarreo ins = new CLS_EmpresasAcarreo();
            ins.Id_EmpresaAcarreo = textId.Text.Trim();
            decimal Precio_Acarreo = 0;
            decimal.TryParse(txtPrecioServicio.Text, style, culture, out Precio_Acarreo);
            ins.Precio_Acarreo = Precio_Acarreo;
            decimal Precio_Caja = 0;
            decimal.TryParse(txtPrecioCaja.Text, style, culture, out Precio_Caja);
            ins.Precio_Caja = Precio_Caja;
            decimal Precio_SalidaForanea = 0;
            decimal.TryParse(txtPrecioSalidaForanea.Text, style, culture, out Precio_SalidaForanea);
            ins.Precio_SalidaForanea = Precio_SalidaForanea;
            ins.Usuario = UsuariosLogin;
            ins.MtdInsertarEmpresasServicios();
            if (ins.Exito)
            {
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
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
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
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
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
                {
                    if (txtIDCamion.Text.Trim().Length > 0)
                    {
                        EliminarCamion();
                    }
                    else
                    {
                        XtraMessageBox.Show("Es necesario seleccionar un Camion.");
                    }
                }
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                {
                    if (txtIDChofer.Text.Trim().Length > 0)
                    {
                        EliminarChofer();
                    }
                    else
                    {
                        XtraMessageBox.Show("Es necesario seleccionar un chofer.");
                    }
                }
                else if (xtraTabControl1.SelectedTabPage == xtraTabPage5)
                {

                }
            }
        }
        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                LimpiarCampos();
                LimpiarCamposDomicilio();
                LimpiarCamposCamiones();
                LimpiarCamposChoferes();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                LimpiarCamposDomicilio();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                LimpiarCamposCamiones();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
            {
                LimpiarCamposChoferes();
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
                xtraTabPage3.PageEnabled = false;
                xtraTabPage4.PageEnabled = false;
                xtraTabPage5.PageEnabled = false;
                groupControl2.Text = "Domicilio";
                groupControl3.Text = "Camion";
                groupControl4.Text = "Chofeer";
            }
            else
            {
                xtraTabPage2.PageEnabled = true;
                xtraTabPage3.PageEnabled = true;
                xtraTabPage4.PageEnabled = true;
                xtraTabPage5.PageEnabled = true;
            }
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdProveedor = textId.Text.Trim();
            Proveedor = textProveedor.Text.Trim();
            this.Close();
        }

        private void dtgCamiones_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValCamiones.GetSelectedRows())
                {
                    DataRow row = this.dtgValCamiones.GetDataRow(i);
                    txtIDCamion.Text = row["Id_Camion"].ToString();
                    txtNombreCamion.Text = row["Nombre_Camion"].ToString();
                    txtPlacasCamion.Text = row["Placas"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgChoferes_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValChoferes.GetSelectedRows())
                {
                    DataRow row = this.dtgValChoferes.GetDataRow(i);
                    txtIDChofer.Text = row["Id_Chofer"].ToString();
                    txtNombreChofer.Text = row["Nombre_Chofer"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_EmpresaAcarreo_Shown(object sender, EventArgs e)
        {
            txtPrecioCaja.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioServicio.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioSalidaForanea.Properties.Mask.UseMaskAsDisplayFormat = true;
        }
    }
}