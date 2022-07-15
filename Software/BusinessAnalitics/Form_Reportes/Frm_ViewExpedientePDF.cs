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
    public partial class Frm_ViewExpedientePDF : DevExpress.XtraEditors.XtraForm
    {

        public string Id_Cosecha { get; set; }
        public int Id_Archivo { get; set; }
        public string UUID { get; set; }
        public Frm_ViewExpedientePDF()
        {
            InitializeComponent();
        }

        private void Frm_ViewPDFSalidas_Load(object sender, EventArgs e)
        {
            if (Id_Archivo < 8)
            {
                CLS_Cosecha_Expedientes sel = new CLS_Cosecha_Expedientes();
                sel.Id_Cosecha = Id_Cosecha;
                sel.Id_Doc = Id_Archivo;
                sel.MtdSeleccionarCosechaArchivoPDFXMLView();
                if (sel.Exito)
                {
                    if (sel.Datos.Rows.Count > 0 && sel.Datos.Rows[0]["Archivo"] != null)
                    {
                        byte[] bytes = (byte[])sel.Datos.Rows[0]["Archivo"];
                        if (bytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf", bytes);
                            this.pdfViewer1.LoadDocument(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show(sel.Mensaje);
                }
            }
            else if(Id_Archivo ==8)
            {
                CLS_Cosecha_Datos sel = new CLS_Cosecha_Datos();
                sel.Id_Cosecha = Id_Cosecha;
                sel.MtdSelecccionarComercializadora();
                if (sel.Exito)
                {
                    if (sel.Datos.Rows.Count > 0 && sel.Datos.Rows[0]["Contrato"] != null)
                    {
                        byte[] bytes = (byte[])sel.Datos.Rows[0]["Contrato"];
                        if (bytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf", bytes);
                            this.pdfViewer1.LoadDocument(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show(sel.Mensaje);
                }
            }
            else if (Id_Archivo == 9)
            {
                CLS_Cosecha_Facturas sel = new CLS_Cosecha_Facturas();
                sel.Id_Cosecha = Id_Cosecha;
                sel.UUID = UUID;
                sel.MtdSeleccionarCosechaArchivoREP_PDFXMLView();
                if (sel.Exito)
                {
                    if (sel.Datos.Rows.Count > 0 && sel.Datos.Rows[0]["FacturaPDF"] != null)
                    {
                        byte[] bytes = (byte[])sel.Datos.Rows[0]["FacturaPDF"];
                        if (bytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf", bytes);
                            this.pdfViewer1.LoadDocument(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show(sel.Mensaje);
                }
            }
        }
    }
}