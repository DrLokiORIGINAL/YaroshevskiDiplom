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
    
    public partial class Keyboard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Keyboard()
        {
            this.OfficeStorage = new HashSet<OfficeStorage>();
        }
    
        public int IdKeyboard { get; set; }
        public string NameKeyboard { get; set; }
        public string SerialNumberKeyboard { get; set; }
        public System.DateTime GuaranteeKeyboard { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfficeStorage> OfficeStorage { get; set; }
    }
}
