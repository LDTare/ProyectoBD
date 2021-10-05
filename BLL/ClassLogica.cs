using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.DataSetProyectoTableAdapters;

namespace BLL
{
    public class ClassLogica
    {
        private EmpleadosTableAdapter Empleados;
        private RolTableAdapter Roles;
        private ProveedoresTableAdapter Proveedores;
        private ProductosTableAdapter Productos;
        private ClientesTableAdapter Clientes;
        private Tipo_ProductosTableAdapter TipoProductos;

        public ClassLogica()
        {
            Empleados = new EmpleadosTableAdapter();
            Roles = new RolTableAdapter();
            Proveedores = new ProveedoresTableAdapter();
            Productos = new ProductosTableAdapter();
            Clientes = new ClientesTableAdapter();
            TipoProductos = new Tipo_ProductosTableAdapter();
        }

        public int RolUser(string User, string Pass)
        {
            int Flag = 0;

            try
            {
                DataTable tabla = Empleados.GetDataByUsuario(User, Pass);
                if (tabla.Rows.Count >= 1)

                    Flag = Convert.ToInt32(tabla.Rows[0]["ID_Rol"]);
                else
                    Flag = 0;
            }
            catch (Exception Broken)
            {
                Flag = 0;
            }

            return Flag;
        }

        public string Rol(int id)
        {
            string Flag;

            try
            {
                DataTable tabla = Roles.GetDataNombreRol(id);
                if (tabla.Rows.Count >= 1)

                    Flag = Convert.ToString( tabla.Rows[0]["Nombre"]);
                else
                    Flag = "";
            }
            catch (Exception Broken)
            {
                Flag = "";
            }

            return Flag;
        }

        public bool Login(string User, string Pass)
        {
            bool flag = false;

            try
            {
                DataTable tabla = Empleados.GetDataByUsuario(User,Pass);
                if (tabla.Rows.Count >= 1)
                    flag = true;
                else
                    flag = false;
            }
            catch(Exception Broken)
            {
                flag = false;
            }
            return flag;
        }

        public DataTable ListarEmpleados()
        {
            return Empleados.GetDataEmpleados();
        }

        public string NuevoEmpleado(string nombre, string apellido, string user, string pass, int id)
        {
            try
            {
                DataTable tabla = Empleados.GetDataByNombreEmpleado(user);
                if(tabla.Rows.Count <1)
                {
                    Empleados.InsertQueryEmpleados(nombre, apellido, user, pass, id);
                    return "Se agrego un nuevo empleado";
                }
                else
                {
                    return "El usuario ya existe";
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public DataTable IDmpleado()
        {
            return Empleados.GetDataEmpleados();
        }

        public string DelteEmpleado(int id)
        {
            try
            {

                Empleados.UpdateQueryEliminarEmpleado(id);
                    return "Se inhabilito un empleado";

            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ActualizarEmpleado(string nombre, string apellido, string user, string pass, int id,int cod)
        {
            try
            {
                DataTable tabla = Empleados.GetDataByNombreEmpleado(user);
                if (tabla.Rows.Count < 1)
                {
                    Empleados.UpdateQueryEmpleados(nombre, apellido, user, pass, id,cod);
                    return "Modifico un Empleado";
                }
                else
                {
                    return "Operacion Fallida";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarProveedores()
        {
            return Proveedores.GetDataProveedores();
        }

        public string InsertarProveedor(string nombre, string direccion)

        {
            try
            {
                DataTable tabla = Proveedores.GetDataByNombreProveedor(nombre);
                if (tabla.Rows.Count < 1)
                {
                    Proveedores.InsertQueryProveedores(nombre,direccion);
                    return "Se agrego un nuevo Proveedor";
                }
                else
                {
                    return "El Proveedor se encuentra registrado";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ActualizarProveeodr(string nombre, string direccion, int code)

        {
            try
            {
                DataTable tabla = Proveedores.GetDataByNombreProveedor(nombre);
                if (tabla.Rows.Count < 1)
                {
                    Proveedores.UpdateQueryProveedores(nombre,direccion,code);
                    return "Se actualizo un nuevo Proveedor";
                }
                else
                {
                    return "Error no se encuentra al proveedor";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteProveedor(int code)
        {
            try
            {

                Proveedores.UpdateQuery(code);
                return "Se inhabilito un proveedor";

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarClientes()
        {
            return Clientes.GetDataClientes();
        }

        public string InsertarCliente(string nombre, string apellido, string nit, string telefono, string direccion)

        {
            try
            {
                DataTable tabla = Clientes.GetDataByNIT(nit);
                if (tabla.Rows.Count < 1)
                {
                    Clientes.InsertQueryClientes(nombre,apellido,nit,telefono,direccion);
                    return "Se agrego un nuevo cliente";
                }
                else
                {
                    return "El NIT se encuentra registrado";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ActualizarCliente(string nombre, string apellido, string nit, string telefono, string direccion, int code)

        {
            try
            {
                DataTable tabla = Clientes.GetDataByNIT(nit);
                if (tabla.Rows.Count < 1)
                {
                    Clientes.UpdateQueryCliente(nombre,apellido,nit,telefono,direccion,code);
                    return "Se Modifico un Cliente";
                }
                else
                {
                    return "Error en la operacion";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteCliente(int code)
        {
            try
            {

                Clientes.UpdateQueryDeleteCliente(code);
                return "Se inhabilito un cliente";

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarProductos()
        {
            return Productos.GetDataProductos();
        }

        public string InsertarProducto(string nombre,string desc, float price1, float price2, int exs, int exsmin, float descuento, int ID1, int ID2)

        {
            try
            {
                DataTable tabla = Productos.GetDataByIDproducto(nombre);
                if (tabla.Rows.Count < 1)
                {
                    Productos.InsertQueryProductos(nombre, desc, price1, price2, exs, exsmin, descuento, ID1, ID2);
                    return "Se agrego un nuevo Producto";
                }
                else
                {
                    return "El Producto se encuentra registrado";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ActualizarProducto(string nombre, string desc, float price1, float price2, int exs, int exsmin, float descuento, int ID1, int ID2, int code)

        {
            try
            {

                    Productos.UpdateQueryProducto(nombre,desc,price1,price2,exs,exsmin,descuento,ID1,ID2,code);
                    return "Se Actualizo un producto";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteProducto(int code)
        {
            try
            {

                Productos.UpdateQueryDeleteProducto(code);
                return "Se inhabilito un Producto";

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarTiposProd()
        {
            return TipoProductos.GetDataTipoProductos();
        }

    }
}
