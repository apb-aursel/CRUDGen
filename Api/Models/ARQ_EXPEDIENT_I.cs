using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDGen.Models
{
    public partial class ARQ_EXPEDIENT_I
    {
        public ARQ_EXPEDIENT_I()
        {
        }
        [Key]
        public int ARQ_EXPEDIENT_I_ID { get; set; }
        public string NOMINTERN { get; set; } = null!;
        public int ARQ_EXPEDIENT_ID { get; set; }

        [ForeignKey("ARQ_EXPEDIENT_ID")]
        public virtual ARQ_EXPEDIENT ARQ_EXPEDIENT { get; set; }
        public string AUDIT_USER { get; set; } = null!;
        public string AUDIT_APP { get; set; } = null!;
        public DateTime AUDIT_DATAOPERACIOBBDD { get; set; }
        public string AUDIT_OPERACIOBBDD_NI { get; set; } = null!;
        public string ESBORRAT { get; set; } = null!;
        public string? NOMVISIBLE { get; set; }
    }
}
