using System;
using System.Drawing;
using TECIT.TBarCode;

namespace Business_Analitics
{
    public class Codigos_TEC_IT
    {
        public static void CodigosBarraUPCA(string _Code)
        {
            try
            {
                Barcode CodigoB = new Barcode();
                CodigoB.License("Mem: San Tadeo y Socios S.A. de R.L, MX-60090", LicenseType.DeveloperOrWeb, 1, "235E63BEE3DF54A2359844D20E268510", TBarCodeProduct.Barcode2D);
                CodigoB.BarcodeType = BarcodeType.UpcA;
                CodigoB.Data = _Code;
                CodigoB.CharacterSpacing = 1;
                CodigoB.CheckdigitMethod = CheckdigitMethod.UpcA;
                CodigoB.TextDistance = 1.3F;
                // CodigoB.BearerBarType = TECIT.TBarCode.BearerBarType.TopAndBottom;

                CodigoB.BearerBarWidth = 2.4F;

                CodigoB.QuietZones.Unit = QuietZoneUnit.Modules;

                Single moduleWidth = 0.5004926F;
                CodigoB.SizeMode = TECIT.TBarCode.SizeMode.CustomModuleWidth;
                CodigoB.ModuleWidth = moduleWidth + 0.001;
                CodigoB.AdjustModuleWidthToPixelRaster = true;
                CodigoB.Dpi = 203F;

                Single width = CodigoB.CalculateBarcodeWidth(null);
                Single height = 35;


                width = width / (Convert.ToSingle(25.4) / Convert.ToSingle(CodigoB.Dpi));
                height = height / (Convert.ToSingle(25.4) / Convert.ToSingle(CodigoB.Dpi));

                CodigoB.Font = new System.Drawing.Font("Arial", 13, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                CodigoB.BoundingRectangle = new Rectangle((int)(0), // X
                                                                 (int)(0), // Y
                                                                 (int)(width), // Width
                                                                 (int)(height));// Height

                CodigoB.Draw("C:\\Etiquetas\\CodeBarUPCA1.bmp", TECIT.TBarCode.ImageType.Bmp);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al generar el codigo" + ex.ToString());
            }
        }
    }
}
