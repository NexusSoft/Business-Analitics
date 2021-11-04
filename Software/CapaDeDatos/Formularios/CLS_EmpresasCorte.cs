using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _dato.CadenaTexto = Id_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaCorte");
                _dato.CadenaTexto = Nombre_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Nombre_EmpresaCorte");
                _dato.CadenaTexto = Telefono1;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Telefono1");
                _dato.CadenaTexto = Telefono2;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Telefono2");
                _dato.CadenaTexto = Email;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Email");
                _dato.CadenaTexto = Contacto;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Contacto");
                _dato.CadenaTexto = RFC;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "RFC");
                _dato.CadenaTexto = Usuario;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Usuario");
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
                _dato.CadenaTexto = Id_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaCorte");
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
                _dato.CadenaTexto = Id_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaCorte");
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
                _dato.CadenaTexto = Id_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaCorte");
                _dato.DecimalValor = Menor_a_kg;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Menor_a_kg");
                _dato.DecimalValor = Precio_kilo;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_kilo");
                _dato.DecimalValor = Precio_Dia;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_Dia");
                _dato.Entero = EsRango;
                _conexion.agregarParametro(EnumTipoDato.Entero, _dato, "EsRango");
                _dato.DecimalValor = Precio_Cuadrilla_Apoyo;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_Cuadrilla_Apoyo");
                _dato.DecimalValor = Kilos_MenorA;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Kilos_MenorA");
                _dato.DecimalValor = Kilos_MayorA;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Kilos_MayorA");
                _dato.DecimalValor = Precio_MenorA;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_MenorA");
                _dato.DecimalValor = Precio_MayorA;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_MayorA");
                _dato.DecimalValor = Precio_Salida_Falso;
                _conexion.agregarParametro(EnumTipoDato.Tipodecimal, _dato, "Precio_Salida_Falso");
                _dato.CadenaTexto = Usuario;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Usuario");
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
                _dato.CadenaTexto = Id_EmpresaCorte;
                _conexion.agregarParametro(EnumTipoDato.CadenaTexto, _dato, "Id_EmpresaCorte");
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
