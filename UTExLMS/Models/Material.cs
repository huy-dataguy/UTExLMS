using System;
using System.Collections.Generic;

namespace UTExLMS.Models
{
    public partial class Material
    {
        public int IdMaterial { get; set; }
        public string? FilePath { get; set; }
        public bool? Statu { get; set; }
        public string? NameMaterial { get; set; }
        public string? TypeMaterial { get; set; }
        public int? IdSection { get; set; }
        public int? IdCourse { get; set; }

        public virtual Section? Id { get; set; }
    }
}
