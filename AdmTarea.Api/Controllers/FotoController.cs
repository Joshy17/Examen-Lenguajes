using AdmTarea.Api.DTOs;
using AdmTarea.Api.Utilitarios;
using AdmTarea.BC.ReglasDeNegocio;
using AdmTarea.BW.Interfaces.BW;
using Microsoft.AspNetCore.Mvc;

namespace AdmTarea.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotoController : ControllerBase
    {
        private readonly IGestionarFotoBW gestionarFotoBW;

        public FotoController(IGestionarFotoBW gestionarFotoBW)
        {
            this.gestionarFotoBW = gestionarFotoBW;
        }

        [HttpGet]
        public async Task<IEnumerable<FotoDTO>> ObtenerTodasLasFotos()
        {
            return FotoDTOMapper.ConvertirListaDeFotosADTO(await gestionarFotoBW.ObtengaTodasLasFotos());
        }

        [HttpGet("{id}")]
        public async Task<FotoDTO> ObtenerFoto(int id)
        {
            return FotoDTOMapper.ConvertirFotoADTO(await gestionarFotoBW.ObtengaFoto(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarFoto(int id, FotoDTO fotoDTO)
        {
            var (esValido, mensaje) = ReglasFoto.ElIdEsValido(id);

            if (!esValido)
                return BadRequest(mensaje);

            var foto = FotoDTOMapper.ConvertirDTOAFoto(fotoDTO);
            var respuesta = await gestionarFotoBW.ActualiceFoto(id, foto);

            if (!respuesta)
                return BadRequest(respuesta);

            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> RegistrarFoto(FotoDTO fotoDTO)
        {
            var (esValido, mensaje) = ReglasFoto.LaFotoEsValida(FotoDTOMapper.ConvertirDTOAFoto(fotoDTO));

            if (!esValido)
                return BadRequest(mensaje);

            var respuesta = await gestionarFotoBW.RegistreFoto(FotoDTOMapper.ConvertirDTOAFoto(fotoDTO));
            return respuesta ? Ok(respuesta) : BadRequest(respuesta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarFoto(int id)
        {
            var (esValido, mensaje) = ReglasFoto.ElIdEsValido(id);

            if (!esValido)
                return BadRequest(mensaje);

            var respuesta = await gestionarFotoBW.ElimineFoto(id);
            return respuesta ? Ok(respuesta) : BadRequest(respuesta);
        }
    }
}