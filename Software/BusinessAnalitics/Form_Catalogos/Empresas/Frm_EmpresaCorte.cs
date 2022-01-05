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
using DevExpress.XtraEditors.Mask;
using System.Globalization;

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
                    txtMenorakg.Text = sel.Datos.Rows[0]["Menor_a_kg"].ToString();
                    txtPreciokg.Text = sel.Datos.Rows[0]["Precio_kilo"].ToString();
                    txtPrecioDia.Text = sel.Datos.Rows[0]["Precio_Dia"].ToString();
                    txtPrecioCuadrillaA.Text = sel.Datos.Rows[0]["Precio_Cuadrilla_Apoyo"].ToString();
                    if (sel.Datos.Rows[0]["EsRango"].ToString() == "True")
                    {
                        chk_Rango.Checked = true;
                    }
                    else
                    {
                        chk_Rango.Checked = false;
                    }
                    txtKilosMayorA.Text = sel.Datos.Rows[0]["Kilos_MayorA"].ToString();
                    txtKilosMenorA.Text = sel.Datos.Rows[0]["Kilos_MenorA"].ToString();
                    txtPrecioMayorA.Text = sel.Datos.Rows[0]["Precio_MayorA"].ToString();
                    txtPrecioMenorA.Text = sel.Datos.Rows[0]["Precio_MenorA"].ToString();

                    if (sel.Datos.Rows[0]["EsRangoCaja"].ToString() == "True")
                    {
                        chk_RangoCajas.Checked = true;
                    }
                    else
                    {
                        chk_RangoCajas.Checked = false;
                    }
                    txtCajasMayorA.Text = sel.Datos.Rows[0]["Cajas_MayorA"].ToString();
                    txtCajasMenorA.Text = sel.Datos.Rows[0]["Cajas_MenorA"].ToString();
                    txtPrecioCajaMayorA.Text = sel.Datos.Rows[0]["PrecioCaja_MayorA"].ToString();
                    txtPrecioCajaMenorA.Text = sel.Datos.Rows[0]["PrecioCaja_MenorA"].ToString();

                    txtPrecioSalidaFalso.Text = sel.Datos.Rows[0]["Precio_Salida_Falso"].ToString();
                }
                else
                {
                    txtMenorakg.Text = "0";
                    txtPreciokg.Text = "0";
                    txtPrecioDia.Text = "0";
                    txtPrecioCuadrillaA.Text = "0";

                    chk_RangoCajas.Checked = false;
                    txtCajasMayorA.Text = "0";
                    txtCajasMenorA.Text = "0";
                    txtPrecioCajaMayorA.Text = "0";
                    txtPrecioCajaMenorA.Text = "0";

                    chk_Rango.Checked = false;
                    txtKilosMayorA.Text = "0";
                    txtKilosMenorA.Text = "0";
                    txtPrecioMayorA.Text = "0";
                    txtPrecioMenorA.Text = "0";
                    txtPrecioSalidaFalso.Text = "0";
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
            decimal Menor_a_kg = 0;
            decimal.TryParse(txtMenorakg.Text, style, culture, out Menor_a_kg);
            ins.Menor_a_kg = Menor_a_kg;
            decimal Precio_kilo = 0;
            decimal.TryParse(txtPreciokg.Text, style, culture, out Precio_kilo);
            ins.Precio_kilo = Precio_kilo;
            decimal Precio_Dia = 0;
            decimal.TryParse(txtPrecioDia.Text, style, culture, out Precio_Dia);
            ins.Precio_Dia = Precio_Dia;
            decimal Precio_Cuadrilla_Apoyo = 0;
            decimal.TryParse(txtPrecioCuadrillaA.Text, style, culture, out Precio_Cuadrilla_Apoyo);
            ins.Precio_Cuadrilla_Apoyo = Precio_Cuadrilla_Apoyo;

            if (chk_RangoCajas.Checked == true)
            {
                ins.EsRangoCaja = 1;
            }
            else
            {
                ins.EsRangoCaja = 0;
            }

            decimal Cajas_MenorA = 0;
            decimal.TryParse(txtCajasMenorA.Text, style, culture, out Cajas_MenorA);
            ins.Cajas_MenorA = Cajas_MenorA;

            decimal Cajas_MayorA = 0;
            decimal.TryParse(txtCajasMayorA.Text, style, culture, out Cajas_MayorA);
            ins.Cajas_MayorA = Cajas_MayorA;

            decimal PrecioCajas_MenorA = 0;
            decimal.TryParse(txtPrecioCajaMenorA.Text, style, culture, out PrecioCajas_MenorA);
            ins.PrecioCaja_MenorA = PrecioCajas_MenorA;

            decimal PrecioCajas_MayorA = 0;
            decimal.TryParse(txtPrecioCajaMayorA.Text, style, culture, out PrecioCajas_MayorA);
            ins.PrecioCaja_MayorA = PrecioCajas_MayorA;

            if (chk_Rango.Checked==true)
            {
                ins.EsRango = 1;
            }
            else
            {
                ins.EsRango = 0;
            }

            decimal Kilos_MenorA = 0;
            decimal.TryParse(txtKilosMenorA.Text, style, culture, out Cajas_MenorA);
            ins.Kilos_MenorA = Cajas_MenorA;

            decimal Kilos_MayorA = 0;
            decimal.TryParse(txtKilosMayorA.Text, style, culture, out Cajas_MayorA);
            ins.Kilos_MayorA = Cajas_MayorA;

            decimal Precio_MenorA = 0;
            decimal.TryParse(txtPrecioMenorA.Text, style, culture, out PrecioCajas_MenorA);
            ins.Precio_MenorA = PrecioCajas_MenorA;

            decimal Precio_MayorA = 0;
            decimal.TryParse(txtPrecioMayorA.Text, style, culture, out PrecioCajas_MayorA);
            ins.Precio_MayorA = PrecioCajas_MayorA;

            decimal Precio_Salida_Falso = 0;
            decimal.TryParse(txtPrecioSalidaFalso.Text, style, culture, out Precio_Salida_Falso);
            ins.Precio_Salida_Falso = Precio_Salida_Falso;
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
        private void LimpiarCamposServicios()
        {
            txtMenorakg.Text = "0";
            txtPreciokg.Text = "0";
            txtPrecioDia.Text = "0";
            txtPrecioCuadrillaA.Text = "0";
            txtPrecioSalidaFalso.Tag = "0";
            txtKilosMayorA.Text = "0";
            txtKilosMenorA.Text = "0";
            txtPrecioMayorA.Text = "0";
            txtPrecioMenorA.Text = "0";
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
            txtMenorakg.Properties.Mask.MaskType = MaskType.Numeric;
            txtMenorakg.Properties.Mask.EditMask = "n2";
            txtMenorakg.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPreciokg.Properties.Mask.MaskType = MaskType.Numeric;
            txtPreciokg.Properties.Mask.EditMask = "c2";
            txtPreciokg.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioDia.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioDia.Properties.Mask.EditMask = "c2";
            txtPrecioDia.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioCuadrillaA.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioCuadrillaA.Properties.Mask.EditMask = "c2";
            txtPrecioCuadrillaA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioSalidaFalso.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioSalidaFalso.Properties.Mask.EditMask = "c2";
            txtPrecioSalidaFalso.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtKilosMayorA.Properties.Mask.MaskType = MaskType.Numeric;
            txtKilosMayorA.Properties.Mask.EditMask = "n0";
            txtKilosMayorA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtKilosMenorA.Properties.Mask.MaskType = MaskType.Numeric;
            txtKilosMenorA.Properties.Mask.EditMask = "n0";
            txtKilosMenorA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioMayorA.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioMayorA.Properties.Mask.EditMask = "c2";
            txtPrecioMayorA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioMenorA.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioMenorA.Properties.Mask.EditMask = "c2";
            txtPrecioMenorA.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtCajasMayorA.Properties.Mask.MaskType = MaskType.Numeric;
            txtCajasMayorA.Properties.Mask.EditMask = "n0";
            txtCajasMayorA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtCajasMenorA.Properties.Mask.MaskType = MaskType.Numeric;
            txtCajasMenorA.Properties.Mask.EditMask = "n0";
            txtCajasMenorA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioCajaMayorA.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioCajaMayorA.Properties.Mask.EditMask = "c2";
            txtPrecioCajaMayorA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioCajaMenorA.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioCajaMenorA.Properties.Mask.EditMask = "c2";
            txtPrecioCajaMenorA.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private void chk_Rango_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Rango.Checked==false)
            {
                txtPrecioCuadrillaA.Enabled = true;
                txtKilosMayorA.Enabled = false;
                txtKilosMenorA.Enabled = false;
                txtPrecioMayorA.Enabled = false;
                txtPrecioMenorA.Enabled = false;
            }
            else
            {
                txtPrecioCuadrillaA.Enabled = false;
                txtKilosMayorA.Enabled = true;
                txtKilosMenorA.Enabled = true;
                txtPrecioMayorA.Enabled = true;
                txtPrecioMenorA.Enabled = true;
            }
            InicializaApoyo();
        }

        private void InicializaApoyo()
        {
            txtPrecioCuadrillaA.Text = "0";
            txtKilosMayorA.Text = "0";
            txtKilosMenorA.Text = "0";
            txtPrecioMayorA.Text = "0";
            txtPrecioMenorA.Text = "0";
        }

        private void chk_RangoCajas_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Rango.Checked == false)
            {
                txtPreciokg.Enabled = true;
                txtCajasMayorA.Enabled = false;
                txtCajasMenorA.Enabled = false;
                txtPrecioCajaMayorA.Enabled = false;
                txtPrecioCajaMenorA.Enabled = false;
            }
            else
            {
                txtPreciokg.Enabled = false;
                txtCajasMayorA.Enabled = true;
                txtPrecioCajaMayorA.Enabled = true;
                txtCajasMenorA.Enabled = true;
                txtPrecioCajaMenorA.Enabled = true;
            }
            InicializaCajas();
        }
        private void InicializaCajas()
        {
            txtPreciokg.Text = "0";
            txtCajasMenorA.Text = "0";
            txtPrecioCajaMenorA.Text = "0";
            txtCajasMayorA.Text = "0";
            txtPrecioCajaMayorA.Text = "0";
        }
    }
}