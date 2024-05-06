using BusinessAnalitics.Form_Catalogos.Acarreo;
using CapaDeDatos;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BusinessAnalitics
{
    public partial class Frm_Acopio_Precios : DevExpress.XtraEditors.XtraForm
    {
        public Boolean PaSel { get; set; }
        public string IdPerfil { get; set; }
        public string UsuariosLogin { get; set; }
        public string c_codigo_est { get; set; }
        NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        CultureInfo provider = new CultureInfo("es-MX");
        private static Frm_Acopio_Precios m_FormDefInstance;
        public static Frm_Acopio_Precios DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Acopio_Precios();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public string ParFechaInicio { get; set; }
        public string ParFechaFin { get; set; }
        public Frm_Acopio_Precios()
        {
            InitializeComponent();
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
        private void MakeTablaExportacion()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column = new DataColumn();
            table.Reset();

            // DataRow row;
            
            column.DataType = typeof(string);
            column.ColumnName = "col_E_Categoria";
            column.AutoIncrement = false;
            column.Caption = "Categoria";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_E_Calibre";
            column.AutoIncrement = false;
            column.Caption = "Calibre";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_E_Gramaje";
            column.AutoIncrement = false;
            column.Caption = "Gramaje";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "col_E_Precio";
            column.AutoIncrement = false;
            column.Caption = "Precio";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "col_E_Orden";
            column.AutoIncrement = false;
            column.Caption = "Orden";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgExportacion.DataSource = table;
        }
        public void CargarTablaExp()
        {
            for (int i = 0; i < 17; i++)
            {
                dtgValExportacion.AddNewRow();

                int rowHandle = dtgValExportacion.GetRowHandle(dtgValExportacion.DataRowCount);
                switch (i)
                {
                    case 0:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i+1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat1");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "32s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "330 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 1:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat1");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "36s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "300-330 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 2:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat1");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "40s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "270-300 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 3:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat1");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "48s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "210-270 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 4:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat1");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "60s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "180-210 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 5:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat1");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "70s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "150-180 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 6:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat1");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "84s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "120-150 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 7:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat2");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "32s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "330 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 8:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat2");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "36s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "300-330 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 9:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat2");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "40s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "270-300 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 10:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat2");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "48s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "210-270 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 11:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat2");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "60s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "180-210 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 12:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat2");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "70s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "150-180 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 13:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat2");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "84s");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "120-150 grs");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 14:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat2");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "Proceso");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "-");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 15:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat2");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "Cuarta");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "-");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                    case 16:
                        if (dtgValExportacion.IsNewItemRow(rowHandle))
                        {
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Orden"], i + 1);
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Categoria"], "Cat2");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Calibre"], "Desecho");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Gramaje"], "-");
                            dtgValExportacion.SetRowCellValue(rowHandle, dtgValExportacion.Columns["col_E_Precio"], "0");
                        }
                        break;
                }
            }
        }
        private void MakeTablaNacional()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column = new DataColumn();
            table.Reset();

            // DataRow row;
            
            column.DataType = typeof(decimal);
            column.ColumnName = "col_N_Orden";
            column.AutoIncrement = false;
            column.Caption = "Orden";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_N_Categoria";
            column.AutoIncrement = false;
            column.Caption = "Categoria";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_N_Calibre";
            column.AutoIncrement = false;
            column.Caption = "Calibre";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_N_Gramaje";
            column.AutoIncrement = false;
            column.Caption = "Gramaje";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "col_N_Precio";
            column.AutoIncrement = false;
            column.Caption = "Precio";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgNacional.DataSource = table;
        }
        public void CargarTablaNal()
        {
            for (int i = 0; i < 17; i++)
            {
                dtgValNacional.AddNewRow();

                int rowHandle = dtgValNacional.GetRowHandle(dtgValNacional.DataRowCount);
                switch (i)
                {
                    case 0:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat1");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "32s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "330 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 1:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat1");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "36s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "300-330 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 2:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat1");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "40s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "270-300 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 3:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat1");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "48s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "210-270 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 4:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat1");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "60s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "180-210 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 5:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat1");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "70s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "150-180 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 6:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat1");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "84s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "120-150 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 7:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat2");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "32s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "330 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 8:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat2");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "36s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "300-330 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 9:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat2");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "40s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "270-300 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 10:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat2");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "48s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "210-270 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 11:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat2");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "60s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "180-210 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 12:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat2");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "70s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "150-180 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 13:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat2");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "84s");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "120-150 grs");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 14:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat2");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "Proceso");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "-");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 15:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat2");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "Cuarta");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "-");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                    case 16:
                        if (dtgValNacional.IsNewItemRow(rowHandle))
                        {
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Orden"], i + 1);
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Categoria"], "Cat2");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Calibre"], "Desecho");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Gramaje"], "-");
                            dtgValNacional.SetRowCellValue(rowHandle, dtgValNacional.Columns["col_N_Precio"], "0");
                        }
                        break;
                }
            }
        }
        private void Frm_Precios_Load(object sender, EventArgs e)
        {
            MakeTablaExportacion();
            CargarTablaExp();
            MakeTablaNacional();
            CargarTablaNal();
            col_E_Precio.DisplayFormat.FormatType = FormatType.Numeric;
            col_E_Precio.DisplayFormat.FormatString = "c2";
            col_N_Precio.DisplayFormat.FormatType = FormatType.Numeric;
            col_N_Precio.DisplayFormat.FormatString = "c2";
            dt_FInicio.DateTime = DateTime.Now;
            dt_FFin.DateTime = DateTime.Now;
            txt_estiba.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txt_estiba.Properties.DisplayFormat.FormatString = "{0:d10}";
        }

        void EliminaPrecios()
        {
            CLS_AcarreroPrecios del = new CLS_AcarreroPrecios();
            del.FechaInicio = ParFechaInicio.ToString();
            del.FechaFin = ParFechaFin.ToString();
            del.Estiba = txt_estiba.Text.ToString();
            if (chk_Todas.Checked == true)
            {
                del.Todas = 1;
            }
            else
            {
                del.Todas = 0;
            }
            del.MtdEliminarAcopioPrecioRango();
            if (!del.Exito)
            {
                XtraMessageBox.Show(del.Mensaje);
            }
        }
        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txt_estiba.Focus();
            if (DateTime.Compare(Convert.ToDateTime(dt_FInicio.EditValue), Convert.ToDateTime(dt_FFin.EditValue)) <= 0)
            {
                DateTime FInicio = Convert.ToDateTime(dt_FInicio.EditValue.ToString());
                DateTime FFin = Convert.ToDateTime(dt_FFin.EditValue.ToString());
                ParFechaInicio = FInicio.Year.ToString() + "-" + DosCeros(FInicio.Month.ToString()) + "-" + DosCeros(FInicio.Day.ToString()) + " 00:00:00";
                ParFechaFin = FFin.Year.ToString() + "-" + DosCeros(FFin.Month.ToString()) + "-" + DosCeros(FFin.Day.ToString()) + " 23:59:59";
                

                if (!ExistenPreciosFechas())
                {
                    GuardarPrecios(FInicio, FFin);

                }
                else
                {
                    DialogResult = XtraMessageBox.Show("¿Existen precios en los dias seleccionados deseas sobre escribir estos precios?", "Actualizacion de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (DialogResult == DialogResult.Yes)
                    {
                        EliminaPrecios();
                        GuardarPrecios(FInicio, FFin);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("La Fecha de inicio es mayor a la fecha Fin");
            }
        }

        private void GuardarPrecios(DateTime FInicio, DateTime FFin)
        {
            TimeSpan rango = FFin - FInicio;
            int dias = rango.Days;
            for (int i = 0; i <= dias; i++)
            {
                CLS_AcarreroPrecios ins = new CLS_AcarreroPrecios();
                ins.Id_AcopioPrecios = txt_Id.Text;
                ParFechaInicio = FInicio.Year.ToString() + "-" + DosCeros(FInicio.Month.ToString()) + "-" + DosCeros(FInicio.Day.ToString()) + " 00:00:00";
                ins.Fecha = ParFechaInicio;
                ins.Estiba = txt_estiba.Text;
                if (chk_Todas.Checked == true)
                {
                    ins.Todas = 1;
                }
                else
                {
                    ins.Todas = 0;
                }
                ins.Usuario = UsuariosLogin;
                ins.MtdInsertarAcopioPrecio_Encabezado();
                if (ins.Exito)
                {
                    string Folio = ins.Datos.Rows[0]["Id_AcopioPrecios"].ToString();
                    for (int x = 0; x < dtgValExportacion.RowCount; x++)
                    {
                        try
                        {
                            CLS_AcarreroPrecios insDE = new CLS_AcarreroPrecios();
                            int xRow = dtgValExportacion.GetVisibleRowHandle(x + 1);
                            string Orden = dtgValExportacion.GetRowCellValue(xRow, "col_E_Orden").ToString();
                            string Mercado = "Exportacion";
                            string Categoria = dtgValExportacion.GetRowCellValue(xRow, "col_E_Categoria").ToString();
                            string Calibre = dtgValExportacion.GetRowCellValue(xRow, "col_E_Calibre").ToString();
                            string Gramaje = dtgValExportacion.GetRowCellValue(xRow, "col_E_Gramaje").ToString();
                            decimal Precio = Decimal.Parse(dtgValExportacion.GetRowCellValue(xRow, "col_E_Precio").ToString(), style, provider);
                            insDE.Id_AcopioPrecios = Folio;
                            insDE.Mercado = Mercado;
                            insDE.Orden = Convert.ToInt32(Orden);
                            insDE.Categoria = Categoria;
                            insDE.Calibre = Calibre;
                            insDE.Gramaje = Gramaje;
                            insDE.Precio = Precio;
                            insDE.Usuario = UsuariosLogin;
                            insDE.MtdInsertarAcopioPrecio_Detalles();
                            if (!insDE.Exito)
                            {
                                XtraMessageBox.Show(ins.Mensaje);
                            }
                        }
                        catch
                        {

                        }
                    }
                    for (int x = 0; x < dtgValNacional.RowCount; x++)
                    {
                        try
                        {
                            CLS_AcarreroPrecios insDN = new CLS_AcarreroPrecios();
                            int xRow = dtgValNacional.GetVisibleRowHandle(x + 1);
                            string Orden = dtgValNacional.GetRowCellValue(xRow, "col_N_Orden").ToString();
                            string Mercado = "Nacional";
                            string Categoria = dtgValNacional.GetRowCellValue(xRow, "col_N_Categoria").ToString();
                            string Calibre = dtgValNacional.GetRowCellValue(xRow, "col_N_Calibre").ToString();
                            string Gramaje = dtgValNacional.GetRowCellValue(xRow, "col_N_Gramaje").ToString();
                            decimal Precio = Decimal.Parse(dtgValNacional.GetRowCellValue(xRow, "col_N_Precio").ToString(), style, provider);
                            insDN.Id_AcopioPrecios = Folio;
                            insDN.Mercado = Mercado;
                            insDN.Orden = Convert.ToInt32(Orden);
                            insDN.Categoria = Categoria;
                            insDN.Calibre = Calibre;
                            insDN.Gramaje = Gramaje;
                            insDN.Precio = Precio;
                            insDN.Usuario = UsuariosLogin;
                            insDN.MtdInsertarAcopioPrecio_Detalles();
                            if (!insDN.Exito)
                            {
                                XtraMessageBox.Show(ins.Mensaje);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show(ins.Mensaje);
                }
                FInicio = FInicio.AddDays(1);
            }
        }

        private bool ExistenPreciosFechas()
        {
            bool Existen = false;
            CLS_AcarreroPrecios sel = new CLS_AcarreroPrecios();
            sel.FechaInicio=ParFechaInicio.ToString();
            sel.FechaFin=ParFechaFin.ToString();
            sel.Estiba=txt_estiba.Text.ToString();
            if(chk_Todas.Checked == true)
            {
                sel.Todas = 1;
            }
            else
            {
                sel.Todas=0;
            }
            sel.MtdSeleccionarAcopioPrecios_Filtro();
            if(sel.Datos.Rows.Count > 0 )
            {
                Existen = true;
            }
            return Existen;
        }

        private void chk_Todas_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_Todas.Checked==true) 
            { 
                txt_estiba.Text=string.Empty;
                txt_estiba.Enabled=false;
            }
            else
            {
                txt_estiba.Enabled = true;
            }
        }

        private void dtgValExportacion_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
           if(dtgValExportacion.FocusedColumn.FieldName=="col_E_Precio")
            {
                double precio =0;
                if(!Double.TryParse(e.Value as string, out precio))
                {
                    e.Valid = false;
                    e.ErrorText = "Solo se aceptan valores numericos";
                }
                else if (precio < 0)
                {
                    e.Valid = false;
                    e.ErrorText = "El precio debe de ser positivo";
                }
            }
        }

        private void dtgValExportacion_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            XtraMessageBox.Show(this, e.ErrorText, "Valor invalido",MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void dtgValNacional_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (dtgValNacional.FocusedColumn.FieldName == "col_N_Precio")
            {
                double precio = 0;
                if (!Double.TryParse(e.Value as string, out precio))
                {
                    e.Valid = false;
                    e.ErrorText = "Solo se aceptan valores numericos";
                }
                else if (precio < 0)
                {
                    e.Valid = false;
                    e.ErrorText = "El precio debe de ser positivo";
                }
            }
        }

        private void dtgValNacional_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            XtraMessageBox.Show(this, e.ErrorText, "Valor invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txt_Id.Text != string.Empty)
            {
                DialogResult = XtraMessageBox.Show("¿Desea eliminar el dato seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                    CLS_AcarreroPrecios del = new CLS_AcarreroPrecios();
                    del.Id_AcopioPrecios = txt_Id.Text.Trim();
                    del.MtdEliminarAcopioPrecio();
                    if (!del.Exito)
                    {
                        XtraMessageBox.Show(del.Mensaje);
                    }
                    else
                    {
                        XtraMessageBox.Show("Se ha Eliminado el registro con exito");

                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado un registro para eliminar");
            }
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InicializaValores();
            dt_FInicio.DateTime = DateTime.Now;
            dt_FFin.DateTime = DateTime.Now;
        }

        private void InicializaValores()
        {
            for (int i = 0; i < 17; i++)
            {
                dtgValExportacion.AddNewRow();

                int rowHandle = dtgValExportacion.GetRowHandle(i);
                dtgValExportacion.SetRowCellValue(rowHandle, "col_E_Precio", 0);
            }
            for (int i = 0; i < 17; i++)
            {
                dtgValNacional.AddNewRow();

                int rowHandle = dtgValNacional.GetRowHandle(i);
                dtgValNacional.SetRowCellValue(rowHandle, "col_N_Precio", 0);
            }
        }
    }
}