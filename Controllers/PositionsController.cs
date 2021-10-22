using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PERSONELWEBAPI.Data;

namespace PERSONELWEBAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : Controller
    {
        private readonly PersonelDBContext _context;
        public PositionsController(PersonelDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get() => Json(_context.Positions.ToList());
        [HttpPost]
        public IActionResult Post(Position position){
            if(position==null) return NoContent();

            _context.Positions.Add(position);
            _context.SaveChanges();
            return Ok();
        }
    }
}