//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Application
    {
        public int Id { get; set; }
        public System.DateTime DateOfAdd { get; set; }
        public int DeffectType { get; set; }
        public string AppDescription { get; set; }
        public int Client { get; set; }
        public int AppStatus { get; set; }
        public Nullable<int> Responsible { get; set; }
        public Nullable<System.DateTime> DateOfEnd { get; set; }
        public string Comment { get; set; }
        public int Equipment { get; set; }
        public System.DateTime DueDate { get; set; }
    
        public virtual AppStatus AppStatus1 { get; set; }
        public virtual Client Client1 { get; set; }
        public virtual DeffectType DeffectType1 { get; set; }
        public virtual Equipment Equipment1 { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
