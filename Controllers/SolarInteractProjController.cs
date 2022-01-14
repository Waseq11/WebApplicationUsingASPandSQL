using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{   
    [Controller]
    [Route("[controller]")]

    public class SolarInteractProjController : ControllerBase
    {
        private DataContext dc;

        public SolarInteractProjController(DataContext context){
            this.dc = context;
        }
    
        [HttpPost("api")]
        public async Task<ActionResult> register([FromBody] SolarInteractProj sp ){
            
            dc.solarInteractProjs.Add(sp);
            await dc.SaveChangesAsync();
            return Created("SolarInteractProj Object", sp);

        }



        [HttpGet("api")]
        public async Task<ActionResult> list(){

            var data = await dc.solarInteractProjs.ToListAsync();  
            return Ok(data);

           }

        [HttpGet("api/{id}")]               
        public SolarInteractProj search(int id){
            SolarInteractProj sp = dc.solarInteractProjs.Find(id);
            return sp;
        }

        
        [HttpPut("api")]
        public async Task<ActionResult> edit([FromBody] SolarInteractProj sp){
            dc.solarInteractProjs.Update(sp);
            await dc.SaveChangesAsync();
            return Ok(sp);
        }


        
        [HttpDelete("api/{id}")]
        public async Task<ActionResult> delete(int id){
            SolarInteractProj sp = search(id);
            if (sp == null){
            return NotFound();
            } else {
                dc.solarInteractProjs.Remove(sp);
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