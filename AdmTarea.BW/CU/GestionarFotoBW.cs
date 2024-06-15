using AdmTarea.BC.Modelos;
using AdmTarea.BC.ReglasDeNegocio;
using AdmTarea.BW.Interfaces.BW;
using AdmTarea.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.BW.CU
{
    public class GestionarFotoBW : IGestionarFotoBW
    {
        private readonly IGestionarFotoDA gestionarFotoDA;

        public GestionarFotoBW(IGestionarFotoDA gestionarFotoDA)
        {
            this.gestionarFotoDA = gestionarFotoDA;
        }
        public async Task<bool> RegistreFoto(Foto foto)
        {
            // Validar la foto usando las reglas de negocio de ReglasFoto
            (bool esValido, string mensaje) validacionReglaDeFoto = ReglasFoto.LaFotoEsValida(foto);

            if (!validacionReglaDeFoto.esValido)
            {
                return false;
            }

            // Llamar al método de la capa de datos para registrar la foto
            return await gestionarFotoDA.RegistreFoto(foto);
        }

        public async Task<Foto> ObtengaFoto(int id)
        {
            // Validar el ID usando las reglas de negocio de ReglasFoto
            (bool esValidoId, string mensajeId) validacionReglaDeId = ReglasFoto.ElIdEsValido(id);

            if (!validacionReglaDeId.esValidoId)
            {
                return null;
            }

            // Llamar al método de la capa de datos para obtener la foto
            return await gestionarFotoDA.ObtengaFoto(id);
        }

        public async Task<IEnumerable<Foto>> ObtengaTodasLasFotos()
        {
            // Llamar al método de la capa de datos para obtener todas las fotos
            return await gestionarFotoDA.ObtengaTodasLasFotos();
        }

        public async Task<bool> ActualiceFoto(int id, Foto foto)
        {
            // Validar la foto y el ID usando las reglas de negocio de ReglasFoto
            (bool esValidoFoto, string mensajeFoto) validacionReglaDeFoto = ReglasFoto.LaFotoEsValida(foto);
            (bool esValidoId, string mensajeId) validacionReglaDeId = ReglasFoto.ElIdEsValido(id);

            if (!validacionReglaDeFoto.esValidoFoto || !validacionReglaDeId.esValidoId)
            {
                return false;
            }

            // Llamar al método de la capa de datos para actualizar la foto
            return await gestionarFotoDA.ActualiceFoto(id, foto);
        }

        public async Task<bool> ElimineFoto(int id)
        {
            // Validar el ID usando las reglas de negocio de ReglasFoto
            (bool esValidoId, string mensajeId) validacionReglaDeId = ReglasFoto.ElIdEsValido(id);

            if (!validacionReglaDeId.esValidoId)
            {
                return false;
            }

            // Llamar al método de la capa de datos para eliminar la foto
            return await gestionarFotoDA.ElimineFoto(id);
        }
    }
}