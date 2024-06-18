using System;

namespace CapaDeDatos
{
    public class CLS_EmpresasCorte : ConexionBase
    {
        public string Id_EmpresaCorte { get; set; }
        public string Nombre_EmpresaCorte { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }
        public string RFC { get; set; }
        public string Usuario { get; set; }

        //Servicios
        public decimal Precio_kilo_Local { get; set; }
        public decimal PorcentajeTolerancia { get; set; }
        public decimal Kilos_MenorA_Local { get; set; }
        public decimal Precio_MenorA_Local { get; set; }
        public decimal Precio_Cuadrilla_Apoyo_Local { get; set; }
        public decimal Precio_kilo_Foraneo { get; set; }
        public decimal Kilos_MenorA_Foraneo { get; set; }
        public decimal Precio_MenorA_Foraneo { get; set; }
        public decimal Precio_Cuadrilla_Apoyo_Foraneo { get; set; }
        

        public void MtdSeleccionarEmpresas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Corte_Select";

                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }

        }
        public void MtdInsertarEmpresas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Corte_Insert";
                _dato.Texto = Id_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaCorte");
                _dato.Texto = Nombre_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_EmpresaCorte");
                _dato.Texto = Telefono1;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Telefono1");
                _dato.Texto = Telefono2;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Telefono2");
                _dato.Texto = Email;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Email");
                _dato.Texto = Contacto;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Contacto");
                _dato.Texto = RFC;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "RFC");
                _dato.Texto = Usuario;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Usuario");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }
        public void MtdEliminarEmpresas()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Corte_Delete";
                _dato.Texto = Id_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaCorte");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }

        // Servicios
        public void MtdSeleccionarEmpresasServicios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Corte_Servicios_Select";
                _dato.Texto = Id_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaCorte");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }

        }
        public void MtdInsertarEmpresasServicios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Corte_Servicios_Insert";
                _dato.Texto = Id_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaCorte");
                _dato.Decimal = Precio_kilo_Local;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_kilo_Local");
                _dato.Decimal = PorcentajeTolerancia;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PorcentajeTolerancia");
                _dato.Decimal = Kilos_MenorA_Local;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Kilos_MenorA_Local");
                _dato.Decimal = Precio_MenorA_Local;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_MenorA_Local");
                _dato.Decimal = Precio_Cuadrilla_Apoyo_Local;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_Cuadrilla_Apoyo_Local");
                _dato.Decimal = Precio_kilo_Foraneo;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_kilo_Foraneo");
                _dato.Decimal = Kilos_MenorA_Foraneo;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Kilos_MenorA_Foraneo");
                _dato.Decimal = Precio_MenorA_Foraneo;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_MenorA_Foraneo");
                _dato.Decimal = Precio_Cuadrilla_Apoyo_Foraneo;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_Cuadrilla_Apoyo_Foraneo");
                _dato.Texto = Usuario;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Usuario");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }
        public void MtdEliminarEmpresasServicios()
        {
            TipoDato _dato = new TipoDato();
            Conexion _conexion = new Conexion(cadenaConexion);

            Exito = true;
            try
            {
                _conexion.NombreProcedimiento = "SP_Empresa_Corte_Servicios_Delete";
                _dato.Texto = Id_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaCorte");
                _conexion.EjecutarDataset();

                if (_conexion.Exito)
                {
                    Datos = _conexion.Datos;
                }
                else
                {
                    Mensaje = _conexion.Mensaje;
                    Exito = false;
                }
            }
            catch (Exception e)
            {
                Mensaje = e.Message;
                Exito = false;
            }
        }

    }
}
