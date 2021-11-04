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
    public partial class Frm_Cosecha : DevExpress.XtraEditors.XtraForm
    {
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
        }

        private void btnBusqProgramaCorte_Click(object sender, EventArgs e)
        {
            Frm_BuscarProgramaCorte frm = new Frm_BuscarProgramaCorte();
            frm.ShowDialog();
            txt_ProgramaCorte.Text = frm.Id_ProgramaCorte;
            txt_Temporada.Text = frm.v_temporada;
            txt_Secuencia.Text = frm.v_secuencia;
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
                    txt_TipoCorte.Text = sel.Datos.Rows[0]["v_tipocorte_pcd"].ToString();
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
            txt_EmpresaComercializadora.Text = frm.Proveedor;
            txt_EmpresaComercializadora.Tag = frm.IdProveedor;
        }

        private void txt_KilosProductor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                int KC = Convert.ToInt32(Convert.ToDecimal(txt_KilosCortados.Text));
                int KP = Convert.ToInt32(Convert.ToDecimal(txt_KilosBasculaE.Text));
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
                    txt_kilos_Totales.Text =Convert.ToString(Convert.ToInt32(Convert.ToDecimal(txt_KilosAjustados.Text))- Convert.ToInt32(Convert.ToDecimal(txt_KilosMuestra.Text)));
                }
                else
                {
                    XtraMessageBox.Show("No se han capturado kilos en recepcion o kilos en bascula productor");
                }
            }
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl32_Click(object sender, EventArgs e)
        {

        }
    }
}