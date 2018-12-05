using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_final.Models;

using Model.Dao;

namespace Model.Neg
{
    public class MetodosPac
    {
    private PacienteDao objProductoDao;
    
        public MetodosPac()
        {
            objProductoDao = new PacienteDao();
          
        }





        public bool find(paciente objProducto)
        {
            return objProductoDao.find(objProducto);
        }

        public List<paciente> findAll()
        {
            return objProductoDao.findAll();
        }

        public List<paciente> findPrecioProducto(long objPrducto)
        {
            return objProductoDao.find(objPrducto);
        }

        public List<paciente> findAllProductos(paciente objProducto)
        {
            return objProductoDao.findAllCliente(objProducto);
        }
        public List<paciente> findAllProductosPorCategoria(String objProducto)
        {
            return objProductoDao.findClientePorDni(objProducto);
        }
    }
}
