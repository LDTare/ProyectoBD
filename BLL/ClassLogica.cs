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

        public ClassLogica()
        {
            Empleados = new EmpleadosTableAdapter();
            Roles = new RolTableAdapter();
            Proveedores = new ProveedoresTableAdapter();
            Productos = new ProductosTableAdapter();
            Clientes = new ClientesTableAdapter();
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

        private DataTable ListarClientes()
        {
            return Clientes.GetDataClientes();
        }

        public DataTable ListarProductos()
        {
            return Productos.GetDataProductos();
        }
    }
}
