using CapaDeDatos;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Business_Analitics
{
    public partial class Frm_Maquila : DevExpress.XtraEditors.XtraForm
    {
        private int vNTermo;
        private string vManifiesto;
        private decimal vPrecioMaquila;
        public string UsuariosLogin { get; set; }
        public string IdPerfil { get; set; }
        private static Frm_Maquila m_FormDefInstance;
        public static Frm_Maquila DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Maquila();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Frm_Maquila()
        {
            InitializeComponent();
        }
        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "cTemporada";
            column.AutoIncrement = false;
            column.Caption = "Temporada";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "cManifiesto";
            column.AutoIncrement = false;
            column.Caption = "Manifiesto";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "cDistribuidor";
            column.AutoIncrement = false;
            column.Caption = "Distribuidor";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "cFechaEmbarque";
            column.AutoIncrement = false;
            column.Caption = "F Embarque";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "cProducto";
            column.AutoIncrement = false;
            column.Caption = "Producto";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "cEnvase";
            column.AutoIncrement = false;
            column.Caption = "Envase";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "cPesoEstandar";
            column.AutoIncrement = false;
            column.Caption = "Peso Estandar";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "cCajas";
            column.AutoIncrement = false;
            column.Caption = "Cajas";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "cMontoMaquila";
            column.AutoIncrement = false;
            column.Caption = "Monto Maquila";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "cMallas";
            column.AutoIncrement = false;
            column.Caption = "Mallas";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "cAPEAM";
            column.AutoIncrement = false;
            column.Caption = "APEAM";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "cSubTotal1";
            column.AutoIncrement = false;
            column.Caption = "SubTotal";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "cCharola";
            column.AutoIncrement = false;
            column.Caption = "Charola";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "cSubTotal";
            column.AutoIncrement = false;
            column.Caption = "SubTotal";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "cCaja";
            column.AutoIncrement = false;
            column.Caption = "Caja";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "cTOTAL";
            column.AutoIncrement = false;
            column.Caption = "TOTAL";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);
            dtgMaquila.DataSource = table;
        }
        private void MakeTablaReempaques()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "d_fecha_rem";
            column.AutoIncrement = false;
            column.Caption = "Fecha";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_nombre_pro_O";
            column.AutoIncrement = false;
            column.Caption = "Producto Origen";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_nombre_env_O";
            column.AutoIncrement = false;
            column.Caption = "Envase Origen";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_nombre_eti_O";
            column.AutoIncrement = false;
            column.Caption = "Etiqueta Origen";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_nombre_plu_O";
            column.AutoIncrement = false;
            column.Caption = "PLU Origen";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "n_cajas_rem_O";
            column.AutoIncrement = false;
            column.Caption = "Cajas Origen";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_nombre_pro_N";
            column.AutoIncrement = false;
            column.Caption = "Produto Nuevo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_nombre_env_N";
            column.AutoIncrement = false;
            column.Caption = "Envase Nuevo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_nombre_eti_N";
            column.AutoIncrement = false;
            column.Caption = "Etqueta Nueva";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_nombre_plu_N";
            column.AutoIncrement = false;
            column.Caption = "PLU Nuevo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "n_cajas_rem_N";
            column.AutoIncrement = false;
            column.Caption = "Cajas Nuevas";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_Observaciones";
            column.AutoIncrement = false;
            column.Caption = "Observaciones";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "n_kilogramos";
            column.AutoIncrement = false;
            column.Caption = "kilos";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_nombre_causa";
            column.AutoIncrement = false;
            column.Caption = "Causa";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "n_costo_rem";
            column.AutoIncrement = false;
            column.Caption = "kilos";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(DateTime);
            column.ColumnName = "d_fecha_inicio_maq";
            column.AutoIncrement = false;
            column.Caption = "fecha inicio";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(DateTime);
            column.ColumnName = "d_fecha_fin_maq";
            column.AutoIncrement = false;
            column.Caption = "fecha Fin";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "n_semana_maq";
            column.AutoIncrement = false;
            column.Caption = "Semana";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "n_secuencia";
            column.AutoIncrement = false;
            column.Caption = "Semana";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgReempaque.DataSource = table;
        }
        private void MakeTablaExtra()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "n_semana_maq";
            column.AutoIncrement = false;
            column.Caption = "Semana";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "n_secuencia";
            column.AutoIncrement = false;
            column.Caption = "Secuencia";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_nombre_causa";
            column.AutoIncrement = false;
            column.Caption = "Causa";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_nombre_horario";
            column.AutoIncrement = false;
            column.Caption = "Horario";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_unidad_causa";
            column.AutoIncrement = false;
            column.Caption = "Unidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "n_precio_causa";
            column.AutoIncrement = false;
            column.Caption = "Precio";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "n_cantidad_causa";
            column.AutoIncrement = false;
            column.Caption = "Cantidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "n_total_causa";
            column.AutoIncrement = false;
            column.Caption = "Total";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgCausaExtra.DataSource = table;
        }
        public string c_codigo_usu { get; set; }
        public DateTime Fechainicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int vn_Secuencia { get; private set; }
        public int vn_SecuenciaX { get; private set; }
        public decimal cTOTAL { get; private set; }
        public decimal sTotal { get; private set; }
        public string v_secuencia { get; private set; }
        public object v_semana { get; private set; }
        public string v_FechaInicio { get; private set; }
        public string v_FechaFin { get; private set; }
        public string v_secuenciaX { get; private set; }
        public string v_semanaX { get; private set; }
        decimal n_costo_extra { get; set; }
        public decimal cPrecioX { get; private set; }

        private void CreatNewRowArticulo(string cTemporada, string cManifiesto, string cDistribuidor, string cFechaEmbarque, string cProducto, string cEnvase, decimal cPesoEstandar, int cCajas, decimal cMontoMaquila, decimal cMallas, decimal cAPEAM, decimal cSubTotal1, decimal cCharola, decimal cSubTotal, decimal cCaja, decimal cTOTAL)
        {
            dtgValMaquila.AddNewRow();
            int rowHandle = dtgValMaquila.GetRowHandle(dtgValMaquila.DataRowCount);
            if (dtgValMaquila.IsNewItemRow(rowHandle))
            {
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["ctemporada"], cTemporada);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cManifiesto"], cManifiesto);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cDistribuidor"], cDistribuidor);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cFechaEmbarque"], cFechaEmbarque);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cProducto"], cProducto);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cEnvase"], cEnvase);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cPesoEstandar"], cPesoEstandar);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cCajas"], cCajas);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cMontoMaquila"], cMontoMaquila);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cMallas"], cMallas);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cAPEAM"], cAPEAM);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cSubTotal1"], cSubTotal1);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cCharola"], cCharola);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cSubTotal"], cSubTotal);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cCaja"], cCaja);
                dtgValMaquila.SetRowCellValue(rowHandle, dtgValMaquila.Columns["cTOTAL"], cTOTAL);

                CLS_Maquila ins2 = new CLS_Maquila();
                ins2.cTemporada = cTemporada;
                ins2.d_fecha_inicio_maq = dtFechaInicio.DateTime.Year.ToString() + DosCeros(dtFechaInicio.DateTime.Month.ToString()) + DosCeros(dtFechaInicio.DateTime.Day.ToString());
                ins2.d_fecha_fin_maq = dtFechaFin.DateTime.Year.ToString() + DosCeros(dtFechaFin.DateTime.Month.ToString()) + DosCeros(dtFechaFin.DateTime.Day.ToString());
                ins2.n_semana_maq = Convert.ToInt32(txtSemana.EditValue);
                ins2.Semana = Convert.ToInt32(txtSemana.EditValue);
                ins2.cManifiesto = cManifiesto;
                ins2.cDistribuidor = cDistribuidor;
                DateTime fecha = Convert.ToDateTime(cFechaEmbarque);
                ins2.cFechaEmbarque = fecha.Year.ToString() + DosCeros(fecha.Month.ToString()) + DosCeros(fecha.Day.ToString());
                ins2.cProducto = cProducto;
                ins2.cEnvase = cEnvase;
                ins2.cPesoEstandar = cPesoEstandar;
                ins2.cCajas = cCajas;
                ins2.cMontoMaquila = cMontoMaquila;
                ins2.cMallas = cMallas;
                ins2.cAPEAM = cAPEAM;
                ins2.cSubTotal1 = cSubTotal1;
                ins2.cCharola = cCharola;
                ins2.cSubTotal = cSubTotal;
                ins2.cCaja = cCaja;
                ins2.cTOTAL = cTOTAL;
                ins2.MtdGuardarMaquilaDetalles();
                if (!ins2.Exito)
                {
                    XtraMessageBox.Show(ins2.Mensaje);
                }
            }
            CLS_Maquila ins = new CLS_Maquila();
            ins.cManifiesto = cManifiesto;
            ins.cDistribuidor = cDistribuidor;
            DateTime vFecha = Convert.ToDateTime(cFechaEmbarque);
            ins.cFechaEmbarque = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
            ins.cProducto = cProducto;
            ins.cEnvase = cEnvase;
            ins.cPesoEstandar = Convert.ToDecimal(cPesoEstandar);
            ins.cCajas = cCajas;
            ins.cMontoMaquila = cMontoMaquila;
            ins.cMallas = cMallas;
            ins.cAPEAM = cAPEAM;
            ins.cSubTotal = cSubTotal;
            ins.cCharola = cCharola;
            ins.cSubTotal1 = cSubTotal1;
            ins.cCaja = cCaja;
            ins.cTOTAL = cTOTAL;
            ins.MtdInsertarMaquila();
            if (!ins.Exito)
            {
                XtraMessageBox.Show(ins.Mensaje);
            }

        }
        private void CreatNewRowReempaque(DateTime d_fecha_rem
            , string v_nombre_pro_O, string v_nombre_env_O, string v_nombre_eti_O, string v_nombre_plu_O, int n_cajas_rem_O
            , string v_nombre_pro_N, string v_nombre_env_N, string v_nombre_eti_N, string v_nombre_plu_N, int n_cajas_rem_N
            , string v_Observaciones, decimal n_kilogramos, string v_nombre_causa, DateTime d_fecha_inicio_maq, DateTime d_fecha_fin_maq, int n_semana_maq, int n_secuencia)
        {
            decimal n_costo_rem = 0;
            dtgValReempaque.AddNewRow();
            int rowHandle = dtgValReempaque.GetRowHandle(dtgValReempaque.DataRowCount);
            if (dtgValReempaque.IsNewItemRow(rowHandle))
            {
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["d_fecha_rem"], d_fecha_rem);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_nombre_pro_O"], v_nombre_pro_O);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_nombre_env_O"], v_nombre_env_O);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_nombre_eti_O"], v_nombre_eti_O);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_nombre_plu_O"], v_nombre_plu_O);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["n_cajas_rem_O"], n_cajas_rem_O);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_nombre_pro_N"], v_nombre_pro_N);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_nombre_env_N"], v_nombre_env_N);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_nombre_eti_N"], v_nombre_eti_N);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_nombre_plu_N"], v_nombre_plu_N);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["n_cajas_rem_N"], n_cajas_rem_N);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_Observaciones"], v_Observaciones);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["n_kilogramos"], n_kilogramos);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_nombre_causa"], v_nombre_causa);
                TomarPrecio(1);
                n_costo_rem = vPrecioMaquila * Convert.ToDecimal(cmb_Motivo.EditValue.ToString()) * n_kilogramos;
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["n_costo_rem"], n_costo_rem);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["d_fecha_inicio_maq"], d_fecha_inicio_maq);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["d_fecha_fin_maq"], d_fecha_fin_maq);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["n_semana_maq"], n_semana_maq);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["n_secuencia"], n_secuencia);
            }
            CLS_Reempaques ins = new CLS_Reempaques();
            ins.d_fecha_rem = d_fecha_rem.Year + DosCeros(d_fecha_rem.Month.ToString()) + DosCeros(d_fecha_rem.Day.ToString());
            ins.v_nombre_pro_O = v_nombre_pro_O;
            ins.v_nombre_env_O = v_nombre_env_O;
            ins.v_nombre_eti_O = v_nombre_eti_O;
            ins.v_nombre_plu_O = v_nombre_plu_O;
            ins.n_cajas_rem_O = n_cajas_rem_O;
            ins.v_nombre_pro_N = v_nombre_pro_N;
            ins.v_nombre_env_N = v_nombre_env_N;
            ins.v_nombre_eti_N = v_nombre_eti_N;
            ins.v_nombre_plu_N = v_nombre_plu_N;
            ins.n_cajas_rem_N = n_cajas_rem_N;
            ins.v_Observaciones = v_Observaciones;
            ins.n_kilogramos = n_kilogramos;
            ins.v_nombre_causa = v_nombre_causa;
            ins.n_costo_rem = n_costo_rem;
            ins.d_fecha_inicio_maq = d_fecha_inicio_maq.Year + DosCeros(d_fecha_inicio_maq.Month.ToString()) + DosCeros(d_fecha_inicio_maq.Day.ToString());
            ins.d_fecha_fin_maq = d_fecha_fin_maq.Year + DosCeros(d_fecha_fin_maq.Month.ToString()) + DosCeros(d_fecha_fin_maq.Day.ToString());
            ins.n_semana_maq = n_semana_maq;
            ins.n_secuencia = n_secuencia;
            ins.MtdInsertarReempaque();
            if (!ins.Exito)
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
            else
            {
                vn_Secuencia = vn_Secuencia + 1;
            }

        }
        private void CreatNewRowExtra(string n_semana_maq
            , string n_secuencia, string v_nombre_causa, string v_nombre_horario, string v_unidad_causa
            , string n_precio_causa, string n_cantidad_causa, string n_total_causa, DateTime d_fecha_inicio_maq, DateTime d_fecha_fin_maq, DateTime d_fecha_causa)
        {
            dtgValReempaque.AddNewRow();
            int rowHandle = dtgValReempaque.GetRowHandle(dtgValReempaque.DataRowCount);
            if (dtgValReempaque.IsNewItemRow(rowHandle))
            {
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["n_semana_maq"], n_semana_maq);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["n_secuencia"], n_secuencia);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_nombre_causa"], v_nombre_causa);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_nombre_horario"], v_nombre_horario);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["v_unidad_causa"], v_unidad_causa);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["n_precio_causa"], n_precio_causa);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["n_cantidad_causa"], n_cantidad_causa);
                dtgValReempaque.SetRowCellValue(rowHandle, dtgValReempaque.Columns["n_total_causa"], n_total_causa);
                n_costo_extra = n_costo_extra + Convert.ToDecimal(n_total_causa);
            }
            CLS_Reempaques ins = new CLS_Reempaques();

            ins.n_semana_maq = Convert.ToInt32(n_semana_maq);
            ins.n_secuencia = Convert.ToInt32(n_secuencia);
            ins.v_nombre_causa = v_nombre_causa;
            ins.v_nombre_horario = v_nombre_horario;
            ins.v_unidad_causa = v_unidad_causa;
            ins.n_precio_causa = Convert.ToDecimal(n_precio_causa);
            ins.n_cantidad_causa = Convert.ToInt32(n_cantidad_causa);
            ins.n_total_causa = Convert.ToDecimal(n_total_causa);
            ins.d_fecha_inicio_maq = d_fecha_inicio_maq.Year + DosCeros(d_fecha_inicio_maq.Month.ToString()) + DosCeros(d_fecha_inicio_maq.Day.ToString());
            ins.d_fecha_fin_maq = d_fecha_fin_maq.Year + DosCeros(d_fecha_fin_maq.Month.ToString()) + DosCeros(d_fecha_fin_maq.Day.ToString());
            ins.d_fecha_causa = d_fecha_causa.Year + DosCeros(d_fecha_causa.Month.ToString()) + DosCeros(d_fecha_causa.Day.ToString());
            ins.MtdInsertarCausaExtra();
            if (!ins.Exito)
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
            else
            {
                vn_SecuenciaX = vn_SecuenciaX + 1;
            }

        }
        private void TomarPrecio(int vNTermo)
        {
            CLS_Parametros sel = new CLS_Parametros();
            sel.MtdSeleccionarParametroTermo();
            if (sel.Exito)
            {
                for (int i = 0; i < sel.Datos.Rows.Count; i++)
                {
                    if (vNTermo <= Convert.ToInt32(sel.Datos.Rows[i]["PrecioMaquilaHasta"].ToString()))
                    {
                        vPrecioMaquila = Convert.ToDecimal(sel.Datos.Rows[i]["PrecioMaquilaCosto"].ToString());
                        break;
                    }
                }
            }
        }
        private void Frm_Maquila_Shown(object sender, EventArgs e)
        {
            vn_Secuencia = 0;
            MakeTablaPedidos();
            MakeTablaReempaques();
            //MakeTablaReempaques();
            //nAño.Value =Convert.ToInt32(DateTime.Now.Year.ToString());
            dtgValMaquila.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValMaquila.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValMaquila.OptionsSelection.MultiSelect = true;
            dtgValMaquila.OptionsView.ShowGroupPanel = false;
            dtgValMaquila.OptionsBehavior.AutoPopulateColumns = true;
            dtgValMaquila.OptionsView.ColumnAutoWidth = true;
            dtgValMaquila.BestFitColumns();

            dtgValReempaque.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValReempaque.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValReempaque.OptionsSelection.MultiSelect = true;
            dtgValReempaque.OptionsView.ShowGroupPanel = false;
            dtgValReempaque.OptionsBehavior.AutoPopulateColumns = true;
            dtgValReempaque.OptionsView.ColumnAutoWidth = true;
            dtgValReempaque.BestFitColumns();

            gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn2.DisplayFormat.FormatString = "dd/mm/yyyy";
            gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn5.DisplayFormat.FormatString = "###,###0.00";
            gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn6.DisplayFormat.FormatString = "###,###0";

            gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn7.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn8.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn9.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn10.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn11.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn12.DisplayFormat.FormatString = "$ ###,###0.00";

            gridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn27.DisplayFormat.FormatString = "$ ###,###0.00";

            gridColumn59.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn59.DisplayFormat.FormatString = "$ ###,###0.00";

            gridColumn60.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn60.DisplayFormat.FormatString = "$ ###,###0.00";

            colPorcentaje.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colPorcentaje.DisplayFormat.FormatString = "P";

            txt_TotalRem.Properties.Mask.MaskType = MaskType.Numeric;
            txt_TotalRem.Properties.Mask.EditMask = "c2";
            txt_TotalRem.Properties.Mask.UseMaskAsDisplayFormat = true;
            txt_Kilogramos.Properties.Mask.MaskType = MaskType.Numeric;
            txt_Kilogramos.Properties.Mask.EditMask = "n2";
            txt_Kilogramos.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtFechaInicio.DateTime = DateTime.Now;
            dtFechaFin.DateTime = DateTime.Now;
            d_FechaCausa.DateTime = DateTime.Now;
            //GridGroupSummaryItem item1 = new GridGroupSummaryItem();
            //item1.FieldName = "gridColumn12";
            //item1.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //item1.DisplayFormat = "Total {0:c2}";
            //item1.ShowInGroupColumnFooter = dtgValMaquila.Columns["gridColumn12"];
            //dtgValMaquila.GroupSummary.Add(item1);
            LimpiaReempaques();
            LimpiaCausaExtra();

        }
        private void CargarCausa(string Valor)
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.MtdSeleccionarCausaExtra();
            if (sel.Exito)
            {
                cmb_Causa.Properties.DisplayMember = "v_nombre_causa";
                cmb_Causa.Properties.ValueMember = "c_codigo_causa";
                cmb_Causa.EditValue = Valor;
                cmb_Causa.Properties.DataSource = sel.Datos;
            }
        }
        private void CargarHorario(string Valor)
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.MtdSeleccionarCausaHorarioExtra();
            if (sel.Exito)
            {
                cmb_Horario.Properties.DisplayMember = "v_nombre_causah";
                cmb_Horario.Properties.ValueMember = "c_codigo_causah";
                cmb_Horario.EditValue = Valor;
                cmb_Horario.Properties.DataSource = sel.Datos;
            }
        }

        public void LimpiaReempaques()
        {
            cmb_Envase_O.Properties.DataSource = null;
            cmb_Envase_N.Properties.DataSource = null;
            CargarProductosO(null);
            CargarProductosN(null);
            CargarEtiquetaO(null);
            CargarEtiquetaN(null);
            CargarPLUO(null);
            CargarPLUN(null);
            CargarMotivo(null);
            dtFechaReempaque.DateTime = DateTime.Now;
            CargarTotalReempaques();
        }
        public void LimpiaCausaExtra()
        {
            cmb_Envase_O.Properties.DataSource = null;
            cmb_Envase_N.Properties.DataSource = null;
            CargarCausa(null);
            CargarHorario(null);
            txt_Precio.Text = "0";
            txt_cantidad.Text = "1";
            txt_Total.Text = "0";
            //CargarTotalExtra();
        }
        public void CargarProductosO(string Valor)
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.MtdSeleccionarProductosReempaque();
            if (sel.Exito)
            {
                cmb_Producto_O.Properties.DisplayMember = "v_nombre_pro";
                cmb_Producto_O.Properties.ValueMember = "c_codigo_pro";
                cmb_Producto_O.EditValue = Valor;
                cmb_Producto_O.Properties.DataSource = sel.Datos;
            }
        }
        public void CargarProductosN(string Valor)
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.MtdSeleccionarProductosReempaque();
            if (sel.Exito)
            {
                cmb_Producto_N.Properties.DisplayMember = "v_nombre_pro";
                cmb_Producto_N.Properties.ValueMember = "c_codigo_pro";
                cmb_Producto_N.EditValue = Valor;
                cmb_Producto_N.Properties.DataSource = sel.Datos;
            }
        }
        public void CargarEnvaseO(string Valor, string c_codigo_pro)
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.c_codigo_pro = c_codigo_pro;
            sel.MtdSeleccionarEnvaseReempaque();
            if (sel.Exito)
            {
                cmb_Envase_O.Properties.DisplayMember = "v_nombre_env";
                cmb_Envase_O.Properties.ValueMember = "c_codigo_env";
                cmb_Envase_O.EditValue = Valor;
                cmb_Envase_O.Properties.DataSource = sel.Datos;
            }
        }
        public void CargarEnvaseN(string Valor, string c_codigo_pro)
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.c_codigo_pro = c_codigo_pro;
            sel.MtdSeleccionarEnvaseReempaque();
            if (sel.Exito)
            {
                cmb_Envase_N.Properties.DisplayMember = "v_nombre_env";
                cmb_Envase_N.Properties.ValueMember = "c_codigo_env";
                cmb_Envase_N.EditValue = Valor;
                cmb_Envase_N.Properties.DataSource = sel.Datos;
            }
        }
        public void CargarEtiquetaO(string Valor)
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.MtdSeleccionarEtiquetaReempaque();
            if (sel.Exito)
            {
                cmb_Etiqueta_O.Properties.DisplayMember = "v_nombre_eti";
                cmb_Etiqueta_O.Properties.ValueMember = "c_codigo_eti";
                cmb_Etiqueta_O.EditValue = Valor;
                cmb_Etiqueta_O.Properties.DataSource = sel.Datos;
            }
        }
        public void CargarEtiquetaN(string Valor)
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.MtdSeleccionarEtiquetaReempaque();
            if (sel.Exito)
            {
                cmb_Etiqueta_N.Properties.DisplayMember = "v_nombre_eti";
                cmb_Etiqueta_N.Properties.ValueMember = "c_codigo_eti";
                cmb_Etiqueta_N.EditValue = Valor;
                cmb_Etiqueta_N.Properties.DataSource = sel.Datos;
            }
        }
        public void CargarPLUO(string Valor)
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.MtdSeleccionarPLUReempaque();
            if (sel.Exito)
            {
                cmb_PLU_O.Properties.DisplayMember = "v_nombre_pro";
                cmb_PLU_O.Properties.ValueMember = "c_codigo_pro";
                cmb_PLU_O.EditValue = Valor;
                cmb_PLU_O.Properties.DataSource = sel.Datos;
            }
        }
        public void CargarPLUN(string Valor)
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.MtdSeleccionarPLUReempaque();
            if (sel.Exito)
            {
                cmb_PLU_N.Properties.DisplayMember = "v_nombre_pro";
                cmb_PLU_N.Properties.ValueMember = "c_codigo_pro";
                cmb_PLU_N.EditValue = Valor;
                cmb_PLU_N.Properties.DataSource = sel.Datos;
            }
        }
        public void CargarMotivo(string Valor)
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.MtdSeleccionarCausaReempaque();
            if (sel.Exito)
            {
                cmb_Motivo.Properties.DisplayMember = "v_nombre_causa";
                cmb_Motivo.Properties.ValueMember = "n_porcentaje_cau";
                cmb_Motivo.EditValue = Valor;
                cmb_Motivo.Properties.DataSource = sel.Datos;
            }
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
        private void btnCalcular_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtgMaquila.DataSource = null;
            dtgReempaque.DataSource = null;
            dtgCausaExtra.DataSource = null;
            cTOTAL = 0;
            sTotal = 0;
            MakeTablaPedidos();
            MakeTablaReempaques();
            MakeTablaExtra();
            int result = DateTime.Compare(dtFechaInicio.DateTime, dtFechaFin.DateTime);
            if (result < 1)
            {
                CLS_Maquila sel = new CLS_Maquila();
                sel.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCeros(dtFechaInicio.DateTime.Month.ToString()) + DosCeros(dtFechaInicio.DateTime.Day.ToString());
                sel.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCeros(dtFechaFin.DateTime.Month.ToString()) + DosCeros(dtFechaFin.DateTime.Day.ToString());
                sel.MtdSeleccionarMaquila();
                vNTermo = 1;
                if (sel.Exito && sel.Datos.Rows.Count > 0)
                {
                    vManifiesto = sel.Datos.Rows[0]["c_codigo_man"].ToString();
                    TomarPrecio(vNTermo);
                    CLS_Maquila del = new CLS_Maquila();
                    del.MtdEliminarMaquila();
                    if (del.Exito)
                    {
                        CLS_Maquila del2 = new CLS_Maquila();
                        del2.d_fecha_inicio_maq = dtFechaInicio.DateTime.Year.ToString() + DosCeros(dtFechaInicio.DateTime.Month.ToString()) + DosCeros(dtFechaInicio.DateTime.Day.ToString());
                        del2.d_fecha_fin_maq = dtFechaFin.DateTime.Year.ToString() + DosCeros(dtFechaFin.DateTime.Month.ToString()) + DosCeros(dtFechaFin.DateTime.Day.ToString());
                        del2.n_semana_maq = Convert.ToInt32(txtSemana.EditValue);
                        del2.MtdEliminarMaquilaDetalles();
                        if (del2.Exito)
                        {
                            for (int i = 0; i < sel.Datos.Rows.Count; i++)
                            {
                                if (vManifiesto != sel.Datos.Rows[i]["c_codigo_man"].ToString())
                                {
                                    vNTermo++;
                                    vManifiesto = sel.Datos.Rows[i]["c_codigo_man"].ToString();
                                    TomarPrecio(vNTermo);
                                }
                                string cTemporada = sel.Datos.Rows[i]["c_codigo_tem"].ToString().Trim();
                                string cManifiesto = sel.Datos.Rows[i]["c_codigo_man"].ToString().Trim();
                                string cDistribuidor = sel.Datos.Rows[i]["v_nombre_dis"].ToString().Trim();
                                string cFechaEmbarque = sel.Datos.Rows[i]["d_embarque_man"].ToString();
                                string cProducto = sel.Datos.Rows[i]["v_nombre_pro"].ToString().Trim();
                                string cEnvase = sel.Datos.Rows[i]["v_nombre_env"].ToString().Trim();
                                decimal cPesoEstandar = Convert.ToDecimal(sel.Datos.Rows[i]["PesoEstandar"].ToString());
                                decimal cPrecioNal = Convert.ToDecimal(sel.Datos.Rows[i]["PrecioNal"].ToString());
                                int cCajas = Convert.ToInt32(Convert.ToDecimal(sel.Datos.Rows[i]["TCajas"].ToString()));
                                decimal cMontoMaquila = 0;
                                if (cProducto.IndexOf("PICADA") == -1 && cProducto.IndexOf("DESECHO") == -1)
                                {
                                    if (cPrecioNal == 0)
                                    {
                                        cMontoMaquila = Convert.ToDecimal(vPrecioMaquila * Convert.ToDecimal(cPesoEstandar));
                                    }
                                    else
                                    {
                                        cMontoMaquila = Convert.ToDecimal(cPrecioNal * Convert.ToDecimal(cPesoEstandar));
                                    }
                                }
                                else
                                {
                                    cMontoMaquila = 0;
                                }

                                decimal cMallas = Convert.ToDecimal(sel.Datos.Rows[i]["TMalla"].ToString());
                                decimal cAPEAM = Convert.ToDecimal(sel.Datos.Rows[i]["TAPEAM"].ToString());
                                decimal cSubTotal1 = Convert.ToDecimal(Convert.ToDecimal(cMontoMaquila) + Convert.ToDecimal(cMallas) + Convert.ToDecimal(cAPEAM));
                                decimal cCharola = Convert.ToDecimal(sel.Datos.Rows[i]["TCharola"].ToString());
                                decimal cSubTotal = Convert.ToDecimal(Convert.ToDecimal(cMontoMaquila) + Convert.ToDecimal(cMallas) + Convert.ToDecimal(cAPEAM) + Convert.ToDecimal(cCharola));
                                decimal cCaja = Convert.ToDecimal(sel.Datos.Rows[i]["TCaja"].ToString());
                                cTOTAL = Convert.ToDecimal(Convert.ToDecimal(cSubTotal) + Convert.ToDecimal(cCaja));
                                sTotal += cTOTAL;
                                CreatNewRowArticulo(cTemporada,cManifiesto, cDistribuidor, cFechaEmbarque, cProducto, cEnvase, cPesoEstandar, cCajas, cMontoMaquila, cMallas, cAPEAM, cSubTotal1, cCharola, cSubTotal, cCaja, cTOTAL);

                            }
                            dtgValMaquila.OptionsView.ColumnAutoWidth = true;
                            dtgValMaquila.BestFitColumns();
                            txt_TotalRem.EditValue = 0;
                            CargarReempaques();
                            CargarExtra();
                        }
                        else
                        {
                            XtraMessageBox.Show(del2.Mensaje);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(del.Mensaje);
                    }
                }
                else
                {
                    XtraMessageBox.Show(sel.Mensaje + " o no existen datos para mostrar");
                }
            }
            else
            {
                XtraMessageBox.Show("La fecha de Inicio no puede ser mayor a la Fecha Fin");
            }

        }

        private void btnParametros_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Parametros frm = new Frm_Parametros();
            frm.ShowDialog();
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new System.IO.FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            dtgMaquila.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            dtgMaquila.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            dtgMaquila.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            dtgMaquila.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            dtgMaquila.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            dtgMaquila.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (System.IO.File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int vSemana = Convert.ToInt32(txtSemana.Value);
            //int vAño =Convert.ToInt32(nAño.Value);

            //ObtenerFechadeSemana(vSemana, vAño);
            XtraFolderBrowserDialog saveFileDialog = new XtraFolderBrowserDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string Cadena = saveFileDialog.SelectedPath;
                XtraInputBoxArgs args = new XtraInputBoxArgs();
                // set required Input Box options 
                args.Caption = "Ingrese Nombre del Archivo PDF";
                args.Prompt = "Nombre Archivo";
                args.DefaultButtonIndex = 0;
                //args.Showing += Args_Showing;
                // initialize a DateEdit editor with custom settings 
                TextEdit editor = new TextEdit();
                args.Editor = editor;
                // a default DateEdit value 
                args.DefaultResponse = "Nombre_Archivo_PDF";
                // display an Input Box with the custom editor 
                string result = string.Empty;
                result = XtraInputBox.Show(args).ToString();
                if (result != string.Empty)
                {
                    string fileNamepdf = Cadena + "\\" + result + ".pdf";
                    CrearPDF(fileNamepdf);
                    System.Diagnostics.Process.Start(fileNamepdf);
                }
                else
                {
                    XtraMessageBox.Show("No se ingreso Nombre para el Archivo a exportar");
                }
            }

        }
        private void CrearPDF(string fileNamepdf)
        {
            //rpt_MaquilaxSemana rpt = new rpt_MaquilaxSemana();
            //((SqlDataSource)rpt.DataSource).ConfigureDataConnection += Form1_ConfigureDataConnection;
            //ReportPrintTool print = new ReportPrintTool(rpt);
            //rpt.ShowPreviewDialog();
            //
            rpt_MaquilaxSemana rpt = new rpt_MaquilaxSemana();
            ((SqlDataSource)rpt.DataSource).ConfigureDataConnection += Form1_ConfigureDataConnection;
            Fechainicio = dtFechaInicio.DateTime;
            FechaFin = dtFechaFin.DateTime;
            rpt.Parameters["FechaInicio"].Value = Fechainicio;
            rpt.Parameters["FechaFin"].Value = FechaFin;
            rpt.Parameters["Semana"].Value = txtSemana.Text;
            rpt.Parameters["Reempaque"].Value = txt_TotalRem.Text;
            rpt.Parameters["iva"].Value = (Convert.ToDecimal(txt_TotalRem.EditValue) + Convert.ToDecimal(sTotal)) * Convert.ToDecimal(0.16);
            rpt.Parameters["Total"].Value = (Convert.ToDecimal(txt_TotalRem.EditValue) + Convert.ToDecimal(sTotal)) * Convert.ToDecimal(1.16);
            PdfExportOptions pdfOptions = rpt.ExportOptions.Pdf;
            pdfOptions.PageRange = "1-1000";

            // Specify the quality of exported images.
            pdfOptions.ConvertImagesToJpeg = false;
            pdfOptions.ImageQuality = PdfJpegImageQuality.Medium;

            // Specify the PDF/A-compatibility.
            pdfOptions.PdfACompatibility = PdfACompatibility.PdfA3b;

            // The following options are not compatible with PDF/A.
            // The use of these options will result in errors on PDF validation.
            //pdfOptions.NeverEmbeddedFonts = "Tahoma;Courier New";
            //pdfOptions.ShowPrintDialogOnOpen = true;

            // If required, you can specify the security and signature options. 
            //pdfOptions.PasswordSecurityOptions
            //pdfOptions.SignatureOptions

            // If required, specify necessary metadata and attachments
            // (e.g., to produce a ZUGFeRD-compatible PDF).
            //pdfOptions.AdditionalMetadata
            //pdfOptions.Attachments

            // Specify the document options.
            pdfOptions.DocumentOptions.Application = "Reporte Maquila";
            pdfOptions.DocumentOptions.Author = "NexusSoft";
            pdfOptions.DocumentOptions.Keywords = "Reportes Santadeo, Reporte, PDF";
            pdfOptions.DocumentOptions.Producer = Environment.UserName.ToString();
            pdfOptions.DocumentOptions.Subject = "Documento Maquila";
            pdfOptions.DocumentOptions.Title = "Reporte Maquila";

            // Checks the validity of PDF export options 
            // and return a list of any detected inconsistencies.
            IList<string> result = pdfOptions.Validate();
            if (result.Count > 0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, result));
            }
            else
            {
                rpt.ExportToPdf(fileNamepdf, pdfOptions);
            }
        }
        private void Form1_ConfigureDataConnection(object sender, ConfigureDataConnectionEventArgs e)
        {
            MSRegistro RegOut = new MSRegistro();
            Crypto DesencriptarTexto = new Crypto();

            string valServer = RegOut.GetSetting("ConexionSQL", "Server");
            string valDB = RegOut.GetSetting("ConexionSQL", "DBase");
            string valLogin = RegOut.GetSetting("ConexionSQL", "User");
            string valPass = RegOut.GetSetting("ConexionSQL", "Password");

            if (valServer != string.Empty && valDB != string.Empty && valLogin != string.Empty && valPass != string.Empty)
            {
                valServer = DesencriptarTexto.Desencriptar(valServer);
                valDB = DesencriptarTexto.Desencriptar(valDB);
                valLogin = DesencriptarTexto.Desencriptar(valLogin);
                valPass = DesencriptarTexto.Desencriptar(valPass);
                e.ConnectionParameters = new MsSqlConnectionParameters(valServer, valDB, valLogin, valPass, MsSqlAuthorizationType.SqlServer);
            }
        }
        private void ObtenerFechadeSemana(int semana, int año)
        {
            DateTime FechaInicioAño = new DateTime(año, 1, 1);
            DateTime DiaSemanaUno = DateTime.Now;
            byte vDiaSemana = (byte)FechaInicioAño.DayOfWeek;
            switch (vDiaSemana)
            {
                case 1:
                    DiaSemanaUno = FechaInicioAño.AddDays(-1);
                    break;
                case 2:
                    DiaSemanaUno = FechaInicioAño.AddDays(-2);
                    break;
                case 3:
                    DiaSemanaUno = FechaInicioAño.AddDays(-3);
                    break;
                case 4:
                    DiaSemanaUno = FechaInicioAño.AddDays(-4);
                    break;
                case 5:
                    DiaSemanaUno = FechaInicioAño.AddDays(-5);
                    break;
                case 6:
                    DiaSemanaUno = FechaInicioAño.AddDays(-6);
                    break;
                default:
                    break;
            }
            int agregadias = semana * 7;
            Fechainicio = DiaSemanaUno.AddDays(agregadias);
            FechaFin = DiaSemanaUno.AddDays(agregadias + 6);
        }

        private void dtFechaInicio_EditValueChanged(object sender, EventArgs e)
        {
            DateTime Fecha = dtFechaInicio.DateTime;
            int Semana = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(Fecha, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            txtSemana.Value = Semana;
        }

        private void CargarReempaques()
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.d_fecha_inicio_maq = dtFechaInicio.DateTime.Year.ToString() + DosCeros(dtFechaInicio.DateTime.Month.ToString()) + DosCeros(dtFechaInicio.DateTime.Day.ToString());
            sel.d_fecha_fin_maq = dtFechaFin.DateTime.Year.ToString() + DosCeros(dtFechaFin.DateTime.Month.ToString()) + DosCeros(dtFechaFin.DateTime.Day.ToString());
            sel.n_semana_maq = Convert.ToInt32(txtSemana.Text);
            sel.MtdSeleccionarReempaque();
            if (sel.Exito)
            {
                dtgReempaque.DataSource = sel.Datos;
                vn_Secuencia = sel.Datos.Rows.Count;
                CargarTotalReempaques();
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
        }
        private void CargarTotalReempaques()
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.d_fecha_inicio_maq = dtFechaInicio.DateTime.Year.ToString() + DosCeros(dtFechaInicio.DateTime.Month.ToString()) + DosCeros(dtFechaInicio.DateTime.Day.ToString());
            sel.d_fecha_fin_maq = dtFechaFin.DateTime.Year.ToString() + DosCeros(dtFechaFin.DateTime.Month.ToString()) + DosCeros(dtFechaFin.DateTime.Day.ToString());
            sel.n_semana_maq = Convert.ToInt32(txtSemana.Text);

            sel.MtdSeleccionarReempaque();
            if (sel.Exito)
            {
                decimal cPrecio = 0;
                for (int i = 0; i < sel.Datos.Rows.Count; i++)
                {
                    cPrecio = cPrecio + Convert.ToDecimal(sel.Datos.Rows[i]["n_costo_rem"].ToString());
                }
                txt_TotalRem.Text = Convert.ToString(Convert.ToDecimal(txt_TotalRem.EditValue) + cPrecio);
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
        }
        private void CargarExtra()
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.d_fecha_inicio_maq = dtFechaInicio.DateTime.Year.ToString() + DosCeros(dtFechaInicio.DateTime.Month.ToString()) + DosCeros(dtFechaInicio.DateTime.Day.ToString());
            sel.d_fecha_fin_maq = dtFechaFin.DateTime.Year.ToString() + DosCeros(dtFechaFin.DateTime.Month.ToString()) + DosCeros(dtFechaFin.DateTime.Day.ToString());
            sel.n_semana_maq = Convert.ToInt32(txtSemana.Text);
            sel.MtdSeleccionarCausaExtraG();
            if (sel.Exito)
            {
                dtgCausaExtra.DataSource = sel.Datos;
                vn_SecuenciaX = sel.Datos.Rows.Count;
                CargarTotalExtra();
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
        }
        private void CargarTotalExtra()
        {
            CLS_Reempaques sel = new CLS_Reempaques();
            sel.d_fecha_inicio_maq = dtFechaInicio.DateTime.Year.ToString() + DosCeros(dtFechaInicio.DateTime.Month.ToString()) + DosCeros(dtFechaInicio.DateTime.Day.ToString());
            sel.d_fecha_fin_maq = dtFechaFin.DateTime.Year.ToString() + DosCeros(dtFechaFin.DateTime.Month.ToString()) + DosCeros(dtFechaFin.DateTime.Day.ToString());
            sel.n_semana_maq = Convert.ToInt32(txtSemana.Text);

            sel.MtdSeleccionarCausaExtraG();
            if (sel.Exito)
            {
                cPrecioX = 0;
                for (int i = 0; i < sel.Datos.Rows.Count; i++)
                {
                    cPrecioX = cPrecioX + Convert.ToDecimal(sel.Datos.Rows[i]["n_total_causa"].ToString());
                }
                txt_TotalRem.Text = Convert.ToString(Convert.ToDecimal(txt_TotalRem.EditValue) + cPrecioX);
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
        }
        private void cmb_Producto_O_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmb_Producto_O.EditValue.ToString()))
                {
                    CargarEnvaseO(null, cmb_Producto_O.EditValue.ToString());
                }
            }
            catch (Exception)
            {


            }

        }

        private void cmb_Producto_N_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmb_Producto_O.EditValue.ToString()))
                {
                    CargarEnvaseN(null, cmb_Producto_N.EditValue.ToString());
                }
            }
            catch (Exception)
            {


            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!CamposVacios())
            {
                DateTime d_fecha_rem = Convert.ToDateTime(dtFechaReempaque.EditValue.ToString());
                string v_nombre_pro_O = cmb_Producto_O.Text.ToString();
                string v_nombre_env_O = cmb_Envase_O.Text.ToString();
                string v_nombre_eti_O = cmb_Etiqueta_O.Text.ToString();
                string v_nombre_plu_O = cmb_PLU_O.Text.ToString();
                int n_cajas_rem_O = Convert.ToInt32(txt_Cajas_O.Text);
                string v_nombre_pro_N = cmb_Producto_N.Text.ToString();
                string v_nombre_env_N = cmb_Envase_N.Text.ToString();
                string v_nombre_eti_N = cmb_Etiqueta_N.Text.ToString();
                string v_nombre_plu_N = cmb_PLU_N.Text.ToString();
                int n_cajas_rem_N = Convert.ToInt32(txt_Cajas_N.Text);
                string v_Observaciones = txt_Observaciones.Text;
                decimal n_kilogramos = Convert.ToDecimal(txt_Kilogramos.Text);
                string v_nombre_causa = cmb_Motivo.Text.ToString();
                DateTime d_fecha_inicio_maq = Convert.ToDateTime(dtFechaInicio.EditValue.ToString());
                DateTime d_fecha_fin_maq = Convert.ToDateTime(dtFechaFin.EditValue.ToString()); ;
                int n_semana_maq = Convert.ToInt32(txtSemana.Text);
                int n_secuencia = vn_Secuencia + 1;
                CreatNewRowReempaque(d_fecha_rem, v_nombre_pro_O, v_nombre_env_O, v_nombre_eti_O, v_nombre_plu_O, n_cajas_rem_O
                            , v_nombre_pro_N, v_nombre_env_N, v_nombre_eti_N, v_nombre_plu_N, n_cajas_rem_N
            , v_Observaciones, n_kilogramos, v_nombre_causa, d_fecha_inicio_maq, d_fecha_fin_maq, n_semana_maq, n_secuencia);
                LimpiaReempaques();
                CargarTotalReempaques();
            }

        }

        private Boolean CamposVacios()
        {
            Boolean valor = true;
            try
            {
                if (dtFechaReempaque.EditValue != null)
                {
                    if (cmb_Producto_O.EditValue != null || cmb_Etiqueta_O.EditValue != null || cmb_Envase_O.EditValue != null || cmb_PLU_O.EditValue != null)
                    {
                        if (cmb_Producto_N.EditValue != null || cmb_Etiqueta_N.EditValue != null || cmb_Envase_N.EditValue != null || cmb_PLU_N.EditValue != null)
                        {
                            if (txt_Kilogramos.Text != string.Empty)
                            {
                                if (cmb_Motivo.EditValue != null)
                                {
                                    valor = false;
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("No se han capturado kilogramos");
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Falta de capturar datos en el producto nuevo");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Falta de capturar datos en el producto de origen");
                    }
                }
                else
                {
                    XtraMessageBox.Show("No se ha capturado fecha de reempaque");
                }
                return valor;
            }
            catch (Exception)
            {

                return valor;
            }
        }

        private Boolean CamposVaciosExtras()
        {
            Boolean valor = true;
            try
            {
                if (cmb_Causa.EditValue != null || cmb_Horario.EditValue != null)
                {
                    valor = false;
                }
                else
                {
                    XtraMessageBox.Show("Falta de capturar datos en el producto nuevo");
                }
                return valor;
            }
            catch (Exception)
            {
                return valor;
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int result = DateTime.Compare(dtFechaInicio.DateTime, dtFechaFin.DateTime);
            if (result < 1)
            {
                CLS_Maquila del1 = new CLS_Maquila();
                del1.d_fecha_inicio_maq = dtFechaInicio.DateTime.Year.ToString() + DosCeros(dtFechaInicio.DateTime.Month.ToString()) + DosCeros(dtFechaInicio.DateTime.Day.ToString());
                del1.d_fecha_fin_maq = dtFechaFin.DateTime.Year.ToString() + DosCeros(dtFechaFin.DateTime.Month.ToString()) + DosCeros(dtFechaFin.DateTime.Day.ToString());
                del1.n_semana_maq = Convert.ToInt32(txtSemana.Text);
                del1.MtdEliminarMaquilaDetalles();
                if (del1.Exito)
                {
                    CLS_Maquila sel = new CLS_Maquila();
                    sel.FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCeros(dtFechaInicio.DateTime.Month.ToString()) + DosCeros(dtFechaInicio.DateTime.Day.ToString());
                    sel.FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCeros(dtFechaFin.DateTime.Month.ToString()) + DosCeros(dtFechaFin.DateTime.Day.ToString());
                    sel.MtdSeleccionarMaquila();
                    vNTermo = 1;
                    if (sel.Exito)
                    {
                        vManifiesto = sel.Datos.Rows[0]["c_codigo_man"].ToString();
                        TomarPrecio(vNTermo);
                        CLS_Maquila del = new CLS_Maquila();
                        del.MtdEliminarMaquila();
                        if (del.Exito)
                        {
                            for (int i = 0; i < sel.Datos.Rows.Count; i++)
                            {
                                if (vManifiesto != sel.Datos.Rows[i]["c_codigo_man"].ToString())
                                {
                                    vNTermo++;
                                    vManifiesto = sel.Datos.Rows[i]["c_codigo_man"].ToString();
                                    TomarPrecio(vNTermo);
                                }
                                string cTemporada = sel.Datos.Rows[i]["c_codigo_tem"].ToString().Trim();
                                string cManifiesto = sel.Datos.Rows[i]["c_codigo_man"].ToString().Trim();
                                string cDistribuidor = sel.Datos.Rows[i]["v_nombre_dis"].ToString().Trim();
                                string cFechaEmbarque = sel.Datos.Rows[i]["d_embarque_man"].ToString();
                                string cProducto = sel.Datos.Rows[i]["v_nombre_pro"].ToString().Trim();
                                string cEnvase = sel.Datos.Rows[i]["v_nombre_env"].ToString().Trim();
                                decimal cPesoEstandar = Convert.ToDecimal(sel.Datos.Rows[i]["PesoEstandar"].ToString());
                                decimal cPrecioNal = Convert.ToDecimal(sel.Datos.Rows[i]["PrecioNal"].ToString());
                                int cCajas = Convert.ToInt32(Convert.ToDecimal(sel.Datos.Rows[i]["TCajas"].ToString()));
                                decimal cMontoMaquila = 0;
                                if (cProducto.IndexOf("PICADA") == -1 && cProducto.IndexOf("DESECHO") == -1)
                                {
                                    if (cPrecioNal == 0)
                                    {
                                        cMontoMaquila = Convert.ToDecimal(vPrecioMaquila * Convert.ToDecimal(cPesoEstandar));
                                    }
                                    else
                                    {
                                        cMontoMaquila = Convert.ToDecimal(cPrecioNal * Convert.ToDecimal(cPesoEstandar));
                                    }
                                }
                                else
                                {
                                    cMontoMaquila = 0;
                                }

                                decimal cMallas = Convert.ToDecimal(sel.Datos.Rows[i]["TMalla"].ToString());
                                decimal cAPEAM = Convert.ToDecimal(sel.Datos.Rows[i]["TAPEAM"].ToString());
                                decimal cSubTotal = Convert.ToDecimal(Convert.ToDecimal(cMontoMaquila) + Convert.ToDecimal(cMallas) + Convert.ToDecimal(cAPEAM));
                                decimal cCharola = Convert.ToDecimal(sel.Datos.Rows[i]["TCharola"].ToString());
                                decimal cTOTAL = Convert.ToDecimal(Convert.ToDecimal(cSubTotal) + Convert.ToDecimal(cCharola));

                                CLS_Maquila ins = new CLS_Maquila();
                                ins.cTemporada = cTemporada;
                                ins.cManifiesto = cManifiesto;
                                ins.cDistribuidor = cDistribuidor;
                                DateTime vFecha = Convert.ToDateTime(cFechaEmbarque);
                                ins.cFechaEmbarque = vFecha.Year.ToString() + DosCeros(vFecha.Month.ToString()) + DosCeros(vFecha.Day.ToString());
                                ins.cProducto = cProducto;
                                ins.cEnvase = cEnvase;
                                ins.cPesoEstandar = Convert.ToDecimal(cPesoEstandar);
                                ins.cCajas = cCajas;
                                ins.cMontoMaquila = cMontoMaquila;
                                ins.cMallas = cMallas;
                                ins.cAPEAM = cAPEAM;
                                ins.cSubTotal = cSubTotal;
                                ins.cCharola = cCharola;
                                ins.cTOTAL = cTOTAL;
                                ins.d_fecha_inicio_maq = dtFechaInicio.DateTime.Year.ToString() + DosCeros(dtFechaInicio.DateTime.Month.ToString()) + DosCeros(dtFechaInicio.DateTime.Day.ToString());
                                ins.d_fecha_fin_maq = dtFechaFin.DateTime.Year.ToString() + DosCeros(dtFechaFin.DateTime.Month.ToString()) + DosCeros(dtFechaFin.DateTime.Day.ToString());
                                ins.n_semana_maq = Convert.ToInt32(txtSemana.Text);
                                ins.MtdGuardarMaquilaDetalles();
                                if (!ins.Exito)
                                {
                                    XtraMessageBox.Show(ins.Mensaje);
                                    break;
                                }
                                else
                                {
                                    if ((i + 1) == sel.Datos.Rows.Count)
                                    {
                                        XtraMessageBox.Show("Se han guardado los datos con exito");
                                    }
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(del.Mensaje);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(sel.Mensaje);
                    }
                }
                else
                {
                    XtraMessageBox.Show(del1.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("La fecha de Inicio no puede ser mayor a la Fecha Fin");
            }
        }
        private void dtgReempaque_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValReempaque.GetSelectedRows())
                {
                    DataRow row = this.dtgValReempaque.GetDataRow(i);
                    v_secuencia = row["n_secuencia"].ToString();
                    v_semana = txtSemana.EditValue.ToString();
                    v_FechaInicio = dtFechaInicio.DateTime.Year.ToString() + DosCeros(dtFechaInicio.DateTime.Month.ToString()) + DosCeros(dtFechaInicio.DateTime.Day.ToString());
                    v_FechaFin = dtFechaFin.DateTime.Year.ToString() + DosCeros(dtFechaFin.DateTime.Month.ToString()) + DosCeros(dtFechaFin.DateTime.Day.ToString());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(v_secuencia) && !string.IsNullOrEmpty(Convert.ToString(v_semana)) && !string.IsNullOrEmpty(v_FechaInicio) && !string.IsNullOrEmpty(v_FechaFin))
            {
                CLS_Reempaques del = new CLS_Reempaques();
                del.n_secuencia = Convert.ToInt32(v_secuencia);
                del.n_semana_maq = Convert.ToInt32(v_semana);
                del.d_fecha_inicio_maq = v_FechaInicio;
                del.d_fecha_fin_maq = v_FechaFin;
                del.MtdEliminarReempaque();
                if (del.Exito)
                {
                    LimpiaReempaques();
                    CargarReempaques();
                    XtraMessageBox.Show("Se ha eliminado el dato con exito");
                }
                else
                {
                    XtraMessageBox.Show(del.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado pais para quitar");
            }
        }

        private void cmb_Causa_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmb_Causa.EditValue.ToString()) && !string.IsNullOrEmpty(cmb_Horario.EditValue.ToString()))
                {
                    CLS_Reempaques del = new CLS_Reempaques();
                    del.c_codigo_causa = cmb_Causa.EditValue.ToString();
                    del.c_codigo_causah = cmb_Horario.EditValue.ToString();
                    del.MtdSeleccionarCausaPrecioExtra();
                    if (del.Exito)
                    {
                        lbl_Unidad.Text = del.Datos.Rows[0]["v_unidad_causa"].ToString();
                        txt_Precio.Text = del.Datos.Rows[0]["n_Precio_causa"].ToString();
                        txt_Total.Text = Convert.ToString(Convert.ToDecimal(txt_Precio.EditValue.ToString()) * Convert.ToDecimal(txt_cantidad.EditValue.ToString()));
                    }
                    else
                    {
                        XtraMessageBox.Show(del.Mensaje);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void cmb_Horario_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmb_Causa.EditValue.ToString()) && !string.IsNullOrEmpty(cmb_Horario.EditValue.ToString()))
                {
                    CLS_Reempaques del = new CLS_Reempaques();
                    del.c_codigo_causa = cmb_Causa.EditValue.ToString();
                    del.c_codigo_causah = cmb_Horario.EditValue.ToString();
                    del.MtdSeleccionarCausaPrecioExtra();
                    if (del.Exito)
                    {
                        lbl_Unidad.Text = del.Datos.Rows[0]["v_unidad_causa"].ToString();
                        txt_Precio.Text = del.Datos.Rows[0]["n_Precio_causa"].ToString();
                        txt_Total.Text = Convert.ToString(Convert.ToDecimal(txt_Precio.EditValue.ToString()) * Convert.ToDecimal(txt_cantidad.EditValue.ToString()));
                    }
                    else
                    {
                        XtraMessageBox.Show(del.Mensaje);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void txt_cantidad_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmb_Causa.EditValue.ToString()) && !string.IsNullOrEmpty(cmb_Horario.EditValue.ToString()))
                {
                    CLS_Reempaques del = new CLS_Reempaques();
                    del.c_codigo_causa = cmb_Causa.EditValue.ToString();
                    del.c_codigo_causah = cmb_Horario.EditValue.ToString();
                    del.MtdSeleccionarCausaPrecioExtra();
                    if (del.Exito)
                    {
                        lbl_Unidad.Text = del.Datos.Rows[0]["v_unidad_causa"].ToString();
                        txt_Precio.Text = del.Datos.Rows[0]["n_Precio_causa"].ToString();
                        txt_Total.Text = Convert.ToString(Convert.ToDecimal(txt_Precio.EditValue.ToString()) * Convert.ToDecimal(txt_cantidad.EditValue.ToString()));
                    }
                    else
                    {
                        XtraMessageBox.Show(del.Mensaje);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btn_AgregarCausa_Click(object sender, EventArgs e)
        {
            if (!CamposVaciosExtras())
            {
                string v_nombre_causa = cmb_Causa.Text.ToString();
                string v_nombre_horario = cmb_Horario.Text.ToString();
                string v_unidad_causa = lbl_Unidad.Text;
                decimal n_precio_causa = Convert.ToDecimal(txt_Precio.EditValue.ToString());
                int n_cantidad_causa = Convert.ToInt32(txt_Cajas_O.Text);
                decimal n_total_causa = Convert.ToDecimal(txt_Total.EditValue.ToString());
                DateTime d_fecha_inicio_maq = Convert.ToDateTime(dtFechaInicio.EditValue.ToString());
                DateTime d_fecha_fin_maq = Convert.ToDateTime(dtFechaFin.EditValue.ToString()); ;
                DateTime d_fecha_causa = Convert.ToDateTime(d_FechaCausa.EditValue.ToString()); ;
                int n_semana_maq = Convert.ToInt32(txtSemana.Text);
                int n_secuencia = vn_SecuenciaX + 1;

                CreatNewRowExtra(n_semana_maq.ToString(), n_secuencia.ToString(), v_nombre_causa, v_nombre_horario, v_unidad_causa
                          , n_precio_causa.ToString(), n_cantidad_causa.ToString(), n_total_causa.ToString(), d_fecha_inicio_maq, d_fecha_fin_maq, d_fecha_causa);
                LimpiaCausaExtra();
                CargarTotalExtra();
            }
        }

        private void btn_Quitar_causa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(v_secuencia) && !string.IsNullOrEmpty(Convert.ToString(v_semana)) && !string.IsNullOrEmpty(v_FechaInicio) && !string.IsNullOrEmpty(v_FechaFin))
            {
                CLS_Reempaques del = new CLS_Reempaques();
                del.n_secuencia = Convert.ToInt32(v_secuenciaX);
                del.n_semana_maq = Convert.ToInt32(v_semanaX);
                del.MtdEliminarCausaExtra();
                if (del.Exito)
                {
                    LimpiaReempaques();
                    CargarExtra();
                    XtraMessageBox.Show("Se ha eliminado el dato con exito");
                }
                else
                {
                    XtraMessageBox.Show(del.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado pais para quitar");
            }
        }

        private void dtgCausaExtra_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValCausaExtra.GetSelectedRows())
                {
                    DataRow row = this.dtgValCausaExtra.GetDataRow(i);
                    v_secuenciaX = row["n_secuencia"].ToString();
                    v_semanaX = txtSemana.EditValue.ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgValMaquila_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            dtgValMaquila.UpdateSummary();
        }
    }
}