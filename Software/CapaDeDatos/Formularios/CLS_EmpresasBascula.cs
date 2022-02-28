using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CLS_EmpresasBascula : ConexionBase
    {
    public string Id_EmpresaBascula { get; set; }
    public string Nombre_EmpresaBascula { get; set; }
    public string Telefono1 { get; set; }
    public string Telefono2 { get; set; }
    public string Email { get; set; }
    public string Contacto { get; set; }
    public string RFC { get; set; }
    public string Usuario { get; set; }

    public void MtdSeleccionarEmpresas()
    {
        TipoDato _dato = new TipoDato();
        Conexion _conexion = new Conexion(cadenaConexion);

        Exito = true;
        try
        {
            _conexion.NombreProcedimiento = "SP_Empresa_Bascula_Select";

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
            _conexion.NombreProcedimiento = "SP_Empresa_Bascula_Insert";
            _dato.Texto = Id_EmpresaBascula;
            _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaBascula");
            _dato.Texto = Nombre_EmpresaBascula;
            _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Nombre_EmpresaBascula");
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
            _conexion.NombreProcedimiento = "SP_Empresa_Bascula_Delete";
            _dato.Texto = Id_EmpresaBascula;
            _conexion.agregarParametro(EnumTipoDato.Texto, _dato, "Id_EmpresaBascula");
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
