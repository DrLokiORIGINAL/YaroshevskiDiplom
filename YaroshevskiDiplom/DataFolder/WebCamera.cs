//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YaroshevskiDiplom.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class WebCamera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WebCamera()
        {
            this.OfficeStorage = new HashSet<OfficeStorage>();
        }
    
        public int IdWebCamera { get; set; }
        public string NameWebCamera { get; set; }
        public string SerialNumberWebCamera { get; set; }
        public System.DateTime GuaranteeWebCamera { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfficeStorage> OfficeStorage { get; set; }
    }
}
