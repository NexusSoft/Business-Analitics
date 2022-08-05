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
    public partial class Frm_BuscarProgramaCorte : DevExpress.XtraEditors.XtraForm
    {
        public string TemActiva { get; private set; }
        public string Id_ProgramaCorte { get;  set; }
        public string v_temporada { get;  set; }
        public string v_secuencia { get;  set; }
        public string v_ordencorte { get; set; }

        public Frm_BuscarProgramaCorte()
        {
            InitializeComponent();
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

        private void Frm_BuscarProgramaCorte_Shown(object sender, EventArgs e)
        {
            Id_ProgramaCorte = string.Empty;
            CargarTemporadaActiva();
            CargarTemporada(TemActiva);
            Cargar_Programa(cmb_Temporada.EditValue.ToString());
            dtgValProgramas.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValProgramas.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValProgramas.OptionsSelection.MultiSelect = true;
            dtgValProgramas.OptionsView.ShowGroupPanel = false;
            dtgValProgramas.OptionsBehavior.AutoPopulateColumns = true;
            dtgValProgramas.OptionsView.ColumnAutoWidth = true;
            dtgValProgramas.BestFitColumns();
        }

        private void Cargar_Programa(string p)
        {
            CLS_ProgramaCorte sel = new CLS_ProgramaCorte();
            sel.c_codigo_tem = p;
            sel.MtdSeleccionarPrograma();
            if(sel.Exito)
            {
                dtgProgramas.DataSource = sel.Datos;
            }
        }

        private void dtgProgramas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValProgramas.GetSelectedRows())
                {
                    DataRow row = this.dtgValProgramas.GetDataRow(i);
                    Id_ProgramaCorte = row["c_codigo_pco"].ToString();
                    v_temporada = row["c_codigo_tem"].ToString();
                    v_secuencia = row["c_secuencia_ocd"].ToString();
                    v_ordencorte= row["c_codigo_oct"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void Frm_BuscarProgramaCorte_Load(object sender, EventArgs e)
        {

        }

        private void btn_RecargarTem_Click(object sender, EventArgs e)
        {
            Cargar_Programa(cmb_Temporada.EditValue.ToString());
        }
    }
   
}