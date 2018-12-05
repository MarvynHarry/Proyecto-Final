using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dao;
using proyecto_final.Models;


namespace proyecto_final.Neg
{
    public class PacienteNeg
    {
        private PacienteDao objClienteDao;
      
        public PacienteNeg()
        {
            objClienteDao = new PacienteDao();
          
        }


        public bool find(paciente objCliente)
        {
            return objClienteDao.find(objCliente);
        }

        public List<paciente> findAll()
        {
            return objClienteDao.findAll();
        }
        public List<paciente> findAllClientes(paciente objCLiente)
        {
            return objClienteDao.findAllCliente(objCLiente);
        }
    }
}
