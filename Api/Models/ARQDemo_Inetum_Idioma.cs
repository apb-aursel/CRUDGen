using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDGen.Models
{
    public partial class ARQDemo_Inetum_Idioma
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ARQDemo_Inetum_Idioma_Id { get; set; }
        public string Mensaje { get; set; } = null!;
        public string Idioma { get; set; } = null!;

    }
}
