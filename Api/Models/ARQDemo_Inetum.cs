using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDGen.Models
{
    public partial class ARQDemo_Inetum
    {
        public ARQDemo_Inetum()
        {
            ARQDemo_Inetum_Idioma = new List<ARQDemo_Inetum_Idioma>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ARQ_Id { get; set; }

        [Required]
        public List<ARQDemo_Inetum_Idioma> ARQDemo_Inetum_Idioma { get; set; }

    }
}
