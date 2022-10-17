using Business_Analitics;
using CapaDeDatos;
using System;
using System.Data;

namespace BusinessAnalitics
{
    public partial class Frm_Cargas : DevExpress.XtraEditors.XtraForm
    {
        public string TemActiva { get; private set; }
        public string UsuariosLogin { get; set; }
        public string IdPerfil { get; set; }
        private static Frm_Cargas m_FormDefInstance;
        public static Frm_Cargas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Cargas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Frm_Cargas()
        {
            InitializeComponent();
        }

        private void Frm_Cargas_Shown(object sender, System.EventArgs e)
        {
            CargarTemporadaActiva();
            CargarTemporada(TemActiva);
            CargarMercado("N");
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
                    cmb_Temporada.Properties.DisplayMember = "c_codigo_tem";
                    cmb_Temporada.Properties.ValueMember = "c_codigo_tem";
                    cmb_Temporada.EditValue = Valor;
                    cmb_Temporada.Properties.DataSource = obtener.Datos;
                }
            }
        }
        private void CargarMercado(string Valor)
        {
            CLS_Cargas obtener = new CLS_Cargas();
            obtener.MtdSelecccionarMercado();
            if (obtener.Exito)
            {
                if (obtener.Datos.Rows.Count > 0)
                {
                    cmb_Mercado.Properties.DisplayMember = "Mercado";
                    cmb_Mercado.Properties.ValueMember = "c_merdes_man";
                    cmb_Mercado.EditValue = Valor;
                    cmb_Mercado.Properties.DataSource = obtener.Datos;
                }
            }
        }

        void BuscarManifiesto()
        {
            CLS_Cargas sel = new CLS_Cargas();
            sel.c_codigo_man = txt_Manifiesto.Text;
            sel.c_codigo_tem = txt_Temporada.Text;
            sel.MtdSeleccionarCargaManifiesto();
            if(sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
                {
                    dt_FechaManifiesto.DateTime = Convert.ToDateTime(sel.Datos.Rows[0]["d_embarque_man"].ToString());
                    txt_Distribuidor.Tag = Convert.ToString(sel.Datos.Rows[0]["c_codigo_dis"].ToString());
                    txt_Distribuidor.Text = Convert.ToString(sel.Datos.Rows[0]["v_nombre_dis"].ToString());
                    txt_Mercado.Text = Convert.ToString(sel.Datos.Rows[0]["Mercado"].ToString());
                    txt_Kilos.Text = Convert.ToString(sel.Datos.Rows[0]["n_peso_pal"].ToString());
                }
            }
        }
        void BuscarCargarProductos()
        {
            CLS_Cargas sel = new CLS_Cargas();
            sel.c_codigo_man = txt_Manifiesto.Text;
            sel.c_codigo_tem = txt_Temporada.Text;
            sel.MtdSeleccionarCargaProductos();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgProductos.DataSource = sel.Datos;
                }
            }
        }
        void BuscarCargarMaquila()
        {
            CLS_Cargas sel = new CLS_Cargas();
            sel.c_codigo_man = txt_Manifiesto.Text;
            sel.c_codigo_tem = txt_Temporada.Text;
            sel.MtdSeleccionarCargaMaquila();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgMaquila.DataSource = sel.Datos;
                }
            }
        }
        private void btnBusqCarga_Click(object sender, System.EventArgs e)
        {
            Frm_BuscarManifiesto frm = new Frm_BuscarManifiesto();
            frm.ShowDialog();
            btn_limpiarOrden.PerformClick();
            txt_Manifiesto.Text = frm.Id_Manifiesto;
            txt_Temporada.Text = frm.v_temporada;
            if (txt_Manifiesto.Text != string.Empty && txt_Temporada.Text != string.Empty)
            {
                BuscarManifiesto();
                BuscarCargarProductos();
                BuscarCargarMaquila();
            }
        }
    }
}