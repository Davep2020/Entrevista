//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prueba.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Canton
    {
        public Canton()
        {
            this.Distrito = new HashSet<Distrito>();
            this.Personas = new HashSet<Personas>();
        }
    
        public int id_Canton { get; set; }
        public int id_Provincia { get; set; }
        public string nombre { get; set; }
        public string usuarioCrea { get; set; }
        public Nullable<System.DateTime> fechaCrea { get; set; }
        public string usuarioModifica { get; set; }
        public Nullable<System.DateTime> fechaModifica { get; set; }
        public string vc_Estado { get; set; }
        public int id_CantonInec { get; set; }
    
        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<Distrito> Distrito { get; set; }
        public virtual ICollection<Personas> Personas { get; set; }
    }
}
