using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_final.Models
{
    public interface Obligatorio<cualquierclase>
    {
        void create(cualquierclase obj);
        void delete(cualquierclase obj);
        void update(cualquierclase obj);
        bool find(cualquierclase obj);
        List<cualquierclase> findAll();

    }
}
