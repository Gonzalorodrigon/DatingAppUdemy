using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatingApp.API.Data;

namespace DatingApp.API.Controllers
{

    //http://localhost:5000/api/values
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        //Get Api/values

        [HttpGet]

        public async Task<IActionResult> GetValues()
        {
          var values = await _context.Values.ToListAsync();

          return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        //POST api values
        [HttpPost]

        public void Put(int id, [FromBody] string value)
        { }

        //Delete api/values/5
        [HttpDelete("{id}")]

        public void Delete(int id)
        { }
    }
}