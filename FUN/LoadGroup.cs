//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FUN
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoadGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoadGroup()
        {
            this.LoadTeacher = new HashSet<LoadTeacher>();
        }
    
        public int ID { get; set; }
        public int ID_Group { get; set; }
        public int ID_Discipline { get; set; }
        public Nullable<int> Lections { get; set; }
        public Nullable<int> Practice { get; set; }
        public Nullable<int> LR { get; set; }
        public string GroupAndDis { get; set; }
    
        public virtual Discipline Discipline { get; set; }
        public virtual Group Group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoadTeacher> LoadTeacher { get; set; }
    }
}
