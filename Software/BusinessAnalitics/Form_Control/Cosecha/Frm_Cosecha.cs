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
using System.IO;
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
        Byte[] ArchivoPDFGlobalProductorREP= null;
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

            dtgValFacturasREP.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValFacturasREP.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValFacturasREP.OptionsSelection.MultiSelect = true;
            dtgValFacturasREP.OptionsView.ShowGroupPanel = false;
            dtgValFacturasREP.OptionsBehavior.AutoPopulateColumns = true;
            dtgValFacturasREP.OptionsView.ColumnAutoWidth = true;
            dtgValFacturasREP.BestFitColumns();

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
            gridColumn48.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn48.DisplayFormat.FormatString = "c2";


            txt_KiloPrecio.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_KiloPrecioInicial.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_PagoTotalCorte.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_PrecioCuadrillaCorte.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_PrecioDiaCorte.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_PrecioKiloCorte.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_PrecioSalidaFCorte.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_PrecioTCorte.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_TotalaPagar.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioCajaMayorA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioCajaMenorA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioCuadrillaA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioDia.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPreciokg.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioMayorA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioMenorA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioSalidaFalso.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioCaja.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioServicio.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtPrecioSalidaForanea.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_CajasProgramadasA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_Cajas_CortadasA.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_CostoServicio.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_CajasExtras.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_CostoxCajaExtra.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_TotalAcarreo.Properties.Mask.UseMaskAsDisplayFormat = true;
            btn_limpiarOrden.PerformClick();
            CargarTemporadaActiva();
            CargarTemporada(TemActiva);
            CargarCosechas();
            CargarAccesos();

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
                    txt_SAGARPA.Text= sel.Datos.Rows[0]["v_registro_hue"].ToString();
                    txt_Estado_Huerta.Text= sel.Datos.Rows[0]["v_nombre_est"].ToString();
                    txt_Acopiador.Text = sel.Datos.Rows[0]["v_nombre_zon"].ToString();
                    txt_Acopiador.Tag = sel.Datos.Rows[0]["c_codigo_zon"].ToString();
                    txt_Cajas_Programa.Text = sel.Datos.Rows[0]["n_cajas_pcd"].ToString();
                    txt_CajasProgramadasA.Text = sel.Datos.Rows[0]["n_cajas_pcd"].ToString();
                    txt_TipoCorte.Text = sel.Datos.Rows[0]["v_tipocorte_pcd"].ToString();
                    txtTipoCorteEC.Text = sel.Datos.Rows[0]["v_tipocorte_pcd"].ToString();
                    txt_OrdenCorte.Text = sel.Datos.Rows[0]["c_codigo_oct"].ToString();
                    txt_Secuencia.Text = sel.Datos.Rows[0]["c_secuencia_ocd"].ToString();
                    txt_Temporada.Text = sel.Datos.Rows[0]["c_codigo_tem"].ToString();
                    txt_Productor.Text = sel.Datos.Rows[0]["v_nombre_dno"].ToString();
                    if(sel.Datos.Rows[0]["b_autorizausa_ase"].ToString()=="True")
                    {
                        chk_Autorizado_USA.Checked = true;
                    }
                    else
                    {
                        chk_Autorizado_USA.Checked = false;
                    }
                    txt_Poliza_ase.Text= sel.Datos.Rows[0]["c_poliza_ase"].ToString();
                    txt_Nombre_ase.Text= sel.Datos.Rows[0]["v_nombre_ase"].ToString();
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

        void CalcularFechaPrograma(DateTime Fecha)
        {
            //XtraMessageBox.Show(Fecha.ToString("dddd", new CultureInfo("es-MX")));
            switch ((byte)Fecha.DayOfWeek)
            {
                case 0:
                    dt_FechaProgramaProductor.DateTime = Fecha.AddDays(19);
                    break;
                case 1:
                    dt_FechaProgramaProductor.DateTime = Fecha.AddDays(25);
                    break;
                case 2:
                    dt_FechaProgramaProductor.DateTime = Fecha.AddDays(24);
                    break;
                case 3:
                    dt_FechaProgramaProductor.DateTime = Fecha.AddDays(23);
                    break;
                case 4:
                    dt_FechaProgramaProductor.DateTime = Fecha.AddDays(22);
                    break;
                case 5:
                    dt_FechaProgramaProductor.DateTime = Fecha.AddDays(21);
                    break;
                case 6:
                    dt_FechaProgramaProductor.DateTime = Fecha.AddDays(20);
                    break;
                default:
                    break;

            }
        }
        void CalcularFechaPrograma8(DateTime Fecha, int Id_Factura)
        {
            if (Id_Factura == 1)
            {
                switch ((byte)Fecha.DayOfWeek)
                {
                    case 0:
                        dt_FechaProgramaCorteKilos.DateTime = Fecha.AddDays(5);
                        break;
                    case 1:
                        dt_FechaProgramaCorteKilos.DateTime = Fecha.AddDays(11);
                        break;
                    case 2:
                        dt_FechaProgramaCorteKilos.DateTime = Fecha.AddDays(10);
                        break;
                    case 3:
                        dt_FechaProgramaCorteKilos.DateTime = Fecha.AddDays(9);
                        break;
                    case 4:
                        dt_FechaProgramaCorteKilos.DateTime = Fecha.AddDays(8);
                        break;
                    case 5:
                        dt_FechaProgramaCorteKilos.DateTime = Fecha.AddDays(7);
                        break;
                    case 6:
                        dt_FechaProgramaCorteKilos.DateTime = Fecha.AddDays(6);
                        break;
                    default:
                        break;
                }
            }
            else if (Id_Factura == 2)
            {
                switch ((byte)Fecha.DayOfWeek)
                {
                    case 0:
                        dt_FechaProgramaCorteDia.DateTime = Fecha.AddDays(5);
                        break;
                    case 1:
                        dt_FechaProgramaCorteDia.DateTime = Fecha.AddDays(11);
                        break;
                    case 2:
                        dt_FechaProgramaCorteDia.DateTime = Fecha.AddDays(10);
                        break;
                    case 3:
                        dt_FechaProgramaCorteDia.DateTime = Fecha.AddDays(9);
                        break;
                    case 4:
                        dt_FechaProgramaCorteDia.DateTime = Fecha.AddDays(8);
                        break;
                    case 5:
                        dt_FechaProgramaCorteDia.DateTime = Fecha.AddDays(7);
                        break;
                    case 6:
                        dt_FechaProgramaCorteDia.DateTime = Fecha.AddDays(6);
                        break;
                    default:
                        break;
                }
            }
            else if (Id_Factura == 3)
            {
                switch ((byte)Fecha.DayOfWeek)
                {
                    case 0:
                        dt_FechaProgramaCorteApoyo.DateTime = Fecha.AddDays(5);
                        break;
                    case 1:
                        dt_FechaProgramaCorteApoyo.DateTime = Fecha.AddDays(11);
                        break;
                    case 2:
                        dt_FechaProgramaCorteApoyo.DateTime = Fecha.AddDays(10);
                        break;
                    case 3:
                        dt_FechaProgramaCorteApoyo.DateTime = Fecha.AddDays(9);
                        break;
                    case 4:
                        dt_FechaProgramaCorteApoyo.DateTime = Fecha.AddDays(8);
                        break;
                    case 5:
                        dt_FechaProgramaCorteApoyo.DateTime = Fecha.AddDays(7);
                        break;
                    case 6:
                        dt_FechaProgramaCorteApoyo.DateTime = Fecha.AddDays(6);
                        break;
                    default:
                        break;
                }
            }
            else if (Id_Factura == 4)
            {
                switch ((byte)Fecha.DayOfWeek)
                {
                    case 0:
                        dt_FechaProgramaCorteSalida.DateTime = Fecha.AddDays(5);
                        break;
                    case 1:
                        dt_FechaProgramaCorteSalida.DateTime = Fecha.AddDays(11);
                        break;
                    case 2:
                        dt_FechaProgramaCorteSalida.DateTime = Fecha.AddDays(10);
                        break;
                    case 3:
                        dt_FechaProgramaCorteSalida.DateTime = Fecha.AddDays(9);
                        break;
                    case 4:
                        dt_FechaProgramaCorteSalida.DateTime = Fecha.AddDays(8);
                        break;
                    case 5:
                        dt_FechaProgramaCorteSalida.DateTime = Fecha.AddDays(7);
                        break;
                    case 6:
                        dt_FechaProgramaCorteSalida.DateTime = Fecha.AddDays(6);
                        break;
                    default:
                        break;
                }
            }
            else if (Id_Factura == 5)
            {
                switch ((byte)Fecha.DayOfWeek)
                {
                    case 0:
                        dt_FechaProgramaAcarreo.DateTime = Fecha.AddDays(5);
                        break;
                    case 1:
                        dt_FechaProgramaAcarreo.DateTime = Fecha.AddDays(11);
                        break;
                    case 2:
                        dt_FechaProgramaAcarreo.DateTime = Fecha.AddDays(10);
                        break;
                    case 3:
                        dt_FechaProgramaAcarreo.DateTime = Fecha.AddDays(9);
                        break;
                    case 4:
                        dt_FechaProgramaAcarreo.DateTime = Fecha.AddDays(8);
                        break;
                    case 5:
                        dt_FechaProgramaAcarreo.DateTime = Fecha.AddDays(7);
                        break;
                    case 6:
                        dt_FechaProgramaAcarreo.DateTime = Fecha.AddDays(6);
                        break;
                    default:
                        break;
                }
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
                    CalcularFechaPrograma(dt_FechaRecepcion.DateTime);
                    txt_Recepcion.Text = sel.Datos.Rows[0]["c_codigo_rec"].ToString();
                    txt_EstibaSel.Text = sel.Datos.Rows[0]["c_codigo_sel"].ToString();
                    BarEstiba.Caption = "Estiba: " + sel.Datos.Rows[0]["c_codigo_sel"].ToString();
                    txt_CajasCortadas.Text = sel.Datos.Rows[0]["n_cajascorte_red"].ToString();
                    txt_Cajas_CortadasA.Text = sel.Datos.Rows[0]["n_cajascorte_red"].ToString();
                    txt_CajasCortadasCorte.Text = sel.Datos.Rows[0]["n_cajascorte_red"].ToString();
                    txt_KilosCortados.Text = sel.Datos.Rows[0]["n_kilos_red"].ToString();
                    txt_KilosPromedio.Text = sel.Datos.Rows[0]["n_promxcaja_red"].ToString();
                    txt_TipoCultivo.Text = sel.Datos.Rows[0]["v_nombre_cul"].ToString();
                    txt_TipoCultivo.Tag = sel.Datos.Rows[0]["c_codigo_cul"].ToString();
                    txt_TicketPesada.Text = sel.Datos.Rows[0]["c_ticketbas_rec"].ToString();
                    if (txt_EstibaSel.Text != string.Empty && txt_Temporada.Text != string.Empty)
                    {
                        if (txt_KilosCortados.Text != String.Empty && Decimal.Parse(txt_KilosCortados.Text, style, provider) > 0)
                        {
                            CorridaBanda();
                            txt_KilosBasculaE.Enabled = true;
                            chk_kgProductor.Enabled = true;
                        }
                        else
                        {
                            txt_KilosBasculaE.Enabled = false;
                            chk_kgProductor.Enabled = false;
                        }
                    }
                }
                else
                {
                    if (Decimal.Parse(txt_KilosCortados.Text, style, provider) > 0)
                    {
                        txt_KilosBasculaE.Enabled = true;
                        chk_kgProductor.Enabled = true;
                    }
                    else
                    {
                        txt_KilosBasculaE.Enabled = false;
                        chk_kgProductor.Enabled = false;
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
            int KC = Convert.ToInt32(Decimal.Parse(txt_KilosCortados.Text, style, provider));
            int KP = Convert.ToInt32(Decimal.Parse(txt_KilosBasculaE.Text, style, provider));
            if (KC > 0 && KP > 0)
            {
                int Res = KC - KP;

                if (Math.Abs(Res) > 49 && Math.Abs(Res) < 100)
                {
                    int Div = Res / 2;
                    txt_KilosDiferencia.Text = Res.ToString();
                    txt_KilosAjuste.Text = Convert.ToString(Div);
                    if (Res > 0)
                    {
                        txt_KilosProductor.Text = Convert.ToString(KP);
                        txt_kilosST.Text = Convert.ToString(KC - Math.Abs(Div));
                    }
                    else
                    {
                        txt_KilosProductor.Text = Convert.ToString(KP);
                        txt_kilosST.Text = Convert.ToString(KC + Math.Abs(Div));
                    }
                    txt_KilosAjustados.Text = txt_kilosST.Text;

                }
                else if (Math.Abs(Res) >= 100)
                {
                    txt_KilosDiferencia.Text = Res.ToString();
                    int ajuste = 0;
                    if (Res > 0)
                    {
                        ajuste = Res - 49;
                        txt_KilosAjuste.Text = Convert.ToString(ajuste);
                        txt_KilosProductor.Text = Convert.ToString(KP);
                        txt_kilosST.Text = Convert.ToString(KC - Math.Abs(ajuste)); ;
                    }
                    else
                    {
                        ajuste = Res + 49;
                        txt_KilosAjuste.Text = Convert.ToString(ajuste);
                        txt_KilosProductor.Text = Convert.ToString(KP);
                        txt_kilosST.Text = Convert.ToString(KC + Math.Abs(ajuste));
                    }
                    txt_KilosAjustados.Text = txt_kilosST.Text;
                }
                else
                {
                    txt_KilosAjuste.Text = "0";
                    txt_KilosDiferencia.Text = Res.ToString();
                    txt_kilosST.Text = Convert.ToString(KC);
                    txt_KilosProductor.Text = Convert.ToString(KP);
                    txt_KilosAjustados.Text = txt_kilosST.Text;
                }
                if (chk_kgCorte.Checked == false)
                {
                    txt_kilosCortadosCorte.Text = Convert.ToString(KC);
                }
                else
                {
                    txt_kilosCortadosCorte.Text = txt_KilosBasculaE.Text;
                }
                txt_kilos_Totales.Text = Convert.ToString(Convert.ToInt32(Decimal.Parse(txt_KilosAjustados.Text, style, provider)) - Convert.ToInt32(Decimal.Parse(txt_KilosMuestra.Text, style, provider)));
            }
            else
            {
                XtraMessageBox.Show("No se han capturado kilos en recepcion o kilos en bascula productor");
            }
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
                CalcularCostosCorte();
            }
        }

        private void CalcularCostosCorte()
        {
            if (txt_kilosCortadosCorte.Text != string.Empty && Decimal.Parse(txt_kilosCortadosCorte.Text, style, provider) > 0)
            {
                //chk_SalidaFalso.Enabled = false;
                txt_Margen5.Text = Convert.ToString(Convert.ToDouble(txt_kilosCortadosCorte.Text) * 0.05);
                txt_kgNoSolicitados.Text = CalcularkilosNoDeseados();
                txt_KilosARestar.Text = (Decimal.Parse(txt_Margen5.Text, style, provider) - Decimal.Parse(txt_kgNoSolicitados.Text, style, provider)).ToString();
                if (Decimal.Parse(txt_KilosARestar.Text, style, provider) < 0)
                {
                    txt_KilosAjustadosCorte.Text = (Decimal.Parse(txt_kilosCortadosCorte.Text, style, provider) - (Decimal.Parse(txt_KilosARestar.Text, style, provider) * (-1))).ToString();
                }
                else
                {
                    txt_KilosAjustadosCorte.Text = txt_kilosCortadosCorte.Text;
                }
                if (Decimal.Parse(txt_kilosCortadosCorte.Text, style, provider) > Decimal.Parse(txtMenorakg.Text, style, provider) || chk_PrecioPorkg.Checked == true)
                {
                    txt_PrecioKiloCorte.Text = txtPreciokg.Text;
                    if (chk_RangoCajas.Checked == false)
                    {
                        txt_PrecioTCorte.Text = (Decimal.Parse(txt_KilosAjustadosCorte.Text, style, provider) * Decimal.Parse(txt_PrecioKiloCorte.Text, style, provider)).ToString();
                    }
                    else
                    {
                        if (Decimal.Parse(txt_CajasCortadasCorte.Text, style, provider) < Decimal.Parse(txtCajasMenorA.Text, style, provider))
                        {
                            txt_PrecioKiloCorte.Text = txtPrecioCajaMenorA.Text;
                        }
                        else
                        {
                            txt_PrecioKiloCorte.Text = txtPrecioCajaMayorA.Text;
                        }
                        txt_PrecioTCorte.Text = (Decimal.Parse(txt_KilosAjustadosCorte.Text, style, provider) * Decimal.Parse(txt_PrecioKiloCorte.Text, style, provider)).ToString();
                    }
                    txt_PrecioDiaCorte.Text = "0";
                    txt_PagoTotalCorte.Text = txt_PrecioTCorte.Text;
                }
                else
                {
                    txt_PrecioKiloCorte.Text = txtPreciokg.Text;
                    if (Decimal.Parse(txt_KilosARestar.Text, style, provider) < 0)
                    {
                        txt_PrecioTCorte.Text = Convert.ToString(Decimal.Parse(txt_PrecioKiloCorte.Text, style, provider) * Decimal.Parse(txt_KilosARestar.Text, style, provider));
                    }
                    else
                    {
                        txt_PrecioTCorte.Text = "0";
                    }
                    txt_PrecioDiaCorte.Text = txtPrecioDia.Text;
                }
                txt_PrecioSalidaFCorte.Text = "0";
                txt_PrecioCuadrillaCorte.Text = "0";
                //chk_SalidaFalso.Checked = false;
                chk_CuadrillaApoyo.Enabled = true;
                txt_NoCuadrillas.Enabled = true;
                chk_CuadrillaApoyo.Checked = false;
                txt_PagoTotalCorte.Text = (Decimal.Parse(txt_PrecioTCorte.Text, style, provider) + Decimal.Parse(txt_PrecioCuadrillaCorte.Text, style, provider) + Decimal.Parse(txt_PrecioSalidaFCorte.Text, style, provider) + Decimal.Parse(txt_PrecioDiaCorte.Text, style, provider)).ToString();
            }
            else
            {
                chk_SalidaFalso.Enabled = true;
                chk_CuadrillaApoyo.Enabled = false;
                txt_NoCuadrillas.Enabled = false;
            }
        }
        private void CalcularCostosAcarreo()
        {
            if (txt_kilosCortadosCorte.Text != string.Empty)
            {
                chk_ServicioForaneo.Checked = false;
                txt_CostoServicio.Text = txtPrecioServicio.Text;
                txt_CajasExtras.Text = "0";
                txt_CostoxCajaExtra.Text = "0";
                //txt_TotalAcarreo.EditValue = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider)).ToString();
                if (!string.IsNullOrEmpty(txt_CajasExtras.Text))
                {
                    txt_CostoxCajaExtra.Text = (Decimal.Parse(txt_CajasExtras.Text, style, provider) * Decimal.Parse(txtPrecioCaja.Text, style, provider)).ToString();
                    txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider) - Decimal.Parse(txt_Descuentos.Text, style, provider)).ToString();
                }
                txt_ImporteFacturaAcarreo.EditValue = txt_TotalAcarreo.EditValue;
                CalcularTotalFacturaAcarreo();
            }
            else
            {
                chk_SalidaFalso.Enabled = true;
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
            if (chk_Mercado.Checked == true && txt_KilosAjustados.Text != string.Empty)
            {
                txt_KilosMuestra.Text = "17";
                txt_kilos_Totales.Text = Convert.ToString(Convert.ToInt32(Decimal.Parse(txt_KilosAjustados.Text, style, provider)) - Convert.ToInt32(Decimal.Parse(txt_KilosMuestra.Text, style, provider)));
            }
            else
            {
                txt_KilosMuestra.Text = "0";
                txt_kilos_Totales.Text = Convert.ToString(Convert.ToInt32(Decimal.Parse(txt_KilosAjustados.Text, style, provider)) - Convert.ToInt32(Decimal.Parse(txt_KilosMuestra.Text, style, provider)));
            }
            CalcularTotalaPagarProductor();
        }

        private void chk_SalidaFalso_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_SalidaFalso.Checked == true)
            {
                txt_PrecioSalidaFCorte.Text = txtPrecioSalidaFalso.Text;
                txt_PrecioTCorte.Text = "0";
            }
            else
            {
                txt_PrecioSalidaFCorte.Text = "0";
            }
            txt_PagoTotalCorte.Text = (Decimal.Parse(txt_PrecioTCorte.Text, style, provider) + Decimal.Parse(txt_PrecioCuadrillaCorte.Text, style, provider) + Decimal.Parse(txt_PrecioSalidaFCorte.Text, style, provider)).ToString();
        }

        private void chk_CuadrillaApoyo_CheckedChanged(object sender, EventArgs e)
        {
            CalcularCuadrillasdeApoyo();
        }

        private void CalcularCuadrillasdeApoyo()
        {
            if (chk_CuadrillaApoyo.Checked == true)
            {
                if (chk_Rango.Checked == false)
                {
                    txt_PrecioCuadrillaCorte.Text = Convert.ToString(Decimal.Parse(txtPrecioCuadrillaA.Text, style, provider) * Decimal.Parse(txt_NoCuadrillas.Text, style, provider));
                }
                else
                {
                    if (Decimal.Parse(txt_KilosAjustadosCorte.Text, style, provider) < Decimal.Parse(txtKilosMenorA.Text, style, provider))
                    {
                        txt_PrecioCuadrillaCorte.Text = (Decimal.Parse(txtPrecioMenorA.Text, style, provider) * Decimal.Parse(txt_NoCuadrillas.Text, style, provider)).ToString();
                    }
                    else
                    {
                        txt_PrecioCuadrillaCorte.Text = (Decimal.Parse(txtPrecioMayorA.Text, style, provider) * Decimal.Parse(txt_NoCuadrillas.Text, style, provider)).ToString();
                    }
                    txt_PrecioTCorte.Text = (Decimal.Parse(txt_KilosAjustadosCorte.Text, style, provider) * Decimal.Parse(txt_PrecioKiloCorte.Text, style, provider)).ToString();
                }
            }
            else
            {
                txt_PrecioCuadrillaCorte.Text = "0";
            }
            txt_PagoTotalCorte.Text = (Decimal.Parse(txt_PrecioTCorte.Text, style, provider) + Decimal.Parse(txt_PrecioCuadrillaCorte.Text, style, provider) + Decimal.Parse(txt_PrecioSalidaFCorte.Text, style, provider)).ToString();
        }

        private void txt_KilosARestar_EditValueChanged(object sender, EventArgs e)
        {
            if (Decimal.Parse(txt_KilosARestar.Text, style, provider) > 0)
            {
                txt_KilosARestar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txt_KilosARestar.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                txt_KilosARestar.Properties.Appearance.Options.UseFont = true;
                txt_KilosARestar.Properties.Appearance.Options.UseForeColor = true;
            }
            else
            {
                txt_KilosARestar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txt_KilosARestar.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
                txt_KilosARestar.Properties.Appearance.Options.UseFont = true;
                txt_KilosARestar.Properties.Appearance.Options.UseForeColor = true;
            }
        }

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
                txt_TotalaPagar.EditValue = (Decimal.Parse(txt_KiloPrecio.Text, style, provider) * Decimal.Parse(txt_kilos_Totales.Text, style, provider)).ToString();
                txt_ImporteFacturaProductor.EditValue = txt_TotalaPagar.EditValue;
                CalcularTotalFacturaProductor();
            }
        }

        private void CargarServiciosAcarreo()
        {
            CLS_EmpresasAcarreo sel = new CLS_EmpresasAcarreo();
            sel.Id_EmpresaAcarreo = txt_EmpresaAcarreo.Tag.ToString();
            sel.Id_TipoCamion = txt_TipoCamion.Tag.ToString();
            sel.MtdSeleccionarEmpresasCostoServicios();
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
        private void CargarCostosServicios()
        {
            CLS_EmpresasAcarreo sel = new CLS_EmpresasAcarreo();
            sel.Id_EmpresaAcarreo = txt_EmpresaAcarreo.Tag.ToString().Trim();
            sel.MtdSeleccionarEmpresasServicios();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgServicios.DataSource = sel.Datos;
                }
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
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
                CargarCamiones(null);
                CargarChoferes(null);
                CargarCostosServicios();
            }
        }
        private void CargarCamiones(string Valor)
        {
            CLS_Camiones camiones = new CLS_Camiones();
            camiones.Id_EmpresaAcarreo = txt_EmpresaAcarreo.Tag.ToString();
            camiones.MtdSeleccionarCamion();
            if (camiones.Exito)
            {
                if (camiones.Datos.Rows.Count > 0)
                {
                    cmb_Camiones.Properties.DisplayMember = "Nombre_Camion";
                    cmb_Camiones.Properties.ValueMember = "Id_Camion";
                    cmb_Camiones.EditValue = Valor;
                    cmb_Camiones.Properties.DataSource = camiones.Datos;
                }
            }
        }
        private void CargarChoferes(string Valor)
        {
            CLS_Choferes Choferes = new CLS_Choferes();
            Choferes.Id_EmpresaAcarreo = txt_EmpresaAcarreo.Tag.ToString();
            Choferes.MtdSeleccionarChoferes();
            if (Choferes.Exito)
            {
                if (Choferes.Datos.Rows.Count > 0)
                {
                    cmb_Choferes.Properties.DisplayMember = "Nombre_Chofer";
                    cmb_Choferes.Properties.ValueMember = "Id_Chofer";
                    cmb_Choferes.EditValue = Valor;
                    cmb_Choferes.Properties.DataSource = Choferes.Datos;
                }
            }
        }
        private void chk_ServicioForaneo_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_CostoServicio.Text) && !string.IsNullOrEmpty(txt_CostoxCajaExtra.Text))
            {
                if (chk_ServicioForaneo.Checked == true)
                {
                    txt_CostoServicio.Text = txtPrecioSalidaForanea.Text;
                }
                else
                {
                    txt_CostoServicio.Text = txtPrecioServicio.Text;
                }
                txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider) - Decimal.Parse(txt_Descuentos.Text, style, provider)).ToString();
            }
        }

        private void txt_CajasExtras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txt_CajasExtras.Text))
                {
                    txt_CostoxCajaExtra.Text = (Decimal.Parse(txt_CajasExtras.Text, style, provider) * Decimal.Parse(txtPrecioCaja.Text, style, provider)).ToString();
                    txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider) - Decimal.Parse(txt_Descuentos.Text, style, provider)).ToString();
                }
            }
        }

        void ConsultarCostos(string str)
        {
            throw new NotImplementedException();
        }
        private void cmb_Camiones_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_EmpresaAcarreo.Tag.ToString()) && !string.IsNullOrEmpty(cmb_Camiones.EditValue.ToString()))
                {
                    CLS_Camiones sel = new CLS_Camiones();
                    sel.Id_Camion = cmb_Camiones.EditValue.ToString();
                    sel.Id_EmpresaAcarreo = txt_EmpresaAcarreo.Tag.ToString();
                    sel.MtdSeleccionarCamionPlaca();
                    if (sel.Exito)
                    {
                        if (sel.Datos.Rows.Count > 0)
                        {
                            txtPlacasCamion.Text = sel.Datos.Rows[0]["Placas"].ToString();
                            txt_TipoCamion.Text= sel.Datos.Rows[0]["Nombre_TipoCamion"].ToString();
                            txt_TipoCamion.Tag = sel.Datos.Rows[0]["Id_TipoCamion"].ToString();
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

        private void chk_kgProductor_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_kgProductor.Checked == true)
            {
                txt_kilosST.Text = txt_KilosBasculaE.Text;
                txt_KilosAjustados.Text = txt_kilosST.Text;
                txt_kilos_Totales.Text = Convert.ToString(Convert.ToInt32(Decimal.Parse(txt_KilosAjustados.Text, style, provider)) - Convert.ToInt32(Decimal.Parse(txt_KilosMuestra.Text, style, provider)));
            }
            else
            {
                CalcularTotalRecepcion();
            }
            if (chk_kgCorte.Checked == true)
            {
                if (Convert.ToDecimal(txt_KilosBasculaE.Text) > 0)
                {
                    txt_kilosCortadosCorte.Text = txt_KilosBasculaE.Text;
                }
            }
            else
            {
                txt_kilosCortadosCorte.Text = txt_KilosCortados.Text;
            }
            CalcularkilosTipoMercado();
            CalcularCostosCorte();

        }
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
        private void btn_UpPDFProductor_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                txt_RutaPDFProductor.Text = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }
        private string ConsultaFactura(string fileName)
        {
            string vMetodo=string.Empty;
            try
            {
                string Valor = String.Empty;
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                XmlNode nodoComprobante = doc.GetElementsByTagName("cfdi:Comprobante").Item(0);
                Valor = nodoComprobante.Attributes["MetodoPago"].Value;
                vMetodo = Valor;
                txt_MetodoPago.Text = Valor;
                Valor = nodoComprobante.Attributes["Fecha"].Value;
                dt_FechaFacturaProductor.DateTime = Convert.ToDateTime(Valor);
                Valor = nodoComprobante.Attributes["Folio"].Value;
                txt_FolioFacturaProductor.Text = Valor;
                Valor = nodoComprobante.Attributes["SubTotal"].Value;
                txt_SubTotal.Text = Valor;
                Valor = nodoComprobante.Attributes["Total"].Value;
                txt_Total.Text = Valor;
                XmlNode nodoComplemento = doc.GetElementsByTagName("tfd:TimbreFiscalDigital").Item(0);
                Valor = nodoComplemento.Attributes["UUID"].Value;
                txt_UUID.Text = Valor;
                XmlNode nodoEmisor = doc.GetElementsByTagName("cfdi:Emisor").Item(0);
                Valor = nodoEmisor.Attributes["Nombre"].Value;
                txtRazonSProductor.Text = Valor;

            }
            catch
            {
                txt_RutaXMLProductor.Text=String.Empty;
                XtraMessageBox.Show("No es un Archivo CFDI Valido favor de verificarlo");
                return vMetodo;
            }
            return vMetodo;
        }
        void CalcularTotalREP()
        {
            CLS_Cosecha_Facturas sel = new CLS_Cosecha_Facturas();
            sel.Id_Cosecha = txt_IdCosecha.Text;
            sel.MtdSeleccionarCosechaTotalREP();
            if(sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    txt_SumaTotal_REP.Text = sel.Datos.Rows[0]["Total"].ToString();
                    txt_Salto_REP.Text = Convert.ToString(Decimal.Parse(txt_Total.Text, style, provider) - decimal.Parse(txt_SumaTotal_REP.Text, style, provider));
                }
                else
                {
                    txt_SumaTotal_REP.Text = "0";
                    txt_Salto_REP.Text = "0";
                }
            }
        }
        private void btn_UpXMLProductor_Click(object sender, EventArgs e)
        {
            if (txt_IdCosecha.Text != String.Empty)
            {
                DialogResult result = FileDialogXML();
                if (result == DialogResult.OK)
                {
                    txt_RutaXMLProductor.Text = OpenDialog.FileName;
                    GuardarRuta(OpenDialog.FileName);
                    if (ConsultaFactura(OpenDialog.FileName) == "PPD")
                    {
                        xtraTabPage4.PageVisible = true;
                        txt_SumaTotal_REP.Visible = true;
                        txt_Salto_REP.Visible = true;
                        labelControl207.Visible = true;
                        labelControl208.Visible = true;
                        CalcularTotalREP();
                    }
                    else
                    {
                        xtraTabPage4.PageVisible = false;
                        txt_SumaTotal_REP.Visible = false;
                        txt_Salto_REP.Visible = false;
                        labelControl207.Visible = false;
                        labelControl208.Visible = false;
                        CalcularTotalREP();
                    }
                }
                CalcularFechaPrograma(dt_FechaRecepcion.DateTime);
                OpenDialog.Dispose();
            }
            else
            {
                XtraMessageBox.Show("No se ha guardado o definido un folio de cosecha");
            }
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
            chk_kgProductor.Checked = false;
            txt_OrdenCorte.Text = string.Empty;
            txt_Secuencia.Text = string.Empty;
            txt_Recepcion.Text = string.Empty;
            txt_TicketPesada.Text = string.Empty;
            txt_EstibaSel.Text = string.Empty;
            txt_CajasCortadas.EditValue = "0";
            txt_KilosCortados.EditValue = "0";
            txt_KilosPromedio.EditValue = "0";
            txt_TipoCultivo.Text = string.Empty;
            dt_FechaRecepcion.EditValue = DateTime.Now;
            txt_EmpresaBascula.Text = string.Empty;
            txt_EmpresaBascula.Tag = string.Empty;
            txt_KilosBasculaE.EditValue = "0";
            txt_KilosDiferencia.EditValue = "0";
            txt_KilosAjuste.EditValue = "0";
            txt_kilosST.EditValue = "0";
            txt_KilosProductor.EditValue = "0";
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
            txt_Productor.Text = string.Empty;
            txt_KilosAjustados.EditValue = "0";
            txt_KilosMuestra.EditValue = "0";
            txt_kilos_Totales.EditValue = "0";
            txt_KiloPrecio.EditValue = "0";
            txt_KiloPrecioInicial.EditValue = "0";
            txt_TotalaPagar.EditValue = "0";
            txt_ObservacionesProductor.Text = string.Empty;
            chk_Mercado.Checked = false;
        }
        void LimpiarCorte()
        {
            txt_NombreEmpresaCorte.Text = string.Empty;
            txt_NombreEmpresaCorte.Tag = string.Empty;
            txtTipoCorteEC.Text = string.Empty;
            txt_kilosCortadosCorte.EditValue = "0";
            txt_Margen5.EditValue = "0";
            txt_kgNoSolicitados.EditValue = "0";
            txt_KilosARestar.EditValue = "0";
            txt_KilosAjustadosCorte.EditValue = "0";
            txt_CajasCortadasCorte.EditValue = "0";
            txt_PrecioKiloCorte.EditValue = "0";
            txt_PrecioTCorte.EditValue = "0";
            txt_PrecioDiaCorte.EditValue = "0";
            txt_PrecioSalidaFCorte.EditValue = "0";
            txt_PrecioCuadrillaCorte.EditValue = "0";
            txt_PagoTotalCorte.EditValue = "0";
            txt_ObservacionesCorte.Text = string.Empty;
            txt_NoCuadrillas.Value = 1;
            LimpiarCamposServiciosCorte();
        }
        private void LimpiarCamposServiciosCorte()
        {
            txtMenorakg.EditValue = "0";
            txtPreciokg.EditValue = "0";
            txtPrecioDia.EditValue = "0";
            txtCajasMenorA.EditValue = "0";
            txtPrecioCajaMenorA.EditValue = "0";
            txtCajasMayorA.EditValue = "0";
            txtPrecioCajaMayorA.EditValue = "0";
            txtPrecioCuadrillaA.EditValue = "0";
            txtKilosMayorA.EditValue = "0";
            txtKilosMenorA.EditValue = "0";
            txtPrecioMayorA.EditValue = "0";
            txtPrecioMenorA.EditValue = "0";
            txtPrecioSalidaFalso.Tag = "0";
        }
        void LimpiarAcarreo()
        {
            txt_EmpresaAcarreo.Text = string.Empty;
            txt_EmpresaAcarreo.Tag = string.Empty;
            cmb_Camiones.Properties.DataSource = null;
            txtPlacasCamion.Text = string.Empty;
            cmb_Choferes.Properties.DataSource = null;
            txt_CajasProgramadasA.EditValue = "0";
            txt_Cajas_CortadasA.EditValue = "0";
            txt_CostoServicio.EditValue = "0";
            txt_CajasExtras.EditValue = "0";
            txt_CostoxCajaExtra.EditValue = "0";
            txt_CargosExtra.EditValue = "0";
            txt_TotalAcarreo.EditValue = "0";
            txtPrecioServicio.EditValue = "0";
            txtPrecioCaja.EditValue = "0";
            txtPrecioSalidaForanea.EditValue = "0";
            txt_ObservacionesAcarreo.Text = string.Empty;
        }
        void LimpiarFacturasProductor()
        {
            txtRazonSProductor.Text = string.Empty;
            txt_RutaPDFProductor.Text = string.Empty;
            txt_RutaXMLProductor.Text = string.Empty;
            txt_FolioFacturaProductor.Text = string.Empty;
            cmb_MonedaProductor.SelectedIndex = 0;
            txt_ImporteFacturaProductor.EditValue = "0";
            txt_RetencionFacturaProductor.EditValue = "0";
            txt_IVAFacturaProductor.EditValue = "0";
            txt_TotalFacturaProductor.EditValue = "0";
            chk_RetencionProductor.Checked = false;
            chk_RetencionFleteProductor.Checked = false;
            chk_IVAProductor.Checked = false;
            chk_PagadaProductor.Checked = false;
            dt_FechaFacturaProductor.DateTime = DateTime.Now;
            dt_FechaPagoProductor.DateTime = DateTime.Now;
            dt_FechaProgramaProductor.DateTime = DateTime.Now;
            opt_TipoFacturaProductor.SelectedIndex = 0;
            btn_ViewPDFProductor.Enabled = false;
            btn_ViewXMLProductor.Enabled = false;
            this.dt_FechaPagoProductor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.dt_FechaPagoProductor.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.dt_FechaPagoProductor.Properties.Appearance.Options.UseFont = true;
            this.dt_FechaPagoProductor.Properties.Appearance.Options.UseForeColor = true;
            xtraTabPage4.PageVisible = false;
            txt_MetodoPago.Text = String.Empty;
            txt_SubTotal.Text=String.Empty;
            txt_Total.Text=String.Empty;
            txt_UUID.Text=String.Empty;
        }
        void LimpiarFacturasKilos()
        {
            txtRazonSCorteKilos.Text = string.Empty;
            txt_RutaPDFCorteKilos.Text = string.Empty;
            txt_RutaXMLCorteKilos.Text = string.Empty;
            txt_FolioFacturaCorteKilos.Text = string.Empty;
            cmb_MonedaCorteKilos.SelectedIndex = 0;
            txt_ImporteFacturaCorteKilos.EditValue = "0";
            txt_IVAFacturaCorteKilos.EditValue = "0";
            txt_RetencionFacturaCorteKilos.EditValue = "0";
            txt_TotalFacturaCorteKilos.EditValue = "0";
            chk_RetencionCorteKilos.Checked = false;
            chk_RetencionFleteCorteKilos.Checked = false;
            chk_IVACorteKilos.Checked = false;
            chk_PagadaCorteKilos.Checked = false;
            dt_FechaFacturaCorteKilos.DateTime = DateTime.Now;
            dt_FechaPagoCorteKilos.DateTime = DateTime.Now;
            dt_FechaProgramaCorteKilos.DateTime = DateTime.Now;
            opt_TipoFacturaCorteKilos.SelectedIndex = 0;
            btn_ViewPDFCorteKilos.Enabled = false;
            btn_ViewXMLCorteKilos.Enabled = false;
            this.dt_FechaPagoCorteKilos.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.dt_FechaPagoCorteKilos.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.dt_FechaPagoCorteKilos.Properties.Appearance.Options.UseFont = true;
            this.dt_FechaPagoCorteKilos.Properties.Appearance.Options.UseForeColor = true;
            txt_SubTotal_Kilos.Text = "0";
            txt_Total_Kilos.Text = "0";
        }
        void LimpiarFacturasDia()
        {
            txtRazonSCorteDia.Text = string.Empty;
            txt_RutaPDFCorteDia.Text = string.Empty;
            txt_RutaXMLCorteDia.Text = string.Empty;
            txt_FolioFacturaCorteDia.Text = string.Empty;
            cmb_MonedaCorteDia.SelectedIndex = 0;
            txt_ImporteFacturaCorteDia.EditValue = "0";
            txt_RetencionFacturaCorteDia.EditValue = "0";
            txt_IVAFacturaCorteDia.EditValue = "0";
            txt_TotalFacturaCorteDia.EditValue = "0";
            chk_RetencionCorteDia.Checked = false;
            chk_RetencionFleteCorteDia.Checked = false;
            chk_IVACorteDia.Checked = false;
            chk_PagadaCorteDia.Checked = false;
            dt_FechaFacturaCorteDia.DateTime = DateTime.Now;
            dt_FechaPagoCorteDia.DateTime = DateTime.Now;
            dt_FechaProgramaCorteDia.DateTime = DateTime.Now;
            opt_TipoFacturaCorteDia.SelectedIndex = 0;
            btn_ViewPDFCorteDia.Enabled = false;
            btn_ViewXMLCorteDia.Enabled = false;
            this.dt_FechaPagoCorteDia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.dt_FechaPagoCorteDia.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.dt_FechaPagoCorteDia.Properties.Appearance.Options.UseFont = true;
            this.dt_FechaPagoCorteDia.Properties.Appearance.Options.UseForeColor = true;
            txt_SubTotal_Dia.Text = "0";
            txt_Total_Dia.Text = "0";
        }
        void LimpiarFacturasApoyo()
        {
            txtRazonSCorteApoyo.Text = string.Empty;
            txt_RutaPDFCorteApoyo.Text = string.Empty;
            txt_RutaXMLCorteApoyo.Text = string.Empty;
            txt_FolioFacturaCorteApoyo.Text = string.Empty;
            cmb_MonedaCorteApoyo.SelectedIndex = 0;
            txt_ImporteFacturaCorteApoyo.EditValue = "0";
            txt_RetencionFacturaCorteApoyo.EditValue = "0";
            txt_IVAFacturaCorteApoyo.EditValue = "0";
            txt_TotalFacturaCorteApoyo.EditValue = "0";
            chk_RetencionCorteApoyo.Checked = false;
            chk_RetencionFleteCorteApoyo.Checked = false;
            chk_IVACorteApoyo.Checked = false;
            chk_PagadaCorteApoyo.Checked = false;
            dt_FechaFacturaCorteApoyo.DateTime = DateTime.Now;
            dt_FechaPagoCorteApoyo.DateTime = DateTime.Now;
            dt_FechaProgramaCorteApoyo.DateTime = DateTime.Now;
            opt_TipoFacturaCorteApoyo.SelectedIndex = 0;
            btn_ViewPDFCorteApoyo.Enabled = false;
            btn_ViewXMLCorteApoyo.Enabled = false;
            this.dt_FechaPagoCorteApoyo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.dt_FechaPagoCorteApoyo.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.dt_FechaPagoCorteApoyo.Properties.Appearance.Options.UseFont = true;
            this.dt_FechaPagoCorteApoyo.Properties.Appearance.Options.UseForeColor = true;
            txt_SubTotal_Apoyo.Text = "0";
            txt_Total_Apoyo.Text = "0";
        }
        void LimpiarFacturasSalida()
        {
            txtRazonSCorteSalida.Text = string.Empty;
            txt_RutaPDFCorteSalida.Text = string.Empty;
            txt_RutaXMLCorteSalida.Text = string.Empty;
            txt_FolioFacturaCorteSalida.Text = string.Empty;
            cmb_MonedaCorteSalida.SelectedIndex = 0;
            txt_ImporteFacturaCorteSalida.EditValue = "0";
            txt_RetencionFacturaCorteSalida.EditValue = "0";
            txt_IVAFacturaCorteSalida.EditValue = "0";
            txt_TotalFacturaCorteSalida.EditValue = "0";
            chk_RetencionCorteSalida.Checked = false;
            chk_RetencionFleteCorteSalida.Checked = false;
            chk_IVACorteSalida.Checked = false;
            chk_PagadaCorteSalida.Checked = false;
            dt_FechaFacturaCorteSalida.DateTime = DateTime.Now;
            dt_FechaPagoCorteSalida.DateTime = DateTime.Now;
            dt_FechaProgramaCorteSalida.DateTime = DateTime.Now;
            opt_TipoFacturaCorteSalida.SelectedIndex = 0;
            btn_ViewPDFCorteSalida.Enabled = false;
            btn_ViewXMLCorteSalida.Enabled = false;
            this.dt_FechaPagoCorteSalida.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.dt_FechaPagoCorteSalida.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.dt_FechaPagoCorteSalida.Properties.Appearance.Options.UseFont = true;
            this.dt_FechaPagoCorteSalida.Properties.Appearance.Options.UseForeColor = true;
            txt_SubTotal_Salida.Text = "0";
            txt_Total_Salida.Text = "0";
        }
        void LimpiarFacturasAcarreo()
        {
            txtRazonSAcarreo.Text = string.Empty;
            txt_RutaPDFAcarreo.Text = string.Empty;
            txt_RutaXMLAcarreo.Text = string.Empty;
            txt_FolioFacturaAcarreo.Text = string.Empty;
            cmb_MonedaAcarreo.SelectedIndex = 0;
            txt_ImporteFacturaAcarreo.EditValue = "0";
            txt_RetencionFacturaAcarreo.EditValue = "0";
            txt_RetencionFleteFacturaAcarreo.EditValue = "0";
            txt_IVAFacturaAcarreo.EditValue = "0";
            txt_TotalFacturaAcarreo.EditValue = "0";
            chk_RetencionAcarreo.Checked = false;
            chk_RetencionFleteAcarreo.Checked = false;
            chk_IVAAcarreo.Checked = false;
            chk_PagadaAcarreo.Checked = false;
            dt_FechaFacturaAcarreo.DateTime = DateTime.Now;
            dt_FechaPagoAcarreo.DateTime = DateTime.Now;
            dt_FechaProgramaAcarreo.DateTime = DateTime.Now;
            opt_TipoFacturaAcarreo.SelectedIndex = 0;
            btn_ViewPDFAcarreo.Enabled = false;
            btn_ViewXMLAcarreo.Enabled = false;
            this.dt_FechaPagoAcarreo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.dt_FechaPagoAcarreo.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.dt_FechaPagoAcarreo.Properties.Appearance.Options.UseFont = true;
            this.dt_FechaPagoAcarreo.Properties.Appearance.Options.UseForeColor = true;
            txt_SubTotal_Acarreo.Text = "0";
            txt_Total_Acarreo.Text = "0";
        }
        void LimpiarProductorExpediente()
        {
            vRutaTarjetaApeam = String.Empty;
            btn_ViewPDFTarjetaAPEAM.Enabled = false;
            btn_DelTarjetaAPEAM.Enabled = false;
            dt_FechaTarjetaAPEAM.EditValue = DateTime.Now;
            vRutaIdentificacion_INE_IFE=String.Empty;
            btn_ViewPDFIdentificacion_IFE_INE.Enabled = false;
            btn_DelIdentificacion_IFE_INE.Enabled = false;
            dt_FechaIdentificacion_IFE_INE.EditValue = DateTime.Now;
            vRutaOpinion_Cumplimiento = String.Empty;   
            btn_ViewPDFOpinionCumplimiento.Enabled = false;
            btn_DelOpinionCumplimiento.Enabled = false;
            dt_FechaOPinionCumplimiento.EditValue = DateTime.Now;
            vRutaConstancia_de_Situacion_Fiscal = String.Empty;
            btn_ViewPDFConstanciaSituacion.Enabled = false;
            btn_DelConstanciaSituacion.Enabled = false;
            dt_FechaConstanciaSituacion.EditValue = DateTime.Now;
            vRutaClave_Interbancaria = String.Empty;
            btn_ViewPDFClaveInterbancaria.Enabled = false;
            btn_DelClaveInterbancaria.Enabled = false;
            dt_FechaClaveInterbancaria.EditValue = DateTime.Now;
            vRutaContrato_entre_Terceros = String.Empty;
            btn_ViewPDFContratoTerceros.Enabled = false;
            btn_DelContratoTerceros.Enabled = false;
            dt_FechaContratoTerceros.EditValue = DateTime.Now;
            vRutaContrato_GEST=String.Empty;
            btn_ViewPDFContratoGEST.Enabled = false;
            btn_DelContratoGEST.Enabled = false;
            dt_FechaContratoGEST.EditValue = DateTime.Now;
        }
        private void btn_limpiarOrden_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vCarga = 1;
            LimpiarOrdenCorte();
            LimpiarRecepcion();
            LimpiarComercializadora();
            LimpiarProductor();
            LimpiarProductorExpediente();
            LimpiarPPD();
            LimpiarCorte();
            LimpiarAcarreo();
            LimpiarFacturas();
            InicializaVariables();
            navigationPane1.SelectedPageIndex = 0;
            BarProductor.Caption = string.Empty;
            BarHuerta.Caption = string.Empty;
            BarEstiba.Caption = string.Empty;
            Bloquear_OrdenCorte(true);
            Bloquear_Recepcion(true);
            Bloquear_Productor(true);
            Bloquear_Comercializacion(true);
            Bloquear_Corte(true);
            Bloquear_Acarreo(true);
            vCarga = 0;
            dtgFacturasREP.DataSource = null;
        }

        private void LimpiarFacturas()
        {
            LimpiarFacturasProductor();
            LimpiarFacturasKilos();
            LimpiarFacturasDia();
            LimpiarFacturasApoyo();
            LimpiarFacturasSalida();
            LimpiarFacturasAcarreo();
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
        void GuardarProductorExpedientes()
        {
            ExpedienteProductor();
            SelectExpedientesProductor();
        }
        private void btn_GuardarOrden_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vId_Cosecha = "0";
            GuardarOrdenCorte();
            if (vId_Cosecha != "0")
            {
                GuardarRecepcion();
                GuardarComercializadora();
                GuardarProductor();
                GuardarProductorExpedientes();
                GuardarCorte();
                GuardarAcarreo();
                GuardarFacturas();
                SelectFacturas();
                
                XtraMessageBox.Show("Se ha guardado el registro con exito");
            }
            CargarCosechas();
        }
        private void ExpedienteProductor()
        {
            Byte[] ArchivoPDFTarjetaAPEAM = null;
            Byte[] ArchivoPDFIdentificacion_INE_IFE = null;
            Byte[] ArchivoPDFOpinion_Cumplimiento = null;
            Byte[] ArchivoPDFConstancia_de_Situacion_Fiscal = null;
            Byte[] ArchivoPDFClave_Interbancaria = null;
            Byte[] ArchivoPDFContrato_entre_Terceros = null;
            Byte[] ArchivoPDFContrato_GEST = null;

            FileStream fsPDF = null;

            Boolean noentroPDFTarjetaAPEAM = true;
            Boolean noentroPDFIdentificacion_INE_IFE = true;
            Boolean noentroPDFOpinion_Cumplimiento = true;
            Boolean noentroPDFConstancia_de_Situacion_Fiscal = true;
            Boolean noentroPDFClave_Interbancaria = true;
            Boolean noentroPDFContrato_entre_Terceros = true;
            Boolean noentroPDFContrato_GEST = true;


            if (vRutaTarjetaApeam.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(vRutaTarjetaApeam, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDFTarjetaAPEAM = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDFTarjetaAPEAM, 0, (int)fsPDF.Length);
                ArchivoPDFGlobalTarjetaApeam = ArchivoPDFTarjetaAPEAM;
            }
            else
            {
                ArchivoPDFTarjetaAPEAM = ArchivoPDFGlobalTarjetaApeam;
                noentroPDFTarjetaAPEAM = false;
            }

            if (vRutaIdentificacion_INE_IFE.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(vRutaIdentificacion_INE_IFE, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDFIdentificacion_INE_IFE = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDFIdentificacion_INE_IFE, 0, (int)fsPDF.Length);
                ArchivoPDFGlobalIdentificacion_INE_IFE = ArchivoPDFIdentificacion_INE_IFE;
            }
            else
            {
                ArchivoPDFIdentificacion_INE_IFE = ArchivoPDFGlobalIdentificacion_INE_IFE;
                noentroPDFIdentificacion_INE_IFE = false;
            }

            if (vRutaOpinion_Cumplimiento.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(vRutaOpinion_Cumplimiento, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDFOpinion_Cumplimiento = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDFOpinion_Cumplimiento, 0, (int)fsPDF.Length);
                ArchivoPDFGlobalOpinion_Cumplimiento = ArchivoPDFOpinion_Cumplimiento;
            }
            else
            {
                ArchivoPDFOpinion_Cumplimiento = ArchivoPDFGlobalOpinion_Cumplimiento;
                noentroPDFOpinion_Cumplimiento = false;
            }

            if (vRutaConstancia_de_Situacion_Fiscal.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(vRutaConstancia_de_Situacion_Fiscal, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDFConstancia_de_Situacion_Fiscal = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDFConstancia_de_Situacion_Fiscal, 0, (int)fsPDF.Length);
                ArchivoPDFGlobalConstancia_de_Situacion_Fiscal = ArchivoPDFConstancia_de_Situacion_Fiscal;
            }
            else
            {
                ArchivoPDFConstancia_de_Situacion_Fiscal = ArchivoPDFGlobalConstancia_de_Situacion_Fiscal;
                noentroPDFConstancia_de_Situacion_Fiscal = false;
            }

            if (vRutaClave_Interbancaria.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(vRutaClave_Interbancaria, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDFClave_Interbancaria = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDFClave_Interbancaria, 0, (int)fsPDF.Length);
                ArchivoPDFGlobalClave_Interbancaria = ArchivoPDFClave_Interbancaria;
            }
            else
            {
                ArchivoPDFClave_Interbancaria = ArchivoPDFGlobalClave_Interbancaria;
                noentroPDFClave_Interbancaria = false;
            }

            if (vRutaContrato_entre_Terceros.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(vRutaContrato_entre_Terceros, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDFContrato_entre_Terceros = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDFContrato_entre_Terceros, 0, (int)fsPDF.Length);
                ArchivoPDFGlobalContrato_entre_Terceros = ArchivoPDFContrato_entre_Terceros;
            }
            else
            {
                ArchivoPDFContrato_entre_Terceros = ArchivoPDFGlobalContrato_entre_Terceros;
                noentroPDFContrato_entre_Terceros = false;
            }

            if (vRutaContrato_GEST.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(vRutaContrato_GEST, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDFContrato_GEST = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDFContrato_GEST, 0, (int)fsPDF.Length);
                ArchivoPDFGlobalContrato_GEST = ArchivoPDFContrato_GEST;
            }
            else
            {
                ArchivoPDFContrato_GEST = ArchivoPDFGlobalContrato_GEST;
                noentroPDFContrato_GEST = false;
            }

            DateTime vFecha = DateTime.Now;

            CLS_Cosecha_Expedientes Clase = new CLS_Cosecha_Expedientes();
            Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
            
            //1
            if (ArchivoPDFGlobalTarjetaApeam != null)
            {
                Clase.TarjetaApeam = ArchivoPDFGlobalTarjetaApeam;
                vFecha = dt_FechaTarjetaAPEAM.DateTime;
                Clase.d_TarjetaApeam = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            else
            {
                Clase.TarjetaApeam = Encoding.UTF8.GetBytes("");
                vFecha = DateTime.Now;
                Clase.d_TarjetaApeam = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            //2
            if (ArchivoPDFGlobalIdentificacion_INE_IFE != null)
            {
                Clase.Identificacion_INE_IFE = ArchivoPDFGlobalIdentificacion_INE_IFE;
                vFecha = dt_FechaIdentificacion_IFE_INE.DateTime;
                Clase.d_Identificacion_INE_IFE = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            else
            {
                Clase.Identificacion_INE_IFE = Encoding.UTF8.GetBytes("");
                vFecha = DateTime.Now;
                Clase.d_Identificacion_INE_IFE = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            //3
            if (ArchivoPDFGlobalOpinion_Cumplimiento != null)
            {
                Clase.Opinion_Cumplimiento = ArchivoPDFGlobalOpinion_Cumplimiento;
                vFecha = dt_FechaOPinionCumplimiento.DateTime;
                Clase.d_Opinion_Cumplimiento = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            else
            {
                Clase.Opinion_Cumplimiento = Encoding.UTF8.GetBytes("");
                vFecha = DateTime.Now;
                Clase.d_Opinion_Cumplimiento = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            //4
            if (ArchivoPDFGlobalConstancia_de_Situacion_Fiscal != null)
            {
                Clase.Constancia_de_Situacion_Fiscal = ArchivoPDFGlobalConstancia_de_Situacion_Fiscal;
                vFecha = dt_FechaConstanciaSituacion.DateTime;
                Clase.d_Constancia_de_Situacion_Fiscal = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            else
            {
                Clase.Constancia_de_Situacion_Fiscal = Encoding.UTF8.GetBytes("");
                vFecha = DateTime.Now;
                Clase.d_Constancia_de_Situacion_Fiscal = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            //5
            if (ArchivoPDFGlobalClave_Interbancaria != null)
            {
                Clase.Clave_Interbancaria = ArchivoPDFGlobalClave_Interbancaria;
                vFecha = dt_FechaClaveInterbancaria.DateTime;
                Clase.d_Clave_Interbancaria = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            else
            {
                Clase.Clave_Interbancaria = Encoding.UTF8.GetBytes("");
                vFecha = DateTime.Now;
                Clase.d_Clave_Interbancaria = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            //6
            if (ArchivoPDFGlobalContrato_entre_Terceros != null)
            {
                Clase.Contrato_entre_Terceros = ArchivoPDFGlobalContrato_entre_Terceros;
                vFecha = dt_FechaContratoTerceros.DateTime;
                Clase.d_Contrato_entre_Terceros = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            else
            {
                Clase.Contrato_entre_Terceros = Encoding.UTF8.GetBytes("");
                vFecha = DateTime.Now;
                Clase.d_Contrato_entre_Terceros = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());

            }
            //7
            if (ArchivoPDFGlobalContrato_GEST != null)
            {
                Clase.Contrato_GEST = ArchivoPDFGlobalContrato_GEST;
                vFecha = dt_FechaContratoGEST.DateTime;
                Clase.d_Contrato_GEST = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }
            else
            {
                Clase.Contrato_GEST = Encoding.UTF8.GetBytes("");
                vFecha = DateTime.Now;
                Clase.d_Contrato_GEST = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            }

            Clase.Usuario = UsuariosLogin;
            
            Clase.MtdInsertarCosechaArchivoPDFXML();
            if (!Clase.Exito)
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
            
            if (noentroPDFTarjetaAPEAM || noentroPDFIdentificacion_INE_IFE || noentroPDFOpinion_Cumplimiento || noentroPDFConstancia_de_Situacion_Fiscal || noentroPDFClave_Interbancaria || noentroPDFContrato_entre_Terceros || noentroPDFContrato_GEST)
            {
                fsPDF.Close();
            }
        }
        private void GuardarFacturas()
        {
            FacturaProductor();
            FacturaKilos();
            FacturaDia();
            FacturaApoyo();
            FacturaSalida();
            FacturaAcarreo();
        }

        private void FacturaProductor()
        {
            Byte[] ArchivoPDF = null;
            Byte[] ArchivoXML = null;

            FileStream fsPDF = null;
            FileStream fsXML = null;

            Boolean noentroPDF = true, noentroXML = true;


            if (txt_RutaPDFProductor.Text.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(txt_RutaPDFProductor.Text, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDF = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDF, 0, (int)fsPDF.Length);
                ArchivoPDFGlobalProductor = ArchivoPDF;
            }
            else
            {
                ArchivoPDF = ArchivoPDFGlobalProductor;
                noentroPDF = false;
            }
            if (txt_RutaXMLProductor.Text.Length > 0)
            {
                fsXML = new FileStream(txt_RutaXMLProductor.Text, FileMode.Open);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoXML = new byte[fsXML.Length];
                //Y guardamos los datos en el array data
                fsXML.Read(ArchivoXML, 0, Convert.ToInt32(fsXML.Length));
                ArchivoXMLGlobalProductor = ArchivoXML;
            }
            else
            {
                ArchivoXML = ArchivoXMLGlobalProductor;
                noentroXML = false;
            }

            CLS_Cosecha_Facturas Clase = new CLS_Cosecha_Facturas();
            Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
            Clase.Id_Archivo = 1;
            Clase.RazonSocial = txtRazonSProductor.Text;
            if (ArchivoPDF != null)
            {
                Clase.FacturaPDF = ArchivoPDF;
            }
            else
            {
                Clase.FacturaPDF = Encoding.UTF8.GetBytes("");
            }

            if (ArchivoXML != null)
            {
                Clase.FacturaXML = ArchivoXML;
            }
            else
            {
                Clase.FacturaXML = Encoding.UTF8.GetBytes("");
            }
            Clase.FolioFactura = txt_FolioFacturaProductor.Text.Trim();
            if (cmb_MonedaProductor.Text.Equals("Pesos"))
            {
                Clase.Moneda = "P";
            }
            else
            {
                Clase.Moneda = "D";
            }
            Clase.Importe_Factura = Decimal.Parse(txt_ImporteFacturaProductor.Text, style, provider);
            if (chk_PagadaProductor.Checked)
            {
                Clase.Pagada = 1;
            }
            else
            {
                Clase.Pagada = 0;
            }

            if (chk_RetencionProductor.Checked)
            {
                Clase.Retencion = 1;
            }
            else
            {
                Clase.Retencion = 0;
            }

            Clase.Importe_Retencion = Decimal.Parse(txt_RetencionFacturaProductor.Text, style, provider);

            if (chk_IVAProductor.Checked)
            {
                Clase.IVA = 1;
            }
            else
            {
                Clase.IVA = 0;
            }

            Clase.Importe_IVA = Decimal.Parse(txt_IVAFacturaProductor.Text, style, provider);
            Clase.Total_Factura = Decimal.Parse(txt_TotalFacturaProductor.Text, style, provider);
            DateTime Fecha;


            if (dt_FechaFacturaProductor.EditValue == null)
            {
                Clase.Fecha_Factura = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaFacturaProductor.Text.Trim());
                Clase.Fecha_Factura = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (dt_FechaPagoProductor.EditValue == null)
            {
                Clase.Fecha_Pago = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaPagoProductor.Text.Trim());
                Clase.Fecha_Pago = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (dt_FechaProgramaProductor.EditValue == null)
            {
                Clase.Fecha_Programacion = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaProgramaProductor.Text.Trim());
                Clase.Fecha_Programacion = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (opt_TipoFacturaProductor.SelectedIndex == 0)
            {
                Clase.Diferido = 1;
            }
            else
            {
                Clase.Diferido = 0;
            }
            Clase.UUID = txt_UUID.Text;
            Clase.MetodoPago = txt_MetodoPago.Text;
            Clase.SubTotalXML = Decimal.Parse(txt_SubTotal.Text, style, provider); 
            Clase.TotalXML = Decimal.Parse(txt_Total.Text, style, provider); 
            Clase.Usuario = UsuariosLogin;
            //if (ArchivoPDFGlobalProductor != null || ArchivoXMLGlobalProductor != null)
            //{
            Clase.MtdInsertarCosechaArchivoPDFXML();
            if (!Clase.Exito)
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
            //}
            if (noentroXML)
            {
                fsXML.Close();
            }
            if (noentroPDF)
            {
                fsPDF.Close();
            }
        }
        private void FacturaKilos()
        {
            Byte[] ArchivoPDF = null;
            Byte[] ArchivoXML = null;

            FileStream fsPDF = null;
            FileStream fsXML = null;

            Boolean noentroPDF = true, noentroXML = true;


            if (txt_RutaPDFCorteKilos.Text.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(txt_RutaPDFCorteKilos.Text, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDF = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDF, 0, (int)fsPDF.Length);
            }
            else
            {
                ArchivoPDF = ArchivoPDFGlobalCorteKilos;
                noentroPDF = false;
            }
            if (txt_RutaXMLCorteKilos.Text.Length > 0)
            {
                fsXML = new FileStream(txt_RutaXMLCorteKilos.Text, FileMode.Open);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoXML = new byte[fsXML.Length];
                //Y guardamos los datos en el array data
                fsXML.Read(ArchivoXML, 0, Convert.ToInt32(fsXML.Length));
            }
            else
            {
                ArchivoXML = ArchivoXMLGlobalCorteKilos;
                noentroXML = false;
            }

            CLS_Cosecha_Facturas Clase = new CLS_Cosecha_Facturas();
            Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
            Clase.Id_Archivo = 2;
            Clase.RazonSocial = txtRazonSCorteKilos.Text;
            if (ArchivoPDF != null)
            {
                Clase.FacturaPDF = ArchivoPDF;
            }
            else
            {
                Clase.FacturaPDF = Encoding.UTF8.GetBytes("");
            }

            if (ArchivoXML != null)
            {
                Clase.FacturaXML = ArchivoXML;
            }
            else
            {
                Clase.FacturaXML = Encoding.UTF8.GetBytes("");
            }
            Clase.FolioFactura = txt_FolioFacturaCorteKilos.Text.Trim();
            if (cmb_MonedaCorteKilos.Text.Equals("Pesos"))
            {
                Clase.Moneda = "P";
            }
            else
            {
                Clase.Moneda = "D";
            }
            Clase.Importe_Factura = Decimal.Parse(txt_ImporteFacturaCorteKilos.Text, style, provider);
            if (chk_PagadaCorteKilos.Checked)
            {
                Clase.Pagada = 1;
            }
            else
            {
                Clase.Pagada = 0;
            }
            if (chk_RetencionCorteKilos.Checked)
            {
                Clase.Retencion = 1;
            }
            else
            {
                Clase.Retencion = 0;
            }

            Clase.Importe_Retencion = Decimal.Parse(txt_RetencionFacturaCorteKilos.Text, style, provider);
            if (chk_IVACorteKilos.Checked)
            {
                Clase.IVA = 1;
            }
            else
            {
                Clase.IVA = 0;
            }

            Clase.Importe_IVA = Decimal.Parse(txt_IVAFacturaCorteKilos.Text, style, provider);

            if (chk_RetencionFleteCorteKilos.Checked)
            {
                Clase.Retencion_Flete = 1;
            }
            else
            {
                Clase.Retencion_Flete = 0;
            }

            Clase.Importe_Retencion_Flete = Decimal.Parse(txt_RetencionFleteFacturaCorteKilos.Text, style, provider);

            Clase.Total_Factura = Decimal.Parse(txt_TotalFacturaCorteKilos.Text, style, provider);
            DateTime Fecha;


            if (dt_FechaFacturaCorteKilos.EditValue == null)
            {
                Clase.Fecha_Factura = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaFacturaCorteKilos.Text.Trim());
                Clase.Fecha_Factura = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (dt_FechaPagoCorteKilos.EditValue == null)
            {
                Clase.Fecha_Pago = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaPagoCorteKilos.Text.Trim());
                Clase.Fecha_Pago = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (dt_FechaProgramaCorteKilos.EditValue == null)
            {
                Clase.Fecha_Programacion = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaProgramaCorteKilos.Text.Trim());
                Clase.Fecha_Programacion = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (opt_TipoFacturaCorteKilos.SelectedIndex == 0)
            {
                Clase.Diferido = 1;
            }
            else
            {
                Clase.Diferido = 0;
            }
            Clase.UUID = txt_UUID_Kilos.Text;
            Clase.MetodoPago = txt_MetodoPago_Kilos.Text;
            Clase.SubTotalXML = Decimal.Parse(txt_SubTotal_Kilos.Text, style, provider);
            Clase.TotalXML = Decimal.Parse(txt_Total_Kilos.Text, style, provider);
            Clase.Usuario = UsuariosLogin;
            //if (ArchivoPDFGlobalCorteKilos != null || ArchivoXMLGlobalCorteKilos != null)
            //{
            Clase.MtdInsertarCosechaArchivoPDFXML();
            if (!Clase.Exito)
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
            //}
            if (noentroXML)
            {
                fsXML.Close();
            }
            if (noentroPDF)
            {
                fsPDF.Close();
            }
        }
        private void FacturaDia()
        {
            Byte[] ArchivoPDF = null;
            Byte[] ArchivoXML = null;

            FileStream fsPDF = null;
            FileStream fsXML = null;

            Boolean noentroPDF = true, noentroXML = true;


            if (txt_RutaPDFCorteDia.Text.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(txt_RutaPDFCorteDia.Text, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDF = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDF, 0, (int)fsPDF.Length);
            }
            else
            {
                ArchivoPDF = ArchivoPDFGlobalCorteDia;
                noentroPDF = false;
            }
            if (txt_RutaXMLCorteDia.Text.Length > 0)
            {
                fsXML = new FileStream(txt_RutaXMLCorteDia.Text, FileMode.Open);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoXML = new byte[fsXML.Length];
                //Y guardamos los datos en el array data
                fsXML.Read(ArchivoXML, 0, Convert.ToInt32(fsXML.Length));
            }
            else
            {
                ArchivoXML = ArchivoXMLGlobalCorteDia;
                noentroXML = false;
            }

            CLS_Cosecha_Facturas Clase = new CLS_Cosecha_Facturas();
            Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
            Clase.Id_Archivo = 3;
            Clase.RazonSocial = txtRazonSCorteDia.Text;
            if (ArchivoPDF != null)
            {
                Clase.FacturaPDF = ArchivoPDF;
            }
            else
            {
                Clase.FacturaPDF = Encoding.UTF8.GetBytes("");
            }

            if (ArchivoXML != null)
            {
                Clase.FacturaXML = ArchivoXML;
            }
            else
            {
                Clase.FacturaXML = Encoding.UTF8.GetBytes("");
            }
            Clase.FolioFactura = txt_FolioFacturaCorteDia.Text.Trim();
            if (cmb_MonedaCorteDia.Text.Equals("Pesos"))
            {
                Clase.Moneda = "P";
            }
            else
            {
                Clase.Moneda = "D";
            }
            Clase.Importe_Factura = Decimal.Parse(txt_ImporteFacturaCorteDia.Text, style, provider);
            if (chk_PagadaCorteDia.Checked)
            {
                Clase.Pagada = 1;
            }
            else
            {
                Clase.Pagada = 0;
            }
            if (chk_RetencionCorteDia.Checked)
            {
                Clase.Retencion = 1;
            }
            else
            {
                Clase.Retencion = 0;
            }

            Clase.Importe_Retencion = Decimal.Parse(txt_RetencionFacturaCorteDia.Text, style, provider);
            if (chk_IVACorteDia.Checked)
            {
                Clase.IVA = 1;
            }
            else
            {
                Clase.IVA = 0;
            }

            Clase.Importe_IVA = Decimal.Parse(txt_IVAFacturaCorteDia.Text, style, provider);
            if (chk_RetencionFleteCorteDia.Checked)
            {
                Clase.Retencion_Flete = 1;
            }
            else
            {
                Clase.Retencion_Flete = 0;
            }

            Clase.Importe_Retencion_Flete = Decimal.Parse(txt_RetencionFleteFacturaCorteDia.Text, style, provider);

            Clase.Total_Factura = Decimal.Parse(txt_TotalFacturaCorteDia.Text, style, provider);
            DateTime Fecha;


            if (dt_FechaFacturaCorteDia.EditValue == null)
            {
                Clase.Fecha_Factura = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaFacturaCorteDia.Text.Trim());
                Clase.Fecha_Factura = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (dt_FechaPagoCorteDia.EditValue == null)
            {
                Clase.Fecha_Pago = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaPagoCorteDia.Text.Trim());
                Clase.Fecha_Pago = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (dt_FechaProgramaCorteDia.EditValue == null)
            {
                Clase.Fecha_Programacion = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaProgramaCorteDia.Text.Trim());
                Clase.Fecha_Programacion = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (opt_TipoFacturaCorteDia.SelectedIndex == 0)
            {
                Clase.Diferido = 1;
            }
            else
            {
                Clase.Diferido = 0;
            }
            Clase.UUID = txt_UUID_Dia.Text;
            Clase.MetodoPago = txt_MetodoPago_Dia.Text;
            Clase.SubTotalXML = Decimal.Parse(txt_SubTotal_Dia.Text, style, provider);
            Clase.TotalXML = Decimal.Parse(txt_Total_Dia.Text, style, provider);
            Clase.Usuario = UsuariosLogin;
            //if (ArchivoPDFGlobalCorteDia != null || ArchivoXMLGlobalCorteDia != null)
            //{
            Clase.MtdInsertarCosechaArchivoPDFXML();
            if (!Clase.Exito)
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
            //}
            if (noentroXML)
            {
                fsXML.Close();
            }
            if (noentroPDF)
            {
                fsPDF.Close();
            }
        }
        private void FacturaApoyo()
        {
            Byte[] ArchivoPDF = null;
            Byte[] ArchivoXML = null;

            FileStream fsPDF = null;
            FileStream fsXML = null;

            Boolean noentroPDF = true, noentroXML = true;


            if (txt_RutaPDFCorteApoyo.Text.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(txt_RutaPDFCorteApoyo.Text, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDF = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDF, 0, (int)fsPDF.Length);
            }
            else
            {
                ArchivoPDF = ArchivoPDFGlobalCorteApoyo;
                noentroPDF = false;
            }
            if (txt_RutaXMLCorteApoyo.Text.Length > 0)
            {
                fsXML = new FileStream(txt_RutaXMLCorteApoyo.Text, FileMode.Open);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoXML = new byte[fsXML.Length];
                //Y guardamos los datos en el array data
                fsXML.Read(ArchivoXML, 0, Convert.ToInt32(fsXML.Length));
            }
            else
            {
                ArchivoXML = ArchivoXMLGlobalCorteApoyo;
                noentroXML = false;
            }

            CLS_Cosecha_Facturas Clase = new CLS_Cosecha_Facturas();
            Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
            Clase.Id_Archivo = 4;
            Clase.RazonSocial = txtRazonSCorteApoyo.Text;
            if (ArchivoPDF != null)
            {
                Clase.FacturaPDF = ArchivoPDF;
            }
            else
            {
                Clase.FacturaPDF = Encoding.UTF8.GetBytes("");
            }

            if (ArchivoXML != null)
            {
                Clase.FacturaXML = ArchivoXML;
            }
            else
            {
                Clase.FacturaXML = Encoding.UTF8.GetBytes("");
            }
            Clase.FolioFactura = txt_FolioFacturaCorteApoyo.Text.Trim();
            if (cmb_MonedaCorteApoyo.Text.Equals("Pesos"))
            {
                Clase.Moneda = "P";
            }
            else
            {
                Clase.Moneda = "D";
            }
            Clase.Importe_Factura = Decimal.Parse(txt_ImporteFacturaCorteApoyo.Text, style, provider);
            if (chk_PagadaCorteApoyo.Checked)
            {
                Clase.Pagada = 1;
            }
            else
            {
                Clase.Pagada = 0;
            }
            if (chk_RetencionCorteApoyo.Checked)
            {
                Clase.Retencion = 1;
            }
            else
            {
                Clase.Retencion = 0;
            }

            Clase.Importe_Retencion = Decimal.Parse(txt_RetencionFacturaCorteApoyo.Text, style, provider);
            if (chk_IVACorteApoyo.Checked)
            {
                Clase.IVA = 1;
            }
            else
            {
                Clase.IVA = 0;
            }

            Clase.Importe_IVA = Decimal.Parse(txt_IVAFacturaCorteApoyo.Text, style, provider);
            if (chk_RetencionFleteCorteApoyo.Checked)
            {
                Clase.Retencion_Flete = 1;
            }
            else
            {
                Clase.Retencion_Flete = 0;
            }

            Clase.Importe_Retencion_Flete = Decimal.Parse(txt_RetencionFleteFacturaCorteApoyo.Text, style, provider);
            Clase.Retencion_Flete = 0;
            Clase.Importe_Retencion_Flete = 0;
            Clase.Total_Factura = Decimal.Parse(txt_TotalFacturaCorteApoyo.Text, style, provider);
            DateTime Fecha;


            if (dt_FechaFacturaCorteApoyo.EditValue == null)
            {
                Clase.Fecha_Factura = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaFacturaCorteApoyo.Text.Trim());
                Clase.Fecha_Factura = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (dt_FechaPagoCorteApoyo.EditValue == null)
            {
                Clase.Fecha_Pago = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaPagoCorteApoyo.Text.Trim());
                Clase.Fecha_Pago = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (dt_FechaProgramaCorteApoyo.EditValue == null)
            {
                Clase.Fecha_Programacion = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaProgramaCorteApoyo.Text.Trim());
                Clase.Fecha_Programacion = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (opt_TipoFacturaCorteApoyo.SelectedIndex == 0)
            {
                Clase.Diferido = 1;
            }
            else
            {
                Clase.Diferido = 0;
            }
            Clase.UUID = txt_UUID_Apoyo.Text;
            Clase.MetodoPago = txt_MetodoPago_Apoyo.Text;
            Clase.SubTotalXML = Decimal.Parse(txt_SubTotal_Apoyo.Text, style, provider);
            Clase.TotalXML = Decimal.Parse(txt_Total_Apoyo.Text, style, provider);
            Clase.Usuario = UsuariosLogin;
            //if (ArchivoPDFGlobalCorteApoyo != null || ArchivoXMLGlobalCorteApoyo != null)
            //{
            Clase.MtdInsertarCosechaArchivoPDFXML();
            if (!Clase.Exito)
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
            //}
            if (noentroXML)
            {
                fsXML.Close();
            }
            if (noentroPDF)
            {
                fsPDF.Close();
            }
        }
        private void FacturaSalida()
        {
            Byte[] ArchivoPDF = null;
            Byte[] ArchivoXML = null;

            FileStream fsPDF = null;
            FileStream fsXML = null;

            Boolean noentroPDF = true, noentroXML = true;


            if (txt_RutaPDFCorteSalida.Text.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(txt_RutaPDFCorteSalida.Text, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDF = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDF, 0, (int)fsPDF.Length);
            }
            else
            {
                ArchivoPDF = ArchivoPDFGlobalCorteSalida;
                noentroPDF = false;
            }
            if (txt_RutaXMLCorteSalida.Text.Length > 0)
            {
                fsXML = new FileStream(txt_RutaXMLCorteSalida.Text, FileMode.Open);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoXML = new byte[fsXML.Length];
                //Y guardamos los datos en el array data
                fsXML.Read(ArchivoXML, 0, Convert.ToInt32(fsXML.Length));
            }
            else
            {
                ArchivoXML = ArchivoXMLGlobalCorteSalida;
                noentroXML = false;
            }

            CLS_Cosecha_Facturas Clase = new CLS_Cosecha_Facturas();
            Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
            Clase.Id_Archivo = 5;
            Clase.RazonSocial = txtRazonSCorteSalida.Text;
            if (ArchivoPDF != null)
            {
                Clase.FacturaPDF = ArchivoPDF;
            }
            else
            {
                Clase.FacturaPDF = Encoding.UTF8.GetBytes("");
            }

            if (ArchivoXML != null)
            {
                Clase.FacturaXML = ArchivoXML;
            }
            else
            {
                Clase.FacturaXML = Encoding.UTF8.GetBytes("");
            }
            Clase.FolioFactura = txt_FolioFacturaCorteSalida.Text.Trim();
            if (cmb_MonedaCorteSalida.Text.Equals("Pesos"))
            {
                Clase.Moneda = "P";
            }
            else
            {
                Clase.Moneda = "D";
            }
            Clase.Importe_Factura = Decimal.Parse(txt_ImporteFacturaCorteSalida.Text, style, provider);
            if (chk_PagadaCorteSalida.Checked)
            {
                Clase.Pagada = 1;
            }
            else
            {
                Clase.Pagada = 0;
            }
            if (chk_RetencionCorteSalida.Checked)
            {
                Clase.Retencion = 1;
            }
            else
            {
                Clase.Retencion = 0;
            }

            Clase.Importe_Retencion = Decimal.Parse(txt_RetencionFacturaCorteSalida.Text, style, provider);
            if (chk_IVACorteSalida.Checked)
            {
                Clase.IVA = 1;
            }
            else
            {
                Clase.IVA = 0;
            }

            Clase.Importe_IVA = Decimal.Parse(txt_IVAFacturaCorteSalida.Text, style, provider);
            if (chk_RetencionFleteCorteSalida.Checked)
            {
                Clase.Retencion_Flete = 1;
            }
            else
            {
                Clase.Retencion_Flete = 0;
            }

            Clase.Importe_Retencion_Flete = Decimal.Parse(txt_RetencionFleteFacturaCorteSalida.Text, style, provider);

            Clase.Total_Factura = Decimal.Parse(txt_TotalFacturaCorteSalida.Text, style, provider);
            DateTime Fecha;


            if (dt_FechaFacturaCorteSalida.EditValue == null)
            {
                Clase.Fecha_Factura = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaFacturaCorteSalida.Text.Trim());
                Clase.Fecha_Factura = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (dt_FechaPagoCorteSalida.EditValue == null)
            {
                Clase.Fecha_Pago = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaPagoCorteSalida.Text.Trim());
                Clase.Fecha_Pago = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (dt_FechaProgramaCorteSalida.EditValue == null)
            {
                Clase.Fecha_Programacion = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaProgramaCorteSalida.Text.Trim());
                Clase.Fecha_Programacion = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (opt_TipoFacturaCorteSalida.SelectedIndex == 0)
            {
                Clase.Diferido = 1;
            }
            else
            {
                Clase.Diferido = 0;
            }
            Clase.UUID = txt_UUID_Salida.Text;
            Clase.MetodoPago = txt_MetodoPago_Salida.Text;
            Clase.SubTotalXML = Decimal.Parse(txt_SubTotal_Salida.Text, style, provider);
            Clase.TotalXML = Decimal.Parse(txt_Total_Salida.Text, style, provider);
            Clase.Usuario = UsuariosLogin;
            //if (ArchivoPDFGlobalCorteSalida != null || ArchivoXMLGlobalCorteSalida != null)
            //{
            Clase.MtdInsertarCosechaArchivoPDFXML();
            if (!Clase.Exito)
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
            //}
            if (noentroXML)
            {
                fsXML.Close();
            }
            if (noentroPDF)
            {
                fsPDF.Close();
            }
        }
        private void FacturaAcarreo()
        {
            Byte[] ArchivoPDF = null;
            Byte[] ArchivoXML = null;

            FileStream fsPDF = null;
            FileStream fsXML = null;

            Boolean noentroPDF = true, noentroXML = true;


            if (txt_RutaPDFAcarreo.Text.Length > 0)
            {
                //txtNombreArchivoPDF.Text = result2;
                //string ar = OpenDialog.FileName;
                fsPDF = new FileStream(txt_RutaPDFAcarreo.Text, FileMode.Open, FileAccess.Read);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoPDF = new byte[fsPDF.Length];
                //Y guardamos los datos en el array data
                fsPDF.Read(ArchivoPDF, 0, (int)fsPDF.Length);
            }
            else
            {
                ArchivoPDF = ArchivoPDFGlobalAcarreo;
                noentroPDF = false;
            }
            if (txt_RutaXMLAcarreo.Text.Length > 0)
            {
                fsXML = new FileStream(txt_RutaXMLAcarreo.Text, FileMode.Open);
                //Creamos un array de bytes para almacenar los datos leídos por fs.
                ArchivoXML = new byte[fsXML.Length];
                //Y guardamos los datos en el array data
                fsXML.Read(ArchivoXML, 0, Convert.ToInt32(fsXML.Length));
            }
            else
            {
                ArchivoXML = ArchivoXMLGlobalAcarreo;
                noentroXML = false;
            }

            CLS_Cosecha_Facturas Clase = new CLS_Cosecha_Facturas();
            Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
            Clase.Id_Archivo = 6;
            Clase.RazonSocial = txtRazonSAcarreo.Text;
            if (ArchivoPDF != null)
            {
                Clase.FacturaPDF = ArchivoPDF;
            }
            else
            {
                Clase.FacturaPDF = Encoding.UTF8.GetBytes("");
            }

            if (ArchivoXML != null)
            {
                Clase.FacturaXML = ArchivoXML;
            }
            else
            {
                Clase.FacturaXML = Encoding.UTF8.GetBytes("");
            }
            Clase.FolioFactura = txt_FolioFacturaAcarreo.Text.Trim();
            if (cmb_MonedaAcarreo.Text.Equals("Pesos"))
            {
                Clase.Moneda = "P";
            }
            else
            {
                Clase.Moneda = "D";
            }
            Clase.Importe_Factura = Decimal.Parse(txt_ImporteFacturaAcarreo.Text, style, provider);
            if (chk_PagadaAcarreo.Checked)
            {
                Clase.Pagada = 1;
            }
            else
            {
                Clase.Pagada = 0;
            }
            if (chk_RetencionAcarreo.Checked)
            {
                Clase.Retencion = 1;
            }
            else
            {
                Clase.Retencion = 0;
            }

            Clase.Importe_Retencion = Decimal.Parse(txt_RetencionFacturaAcarreo.Text, style, provider);
            if (chk_RetencionFleteAcarreo.Checked)
            {
                Clase.Retencion_Flete = 1;
            }
            else
            {
                Clase.Retencion_Flete = 0;
            }

            Clase.Importe_Retencion_Flete = Decimal.Parse(txt_RetencionFleteFacturaAcarreo.Text, style, provider);

            if (chk_IVAAcarreo.Checked)
            {
                Clase.IVA = 1;
            }
            else
            {
                Clase.IVA = 0;
            }

            Clase.Importe_IVA = Decimal.Parse(txt_IVAFacturaAcarreo.Text, style, provider);
            Clase.Total_Factura = Decimal.Parse(txt_TotalFacturaAcarreo.Text, style, provider);
            DateTime Fecha;


            if (dt_FechaFacturaAcarreo.EditValue == null)
            {
                Clase.Fecha_Factura = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaFacturaAcarreo.Text.Trim());
                Clase.Fecha_Factura = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (dt_FechaPagoAcarreo.EditValue == null)
            {
                Clase.Fecha_Pago = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaPagoAcarreo.Text.Trim());
                Clase.Fecha_Pago = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (dt_FechaProgramaAcarreo.EditValue == null)
            {
                Clase.Fecha_Programacion = String.Empty;
            }
            else
            {
                Fecha = Convert.ToDateTime(dt_FechaProgramaAcarreo.Text.Trim());
                Clase.Fecha_Programacion = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            }
            if (opt_TipoFacturaAcarreo.SelectedIndex == 0)
            {
                Clase.Diferido = 1;
            }
            else
            {
                Clase.Diferido = 0;
            }
            Clase.UUID = txt_UUID_Acarreo.Text;
            Clase.MetodoPago = txt_MetodoPago_Acarreo.Text;
            Clase.SubTotalXML = Decimal.Parse(txt_SubTotal_Acarreo.Text, style, provider);
            Clase.TotalXML = Decimal.Parse(txt_Total_Acarreo.Text, style, provider);
            Clase.Usuario = UsuariosLogin;
            //if (ArchivoPDFGlobalAcarreo != null || ArchivoXMLGlobalAcarreo != null)
            //{
            Clase.MtdInsertarCosechaArchivoPDFXML();
            if (!Clase.Exito)
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
            //}
            if (noentroXML)
            {
                fsXML.Close();
            }
            if (noentroPDF)
            {
                fsPDF.Close();
            }
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
            ins.KilosCortados = Convert.ToDecimal(txt_KilosCortados.EditValue);
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
            ins.KilosBasculaExterna = Convert.ToDecimal(txt_KilosBasculaE.EditValue);
            if (chk_kgProductor.Checked == true)
            {
                ins.TomarkgProductor = 1;
            }
            else
            {
                ins.TomarkgProductor = 0;
            }
            if (chk_kgCorte.Checked == true)
            {
                ins.TomarkgenCorte = 1;
            }
            else
            {
                ins.TomarkgenCorte = 0;
            }
            ins.KilosDiferencia = Convert.ToDecimal(txt_KilosDiferencia.EditValue);
            ins.Ajuste = Convert.ToDecimal(txt_KilosAjuste.EditValue);
            ins.KilosST = Convert.ToDecimal(txt_kilosST.EditValue);
            ins.KilosProductor = Convert.ToDecimal(txt_KilosProductor.EditValue);
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
            Boolean noentroPDFContratoComercializadora = true;

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
            ins.Productor = txt_Productor.Text;
            ins.KilosAjustados = Convert.ToDecimal(txt_KilosAjustados.EditValue);
            ins.KilosMuestra = Convert.ToDecimal(txt_KilosMuestra.EditValue);
            ins.KilosaPagar = Convert.ToDecimal(txt_kilos_Totales.EditValue);
            ins.PreciokgInicial = Decimal.Parse(txt_KiloPrecioInicial.Text, style, provider);
            ins.Preciokg = Decimal.Parse(txt_KiloPrecio.Text, style, provider);
            ins.TotalaPagar = Decimal.Parse(txt_TotalaPagar.Text, style, provider);
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
            if (chk_PrecioPorkg.Checked == true)
            {
                ins.PrecioporKiloB = 1;
            }
            else
            {
                ins.PrecioporKiloB = 0;
            }
            ins.Preciodecosecha = Decimal.Parse(txt_PrecioTCorte.Text, style, provider);
            ins.PrecioporDia = Decimal.Parse(txt_PrecioDiaCorte.Text, style, provider);
            ins.SalidaenFalso = Decimal.Parse(txt_PrecioSalidaFCorte.Text, style, provider);
            if (chk_SalidaFalso.Checked == true)
            {
                ins.SalidaenFalsoB = 1;
            }
            else
            {
                ins.SalidaenFalsoB = 0;
            }
            ins.CuadrillaApoyo = Decimal.Parse(txt_PrecioCuadrillaCorte.Text, style, provider);
            if (chk_CuadrillaApoyo.Checked == true)
            {
                ins.CuadrillaApoyoB = 1;
            }
            else
            {
                ins.CuadrillaApoyoB = 0;
            }
            ins.Margen5p = Convert.ToDecimal(txt_Margen5.EditValue);
            ins.KilosnoSolicitados = Convert.ToDecimal(txt_kgNoSolicitados.EditValue);
            ins.KilosaAjustar = Convert.ToDecimal(txt_KilosARestar.EditValue);
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
            try
            {
                ins.Id_Camion = cmb_Camiones.EditValue.ToString();
            }
            catch (Exception)
            {
                ins.Id_Camion = string.Empty;
            }
            try
            {
                ins.Nombre_Camion = cmb_Camiones.Text.ToString();
            }
            catch (Exception)
            {
                ins.Nombre_Camion = string.Empty;
            }
            ins.Placas = txtPlacasCamion.Text;
            try
            {
                ins.Id_TipoCamion = txt_TipoCamion.Tag.ToString();
            }
            catch (Exception)
            {
                ins.Id_TipoCamion = String.Empty;
            }
            try
            {
                ins.Nombre_TipoCamion = txt_TipoCamion.Text;
            }
            catch (Exception)
            {
                ins.Nombre_TipoCamion = String.Empty;
            }
            try
            {
                ins.Id_Chofer = cmb_Choferes.EditValue.ToString();
            }
            catch (Exception)
            {
                ins.Id_Chofer = string.Empty;
            }
            try
            {
                ins.Nombre_Chofer = cmb_Choferes.EditValue.ToString();
            }
            catch (Exception)
            {
                ins.Nombre_Chofer = string.Empty;
            }

            ins.CajasProgramadas = Convert.ToDecimal(txt_CajasProgramadasA.EditValue);
            ins.CajasCortadasA = Convert.ToDecimal(txt_Cajas_CortadasA.EditValue);
            ins.CostoServicio = Decimal.Parse(txt_CostoServicio.Text, style, provider);
            if (chk_ServicioForaneo.Checked == true)
            {
                ins.CostoServicioB = 1;
            }
            else
            {
                ins.CostoServicioB = 0;
            }

            ins.CajasExtras = Convert.ToDecimal(txt_CajasExtras.EditValue);
            ins.CostoCajasExtras = Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider);
            ins.CargosExtras = Decimal.Parse(txt_CargosExtra.Text, style, provider);
            ins.Descuentos = Decimal.Parse(txt_Descuentos.Text, style, provider);
            ins.TotalAcarreo = Decimal.Parse(txt_TotalAcarreo.Text, style, provider);
            ins.Observaciones = txt_ObservacionesAcarreo.Text;
            ins.Usuario = UsuariosLogin;
            ins.MtdInsertarAcarreo();
            if (!ins.Exito)
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }

        private void btn_UpPDFCorteKilos_Click(object sender, EventArgs e)
        {
            OpenDialog.FileName = String.Empty;
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                txt_RutaPDFCorteKilos.Text = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }

        private void btn_UpPDFCorteDia_Click(object sender, EventArgs e)
        {
            OpenDialog.FileName = String.Empty;
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                txt_RutaPDFCorteDia.Text = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }

        private void btn_UpPDFCorteApoyo_Click(object sender, EventArgs e)
        {
            OpenDialog.FileName = String.Empty;
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                txt_RutaPDFCorteApoyo.Text = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }

        private void btn_UpPDFCorteSalida_Click(object sender, EventArgs e)
        {
            OpenDialog.FileName = String.Empty;
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                txt_RutaPDFCorteSalida.Text = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }

        private void btn_UpPDFAcarreo_Click(object sender, EventArgs e)
        {
            if (txt_IdCosecha.Text != String.Empty)
            {
                OpenDialog.FileName = String.Empty;
                DialogResult result = FileDialogPDF();
                if (result == DialogResult.OK)
                {
                    txt_RutaPDFAcarreo.Text = OpenDialog.FileName;
                    GuardarRuta(OpenDialog.FileName);
                    
                }
                OpenDialog.Dispose();
            }
            else
            {
                XtraMessageBox.Show("No se ha guardado o definido un folio de cosecha");
            }
        }

        private void btn_UpXMLCorteKilos_Click(object sender, EventArgs e)
        {
            if (txt_IdCosecha.Text != String.Empty)
            {
                OpenDialog.FileName = String.Empty;
                DialogResult result = FileDialogXML();
                if (result == DialogResult.OK)
                {
                    txt_RutaXMLCorteKilos.Text = OpenDialog.FileName;
                    GuardarRuta(OpenDialog.FileName);
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(OpenDialog.FileName);
                        XmlNode nodoComprobante = doc.GetElementsByTagName("cfdi:Comprobante").Item(0);
                        txt_MetodoPago_Kilos.Text = nodoComprobante.Attributes["MetodoPago"].Value;
                        dt_FechaFacturaCorteKilos.DateTime = Convert.ToDateTime(nodoComprobante.Attributes["Fecha"].Value);
                        txt_FolioFacturaCorteKilos.Text = nodoComprobante.Attributes["Folio"].Value; ;
                        txt_SubTotal_Kilos.Text = nodoComprobante.Attributes["SubTotal"].Value;
                        txt_Total_Kilos.Text = nodoComprobante.Attributes["Total"].Value;
                        XmlNode nodoComplemento = doc.GetElementsByTagName("tfd:TimbreFiscalDigital").Item(0);
                        txt_UUID_Kilos.Text = nodoComplemento.Attributes["UUID"].Value;
                        XmlNode nodoEmisor = doc.GetElementsByTagName("cfdi:Emisor").Item(0);
                        txtRazonSCorteKilos.Text = nodoEmisor.Attributes["Nombre"].Value;
                    }
                    catch
                    {
                        txt_RutaXMLProductor.Text = String.Empty;
                        XtraMessageBox.Show("No es un Archivo CFDI Valido favor de verificarlo");

                    }
                }
                else
                {
                    txt_RutaXMLCorteKilos.Text = String.Empty;
                }
                OpenDialog.Dispose();
            }
            else
            {
                XtraMessageBox.Show("No se ha guardado o definido un folio de cosecha");
            }
        }

        private void btn_UpXMLCorteDia_Click(object sender, EventArgs e)
        {
            if (txt_IdCosecha.Text != String.Empty)
            {
                OpenDialog.FileName = String.Empty;
                DialogResult result = FileDialogXML();
                if (result == DialogResult.OK)
                {
                    txt_RutaXMLCorteDia.Text = OpenDialog.FileName;
                    GuardarRuta(OpenDialog.FileName);
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(OpenDialog.FileName);
                        XmlNode nodoComprobante = doc.GetElementsByTagName("cfdi:Comprobante").Item(0);
                        txt_MetodoPago_Dia.Text = nodoComprobante.Attributes["MetodoPago"].Value;
                        dt_FechaFacturaCorteDia.DateTime = Convert.ToDateTime(nodoComprobante.Attributes["Fecha"].Value);
                        txt_FolioFacturaCorteDia.Text = nodoComprobante.Attributes["Folio"].Value; ;
                        txt_SubTotal_Dia.Text = nodoComprobante.Attributes["SubTotal"].Value;
                        txt_Total_Dia.Text = nodoComprobante.Attributes["Total"].Value;
                        XmlNode nodoComplemento = doc.GetElementsByTagName("tfd:TimbreFiscalDigital").Item(0);
                        txt_UUID_Dia.Text = nodoComplemento.Attributes["UUID"].Value;
                        XmlNode nodoEmisor = doc.GetElementsByTagName("cfdi:Emisor").Item(0);
                        txtRazonSCorteDia.Text = nodoEmisor.Attributes["Nombre"].Value;
                    }
                    catch
                    {
                        txt_RutaXMLProductor.Text = String.Empty;
                        XtraMessageBox.Show("No es un Archivo CFDI Valido favor de verificarlo");

                    }
                }
                OpenDialog.Dispose();
            }
            else
            {
                XtraMessageBox.Show("No se ha guardado o definido un folio de cosecha");
            }
        }

        private void btn_UpXMLCorteApoyo_Click(object sender, EventArgs e)
        {
            if (txt_IdCosecha.Text != String.Empty)
            {
                OpenDialog.FileName = String.Empty;
                DialogResult result = FileDialogXML();
                if (result == DialogResult.OK)
                {
                    txt_RutaXMLCorteApoyo.Text = OpenDialog.FileName;
                    GuardarRuta(OpenDialog.FileName);
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(OpenDialog.FileName);
                        XmlNode nodoComprobante = doc.GetElementsByTagName("cfdi:Comprobante").Item(0);
                        txt_MetodoPago_Apoyo.Text = nodoComprobante.Attributes["MetodoPago"].Value;
                        dt_FechaFacturaCorteApoyo.DateTime = Convert.ToDateTime(nodoComprobante.Attributes["Fecha"].Value);
                        txt_FolioFacturaCorteApoyo.Text = nodoComprobante.Attributes["Folio"].Value; ;
                        txt_SubTotal_Apoyo.Text = nodoComprobante.Attributes["SubTotal"].Value;
                        txt_Total_Apoyo.Text = nodoComprobante.Attributes["Total"].Value;
                        XmlNode nodoComplemento = doc.GetElementsByTagName("tfd:TimbreFiscalDigital").Item(0);
                        txt_UUID_Apoyo.Text = nodoComplemento.Attributes["UUID"].Value;
                        XmlNode nodoEmisor = doc.GetElementsByTagName("cfdi:Emisor").Item(0);
                        txtRazonSCorteApoyo.Text = nodoEmisor.Attributes["Nombre"].Value;
                    }
                    catch
                    {
                        txt_RutaXMLProductor.Text = String.Empty;
                        XtraMessageBox.Show("No es un Archivo CFDI Valido favor de verificarlo");

                    }
                }
                OpenDialog?.Dispose();
            }
            else
            {
                XtraMessageBox.Show("No se ha guardado o definido un folio de cosecha");
            }
        }

        private void btn_UpXMLCorteSalida_Click(object sender, EventArgs e)
        {
            if (txt_IdCosecha.Text != String.Empty)
            {
                OpenDialog.FileName = String.Empty;
                DialogResult result = FileDialogXML();
                if (result == DialogResult.OK)
                {
                    txt_RutaXMLCorteSalida.Text = OpenDialog.FileName;
                    GuardarRuta(OpenDialog.FileName);
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(OpenDialog.FileName);
                        XmlNode nodoComprobante = doc.GetElementsByTagName("cfdi:Comprobante").Item(0);
                        txt_MetodoPago_Salida.Text = nodoComprobante.Attributes["MetodoPago"].Value;
                        dt_FechaFacturaCorteSalida.DateTime = Convert.ToDateTime(nodoComprobante.Attributes["Fecha"].Value);
                        txt_FolioFacturaCorteSalida.Text = nodoComprobante.Attributes["Folio"].Value; ;
                        txt_SubTotal_Salida.Text = nodoComprobante.Attributes["SubTotal"].Value;
                        txt_Total_Salida.Text = nodoComprobante.Attributes["Total"].Value;
                        XmlNode nodoComplemento = doc.GetElementsByTagName("tfd:TimbreFiscalDigital").Item(0);
                        txt_UUID_Salida.Text = nodoComplemento.Attributes["UUID"].Value;
                        XmlNode nodoEmisor = doc.GetElementsByTagName("cfdi:Emisor").Item(0);
                        txtRazonSCorteSalida.Text = nodoEmisor.Attributes["Nombre"].Value;
                    }
                    catch
                    {
                        txt_RutaXMLProductor.Text = String.Empty;
                        XtraMessageBox.Show("No es un Archivo CFDI Valido favor de verificarlo");

                    }
                }
                OpenDialog?.Dispose();
            }
            else
            {
                XtraMessageBox.Show("No se ha guardado o definido un folio de cosecha");
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
                    txt_SAGARPA.Text= ins.Datos.Rows[0]["SAGARPA"].ToString();
                    txt_Estado_Huerta.Text = ins.Datos.Rows[0]["Estado_Huerta"].ToString();
                    BarHuerta.Caption = "Huerta: " + ins.Datos.Rows[0]["Huerta"].ToString();
                    txt_Acopiador.Text = ins.Datos.Rows[0]["Acopiador"].ToString();
                    txt_Cajas_Programa.EditValue = ins.Datos.Rows[0]["ProgramaCajas"].ToString();
                    txt_TipoCorte.Text = ins.Datos.Rows[0]["TipoCorte"].ToString();
                    txtTipoCorteEC.Text = ins.Datos.Rows[0]["TipoCorte"].ToString();
                    if(ins.Datos.Rows[0]["Autorizado_USA"].ToString()=="True")
                    {
                        chk_Autorizado_USA.Checked = true;
                    }
                    else
                    {
                        chk_Autorizado_USA.Checked = false;
                    }
                    txt_Poliza_ase.Text= ins.Datos.Rows[0]["Poliza_aseguradora"].ToString();
                    txt_Nombre_ase.Text= ins.Datos.Rows[0]["Aseguradora"].ToString();
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
                    txt_KilosCortados.EditValue = ins.Datos.Rows[0]["KilosCortados"].ToString();
                    txt_KilosPromedio.EditValue = ins.Datos.Rows[0]["KilosPromedio"].ToString();
                    txt_TipoCultivo.Text = ins.Datos.Rows[0]["TipoCultivo"].ToString();
                    dt_FechaRecepcion.DateTime = Convert.ToDateTime(ins.Datos.Rows[0]["RecepcionFecha"].ToString());
                    txt_EmpresaBascula.Tag = ins.Datos.Rows[0]["Id_EmpresaBascula"].ToString();
                    txt_EmpresaBascula.Text = ins.Datos.Rows[0]["Nombre_EmpresaBascula"].ToString();
                    txt_KilosBasculaE.EditValue = ins.Datos.Rows[0]["KilosBasculaExterna"].ToString();
                    txt_KilosDiferencia.EditValue = ins.Datos.Rows[0]["KilosDiferencia"].ToString();
                    txt_KilosAjuste.EditValue = ins.Datos.Rows[0]["Ajuste"].ToString();
                    txt_kilosST.EditValue = ins.Datos.Rows[0]["KilosST"].ToString();
                    txt_KilosProductor.EditValue = ins.Datos.Rows[0]["KilosProductor"].ToString();
                    if (ins.Datos.Rows[0]["TomarkgProductor"].ToString() == "True")
                    {
                        chk_kgProductor.Checked = true;

                    }
                    else
                    {
                        chk_kgProductor.Checked = false;
                    }
                    if (ins.Datos.Rows[0]["TomarkgenCorte"].ToString() == "True")
                    {
                        chk_kgCorte.Checked = true;

                    }
                    else
                    {
                        chk_kgCorte.Checked = false;
                    }
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
                        ArchivoPDFGlobalContratoComercializadora=null;
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
                    txt_Productor.Text = ins.Datos.Rows[0]["Productor"].ToString();
                    BarProductor.Caption = "Productor: " + ins.Datos.Rows[0]["Productor"].ToString();
                    txt_KilosAjustados.EditValue = ins.Datos.Rows[0]["KilosAjustados"].ToString();
                    txt_KilosMuestra.EditValue = ins.Datos.Rows[0]["KilosMuestra"].ToString();
                    txt_kilos_Totales.EditValue = ins.Datos.Rows[0]["KilosaPagar"].ToString();
                    txt_KiloPrecioInicial.EditValue = ins.Datos.Rows[0]["PreciokgInicial"].ToString();
                    txt_KiloPrecio.EditValue = ins.Datos.Rows[0]["Preciokg"].ToString();
                    txt_TotalaPagar.EditValue = ins.Datos.Rows[0]["TotalaPagar"].ToString();
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
                    if (ins.Datos.Rows[0]["PrecioporKiloB"].ToString() == "True")
                    {
                        chk_PrecioPorkg.Checked = true;
                    }
                    else
                    {
                        chk_PrecioPorkg.Checked = false;
                    }
                    txt_PrecioTCorte.EditValue = ins.Datos.Rows[0]["Preciodecosecha"].ToString();
                    txt_PrecioDiaCorte.EditValue = ins.Datos.Rows[0]["PrecioporDia"].ToString();
                    txt_PrecioSalidaFCorte.EditValue = ins.Datos.Rows[0]["SalidaenFalso"].ToString();
                    if (ins.Datos.Rows[0]["SalidaenFalsoB"].ToString() == "True")
                    {
                        chk_SalidaFalso.Checked = true;
                    }
                    else
                    {
                        chk_SalidaFalso.Checked = false;
                    }
                    txt_PrecioCuadrillaCorte.EditValue = ins.Datos.Rows[0]["CuadrillaApoyo"].ToString();
                    if (ins.Datos.Rows[0]["CuadrillaApoyoB"].ToString() == "True")
                    {
                        chk_CuadrillaApoyo.Checked = true;

                    }
                    else
                    {
                        chk_CuadrillaApoyo.Checked = false;
                    }
                    txt_Margen5.EditValue = ins.Datos.Rows[0]["Margen5p"].ToString();
                    txt_kgNoSolicitados.EditValue = ins.Datos.Rows[0]["KilosnoSolicitados"].ToString();
                    txt_KilosARestar.EditValue = ins.Datos.Rows[0]["KilosaAjustar"].ToString();
                    txt_CajasCortadasCorte.EditValue = ins.Datos.Rows[0]["CajasCortadas"].ToString();
                    txt_PagoTotalCorte.EditValue = ins.Datos.Rows[0]["TotalaPagar"].ToString();
                    txt_ObservacionesCorte.Text = ins.Datos.Rows[0]["Observaciones"].ToString();
                    Bloquear_Corte(!Convert.ToBoolean(ins.Datos.Rows[0]["Cerrado"]));
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
                    txt_EmpresaAcarreo.Tag = ins.Datos.Rows[0]["Id_EmpresaAcarreo"].ToString();
                    txt_EmpresaAcarreo.Text = ins.Datos.Rows[0]["Nombre_EmpresaAcarreo"].ToString();
                    CargarCamiones(ins.Datos.Rows[0]["Id_Camion"].ToString());
                    CargarChoferes(ins.Datos.Rows[0]["Id_Chofer"].ToString());
                    txtPlacasCamion.Text = ins.Datos.Rows[0]["Placas"].ToString();
                    txt_TipoCamion.Text= ins.Datos.Rows[0]["Nombre_TipoCamion"].ToString();
                    txt_TipoCamion.Tag = ins.Datos.Rows[0]["Id_TipoCamion"].ToString();
                    CargarServiciosAcarreo();
                    CargarCostosServicios();
                    txt_CajasProgramadasA.EditValue = ins.Datos.Rows[0]["CajasProgramadas"].ToString();
                    txt_Cajas_CortadasA.EditValue = ins.Datos.Rows[0]["CajasCortadas"].ToString();
                    txt_CostoServicio.EditValue = ins.Datos.Rows[0]["CostoServicio"].ToString();
                    if (ins.Datos.Rows[0]["CostoServicioB"].ToString() == "True")
                    {
                        chk_ServicioForaneo.Checked = true;
                    }
                    else
                    {
                        chk_ServicioForaneo.Checked = false;
                    }

                    txt_CajasExtras.EditValue = ins.Datos.Rows[0]["CajasExtras"].ToString();
                    txt_CostoxCajaExtra.EditValue = ins.Datos.Rows[0]["CostoCajasExtras"].ToString();
                    txt_CargosExtra.EditValue = ins.Datos.Rows[0]["CargosExtras"].ToString();
                    txt_Descuentos.EditValue = ins.Datos.Rows[0]["Descuentos"].ToString();
                    txt_TotalAcarreo.EditValue = ins.Datos.Rows[0]["TotalAcarreo"].ToString();
                    txt_ObservacionesAcarreo.Text = ins.Datos.Rows[0]["Observaciones"].ToString();
                    Bloquear_Acarreo(!Convert.ToBoolean(ins.Datos.Rows[0]["Cerrado"]));
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }

        }
        void SelectExpedientesProductor()
        {
            CLS_Cosecha_Expedientes ins = new CLS_Cosecha_Expedientes();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.MtdSeleccionarCosechaArchivoPDFXML();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    ArchivoPDFGlobalTarjetaApeam = (byte[])ins.Datos.Rows[0]["TarjetaApeam"];
                    ArchivoPDFGlobalIdentificacion_INE_IFE = (byte[])ins.Datos.Rows[0]["Identificacion_INE_IFE"];
                    ArchivoPDFGlobalOpinion_Cumplimiento = (byte[])ins.Datos.Rows[0]["Opinion_Cumplimiento"];
                    ArchivoPDFGlobalConstancia_de_Situacion_Fiscal = (byte[])ins.Datos.Rows[0]["Constancia_de_Situacion_Fiscal"];
                    ArchivoPDFGlobalClave_Interbancaria = (byte[])ins.Datos.Rows[0]["Clave_Interbancaria"];
                    ArchivoPDFGlobalContrato_entre_Terceros = (byte[])ins.Datos.Rows[0]["Contrato_entre_Terceros"];
                    ArchivoPDFGlobalContrato_GEST = (byte[])ins.Datos.Rows[0]["Contrato_GEST"];
                    
                    if (ArchivoPDFGlobalTarjetaApeam.Length > 0)
                    {
                        btn_ViewPDFTarjetaAPEAM.Enabled = true;
                        btn_DelTarjetaAPEAM.Enabled = true;
                        dt_FechaTarjetaAPEAM.EditValue =Convert.ToDateTime(ins.Datos.Rows[0]["d_TarjetaApeam"].ToString());
                    }
                    else
                    {
                        btn_ViewPDFTarjetaAPEAM.Enabled = false;
                        btn_DelTarjetaAPEAM.Enabled = false;
                        dt_FechaTarjetaAPEAM.EditValue = DateTime.Now;
                    }

                    if (ArchivoPDFGlobalIdentificacion_INE_IFE.Length > 0)
                    {
                        btn_ViewPDFIdentificacion_IFE_INE.Enabled = true;
                        btn_DelIdentificacion_IFE_INE.Enabled=true;
                        dt_FechaIdentificacion_IFE_INE.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["d_Identificacion_INE_IFE"].ToString());
                    }
                    else
                    {
                        btn_ViewPDFIdentificacion_IFE_INE.Enabled = false;
                        btn_DelIdentificacion_IFE_INE.Enabled = false;
                        dt_FechaIdentificacion_IFE_INE.EditValue = DateTime.Now;
                    }

                    if (ArchivoPDFGlobalOpinion_Cumplimiento.Length > 0)
                    {
                        btn_ViewPDFOpinionCumplimiento.Enabled = true;
                        btn_DelOpinionCumplimiento.Enabled=true;
                        dt_FechaOPinionCumplimiento.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["d_Opinion_Cumplimiento"].ToString());
                    }
                    else
                    {
                        btn_ViewPDFOpinionCumplimiento.Enabled = false;
                        btn_DelOpinionCumplimiento.Enabled = false;
                        dt_FechaOPinionCumplimiento.EditValue = DateTime.Now;
                    }

                    if (ArchivoPDFGlobalConstancia_de_Situacion_Fiscal.Length > 0)
                    {
                        btn_ViewPDFConstanciaSituacion.Enabled = true;
                        btn_DelConstanciaSituacion.Enabled=true;
                        dt_FechaConstanciaSituacion.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["d_Constancia_de_Situacion_Fiscal"].ToString());
                    }
                    else
                    {
                        btn_ViewPDFConstanciaSituacion.Enabled = false;
                        btn_DelConstanciaSituacion.Enabled = false;
                        dt_FechaConstanciaSituacion.EditValue = DateTime.Now;
                    }

                    if (ArchivoPDFGlobalClave_Interbancaria.Length > 0)
                    {
                        btn_ViewPDFClaveInterbancaria.Enabled = true;
                        btn_DelClaveInterbancaria.Enabled = true;
                        dt_FechaClaveInterbancaria.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["d_Clave_Interbancaria"].ToString());
                    }
                    else
                    {
                        btn_ViewPDFClaveInterbancaria.Enabled = false;
                        btn_DelClaveInterbancaria.Enabled = false;
                        dt_FechaClaveInterbancaria.EditValue = DateTime.Now;
                    }

                    if (ArchivoPDFGlobalContrato_entre_Terceros.Length > 0)
                    {
                        btn_ViewPDFContratoTerceros.Enabled = true;
                        btn_DelContratoTerceros.Enabled = true;
                        dt_FechaContratoTerceros.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["d_Contrato_entre_Terceros"].ToString());
                    }
                    else
                    {
                        btn_ViewPDFContratoTerceros.Enabled = false;
                        btn_DelContratoTerceros.Enabled = false;
                        dt_FechaContratoTerceros.EditValue = DateTime.Now;
                    }

                    if (ArchivoPDFGlobalContrato_GEST.Length > 0)
                    {
                        btn_ViewPDFContratoGEST.Enabled = true;
                        btn_DelContratoGEST.Enabled= true;
                        dt_FechaContratoGEST.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["d_Contrato_GEST"].ToString());
                    }
                    else
                    {
                        btn_ViewPDFContratoGEST.Enabled = false;
                        btn_DelContratoGEST.Enabled = false;
                        dt_FechaContratoGEST.EditValue = DateTime.Now;
                    }
                }
                else
                {
                    btn_ViewPDFTarjetaAPEAM.Enabled = false;
                    btn_DelTarjetaAPEAM.Enabled = false;
                    dt_FechaTarjetaAPEAM.EditValue = DateTime.Now;
                    btn_ViewPDFIdentificacion_IFE_INE.Enabled = false;
                    btn_DelIdentificacion_IFE_INE.Enabled = false;
                    dt_FechaIdentificacion_IFE_INE.EditValue = DateTime.Now;
                    btn_ViewPDFOpinionCumplimiento.Enabled = false;
                    btn_DelOpinionCumplimiento.Enabled = false;
                    dt_FechaOPinionCumplimiento.EditValue = DateTime.Now;
                    btn_ViewPDFConstanciaSituacion.Enabled = false;
                    btn_DelConstanciaSituacion.Enabled = false;
                    dt_FechaConstanciaSituacion.EditValue = DateTime.Now;
                    btn_ViewPDFClaveInterbancaria.Enabled = false;
                    btn_DelClaveInterbancaria.Enabled = false;
                    dt_FechaClaveInterbancaria.EditValue = DateTime.Now;
                    btn_ViewPDFContratoTerceros.Enabled = false;
                    btn_DelContratoTerceros.Enabled = false;
                    dt_FechaContratoTerceros.EditValue = DateTime.Now;
                    btn_ViewPDFContratoGEST.Enabled = false;
                    btn_DelContratoGEST.Enabled = false;
                    dt_FechaContratoGEST.EditValue = DateTime.Now;
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        void CargarREP()
        {
            CLS_Cosecha_Facturas sel = new CLS_Cosecha_Facturas();
            sel.Id_Cosecha = txt_IdCosecha.Text;
            sel.MtdSeleccionarCosechaArchivoREP_PDFXML();
            if(sel.Exito)
            {
                dtgFacturasREP.DataSource = sel.Datos;
            }

        }
        void SelectFacturaProductor()
        {
            CLS_Cosecha_Facturas ins = new CLS_Cosecha_Facturas();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.Id_Archivo = 1;
            ins.MtdSeleccionarCosechaArchivoPDFXML();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    ArchivoPDFGlobalProductor = (byte[])ins.Datos.Rows[0]["FacturaPDF"];
                    ArchivoXMLGlobalProductor = (byte[])ins.Datos.Rows[0]["FacturaXML"];
                    if (ArchivoPDFGlobalProductor.Length > 0)
                    {
                        btn_ViewPDFProductor.Enabled = true;
                    }
                    else
                    {
                        btn_ViewPDFProductor.Enabled = false;
                    }
                    if (ArchivoXMLGlobalProductor.Length > 0)
                    {
                        btn_ViewXMLProductor.Enabled = true;
                    }
                    else
                    {
                        btn_ViewXMLProductor.Enabled = false;
                    }
                    if (ArchivoPDFGlobalProductor.Length > 0 || ArchivoXMLGlobalProductor.Length > 0)
                    {
                        btn_DelFacturaProductor.Enabled = true;
                    }
                    else
                    {
                        btn_DelFacturaProductor.Enabled = false;
                    }
                    txtRazonSProductor.Text = ins.Datos.Rows[0]["RazonSocial"].ToString();
                    txt_FolioFacturaProductor.Text = ins.Datos.Rows[0]["FolioFactura"].ToString();
                    if (ins.Datos.Rows[0]["Moneda"].ToString() == "P")
                    {
                        cmb_MonedaProductor.SelectedIndex = 0;
                    }
                    else
                    {
                        cmb_MonedaProductor.SelectedIndex = 1;
                    }

                    txt_ImporteFacturaProductor.EditValue = ins.Datos.Rows[0]["Importe_Factura"].ToString();

                    if (ins.Datos.Rows[0]["Pagada"].ToString() == "True")
                    {
                        chk_PagadaProductor.Checked = true;
                    }
                    else
                    {
                        chk_PagadaProductor.Checked = false;
                    }
                    if (ins.Datos.Rows[0]["Retencion"].ToString() == "True")
                    {
                        chk_RetencionProductor.Checked = true;
                    }
                    else
                    {
                        chk_RetencionProductor.Checked = false;
                    }
                    txt_RetencionFacturaProductor.EditValue = ins.Datos.Rows[0]["Importe_Retencion"].ToString();
                    if (ins.Datos.Rows[0]["IVA"].ToString() == "True")
                    {
                        chk_IVAProductor.Checked = true;
                    }
                    else
                    {
                        chk_IVAProductor.Checked = false;
                    }
                    txt_IVAFacturaProductor.EditValue = ins.Datos.Rows[0]["Importe_IVA"].ToString();
                    txt_TotalFacturaProductor.EditValue = ins.Datos.Rows[0]["Total_Factura"].ToString();
                    dt_FechaFacturaProductor.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Factura"].ToString());
                    dt_FechaPagoProductor.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Pago"].ToString());
                    dt_FechaProgramaProductor.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Programacion"].ToString());

                    if (ins.Datos.Rows[0]["Diferido"].ToString() == "True")
                    {
                        opt_TipoFacturaProductor.SelectedIndex = 0;
                    }
                    else
                    {
                        opt_TipoFacturaProductor.SelectedIndex = 1;
                    }
                    txt_UUID.EditValue = ins.Datos.Rows[0]["UUID"].ToString();
                    txt_MetodoPago.EditValue = ins.Datos.Rows[0]["MetodoPago"].ToString();
                    txt_SubTotal.EditValue = ins.Datos.Rows[0]["SubTotalXML"].ToString();
                    txt_Total.EditValue = ins.Datos.Rows[0]["TotalXML"].ToString();
                    if(txt_MetodoPago.Text=="PPD")
                    {
                        xtraTabPage4.PageVisible = true;
                        txt_SumaTotal_REP.Visible = true;
                        txt_Salto_REP.Visible = true;
                        labelControl207.Visible = true;
                        labelControl208.Visible = true;
                        CargarREP();
                        CalcularTotalREP();
                    }
                    else
                    {
                        xtraTabPage4.PageVisible = false;
                        txt_SumaTotal_REP.Visible = false;
                        txt_Salto_REP.Visible = false;
                        labelControl207.Visible = false;
                        labelControl208.Visible = false;
                        CargarREP();
                        CalcularTotalREP();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        void SelectFacturaKilos()
        {
            CLS_Cosecha_Facturas ins = new CLS_Cosecha_Facturas();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.Id_Archivo = 2;
            ins.MtdSeleccionarCosechaArchivoPDFXML();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    ArchivoPDFGlobalCorteKilos = (byte[])ins.Datos.Rows[0]["FacturaPDF"];
                    ArchivoXMLGlobalCorteKilos = (byte[])ins.Datos.Rows[0]["FacturaXML"];
                    if (ArchivoPDFGlobalCorteKilos.Length > 0)
                    {
                        btn_ViewPDFCorteKilos.Enabled = true;
                    }
                    else
                    {
                        btn_ViewPDFCorteKilos.Enabled = false;
                    }
                    if (ArchivoXMLGlobalCorteKilos.Length > 0)
                    {
                        btn_ViewXMLCorteKilos.Enabled = true;
                    }
                    else
                    {
                        btn_ViewXMLCorteKilos.Enabled = false;
                    }
                    if (ArchivoPDFGlobalCorteKilos.Length > 0 || ArchivoXMLGlobalCorteKilos.Length > 0)
                    {
                        btn_DelFacturaKilos.Enabled = true;
                    }
                    else
                    {
                        btn_DelFacturaKilos.Enabled = false;
                    }
                    txtRazonSCorteKilos.Text = ins.Datos.Rows[0]["RazonSocial"].ToString();
                    txt_FolioFacturaCorteKilos.Text = ins.Datos.Rows[0]["FolioFactura"].ToString();
                    if (ins.Datos.Rows[0]["Moneda"].ToString() == "P")
                    {
                        cmb_MonedaCorteKilos.SelectedIndex = 0;
                    }
                    else
                    {
                        cmb_MonedaCorteKilos.SelectedIndex = 1;
                    }

                    txt_ImporteFacturaCorteKilos.EditValue = ins.Datos.Rows[0]["Importe_Factura"].ToString();

                    if (ins.Datos.Rows[0]["Pagada"].ToString() == "True")
                    {
                        chk_PagadaCorteKilos.Checked = true;
                    }
                    else
                    {
                        chk_PagadaCorteKilos.Checked = false;
                    }
                    if (ins.Datos.Rows[0]["Retencion"].ToString() == "True")
                    {
                        chk_RetencionCorteKilos.Checked = true;
                    }
                    else
                    {
                        chk_RetencionCorteKilos.Checked = false;
                    }
                    txt_RetencionFacturaCorteKilos.EditValue = ins.Datos.Rows[0]["Importe_Retencion"].ToString();
                    if (ins.Datos.Rows[0]["IVA"].ToString() == "True")
                    {
                        chk_IVACorteKilos.Checked = true;
                    }
                    else
                    {
                        chk_IVACorteKilos.Checked = false;
                    }
                    txt_IVAFacturaCorteKilos.EditValue = ins.Datos.Rows[0]["Importe_IVA"].ToString();
                    txt_TotalFacturaCorteKilos.EditValue = ins.Datos.Rows[0]["Total_Factura"].ToString();
                    dt_FechaFacturaCorteKilos.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Factura"].ToString());
                    dt_FechaPagoCorteKilos.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Pago"].ToString());
                    dt_FechaProgramaCorteKilos.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Programacion"].ToString());

                    if (ins.Datos.Rows[0]["Diferido"].ToString() == "True")
                    {
                        opt_TipoFacturaCorteKilos.SelectedIndex = 0;
                    }
                    else
                    {
                        opt_TipoFacturaCorteKilos.SelectedIndex = 1;
                    }
                    txt_UUID_Kilos.EditValue = ins.Datos.Rows[0]["UUID"].ToString();
                    txt_MetodoPago_Kilos.EditValue = ins.Datos.Rows[0]["MetodoPago"].ToString();
                    txt_SubTotal_Kilos.EditValue = ins.Datos.Rows[0]["SubTotalXML"].ToString();
                    txt_Total_Kilos.EditValue = ins.Datos.Rows[0]["TotalXML"].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        void SelectFacturaDia()
        {
            CLS_Cosecha_Facturas ins = new CLS_Cosecha_Facturas();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.Id_Archivo = 3;
            ins.MtdSeleccionarCosechaArchivoPDFXML();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    ArchivoPDFGlobalCorteDia = (byte[])ins.Datos.Rows[0]["FacturaPDF"];
                    ArchivoXMLGlobalCorteDia = (byte[])ins.Datos.Rows[0]["FacturaXML"];
                    if (ArchivoPDFGlobalCorteDia.Length > 0)
                    {
                        btn_ViewPDFCorteDia.Enabled = true;
                    }
                    else
                    {
                        btn_ViewPDFCorteDia.Enabled = false;
                    }
                    if (ArchivoXMLGlobalCorteDia.Length > 0)
                    {
                        btn_ViewXMLCorteDia.Enabled = true;
                    }
                    else
                    {
                        btn_ViewXMLCorteDia.Enabled = false;
                    }
                    if (ArchivoPDFGlobalCorteDia.Length > 0 || ArchivoXMLGlobalCorteDia.Length > 0)
                    {
                        btn_DelFacturaDia.Enabled = true;
                    }
                    else
                    {
                        btn_DelFacturaDia.Enabled = false;
                    }
                    txtRazonSCorteDia.Text = ins.Datos.Rows[0]["RazonSocial"].ToString();
                    txt_FolioFacturaCorteDia.Text = ins.Datos.Rows[0]["FolioFactura"].ToString();
                    if (ins.Datos.Rows[0]["Moneda"].ToString() == "P")
                    {
                        cmb_MonedaCorteDia.SelectedIndex = 0;
                    }
                    else
                    {
                        cmb_MonedaCorteDia.SelectedIndex = 1;
                    }

                    txt_ImporteFacturaCorteDia.EditValue = ins.Datos.Rows[0]["Importe_Factura"].ToString();

                    if (ins.Datos.Rows[0]["Pagada"].ToString() == "True")
                    {
                        chk_PagadaCorteDia.Checked = true;
                    }
                    else
                    {
                        chk_PagadaCorteDia.Checked = false;
                    }
                    if (ins.Datos.Rows[0]["Retencion"].ToString() == "True")
                    {
                        chk_RetencionCorteDia.Checked = true;
                    }
                    else
                    {
                        chk_RetencionCorteDia.Checked = false;
                    }
                    txt_RetencionFacturaCorteDia.EditValue = ins.Datos.Rows[0]["Importe_Retencion"].ToString();
                    if (ins.Datos.Rows[0]["IVA"].ToString() == "True")
                    {
                        chk_IVACorteDia.Checked = true;
                    }
                    else
                    {
                        chk_IVACorteDia.Checked = false;
                    }
                    txt_IVAFacturaCorteDia.EditValue = ins.Datos.Rows[0]["Importe_IVA"].ToString();
                    txt_TotalFacturaCorteDia.EditValue = ins.Datos.Rows[0]["Total_Factura"].ToString();
                    dt_FechaFacturaCorteDia.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Factura"].ToString());
                    dt_FechaPagoCorteDia.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Pago"].ToString());
                    dt_FechaProgramaCorteDia.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Programacion"].ToString());

                    if (ins.Datos.Rows[0]["Diferido"].ToString() == "True")
                    {
                        opt_TipoFacturaCorteDia.SelectedIndex = 0;
                    }
                    else
                    {
                        opt_TipoFacturaCorteDia.SelectedIndex = 1;
                    }
                    txt_UUID_Dia.EditValue = ins.Datos.Rows[0]["UUID"].ToString();
                    txt_MetodoPago_Dia.EditValue = ins.Datos.Rows[0]["MetodoPago"].ToString();
                    txt_SubTotal_Dia.EditValue = ins.Datos.Rows[0]["SubTotalXML"].ToString();
                    txt_Total_Dia.EditValue = ins.Datos.Rows[0]["TotalXML"].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        void SelectFacturaApoyo()
        {
            CLS_Cosecha_Facturas ins = new CLS_Cosecha_Facturas();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.Id_Archivo = 4;
            ins.MtdSeleccionarCosechaArchivoPDFXML();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    ArchivoPDFGlobalCorteApoyo = (byte[])ins.Datos.Rows[0]["FacturaPDF"];
                    ArchivoXMLGlobalCorteApoyo = (byte[])ins.Datos.Rows[0]["FacturaXML"];
                    if (ArchivoPDFGlobalCorteApoyo.Length > 0)
                    {
                        btn_ViewPDFCorteApoyo.Enabled = true;
                    }
                    else
                    {
                        btn_ViewPDFCorteApoyo.Enabled = false;
                    }
                    if (ArchivoXMLGlobalCorteApoyo.Length > 0)
                    {
                        btn_ViewXMLCorteApoyo.Enabled = true;
                    }
                    else
                    {
                        btn_ViewXMLCorteApoyo.Enabled = false;
                    }
                    if (ArchivoPDFGlobalCorteApoyo.Length > 0 || ArchivoXMLGlobalCorteApoyo.Length > 0)
                    {
                        btn_DelFacturaApoyo.Enabled = true;
                    }
                    else
                    {
                        btn_DelFacturaApoyo.Enabled = false;
                    }
                    txtRazonSCorteApoyo.Text = ins.Datos.Rows[0]["RazonSocial"].ToString();
                    txt_FolioFacturaCorteApoyo.Text = ins.Datos.Rows[0]["FolioFactura"].ToString();
                    if (ins.Datos.Rows[0]["Moneda"].ToString() == "P")
                    {
                        cmb_MonedaCorteApoyo.SelectedIndex = 0;
                    }
                    else
                    {
                        cmb_MonedaCorteApoyo.SelectedIndex = 1;
                    }

                    txt_ImporteFacturaCorteApoyo.EditValue = ins.Datos.Rows[0]["Importe_Factura"].ToString();

                    if (ins.Datos.Rows[0]["Pagada"].ToString() == "True")
                    {
                        chk_PagadaCorteApoyo.Checked = true;
                    }
                    else
                    {
                        chk_PagadaCorteApoyo.Checked = false;
                    }
                    if (ins.Datos.Rows[0]["Retencion"].ToString() == "True")
                    {
                        chk_RetencionCorteApoyo.Checked = true;
                    }
                    else
                    {
                        chk_RetencionCorteApoyo.Checked = false;
                    }
                    txt_RetencionFacturaCorteApoyo.EditValue = ins.Datos.Rows[0]["Importe_Retencion"].ToString();
                    if (ins.Datos.Rows[0]["IVA"].ToString() == "True")
                    {
                        chk_IVACorteApoyo.Checked = true;
                    }
                    else
                    {
                        chk_IVACorteApoyo.Checked = false;
                    }
                    txt_IVAFacturaCorteApoyo.EditValue = ins.Datos.Rows[0]["Importe_IVA"].ToString();
                    txt_TotalFacturaCorteApoyo.EditValue = ins.Datos.Rows[0]["Total_Factura"].ToString();
                    dt_FechaFacturaCorteApoyo.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Factura"].ToString());
                    dt_FechaPagoCorteApoyo.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Pago"].ToString());
                    dt_FechaProgramaCorteApoyo.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Programacion"].ToString());
                    if (ins.Datos.Rows[0]["Diferido"].ToString() == "True")
                    {
                        opt_TipoFacturaCorteApoyo.SelectedIndex = 0;
                    }
                    else
                    {
                        opt_TipoFacturaCorteApoyo.SelectedIndex = 1;
                    }
                    txt_UUID_Apoyo.EditValue = ins.Datos.Rows[0]["UUID"].ToString();
                    txt_MetodoPago_Apoyo.EditValue = ins.Datos.Rows[0]["MetodoPago"].ToString();
                    txt_SubTotal_Apoyo.EditValue = ins.Datos.Rows[0]["SubTotalXML"].ToString();
                    txt_Total_Apoyo.EditValue = ins.Datos.Rows[0]["TotalXML"].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        void SelectFacturaSalida()
        {
            CLS_Cosecha_Facturas ins = new CLS_Cosecha_Facturas();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.Id_Archivo = 5;
            ins.MtdSeleccionarCosechaArchivoPDFXML();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    ArchivoPDFGlobalCorteSalida = (byte[])ins.Datos.Rows[0]["FacturaPDF"];
                    ArchivoXMLGlobalCorteSalida = (byte[])ins.Datos.Rows[0]["FacturaXML"];
                    if (ArchivoPDFGlobalCorteSalida.Length > 0)
                    {
                        btn_ViewPDFCorteSalida.Enabled = true;
                    }
                    else
                    {
                        btn_ViewPDFCorteSalida.Enabled = false;
                    }
                    if (ArchivoXMLGlobalCorteSalida.Length > 0)
                    {
                        btn_ViewXMLCorteSalida.Enabled = true;
                    }
                    else
                    {
                        btn_ViewXMLCorteSalida.Enabled = false;
                    }
                    if (ArchivoPDFGlobalCorteSalida.Length > 0 || ArchivoXMLGlobalCorteSalida.Length > 0)
                    {
                        btn_DelFacturaSalida.Enabled = true;
                    }
                    else
                    {
                        btn_DelFacturaSalida.Enabled = false;
                    }
                    txtRazonSCorteSalida.Text = ins.Datos.Rows[0]["RazonSocial"].ToString();
                    txt_FolioFacturaCorteSalida.Text = ins.Datos.Rows[0]["FolioFactura"].ToString();
                    if (ins.Datos.Rows[0]["Moneda"].ToString() == "P")
                    {
                        cmb_MonedaCorteSalida.SelectedIndex = 0;
                    }
                    else
                    {
                        cmb_MonedaCorteSalida.SelectedIndex = 1;
                    }

                    txt_ImporteFacturaCorteSalida.EditValue = ins.Datos.Rows[0]["Importe_Factura"].ToString();

                    if (ins.Datos.Rows[0]["Pagada"].ToString() == "True")
                    {
                        chk_PagadaCorteSalida.Checked = true;
                    }
                    else
                    {
                        chk_PagadaCorteSalida.Checked = false;
                    }
                    if (ins.Datos.Rows[0]["Retencion"].ToString() == "True")
                    {
                        chk_RetencionCorteSalida.Checked = true;
                    }
                    else
                    {
                        chk_RetencionCorteSalida.Checked = false;
                    }
                    txt_RetencionFacturaCorteSalida.EditValue = ins.Datos.Rows[0]["Importe_Retencion"].ToString();
                    if (ins.Datos.Rows[0]["IVA"].ToString() == "True")
                    {
                        chk_IVACorteSalida.Checked = true;
                    }
                    else
                    {
                        chk_IVACorteSalida.Checked = false;
                    }
                    txt_IVAFacturaCorteSalida.EditValue = ins.Datos.Rows[0]["Importe_IVA"].ToString();
                    txt_TotalFacturaCorteSalida.EditValue = ins.Datos.Rows[0]["Total_Factura"].ToString();
                    dt_FechaFacturaCorteSalida.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Factura"].ToString());
                    dt_FechaPagoCorteSalida.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Pago"].ToString());
                    dt_FechaProgramaCorteSalida.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Programacion"].ToString());

                    if (ins.Datos.Rows[0]["Diferido"].ToString() == "True")
                    {
                        opt_TipoFacturaCorteSalida.SelectedIndex = 0;
                    }
                    else
                    {
                        opt_TipoFacturaCorteSalida.SelectedIndex = 1;
                    }
                    txt_UUID_Salida.EditValue = ins.Datos.Rows[0]["UUID"].ToString();
                    txt_MetodoPago_Salida.EditValue = ins.Datos.Rows[0]["MetodoPago"].ToString();
                    txt_SubTotal_Salida.EditValue = ins.Datos.Rows[0]["SubTotalXML"].ToString();
                    txt_Total_Salida.EditValue = ins.Datos.Rows[0]["TotalXML"].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        void SelectFacturaAcarreo()
        {
            CLS_Cosecha_Facturas ins = new CLS_Cosecha_Facturas();
            ins.Id_Cosecha = txt_IdCosecha.Text;
            ins.Id_Archivo = 6;
            ins.MtdSeleccionarCosechaArchivoPDFXML();
            if (ins.Exito)
            {
                if (ins.Datos.Rows.Count > 0)
                {
                    ArchivoPDFGlobalAcarreo = (byte[])ins.Datos.Rows[0]["FacturaPDF"];
                    ArchivoXMLGlobalAcarreo = (byte[])ins.Datos.Rows[0]["FacturaXML"];
                    if (ArchivoPDFGlobalAcarreo.Length > 0)
                    {
                        btn_ViewPDFAcarreo.Enabled = true;
                    }
                    else
                    {
                        btn_ViewPDFAcarreo.Enabled = false;
                    }
                    if (ArchivoXMLGlobalAcarreo.Length > 0)
                    {
                        btn_ViewXMLAcarreo.Enabled = true;
                    }
                    else
                    {
                        btn_ViewXMLAcarreo.Enabled = false;
                    }
                    if (ArchivoPDFGlobalAcarreo.Length > 0 || ArchivoXMLGlobalAcarreo.Length > 0)
                    {
                        btn_DelFacturaAcarreo.Enabled = true;
                    }
                    else
                    {
                        btn_DelFacturaAcarreo.Enabled = false;
                    }
                    txtRazonSAcarreo.Text = ins.Datos.Rows[0]["RazonSocial"].ToString();
                    txt_FolioFacturaAcarreo.Text = ins.Datos.Rows[0]["FolioFactura"].ToString();
                    if (ins.Datos.Rows[0]["Moneda"].ToString() == "P")
                    {
                        cmb_MonedaAcarreo.SelectedIndex = 0;
                    }
                    else
                    {
                        cmb_MonedaAcarreo.SelectedIndex = 1;
                    }

                    txt_ImporteFacturaAcarreo.EditValue = ins.Datos.Rows[0]["Importe_Factura"].ToString();

                    if (ins.Datos.Rows[0]["Pagada"].ToString() == "True")
                    {
                        chk_PagadaAcarreo.Checked = true;
                    }
                    else
                    {
                        chk_PagadaAcarreo.Checked = false;
                    }
                    if (ins.Datos.Rows[0]["Retencion"].ToString() == "True")
                    {
                        chk_RetencionAcarreo.Checked = true;
                    }
                    else
                    {
                        chk_RetencionAcarreo.Checked = false;
                    }
                    txt_RetencionFacturaAcarreo.EditValue = ins.Datos.Rows[0]["Importe_Retencion"].ToString();
                    if (ins.Datos.Rows[0]["IVA"].ToString() == "True")
                    {
                        chk_IVAAcarreo.Checked = true;
                    }
                    else
                    {
                        chk_IVAAcarreo.Checked = false;
                    }
                    txt_IVAFacturaAcarreo.EditValue = ins.Datos.Rows[0]["Importe_IVA"].ToString();
                    txt_TotalFacturaAcarreo.EditValue = ins.Datos.Rows[0]["Total_Factura"].ToString();
                    dt_FechaFacturaAcarreo.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Factura"].ToString());
                    dt_FechaPagoAcarreo.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Pago"].ToString());
                    dt_FechaProgramaAcarreo.EditValue = Convert.ToDateTime(ins.Datos.Rows[0]["Fecha_Programacion"].ToString());

                    if (ins.Datos.Rows[0]["Diferido"].ToString() == "True")
                    {
                        opt_TipoFacturaAcarreo.SelectedIndex = 0;
                    }
                    else
                    {
                        opt_TipoFacturaAcarreo.SelectedIndex = 1;
                    }
                    txt_UUID_Acarreo.EditValue = ins.Datos.Rows[0]["UUID"].ToString();
                    txt_MetodoPago_Acarreo.EditValue = ins.Datos.Rows[0]["MetodoPago"].ToString();
                    txt_SubTotal_Acarreo.EditValue = ins.Datos.Rows[0]["SubTotalXML"].ToString();
                    txt_Total_Acarreo.EditValue = ins.Datos.Rows[0]["TotalXML"].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        void SelectFacturas()
        {
            //LimpiarFacturas();
            SelectFacturaProductor();
            SelectFacturaKilos();
            SelectFacturaDia();
            SelectFacturaApoyo();
            SelectFacturaSalida();
            SelectFacturaAcarreo();
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
            SelectExpedientesProductor();
            SelectCorte();
            CorridaBanda();
            SelectAcarreo();
            SelectFacturas();
        }

        private void txt_ImporteFacturaProductor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CalcularTotalFacturaProductor();
            }
        }

        private void CalcularTotalFacturaProductor()
        {
            decimal vimporteFactura = 0;
            if (Decimal.TryParse(txt_ImporteFacturaProductor.EditValue.ToString(), out vimporteFactura))
            {
                if (chk_RetencionProductor.Checked)
                {
                    txt_RetencionFacturaProductor.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaProductor.Text, style, provider)) * Decimal.Parse("0.0125", style, provider));
                }
                else
                {
                    txt_RetencionFacturaProductor.EditValue = "0";
                }
                txt_TotalFacturaProductor.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaProductor.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaProductor.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaProductor.Text, style, provider)));
                if (txtRazonSProductor.Text == String.Empty && Decimal.Parse(txt_TotalFacturaProductor.Text, style, provider) > 0)
                {
                    txtRazonSProductor.Text = "Sin Factura";
                }
            }
        }

        private void chk_RetencionProductor_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_RetencionProductor.Checked == true)
            {
                txt_RetencionFacturaProductor.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaProductor.Text, style, provider)) * Decimal.Parse("0.0125", style, provider));
            }
            else
            {
                txt_RetencionFacturaProductor.EditValue = "0";
            }
            txt_TotalFacturaProductor.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaProductor.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaProductor.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaProductor.Text, style, provider)));
        }
        private void chk_IVAProductor_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_IVAProductor.Checked == true)
            {
                txt_IVAFacturaProductor.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaProductor.Text, style, provider)) * Decimal.Parse("0.16", style, provider));
            }
            else
            {
                txt_IVAFacturaProductor.EditValue = "0";
            }
            txt_TotalFacturaProductor.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaProductor.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaProductor.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaProductor.Text, style, provider)));
        }

        private void txt_ImporteFacturaCorteKilos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CalcularTotalKilos();
            }
        }

        private void CalcularTotalKilos()
        {
            decimal vimporteFactura = 0;
            if (Decimal.TryParse(txt_ImporteFacturaCorteKilos.EditValue.ToString(), out vimporteFactura))
            {
                if (chk_RetencionCorteKilos.Checked)
                {
                    txt_RetencionFacturaCorteKilos.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteKilos.Text, style, provider)) * Decimal.Parse("0.0125", style, provider));
                }
                else
                {
                    txt_RetencionFacturaCorteKilos.EditValue = "0";
                }
                txt_TotalFacturaCorteKilos.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteKilos.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteKilos.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteKilos.Text, style, provider)));
                if (txtRazonSCorteKilos.Text == String.Empty && Decimal.Parse(txt_TotalFacturaCorteKilos.Text, style, provider) > 0)
                {
                    txtRazonSCorteKilos.Text = "Sin Factura";
                }
            }
        }

        private void chk_RetencionCorteKilos_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_RetencionCorteKilos.Checked == true)
            {
                txt_RetencionFacturaCorteKilos.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteKilos.Text, style, provider)) * Decimal.Parse("0.0125", style, provider));
            }
            else
            {
                txt_RetencionFacturaCorteKilos.EditValue = "0";
            }
            txt_TotalFacturaCorteKilos.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteKilos.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteKilos.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteKilos.Text, style, provider)));

        }
        private void chk_IVACorteKilos_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_IVACorteKilos.Checked == true)
            {
                txt_IVAFacturaCorteKilos.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteKilos.Text, style, provider)) * Decimal.Parse("0.16", style, provider));
            }
            else
            {
                txt_IVAFacturaCorteKilos.EditValue = "0";
            }
            txt_TotalFacturaCorteKilos.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteKilos.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteKilos.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteKilos.Text, style, provider)));
        }

        private void txt_ImporteFacturaCorteDia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CalcularTotalDia();
            }
        }

        private void CalcularTotalDia()
        {
            decimal vimporteFactura = 0;
            if (Decimal.TryParse(txt_ImporteFacturaCorteDia.EditValue.ToString(), out vimporteFactura))
            {
                if (chk_RetencionCorteDia.Checked)
                {
                    txt_RetencionFacturaCorteDia.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteDia.Text, style, provider)) * Decimal.Parse("0.0125", style, provider));
                }
                else
                {
                    txt_RetencionFacturaCorteDia.EditValue = "0";
                }
                txt_TotalFacturaCorteDia.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteDia.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteDia.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteDia.Text, style, provider)));
                if (txtRazonSCorteDia.Text == String.Empty && Decimal.Parse(txt_TotalFacturaCorteDia.Text, style, provider) > 0)
                {
                    txtRazonSCorteDia.Text = "Sin Factura";
                }
            }
        }

        private void chk_RetencionCorteDia_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_RetencionCorteDia.Checked == true)
            {
                txt_RetencionFacturaCorteDia.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteDia.Text, style, provider)) * Decimal.Parse("0.0125", style, provider));
            }
            else
            {
                txt_RetencionFacturaCorteDia.EditValue = "0";
            }
            txt_TotalFacturaCorteDia.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteDia.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteDia.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteDia.Text, style, provider)));
        }
        private void chk_IVACorteDia_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_IVACorteDia.Checked == true)
            {
                txt_IVAFacturaCorteDia.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteDia.Text, style, provider)) * Decimal.Parse("0.16", style, provider));
            }
            else
            {
                txt_IVAFacturaCorteDia.EditValue = "0";
            }
            txt_TotalFacturaCorteDia.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteDia.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteDia.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteDia.Text, style, provider)));
        }

        private void txt_ImporteFacturaCorteApoyo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CalcularTotalApoyo();
            }
        }

        private void CalcularTotalApoyo()
        {
            decimal vimporteFactura = 0;
            if (Decimal.TryParse(txt_ImporteFacturaCorteApoyo.EditValue.ToString(), out vimporteFactura))
            {
                if (chk_RetencionCorteApoyo.Checked)
                {
                    txt_RetencionFacturaCorteApoyo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteApoyo.Text, style, provider)) * Decimal.Parse("0.0125", style, provider));
                }
                else
                {
                    txt_RetencionFacturaCorteApoyo.EditValue = "0";
                }
                txt_TotalFacturaCorteApoyo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteApoyo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteApoyo.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteApoyo.Text, style, provider)));
                if (txtRazonSCorteApoyo.Text == String.Empty && Decimal.Parse(txt_TotalFacturaCorteApoyo.Text, style, provider) > 0)
                {
                    txtRazonSCorteApoyo.Text = "Sin Factura";
                }
            }
        }

        private void chk_RetencionCorteApoyo_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_RetencionCorteApoyo.Checked == true)
            {
                txt_RetencionFacturaCorteApoyo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteApoyo.Text, style, provider)) * Decimal.Parse("0.0125", style, provider));
            }
            else
            {
                txt_RetencionFacturaCorteApoyo.EditValue = "0";
            }
            txt_TotalFacturaCorteApoyo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteApoyo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteApoyo.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteApoyo.Text, style, provider)));
        }
        private void chk_IVACorteApoyo_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_IVACorteApoyo.Checked == true)
            {
                txt_IVAFacturaCorteApoyo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteApoyo.Text, style, provider)) * Decimal.Parse("0.16", style, provider));
            }
            else
            {
                txt_IVAFacturaCorteApoyo.EditValue = "0";
            }
            txt_TotalFacturaCorteApoyo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteApoyo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteApoyo.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteApoyo.Text, style, provider)));
        }

        private void txt_ImporteFacturaCorteSalida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CalcularTotalSalidaFalso();
            }
        }

        private void CalcularTotalSalidaFalso()
        {
            decimal vimporteFactura = 0;
            if (Decimal.TryParse(txt_ImporteFacturaCorteSalida.EditValue.ToString(), out vimporteFactura))
            {
                if (chk_RetencionCorteSalida.Checked)
                {
                    txt_RetencionFacturaCorteSalida.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteSalida.Text, style, provider)) * Decimal.Parse("0.0125", style, provider));
                }
                else
                {
                    txt_RetencionFacturaCorteSalida.EditValue = "0";
                }
                txt_TotalFacturaCorteSalida.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteSalida.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteSalida.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteSalida.Text, style, provider)));
                if (txtRazonSCorteSalida.Text == String.Empty && Decimal.Parse(txt_TotalFacturaCorteSalida.Text, style, provider) > 0)
                {
                    txtRazonSCorteSalida.Text = "Sin Factura";
                }
            }
        }

        private void chk_RetencionCorteSalida_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_RetencionCorteSalida.Checked == true)
            {
                txt_RetencionFacturaCorteSalida.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteSalida.Text, style, provider)) * Decimal.Parse("0.0125", style, provider));
            }
            else
            {
                txt_RetencionFacturaCorteSalida.EditValue = "0";
            }
            txt_TotalFacturaCorteSalida.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteSalida.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteSalida.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteSalida.Text, style, provider)));
        }
        private void chk_IVACorteSalida_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_IVACorteSalida.Checked == true)
            {
                txt_IVAFacturaCorteSalida.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteSalida.Text, style, provider)) * Decimal.Parse("0.16", style, provider));
            }
            else
            {
                txt_IVAFacturaCorteSalida.EditValue = "0";
            }
            txt_TotalFacturaCorteSalida.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteSalida.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteSalida.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteSalida.Text, style, provider)));
        }

        private void txt_ImporteFacturaAcarreo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CalcularTotalFacturaAcarreo();
            }
        }

        private void CalcularTotalFacturaAcarreo()
        {
            decimal vimporteFactura = 0;
            if (Decimal.TryParse(txt_ImporteFacturaAcarreo.EditValue.ToString(), out vimporteFactura))
            {
                if (chk_RetencionAcarreo.Checked)
                {
                    txt_RetencionFacturaAcarreo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaAcarreo.Text, style, provider)) * Decimal.Parse("0.0125", style, provider));
                }
                else
                {
                    txt_RetencionFacturaAcarreo.EditValue = "0";
                }
                txt_TotalFacturaAcarreo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaAcarreo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaAcarreo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFleteFacturaAcarreo.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaAcarreo.Text, style, provider)));
                if (txtRazonSAcarreo.Text == String.Empty && Decimal.Parse(txt_TotalFacturaAcarreo.Text, style, provider) > 0)
                {
                    txtRazonSAcarreo.Text = "Sin Factura";
                }
            }
        }

        private void chk_RetencionAcarreo_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_RetencionAcarreo.Checked == true)
            {
                txt_RetencionFacturaAcarreo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaAcarreo.Text, style, provider)) * Decimal.Parse("0.0125", style, provider));
            }
            else
            {
                txt_RetencionFacturaAcarreo.EditValue = "0";
            }
            txt_TotalFacturaAcarreo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaAcarreo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaAcarreo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFleteFacturaAcarreo.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaAcarreo.Text, style, provider)));
        }
        private void chk_RetencionFleteAcarreo_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_RetencionFleteAcarreo.Checked == true)
            {
                txt_RetencionFleteFacturaAcarreo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaAcarreo.Text, style, provider)) * Decimal.Parse("0.04", style, provider));
            }
            else
            {
                txt_RetencionFleteFacturaAcarreo.EditValue = "0";
            }
            txt_TotalFacturaAcarreo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaAcarreo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaAcarreo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFleteFacturaAcarreo.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaAcarreo.Text, style, provider)));
        }
        private void chk_IVAAcarreo_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_IVAAcarreo.Checked == true)
            {
                txt_IVAFacturaAcarreo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaAcarreo.Text, style, provider)) * Decimal.Parse("0.16", style, provider));
            }
            else
            {
                txt_IVAFacturaAcarreo.EditValue = "0";
            }
            txt_TotalFacturaAcarreo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaAcarreo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaAcarreo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFleteFacturaAcarreo.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaAcarreo.Text, style, provider)));
        }

        private void txt_TotalAcarreo_EditValueChanged(object sender, EventArgs e)
        {
            txt_ImporteFacturaAcarreo.EditValue = txt_TotalAcarreo.EditValue;
            if (Decimal.Parse(txt_ImporteFacturaAcarreo.Text, style, provider) > 0)
            {
                txtRazonSAcarreo.EditValue = txt_EmpresaAcarreo.EditValue;
            }
            CalcularTotalFacturaAcarreo();
        }

        private void txt_TotalaPagar_EditValueChanged(object sender, EventArgs e)
        {
            txt_ImporteFacturaProductor.EditValue = txt_TotalaPagar.EditValue;
            CalcularTotalFacturaProductor();
        }

        private void txt_CargosExtra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txt_CajasExtras.Text))
                {
                    txt_CostoxCajaExtra.Text = (Decimal.Parse(txt_CajasExtras.Text, style, provider) * Decimal.Parse(txtPrecioCaja.Text, style, provider)).ToString();
                    txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider) - Decimal.Parse(txt_Descuentos.Text, style, provider)).ToString();
                }
            }
        }

        private void btn_CalcularFechaPago_Click(object sender, EventArgs e)
        {
            CalcularFechaPrograma(dt_FechaRecepcion.DateTime);
        }

        private void txt_PrecioTCorte_EditValueChanged(object sender, EventArgs e)
        {
            txt_ImporteFacturaCorteKilos.EditValue = txt_PrecioTCorte.EditValue;
            if (Decimal.Parse(txt_ImporteFacturaCorteKilos.Text, style, provider) > 0)
            {
                txtRazonSCorteKilos.EditValue = txt_NombreEmpresaCorte.EditValue;
            }
            CalcularTotalKilos();
        }

        private void txt_PrecioDiaCorte_EditValueChanged(object sender, EventArgs e)
        {
            txt_ImporteFacturaCorteDia.EditValue = txt_PrecioDiaCorte.EditValue;
            if (Decimal.Parse(txt_ImporteFacturaCorteDia.Text, style, provider) > 0)
            {
                txtRazonSCorteDia.EditValue = txt_NombreEmpresaCorte.EditValue;
            }
            CalcularTotalDia();
        }

        private void txt_PrecioSalidaFCorte_EditValueChanged(object sender, EventArgs e)
        {
            txt_ImporteFacturaCorteSalida.EditValue = txt_PrecioSalidaFCorte.EditValue;
            if (Decimal.Parse(txt_ImporteFacturaCorteSalida.Text, style, provider) > 0)
            {
                txtRazonSCorteSalida.EditValue = txt_NombreEmpresaCorte.EditValue;
            }
            CalcularTotalSalidaFalso();
        }

        private void txt_PrecioCuadrillaCorte_EditValueChanged(object sender, EventArgs e)
        {
            txt_ImporteFacturaCorteApoyo.EditValue = txt_PrecioCuadrillaCorte.EditValue;
            if (Decimal.Parse(txt_ImporteFacturaCorteApoyo.Text, style, provider) > 0)
            {
                txtRazonSCorteSalida.EditValue = txt_NombreEmpresaCorte.EditValue;
            }
            CalcularTotalApoyo();
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

        private void btn_UpXMLAcarreo_Click(object sender, EventArgs e)
        {
            if (txt_IdCosecha.Text != String.Empty)
            {
                OpenDialog.FileName = String.Empty;
                DialogResult result = FileDialogXML();
                if (result == DialogResult.OK)
                {
                    txt_RutaXMLAcarreo.Text = OpenDialog.FileName;
                    GuardarRuta(OpenDialog.FileName);
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(OpenDialog.FileName);
                        XmlNode nodoComprobante = doc.GetElementsByTagName("cfdi:Comprobante").Item(0);
                        txt_MetodoPago_Acarreo.Text = nodoComprobante.Attributes["MetodoPago"].Value;
                        dt_FechaFacturaAcarreo.DateTime = Convert.ToDateTime(nodoComprobante.Attributes["Fecha"].Value);
                        txt_FolioFacturaAcarreo.Text = nodoComprobante.Attributes["Folio"].Value; ;
                        txt_SubTotal_Acarreo.Text = nodoComprobante.Attributes["SubTotal"].Value;
                        txt_Total_Acarreo.Text = nodoComprobante.Attributes["Total"].Value;
                        XmlNode nodoComplemento = doc.GetElementsByTagName("tfd:TimbreFiscalDigital").Item(0);
                        txt_UUID_Acarreo.Text = nodoComplemento.Attributes["UUID"].Value;
                        XmlNode nodoEmisor = doc.GetElementsByTagName("cfdi:Emisor").Item(0);
                        txtRazonSAcarreo.Text = nodoEmisor.Attributes["Nombre"].Value;
                    }
                    catch
                    {
                        txt_RutaXMLProductor.Text = String.Empty;
                        XtraMessageBox.Show("No es un Archivo CFDI Valido favor de verificarlo");

                    }

                }
                OpenDialog.Dispose();
            }
            else
            {
                XtraMessageBox.Show("No se ha guardado o definido un folio de cosecha");
            }
        }

        private void btn_Manifiesto_Click(object sender, EventArgs e)
        {

        }

        private void chk_RetencionFleteCorteSalida_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_RetencionFleteCorteSalida.Checked == true)
            {
                txt_RetencionFleteFacturaCorteSalida.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteSalida.Text, style, provider)) * Decimal.Parse("0.04", style, provider));
            }
            else
            {
                txt_RetencionFleteFacturaCorteSalida.EditValue = "0";
            }
            txt_TotalFacturaCorteSalida.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteSalida.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteSalida.Text, style, provider)) - (Decimal.Parse(txt_RetencionFleteFacturaCorteSalida.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteSalida.Text, style, provider)));
        }

        private void chk_RetencionFleteCorteApoyo_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_RetencionFleteCorteApoyo.Checked == true)
            {
                txt_RetencionFleteFacturaCorteApoyo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteApoyo.Text, style, provider)) * Decimal.Parse("0.04", style, provider));
            }
            else
            {
                txt_RetencionFleteFacturaCorteApoyo.EditValue = "0";
            }
            txt_TotalFacturaCorteApoyo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteApoyo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteApoyo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFleteFacturaCorteApoyo.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteApoyo.Text, style, provider)));
        }

        private void chk_RetencionFleteCorteDia_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_RetencionFleteCorteDia.Checked == true)
            {
                txt_RetencionFleteFacturaCorteDia.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteDia.Text, style, provider)) * Decimal.Parse("0.04", style, provider));
            }
            else
            {
                txt_RetencionFleteFacturaCorteDia.EditValue = "0";
            }
            txt_TotalFacturaCorteDia.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteDia.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteDia.Text, style, provider)) - (Decimal.Parse(txt_RetencionFleteFacturaCorteDia.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteDia.Text, style, provider)));
        }

        private void chk_RetencionFleteCorteKilos_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_RetencionFleteCorteKilos.Checked == true)
            {
                txt_RetencionFleteFacturaCorteKilos.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteKilos.Text, style, provider)) * Decimal.Parse("0.04", style, provider));
            }
            else
            {
                txt_RetencionFleteFacturaCorteKilos.EditValue = "0";
            }
            txt_TotalFacturaCorteKilos.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaCorteKilos.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaCorteKilos.Text, style, provider)) - (Decimal.Parse(txt_RetencionFleteFacturaCorteKilos.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaCorteKilos.Text, style, provider)));
        }

        private void chk_PagadaProductor_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_PagadaProductor.Checked == false)
            {
                this.dt_FechaPagoProductor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                this.dt_FechaPagoProductor.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
                this.dt_FechaPagoProductor.Properties.Appearance.Options.UseFont = true;
                this.dt_FechaPagoProductor.Properties.Appearance.Options.UseForeColor = true;
            }
            else
            {
                this.dt_FechaPagoProductor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
                this.dt_FechaPagoProductor.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                this.dt_FechaPagoProductor.Properties.Appearance.Options.UseFont = false;
                this.dt_FechaPagoProductor.Properties.Appearance.Options.UseForeColor = false;
            }
        }

        private void chk_PagadaCorteKilos_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_PagadaCorteKilos.Checked == false)
            {
                this.dt_FechaPagoCorteKilos.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                this.dt_FechaPagoCorteKilos.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
                this.dt_FechaPagoCorteKilos.Properties.Appearance.Options.UseFont = true;
                this.dt_FechaPagoCorteKilos.Properties.Appearance.Options.UseForeColor = true;
            }
            else
            {
                this.dt_FechaPagoCorteKilos.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
                this.dt_FechaPagoCorteKilos.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                this.dt_FechaPagoCorteKilos.Properties.Appearance.Options.UseFont = false;
                this.dt_FechaPagoCorteKilos.Properties.Appearance.Options.UseForeColor = false;
            }
        }

        private void chk_PagadaCorteDia_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_PagadaCorteDia.Checked == false)
            {
                this.dt_FechaPagoCorteDia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                this.dt_FechaPagoCorteDia.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
                this.dt_FechaPagoCorteDia.Properties.Appearance.Options.UseFont = true;
                this.dt_FechaPagoCorteDia.Properties.Appearance.Options.UseForeColor = true;
            }
            else
            {
                this.dt_FechaPagoCorteDia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
                this.dt_FechaPagoCorteDia.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                this.dt_FechaPagoCorteDia.Properties.Appearance.Options.UseFont = false;
                this.dt_FechaPagoCorteDia.Properties.Appearance.Options.UseForeColor = false;
            }
        }

        private void chk_PagadaCorteApoyo_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_PagadaCorteApoyo.Checked == false)
            {
                this.dt_FechaPagoCorteApoyo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                this.dt_FechaPagoCorteApoyo.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
                this.dt_FechaPagoCorteApoyo.Properties.Appearance.Options.UseFont = true;
                this.dt_FechaPagoCorteApoyo.Properties.Appearance.Options.UseForeColor = true;
            }
            else
            {
                this.dt_FechaPagoCorteApoyo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
                this.dt_FechaPagoCorteApoyo.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                this.dt_FechaPagoCorteApoyo.Properties.Appearance.Options.UseFont = false;
                this.dt_FechaPagoCorteApoyo.Properties.Appearance.Options.UseForeColor = false;
            }
        }

        private void chk_PagadaCorteSalida_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_PagadaCorteSalida.Checked == false)
            {
                this.dt_FechaPagoCorteSalida.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                this.dt_FechaPagoCorteSalida.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
                this.dt_FechaPagoCorteSalida.Properties.Appearance.Options.UseFont = true;
                this.dt_FechaPagoCorteSalida.Properties.Appearance.Options.UseForeColor = true;
            }
            else
            {
                this.dt_FechaPagoCorteSalida.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
                this.dt_FechaPagoCorteSalida.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                this.dt_FechaPagoCorteSalida.Properties.Appearance.Options.UseFont = false;
                this.dt_FechaPagoCorteSalida.Properties.Appearance.Options.UseForeColor = false;
            }
        }

        private void chk_PagadaAcarreo_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_PagadaAcarreo.Checked == false)
            {
                this.dt_FechaPagoAcarreo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                this.dt_FechaPagoAcarreo.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
                this.dt_FechaPagoAcarreo.Properties.Appearance.Options.UseFont = true;
                this.dt_FechaPagoAcarreo.Properties.Appearance.Options.UseForeColor = true;
            }
            else
            {
                this.dt_FechaPagoAcarreo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
                this.dt_FechaPagoAcarreo.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                this.dt_FechaPagoAcarreo.Properties.Appearance.Options.UseFont = false;
                this.dt_FechaPagoAcarreo.Properties.Appearance.Options.UseForeColor = false;
            }
        }

        private void dt_FechaPagoProductor_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaFacturaProductor_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaFacturaCorteKilos_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaPagoCorteKilos_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaFacturaCorteDia_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaPagoCorteDia_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaFacturaCorteApoyo_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaPagoCorteApoyo_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaFacturaCorteSalida_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaPagoCorteSalida_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaFacturaAcarreo_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaPagoAcarreo_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
        private void txt_Descuentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txt_CajasExtras.Text))
                {
                    txt_CostoxCajaExtra.Text = (Decimal.Parse(txt_CajasExtras.Text, style, provider) * Decimal.Parse(txtPrecioCaja.Text, style, provider)).ToString();
                    txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider) - Decimal.Parse(txt_Descuentos.Text, style, provider)).ToString();
                }
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

        private void chk_kgCorte_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_kgCorte.Checked == true)
            {
                if (Convert.ToDecimal(txt_KilosBasculaE.Text) > 0)
                {
                    txt_kilosCortadosCorte.Text = txt_KilosBasculaE.Text;
                }
            }
            else
            {
                txt_kilosCortadosCorte.Text = txt_KilosCortados.Text;
            }
        }
        private void EliminaFacturaXMLPDF(int Id_Factura)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar la factura?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                if (txt_IdCosecha.Text.Trim() != String.Empty)
                {
                    CLS_Cosecha_Facturas Clase = new CLS_Cosecha_Facturas();
                    Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
                    Clase.Id_Archivo = Id_Factura;
                    Clase.FacturaPDF = Encoding.UTF8.GetBytes("");
                    Clase.FacturaXML = Encoding.UTF8.GetBytes("");
                    Clase.RazonSocial=String.Empty;
                    Clase.FolioFactura = String.Empty;
                    Clase.Fecha_Factura=DateTime.Now.Year.ToString() + DosCeros(DateTime.Now.Month.ToString()) + DosCeros(DateTime.Now.Day.ToString());
                    Clase.UUID = String.Empty;
                    Clase.MetodoPago=String.Empty;
                    Clase.SubTotalXML = 0;
                    Clase.TotalXML = 0;
                    Clase.Usuario = UsuariosLogin;
                    Clase.MtdDeleteCosechaArchivoPDFXML();
                    if (!Clase.Exito)
                    {
                        XtraMessageBox.Show(Clase.Mensaje);
                    }
                    else
                    {
                        if(Id_Factura==1)
                        {
                            EliminaREP();
                        }
                    }
                }
            }
        }
        void EliminaREP()
        {
            if (txt_IdCosecha.Text.Trim() != String.Empty)
            {
                CLS_Cosecha_Facturas Clase = new CLS_Cosecha_Facturas();
                Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
                Clase.MtdDeleteCosechaTodosArchivoREP_PDFXML();
                if (!Clase.Exito)
                {
                    XtraMessageBox.Show(Clase.Mensaje);
                }
            }
        }
        private void btn_DelFacturaProductor_Click(object sender, EventArgs e)
        {
            EliminaFacturaXMLPDF(1);
            SelectFacturas();
        }
        private void btn_DelFacturaKilos_Click(object sender, EventArgs e)
        {
            EliminaFacturaXMLPDF(2);
            SelectFacturas();
        }

        private void btn_DelFacturaDia_Click(object sender, EventArgs e)
        {
            EliminaFacturaXMLPDF(3);
            SelectFacturas();
        }

        private void btn_DelFacturaApoyo_Click(object sender, EventArgs e)
        {
            EliminaFacturaXMLPDF(4);
            SelectFacturas();
        }

        private void btn_DelFacturaSalida_Click(object sender, EventArgs e)
        {
            EliminaFacturaXMLPDF(5);
            SelectFacturas();
        }

        private void btn_DelFacturaAcarreo_Click(object sender, EventArgs e)
        {
            EliminaFacturaXMLPDF(6);
            SelectFacturas();
        }
        private void Bloquear_OrdenCorte(Boolean valor)
        {
            btnBusqProgramaCorte.Enabled = valor;
        }
        private void Bloquear_Recepcion(Boolean valor)
        {
            txt_KilosBasculaE.Enabled = valor;
            chk_kgProductor.Enabled = valor;
            chk_kgCorte.Enabled = valor;
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
            //Facturas
            txtRazonSProductor.Enabled = valor;
            opt_TipoFacturaProductor.Enabled = valor;
            txt_FolioFacturaProductor.Enabled = valor;
            cmb_MonedaProductor.Enabled = valor;
            txt_ImporteFacturaProductor.Enabled = valor;
            chk_PagadaProductor.Enabled = valor;
            chk_RetencionProductor.Enabled = valor;
            chk_RetencionFleteProductor.Enabled = valor;
            chk_IVAProductor.Enabled = valor;
            dt_FechaFacturaProductor.Enabled = valor;
            dt_FechaPagoProductor.Enabled = valor;
            btn_CalcularFechaPago.Enabled = valor;
            if (!valor)
            {
                btn_UpPDFProductor.Enabled = valor;
                btn_UpXMLProductor.Enabled = valor;
                btn_ViewPDFProductor.Enabled = valor;
                btn_ViewXMLProductor.Enabled = valor;
                btn_DelFacturaProductor.Enabled = valor;
                //Expedientes
                btn_UpPDFTarjeta_APEAM.Enabled = valor;
                btn_UpPDFIdntificacion_IFE_INE.Enabled = valor;
                btn_UpPDFOpinion_Cumplimiento.Enabled = valor;
                btn_UpPDFConstancia_Situacion.Enabled = valor;
                btn_UpPDFClaveInterbancaria.Enabled = valor;
                btn_UpPDFContratoTerceros.Enabled = valor;
                btn_UpPDFContratoGEST.Enabled = valor;
                btn_ViewPDFTarjetaAPEAM.Enabled = valor;
                btn_DelTarjetaAPEAM.Enabled = valor;
                btn_ViewPDFIdentificacion_IFE_INE.Enabled = valor;
                btn_DelIdentificacion_IFE_INE.Enabled = valor;
                btn_ViewPDFOpinionCumplimiento.Enabled = valor;
                btn_DelOpinionCumplimiento.Enabled = valor;
                btn_ViewPDFConstanciaSituacion.Enabled = valor;
                btn_DelConstanciaSituacion.Enabled = valor;
                btn_ViewPDFClaveInterbancaria.Enabled = valor;
                btn_DelClaveInterbancaria.Enabled = valor;
                btn_ViewPDFContratoTerceros.Enabled = valor;
                btn_DelContratoTerceros.Enabled = valor;
                btn_ViewPDFContratoGEST.Enabled = valor;
                btn_DelContratoGEST.Enabled = valor;
            }
            else
            {
                btn_UpPDFProductor.Enabled = valor;
                btn_UpXMLProductor.Enabled = valor;
                SelectFacturaProductor();
                SelectExpedientesProductor();
            }
        }
        private void Bloquear_Acarreo(Boolean valor)
        {
            btn_EmpresaAcarreo.Enabled = valor;
            cmb_Camiones.Enabled = valor;
            cmb_Choferes.Enabled = valor;
            txt_ObservacionesAcarreo.Enabled = valor;
            chk_ServicioForaneo.Enabled = valor;
            txt_CargosExtra.Enabled = valor;
            txt_CajasExtras.Enabled = valor;
            txt_Descuentos.Enabled = valor;
            //Facturas
            txtRazonSAcarreo.Enabled = valor;
            opt_TipoFacturaAcarreo.Enabled = valor;
            txt_FolioFacturaAcarreo.Enabled = valor;
            cmb_MonedaAcarreo.Enabled = valor;
            txt_ImporteFacturaAcarreo.Enabled = valor;
            chk_PagadaAcarreo.Enabled = valor;
            chk_RetencionAcarreo.Enabled = valor;
            chk_RetencionFleteAcarreo.Enabled = valor;
            chk_IVAAcarreo.Enabled = valor;
            dt_FechaFacturaAcarreo.Enabled = valor;
            dt_FechaPagoAcarreo.Enabled = valor;
            btn_CalcularFechaPago.Enabled = valor;
            if (!valor)
            {
                btn_UpPDFAcarreo.Enabled = valor;
                btn_UpXMLAcarreo.Enabled = valor;
                btn_ViewPDFAcarreo.Enabled = valor;
                btn_ViewXMLAcarreo.Enabled = valor;
                btn_DelFacturaAcarreo.Enabled = valor;
            }
            else
            {
                btn_UpPDFAcarreo.Enabled = valor;
                btn_UpXMLAcarreo.Enabled = valor;
                SelectFacturaAcarreo();
            }
        }
        private void Bloquear_Corte(Boolean valor)
        {
            btn_EmpresaCorte.Enabled = valor;
            btn_RefrescarPeso.Enabled = valor;
            chk_PrecioPorkg.Enabled = valor;
            txt_PrecioKiloCorte.Enabled = valor;
            txt_ObservacionesCorte.Enabled = valor;
            txt_NoCuadrillas.Enabled = valor;
            if (txt_kilosCortadosCorte.Text != String.Empty)
            {
                chk_SalidaFalso.Enabled = true;
            }
            else
            {
                chk_SalidaFalso.Enabled = valor;
            }
            chk_CuadrillaApoyo.Enabled = valor;
            //Facturas
            txtRazonSCorteKilos.Enabled = valor;
            opt_TipoFacturaCorteKilos.Enabled = valor;
            txt_FolioFacturaCorteKilos.Enabled = valor;
            cmb_MonedaCorteKilos.Enabled = valor;
            txt_ImporteFacturaCorteKilos.Enabled = valor;
            chk_PagadaCorteKilos.Enabled = valor;
            chk_RetencionCorteKilos.Enabled = valor;
            chk_RetencionFleteCorteKilos.Enabled = valor;
            chk_IVACorteKilos.Enabled = valor;
            dt_FechaFacturaCorteKilos.Enabled = valor;
            dt_FechaPagoCorteKilos.Enabled = valor;
            if (!valor)
            {
                btn_UpPDFCorteKilos.Enabled = valor;
                btn_UpXMLCorteKilos.Enabled = valor;
                btn_ViewPDFCorteKilos.Enabled = valor;
                btn_ViewXMLCorteKilos.Enabled = valor;
                btn_DelFacturaKilos.Enabled = valor;
            }
            else
            {
                btn_UpPDFCorteKilos.Enabled = valor;
                btn_UpXMLCorteKilos.Enabled = valor;
                SelectFacturaKilos();
            }

            txtRazonSCorteDia.Enabled = valor;
            opt_TipoFacturaCorteDia.Enabled = valor;
            txt_FolioFacturaCorteDia.Enabled = valor;
            cmb_MonedaCorteDia.Enabled = valor;
            txt_ImporteFacturaCorteDia.Enabled = valor;
            chk_PagadaCorteDia.Enabled = valor;
            chk_RetencionCorteDia.Enabled = valor;
            chk_RetencionFleteCorteDia.Enabled = valor;
            chk_IVACorteDia.Enabled = valor;
            dt_FechaFacturaCorteDia.Enabled = valor;
            dt_FechaPagoCorteDia.Enabled = valor;
            if (!valor)
            {
                btn_UpPDFCorteDia.Enabled = valor;
                btn_UpXMLCorteDia.Enabled = valor;
                btn_ViewPDFCorteDia.Enabled = valor;
                btn_ViewXMLCorteDia.Enabled = valor;
                btn_DelFacturaDia.Enabled = valor;
            }
            else
            {
                btn_UpPDFCorteDia.Enabled = valor;
                btn_UpXMLCorteDia.Enabled = valor;
                SelectFacturaDia();
            }

            txtRazonSCorteApoyo.Enabled = valor;
            opt_TipoFacturaCorteApoyo.Enabled = valor;
            txt_FolioFacturaCorteApoyo.Enabled = valor;
            cmb_MonedaCorteApoyo.Enabled = valor;
            txt_ImporteFacturaCorteApoyo.Enabled = valor;
            chk_PagadaCorteApoyo.Enabled = valor;
            chk_RetencionCorteApoyo.Enabled = valor;
            chk_RetencionFleteCorteApoyo.Enabled = valor;
            chk_IVACorteApoyo.Enabled = valor;
            dt_FechaFacturaCorteApoyo.Enabled = valor;
            dt_FechaPagoCorteApoyo.Enabled = valor;
            if (!valor)
            {
                btn_UpPDFCorteApoyo.Enabled = valor;
                btn_UpXMLCorteApoyo.Enabled = valor;
                btn_ViewPDFCorteApoyo.Enabled = valor;
                btn_ViewXMLCorteApoyo.Enabled = valor;
                btn_DelFacturaApoyo.Enabled = valor;
            }
            else
            {
                btn_UpPDFCorteApoyo.Enabled = valor;
                btn_UpXMLCorteApoyo.Enabled = valor;
                SelectFacturaApoyo();
            }

            txtRazonSCorteSalida.Enabled = valor;
            opt_TipoFacturaCorteSalida.Enabled = valor;
            txt_FolioFacturaCorteSalida.Enabled = valor;
            cmb_MonedaCorteSalida.Enabled = valor;
            txt_ImporteFacturaCorteSalida.Enabled = valor;
            chk_PagadaCorteSalida.Enabled = valor;
            chk_RetencionCorteSalida.Enabled = valor;
            chk_RetencionFleteCorteSalida.Enabled = valor;
            chk_IVACorteSalida.Enabled = valor;
            dt_FechaFacturaCorteSalida.Enabled = valor;
            dt_FechaPagoCorteSalida.Enabled = valor;
            if (!valor)
            {
                btn_UpPDFCorteSalida.Enabled = valor;
                btn_UpXMLCorteSalida.Enabled = valor;
                btn_ViewPDFCorteSalida.Enabled = valor;
                btn_ViewXMLCorteSalida.Enabled = valor;
                btn_DelFacturaSalida.Enabled = valor;
            }
            else
            {
                btn_UpPDFCorteSalida.Enabled = valor;
                btn_UpXMLCorteSalida.Enabled = valor;
                SelectFacturaSalida();
            }
        }
        private void btn_CerrarRecepcion_Click(object sender, EventArgs e)
        {
            Cerrar_Recepcion(1);
        }

        private void btn_AbrirRecepcion_Click(object sender, EventArgs e)
        {
            Cerrar_Recepcion(0);
        }

        private void Cerrar_Recepcion(int Cierre)
        {
            if (TieneAcceso("023"))
            {
                CLS_Cosecha_Datos Clase = new CLS_Cosecha_Datos();
                Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
                Clase.Usuario = UsuariosLogin;
                Clase.Cerrado = Cierre;
                Clase.MtdModificarCerradoRecepcion();
                if (Clase.Exito)
                {
                    if (Cierre == 0)
                    {
                        Bloquear_Recepcion(true);
                    }
                    else
                    {
                        Bloquear_Recepcion(false);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [023]");
            }
        }

        private void btn_CerrarComer_Click(object sender, EventArgs e)
        {
            Cerrar_Comercializacion(1);
        }

        private void btn_AbrirComer_Click(object sender, EventArgs e)
        {
            Cerrar_Comercializacion(0);
        }

        private void Cerrar_Comercializacion(int Cierre)
        {
            if (TieneAcceso("023"))
            {
                CLS_Cosecha_Datos Clase = new CLS_Cosecha_Datos();
                Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
                Clase.Usuario = UsuariosLogin;
                Clase.Cerrado = Cierre;
                Clase.MtdModificarCerradoComercializadora();
                if (Clase.Exito)
                {
                    if (Cierre == 0)
                    {
                        Bloquear_Comercializacion(true);
                    }
                    else
                    {
                        Bloquear_Comercializacion(false);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [023]");
            }
        }

        private void btn_CerrarProductor_Click(object sender, EventArgs e)
        {
            Cerrar_Productor(1);
        }

        private void btn_AbrirProductor_Click(object sender, EventArgs e)
        {
            Cerrar_Productor(0);
        }

        private void Cerrar_Productor(int Cierre)
        {
            if (TieneAcceso("023"))
            {
                CLS_Cosecha_Datos Clase = new CLS_Cosecha_Datos();
                Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
                Clase.Usuario = UsuariosLogin;
                Clase.Cerrado = Cierre;
                Clase.MtdModificarCerradoProductor();
                if (Clase.Exito)
                {
                    if (Cierre == 0)
                    {
                        Bloquear_Productor(true);
                    }
                    else
                    {
                        Bloquear_Productor(false);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [023]");
            }
        }

        private void btn_CerrarAcarreo_Click(object sender, EventArgs e)
        {
            Cerrar_Acarreo(1);
        }
        private void btn_AbrirAcarreo_Click(object sender, EventArgs e)
        {
            Cerrar_Acarreo(0);
        }
        private void Cerrar_Acarreo(int Cierre)
        {
            if (TieneAcceso("023"))
            {
                CLS_Cosecha_Datos Clase = new CLS_Cosecha_Datos();
                Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
                Clase.Usuario = UsuariosLogin;
                Clase.Cerrado = Cierre;
                Clase.MtdModificarCerradoAcarreo();
                if (Clase.Exito)
                {
                    if (Cierre == 0)
                    {
                        Bloquear_Acarreo(true);
                    }
                    else
                    {
                        Bloquear_Acarreo(false);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [023]");
            }
        }
        private void btn_CerrarCorte_Click(object sender, EventArgs e)
        {
            Cerrar_Corte(1);
        }
        private void btn_AbrirCorte_Click(object sender, EventArgs e)
        {
            Cerrar_Corte(0);
        }

        private void Cerrar_Corte(int Cierre)
        {
            if (TieneAcceso("023"))
            {
                CLS_Cosecha_Datos Clase = new CLS_Cosecha_Datos();
                Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
                Clase.Usuario = UsuariosLogin;
                Clase.Cerrado = Cierre;
                Clase.MtdModificarCerradoCorte();
                if (Clase.Exito)
                {
                    if (Cierre == 0)
                    {
                        Bloquear_Corte(true);
                    }
                    else
                    {
                        Bloquear_Corte(false);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [023]");
            }
        }
        private void CargarAccesos()
        {
            CLS_Perfiles_Pantallas Clase = new CLS_Perfiles_Pantallas();
            Clase.Id_Perfil = IdPerfil;
            Clase.MtdSeleccionarAccesosPermisos();
            if (Clase.Exito)
            {

                for (int x = 0; x < Clase.Datos.Rows.Count; x++)
                {
                    Lista.Add(Clase.Datos.Rows[x][0].ToString());
                }
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }
        private Boolean TieneAcceso(String valor)
        {
            foreach (string x in Lista)
            {
                if (x == valor)
                {
                    return true;
                }

            }
            return false;
        }
        private void btn_CerrarOrden_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("023"))
            {
                DialogResult = XtraMessageBox.Show("¿Desea Cerrar la estiba completa?", "Cierre de Estiba", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                    CLS_Cosecha_Datos Clase = new CLS_Cosecha_Datos();
                    Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
                    Clase.Usuario = UsuariosLogin;
                    Clase.Cerrado = 1;
                    Clase.MtdModificarCerradoOrdenCorte();

                    if (Clase.Exito)
                    {
                        Bloquear_OrdenCorte(false);
                        Cerrar_Recepcion(1);
                        Cerrar_Productor(1);
                        Cerrar_Comercializacion(1);
                        Cerrar_Corte(1);
                        Cerrar_Acarreo(1);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [023]");
            }

        }
        private void btn_AbrirOrden_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("023"))
            {
                DialogResult = XtraMessageBox.Show("¿Desea Abrir la estiba completa?", "Apertura de Estiba", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                    CLS_Cosecha_Datos Clase = new CLS_Cosecha_Datos();
                    Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
                    Clase.Usuario = UsuariosLogin;
                    Clase.Cerrado = 1;
                    Clase.MtdModificarCerradoOrdenCorte();

                    if (Clase.Exito)
                    {
                        Bloquear_OrdenCorte(true);
                        Cerrar_Recepcion(0);
                        Cerrar_Productor(0);
                        Cerrar_Comercializacion(0);
                        Cerrar_Corte(0);
                        Cerrar_Acarreo(0);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [023]");
            }
        }

        private void dt_FechaFacturaProductor_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dt_FechaFacturaProductor.DateTime, dt_FechaProgramaProductor.DateTime) > 0 && vCarga == 0)
            {
                XtraMessageBox.Show("La fecha de Factura debe ser menor a la fecha de pago");
                dt_FechaFacturaProductor.DateTime = vFechaFacturaProductor;
            }
        }

        private void dt_FechaProgramaProductor_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dt_FechaFacturaProductor.DateTime, dt_FechaProgramaProductor.DateTime) > 0 && vCarga == 0)
            {
                XtraMessageBox.Show("LA fecha de Factura debe ser menor a la fecha de pago");
                dt_FechaProgramaProductor.DateTime = vFechaProgramaProductor;
            }
        }

        private void dt_FechaProgramaProductor_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            vFechaProgramaProductor = dt_FechaProgramaProductor.DateTime;
        }

        private void dt_FechaFacturaProductor_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            vFechaFacturaProductor = dt_FechaFacturaProductor.DateTime;
        }

        private void dt_FechaFacturaCorteKilos_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dt_FechaFacturaCorteKilos.DateTime, dt_FechaProgramaCorteKilos.DateTime) > 0 && vCarga == 0)
            {
                XtraMessageBox.Show("La fecha de Factura debe ser menor a la fecha de pago");
                dt_FechaFacturaCorteKilos.DateTime = vFechaFacturaCorteKilos;
            }
        }

        private void dt_FechaProgramaCorteKilos_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dt_FechaFacturaCorteKilos.DateTime, dt_FechaProgramaCorteKilos.DateTime) > 0 && vCarga == 0)
            {
                XtraMessageBox.Show("La fecha de Factura debe ser menor a la fecha de pago");
                dt_FechaProgramaCorteKilos.DateTime = vFechaProgramaCorteKilos;
            }
        }

        private void dt_FechaFacturaCorteKilos_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            vFechaFacturaCorteKilos = dt_FechaFacturaCorteKilos.DateTime;
        }

        private void dt_FechaProgramaCorteKilos_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            vFechaProgramaCorteKilos = dt_FechaProgramaCorteKilos.DateTime;
        }

        private void dt_FechaFacturaCorteDia_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dt_FechaFacturaCorteDia.DateTime, dt_FechaProgramaCorteDia.DateTime) > 0 && vCarga == 0)
            {
                XtraMessageBox.Show("La fecha de Factura debe ser menor a la fecha de Programa");
                dt_FechaFacturaCorteDia.DateTime = vFechaFacturaCorteDia;
            }
        }

        private void dt_FechaProgramaCorteDia_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dt_FechaFacturaCorteDia.DateTime, dt_FechaProgramaCorteDia.DateTime) > 0 && vCarga == 0)
            {
                XtraMessageBox.Show("La fecha de Factura debe ser menor a la fecha de Programa");
                dt_FechaProgramaCorteDia.DateTime = vFechaProgramaCorteDia;
            }
        }

        private void dt_FechaFacturaCorteDia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            vFechaFacturaCorteDia = dt_FechaFacturaCorteDia.DateTime;
        }

        private void dt_FechaProgramaCorteDia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            vFechaProgramaCorteDia = dt_FechaProgramaCorteDia.DateTime;
        }

        private void dt_FechaFacturaCorteApoyo_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dt_FechaFacturaCorteApoyo.DateTime, dt_FechaProgramaCorteApoyo.DateTime) > 0 && vCarga == 0)
            {
                XtraMessageBox.Show("La fecha de Factura debe ser menor a la fecha de Programa");
                dt_FechaFacturaCorteApoyo.DateTime = vFechaFacturaCorteApoyo;
            }
        }

        private void dt_FechaProgramaCorteApoyo_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dt_FechaFacturaCorteApoyo.DateTime, dt_FechaProgramaCorteApoyo.DateTime) > 0 && vCarga == 0)
            {
                XtraMessageBox.Show("La fecha de Factura debe ser menor a la fecha de pago");
                dt_FechaProgramaCorteApoyo.DateTime = vFechaProgramaCorteApoyo;
            }
        }

        private void dt_FechaFacturaCorteApoyo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            vFechaFacturaCorteApoyo = dt_FechaFacturaCorteApoyo.DateTime;
        }

        private void dt_FechaProgramaCorteApoyo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            vFechaProgramaCorteApoyo = dt_FechaProgramaCorteApoyo.DateTime;
        }

        private void dt_FechaFacturaCorteSalida_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dt_FechaFacturaCorteSalida.DateTime, dt_FechaProgramaCorteSalida.DateTime) > 0 && vCarga == 0)
            {
                XtraMessageBox.Show("La fecha de Factura debe ser menor a la fecha de pago");
                dt_FechaFacturaCorteSalida.DateTime = vFechaFacturaCorteSalida;
            }
        }

        private void dt_FechaProgramaCorteSalida_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dt_FechaFacturaCorteSalida.DateTime, dt_FechaProgramaCorteSalida.DateTime) > 0 && vCarga == 0)
            {
                XtraMessageBox.Show("La fecha de Factura debe ser menor a la fecha de pago");
                dt_FechaProgramaCorteSalida.DateTime = vFechaProgramaCorteSalida;
            }
        }

        private void dt_FechaFacturaCorteSalida_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            vFechaFacturaCorteSalida = dt_FechaFacturaCorteSalida.DateTime;
        }

        private void dt_FechaProgramaCorteSalida_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            vFechaProgramaCorteSalida = dt_FechaProgramaCorteSalida.DateTime;
        }

        private void dt_FechaFacturaAcarreo_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dt_FechaFacturaAcarreo.DateTime, dt_FechaProgramaAcarreo.DateTime) > 0 && vCarga == 0)
            {
                XtraMessageBox.Show("La fecha de Factura debe ser menor a la fecha de pago");
                dt_FechaFacturaAcarreo.DateTime = vFechaFacturaAcarreo;
            }
        }

        private void dt_FechaProgramaAcarreo_EditValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dt_FechaFacturaAcarreo.DateTime, dt_FechaProgramaAcarreo.DateTime) > 0 && vCarga == 0)
            {
                XtraMessageBox.Show("La fecha de Factura debe ser menor a la fecha de pago");
                dt_FechaProgramaAcarreo.DateTime = vFechaProgramaAcarreo;
            }
        }

        private void dt_FechaFacturaAcarreo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            vFechaFacturaAcarreo = dt_FechaFacturaAcarreo.DateTime;
        }

        private void dt_FechaProgramaAcarreo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            vFechaProgramaAcarreo = dt_FechaProgramaAcarreo.DateTime;
        }

        private void btn_ActualizarAcopiador_Click(object sender, EventArgs e)
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
                    txt_Acopiador.Text = sel.Datos.Rows[0]["v_nombre_zon"].ToString();
                    txt_Acopiador.Tag = sel.Datos.Rows[0]["c_codigo_zon"].ToString();
                    XtraMessageBox.Show("Se ha actualizado registro");
                }
            }
            else
            {
                XtraMessageBox.Show("No se encontraron registros");
            }
        }

        private void txt_PrecioKiloCorte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CalcularCostosCorte();
            }
        }

        private void btn_UpPDFTarjeta_APEAM_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                vRutaTarjetaApeam = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }

        private void btn_UpPDFIdntificacion_IFE_INE_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                vRutaIdentificacion_INE_IFE = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }

        private void btn_UpPDFOpinion_Cumplimiento_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                vRutaOpinion_Cumplimiento = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }

        private void btn_UpPDFConstancia_Situacion_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                vRutaConstancia_de_Situacion_Fiscal = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }

        private void btn_UpPDFClaveInterbancaria_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                vRutaClave_Interbancaria = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }

        private void btn_UpPDFContratoTerceros_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                vRutaContrato_entre_Terceros = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }

        private void btn_UpPDFContratoGEST_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                vRutaContrato_GEST = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }
        private void CargarExpediente(int Archivo)
        {
            Frm_ViewExpedientePDF frm = new Frm_ViewExpedientePDF();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = Archivo;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
        }
        private void btn_ViewPDFTarjetaAPEAM_Click(object sender, EventArgs e)
        {
            CargarExpediente(1);
        }
        private void btn_ViewPDFIdentificacion_IFE_INE_Click(object sender, EventArgs e)
        {
            CargarExpediente(2);
        }
        private void btn_ViewPDFOpinionCumplimiento_Click(object sender, EventArgs e)
        {
            CargarExpediente(3);
        }
        private void btn_ViewPDFConstanciaSituacion_Click(object sender, EventArgs e)
        {
            CargarExpediente(4);
        }
        private void btn_ViewPDFClaveInterbancaria_Click(object sender, EventArgs e)
        {
            CargarExpediente(5);
        }
        private void btn_ViewPDFContratoTerceros_Click(object sender, EventArgs e)
        {
            CargarExpediente(6);
        }
        private void btn_ViewPDFContratoGEST_Click(object sender, EventArgs e)
        {
            CargarExpediente(7);
        }
        private void EliminarExpediente(int Archivo)
        {
            if (txt_IdCosecha.Text.Trim() != String.Empty)
            {
                CLS_Cosecha_Expedientes Clase = new CLS_Cosecha_Expedientes();
                Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
                Clase.Id_Doc = Archivo;
                Clase.ArchivoPDF = Encoding.UTF8.GetBytes("");
                Clase.Usuario = UsuariosLogin;
                Clase.MtdDeleteCosechaArchivoPDFXML();
                if (!Clase.Exito)
                {
                    XtraMessageBox.Show(Clase.Mensaje);
                }
            }
            SelectExpedientesProductor();
        }
        private void btn_DelTarjetaAPEAM_Click(object sender, EventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar el expediente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                EliminarExpediente(1);
            }
        }

        private void btn_DelIdentificacion_IFE_INE_Click(object sender, EventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar el expediente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                EliminarExpediente(2);
            }
        }

        private void btn_DelOpinionCumplimiento_Click(object sender, EventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar el expediente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                EliminarExpediente(3);
            }
        }

        private void btn_DelConstanciaSituacion_Click(object sender, EventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar el expediente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                EliminarExpediente(4);
            }
        }

        private void btn_DelClaveInterbancaria_Click(object sender, EventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar el expediente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                EliminarExpediente(5);
            }
        }

        private void btn_DelContratoTerceros_Click(object sender, EventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar el expediente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                EliminarExpediente(6);
            }
        }

        private void btn_DelContratoGEST_Click(object sender, EventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar el expediente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                EliminarExpediente(7);
            }
        }

        private void btn_UpPDFComercializadora_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                vRutaContratoComercializadora = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }
        private void CargarContratoComercializadora(int Archivo)
        {
            Frm_ViewExpedientePDF frm = new Frm_ViewExpedientePDF();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = Archivo;
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
        }
        private void btn_ViewPDFComercializadora_Click(object sender, EventArgs e)
        {
            CargarExpediente(8);
        }
        private void EliminarContrato()
        {
            if (txt_IdCosecha.Text.Trim() != String.Empty)
            {
                CLS_Cosecha_Datos Clase = new CLS_Cosecha_Datos();
                Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
                Clase.Contrato = Encoding.UTF8.GetBytes("");
                Clase.Usuario = UsuariosLogin;
                Clase.MtdEliminarContratoComercializadora();
                if (!Clase.Exito)
                {
                    XtraMessageBox.Show(Clase.Mensaje);
                }
            }
            SelectExpedientesProductor();
        }
        private void btn_DelContratoComercializadora_Click(object sender, EventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar el Contrato?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                EliminarContrato();
            }
        }

        private void btn_PDFGrid_Click(object sender, EventArgs e)
        {
            Frm_ViewExpedientePDF frm = new Frm_ViewExpedientePDF();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 9;
            frm.UUID= dtgValFacturasREP.GetFocusedRowCellValue("UUID").ToString();
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
        }

        private void btn_XMLGrid_Click(object sender, EventArgs e)
        {
            Frm_ViewXML frm = new Frm_ViewXML();
            frm.Id_Cosecha = txt_IdCosecha.Text.Trim();
            frm.Id_Archivo = 7;
            frm.UUID = dtgValFacturasREP.GetFocusedRowCellValue("UUID").ToString();
            frm.ShowDialog();
            frm.Dispose();
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewXML.xml");
        }
        private void btn_EliminarREP_Click(object sender, EventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar el REP?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                CLS_Cosecha_Facturas del = new CLS_Cosecha_Facturas();
                del.Id_Cosecha = txt_IdCosecha.Text.Trim();
                del.UUID = dtgValFacturasREP.GetFocusedRowCellValue("UUID").ToString();
                del.MtdDeleteCosechaArchivoREP_PDFXML();
                if (del.Exito)
                {
                    XtraMessageBox.Show("Se ha Eliminado el REP con exito");
                    CargarREP();
                    CalcularTotalREP();
                }
            }
        }
        private void btn_UpXMLREP_Click(object sender, EventArgs e)
        {
            if (txt_IdCosecha.Text != String.Empty)
            {
                DialogResult result = FileDialogXML();
                if (result == DialogResult.OK)
                {
                    
                    GuardarRuta(OpenDialog.FileName);
                    string vMetodo = string.Empty;
                    try
                    {
                        string Valor = String.Empty;
                        XmlDocument doc = new XmlDocument();
                        doc.Load(OpenDialog.FileName);
                        XmlNode nodoDocumentoRel = doc.GetElementsByTagName("pago10:DoctoRelacionado").Item(0);
                        if(txt_UUID.Text== nodoDocumentoRel.Attributes["IdDocumento"].Value)
                        {
                            txt_RutaXMLREP.Text = OpenDialog.FileName;
                            XmlNode nodoComplemento = doc.GetElementsByTagName("tfd:TimbreFiscalDigital").Item(0);
                            Valor = nodoComplemento.Attributes["UUID"].Value;
                            txt_UUID_REP.Text = Valor;
                            Valor = nodoDocumentoRel.Attributes["ImpPagado"].Value;
                            txt_Total_REP.Text = Valor;
                        }
                        else
                        {
                            XtraMessageBox.Show("El Archivo REP no corresponde a este CFDI");
                        }
                    }
                    catch
                    {
                        txt_RutaXMLProductor.Text = String.Empty;
                        XtraMessageBox.Show("No es un Archivo REP Valido favor de verificarlo");
                    }
                }
                OpenDialog.Dispose();
            }
            else
            {
                XtraMessageBox.Show("No se ha guardado o definido un folio de cosecha");
            }
        }

        private void btn_UpPDFREP_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                txt_RutaPDFREP.Text = OpenDialog.FileName;
                GuardarRuta(OpenDialog.FileName);
            }
            OpenDialog.Dispose();
        }

        void LimpiarPPD()
        {
            txt_RutaPDFREP.Text = String.Empty;
            txt_RutaXMLREP.Text=String.Empty;
            txt_UUID_REP.Text = String.Empty;
            txt_Total_REP.Text= String.Empty;
        }
        private void btn_AgregarREP_Click(object sender, EventArgs e)
        {
            if (txt_RutaPDFREP.Text != String.Empty && txt_RutaXMLREP.Text != String.Empty)
            {
                Byte[] ArchivoPDF = null;
                Byte[] ArchivoXML = null;

                FileStream fsPDF = null;
                FileStream fsXML = null;

                Boolean noentroPDF = true, noentroXML = true;


                if (txt_RutaPDFREP.Text.Length > 0)
                {
                    //txtNombreArchivoPDF.Text = result2;
                    //string ar = OpenDialog.FileName;
                    fsPDF = new FileStream(txt_RutaPDFREP.Text, FileMode.Open, FileAccess.Read);
                    //Creamos un array de bytes para almacenar los datos leídos por fs.
                    ArchivoPDF = new byte[fsPDF.Length];
                    //Y guardamos los datos en el array data
                    fsPDF.Read(ArchivoPDF, 0, (int)fsPDF.Length);
                    ArchivoPDFGlobalProductorREP = ArchivoPDF;
                }
                else
                {
                    ArchivoPDF = ArchivoPDFGlobalProductorREP;
                    noentroPDF = false;
                }
                if (txt_RutaXMLREP.Text.Length > 0)
                {
                    fsXML = new FileStream(txt_RutaXMLREP.Text, FileMode.Open);
                    //Creamos un array de bytes para almacenar los datos leídos por fs.
                    ArchivoXML = new byte[fsXML.Length];
                    //Y guardamos los datos en el array data
                    fsXML.Read(ArchivoXML, 0, Convert.ToInt32(fsXML.Length));
                    ArchivoXMLGlobalProductorREP = ArchivoXML;
                }
                else
                {
                    ArchivoXML = ArchivoXMLGlobalProductorREP;
                    noentroXML = false;
                }

                CLS_Cosecha_Facturas Clase = new CLS_Cosecha_Facturas();
                Clase.Id_Cosecha = txt_IdCosecha.Text.Trim();
                Clase.UUID = txt_UUID_REP.Text;
                Clase.FacturaTotal = Decimal.Parse(txt_Total_REP.Text, style, provider);
                if (ArchivoPDF != null)
                {
                    Clase.FacturaPDF = ArchivoPDF;
                }
                else
                {
                    Clase.FacturaPDF = Encoding.UTF8.GetBytes("");
                }

                if (ArchivoXML != null)
                {
                    Clase.FacturaXML = ArchivoXML;
                }
                else
                {
                    Clase.FacturaXML = Encoding.UTF8.GetBytes("");
                }

                Clase.Usuario = UsuariosLogin;

                Clase.MtdInsertarCosechaArchivoREP_PDFXML();
                if (!Clase.Exito)
                {
                    XtraMessageBox.Show(Clase.Mensaje);
                }
                else
                {
                    LimpiarPPD();
                    CargarREP();
                    CalcularTotalREP();
                }
                if (noentroXML)
                {
                    fsXML.Close();
                }
                if (noentroPDF)
                {
                    fsPDF.Close();
                }
            }
            else
            {
                XtraMessageBox.Show("Se debe de cargar PDF y XML");
            }
        }
        private void btn_CalcularFechaPagoK_Click(object sender, EventArgs e)
        {
            CalcularFechaPrograma8(dt_FechaRecepcion.DateTime,1);
        }

        private void btn_CalcularFechaPagoD_Click(object sender, EventArgs e)
        {
            CalcularFechaPrograma8(dt_FechaRecepcion.DateTime,2);
        }

        private void btn_CalcularFechaPagoA_Click(object sender, EventArgs e)
        {
            CalcularFechaPrograma8(dt_FechaRecepcion.DateTime,3);
        }

        private void btn_CalcularFechaPagoS_Click(object sender, EventArgs e)
        {
            CalcularFechaPrograma8(dt_FechaRecepcion.DateTime,4);
        }

        private void btn_CalcularFechaPagoAC_Click(object sender, EventArgs e)
        {
            CalcularFechaPrograma8(dt_FechaRecepcion.DateTime,5);
        }

        private void btn_RecargarTem_Click(object sender, EventArgs e)
        {
            CargarCosechas();
        }
    }
}