using AdmTarea.DA.Contexto;
using AdmTarea.BC.Modelos;
using AdmTarea.BW.Interfaces.DA;
using AdmTarea.DA.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AdmTarea.DA.Acciones
{
    public class GestionarFotoDA : IGestionarFotoDA
    {
        private readonly FotoContext _fotoContext;

        public GestionarFotoDA(FotoContext fotoContext)
        {
            _fotoContext = fotoContext;
        }

        public async Task<bool> RegistreFoto(Foto foto)
        {
            try
            {
                var fotoDA = new FotoDA
                {
                    Imagen = foto.Imagen,
                    Latitud = foto.Latitud,
                    Longitud = foto.Longitud,
                    FechaCreacion = foto.FechaCreacion,
                    Descripcion = foto.Descripcion,
                    Etiquetas = foto.Etiquetas,
                    Eliminada = foto.Eliminada
                };

                _fotoContext.FotoDA.Add(fotoDA);
                await _fotoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar la foto: {ex.Message}");
                return false;
            }
        }

        public async Task<Foto> ObtengaFoto(int id)
        {
            var fotoDA = await _fotoContext.FotoDA.FindAsync(id);

            if (fotoDA == null)
                return null;

            var foto = new Foto
            {
                Id = fotoDA.Id,
                Imagen = fotoDA.Imagen,
                Latitud = fotoDA.Latitud,
                Longitud = fotoDA.Longitud,
                FechaCreacion = fotoDA.FechaCreacion,
                Descripcion = fotoDA.Descripcion,
                Etiquetas = fotoDA.Etiquetas,
                Eliminada = fotoDA.Eliminada
            };

            return foto;
        }

        public async Task<IEnumerable<Foto>> ObtengaTodasLasFotos()
        {
            var fotosDA = await _fotoContext.FotoDA.ToListAsync();

            var fotos = fotosDA.Select(fotoDA => new Foto
            {
                Id = fotoDA.Id,
                Imagen = fotoDA.Imagen,
                Latitud = fotoDA.Latitud,
                Longitud = fotoDA.Longitud,
                FechaCreacion = fotoDA.FechaCreacion,
                Descripcion = fotoDA.Descripcion,
                Etiquetas = fotoDA.Etiquetas,
                Eliminada = fotoDA.Eliminada
            });

            return fotos;
        }

        public async Task<bool> ActualiceFoto(int id, Foto foto)
        {
            var fotoExistente = await _fotoContext.FotoDA.FindAsync(id);

            if (fotoExistente != null)
            {
                fotoExistente.Imagen = foto.Imagen;
                fotoExistente.Latitud = foto.Latitud;
                fotoExistente.Longitud = foto.Longitud;
                fotoExistente.FechaCreacion = foto.FechaCreacion;
                fotoExistente.Descripcion = foto.Descripcion;
                fotoExistente.Etiquetas = foto.Etiquetas;
                fotoExistente.Eliminada = foto.Eliminada;

                await _fotoContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ElimineFoto(int id)
        {
            var foto = await _fotoContext.FotoDA.FindAsync(id);

            if (foto != null)
            {
                _fotoContext.FotoDA.Remove(foto);
                await _fotoContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}