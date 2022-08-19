using Business_Analitics;
using CapaDeDatos;
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
    }
}