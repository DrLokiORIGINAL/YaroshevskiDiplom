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
    
    public partial class OfficeStorage
    {
        public int IdOfficeStorage { get; set; }
        public int IdComputer { get; set; }
        public int IdStaff { get; set; }
        public int IdKeyboard { get; set; }
        public int IdComputerMouse { get; set; }
        public Nullable<int> IdScanner { get; set; }
        public Nullable<int> IdMicrophone { get; set; }
        public Nullable<int> IdWebCamera { get; set; }
        public int IdMonitor { get; set; }
        public Nullable<int> IdPrinter { get; set; }
        public Nullable<int> IdHeadphones { get; set; }
        public Nullable<int> IdGarniture { get; set; }
    
        public virtual Computer Computer { get; set; }
        public virtual ComputerMouse ComputerMouse { get; set; }
        public virtual Garniture Garniture { get; set; }
        public virtual Headphones Headphones { get; set; }
        public virtual Keyboard Keyboard { get; set; }
        public virtual Microphone Microphone { get; set; }
        public virtual Monitor Monitor { get; set; }
        public virtual Printer Printer { get; set; }
        public virtual Scanner Scanner { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual WebCamera WebCamera { get; set; }
    }
}