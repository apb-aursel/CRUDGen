using System;
using System.Collections.Generic;

namespace CRUDGen.Models
{
    public partial class ARQ_EXPEDIENT
    {
        public ARQ_EXPEDIENT()
        {
            ARQ_EXPEDIENTRELACIONATARQ_EXPEDIENT_NINavigation = new HashSet<ARQ_EXPEDIENTRELACIONAT>();
            ARQ_EXPEDIENTRELACIONATNOMINTERNNavigation = new HashSet<ARQ_EXPEDIENTRELACIONAT>();
        }

        public int ARQ_EXPEDIENT_ID { get; set; }
        public string ARQ_USUARI_NI { get; set; } = null!;
        public string ARQ_EXPEDIENTESTAT_NI { get; set; } = null!;
        public string ARQ_APP_NI { get; set; } = null!;
        public string ALFRESCOPATH { get; set; } = null!;
        public string NOMINTERN { get; set; } = null!;
        public string AUDIT_USER { get; set; } = null!;
        public string AUDIT_APP { get; set; } = null!;
        public DateTime AUDIT_DATAOPERACIOBBDD { get; set; }
        public string AUDIT_OPERACIOBBDD_NI { get; set; } = null!;
        public string ESBORRAT { get; set; } = null!;
        public int ARQ_EVENT_FK { get; set; }
        public string ARQ_APPFASES_NI { get; set; } = null!;
        public string? NOMVISIBLE { get; set; }
        public string ARQ_EXPEDIENTTIPUS_NI { get; set; } = null!;
        public string CONCURRENCYGUID { get; set; } = null!;

        public virtual ICollection<ARQ_EXPEDIENTRELACIONAT> ARQ_EXPEDIENTRELACIONATARQ_EXPEDIENT_NINavigation { get; set; }
        public virtual ICollection<ARQ_EXPEDIENTRELACIONAT> ARQ_EXPEDIENTRELACIONATNOMINTERNNavigation { get; set; }
    }
}
