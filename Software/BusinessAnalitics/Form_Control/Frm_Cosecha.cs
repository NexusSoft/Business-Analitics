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
    public partial class Frm_Cosecha : DevExpress.XtraEditors.XtraForm
    {
        NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        CultureInfo provider = new CultureInfo("es-MX");
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
        }

        private void btnBusqProgramaCorte_Click(object sender, EventArgs e)
        {
            Frm_BuscarProgramaCorte frm = new Frm_BuscarProgramaCorte();
            frm.ShowDialog();
            txt_ProgramaCorte.Text = frm.Id_ProgramaCorte;
            txt_Temporada.Text = frm.v_temporada;
            txt_Secuencia.Text = frm.v_secuencia;
            txt_OrdenCorte.Text = frm.v_ordencorte;
            if (txt_ProgramaCorte.Text != string.Empty && txt_Temporada.Text!=string.Empty)
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
            if(sel.Exito)
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
                    txt_OrdenCorte.Text= sel.Datos.Rows[0]["c_codigo_oct"].ToString();
                    txt_Secuencia.Text = sel.Datos.Rows[0]["c_secuencia_ocd"].ToString();
                    txt_Temporada.Text= sel.Datos.Rows[0]["c_codigo_tem"].ToString();
                    txt_Productor.Text= sel.Datos.Rows[0]["v_nombre_dno"].ToString(); 
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
                    txt_CajasCortadas.Text = sel.Datos.Rows[0]["n_cajascorte_red"].ToString();
                    txt_Cajas_CortadasA.Text = sel.Datos.Rows[0]["n_cajascorte_red"].ToString();
                    txt_CajasCortadasCorte.Text = sel.Datos.Rows[0]["n_cajascorte_red"].ToString();
                    txt_KilosCortados.Text = sel.Datos.Rows[0]["n_kilos_red"].ToString();
                    txt_KilosPromedio.Text= sel.Datos.Rows[0]["n_promxcaja_red"].ToString();
                    txt_TipoCultivo.Text = sel.Datos.Rows[0]["v_nombre_cul"].ToString();
                    txt_TipoCultivo.Tag = sel.Datos.Rows[0]["c_codigo_cul"].ToString();
                    txt_TicketPesada.Text = sel.Datos.Rows[0]["c_ticketbas_rec"].ToString();
                    if (txt_EstibaSel.Text != string.Empty && txt_Temporada.Text!=string.Empty)
                    {
                        CargarCorrida();
                        CargarExportacion();
                        CargarNacional();
                        CargarMerma();
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
            if(sel.Exito)
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
                if(Decimal.Parse(txt_KilosARestar.Text, style, provider) <0)
                {
                    txt_KilosAjustadosCorte.Text = (Decimal.Parse(txt_kilosCortadosCorte.Text, style, provider) - Decimal.Parse(txt_KilosARestar.Text, style, provider)).ToString();
                }
                else
                {
                    txt_KilosAjustadosCorte.Text = txt_kilosCortadosCorte.Text;
                }
                if (Decimal.Parse(txt_kilosCortadosCorte.Text, style, provider) > Decimal.Parse(txtMenorakg.Text, style, provider))
                {
                    txt_PrecioKiloCorte.Text = txtPreciokg.Text;
                    if (chk_RangoCajas.Checked==false)
                    {
                        txt_PrecioTCorte.Text = (Decimal.Parse(txt_KilosAjustadosCorte.Text, style, provider) * Decimal.Parse(txt_PrecioKiloCorte.Text, style, provider)).ToString();
                    }
                    else
                    {
                        if(Decimal.Parse(txt_CajasCortadasCorte.Text, style, provider) < Decimal.Parse(txtCajasMenorA.Text, style, provider))
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
                txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider)).ToString();
            }
            else
            {
                chk_SalidaFalso.Enabled = true;
            }
        }
        private string CalcularkilosNoDeseados()
        {
            string vTotal = string.Empty;
            decimal vtotalExp=0, vtotalNal=0, vtotalPorcentaje=0;
            CLS_CorridaFruta selRec = new CLS_CorridaFruta();
            selRec.c_codigo_tem = txt_Temporada.Text;
            selRec.c_codigo_sel = txt_EstibaSel.Text;
            selRec.c_codigo_rec = txt_Recepcion.Text;
            selRec.MtdSeleccionarRecepcionCorte();
            if (selRec.Exito)
            {
                vtotalPorcentaje =Decimal.Parse(selRec.Datos.Rows[0]["Porcentaje"].ToString());
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
            vTotal = Math.Round(((vtotalExp + vtotalNal) * vtotalPorcentaje),4).ToString();
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
                        txt_PrecioCuadrillaCorte.Text = txtPrecioMenorA.Text;
                    }
                    else
                    {
                        txt_PrecioCuadrillaCorte.Text = txtPrecioMayorA.Text;
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
            if(Decimal.Parse(txt_KilosARestar.Text, style, provider) >0)
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
                txt_TotalaPagar.Text = (Decimal.Parse(txt_KiloPrecio.Text, style, provider) * Decimal.Parse(txt_kilos_Totales.Text, style, provider)).ToString();
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
                txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider)).ToString();
            }
        }

        private void txt_CajasExtras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if(!string.IsNullOrEmpty(txt_CajasExtras.Text))
                {
                    txt_CostoxCajaExtra.Text = (Decimal.Parse(txt_CajasExtras.Text, style, provider) * Decimal.Parse(txtPrecioCaja.Text, style, provider)).ToString();
                    txt_TotalAcarreo.Text = (Decimal.Parse(txt_CostoServicio.Text, style, provider) + Decimal.Parse(txt_CostoxCajaExtra.Text, style, provider)).ToString();
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

        private void txt_PrecioDiaCorte_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_PrecioCuadrillaCorte_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}