//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyecto_final.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class recetacita
    {
        public int Id { get; set; }
        public long paciente { get; set; }
        public System.DateTime fecha { get; set; }
        public int cita { get; set; }
        public string medicamentos { get; set; }
        public string observaciones { get; set; }
    
        public virtual paciente paciente1 { get; set; }
    }
}
