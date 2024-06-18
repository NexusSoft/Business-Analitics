using CapaDeDatos;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Business_Analitics
{

    public partial class Frm_EmpresaCorte : DevExpress.XtraEditors.XtraForm
    {
        public NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        public CultureInfo culture = CultureInfo.CreateSpecificCulture("es-MX");
        public Boolean PaSel { get; set; }
        public string IdProveedor { get; set; }
        public string Proveedor { get; set; }
        const string idTipoPersona = "0002";
        public string UsuariosLogin { get; set; }

        private static Frm_EmpresaCorte m_FormDefInstance;
        public static Frm_EmpresaCorte DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_EmpresaCorte();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }



        public Frm_EmpresaCorte()
        {
            InitializeComponent();
        }

        private void CargarEmpresas()
        {
            dtgEmpCorte.DataSource = null;
            CLS_EmpresasCorte Empresas = new CLS_EmpresasCorte();

            Empresas.MtdSeleccionarEmpresas();
            if (Empresas.Exito)
            {
                dtgEmpCorte.DataSource = Empresas.Datos;
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
        private void CargarServicios()
        {
            CLS_EmpresasCorte sel = new CLS_EmpresasCorte();
            sel.Id_EmpresaCorte = textId.Text.Trim();
            sel.MtdSeleccionarEmpresasServicios();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    txtPreciokg_Local.Text = sel.Datos.Rows[0]["Precio_kilo_Local"].ToString();
                    txtPorcentajeTolerancia.Text = sel.Datos.Rows[0]["PorcentajeTolerancia"].ToString();
                    txtKilosMenorA_Local.Text = sel.Datos.Rows[0]["Kilos_MenorA_Local"].ToString();
                    txtPrecioMenorA_Local.Text = sel.Datos.Rows[0]["Precio_MenorA_Local"].ToString();
                    txtPrecioApoyo_Local.Text = sel.Datos.Rows[0]["Precio_Cuadrilla_Apoyo_Local"].ToString();

                    txtPreciokg_Foraneo.Text = sel.Datos.Rows[0]["Precio_kilo_Foraneo"].ToString();
                    txtKilosMenorA_Foraneo.Text = sel.Datos.Rows[0]["Kilos_MenorA_Foraneo"].ToString();
                    txtPrecioMenorA_Foraneo.Text = sel.Datos.Rows[0]["Precio_MenorA_Foraneo"].ToString();
                    txtPrecioApoyo_Foraneo.Text = sel.Datos.Rows[0]["Precio_Cuadrilla_Apoyo_Foraneo"].ToString();
                }
                else
                {
                    txtPreciokg_Local.Text = "0";
                    txtKilosMenorA_Local.Text = "0";
                    txtPrecioMenorA_Local.Text = "0";
                        txtPrecioApoyo_Local.Text = "0";

                    txtPreciokg_Foraneo.Text = "0";
                    txtKilosMenorA_Foraneo.Text = "0";
                    txtPrecioMenorA_Foraneo.Text = "0";
                    txtPrecioApoyo_Foraneo.Text = "0";
                }
            }
        }
        private void InsertarEmpresas()
        {
            CLS_EmpresasCorte Empresas = new CLS_EmpresasCorte();
            Empresas.Id_EmpresaCorte = textId.Text.Trim();
            Empresas.Nombre_EmpresaCorte = textProveedor.Text.Trim();
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
        private void InsertarServicios()
        {
            CLS_EmpresasCorte ins = new CLS_EmpresasCorte();
            ins.Id_EmpresaCorte = textId.Text.Trim();

            decimal Precio_kilo_Local = 0;
            decimal.TryParse(txtPreciokg_Local.Text, style, culture, out Precio_kilo_Local);
            ins.Precio_kilo_Local = Precio_kilo_Local;

            decimal PorcentajeTolerancia = 0;
            decimal.TryParse(txtPorcentajeTolerancia.Text, style, culture, out PorcentajeTolerancia);
            ins.PorcentajeTolerancia = PorcentajeTolerancia;

            decimal Kilos_MenorA_Local = 0;
            decimal.TryParse(txtKilosMenorA_Local.Text, style, culture, out Kilos_MenorA_Local);
            ins.Kilos_MenorA_Local = Kilos_MenorA_Local;

            decimal Precio_MenorA_Local = 0;
            decimal.TryParse(txtPrecioMenorA_Local.Text, style, culture, out Precio_MenorA_Local);
            ins.Precio_MenorA_Local = Precio_MenorA_Local;

            decimal Precio_Cuadrilla_Apoyo_Local = 0;
            decimal.TryParse(txtPrecioApoyo_Local.Text, style, culture, out Precio_Cuadrilla_Apoyo_Local);
            ins.Precio_Cuadrilla_Apoyo_Local = Precio_Cuadrilla_Apoyo_Local;


            decimal Precio_kilo_Foraneo = 0;
            decimal.TryParse(txtPreciokg_Foraneo.Text, style, culture, out Precio_kilo_Foraneo);
            ins.Precio_kilo_Foraneo = Precio_kilo_Foraneo;

            decimal Kilos_MenorA_Foraneo = 0;
            decimal.TryParse(txtKilosMenorA_Foraneo.Text, style, culture, out Kilos_MenorA_Foraneo);
            ins.Kilos_MenorA_Foraneo = Kilos_MenorA_Foraneo;

            decimal Precio_MenorA_Foraneo = 0;
            decimal.TryParse(txtPrecioMenorA_Foraneo.Text, style, culture, out Precio_MenorA_Foraneo);
            ins.Precio_MenorA_Foraneo = Precio_MenorA_Foraneo;

            decimal Precio_Cuadrilla_Apoyo_Foraneo = 0;
            decimal.TryParse(txtPrecioApoyo_Foraneo.Text, style, culture, out Precio_Cuadrilla_Apoyo_Foraneo);
            ins.Precio_Cuadrilla_Apoyo_Foraneo = Precio_Cuadrilla_Apoyo_Foraneo;
            
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

        private void EliminarEmpresas()
        {
            CLS_EmpresasCorte Empresas = new CLS_EmpresasCorte();
            Empresas.Id_EmpresaCorte = textId.Text.Trim();
            Empresas.MtdEliminarEmpresas();
            if (Empresas.Exito)
            {
                EliminarDomicilioPersona();
                EliminarServicios();
                CargarEmpresas();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
                LimpiarCamposDomicilio();
                LimpiarCamposServicios();
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
        private void EliminarServicios()
        {
            CLS_EmpresasCorte del = new CLS_EmpresasCorte();
            del.Id_EmpresaCorte = textId.Text.Trim();
            del.MtdEliminarEmpresasServicios();
            if (del.Exito)
            {
                CargarServicios();

                LimpiarCamposDomicilio();
            }
            else
            {
                XtraMessageBox.Show(del.Mensaje);
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
            textId.Text = string.Empty;
            textProveedor.Text = string.Empty;
            textTelefono.Text = string.Empty;
            textTelefono2.Text = string.Empty;
            textCorreo.Text = string.Empty;
            textContacto.Text = string.Empty;
            txtRFC.Text = string.Empty;
            labelControl23.Text = string.Empty;
            labelControl30.Text = string.Empty;
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
        private void LimpiarCamposServicios()
        {
            txtPreciokg_Local.Text = "0";
            txtKilosMenorA_Local.Text = "0";
            txtPrecioMenorA_Local.Text = "0";
            txtPrecioApoyo_Local.Text = "0";

            txtPreciokg_Foraneo.Text = "0";
            txtKilosMenorA_Foraneo.Text = "0";
            txtPrecioMenorA_Foraneo.Text = "0";
            txtPrecioApoyo_Foraneo.Text = "0";
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValEmpCorte.GetSelectedRows())
                {
                    DataRow row = this.dtgValEmpCorte.GetDataRow(i);
                    textId.Text = row["Id_EmpresaCorte"].ToString();
                    textProveedor.Text = row["Nombre_EmpresaCorte"].ToString();
                    textTelefono.Text = row["Telefono1"].ToString();
                    textTelefono2.Text = row["Telefono2"].ToString();
                    textCorreo.Text = row["Email"].ToString();
                    textContacto.Text = row["Contacto"].ToString();
                    txtRFC.Text = row["RFC"].ToString();
                    labelControl23.Text = row["Nombre_EmpresaCorte"].ToString();
                    labelControl30.Text = row["Nombre_EmpresaCorte"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

            CargarDomicilio();
            CargarServicios();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                if (textProveedor.Text.ToString().Trim().Length > 0)
                {
                    InsertarEmpresas();
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
            else
            {
                InsertarServicios();
            }
        }
        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text != "00000000")
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
                    else
                    {
                        EliminarServicios();
                        XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Esta empresa no puede ser eliminada");
            }
        }
        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                LimpiarCampos();
                LimpiarCamposDomicilio();
                LimpiarCamposServicios();
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                LimpiarCamposDomicilio();
            }
            else
            {
                LimpiarCamposServicios();
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
            CargarServicios();
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
            }
            else
            {
                xtraTabPage2.PageEnabled = true;
                xtraTabPage3.PageEnabled = true;
            }
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdProveedor = textId.Text.Trim();
            Proveedor = textProveedor.Text.Trim();
            this.Close();
        }

        private void Frm_EmpresaCorte_Shown(object sender, EventArgs e)
        {
            txtPreciokg_Local.Properties.Mask.MaskType = MaskType.Numeric;
            txtPreciokg_Local.Properties.Mask.EditMask = "c2";
            txtPreciokg_Local.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtKilosMenorA_Local.Properties.Mask.MaskType = MaskType.Numeric;
            txtKilosMenorA_Local.Properties.Mask.EditMask = "n2";
            txtKilosMenorA_Local.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioMenorA_Local.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioMenorA_Local.Properties.Mask.EditMask = "c2";
            txtPrecioMenorA_Local.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioApoyo_Local.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioApoyo_Local.Properties.Mask.EditMask = "c2";
            txtPrecioApoyo_Local.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPreciokg_Foraneo.Properties.Mask.MaskType = MaskType.Numeric;
            txtPreciokg_Foraneo.Properties.Mask.EditMask = "c2";
            txtPreciokg_Foraneo.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtKilosMenorA_Foraneo.Properties.Mask.MaskType = MaskType.Numeric;
            txtKilosMenorA_Foraneo.Properties.Mask.EditMask = "n2";
            txtKilosMenorA_Foraneo.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioMenorA_Foraneo.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioMenorA_Foraneo.Properties.Mask.EditMask = "c2";
            txtPrecioMenorA_Foraneo.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioApoyo_Foraneo.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioApoyo_Foraneo.Properties.Mask.EditMask = "c2";
            txtPrecioApoyo_Foraneo.Properties.Mask.UseMaskAsDisplayFormat = true;

        }
    }
}