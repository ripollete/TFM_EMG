//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace signalAcquirer.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class people
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public people()
        {
            this.sample = new HashSet<sample>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public string surnames { get; set; }
        public Nullable<System.DateTime> birth_date { get; set; }
        public Nullable<int> gender { get; set; }
        public Nullable<decimal> weight { get; set; }
        public Nullable<int> height { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sample> sample { get; set; }
    }
}