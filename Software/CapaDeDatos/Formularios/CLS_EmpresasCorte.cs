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
        public decimal Menor_a_kg { get; set; }
        public decimal Precio_kilo { get; set; }
        public decimal Precio_Dia { get; set; }
        public int EsRango { get; set; }
        public decimal Precio_Cuadrilla_Apoyo { get; set; }
        public decimal Precio_Salida_Falso { get; set; }
        public decimal Kilos_MenorA { get; set; }
        public decimal Kilos_MayorA { get; set; }
        public decimal Precio_MenorA { get; set; }
        public decimal Precio_MayorA { get; set; }
        public int EsRangoCaja { get; set; }
        public decimal Cajas_MenorA { get; set; }
        public decimal Cajas_MayorA { get; set; }
        public decimal PrecioCaja_MenorA { get; set; }
        public decimal PrecioCaja_MayorA { get; set; }

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
                _dato.Decimal = Menor_a_kg;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Menor_a_kg");
                _dato.Decimal = Precio_Dia;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_Dia");
                _dato.Entero = EsRango;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EsRango");
                _dato.Decimal = Precio_Cuadrilla_Apoyo;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_Cuadrilla_Apoyo");
                _dato.Decimal = Kilos_MenorA;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Kilos_MenorA");
                _dato.Decimal = Kilos_MayorA;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Kilos_MayorA");
                _dato.Decimal = Precio_MenorA;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_MenorA");
                _dato.Decimal = Precio_MayorA;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_MayorA");
                _dato.Entero = EsRangoCaja;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EsRangoCaja");
                _dato.Decimal = Precio_kilo;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_kilo");
                _dato.Decimal = Cajas_MenorA;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Cajas_MenorA");
                _dato.Decimal = Cajas_MayorA;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Cajas_MayorA");
                _dato.Decimal = PrecioCaja_MenorA;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioCaja_MenorA");
                _dato.Decimal = PrecioCaja_MayorA;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "PrecioCaja_MayorA");
                _dato.Decimal = Precio_Salida_Falso;
                _conexion.agregarParametro(EnumTipoDato.Decimal, _dato, "Precio_Salida_Falso");
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
