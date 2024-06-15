using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.BC.Modelos
{
    public class Foto
    {
        public int Id { get; set; }
        public byte[] Imagen { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }
        public string Etiquetas { get; set; }
        public bool Eliminada { get; set; } 
    }
}
