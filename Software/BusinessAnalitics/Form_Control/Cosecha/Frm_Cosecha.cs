using CapaDeDatos;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;


namespace Business_Analitics
{
    public partial class Frm_Cosecha : DevExpress.XtraEditors.XtraForm
    {
        public string IdPerfil { get; set; }
        List<string> Lista = new List<string>();

        NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        CultureInfo provider = new CultureInfo("es-MX");
        Byte[] ArchivoPDFGlobalProductor = null;
        Byte[] ArchivoXMLGlobalProductor = null;
        Byte[] ArchivoPDFGlobalCorteKilos = null;
        Byte[] ArchivoXMLGlobalCorteKilos = null;
        Byte[] ArchivoPDFGlobalCorteDia = null;
        Byte[] ArchivoXMLGlobalCorteDia = null;
        Byte[] ArchivoPDFGlobalCorteApoyo = null;
        Byte[] ArchivoXMLGlobalCorteApoyo = null;
        Byte[] ArchivoPDFGlobalCorteSalida = null;
        Byte[] ArchivoXMLGlobalCorteSalida = null;
        Byte[] ArchivoPDFGlobalAcarreo = null;
        Byte[] ArchivoXMLGlobalAcarreo = null;
        //REP
        Byte[] ArchivoPDFGlobalProductorREP = null;
        Byte[] ArchivoXMLGlobalProductorREP = null;
        //ArchivoExpediente
        Byte[] ArchivoPDFGlobalTarjetaApeam = null;
        string vRutaTarjetaApeam = String.Empty;
        Byte[] ArchivoPDFGlobalIdentificacion_INE_IFE = null;
        string vRutaIdentificacion_INE_IFE = String.Empty;
        Byte[] ArchivoPDFGlobalOpinion_Cumplimiento = null;
        string vRutaOpinion_Cumplimiento = String.Empty;
        Byte[] ArchivoPDFGlobalConstancia_de_Situacion_Fiscal = null;
        string vRutaConstancia_de_Situacion_Fiscal = String.Empty;
        Byte[] ArchivoPDFGlobalClave_Interbancaria = null;
        string vRutaClave_Interbancaria = String.Empty;
        Byte[] ArchivoPDFGlobalContrato_entre_Terceros = null;
        string vRutaContrato_entre_Terceros = String.Empty;
        Byte[] ArchivoPDFGlobalContrato_GEST = null;
        string vRutaContrato_GEST = String.Empty;
        //Contrato Comercializadora
        Byte[] ArchivoPDFGlobalContratoComercializadora = null;
        string vRutaContratoComercializadora = string.Empty;

        public string TemActiva { get; private set; }
        public string vId_Cosecha { get; set; }
        public Boolean EsCorteLocal { get; set; }
        public Frm_Cosecha()
        {
            InitializeComponent();
        }
        public string UsuariosLogin { get; set; }

        private static Frm_Cosecha m_FormDefInstance;
        public static Frm_Cosecha DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Cosecha();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public int vCarga { get; set; }
        public DateTime vFechaProgramaProductor { get; set; }
        public DateTime vFechaFacturaProductor { get; set; }
        public DateTime vFechaFacturaCorteKilos { get; set; }
        public DateTime vFechaProgramaCorteKilos { get; set; }
        public DateTime vFechaFacturaCorteDia { get; set; }
        public DateTime vFechaProgramaCorteDia { get; set; }
        public DateTime vFechaFacturaCorteApoyo { get; set; }
        public DateTime vFechaProgramaCorteApoyo { get; set; }
        public DateTime vFechaFacturaCorteSalida { get; set; }
        public DateTime vFechaProgramaCorteSalida { get; set; }
        public DateTime vFechaProgramaAcarreo { get; set; }
        public DateTime vFechaFacturaAcarreo { get; set; }
        public decimal kiloscortados { get; set; }
        public decimal AjusteAcarreo { get; set; }

        void CargarCosechas()
        {
            CLS_Cosecha_Datos obtener = new CLS_Cosecha_Datos();
            obtener.Temporada = cmb_Temporada.EditValue.ToString();
            obtener.MtdSelecccionarGOrdencorte();
            if (obtener.Exito)
            {
                dtgCosecha.DataSource = obtener.Datos;
            }
        }
        private void Frm_Cosecha_Shown(object sender, EventArgs e)
        {
            vCarga = 1;
            rb_Bascula.SelectedIndex = 0;
            navigationPane1.SelectedPageIndex = 0;
            dtgValRecepcion.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValRecepcion.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValRecepcion.OptionsSelection.MultiSelect = true;
            dtgValRecepcion.OptionsView.ShowGroupPanel = false;
            dtgValRecepcion.OptionsBehavior.AutoPopulateColumns = true;
            dtgValRecepcion.OptionsView.ColumnAutoWidth = true;
            dtgValRecepcion.BestFitColumns();

            dtgValExportacion.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValExportacion.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValExportacion.OptionsSelection.MultiSelect = true;
            dtgValExportacion.OptionsView.ShowGroupPanel = false;
            dtgValExportacion.OptionsBehavior.AutoPopulateColumns = true;
            dtgValExportacion.OptionsView.ColumnAutoWidth = true;
            dtgValExportacion.BestFitColumns();

            dtgValNacional.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValNacional.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValNacional.OptionsSelection.MultiSelect = true;
            dtgValNacional.OptionsView.ShowGroupPanel = false;
            dtgValNacional.OptionsBehavior.AutoPopulateColumns = true;
            dtgValNacional.OptionsView.ColumnAutoWidth = true;
            dtgValNacional.BestFitColumns();

            dtgValMerma.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValMerma.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValMerma.OptionsSelection.MultiSelect = true;
            dtgValMerma.OptionsView.ShowGroupPanel = false;
            dtgValMerma.OptionsBehavior.AutoPopulateColumns = true;
            dtgValMerma.OptionsView.ColumnAutoWidth = true;
            dtgValMerma.BestFitColumns();


            gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn4.DisplayFormat.FormatString = "n0";
            gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn5.DisplayFormat.FormatString = "n2";
            gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn6.DisplayFormat.FormatString = "n0";
            gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn7.DisplayFormat.FormatString = "p2";

            gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn9.DisplayFormat.FormatString = "n0";
            gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn10.DisplayFormat.FormatString = "n3";
            gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn11.DisplayFormat.FormatString = "n3";
            gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn14.DisplayFormat.FormatString = "p2";

            gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn13.DisplayFormat.FormatString = "n0";
            gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn17.DisplayFormat.FormatString = "n3";
            gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn18.DisplayFormat.FormatString = "p2";

            gridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn21.DisplayFormat.FormatString = "n3";
            gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn22.DisplayFormat.FormatString = "p2";

            gridColumn41.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn41.DisplayFormat.FormatString = "c2";
            gridColumn42.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn42.DisplayFormat.FormatString = "c2";
            gridColumn43.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn43.DisplayFormat.FormatString = "c2";



            txt_KiloPrecio.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_KiloPrecioInicial.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_PagoTotalCorte.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_PrecioCuadrillaCorte.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_PrecioDiaCorte.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_PrecioKiloCorte.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_PrecioTCorte.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_SubTotalaPagar.Properties.Mask.UseMaskAsDisplayFormat = true;
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
            txtPrecioZona.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioEstado.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioCiudad.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioRabon.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioTorton.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_CajasProgramadasA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_Cajas_CortadasA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_CostoServicio.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_CostoxCajaExtra.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_TotalAcarreo.Properties.Mask.UseMaskAsDisplayFormat = true;
            btn_limpiarOrden.PerformClick();
            CargarTemporadaActiva();
            CargarTemporada(TemActiva);
            CargarCosechas();
        }
        private void CargarTemporadaActiva()
        {
            CLS_Temporada obtener = new CLS_Temporada();
            obtener.MtdSeleccionarEtiquetaTemporadaActiva();
            if (obtener.Exito)
            {
                if (obtener.Datos.Rows.Count > 0)
                {
                    TemActiva = obtener.Datos.Rows[0][0].ToString();
                }
            }
        }
        private void CargarTemporada(string Valor)
        {
            CLS_Temporada obtener = new CLS_Temporada();
            obtener.MtdSeleccionarEtiquetaTemporada();
            if (obtener.Exito)
            {
                if (obtener.Datos.Rows.Count > 0)
                {
                    CargarComboTemporada(obtener.Datos, Valor);
                }
            }
        }
        private void CargarComboTemporada(DataTable Datos, string Valor)
        {
            cmb_Temporada.Properties.DisplayMember = "c_codigo_tem";
            cmb_Temporada.Properties.ValueMember = "c_codigo_tem";
            cmb_Temporada.EditValue = Valor;
            cmb_Temporada.Properties.DataSource = Datos;
        }
        private void btnBusqProgramaCorte_Click(object sender, EventArgs e)
        {
            Frm_BuscarProgramaCorte frm = new Frm_BuscarProgramaCorte();
            frm.ShowDialog();
            vCarga = 1;
            btn_limpiarOrden.PerformClick();
            txt_ProgramaCorte.Text = frm.Id_ProgramaCorte;
            txt_Temporada.Text = frm.v_temporada;
            txt_Secuencia.Text = frm.v_secuencia;
            txt_OrdenCorte.Text = frm.v_ordencorte;
            if (txt_ProgramaCorte.Text != string.Empty && txt_Temporada.Text != string.Empty)
            {
                CargarProgramaCorte();
            }
            vCarga = 0;
        }

        private void CargarProgramaCorte()
        {
            CLS_Cosecha sel = new CLS_Cosecha();
            sel.c_codigo_tem = txt_Temporada.Text;
            sel.c_codigo_pco = txt_ProgramaCorte.Text;
            sel.c_codigo_oct = txt_OrdenCorte.Text;
            sel.c_secuencia_ocd = txt_Secuencia.Text;
            sel.MtdSeleccionarPrograma();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dt_FechaPrograma.DateTime = Convert.ToDateTime(sel.Datos.Rows[0]["d_fecha_pco"].ToString());
                    txt_Mercado.Text = sel.Datos.Rows[0]["c_mercado_pcd"].ToString();
                    if (txt_Mercado.Text == "Extranjero")
                    {
                        txt_KilosMuestra.Text = "17";
                        chk_Mercado.Checked = true;
                    }
                    else
                    {
                        txt_KilosMuestra.Text = "0";
                        chk_Mercado.Checked = false;
                    }
                    txt_Huerta.Text = sel.Datos.Rows[0]["v_nombre_hue"].ToString();
                    BarHuerta.Caption = "Huerta: " + sel.Datos.Rows[0]["v_nombre_hue"].ToString();
                    txt_Huerta.Tag = sel.Datos.Rows[0]["c_codigo_hue"].ToString();
                    txt_SAGARPA.Text = sel.Datos.Rows[0]["v_registro_hue"].ToString();
                    txt_Estado_Huerta.Text = sel.Datos.Rows[0]["v_nombre_est"].ToString();
                    txt_Acopiador.Text = sel.Datos.Rows[0]["v_nombre_zon"].ToString();
                    barComercializador.Caption = "Comercializador: " + sel.Datos.Rows[0]["v_nombre_zon"].ToString();
                    txt_Acopiador.Tag = sel.Datos.Rows[0]["c_codigo_zon"].ToString();
                    txt_Cajas_Programa.Text = sel.Datos.Rows[0]["n_cajas_pcd"].ToString();
                    txt_CajasProgramadasA.Text = sel.Datos.Rows[0]["n_cajas_pcd"].ToString();
                    txt_TipoCorte.Text = sel.Datos.Rows[0]["v_tipocorte_pcd"].ToString();
                    txtTipoCorteEC.Text = sel.Datos.Rows[0]["v_tipocorte_pcd"].ToString();
                    txt_OrdenCorte.Text = sel.Datos.Rows[0]["c_codigo_oct"].ToString();
                    txt_Secuencia.Text = sel.Datos.Rows[0]["c_secuencia_ocd"].ToString();
                    txt_Temporada.Text = sel.Datos.Rows[0]["c_codigo_tem"].ToString();
                    txt_Productor.Text = sel.Datos.Rows[0]["v_nombre_dno"].ToString();
                    txt_Comercializador.Text = sel.Datos.Rows[0]["v_nombre_zon"].ToString();
                    if (sel.Datos.Rows[0]["b_autorizausa_ase"].ToString() == "True")
                    {
                        chk_Autorizado_USA.Checked = true;
                    }
                    else
                    {
                        chk_Autorizado_USA.Checked = false;
                    }
                    txt_Poliza_ase.Text = sel.Datos.Rows[0]["c_poliza_ase"].ToString();
                    txt_Nombre_ase.Text = sel.Datos.Rows[0]["v_nombre_ase"].ToString();
                    BarProductor.Caption = "Productor: " + sel.Datos.Rows[0]["v_nombre_dno"].ToString();
                    if (txt_Temporada.Text != string.Empty && txt_OrdenCorte.Text != string.Empty && txt_Secuencia.Text != string.Empty)
                    {
                        CargarRecepcion();
                    }
                }
                else
                {
                    XtraMessageBox.Show("No se encontraron registros");
                }
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
        }



        private void CargarRecepcion()
        {
            CLS_Cosecha sel = new CLS_Cosecha();
            sel.c_codigo_tem = txt_Temporada.Text;
            sel.c_codigo_oct = txt_OrdenCorte.Text;
            sel.c_secuencia_ocd = txt_Secuencia.Text;
            sel.MtdSeleccionarRecepcion();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dt_FechaRecepcion.DateTime = Convert.ToDateTime(sel.Datos.Rows[0]["d_fecha_rec"].ToString());
                    txt_Recepcion.Text = sel.Datos.Rows[0]["c_codigo_rec"].ToString();
                    txt_EstibaSel.Text = sel.Datos.Rows[0]["c_codigo_sel"].ToString();
                    BarEstiba.Caption = "Estiba: " + sel.Datos.Rows[0]["c_codigo_sel"].ToString();
                    txt_CajasCortadas.Text = sel.Datos.Rows[0]["n_cajascorte_red"].ToString();
                    txt_Cajas_CortadasA.Text = sel.Datos.Rows[0]["n_cajascorte_red"].ToString();
                    txt_CajasCortadasCorte.Text = sel.Datos.Rows[0]["n_cajascorte_red"].ToString();
                    txt_KilosBExterna.Text = sel.Datos.Rows[0]["n_kilos_red"].ToString();
                    txt_KilosPromedio.Text = sel.Datos.Rows[0]["n_promxcaja_red"].ToString();
                    txt_TipoCultivo.Text = sel.Datos.Rows[0]["v_nombre_cul"].ToString();
                    txt_TipoCultivo.Tag = sel.Datos.Rows[0]["c_codigo_cul"].ToString();
                    txt_TicketPesada.Text = sel.Datos.Rows[0]["c_ticketbas_rec"].ToString();
                    if (txt_EstibaSel.Text != string.Empty && txt_Temporada.Text != string.Empty)
                    {
                        if (txt_KilosBExterna.Text != String.Empty && Decimal.Parse(txt_KilosBExterna.Text, style, provider) > 0)
                        {
                            CorridaBanda();
                            //txt_KilosBasculaE.Enabled = true;
                            //chk_kgProductor.Enabled = true;
                        }
                        else
                        {
                            //txt_KilosBasculaE.Enabled = false;
                            //chk_kgProductor.Enabled = false;
                        }
                    }
                }
                else
                {
                    if (Decimal.Parse(txt_KilosBExterna.Text, style, provider) > 0)
                    {
                        //txt_KilosBasculaE.Enabled = true;
                        //chk_kgProductor.Enabled = true;
                    }
                    else
                    {
                        //txt_KilosBasculaE.Enabled = false;
                        //chk_kgProductor.Enabled = false;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
        }

        private void CorridaBanda()
        {
            CargarCorrida();
            CargarExportacion();
            CargarNacional();
            CargarMerma();
        }

        private void CargarExportacion()
        {
            CLS_CorridaFruta sel = new CLS_CorridaFruta();
            sel.c_codigo_tem = txt_Temporada.Text;
            sel.c_codigo_sel = txt_EstibaSel.Text;
            sel.MtdSeleccionarRecepcion();
            if (sel.Exito)
            {
                dtgRecepcion.DataSource = sel.Datos;
            }
        }
        private void CargarNacional()
        {
            CLS_CorridaFruta sel = new CLS_CorridaFruta();
            sel.c_codigo_tem = txt_Temporada.Text;
            sel.c_codigo_sel = txt_EstibaSel.Text;
            sel.MtdSeleccionarNacional();
            if (sel.Exito)
            {
                dtgNacional.DataSource = sel.Datos;
            }
        }
        private void CargarMerma()
        {
            CLS_CorridaFruta sel = new CLS_CorridaFruta();
            sel.c_codigo_tem = txt_Temporada.Text;
            sel.c_codigo_sel = txt_EstibaSel.Text;
            sel.MtdSeleccionarMerma();
            if (sel.Exito)
            {
                dtgMerma.DataSource = sel.Datos;
            }
        }
        private void CargarCorrida()
        {
            CLS_CorridaFruta sel = new CLS_CorridaFruta();
            sel.c_codigo_tem = txt_Temporada.Text;
            sel.c_codigo_sel = txt_EstibaSel.Text;
            sel.MtdSeleccionarExportacion();
            if (sel.Exito)
            {
                dtgExportacion.DataSource = sel.Datos;
            }

        }

        private void btn_EmpresaBascula_Click(object sender, EventArgs e)
        {
            Frm_EmpresaBasculas frm = new Frm_EmpresaBasculas();
            frm.UsuariosLogin = UsuariosLogin;
            frm.PaSel = true;
            frm.ShowDialog();
            txt_EmpresaBascula.Text = frm.Proveedor;
            txt_EmpresaBascula.Tag = frm.IdProveedor;
        }

        void BorrarcontactoComer()
        {
            txt_EmpresaComercializadora.Text = string.Empty;
            txt_EmpresaComercializadora.Tag = string.Empty;
            txtNombreContacto.Text = string.Empty;
            txtTelefonoContacto.Text = string.Empty;
            txtCorreoContacto.Text = string.Empty;
        }
        private void btn_EmpresaComercializacion_Click(object sender, EventArgs e)
        {
            BorrarcontactoComer();
            Frm_EmpresaComercializadora frm = new Frm_EmpresaComercializadora();
            frm.UsuariosLogin = UsuariosLogin;
            frm.PaSel = true;
            frm.ShowDialog();
            if (!string.IsNullOrEmpty(frm.IdProveedor))
            {
                txt_EmpresaComercializadora.Text = frm.Proveedor;
                txt_EmpresaComercializadora.Tag = frm.IdProveedor;
                CargarContacto();
            }

        }
        private void CargarContacto()
        {
            CLS_EmpresasComercializadora_Contacto Contacto = new CLS_EmpresasComercializadora_Contacto();
            Contacto.Id_EmpresaComercializacion = txt_EmpresaComercializadora.Tag.ToString();
            Contacto.c_codigo_hue = txt_Huerta.Tag.ToString();
            Contacto.MtdSeleccionarContactoCosecha();
            if (Contacto.Exito)
            {
                if (Contacto.Datos.Rows.Count > 0)
                {
                    txtNombreContacto.Text = Contacto.Datos.Rows[0]["Nombre_Contacto"].ToString();
                    txtTelefonoContacto.Text = Contacto.Datos.Rows[0]["Telefono_Contacto"].ToString();
                    txtCorreoContacto.Text = Contacto.Datos.Rows[0]["EMail_Contacto"].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(Contacto.Mensaje);
            }
        }
        private void txt_KilosProductor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CalcularTotalRecepcion();
            }
        }

        private void CalcularTotalRecepcion()
        {
            //int KC = Convert.ToInt32(Decimal.Parse(txt_KilosCortados.Text, style, provider));
            //int KP = Convert.ToInt32(Decimal.Parse(txt_KilosBasculaE.Text, style, provider));
            //if (KC > 0 && KP > 0)
            //{
            //    int Res = KC - KP;

            //    if (Math.Abs(Res) > 49 && Math.Abs(Res) < 100)
            //    {
            //        int Div = Res / 2;
            //        txt_KilosDiferencia.Text = Res.ToString();
            //        txt_KilosAjuste.Text = Convert.ToString(Div);
            //        if (Res > 0)
            //        {
            //            txt_KilosProductor.Text = Convert.ToString(KP);
            //            txt_kilosST.Text = Convert.ToString(KC - Math.Abs(Div));
            //        }
            //        else
            //        {
            //            txt_KilosProductor.Text = Convert.ToString(KP);
            //            txt_kilosST.Text = Convert.ToString(KC + Math.Abs(Div));
            //        }
            //        txt_KilosAjustados.Text = txt_kilosST.Text;

            //    }
            //    else if (Math.Abs(Res) >= 100)
            //    {
            //        txt_KilosDiferencia.Text = Res.ToString();
            //        int ajuste = 0;
            //        if (Res > 0)
            //        {
            //            ajuste = Res - 49;
            //            txt_KilosAjuste.Text = Convert.ToString(ajuste);
            //            txt_KilosProductor.Text = Convert.ToString(KP);
            //            txt_kilosST.Text = Convert.ToString(KC - Math.Abs(ajuste)); ;
            //        }
            //        else
            //        {
            //            ajuste = Res + 49;
            //            txt_KilosAjuste.Text = Convert.ToString(ajuste);
            //            txt_KilosProductor.Text = Convert.ToString(KP);
            //            txt_kilosST.Text = Convert.ToString(KC + Math.Abs(ajuste));
            //        }
            //        txt_KilosAjustados.Text = txt_kilosST.Text;
            //    }
            //    else
            //    {
            //        txt_KilosAjuste.Text = "0";
            //        txt_KilosDiferencia.Text = Res.ToString();
            //        txt_kilosST.Text = Convert.ToString(KC);
            //        txt_KilosProductor.Text = Convert.ToString(KP);
            //        txt_KilosAjustados.Text = txt_kilosST.Text;
            //    }
            //    if (chk_kgCorte.Checked == false)
            //    {
            //        txt_kilosCortadosCorte.Text = Convert.ToString(KC);
            //    }
            //    else
            //    {
            //        txt_kilosCortadosCorte.Text = txt_KilosBasculaE.Text;
            //    }
            //    txt_kilos_Totales.Text = Convert.ToString(Convert.ToInt32(Decimal.Parse(txt_KilosAjustados.Text, style, provider)) - Convert.ToInt32(Decimal.Parse(txt_KilosMuestra.Text, style, provider)));
            //}
            //else
            //{
            //    XtraMessageBox.Show("No se han capturado kilos en recepcion o kilos en bascula productor");
            //}
        }

        private void CargarServicios()
        {
            CLS_EmpresasCorte sel = new CLS_EmpresasCorte();
            sel.Id_EmpresaCorte = txt_NombreEmpresaCorte.Tag.ToString();
            sel.MtdSeleccionarEmpresasServicios();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    txtPreciokg_Local.Text = sel.Datos.Rows[0]["Precio_kilo_Local"].ToString();
                    txtPorcentajeTolerancia.Text = decimal.Round(Convert.ToDecimal(sel.Datos.Rows[0]["PorcentajeTolerancia"].ToString()), 2).ToString();
                    labelMargen.Text = "Margen " +decimal.Round(Convert.ToDecimal( sel.Datos.Rows[0]["PorcentajeTolerancia"].ToString()),2).ToString() + " %";
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

        private void btn_EmpresaCorte_Click(object sender, EventArgs e)
        {
            Frm_EmpresaCorte frm = new Frm_EmpresaCorte();
            frm.UsuariosLogin = UsuariosLogin;
            frm.PaSel = true;
            frm.ShowDialog();
            if (!string.IsNullOrEmpty(frm.IdProveedor))
            {
                txt_NombreEmpresaCorte.Text = frm.Proveedor;
                txt_NombreEmpresaCorte.Tag = frm.IdProveedor;
                CargarServicios();
                if (rb_Bascula.SelectedIndex == 0)
                {
                    txt_kilosCortadosCorte.Text = txt_KilosBExterna.Text;
                }
                else
                {
                    txt_kilosCortadosCorte.Text = txt_KilosBFronterra.Text;
                }
                try
                {
                    decimal Peso = decimal.Parse(txt_kilosCortadosCorte.Text, style, provider);
                    txt_Margen.Text = Convert.ToString(Peso * (decimal.Round(Convert.ToDecimal(txtPorcentajeTolerancia.Text) / 100, 2)));
                }
                catch 
                {
                    XtraMessageBox.Show("No se han definido precio o tolerancia para esta empresa de corte");
                }
                //txt_kgNoSolicitados.Text = CalcularkilosNoDeseados();
                CalcularCostosCorte();
            }
        }

        private void CalcularCostosCorte()
        {
            //if (txt_kilosCortadosCorte.Text != string.Empty && Decimal.Parse(txt_kilosCortadosCorte.Text, style, provider) > 0)
            //{
            //    txt_Margen10.Text = Convert.ToString(Convert.ToDouble(txt_kilosCortadosCorte.Text) * 0.10);
            //    txt_kgNoSolicitados.Text = CalcularkilosNoDeseados();
            //    txt_KilosARestar.Text = (Decimal.Parse(txt_Margen10.Text, style, provider) - Decimal.Parse(txt_kgNoSolicitados.Text, style, provider)).ToString();
            //    if (Decimal.Parse(txt_KilosARestar.Text, style, provider) < 0)
            //    {
            //        txt_KilosAjustadosCorte.Text = (Decimal.Parse(txt_kilosCortadosCorte.Text, style, provider) - (Decimal.Parse(txt_KilosARestar.Text, style, provider) * (-1))).ToString();
            //    }
            //    else
            //    {
            //        txt_KilosAjustadosCorte.Text = txt_kilosCortadosCorte.Text;
            //    }
            //    if (Decimal.Parse(txt_kilosCortadosCorte.Text, style, provider) > Decimal.Parse(txtMenorakg.Text, style, provider) || chk_PrecioPorkg.Checked == true)
            //    {
            //        txt_PrecioKiloCorte.Text = txtPreciokg.Text;
            //        if (chk_RangoCajas.Checked == false)
            //        {
            //            txt_PrecioTCorte.Text = (Decimal.Parse(txt_KilosAjustadosCorte.Text, style, provider) * Decimal.Parse(txt_PrecioKiloCorte.Text, style, provider)).ToString();
            //        }
            //        else
            //        {
            //            if (Decimal.Parse(txt_CajasCortadasCorte.Text, style, provider) < Decimal.Parse(txtCajasMenorA.Text, style, provider))
            //            {
            //                txt_PrecioKiloCorte.Text = txtPrecioCajaMenorA.Text;
            //            }
            //            else
            //            {
            //                txt_PrecioKiloCorte.Text = txtPrecioCajaMayorA.Text;
            //            }
            //            txt_PrecioTCorte.Text = (Decimal.Parse(txt_KilosAjustadosCorte.Text, style, provider) * Decimal.Parse(txt_PrecioKiloCorte.Text, style, provider)).ToString();
            //        }
            //        txt_PrecioDiaCorte.Text = "0";
            //        txt_PagoTotalCorte.Text = txt_PrecioTCorte.Text;
            //    }
            //    else
            //    {
            //        //txt_PrecioKiloCorte.Text = txtPreciokg.Text;
            //        if (Decimal.Parse(txt_KilosARestar.Text, style, provider) < 0)
            //        {
            //            txt_PrecioTCorte.Text = Convert.ToString(Decimal.Parse(txt_PrecioKiloCorte.Text, style, provider) * Decimal.Parse(txt_KilosARestar.Text, style, provider));
            //        }
            //        else
            //        {
            //            txt_PrecioTCorte.Text = "0";
            //        }
            //        //txt_PrecioDiaCorte.Text = txtPrecioDia.Text;
            //    }
            //    txt_PrecioCuadrillaCorte.Text = "0";
            //    chk_CuadrillaApoyo.Enabled = true;
            //    txt_NoCuadrillas.Enabled = true;
            //    chk_CuadrillaApoyo.Checked = false;
            //    txt_PagoTotalCorte.Text = (Decimal.Parse(txt_PrecioTCorte.Text, style, provider) + Decimal.Parse(txt_PrecioCuadrillaCorte.Text, style, provider) + Decimal.Parse(txt_PrecioSalidaFCorte.Text, style, provider) + Decimal.Parse(txt_PrecioDiaCorte.Text, style, provider)).ToString();
            //}
            //else
            //{
            //    chk_CuadrillaApoyo.Enabled = false;
            //    txt_NoCuadrillas.Enabled = false;
            //}
        }
        private void CalcularCostosAcarreo()
        {
            if (txt_kilosCortadosCorte.Text != string.Empty)
            {
                txt_CostoServicio.Text = txtPrecioZona.Text;
                txt_CostoxCajaExtra.Text = "0";
                //txt_TotalAcarreo.EditValue = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider)).ToString();
            }
        }
        private string CalcularkilosNoDeseados()
        {
            string vTotal = string.Empty;
            decimal vtotalExp = 0, vtotalNal = 0, vtotalPorcentaje = 0;
            CLS_CorridaFruta selRec = new CLS_CorridaFruta();
            selRec.c_codigo_tem = txt_Temporada.Text;
            selRec.c_codigo_sel = txt_EstibaSel.Text;
            selRec.c_codigo_rec = txt_Recepcion.Text;
            selRec.MtdSeleccionarRecepcionCorte();
            if (selRec.Exito)
            {
                if (selRec.Datos.Rows.Count > 0)
                {
                    vtotalPorcentaje = Decimal.Parse(selRec.Datos.Rows[0]["Porcentaje"].ToString());
                }
                else
                {
                    vtotalPorcentaje = 0;
                }
            }
            else
            {
                XtraMessageBox.Show(selRec.Mensaje);
            }

            CLS_CorridaFruta selExt = new CLS_CorridaFruta();
            selExt.c_codigo_tem = txt_Temporada.Text;
            selExt.c_codigo_sel = txt_EstibaSel.Text;
            selExt.v_nombre_tipocorte = txtTipoCorteEC.Text;
            selExt.MtdSeleccionarExportacionCorte();
            if (selExt.Exito)
            {
                if (selExt.Datos.Rows.Count > 0)
                {
                    vtotalExp = Decimal.Parse(selExt.Datos.Rows[0]["PesoRealExp"].ToString());
                }
                else
                {
                    vtotalExp = 0;
                }
            }
            else
            {
                XtraMessageBox.Show(selExt.Mensaje);
            }

            CLS_CorridaFruta selNal = new CLS_CorridaFruta();
            selNal.c_codigo_tem = txt_Temporada.Text;
            selNal.c_codigo_sel = txt_EstibaSel.Text;
            selNal.v_nombre_tipocorte = txtTipoCorteEC.Text;
            selNal.MtdSeleccionarNacionalCorte();
            if (selNal.Exito)
            {
                if (selNal.Datos.Rows.Count > 0)
                {
                    vtotalNal = Decimal.Parse(selNal.Datos.Rows[0]["PesoRealNal"].ToString());
                }
                else
                {
                    vtotalNal = 0;
                }
            }
            else
            {
                XtraMessageBox.Show(selNal.Mensaje);
            }
            vTotal = Math.Round(((vtotalExp + vtotalNal) * vtotalPorcentaje), 4).ToString();
            //CLS_CorridaFruta selMer = new CLS_CorridaFruta();
            //selMer.c_codigo_tem = txt_Temporada.Text;
            //selMer.c_codigo_sel = txt_EstibaSel.Text;
            //selMer.MtdSeleccionarMerma();
            //if (selMer.Exito)
            //{
            //    dtgMerma.DataSource = Decimal.Parse(selExt.Datos.Rows[0][""].ToString());
            //}
            return vTotal;
        }

        private void chk_Mercado_CheckedChanged(object sender, EventArgs e)
        {
            CalcularkilosTipoMercado();
        }

        private void CalcularkilosTipoMercado()
        {
            decimal KilosAjustados = 0;
            decimal KilosMuestra = 0;
            decimal KilosDevolucion = 0;
            decimal KilosTotales = 0;
            if (chk_Mercado.Checked == true && txt_KilosAjustados.Text != string.Empty)
            {
                txt_KilosMuestra.Text = "17";
                KilosAjustados = Decimal.Parse(txt_KilosAjustados.Text, style, provider);
                KilosMuestra = Decimal.Parse(txt_KilosMuestra.Text, style, provider);
                KilosDevolucion = Decimal.Parse(txt_KilosDevolucion.Text, style, provider);
                KilosTotales = KilosAjustados - KilosMuestra - KilosDevolucion;
                txt_kilos_Totales.Text = Convert.ToString(KilosTotales);
            }
            else
            {
                txt_KilosMuestra.Text = "0";
                KilosAjustados = Decimal.Parse(txt_KilosAjustados.Text, style, provider);
                KilosMuestra = Decimal.Parse(txt_KilosMuestra.Text, style, provider);
                KilosDevolucion = Decimal.Parse(txt_KilosDevolucion.Text, style, provider);
                KilosTotales = KilosAjustados - KilosMuestra - KilosDevolucion;
                txt_kilos_Totales.Text = Convert.ToString(KilosTotales);
            }
            CalcularTotalaPagarProductor();
        }
        private void chk_CuadrillaApoyo_CheckedChanged(object sender, EventArgs e)
        {
            CalcularCuadrillasdeApoyo();
        }

        private void CalcularCuadrillasdeApoyo()
        {
            //if (chk_CuadrillaApoyo.Checked == true)
            //{
            //    if (chk_Rango.Checked == false)
            //    {
            //        txt_PrecioCuadrillaCorte.Text = Convert.ToString(Decimal.Parse(txtPrecioCuadrillaA.Text, style, provider) * Decimal.Parse(txt_NoCuadrillas.Text, style, provider));
            //    }
            //    else
            //    {
            //        if (Decimal.Parse(txt_KilosAjustadosCorte.Text, style, provider) < Decimal.Parse(txtKilosMenorA.Text, style, provider))
            //        {
            //            txt_PrecioCuadrillaCorte.Text = (Decimal.Parse(txtPrecioMenorA.Text, style, provider) * Decimal.Parse(txt_NoCuadrillas.Text, style, provider)).ToString();
            //        }
            //        else
            //        {
            //            txt_PrecioCuadrillaCorte.Text = (Decimal.Parse(txtPrecioMayorA.Text, style, provider) * Decimal.Parse(txt_NoCuadrillas.Text, style, provider)).ToString();
            //        }
            //        txt_PrecioTCorte.Text = (Decimal.Parse(txt_KilosAjustadosCorte.Text, style, provider) * Decimal.Parse(txt_PrecioKiloCorte.Text, style, provider)).ToString();
            //    }
            //}
            //else
            //{
            //    txt_PrecioCuadrillaCorte.Text = "0";
            //}
            //txt_PagoTotalCorte.Text = (Decimal.Parse(txt_PrecioTCorte.Text, style, provider) + Decimal.Parse(txt_PrecioCuadrillaCorte.Text, style, provider) + Decimal.Parse(txt_PrecioSalidaFCorte.Text, style, provider)).ToString();
        }

        //private void txt_KilosARestar_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (Decimal.Parse(txt_KilosARestar.Text, style, provider) > 0)
        //    {
        //        txt_KilosARestar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        txt_KilosARestar.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
        //        txt_KilosARestar.Properties.Appearance.Options.UseFont = true;
        //        txt_KilosARestar.Properties.Appearance.Options.UseForeColor = true;
        //    }
        //    else
        //    {
        //        txt_KilosARestar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        txt_KilosARestar.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
        //        txt_KilosARestar.Properties.Appearance.Options.UseFont = true;
        //        txt_KilosARestar.Properties.Appearance.Options.UseForeColor = true;
        //    }
        //}

        private void btn_kilosND_Click(object sender, EventArgs e)
        {
            Frm_CosechaKgNoSolicitados frm = new Frm_CosechaKgNoSolicitados();
            frm.c_codigo_tem = txt_Temporada.Text;
            frm.c_codigo_sel = txt_EstibaSel.Text;
            frm.c_codigo_rec = txt_Recepcion.Text;
            frm.v_nombre_tipocorte = txt_TipoCorte.Text;
            frm.ShowDialog();
        }
        private void txt_KiloPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CalcularTotalaPagarProductor();
            }
        }

        private void CalcularTotalaPagarProductor()
        {
            decimal vKiloPrecio = 0;
            if (Decimal.TryParse(txt_KiloPrecio.EditValue.ToString(), out vKiloPrecio) && Decimal.Parse(txt_kilos_Totales.Text, style, provider) > 0)
            {
                txt_SubTotalaPagar.EditValue = (Decimal.Parse(txt_KiloPrecio.Text, style, provider) * Decimal.Parse(txt_kilos_Totales.Text, style, provider)).ToString();
            }
        }

        private void CargarServiciosAcarreo()
        {
            CLS_EmpresasAcarreo sel = new CLS_EmpresasAcarreo();
            sel.Id_EmpresaAcarreo = txt_EmpresaAcarreo.Tag.ToString();
            sel.MtdSeleccionarEmpresasCostoServicios();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    txtPrecioZona.Text = sel.Datos.Rows[0]["Precio_Acarreo"].ToString();
                    txtPrecioEstado.Text = sel.Datos.Rows[0]["Precio_SalidaForanea"].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
        }
        private void CargarCostosServicios()
        {
            CLS_EmpresasAcarreo sel = new CLS_EmpresasAcarreo();
            sel.c_codigo_hue = txt_Huerta.Tag.ToString().Trim();
            sel.MtdSeleccionarEmpresasServicios();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    txtPrecioZona.Text = sel.Datos.Rows[0]["v_nombre_zona"].ToString();
                    txtPrecioEstado.Text = sel.Datos.Rows[0]["v_nombre_est"].ToString();
                    txtPrecioCiudad.Text = sel.Datos.Rows[0]["v_nombre_ciu"].ToString();
                    txtPrecioRabon.Text = sel.Datos.Rows[0]["Rabon"].ToString();
                    txtPrecioTorton.Text = sel.Datos.Rows[0]["Torton"].ToString();
                    txtPrecioContenedor.Text = sel.Datos.Rows[0]["Contenedor"].ToString();
                    txtPreciokgRabon.Text = sel.Datos.Rows[0]["kgRabon"].ToString();
                    txtPreciokgTorton.Text = sel.Datos.Rows[0]["kgTorton"].ToString();
                    txtPreciokgContenedor.Text = sel.Datos.Rows[0]["kgContenedor"].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
        }
        private void CargarCajasProgCort()
        {
            CLS_Cosecha sel = new CLS_Cosecha();
            sel.c_codigo_tem = txt_Temporada.Text;
            sel.c_codigo_pco = txt_ProgramaCorte.Text;
            sel.c_codigo_oct = txt_OrdenCorte.Text;
            sel.c_secuencia_ocd = txt_Secuencia.Text;
            sel.MtdSeleccionarPrograma();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    txt_CajasProgramadasA.Text = sel.Datos.Rows[0]["n_cajas_pcd"].ToString();
                }
                else
                {
                    XtraMessageBox.Show("No se encontraron registros");
                }
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
            CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.MtdSelecccionarRecepcion();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    txt_Cajas_CortadasA.EditValue = ins.Datos.Rows[0]["CajasCortadas"].ToString();
                }
                else
                {
                    XtraMessageBox.Show("No se encontraron registros");
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        private void btn_EmpresaAcarreo_Click(object sender, EventArgs e)
        {
            Frm_EmpresaAcarreo frm = new Frm_EmpresaAcarreo();
            frm.UsuariosLogin = UsuariosLogin;
            frm.PaSel = true;
            frm.ShowDialog();
            if (!string.IsNullOrEmpty(frm.IdProveedor))
            {
                txt_EmpresaAcarreo.Text = frm.Proveedor;
                txt_EmpresaAcarreo.Tag = frm.IdProveedor;
                CalcularAcarreo();
            }
        }

        private void CalcularAcarreo()
        {

            kiloscortados = 0;
            AjusteAcarreo = 0;
            if (rb_Bascula.SelectedIndex == 0)
            {
                kiloscortados = Convert.ToDecimal(txt_KilosBExterna.Text);
            }
            else
            {
                kiloscortados = Convert.ToDecimal(txt_KilosBFronterra.Text);
            }
            
            CargarCajasProgCort();
            CargarCostosServicios();
            if (Convert.ToInt32(txt_CajasProgramadasA.Text) <= 400)
            {
                txt_CostoServicio.Text = txtPrecioRabon.Text;
                txtTipoCamion.Text = "Rabon";

                if (kiloscortados < Convert.ToDecimal(txtPreciokgRabon.Text))
                {
                    AjusteAcarreo = Decimal.Parse(txt_CostoServicio.Text, style, provider) - ((Decimal.Parse(txt_CostoServicio.Text, style, provider) / Decimal.Parse(txtPreciokgRabon.Text, style, provider)) * kiloscortados);
                    txt_AjusteAcarreoProductor.Text = AjusteAcarreo.ToString();
                }
            }
            else if (Convert.ToInt32(txt_CajasProgramadasA.Text) > 400 && Convert.ToInt32(txt_CajasProgramadasA.Text) <= 700)
            {
                txt_CostoServicio.Text = txtPrecioTorton.Text;
                txtTipoCamion.Text = "Torton";
                if (kiloscortados < Convert.ToDecimal(txtPreciokgTorton.Text))
                {
                    AjusteAcarreo = Decimal.Parse(txt_CostoServicio.Text, style, provider) - ((Decimal.Parse(txt_CostoServicio.Text, style, provider) / Decimal.Parse(txtPreciokgTorton.Text, style, provider)) * kiloscortados);
                    txt_AjusteAcarreoProductor.Text = AjusteAcarreo.ToString();
                }
            }
            else if (Convert.ToInt32(txt_CajasProgramadasA.Text) > 700)
            {
                txt_CostoServicio.Text = txtPrecioContenedor.Text;
                txtTipoCamion.Text = "Contenedor";
                if (kiloscortados < Convert.ToDecimal(txtPreciokgContenedor.Text))
                {
                    AjusteAcarreo = Decimal.Parse(txt_CostoServicio.Text, style, provider) - ((Decimal.Parse(txt_CostoServicio.Text, style, provider) / Decimal.Parse(txtPreciokgContenedor.Text, style, provider)) * kiloscortados);
                    txt_AjusteAcarreoProductor.Text = AjusteAcarreo.ToString();
                }
            }

        }

        private void cmb_Camiones_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_EmpresaAcarreo.Tag.ToString()))
                {
                    CLS_Camiones sel = new CLS_Camiones();
                    sel.Id_EmpresaAcarreo = txt_EmpresaAcarreo.Tag.ToString();
                    sel.MtdSeleccionarCamionPlaca();
                    if (sel.Exito)
                    {
                        if (sel.Datos.Rows.Count > 0)
                        {
                           
                            CargarServiciosAcarreo();
                            CalcularCostosAcarreo();
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        //private void chk_kgProductor_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chk_kgProductor.Checked == true)
        //    {
        //        txt_kilosST.Text = txt_KilosBasculaE.Text;
        //        txt_KilosAjustados.Text = txt_kilosST.Text;
        //        txt_kilos_Totales.Text = Convert.ToString(Convert.ToInt32(Decimal.Parse(txt_KilosAjustados.Text, style, provider)) - Convert.ToInt32(Decimal.Parse(txt_KilosMuestra.Text, style, provider)));
        //    }
        //    else
        //    {
        //        CalcularTotalRecepcion();
        //    }
        //    if (chk_kgCorte.Checked == true)
        //    {
        //        if (Convert.ToDecimal(txt_KilosBasculaE.Text) > 0)
        //        {
        //            txt_kilosCortadosCorte.Text = txt_KilosBasculaE.Text;
        //        }
        //    }
        //    else
        //    {
        //        txt_kilosCortadosCorte.Text = txt_KilosCortados.Text;
        //    }
        //    CalcularkilosTipoMercado();
        //    CalcularCostosCorte();

        //}
        void GuardarRuta(string fileName)
        {
            string ruta = string.Empty;
            string[] carpetas = fileName.ToString().Split('\\');
            for (int i = 0; i < carpetas.Length - 1; i++)
            {
                if (carpetas[i].ToString() == string.Empty)
                {
                    ruta = ruta + "\\";
                }
                else
                {
                    ruta = ruta + carpetas[i].ToString() + "\\";
                }
            }
            MSRegistro RegIn = new MSRegistro();
            RegIn.SaveSetting("ConexionSQL", "Ultima_Ruta", ruta);
        }
        string ObtenerRuta()
        {
            string ruta = string.Empty;
            try
            {
                MSRegistro RegOut = new MSRegistro();
                ruta = RegOut.GetSetting("ConexionSQL", "Ultima_Ruta");
            }
            catch (Exception)
            {
                MSRegistro RegIn = new MSRegistro();
                RegIn.SaveSetting("ConexionSQL", "Ultima_Ruta", string.Empty);
                ruta = string.Empty;
            }
            return ruta;
        }

        private DialogResult FileDialogPDF()
        {
            OpenDialog.FileName = string.Empty;
            OpenDialog.Filter = "Portable Document Format (*.PDF)|*.PDF";
            OpenDialog.FilterIndex = 1;
            string ruta = ObtenerRuta();
            if (string.IsNullOrEmpty(ruta))
            {
                OpenDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
            {
                OpenDialog.InitialDirectory = ruta;
            }
            OpenDialog.Title = "Cargar Documento PDF";
            OpenDialog.CheckFileExists = false;
            OpenDialog.Multiselect = false;
            OpenDialog.DefaultViewMode = DevExpress.Dialogs.Core.View.ViewMode.Details;
            DialogResult result = OpenDialog.ShowDialog();
            return result;
        }
        private DialogResult FileDialogXML()
        {
            OpenDialog.FileName = string.Empty;
            OpenDialog.Filter = "eXtensible Markup Language (*.XML)|*.XML";
            OpenDialog.FilterIndex = 1;
            string ruta = ObtenerRuta();
            if (ruta == string.Empty)
            {
                OpenDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
            {
                OpenDialog.InitialDirectory = ruta;
            }
            OpenDialog.Title = "Cargar Documento XML";
            OpenDialog.CheckFileExists = false;
            OpenDialog.Multiselect = false;
            OpenDialog.DefaultViewMode = DevExpress.Dialogs.Core.View.ViewMode.Details;
            DialogResult result = OpenDialog.ShowDialog();
            return result;
        }

        void LimpiarOrdenCorte()
        {
            txt_IdCosecha.Text = string.Empty;
            txt_ProgramaCorte.Text = string.Empty;
            dt_FechaPrograma.EditValue = DateTime.Now;
            txt_Temporada.Text = string.Empty;
            txt_Mercado.Text = string.Empty;
            txt_Huerta.Text = string.Empty;
            txt_Acopiador.Text = string.Empty;
            txt_Cajas_Programa.EditValue = "0";
            txt_TipoCorte.Text = string.Empty;
        }
        void LimpiarRecepcion()
        {
            //chk_kgProductor.Checked = false;
            txt_OrdenCorte.Text = string.Empty;
            txt_Secuencia.Text = string.Empty;
            txt_Recepcion.Text = string.Empty;
            txt_TicketPesada.Text = string.Empty;
            txt_EstibaSel.Text = string.Empty;
            txt_CajasCortadas.EditValue = "0";
            txt_KilosBExterna.EditValue = "0";
            txt_KilosPromedio.EditValue = "0";
            txt_TipoCultivo.Text = string.Empty;
            dt_FechaRecepcion.EditValue = DateTime.Now;
            txt_EmpresaBascula.Text = string.Empty;
            txt_EmpresaBascula.Tag = string.Empty;
            //txt_KilosBasculaE.EditValue = "0";
            //txt_KilosDiferencia.EditValue = "0";
            //txt_KilosAjuste.EditValue = "0";
            //txt_kilosST.EditValue = "0";
            //txt_KilosProductor.EditValue = "0";
        }
        void LimpiarComercializadora()
        {
            txt_EmpresaComercializadora.Text = string.Empty;
            txt_EmpresaComercializadora.Tag = string.Empty;
            txtNombreContacto.Text = string.Empty;
            txtTelefonoContacto.Text = string.Empty;
            txtCorreoContacto.Text = string.Empty;
        }
        void LimpiarProductor()
        {
            txt_Comercializador.Text = string.Empty;
            txt_Productor.Text = string.Empty;
            txt_KilosAjustados.EditValue = "0";
            txt_KilosMuestra.EditValue = "0";
            txt_kilos_Totales.EditValue = "0";
            txt_KiloPrecio.EditValue = "0";
            txt_KiloPrecioInicial.EditValue = "0";
            txt_SubTotalaPagar.EditValue = "0";
            txt_ObservacionesProductor.Text = string.Empty;
            chk_Mercado.Checked = false;
        }
        void LimpiarCorte()
        {
            txt_NombreEmpresaCorte.Text = string.Empty;
            txt_NombreEmpresaCorte.Tag = string.Empty;
            txtTipoCorteEC.Text = string.Empty;
            txt_kilosCortadosCorte.EditValue = "0";
            txt_Margen.EditValue = "0";
            txt_KilosAjustadosCorte.EditValue = "0";
            txt_CajasCortadasCorte.EditValue = "0";
            txt_PrecioKiloCorte.EditValue = "0";
            txt_PrecioTCorte.EditValue = "0";
            txt_PrecioDiaCorte.EditValue = "0";
            txt_PrecioCuadrillaCorte.EditValue = "0";
            txt_PagoTotalCorte.EditValue = "0";
            txt_ObservacionesCorte.Text = string.Empty;
            txt_NoCuadrillas.Value = 1;
            LimpiarCamposServiciosCorte();
        }
        private void LimpiarCamposServiciosCorte()
        {
            txtPreciokg_Local.EditValue = "0";
            txtKilosMenorA_Local.EditValue = "0";
            txtPrecioMenorA_Local.EditValue = "0";
            txtPrecioApoyo_Local.EditValue = "0";
            txtPreciokg_Foraneo.EditValue = "0";
            txtKilosMenorA_Foraneo.EditValue = "0";
            txtPrecioMenorA_Foraneo.EditValue = "0";
            txtPrecioApoyo_Foraneo.EditValue = "0";
        }
        void LimpiarAcarreo()
        {
            txt_EmpresaAcarreo.Text = string.Empty;
            txt_EmpresaAcarreo.Tag = string.Empty;
            txt_CajasProgramadasA.EditValue = "0";
            txt_Cajas_CortadasA.EditValue = "0";
            txtTipoCamion.Text= string.Empty;
            txt_CostoServicio.EditValue = "0";
            txt_CostoxCajaExtra.EditValue = "0";
            txt_CargosExtra.EditValue = "0";
            txt_Descuentos.EditValue = "0";
            txt_TotalAcarreo.EditValue = "0";
            txt_AjusteAcarreoProductor.EditValue = "0";
            txt_ObservacionesAcarreo.Text = string.Empty;

            txtPrecioZona.Text = string.Empty;
            txtPrecioEstado.Text = string.Empty;
            txtPrecioCiudad.Text = string.Empty;
            txtPrecioRabon.EditValue = "0";
            txtPrecioTorton.EditValue = "0";
            txtPrecioContenedor.EditValue = "0";
        }

        private void btn_limpiarOrden_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vCarga = 1;
            LimpiarOrdenCorte();
            LimpiarRecepcion();
            LimpiarComercializadora();
            LimpiarProductor();
            LimpiarCorte();
            LimpiarAcarreo();

            InicializaVariables();
            navigationPane1.SelectedPageIndex = 0;
            BarProductor.Caption = string.Empty;
            BarHuerta.Caption = string.Empty;
            BarEstiba.Caption = string.Empty;
            Bloquear_OrdenCorte(true);
            Bloquear_Recepcion(true);
            Bloquear_Productor(true);
            Bloquear_Comercializacion(true);

            vCarga = 0;

        }


        private void InicializaVariables()
        {
            ArchivoPDFGlobalProductor = null;
            ArchivoXMLGlobalProductor = null;
            ArchivoPDFGlobalCorteKilos = null;
            ArchivoXMLGlobalCorteKilos = null;
            ArchivoPDFGlobalCorteDia = null;
            ArchivoXMLGlobalCorteDia = null;
            ArchivoPDFGlobalCorteApoyo = null;
            ArchivoXMLGlobalCorteApoyo = null;
            ArchivoPDFGlobalCorteSalida = null;
            ArchivoXMLGlobalCorteSalida = null;
            ArchivoPDFGlobalAcarreo = null;
            ArchivoXMLGlobalAcarreo = null;
        }

        public string DosCeros(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }

        private void btn_GuardarOrden_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vId_Cosecha = "0";
            GuardarOrdenCorte();
            if (vId_Cosecha != "0")
            {
                GuardarRecepcion();
                GuardarComercializadora();
                GuardarAcarreo();
                GuardarCorte();
                GuardarProductor();

                XtraMessageBox.Show("Se ha guardado el registro con exito");
            }
            CargarCosechas();
        }



        private void GuardarOrdenCorte()
        {
            if (txt_ProgramaCorte.Text != String.Empty)
            {

                CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
                ins.Id_Cosecha = txt_IdCosecha.Text;
                ins.ProgramaCorte = txt_ProgramaCorte.Text;
                ins.ProgramaFecha = dt_FechaPrograma.DateTime.Year.ToString() + DosCeros(dt_FechaPrograma.DateTime.Month.ToString()) + DosCeros(dt_FechaPrograma.DateTime.Day.ToString());
                ins.Temporada = txt_Temporada.Text;
                ins.Mercado = txt_Mercado.Text;
                ins.c_codigo_hue = txt_Huerta.Tag.ToString();
                ins.Huerta = txt_Huerta.Text;
                ins.SAGARPA = txt_SAGARPA.Text;
                ins.Estado_Huerta = txt_Estado_Huerta.Text;
                ins.Acopiador = txt_Acopiador.Text;
                ins.ProgramaCajas = Convert.ToInt32(txt_Cajas_Programa.EditValue);
                ins.TipoCorte = txt_TipoCorte.Text;
                if (chk_Autorizado_USA.Checked == true)
                {
                    ins.Autorizado_USA = 1;
                }
                else
                {
                    ins.Autorizado_USA = 0;
                }
                ins.Poliza_aseguradora = txt_Poliza_ase.Text;
                ins.Aseguradora = txt_Nombre_ase.Text;
                ins.Usuario = UsuariosLogin;
                if (txt_IdCosecha.Text != String.Empty)
                {
                    ins.MtdInsertarOrdencorte();
                    if (ins.Exito)
                    {
                        vId_Cosecha = ins.Datos.Rows[0]["Id_Cosecha"].ToString();
                        txt_IdCosecha.EditValue = vId_Cosecha;
                    }
                    else
                    {
                        vId_Cosecha = "0";
                    }
                }
                else
                {
                    DialogResult = XtraMessageBox.Show("¿Desea realmente guardar la cosecha?", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (DialogResult == DialogResult.Yes)
                    {
                        ins.MtdInsertarOrdencorte();
                        if (ins.Exito)
                        {
                            vId_Cosecha = ins.Datos.Rows[0]["Id_Cosecha"].ToString();
                            txt_IdCosecha.EditValue = vId_Cosecha;
                        }
                        else
                        {
                            vId_Cosecha = "0";
                        }
                    }
                    else
                    {
                        vId_Cosecha = "0";
                    }
                }

            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado un programa de corte");
            }
        }
        private void GuardarRecepcion()
        {
            CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.OrdendeCorte = txt_OrdenCorte.Text;
            ins.Secuencia = txt_Secuencia.Text;
            ins.RecepcionCodigo = txt_Recepcion.Text;
            ins.TicketPesada = txt_TicketPesada.Text;
            ins.EstibadeSeleccion = txt_EstibaSel.Text;
            ins.CajasCortadas = Convert.ToDecimal(txt_CajasCortadas.EditValue);
            ins.KilosCortados = Convert.ToDecimal(txt_KilosBExterna.EditValue);
            ins.KilosPromedio = Convert.ToDecimal(txt_KilosPromedio.EditValue);
            ins.TipoCultivo = txt_TipoCultivo.Text;
            ins.RecepcionFecha = dt_FechaRecepcion.DateTime.Year.ToString() + DosCeros(dt_FechaRecepcion.DateTime.Month.ToString()) + DosCeros(dt_FechaRecepcion.DateTime.Day.ToString());
            try
            {
                ins.Id_EmpresaBascula = txt_EmpresaBascula.Tag.ToString();
            }
            catch (Exception)
            {

                ins.Id_EmpresaBascula = String.Empty;
            }
            ins.Nombre_EmpresaBascula = txt_EmpresaBascula.Text;
            //ins.KilosBasculaExterna = Convert.ToDecimal(txt_KilosBasculaE.EditValue);
            //if (chk_kgProductor.Checked == true)
            //{
            //    ins.TomarkgProductor = 1;
            //}
            //else
            //{
            //    ins.TomarkgProductor = 0;
            //}
            //if (chk_kgCorte.Checked == true)
            //{
            //    ins.TomarkgenCorte = 1;
            //}
            //else
            //{
            //    ins.TomarkgenCorte = 0;
            //}
            //ins.KilosDiferencia = Convert.ToDecimal(txt_KilosDiferencia.EditValue);
            //ins.Ajuste = Convert.ToDecimal(txt_KilosAjuste.EditValue);
            //ins.KilosST = Convert.ToDecimal(txt_kilosST.EditValue);
            //ins.KilosProductor = Convert.ToDecimal(txt_KilosProductor.EditValue);
            ins.Usuario = UsuariosLogin;
            ins.MtdInsertarRecepcion();
            if (!ins.Exito)
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        private void GuardarComercializadora()
        {
            Byte[] ArchivoPDFContratoComercializadora = null;
            FileStream fsPDF = null;
#pragma warning disable CS0219 // La variable 'noentroPDFContratoComercializadora' está asignada pero su valor nunca se usa
            Boolean noentroPDFContratoComercializadora = true;
#pragma warning restore CS0219 // La variable 'noentroPDFContratoComercializadora' está asignada pero su valor nunca se usa

            if (vRutaContratoComercializadora.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(vRutaContratoComercializadora, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDFContratoComercializadora = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDFContratoComercializadora, 0, (int)fsPDF.Length);
                ArchivoPDFGlobalContratoComercializadora = ArchivoPDFContratoComercializadora;
            }
            else
            {
                ArchivoPDFContratoComercializadora = ArchivoPDFGlobalContratoComercializadora;
                noentroPDFContratoComercializadora = false;
            }

            DateTime vFecha = DateTime.Now;
            CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            try
            {
                ins.Id_EmpresaComercializacion = txt_EmpresaComercializadora.Tag.ToString();
            }
            catch (Exception)
            {
                ins.Id_EmpresaComercializacion = string.Empty;
            }
            ins.Nombre_EmpresaComercializacion = txt_EmpresaComercializadora.Text;
            ins.Nombre_Contacto = txtNombreContacto.Text;
            ins.Telefono_Contacto = txtTelefonoContacto.Text;
            ins.Email_Contacto = txtCorreoContacto.Text;
            if (ArchivoPDFContratoComercializadora != null)
            {
                ins.Contrato = ArchivoPDFContratoComercializadora;
                vFecha = dt_FechaContratocomercializadora.DateTime;
                ins.d_Contrato = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            else
            {
                ins.Contrato = Encoding.UTF8.GetBytes("");
                vFecha = DateTime.Now;
                ins.d_Contrato = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            ins.Usuario = UsuariosLogin;
            ins.MtdInsertarComercializadora();
            if (!ins.Exito)
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
            else
            {
                SelectComercializadora();
            }

        }

        private void GuardarProductor()
        {
            CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.Comercializador = txt_Comercializador.Text;
            ins.Productor = txt_Productor.Text;
            ins.KilosAjustados = Convert.ToDecimal(txt_KilosAjustados.EditValue);
            ins.KilosMuestra = Convert.ToDecimal(txt_KilosMuestra.EditValue);
            ins.KilosaDevolver = Convert.ToDecimal(txt_KilosDevolucion.EditValue);
            ins.KilosaPagar = Convert.ToDecimal(txt_kilos_Totales.EditValue);
            ins.PreciokgInicial = Decimal.Parse(txt_KiloPrecioInicial.Text, style, provider);
            ins.Preciokg = Decimal.Parse(txt_KiloPrecio.Text, style, provider);
            ins.TotalaPagar = Decimal.Parse(txt_SubTotalaPagar.Text, style, provider);
            ins.Observaciones = txt_ObservacionesProductor.Text;
            ins.Usuario = UsuariosLogin;
            if (chk_Mercado.Checked == true)
            {
                ins.Exportacion = 1;
            }
            else
            {
                ins.Exportacion = 0;
            }
            ins.MtdInsertarProductor();
            if (!ins.Exito)
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }

        private void GuardarCorte()
        {
            CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            try
            {
                ins.Id_EmpresaCorte = txt_NombreEmpresaCorte.Tag.ToString();
            }
            catch (Exception)
            {
                ins.Id_EmpresaCorte = string.Empty;
            }
            ins.Nombre_EmpresaCorte = txt_NombreEmpresaCorte.Text;
            ins.TipodeCorte = txtTipoCorteEC.Text;
            ins.KilosCortadosC = Convert.ToDecimal(txt_kilosCortadosCorte.EditValue);
            ins.KilosAjustadosC = Convert.ToDecimal(txt_KilosAjustadosCorte.EditValue);
            ins.PrecioporKilo = Decimal.Parse(txt_PrecioKiloCorte.Text, style, provider);
            //if (chk_PrecioPorkg.Checked == true)
            //{
            //    ins.PrecioporKiloB = 1;
            //}
            //else
            //{
            //    ins.PrecioporKiloB = 0;
            //}
            ins.Preciodecosecha = Decimal.Parse(txt_PrecioTCorte.Text, style, provider);
            ins.PrecioporDia = Decimal.Parse(txt_PrecioDiaCorte.Text, style, provider);
            ins.CuadrillaApoyo = Decimal.Parse(txt_PrecioCuadrillaCorte.Text, style, provider);
            if (chk_CuadrillaApoyo.Checked == true)
            {
                ins.CuadrillaApoyoB = 1;
            }
            else
            {
                ins.CuadrillaApoyoB = 0;
            }
            ins.Margen5p = Convert.ToDecimal(txt_Margen.EditValue);
            ins.CajasCortadasC = Convert.ToInt32(txt_CajasCortadasCorte.EditValue);
            ins.TotalaPagarC = Decimal.Parse(txt_PagoTotalCorte.Text, style, provider);
            ins.Observaciones = txt_ObservacionesCorte.Text;
            ins.Usuario = UsuariosLogin;
            ins.MtdInsertarCorte();
            if (!ins.Exito)
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }

        private void GuardarAcarreo()
        {
            CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            try
            {
                ins.Id_EmpresaAcarreo = txt_EmpresaAcarreo.Tag.ToString();
            }
            catch (Exception)
            {
                ins.Id_EmpresaAcarreo = string.Empty;
            }
            ins.Nombre_EmpresaAcarreo = txt_EmpresaAcarreo.Text;
            ins.TipoCamion = txtTipoCamion.Text;
            ins.CajasProgramadas = Convert.ToDecimal(txt_CajasProgramadasA.EditValue);
            ins.CajasCortadasA= Convert.ToDecimal(txt_Cajas_CortadasA.EditValue);
            ins.CostoServicio = Decimal.Parse(txt_CostoServicio.Text, style, provider);
            ins.CostoCajasExtras = Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider);
            ins.CargosExtras = Decimal.Parse(txt_CargosExtra.Text, style, provider);
            ins.Descuentos = Decimal.Parse(txt_Descuentos.Text, style, provider);
            ins.TotalAcarreo = Decimal.Parse(txt_TotalAcarreo.Text, style, provider);
            ins.TotalAjusteProductor = Decimal.Parse(txt_AjusteAcarreoProductor.Text, style, provider);
            ins.Observaciones = txt_ObservacionesAcarreo.Text;
            if (chkCostoAcarreoFruta.Checked == true)
            {
                ins.CostoIncluidoEnFruta = 1;
            }
            else
            {
                ins.CostoIncluidoEnFruta = 0;
            }
            ins.Usuario = UsuariosLogin;
            ins.MtdInsertarAcarreo();
            if (!ins.Exito)
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }

        private void btn_ViewPDFProductor_Click(object sender, EventArgs e)
        {
            Frm_ViewPDF frm = new Frm_ViewPDF();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 1;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
        }

        private void btn_ViewXMLProductor_Click(object sender, EventArgs e)
        {
            Frm_ViewXML frm = new Frm_ViewXML();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 1;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewXML.xml");
        }

        private void btn_ViewPDFCorteKilos_Click(object sender, EventArgs e)
        {
            Frm_ViewPDF frm = new Frm_ViewPDF();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 2;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
        }

        private void btn_ViewPDFCorteDia_Click(object sender, EventArgs e)
        {
            Frm_ViewPDF frm = new Frm_ViewPDF();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 3;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
        }

        private void btn_ViewPDFCorteApoyo_Click(object sender, EventArgs e)
        {
            Frm_ViewPDF frm = new Frm_ViewPDF();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 4;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
        }

        private void btn_ViewPDFCorteSalida_Click(object sender, EventArgs e)
        {
            Frm_ViewPDF frm = new Frm_ViewPDF();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 5;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
        }

        private void btn_ViewPDFAcarreo_Click(object sender, EventArgs e)
        {
            Frm_ViewPDF frm = new Frm_ViewPDF();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 6;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
        }

        private void btn_ViewXMLCorteKilos_Click(object sender, EventArgs e)
        {
            Frm_ViewXML frm = new Frm_ViewXML();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 2;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewXML.xml");
        }

        private void btn_ViewXMLCorteDia_Click(object sender, EventArgs e)
        {
            Frm_ViewXML frm = new Frm_ViewXML();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 3;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewXML.xml");
        }

        private void btn_ViewXMLCorteApoyo_Click(object sender, EventArgs e)
        {
            Frm_ViewXML frm = new Frm_ViewXML();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 4;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewXML.xml");
        }

        private void btn_ViewXMLCorteSalida_Click(object sender, EventArgs e)
        {
            Frm_ViewXML frm = new Frm_ViewXML();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 5;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewXML.xml");
        }

        private void btn_ViewXMLAcarreo_Click(object sender, EventArgs e)
        {
            Frm_ViewXML frm = new Frm_ViewXML();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 6;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewXML.xml");
        }

        void SelectOrdendeCorte()
        {
            CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.MtdSelecccionarOrdencorte();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    txt_ProgramaCorte.Text = ins.Datos.Rows[0]["ProgramaCorte"].ToString();
                    dt_FechaPrograma.DateTime = Convert.ToDateTime(ins.Datos.Rows[0]["ProgramaFecha"].ToString());
                    txt_Temporada.Text = ins.Datos.Rows[0]["Temporada"].ToString();
                    txt_Mercado.Text = ins.Datos.Rows[0]["Mercado"].ToString();
                    txt_Huerta.Tag = ins.Datos.Rows[0]["c_codigo_hue"].ToString();
                    txt_Huerta.Text = ins.Datos.Rows[0]["Huerta"].ToString();
                    txt_SAGARPA.Text = ins.Datos.Rows[0]["SAGARPA"].ToString();
                    txt_Estado_Huerta.Text = ins.Datos.Rows[0]["Estado_Huerta"].ToString();
                    BarHuerta.Caption = "Huerta: " + ins.Datos.Rows[0]["Huerta"].ToString();
                    txt_Acopiador.Text = ins.Datos.Rows[0]["Acopiador"].ToString();
                    barComercializador.Caption = "Comercializador: " + ins.Datos.Rows[0]["Acopiador"].ToString();
                    txt_Cajas_Programa.EditValue = ins.Datos.Rows[0]["ProgramaCajas"].ToString();
                    txt_TipoCorte.Text = ins.Datos.Rows[0]["TipoCorte"].ToString();
                    txtTipoCorteEC.Text = ins.Datos.Rows[0]["TipoCorte"].ToString();
                    if (ins.Datos.Rows[0]["Autorizado_USA"].ToString() == "True")
                    {
                        chk_Autorizado_USA.Checked = true;
                    }
                    else
                    {
                        chk_Autorizado_USA.Checked = false;
                    }
                    txt_Poliza_ase.Text = ins.Datos.Rows[0]["Poliza_aseguradora"].ToString();
                    txt_Nombre_ase.Text = ins.Datos.Rows[0]["Aseguradora"].ToString();
                    Bloquear_OrdenCorte(!Convert.ToBoolean(ins.Datos.Rows[0]["Cerrado"]));
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        void SelectRecepcion()
        {
            CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.MtdSelecccionarRecepcion();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    txt_OrdenCorte.Text = ins.Datos.Rows[0]["OrdendeCorte"].ToString();
                    txt_Secuencia.Text = ins.Datos.Rows[0]["Secuencia"].ToString();
                    txt_Recepcion.Text = ins.Datos.Rows[0]["RecepcionCodigo"].ToString();
                    txt_TicketPesada.Text = ins.Datos.Rows[0]["TicketPesada"].ToString();
                    txt_EstibaSel.Text = ins.Datos.Rows[0]["EstibadeSeleccion"].ToString();
                    txt_CajasCortadas.EditValue = ins.Datos.Rows[0]["CajasCortadas"].ToString();
                    txt_KilosBExterna.EditValue = ins.Datos.Rows[0]["KilosCortados"].ToString();
                    txt_KilosPromedio.EditValue = ins.Datos.Rows[0]["KilosPromedio"].ToString();
                    txt_TipoCultivo.Text = ins.Datos.Rows[0]["TipoCultivo"].ToString();
                    dt_FechaRecepcion.DateTime = Convert.ToDateTime(ins.Datos.Rows[0]["RecepcionFecha"].ToString());
                    txt_EmpresaBascula.Tag = ins.Datos.Rows[0]["Id_EmpresaBascula"].ToString();
                    txt_EmpresaBascula.Text = ins.Datos.Rows[0]["Nombre_EmpresaBascula"].ToString();
                    //txt_KilosBasculaE.EditValue = ins.Datos.Rows[0]["KilosBasculaExterna"].ToString();
                    //txt_KilosDiferencia.EditValue = ins.Datos.Rows[0]["KilosDiferencia"].ToString();
                    //txt_KilosAjuste.EditValue = ins.Datos.Rows[0]["Ajuste"].ToString();
                    //txt_kilosST.EditValue = ins.Datos.Rows[0]["KilosST"].ToString();
                    //txt_KilosProductor.EditValue = ins.Datos.Rows[0]["KilosProductor"].ToString();
                    //if (ins.Datos.Rows[0]["TomarkgProductor"].ToString() == "True")
                    //{
                    //    chk_kgProductor.Checked = true;

                    //}
                    //else
                    //{
                    //    chk_kgProductor.Checked = false;
                    //}
                    //if (ins.Datos.Rows[0]["TomarkgenCorte"].ToString() == "True")
                    //{
                    //    chk_kgCorte.Checked = true;

                    //}
                    //else
                    //{
                    //    chk_kgCorte.Checked = false;
                    //}
                    Bloquear_Recepcion(!Convert.ToBoolean(ins.Datos.Rows[0]["Cerrado"]));
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        void SelectComercializadora()
        {
            CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.MtdSelecccionarComercializadora();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    try
                    {
                        ArchivoPDFGlobalContratoComercializadora = (byte[])ins.Datos.Rows[0]["Contrato"];
                    }
                    catch
                    {
                        ArchivoPDFGlobalContratoComercializadora = null;
                    }
                    try
                    {
                        txt_EmpresaComercializadora.Tag = ins.Datos.Rows[0]["Id_EmpresaComercializacion"].ToString();
                    }
                    catch (Exception)
                    {
                        ins.Id_EmpresaComercializacion = string.Empty;
                    }

                    txt_EmpresaComercializadora.Text = ins.Datos.Rows[0]["Nombre_EmpresaComercializacion"].ToString();
                    txtNombreContacto.Text = ins.Datos.Rows[0]["Nombre_Contacto"].ToString();
                    txtTelefonoContacto.Text = ins.Datos.Rows[0]["Telefono_Contacto"].ToString();
                    txtCorreoContacto.Text = ins.Datos.Rows[0]["Email_Contacto"].ToString();
                    try
                    {
                        if (ArchivoPDFGlobalContratoComercializadora.Length > 0)
                        {
                            btn_ViewPDFComercializadora.Enabled = true;
                            btn_DelContratoComercializadora.Enabled = true;
                            dt_FechaContratocomercializadora.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["d_Contrato"].ToString());
                        }
                        else
                        {
                            btn_ViewPDFComercializadora.Enabled = false;
                            btn_DelContratoComercializadora.Enabled = false;
                            dt_FechaContratocomercializadora.EditValue = DateTime.Now;
                        }
                    }
                    catch
                    {
                        btn_ViewPDFComercializadora.Enabled = false;
                        btn_DelContratoComercializadora.Enabled = false;
                        dt_FechaContratocomercializadora.EditValue = DateTime.Now;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
            Bloquear_Comercializacion(!Convert.ToBoolean(ins.Datos.Rows[0]["Cerrado"]));
        }
        void SelectProductor()
        {
            CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.MtdSelecccionarProductor();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    txt_Comercializador.Text = ins.Datos.Rows[0]["Comercializador"].ToString();
                    txt_Productor.Text = ins.Datos.Rows[0]["Productor"].ToString();
                    BarProductor.Caption = "Productor: " + ins.Datos.Rows[0]["Productor"].ToString();
                    txt_KilosAjustados.EditValue = ins.Datos.Rows[0]["KilosAjustados"].ToString();
                    txt_KilosMuestra.EditValue = ins.Datos.Rows[0]["KilosMuestra"].ToString();
                    txt_kilos_Totales.EditValue = ins.Datos.Rows[0]["KilosaPagar"].ToString();
                    txt_KiloPrecioInicial.EditValue = ins.Datos.Rows[0]["PreciokgInicial"].ToString();
                    txt_KiloPrecio.EditValue = ins.Datos.Rows[0]["Preciokg"].ToString();
                    txt_SubTotalaPagar.EditValue = ins.Datos.Rows[0]["TotalaPagar"].ToString();
                    txt_ObservacionesProductor.Text = ins.Datos.Rows[0]["Observaciones"].ToString();
                    if (ins.Datos.Rows[0]["Exportacion"].ToString() == "True")
                    {
                        chk_Mercado.Checked = true;

                    }
                    else
                    {
                        chk_Mercado.Checked = false;
                    }
                    Bloquear_Productor(!Convert.ToBoolean(ins.Datos.Rows[0]["Cerrado"]));
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }

        }
        void SelectCorte()
        {
            CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.MtdSelecccionarCorte();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {

                    txt_NombreEmpresaCorte.Tag = ins.Datos.Rows[0]["Id_EmpresaCorte"].ToString();
                    txt_NombreEmpresaCorte.Text = ins.Datos.Rows[0]["Nombre_EmpresaCorte"].ToString();
                    CargarServicios();
                    txtTipoCorteEC.Text = ins.Datos.Rows[0]["TipodeCorte"].ToString();
                    txt_kilosCortadosCorte.EditValue = ins.Datos.Rows[0]["KilosCortados"].ToString();
                    txt_KilosAjustadosCorte.EditValue = ins.Datos.Rows[0]["KilosAjustados"].ToString();
                    txt_PrecioKiloCorte.EditValue = ins.Datos.Rows[0]["PrecioporKilo"].ToString();
                    //if (ins.Datos.Rows[0]["PrecioporKiloB"].ToString() == "True")
                    //{
                    //    chk_PrecioPorkg.Checked = true;
                    //}
                    //else
                    //{
                    //    chk_PrecioPorkg.Checked = false;
                    //}
                    txt_PrecioTCorte.EditValue = ins.Datos.Rows[0]["Preciodecosecha"].ToString();
                    txt_PrecioDiaCorte.EditValue = ins.Datos.Rows[0]["PrecioporDia"].ToString();
                    txt_PrecioCuadrillaCorte.EditValue = ins.Datos.Rows[0]["CuadrillaApoyo"].ToString();
                    if (ins.Datos.Rows[0]["CuadrillaApoyoB"].ToString() == "True")
                    {
                        chk_CuadrillaApoyo.Checked = true;

                    }
                    else
                    {
                        chk_CuadrillaApoyo.Checked = false;
                    }
                    txt_Margen.EditValue = ins.Datos.Rows[0]["Margen5p"].ToString();
                    txt_CajasCortadasCorte.EditValue = ins.Datos.Rows[0]["CajasCortadas"].ToString();
                    txt_PagoTotalCorte.EditValue = ins.Datos.Rows[0]["TotalaPagar"].ToString();
                    txt_ObservacionesCorte.Text = ins.Datos.Rows[0]["Observaciones"].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        void SelectAcarreo()
        {
            CLS_Cosecha_Datos ins = new CLS_Cosecha_Datos();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.MtdSelecccionarAcarreo();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    CargarCostosServicios();
                    txt_EmpresaAcarreo.Tag = ins.Datos.Rows[0]["Id_EmpresaAcarreo"].ToString();
                    txt_EmpresaAcarreo.Text = ins.Datos.Rows[0]["Nombre_EmpresaAcarreo"].ToString();
                    txt_CajasProgramadasA.EditValue = ins.Datos.Rows[0]["CajasProgramadas"].ToString();
                    txt_Cajas_CortadasA.EditValue = ins.Datos.Rows[0]["CajasCortadas"].ToString();
                    txtTipoCamion.Text= ins.Datos.Rows[0]["TipoCamion"].ToString();
                    txt_CostoServicio.EditValue = ins.Datos.Rows[0]["CostoServicio"].ToString();
                    txt_CostoxCajaExtra.EditValue = ins.Datos.Rows[0]["CostoCajasExtras"].ToString();
                    txt_CargosExtra.EditValue = ins.Datos.Rows[0]["CargosExtras"].ToString();
                    txt_Descuentos.EditValue = ins.Datos.Rows[0]["Descuentos"].ToString();
                    txt_TotalAcarreo.EditValue = ins.Datos.Rows[0]["TotalAcarreo"].ToString();
                    txt_ObservacionesAcarreo.Text = ins.Datos.Rows[0]["Observaciones"].ToString();
                    if (ins.Datos.Rows[0]["CostoIncluidoEnFruta"].ToString()=="True")
                    {
                        chkCostoAcarreoFruta.Checked = true;
                    }
                    else
                    {
                        chkCostoAcarreoFruta.Checked = false;
                    }

                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }

        }





        private void dtgCosecha_Click(object sender, EventArgs e)
        {
            btn_limpiarOrden.PerformClick();
            try
            {
                foreach (int i in this.dtgValCosecha.GetSelectedRows())
                {
                    vCarga = 1;
                    DataRow row = this.dtgValCosecha.GetDataRow(i);
                    txt_IdCosecha.Text = row["Id_Cosecha"].ToString();
                    BarEstiba.Caption = "Estiba: " + row["EstibadeSeleccion"].ToString();
                    CargarCosecha();
                    vCarga = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void CargarCosecha()
        {
            SelectOrdendeCorte();
            SelectRecepcion();
            SelectComercializadora();
            SelectProductor();

            SelectCorte();
            CorridaBanda();
            SelectAcarreo();
        }



        private void txt_CargosExtra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider) - Decimal.Parse(txt_Descuentos.Text, style, provider)).ToString();
            }
        }


        private void txt_NoCuadrillas_EditValueChanged(object sender, EventArgs e)
        {
            CalcularCuadrillasdeApoyo();
        }


        private void btn_RefrescarPeso_Click(object sender, EventArgs e)
        {
            CalcularTotalRecepcion();
            if (!string.IsNullOrEmpty(txt_NombreEmpresaCorte.Text) && txt_EmpresaAcarreo.Tag != string.Empty)
            {
                CargarServicios();
                CalcularCostosCorte();
            }
        }



        private void txt_Descuentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider) - Decimal.Parse(txt_Descuentos.Text, style, provider)).ToString();
            }
        }

        private void chk_PrecioPorkg_CheckedChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txt_NombreEmpresaCorte.Text) && txt_EmpresaAcarreo.Tag != string.Empty)
            {
                CargarServicios();
                CalcularCostosCorte();
            }
        }

        private void Bloquear_OrdenCorte(Boolean valor)
        {
            btnBusqProgramaCorte.Enabled = valor;
        }
        private void Bloquear_Recepcion(Boolean valor)
        {
            btn_EmpresaBascula.Enabled = valor;
        }
        private void Bloquear_Comercializacion(Boolean valor)
        {
            btn_EmpresaComercializacion.Enabled = valor;
            if (!valor)
            {
                btn_UpPDFComercializadora.Enabled = valor;
                btn_ViewPDFComercializadora.Enabled = valor;
                btn_DelContratoComercializadora.Enabled = !valor;
            }
        }
        private void Bloquear_Productor(Boolean valor)
        {
            txt_KiloPrecioInicial.Enabled = valor;
            txt_KiloPrecio.Enabled = valor;
            chk_Mercado.Enabled = valor;
            txt_ObservacionesProductor.Enabled = valor;
        }

        private void txt_CostoServicio_EditValueChanged(object sender, EventArgs e)
        {
            txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider) - Decimal.Parse(txt_Descuentos.Text, style, provider)).ToString();
        }

        private void txt_CargosExtra_EditValueChanged(object sender, EventArgs e)
        {
            txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider) - Decimal.Parse(txt_Descuentos.Text, style, provider)).ToString();
        }

        private void txt_CostoxCajaExtra_EditValueChanged(object sender, EventArgs e)
        {
            txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider) - Decimal.Parse(txt_Descuentos.Text, style, provider)).ToString();
        }

        private void txt_Descuentos_EditValueChanged(object sender, EventArgs e)
        {
            txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider) - Decimal.Parse(txt_Descuentos.Text, style, provider)).ToString();
        }

        private void chkCostoAcarreoFruta_CheckedChanged(object sender, EventArgs e)
        {
            if(chkCostoAcarreoFruta.Checked) 
            {
                LimpiarAcarreo();
                txt_EmpresaAcarreo.Tag = "00000000";
                txt_EmpresaAcarreo.Text = "SIN EMPRESA DE ACARREO";
                txt_CargosExtra.Enabled = false;
                txt_CostoxCajaExtra.Enabled = false;
                txt_Descuentos.Enabled = false;
            }
            else
            {
                txt_CargosExtra.Enabled = false;
                txt_CostoxCajaExtra.Enabled = false;
                txt_Descuentos.Enabled = false;
            }
        }

        private void chkCostoCorteFruta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCostoAcarreoFruta.Checked)
            {
                LimpiarCorte();
                txt_NombreEmpresaCorte.Tag = "00000000";
                txt_NombreEmpresaCorte.Text = "SIN EMPRESA DE CORTE";
                
            }
            else
            {
                
            }
        }

        private void btn_RecalcularAcarreo_Click(object sender, EventArgs e)
        {
            if (txt_EmpresaAcarreo.Text != string.Empty)
            {
                CalcularAcarreo();
            }
        }

        private void rb_Bascula_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_EmpresaAcarreo.Text != string.Empty)
            {
                CalcularAcarreo();
            }
        }
    }
}