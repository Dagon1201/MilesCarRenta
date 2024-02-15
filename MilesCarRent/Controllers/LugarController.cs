using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilesCarRent.Models;

namespace MilesCarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugarController : ControllerBase
    {
        public readonly MilesCarRentalContext _dbcontext;

        public LugarController(MilesCarRentalContext _context)
        {
            _dbcontext = _context;
        }

        /// <summary>
        /// Api para ver localidades
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ListaLocalidades")]
        public IActionResult ListaLocalidades()
        {
            List<Lugar> Lista = new List<Lugar>();
            try
            {
                Lista = _dbcontext.Lugars.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = Lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = Lista });
            }
        }



    }
}
