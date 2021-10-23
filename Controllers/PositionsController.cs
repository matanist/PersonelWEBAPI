using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PERSONELWEBAPI.Data;
using PERSONELWEBAPI.Models;

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
        public ApiResponse Post(Position position)
        {
            if (position == null) return new ApiResponse{Code="202",Message="position değeri boş olamaz", Set=null};
            var pos = _context.Positions.FirstOrDefault(p => p.Name == position.Name);
            if (pos != null) return new ApiResponse{Code="204",Message="Bu position ismi mevcut", Set=null};
            _context.Positions.Add(position);
            _context.SaveChanges();
            return new ApiResponse{Code="200",Message="Başarılı bir şekilde kaydedildi", Set=position};
        }
    }
}