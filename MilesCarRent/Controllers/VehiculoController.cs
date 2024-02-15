using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilesCarRent.Models;

namespace MilesCarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        public readonly MilesCarRentalContext _dbcontext;

        public VehiculoController(MilesCarRentalContext _context)
        {
            _dbcontext = _context;
        }


        /// <summary>
        /// Api para obtener la lista de vehiculos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ListaVehiculos")]
        public IActionResult ListaVehiculos()
        {
            List<Vehiculo> Lista = new List<Vehiculo>();
            try
            {
                Lista = _dbcontext.Vehiculos.Include(c => c.oUbicacionActual).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = Lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Lista });
            }
        }

        /// <summary>
        /// Api para obtener un solo vehiculo
        /// </summary>
        /// <param name="IdVehiculo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Vehiculo/{idVehiculo:int}")]
        public IActionResult Vehiculo(int IdVehiculo)
        {
            Vehiculo Ovehiculo = _dbcontext.Vehiculos.Find(IdVehiculo);
            if (Ovehiculo == null)
            {
                return BadRequest("Vehiculo no encontrado");
            }
            try
            {
                Ovehiculo = _dbcontext.Vehiculos.Include(c => c.oUbicacionActual).Where(p => p.IdVehiculo == IdVehiculo).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = Ovehiculo });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Ovehiculo });
            }
        }

        /// <summary>
        /// Api de guardado de vehicuo
        /// </summary>
        /// <param name="Vehiculo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GuardarVehiculo")]
        public IActionResult GuardarVehiculo([FromBody] Vehiculo Vehiculo)
        {
            try
            {
                _dbcontext.Vehiculos.Add(Vehiculo);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Api de edicion de vehiculo
        /// </summary>
        /// <param name="Vehiculo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("EditarVehiculo")]
        public IActionResult Editar([FromBody] Vehiculo Vehiculo)
        {
            Vehiculo Ovehiculo = _dbcontext.Vehiculos.Find(Vehiculo.IdVehiculo);
            if (Ovehiculo == null)
            {
                return BadRequest("Vehiculo no encontrado");
            }
            try
            {
                Ovehiculo.Modelo = Vehiculo.Modelo is null ? Ovehiculo.Modelo : Vehiculo.Modelo;
                Ovehiculo.UbicacionPrincipal = Vehiculo.UbicacionPrincipal is null ? Ovehiculo.UbicacionPrincipal : Vehiculo.UbicacionPrincipal;
                Ovehiculo.UbicacionActual = Vehiculo.UbicacionActual is null ? Ovehiculo.UbicacionActual : Vehiculo.UbicacionActual;
                Ovehiculo.Disponibilidad = Vehiculo.Disponibilidad is null ? Ovehiculo.Disponibilidad : Vehiculo.Disponibilidad;

                _dbcontext.Vehiculos.Add(Ovehiculo);
                _dbcontext.SaveChanges();


                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message});
            }
        }


        [HttpDelete]
        [Route("EliminarVehiculo/{idVehiculo:int}")]

        public IActionResult EliminarVehiculo(int idVehiculo)
        {
            Vehiculo Ovehiculo = _dbcontext.Vehiculos.Find(idVehiculo);

            if (Ovehiculo == null)
            {
                return BadRequest("Vehiculo no encontrado");
            }
            try
            {
                _dbcontext.Vehiculos.Remove(Ovehiculo);
                _dbcontext.SaveChanges();


                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }







    }
}
