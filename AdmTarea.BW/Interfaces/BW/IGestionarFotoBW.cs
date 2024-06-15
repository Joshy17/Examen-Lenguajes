using AdmTarea.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.BW.Interfaces.BW
{
    public interface IGestionarFotoBW
    {
         Task<bool> RegistreFoto(Foto foto);
         Task<Foto> ObtengaFoto(int id);
         Task<IEnumerable<Foto>> ObtengaTodasLasFotos();
         Task<bool> ActualiceFoto(int id, Foto foto);
         Task<bool> ElimineFoto(int id);
    }
}
