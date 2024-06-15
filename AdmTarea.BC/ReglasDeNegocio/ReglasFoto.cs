using AdmTarea.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.BC.ReglasDeNegocio
{
    public static class ReglasFoto
    {
        public static (bool, string) LaFotoEsValida(Foto foto)
        {
            if (foto.Imagen == null || foto.Imagen.Length == 0)
                return (false, "La foto no es válida porque no tiene una imagen asociada.");

            if (string.IsNullOrWhiteSpace(foto.Descripcion))
                return (false, "La foto no es válida porque la descripción es requerida.");

            if (foto.Latitud < -90 || foto.Latitud > 90 || foto.Longitud < -180 || foto.Longitud > 180)
                return (false, "Las coordenadas de la foto no son válidas.");

            // Puedes agregar más validaciones según tus requisitos de negocio

            return (true, string.Empty);
        }

        public static (bool, string) ElIdEsValido(int id)
        {
            if (id <= 0)
                return (false, "El ID de la foto no es válido.");

            return (true, string.Empty);
        }
    }
}