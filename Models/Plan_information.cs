//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PP_12._2020.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plan_information
    {
        public int ID { get; set; }
        public int Semester { get; set; }
        public int ID_Subject { get; set; }
        public int ID_AP { get; set; }
    
        public virtual Academic_plans Academic_plans { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
