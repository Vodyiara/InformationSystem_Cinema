//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursovaya1._1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Actor
    {
        public int ID_director { get; set; }
        public int ID_film { get; set; }
        public string FIO { get; set; }
        public string Country { get; set; }
        public int Birth_year { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Filmplayed { get; set; }
        public Nullable<int> Filmawards { get; set; }
        public byte[] Imageactor { get; set; }
    
        public virtual Film Film { get; set; }
    }
}