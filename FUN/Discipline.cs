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
    
    public partial class Discipline
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Discipline()
        {
            this.LoadGroup = new HashSet<LoadGroup>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int ID_Speciality { get; set; }
        public Nullable<int> Lections { get; set; }
        public Nullable<int> Practice { get; set; }
        public Nullable<int> Laboratory { get; set; }
        public int Year { get; set; }
    
        public virtual Speciality Speciality { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoadGroup> LoadGroup { get; set; }
    }
}
