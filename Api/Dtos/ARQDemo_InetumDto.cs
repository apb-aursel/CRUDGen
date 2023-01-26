namespace CRUDGen.Dtos
{
    public class ARQDemo_InetumDto
    {
        public ARQDemo_InetumDto()
        {
            ARQDemo_Inetum_Idioma = new List<ARQDemo_Inetum_IdiomaDto>();
        }
        public int ARQ_Id { get; set; }

        public List<ARQDemo_Inetum_IdiomaDto> ARQDemo_Inetum_Idioma { get; set; }

    }
}
