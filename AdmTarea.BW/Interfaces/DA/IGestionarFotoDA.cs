using AdmTarea.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.BW.Interfaces.DA
{
    public interface IGestionarFotoDA
    {
        public Task<bool> RegistreFoto(Foto foto);
        public Task<Foto> ObtengaFoto(int id);
        public Task<IEnumerable<Foto>> ObtengaTodasLasFotos();
        public Task<bool> ActualiceFoto(int id, Foto foto);
        public Task<bool> ElimineFoto(int id);

    }
}
