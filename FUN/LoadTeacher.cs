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
    
    public partial class LoadTeacher
    {
        public int ID { get; set; }
        public int ID_Load { get; set; }
        public int ID_Teacher { get; set; }
        public Nullable<int> Lections { get; set; }
        public Nullable<int> Practice { get; set; }
        public Nullable<int> LR { get; set; }
        public string TeacherDisGroup { get; set; }
    
        public virtual LoadGroup LoadGroup { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
