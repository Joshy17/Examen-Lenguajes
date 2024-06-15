namespace AdmTarea.Api.DTOs
{
    public class FotoDTO
    {
        public int Id { get; set; }
        public byte[] Imagen { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public string Etiquetas { get; set; }
        public bool Eliminada { get; set; } = false;
    }
}
