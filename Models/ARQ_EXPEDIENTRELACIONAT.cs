using System;
using System.Collections.Generic;

namespace CRUDGen.Models
{
    public partial class ARQ_EXPEDIENTRELACIONAT
    {
        public string NOMINTERN { get; set; } = null!;
        public string ARQ_EXPEDIENT_NI { get; set; } = null!;
        public string AUDIT_USER { get; set; } = null!;
        public string AUDIT_APP { get; set; } = null!;
        public DateTime AUDIT_DATAOPERACIOBBDD { get; set; }
        public string AUDIT_OPERACIOBBDD_NI { get; set; } = null!;
        public string ESBORRAT { get; set; } = null!;

        public virtual ARQ_EXPEDIENT ARQ_EXPEDIENT_NINavigation { get; set; } = null!;
        public virtual ARQ_EXPEDIENT NOMINTERNNavigation { get; set; } = null!;
    }
}
