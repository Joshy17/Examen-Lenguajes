using AdmTarea.Api.DTOs;
using AdmTarea.BC.Modelos;

namespace AdmTarea.Api.Utilitarios
{
    public class FotoDTOMapper
    {
        public static FotoDTO ConvertirFotoADTO(Foto foto)
        {
            return new FotoDTO()
            {
                Id = foto.Id,
                Imagen = foto.Imagen,
                Latitud = foto.Latitud,
                Longitud = foto.Longitud,
                FechaCreacion = foto.FechaCreacion,
                Descripcion = foto.Descripcion,
                Etiquetas = foto.Etiquetas,
                Eliminada = foto.Eliminada
            };
        }

        public static Foto ConvertirDTOAFoto(FotoDTO fotoDTO)
        {
            return new Foto()
            {
                Id = fotoDTO.Id,
                Imagen = fotoDTO.Imagen,
                Latitud = fotoDTO.Latitud,
                Longitud = fotoDTO.Longitud,
                FechaCreacion = fotoDTO.FechaCreacion,
                Descripcion = fotoDTO.Descripcion,
                Etiquetas = fotoDTO.Etiquetas,
                Eliminada = fotoDTO.Eliminada
            };
        }

        public static IEnumerable<FotoDTO> ConvertirListaDeFotosADTO(IEnumerable<Foto> fotos)
        {
            return fotos.Select(foto => ConvertirFotoADTO(foto));
        }
    }
}