//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spa_Personas.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factura()
        {
            this.Detalle_factura = new HashSet<Detalle_factura>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> Total { get; set; }
        public int Id_Usuario { get; set; }
        public Nullable<decimal> TotalConDescuento { get; set; }
        public int Id_Reservas { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_factura> Detalle_factura { get; set; }
        public virtual Reserva Reserva { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
