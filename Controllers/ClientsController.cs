using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{   
    [Controller]
    [Route("[controller]")]

    public class ClientsController : ControllerBase
    {
        private DataContext dc;

        public ClientsController(DataContext context){
            this.dc = context;
        }
    
        [HttpPost("api")]
        public async Task<ActionResult> register([FromBody] Clients p ){
            
            dc.clients.Add(p);
            await dc.SaveChangesAsync();
            return Created("Clients Object", p);

        }



        [HttpGet("api")]
        public async Task<ActionResult> list(){

            var data = await dc.clients.ToListAsync();
            return Ok(data);
        }

           
        [HttpGet("api/{id}")]               
        public Clients search(int id){
            Clients p = dc.clients.Find(id);
            return p;
        }

           
        [HttpPut("api")]
        public async Task<ActionResult> edit([FromBody] Clients p){
            dc.clients.Update(p);
            await dc.SaveChangesAsync();
            return Ok(p);
        }


        
        [HttpDelete("api/{id}")]
        public async Task<ActionResult> delete(int id){
            Clients p = search(id);
            if (p == null){
            return NotFound();
            } else {
                dc.clients.Remove(p);
                await  dc.SaveChangesAsync();
                return Ok();
            }
        }


        [HttpGet("hello")]
        public string hello() {

            return "I need vacation";
        }

    }
}