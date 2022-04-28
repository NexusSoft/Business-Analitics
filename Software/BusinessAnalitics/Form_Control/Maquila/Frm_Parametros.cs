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
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;

namespace Business_Analitics
{
    public partial class Frm_Parametros : DevExpress.XtraEditors.XtraForm
    {
        public NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        public CultureInfo culture = CultureInfo.CreateSpecificCulture("es-MX");

        private decimal vPrecioNacional;
        private decimal vPrecioMalla;
        private decimal vPrecioAPEAM;
        private decimal vPrecioCharola25Lb;
        private decimal vPrecioCharolaRPC;
        private decimal vPrecioCarton25Lb;
        private decimal vPrecioCaja10kg;
        private decimal vPrecioCaja6kg;
        private decimal vPrecioCaja4kg;
        private decimal vPrecioCajaSAMS;
        private decimal vPrecioCajaRPC;

        public string vc_codigo_mat25 { get;  set; }
        public string vc_codigo_matRPC { get;  set; }
        public string vPrecioMaquilaId { get;  set; }
        public bool PrimeraEdicionC { get;  set; }
        public string vc_codigo_pai { get;  set; }
        public string vc_codigo_matMalla { get;  set; }
        public string vc_codigo_pro { get; private set; }

        public Frm_Parametros()
        {
            InitializeComponent();
        }

        private void FrmParametros_Shown(object sender, EventArgs e)
        {
            PrimeraEdicionC = false;
            CargarPrecioTermos();
            CargarPrecios();
            CargarPaisAPEAM();
            CargarProductosO(null);
            CargarProductosExc();
            dtgValPrecioTermo.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValPrecioTermo.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValPrecioTermo.OptionsSelection.MultiSelect = true;
            dtgValPrecioTermo.OptionsView.ShowGroupPanel = false;

            

            dtgValAPEAM.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValAPEAM.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValAPEAM.OptionsSelection.MultiSelect = true;
            dtgValAPEAM.OptionsView.ShowGroupPanel = false;

            gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn2.DisplayFormat.FormatString = "###,###0";
            gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn3.DisplayFormat.FormatString = "###,###0";
            gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn4.DisplayFormat.FormatString = "$ ###,###0.000000";

            txtPrecioNacional.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioNacional.Properties.Mask.EditMask = "c6";
            txtPrecioNacional.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioMalla.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioMalla.Properties.Mask.EditMask = "c6";
            txtPrecioMalla.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioAPEAM.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioAPEAM.Properties.Mask.EditMask = "c6";
            txtPrecioAPEAM.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecio25Lb.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecio25Lb.Properties.Mask.EditMask = "c6";
            txtPrecio25Lb.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioRPC.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioRPC.Properties.Mask.EditMask = "c6";
            txtPrecioRPC.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioCarton25lb.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioCarton25lb.Properties.Mask.EditMask = "c6";
            txtPrecioCarton25lb.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioCaja10kg.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioCaja10kg.Properties.Mask.EditMask = "c6";
            txtPrecioCaja10kg.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioCaja6kg.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioCaja6kg.Properties.Mask.EditMask = "c6";
            txtPrecioCaja6kg.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioCaja4kg.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioCaja4kg.Properties.Mask.EditMask = "c6";
            txtPrecioCaja4kg.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioCajaRPC.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioCajaRPC.Properties.Mask.EditMask = "c6";
            txtPrecioCajaRPC.Properties.Mask.UseMaskAsDisplayFormat = true;

            txtPrecioCajaSAMS.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecioCajaSAMS.Properties.Mask.EditMask = "c6";
            txtPrecioCajaSAMS.Properties.Mask.UseMaskAsDisplayFormat = true;
        }
        
        private void CargarPaisAPEAM()
        {
            CLS_Parametros sel = new CLS_Parametros();
            sel.MtdSeleccionarParametroAPEAM();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgAPEAM.DataSource = sel.Datos;
                }
            }
        }
        private void CargarProductosExc()
        {
            CLS_Parametros sel = new CLS_Parametros();
            sel.MtdSeleccionarParametroProductoExt();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgProductoExc.DataSource = sel.Datos;
                }
            }
        }
        private void CargarPrecios()
        {
            CLS_Parametros sel = new CLS_Parametros();
            sel.MtdSeleccionarParametroPrecios();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    txtPrecioNacional.Text = sel.Datos.Rows[0]["PrecioNacional"].ToString();
                    txtPrecioMalla.Text = sel.Datos.Rows[0]["PrecioMalla"].ToString();
                    txtPrecioAPEAM.Text = sel.Datos.Rows[0]["PrecioAPEAM"].ToString();
                    txtPrecio25Lb.Text = sel.Datos.Rows[0]["PrecioCharola25Lb"].ToString();
                    txtPrecioRPC.Text = sel.Datos.Rows[0]["PrecioCharolaRPC"].ToString();
                    txtPrecioCarton25lb.Text = sel.Datos.Rows[0]["PrecioCarton25Lb"].ToString();
                    txtPrecioCaja10kg.Text = sel.Datos.Rows[0]["PrecioCaja10kg"].ToString();
                    txtPrecioCaja6kg.Text = sel.Datos.Rows[0]["PrecioCaja6kg"].ToString();
                    txtPrecioCaja4kg.Text = sel.Datos.Rows[0]["PrecioCaja4kg"].ToString();
                    txtPrecioCajaSAMS.Text = sel.Datos.Rows[0]["PrecioCajaSAMS"].ToString();
                    txtPrecioCajaRPC.Text = sel.Datos.Rows[0]["PrecioCajaRPC"].ToString();
                }
            }
        }
        private void CargarPrecioTermos()
        {
            CLS_Parametros sel = new CLS_Parametros();
            sel.MtdSeleccionarParametroTermo();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgPrecioTermo.DataSource = sel.Datos;
                }
            }
        }
        public void CargarProductosO(string Valor)
        {
            CLS_Productos sel = new CLS_Productos();
            sel.MtdSeleccionarProductosExcluidos();
            if (sel.Exito)
            {
                cmb_Producto_O.Properties.DisplayMember = "v_nombre_pro";
                cmb_Producto_O.Properties.ValueMember = "c_codigo_pro";
                cmb_Producto_O.EditValue = Valor;
                cmb_Producto_O.Properties.DataSource = sel.Datos;
            }
        }
        
        private void btnAgregarPais_Click(object sender, EventArgs e)
        {
            Frm_Paises frm = new Frm_Paises();
            frm.ShowDialog();
            CargarPaisAPEAM();
        }
        private void btnQuitarPais_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(vc_codigo_pai))
            {
                CLS_Parametros del = new CLS_Parametros();
                del.c_codigo_pai = vc_codigo_pai;
                del.MtdProductoAPEAM_Delete();
                if (del.Exito)
                {
                    CargarPaisAPEAM();
                    XtraMessageBox.Show("se ha eliminado el dato con exito");
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
        private void dtgPrecioTermo_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValPrecioTermo.GetSelectedRows())
                {
                    DataRow row = this.dtgValPrecioTermo.GetDataRow(i);
                    vPrecioMaquilaId = row["PrecioMaquilaId"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtPrecioNacional.Text!=string.Empty)
            {
                if (txtPrecioMalla.Text != string.Empty)
                {
                    if (txtPrecioAPEAM.Text != string.Empty)
                    {
                        if (txtPrecio25Lb.Text != string.Empty)
                        {
                            if (txtPrecioRPC.Text != string.Empty)
                            {
                                if (txtPrecioCarton25lb.Text != string.Empty)
                                {
                                    if (txtPrecioCaja10kg.Text != string.Empty)
                                    {
                                        if (txtPrecioCaja6kg.Text != string.Empty)
                                        {
                                            if (txtPrecioCaja4kg.Text != string.Empty)
                                            {
                                                if (txtPrecioCajaSAMS.Text != string.Empty)
                                                {
                                                    if (txtPrecioCajaRPC.Text != string.Empty)
                                                    {
                                                        CLS_Parametros udp = new CLS_Parametros();
                                                        Decimal.TryParse(txtPrecioNacional.Text, style, culture, out vPrecioNacional);
                                                        udp.PrecioNacional = vPrecioNacional;
                                                        Decimal.TryParse(txtPrecioMalla.Text, style, culture, out vPrecioMalla);
                                                        udp.PrecioMalla = vPrecioMalla;
                                                        Decimal.TryParse(txtPrecioAPEAM.Text, style, culture, out vPrecioAPEAM);
                                                        udp.PrecioAPEAM = vPrecioAPEAM;
                                                        Decimal.TryParse(txtPrecio25Lb.Text, style, culture, out vPrecioCharola25Lb);
                                                        udp.PrecioCharola25Lb = vPrecioCharola25Lb;
                                                        Decimal.TryParse(txtPrecioRPC.Text, style, culture, out vPrecioCharolaRPC);
                                                        udp.PrecioCharolaRPC = vPrecioCharolaRPC;
                                                        Decimal.TryParse(txtPrecioCarton25lb.Text, style, culture, out vPrecioCarton25Lb);
                                                        udp.PrecioCarton25Lb = vPrecioCarton25Lb;
                                                        Decimal.TryParse(txtPrecioCaja10kg.Text, style, culture, out vPrecioCaja10kg);
                                                        udp.PrecioCaja10kg = vPrecioCaja10kg;
                                                        Decimal.TryParse(txtPrecioCaja6kg.Text, style, culture, out vPrecioCaja6kg);
                                                        udp.PrecioCaja6kg = vPrecioCaja6kg;
                                                        Decimal.TryParse(txtPrecioCaja4kg.Text, style, culture, out vPrecioCaja4kg);
                                                        udp.PrecioCaja4kg = vPrecioCaja4kg;
                                                        Decimal.TryParse(txtPrecioCajaRPC.Text, style, culture, out vPrecioCajaRPC);
                                                        udp.PrecioCajaRPC = vPrecioCajaRPC;
                                                        Decimal.TryParse(txtPrecioCajaSAMS.Text, style, culture, out vPrecioCajaSAMS);
                                                        udp.PrecioCajaSAMS = vPrecioCajaSAMS;

                                                        udp.MtdPrecio_Update();
                                                        if (udp.Exito)
                                                        {
                                                            XtraMessageBox.Show("Se han guardado los precios con exito");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        XtraMessageBox.Show("Falta captura de precio Caja RPC");
                                                    }
                                                }
                                                else
                                                {
                                                    XtraMessageBox.Show("Falta captura de precio Caja SAMS");
                                                }
                                            }
                                            else
                                            {
                                                XtraMessageBox.Show("Falta captura de precio Caja 4kg");
                                            }
                                        }
                                        else
                                        {
                                            XtraMessageBox.Show("Falta captura de precio Caja 6kg");
                                        }
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("Falta captura de precio Caja 10kg");
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("Falta captura de precio Carton 25lb");
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("Falta captura de precio RPC");
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Falta captura de precio 25Lb");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Falta captura de precio Apeam");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Falta captura de precio Malla");
                }
            }
            else
            {
                XtraMessageBox.Show("Falta captura de precio Naconal");
            }
        }

        private void dtgValPrecioTermo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!PrimeraEdicionC == true)
            {
                PrimeraEdicionC = true;
                CLS_Parametros udp = new CLS_Parametros();
                GridView gv = sender as GridView;
                udp.PrecioMaquilaDesde=Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["PrecioMaquilaDesde"]).ToString());
                udp.PrecioMaquilaHasta = Convert.ToInt32(gv.GetRowCellValue(e.RowHandle, gv.Columns["PrecioMaquilaHasta"]).ToString());
                udp.PrecioMaquilaCosto = Convert.ToDecimal(gv.GetRowCellValue(e.RowHandle, gv.Columns["PrecioMaquilaCosto"]).ToString());
                udp.PrecioMaquilaId= gv.GetRowCellValue(e.RowHandle, gv.Columns["PrecioMaquilaId"]).ToString();
                udp.MtdPrecioTermo_Update();
                PrimeraEdicionC = false;
            }
        }

        private void dtgAPEAM_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValAPEAM.GetSelectedRows())
                {
                    DataRow row = this.dtgValAPEAM.GetDataRow(i);
                    vc_codigo_pai = row["c_codigo_pai"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void btnAgregarEx_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmb_Producto_O.EditValue.ToString()))
                {
                    CLS_Parametros ins = new CLS_Parametros();
                    ins.c_codigo_pro = cmb_Producto_O.EditValue.ToString();
                    ins.v_nombre_pro = cmb_Producto_O.Text;
                    ins.MtdProductoExc_Insert();
                    if(ins.Exito)
                    {
                        CargarProductosExc();
                        CargarProductosO(null);
                    }
                    else
                    {
                        XtraMessageBox.Show(ins.Mensaje);
                    }
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("No se ha seleccionado un producto para agregar");

            }
        }

        private void btnQuitarEx_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(vc_codigo_pro))
            {
                CLS_Parametros del = new CLS_Parametros();
                del.c_codigo_pro = vc_codigo_pro;
                del.MtdProductoExc_Delete();
                if (del.Exito)
                {
                    CargarProductosExc();
                    CargarProductosO(null);
                    XtraMessageBox.Show("se ha eliminado el dato con exito");
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

        private void dtgProductoExc_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValProductoExc.GetSelectedRows())
                {
                    DataRow row = this.dtgValProductoExc.GetDataRow(i);
                    vc_codigo_pro = row["c_codigo_pro"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnAgregarCharola25lb_Click(object sender, EventArgs e)
        {
            Frm_Materiales frm = new Frm_Materiales();
            frm.v_Opcion = 1;
            frm.Text = "Materiales Charola 25Lb";
            frm.ShowDialog();
        }

        private void btnAgregarMalla_Click(object sender, EventArgs e)
        {
            Frm_Materiales frm = new Frm_Materiales();
            frm.v_Opcion = 3;
            frm.Text = "Materiales Malla";
            frm.ShowDialog();
        }

        private void btnAgregarCharolaRPC_Click(object sender, EventArgs e)
        {
            Frm_Materiales frm = new Frm_Materiales();
            frm.v_Opcion = 2;
            frm.Text = "Materiales Charola RPC";
            frm.ShowDialog();
        }

        private void btnAgregarCarton25lb_Click(object sender, EventArgs e)
        {
            Frm_Materiales frm = new Frm_Materiales();
            frm.v_Opcion = 4;
            frm.Text = "Materiales Cartón 25 Lb";
            frm.ShowDialog();
        }

        private void btnAgregarCaja10kg_Click(object sender, EventArgs e)
        {
            Frm_Materiales frm = new Frm_Materiales();
            frm.v_Opcion = 5;
            frm.Text = "Materiales Caja 10kg";
            frm.ShowDialog();
        }

        private void btnAgregarCaja6kg_Click(object sender, EventArgs e)
        {
            Frm_Materiales frm = new Frm_Materiales();
            frm.v_Opcion = 6;
            frm.Text = "Materiales Caja 6kg";
            frm.ShowDialog();
        }

        private void btnAgregarCaja4kg_Click(object sender, EventArgs e)
        {
            Frm_Materiales frm = new Frm_Materiales();
            frm.v_Opcion = 7;
            frm.Text = "Materiales Caja 4kg";
            frm.ShowDialog();
        }

        private void btnAgregarCajaSAMS_Click(object sender, EventArgs e)
        {
            Frm_Materiales frm = new Frm_Materiales();
            frm.v_Opcion = 8;
            frm.Text = "Materiales Caja SAMS";
            frm.ShowDialog();
        }

        private void btnAgregarCajaRPC_Click(object sender, EventArgs e)
        {
            Frm_Materiales frm = new Frm_Materiales();
            frm.v_Opcion = 9;
            frm.Text = "Materiales Caja RPC";
            frm.ShowDialog();
        }
    }
}