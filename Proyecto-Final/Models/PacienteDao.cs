using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using proyecto_final.Models;

namespace Model.Dao
{
    public class PacienteDao
    {
        private DatabaseEntities objConexinDB;
        private SqlCommand comando;

        public PacienteDao()
        {
            objConexinDB = DatabaseEntities.saberEstado();

        }




        public bool find(paciente objCliente)
        {
            bool hayRegistros;
            string find = "select*from paciente where cedula='" + objCliente.cedula + "'";
            try
            {
                comando = new SqlCommand(find, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                //bool hayRegistros;
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objCliente.nombre = reader[1].ToString();
                    objCliente.apellido = reader[2].ToString();
                    objCliente.fecha_naciemiento =Convert.ToDateTime( reader[3].ToString());
                    objCliente.telefono =Convert.ToInt64( reader[4].ToString());
                    objCliente.tipo_sangre = reader[5].ToString();
                    

                   


                }
                else
                {
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
           finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }
            return hayRegistros;
        }

        internal List<paciente> findClientePorDni(string objProducto)
        {
            throw new NotImplementedException();
        }

        internal List<paciente> find(long objPrducto)
        {
            throw new NotImplementedException();
        }

        public List<paciente> findAll()
        {
            List<paciente> listaClientes = new List<paciente>();
            string findAll = "select*from cliente order by nombre asc, apPaterno asc,apMaterno asc";
            try
            {
                comando = new SqlCommand(findAll, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    paciente objCliente = new paciente();
                    objCliente.cedula = Convert.ToInt64(reader[0].ToString());
                    objCliente.nombre = reader[1].ToString();
                    objCliente.apellido = reader[2].ToString();
                    objCliente.fecha_naciemiento =Convert.ToDateTime( reader[3].ToString());
                    objCliente.telefono = Convert.ToInt64(reader[4].ToString());
                    objCliente.tipo_sangre = reader[5].ToString();
                    
                    listaClientes.Add(objCliente);

                }
            }
            catch (Exception)
            {

            }
            finally
            {
              
            }

            return listaClientes;           
           
        }

        public void update(paciente objCliente)
        {
            string update = "update paciente set nombre='" + objCliente.nombre + "',apellido='" + objCliente.apellido + "',fecha_nacimiento='" + objCliente.fecha_naciemiento + "',telefono='" + objCliente.telefono + "',tipo_sangre='" + objCliente.tipo_sangre + "',telefono='";
            try
            {
                comando = new SqlCommand(update, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                comando.ExecuteNonQuery();                
            }
            catch (Exception e)
            {

              
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }
        }

        public bool findClientePorDni(paciente objCliente)
        {
            bool hayRegistros;
            string find = "select*from paciente where tipo_sangre='"+objCliente.tipo_sangre+"'" ;
            try
            {
                comando = new SqlCommand(find, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                //bool hayRegistros;
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objCliente.nombre = reader[1].ToString();
                    objCliente.apellido = reader[2].ToString();
                    objCliente.fecha_naciemiento =Convert.ToDateTime( reader[3].ToString());
                    
                    objCliente.telefono =Convert.ToInt64( reader[4].ToString());
                    objCliente.tipo_sangre = reader[5].ToString();
            

                }
                else
                {
                   
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }
            return hayRegistros;
        }

        public List<paciente> findAllCliente(paciente objCLiente)
        {
            List<paciente> listaClientes = new List<paciente>();
            //string findAll = "select*from paciente where nombre='" + objCLiente.nombre + "' or apellido='" + objCLiente.Dni + "' or idCliente=" + objCLiente.IdCliente + " or apPaterno='" + objCLiente.Appaterno + "'";
            string findAll = "select* from paciente where nombre like '%" + objCLiente.nombre + "%' or apellido like '%" + objCLiente.apellido + "%' or cedula like '%" + objCLiente.cedula + "%' or tipo_sangre like '%" + objCLiente.tipo_sangre + "%'  or fecha_nacimiento like '%" + objCLiente.fecha_naciemiento + "%'";
            try
            {
                comando = new SqlCommand(findAll, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    paciente objCliente = new paciente();
                    objCliente.cedula = Convert.ToInt64(reader[0].ToString());
                    objCliente.nombre = reader[1].ToString();
                    objCliente.apellido = reader[2].ToString();
                    objCliente.fecha_naciemiento =Convert.ToDateTime( reader[3].ToString());
                    objCliente.telefono =Convert.ToInt64( reader[4].ToString());
                    objCliente.telefono = Convert.ToInt64( reader[5].ToString());
                    objCliente.tipo_sangre = reader[6].ToString();
                    listaClientes.Add(objCliente);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }

            return listaClientes;

        }

    }
}
