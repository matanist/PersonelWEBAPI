using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PERSONELWEBAPI.Data;
using PERSONELWEBAPI.Models;

namespace PERSONELWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly PersonelDBContext _context;
        public PersonsController(PersonelDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get() => Json(_context.Persons.Take(100).ToList());
        [HttpGet("{id}")]
        public IActionResult Get(int id) => Json(_context.Persons.FirstOrDefault(p => p.Id == id));
        [HttpPost]
        public ApiResponse Post(Person person)
        {
            if (person == null)
                return new ApiResponse{Code="204",Message="person boş olamaz",Set=null};
            _context.Persons.Add(person);
            _context.SaveChanges();
            return new ApiResponse{Code="200", Message="Başarılı bir şekilde kaydedildi",Set=person};
        }
        [HttpGet]
        [Route("SearchPerson/{searchTerm}")]
        public IActionResult SearchPerson(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return Json(_context.Persons.Include(p => p.Position).Take(100).ToList());
            }
            var searchResult = _context.Persons.Where(p => p.FirstName.Contains(searchTerm) || p.LastName.Contains(searchTerm)).ToList();
            return Json(searchResult);
        }
    }
}