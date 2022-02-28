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

namespace Business_Analitics
{
    public partial class Frm_Cosecha : DevExpress.XtraEditors.XtraForm
    {
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


            txt_KiloPrecio.Properties.Mask.UseMaskAsDisplayFormat = true;
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
            btn_limpiarOrden.PerformClick();
            txt_ProgramaCorte.Text = frm.Id_ProgramaCorte;
            txt_Temporada.Text = frm.v_temporada;
            txt_Secuencia.Text = frm.v_secuencia;
            txt_OrdenCorte.Text = frm.v_ordencorte;
            if (txt_ProgramaCorte.Text != string.Empty && txt_Temporada.Text != string.Empty)
            {
                CargarProgramaCorte();
            }
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
                    txt_Huerta.Tag = sel.Datos.Rows[0]["c_codigo_hue"].ToString();
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

        void CalcularFechaPago(DateTime Fecha)
        {
            //XtraMessageBox.Show(Fecha.ToString("dddd", new CultureInfo("es-MX")));
            switch ((byte)Fecha.DayOfWeek)
            {
                case 0:
                    dt_FechaPagoProductor.DateTime = Fecha.AddDays(19);
                    break;
                case 1:
                    dt_FechaPagoProductor.DateTime = Fecha.AddDays(25);
                    break;
                case 2:
                    dt_FechaPagoProductor.DateTime = Fecha.AddDays(24);
                    break;
                case 3:
                    dt_FechaPagoProductor.DateTime = Fecha.AddDays(23);
                    break;
                case 4:
                    dt_FechaPagoProductor.DateTime = Fecha.AddDays(22);
                    break;
                case 5:
                    dt_FechaPagoProductor.DateTime = Fecha.AddDays(21);
                    break;
                case 6:
                    dt_FechaPagoProductor.DateTime = Fecha.AddDays(20);
                    break;
                default:
                    break;
               
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
                    CalcularFechaPago(dt_FechaRecepcion.DateTime);
                    txt_Recepcion.Text = sel.Datos.Rows[0]["c_codigo_rec"].ToString();
                    txt_EstibaSel.Text = sel.Datos.Rows[0]["c_codigo_sel"].ToString();
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
                        CorridaBanda();
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

        private void btn_EmpresaComercializacion_Click(object sender, EventArgs e)
        {
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
            Contacto.MtdSeleccionarContacto();
            if (Contacto.Exito)
            {
                txtNombreContacto.Text = Contacto.Datos.Rows[0]["Nombre_Contacto"].ToString();
                txtTelefonoContacto.Text = Contacto.Datos.Rows[0]["Telefono_Contacto"].ToString();
                txtCorreoContacto.Text = Contacto.Datos.Rows[0]["EMail_Contacto"].ToString();
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
                txt_kilosCortadosCorte.Text = txt_kilosST.Text;
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
            if (txt_kilosCortadosCorte.Text != string.Empty)
            {
                chk_SalidaFalso.Enabled = false;
                txt_Margen5.Text = Convert.ToString(Convert.ToDouble(txt_kilosCortadosCorte.Text) * 0.05);
                txt_kgNoSolicitados.Text = CalcularkilosNoDeseados();
                txt_KilosARestar.Text = (Decimal.Parse(txt_Margen5.Text, style, provider) - Decimal.Parse(txt_kgNoSolicitados.Text, style, provider)).ToString();
                if (Decimal.Parse(txt_KilosARestar.Text, style, provider) < 0)
                {
                    txt_KilosAjustadosCorte.Text = (Decimal.Parse(txt_kilosCortadosCorte.Text, style, provider) - (Decimal.Parse(txt_KilosARestar.Text, style, provider)*(-1))).ToString();
                }
                else
                {
                    txt_KilosAjustadosCorte.Text = txt_kilosCortadosCorte.Text;
                }
                if (Decimal.Parse(txt_kilosCortadosCorte.Text, style, provider) > Decimal.Parse(txtMenorakg.Text, style, provider))
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
                    txt_PrecioKiloCorte.Text = "0";
                    txt_PrecioTCorte.Text = "0";
                    txt_PrecioDiaCorte.Text = txtPrecioDia.Text;
                    txt_PagoTotalCorte.Text = txt_PrecioDiaCorte.Text;
                }
                txt_PrecioSalidaFCorte.Text = "0";
                txt_PrecioCuadrillaCorte.Text = "0";
                chk_SalidaFalso.Checked = false;
                chk_CuadrillaApoyo.Checked = false;
                txt_PagoTotalCorte.Text = (Decimal.Parse(txt_PrecioTCorte.Text, style, provider) + Decimal.Parse(txt_PrecioCuadrillaCorte.Text, style, provider) + Decimal.Parse(txt_PrecioSalidaFCorte.Text, style, provider)).ToString();
            }
            else
            {
                chk_SalidaFalso.Enabled = true;
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
                txt_TotalAcarreo.EditValue = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider)).ToString();
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
                vtotalPorcentaje = Decimal.Parse(selRec.Datos.Rows[0]["Porcentaje"].ToString());
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
                vtotalExp = Decimal.Parse(selExt.Datos.Rows[0]["PesoRealExp"].ToString());
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
                vtotalNal = Decimal.Parse(selNal.Datos.Rows[0]["PesoRealNal"].ToString());
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
                    txt_PrecioCuadrillaCorte.Text = txtPrecioCuadrillaA.Text;
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
                CargarServiciosAcarreo();
                CargarCamiones(null);
                CargarChoferes(null);
                CalcularCostosAcarreo();
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
                txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider)+ Decimal.Parse(txt_CargosExtra.Text, style, provider)).ToString();
            }
        }

        private void txt_CajasExtras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(txt_CajasExtras.Text))
                {
                    txt_CostoxCajaExtra.Text = (Decimal.Parse(txt_CajasExtras.Text, style, provider) * Decimal.Parse(txtPrecioCaja.Text, style, provider)).ToString();
                    txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider)).ToString();
                }
            }
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
                txt_kilosCortadosCorte.Text = txt_kilosST.Text;
                txt_KilosAjustados.Text = txt_kilosST.Text;
                txt_kilos_Totales.Text = Convert.ToString(Convert.ToInt32(Decimal.Parse(txt_KilosAjustados.Text, style, provider)) - Convert.ToInt32(Decimal.Parse(txt_KilosMuestra.Text, style, provider)));
            }
            else
            {
                CalcularTotalRecepcion();
            }
            CalcularkilosTipoMercado();
            CalcularCostosCorte();

        }
        private void btn_UpPDFProductor_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                txt_RutaPDFProductor.Text = OpenDialog.FileName;
            }
        }
        private void btn_UpXMLProductor_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialogXML();
            if (result == DialogResult.OK)
            {
                txt_RutaXMLProductor.Text = OpenDialog.FileName;
            }
        }
        private DialogResult FileDialogPDF()
        {
            OpenDialog.FileName = string.Empty;
            OpenDialog.Filter = "Portable Document Format (*.PDF)|*.PDF";
            OpenDialog.FilterIndex = 1;
            OpenDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
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
            OpenDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
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
            chk_kgProductor.Checked = false;
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
            chk_IVAProductor.Checked = false;
            chk_PagadaProductor.Checked = false;
            dt_FechaFacturaProductor.DateTime = DateTime.Now;
            dt_FechaPagoProductor.DateTime = DateTime.Now;
            opt_TipoFacturaProductor.SelectedIndex = 0;
            btn_ViewPDFProductor.Enabled = false;
            btn_ViewXMLProductor.Enabled = false;
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
            chk_IVACorteKilos.Checked = false;
            chk_PagadaCorteKilos.Checked = false;
            dt_FechaFacturaCorteKilos.DateTime = DateTime.Now;
            dt_FechaPagoCorteKilos.DateTime = DateTime.Now;
            opt_TipoFacturaCorteKilos.SelectedIndex = 0;
            btn_ViewPDFCorteKilos.Enabled = false;
            btn_ViewXMLCorteKilos.Enabled = false;
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
            chk_IVACorteDia.Checked = false;
            chk_PagadaCorteDia.Checked = false;
            dt_FechaFacturaCorteDia.DateTime = DateTime.Now;
            dt_FechaPagoCorteDia.DateTime = DateTime.Now;
            opt_TipoFacturaCorteDia.SelectedIndex = 0;
            btn_ViewPDFCorteDia.Enabled = false;
            btn_ViewXMLCorteDia.Enabled = false;
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
            chk_IVACorteApoyo.Checked = false;
            chk_PagadaCorteApoyo.Checked = false;
            dt_FechaFacturaCorteApoyo.DateTime = DateTime.Now;
            dt_FechaPagoCorteApoyo.DateTime = DateTime.Now;
            opt_TipoFacturaCorteApoyo.SelectedIndex = 0;
            btn_ViewPDFCorteApoyo.Enabled = false;
            btn_ViewXMLCorteApoyo.Enabled = false;
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
            chk_IVACorteSalida.Checked = false;
            chk_PagadaCorteSalida.Checked = false;
            dt_FechaFacturaCorteSalida.DateTime = DateTime.Now;
            dt_FechaPagoCorteSalida.DateTime = DateTime.Now;
            opt_TipoFacturaCorteSalida.SelectedIndex = 0;
            btn_ViewPDFCorteSalida.Enabled = false;
            btn_ViewXMLCorteSalida.Enabled = false;
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
            opt_TipoFacturaAcarreo.SelectedIndex = 0;
            btn_ViewPDFAcarreo.Enabled = false;
            btn_ViewXMLAcarreo.Enabled = false;
        }
        private void btn_limpiarOrden_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarOrdenCorte();
            LimpiarRecepcion();
            LimpiarComercializadora();
            LimpiarProductor();
            LimpiarCorte();
            LimpiarAcarreo();
            LimpiarFacturasProductor();
            LimpiarFacturasKilos();
            LimpiarFacturasDia();
            LimpiarFacturasApoyo();
            LimpiarFacturasSalida();
            LimpiarFacturasAcarreo();
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
                GuardarProductor();
                GuardarCorte();
                GuardarAcarreo();
                GuardarFacturas();
                SelectFacturas();
            }
            CargarCosechas();
            XtraMessageBox.Show("Se ha guardado el registro con exito");
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
            if (opt_TipoFacturaProductor.SelectedIndex == 0)
            {
                Clase.Diferido = 1;
            }
            else
            {
                Clase.Diferido = 0;
            }

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
            Clase.Retencion_Flete = 0;
            Clase.Importe_Retencion_Flete = 0;
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
            if (opt_TipoFacturaCorteKilos.SelectedIndex == 0)
            {
                Clase.Diferido = 1;
            }
            else
            {
                Clase.Diferido = 0;
            }

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
            Clase.Retencion_Flete = 0;
            Clase.Importe_Retencion_Flete = 0;
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
            if (opt_TipoFacturaCorteDia.SelectedIndex == 0)
            {
                Clase.Diferido = 1;
            }
            else
            {
                Clase.Diferido = 0;
            }

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
            if (opt_TipoFacturaCorteApoyo.SelectedIndex == 0)
            {
                Clase.Diferido = 1;
            }
            else
            {
                Clase.Diferido = 0;
            }

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
            Clase.Retencion_Flete = 0;
            Clase.Importe_Retencion_Flete = 0;
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
            if (opt_TipoFacturaCorteSalida.SelectedIndex == 0)
            {
                Clase.Diferido = 1;
            }
            else
            {
                Clase.Diferido = 0;
            }

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
            if (opt_TipoFacturaAcarreo.SelectedIndex == 0)
            {
                Clase.Diferido = 1;
            }
            else
            {
                Clase.Diferido = 0;
            }

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
                ins.Acopiador = txt_Acopiador.Text;
                ins.ProgramaCajas = Convert.ToInt32(txt_Cajas_Programa.EditValue);
                ins.TipoCorte = txt_TipoCorte.Text;
                ins.Usuario = UsuariosLogin;
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
            ins.Usuario = UsuariosLogin;
            ins.MtdInsertarComercializadora();
            if (!ins.Exito)
            {
                XtraMessageBox.Show(ins.Mensaje);
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
                ins.Nombre_Camion = cmb_Camiones.EditValue.ToString();
            }
            catch (Exception)
            {
                ins.Nombre_Camion = string.Empty;
            }
            ins.Placas = txtPlacasCamion.Text;
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
            }
            OpenDialog.Dispose();
        }

        private void btn_UpPDFAcarreo_Click(object sender, EventArgs e)
        {
            OpenDialog.FileName = String.Empty;
            DialogResult result = FileDialogPDF();
            if (result == DialogResult.OK)
            {
                txt_RutaPDFAcarreo.Text = OpenDialog.FileName;
            }
            OpenDialog.Dispose();
        }

        private void btn_UpXMLCorteKilos_Click(object sender, EventArgs e)
        {
            OpenDialog.FileName = String.Empty;
            DialogResult result = FileDialogXML();
            if (result == DialogResult.OK)
            {
                txt_RutaXMLCorteKilos.Text = OpenDialog.FileName;
            }
            OpenDialog?.Dispose();
        }

        private void btn_UpXMLCorteDia_Click(object sender, EventArgs e)
        {
            OpenDialog.FileName = String.Empty;
            DialogResult result = FileDialogXML();
            if (result == DialogResult.OK)
            {
                txt_RutaXMLCorteDia.Text = OpenDialog.FileName;
            }
            OpenDialog.Dispose();
        }

        private void btn_UpXMLCorteApoyo_Click(object sender, EventArgs e)
        {
            OpenDialog.FileName = String.Empty;
            DialogResult result = FileDialogXML();
            if (result == DialogResult.OK)
            {
                txt_RutaXMLCorteApoyo.Text = OpenDialog.FileName;
            }
            OpenDialog?.Dispose();
        }

        private void btn_UpXMLCorteSalida_Click(object sender, EventArgs e)
        {
            OpenDialog.FileName = String.Empty;
            DialogResult result = FileDialogXML();
            if (result == DialogResult.OK)
            {
                txt_RutaXMLCorteSalida.Text = OpenDialog.FileName;
            }
            OpenDialog?.Dispose();
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
                    txt_Acopiador.Text = ins.Datos.Rows[0]["Acopiador"].ToString();
                    txt_Cajas_Programa.EditValue = ins.Datos.Rows[0]["ProgramaCajas"].ToString();
                    txt_TipoCorte.Text = ins.Datos.Rows[0]["TipoCorte"].ToString();
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
                    if (ins.Datos.Rows[0]["TomarkgProductor"].ToString() == "1")
                    {
                        chk_kgProductor.Checked = true;

                    }
                    else
                    {
                        chk_kgProductor.Checked = false;
                    }
                    txt_KilosDiferencia.EditValue = ins.Datos.Rows[0]["KilosDiferencia"].ToString();
                    txt_KilosAjuste.EditValue = ins.Datos.Rows[0]["Ajuste"].ToString();
                    txt_kilosST.EditValue = ins.Datos.Rows[0]["KilosST"].ToString();
                    txt_KilosProductor.EditValue = ins.Datos.Rows[0]["KilosProductor"].ToString();
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
                        txt_EmpresaComercializadora.Tag = ins.Datos.Rows[0]["Id_EmpresaComercializacion"].ToString();
                    }
                    catch (Exception)
                    {
                        ins.Id_EmpresaComercializacion = string.Empty;
                    }
                    //aqui me quede
                    txt_EmpresaComercializadora.Text = ins.Datos.Rows[0]["Nombre_EmpresaComercializacion"].ToString();
                    txtNombreContacto.Text = ins.Datos.Rows[0]["Nombre_Contacto"].ToString();
                    txtTelefonoContacto.Text = ins.Datos.Rows[0]["Telefono_Contacto"].ToString();
                    txtCorreoContacto.Text = ins.Datos.Rows[0]["Email_Contacto"].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
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
                    txt_KilosAjustados.EditValue = ins.Datos.Rows[0]["KilosAjustados"].ToString();
                    txt_KilosMuestra.EditValue = ins.Datos.Rows[0]["KilosMuestra"].ToString();
                    txt_kilos_Totales.EditValue = ins.Datos.Rows[0]["KilosaPagar"].ToString();
                    txt_KiloPrecio.EditValue = ins.Datos.Rows[0]["Preciokg"].ToString();
                    txt_TotalaPagar.EditValue = ins.Datos.Rows[0]["TotalaPagar"].ToString();
                    txt_ObservacionesProductor.Text= ins.Datos.Rows[0]["Observaciones"].ToString();
                    if (ins.Datos.Rows[0]["Exportacion"].ToString() == "True")
                    {
                        chk_Mercado.Checked = true;

                    }
                    else
                    {
                        chk_Mercado.Checked = false;
                    }
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
                    CargarServiciosAcarreo();
                    CargarCamiones(ins.Datos.Rows[0]["Id_Camion"].ToString());
                    CargarChoferes(ins.Datos.Rows[0]["Id_Chofer"].ToString());
                    txtPlacasCamion.Text = ins.Datos.Rows[0]["Placas"].ToString();
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
                    txt_TotalAcarreo.EditValue = ins.Datos.Rows[0]["TotalAcarreo"].ToString();
                    txt_ObservacionesAcarreo.Text = ins.Datos.Rows[0]["Observaciones"].ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
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
                    if (ArchivoPDFGlobalProductor.Length>0)
                    {
                        btn_ViewPDFProductor.Enabled=true;
                    }
                    else
                    {
                        btn_ViewPDFProductor.Enabled = false;
                    }
                    if(ArchivoXMLGlobalProductor.Length > 0)
                    {
                        btn_ViewXMLProductor.Enabled = true;
                    }
                    else
                    {
                        btn_ViewXMLProductor.Enabled = false;
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

                    if (ins.Datos.Rows[0]["Diferido"].ToString() == "True")
                    {
                        opt_TipoFacturaProductor.SelectedIndex = 0;
                    }
                    else
                    {
                        opt_TipoFacturaProductor.SelectedIndex = 1;
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

                    if (ins.Datos.Rows[0]["Diferido"].ToString() == "True")
                    {
                        opt_TipoFacturaCorteKilos.SelectedIndex = 0;
                    }
                    else
                    {
                        opt_TipoFacturaCorteKilos.SelectedIndex = 1;
                    }
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

                    if (ins.Datos.Rows[0]["Diferido"].ToString() == "True")
                    {
                        opt_TipoFacturaCorteDia.SelectedIndex = 0;
                    }
                    else
                    {
                        opt_TipoFacturaCorteDia.SelectedIndex = 1;
                    }
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

                    if (ins.Datos.Rows[0]["Diferido"].ToString() == "True")
                    {
                        opt_TipoFacturaCorteApoyo.SelectedIndex = 0;
                    }
                    else
                    {
                        opt_TipoFacturaCorteApoyo.SelectedIndex = 1;
                    }
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

                    if (ins.Datos.Rows[0]["Diferido"].ToString() == "True")
                    {
                        opt_TipoFacturaCorteSalida.SelectedIndex = 0;
                    }
                    else
                    {
                        opt_TipoFacturaCorteSalida.SelectedIndex = 1;
                    }
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

                    if (ins.Datos.Rows[0]["Diferido"].ToString() == "True")
                    {
                        opt_TipoFacturaAcarreo.SelectedIndex = 0;
                    }
                    else
                    {
                        opt_TipoFacturaAcarreo.SelectedIndex = 1;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }
        void SelectFacturas()
        {
            SelectFacturaProductor();
            SelectFacturaKilos();
            SelectFacturaDia();
            SelectFacturaApoyo();
            SelectFacturaSalida();
            SelectFacturaAcarreo();
        }
        private void dtgCosecha_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValCosecha.GetSelectedRows())
                {
                    DataRow row = this.dtgValCosecha.GetDataRow(i);
                    btn_limpiarOrden.PerformClick();
                    txt_IdCosecha.Text = row["Id_Cosecha"].ToString();
                    CargarCosecha();
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

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
            txt_TotalFacturaAcarreo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaAcarreo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaAcarreo.Text, style, provider))-(Decimal.Parse(txt_RetencionFleteFacturaAcarreo.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaAcarreo.Text, style, provider)));
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
            txt_TotalFacturaAcarreo.Text = Convert.ToString((Decimal.Parse(txt_ImporteFacturaAcarreo.Text, style, provider)) - (Decimal.Parse(txt_RetencionFacturaAcarreo.Text, style, provider)) + (Decimal.Parse(txt_IVAFacturaAcarreo.Text, style, provider)));
        }

        private void txt_TotalAcarreo_EditValueChanged(object sender, EventArgs e)
        {
            txt_ImporteFacturaAcarreo.EditValue = txt_TotalAcarreo.EditValue;
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
                    txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider) + Decimal.Parse(txt_CargosExtra.Text, style, provider)).ToString();
                }
            }
        }

        private void btn_CalcularFechaPago_Click(object sender, EventArgs e)
        {
            CalcularFechaPago(dt_FechaRecepcion.DateTime);
        }

        private void txt_PrecioTCorte_EditValueChanged(object sender, EventArgs e)
        {
            txt_ImporteFacturaCorteKilos.EditValue = txt_PrecioTCorte.EditValue;
            CalcularTotalKilos();
        }

        private void txt_PrecioDiaCorte_EditValueChanged(object sender, EventArgs e)
        {
            txt_ImporteFacturaCorteDia.EditValue=txt_PrecioDiaCorte.EditValue;
            CalcularTotalDia();
        }

        private void txt_PrecioSalidaFCorte_EditValueChanged(object sender, EventArgs e)
        {
            txt_ImporteFacturaCorteSalida.EditValue=txt_PrecioSalidaFCorte.EditValue;
            CalcularTotalSalidaFalso();
        }

        private void txt_PrecioCuadrillaCorte_EditValueChanged(object sender, EventArgs e)
        {
            txt_ImporteFacturaCorteApoyo.EditValue=txt_PrecioCuadrillaCorte.EditValue;
            CalcularTotalApoyo();
        }

        private void txt_NoCuadrillas_EditValueChanged(object sender, EventArgs e)
        {
            CalcularCuadrillasdeApoyo();
        }
    }
}