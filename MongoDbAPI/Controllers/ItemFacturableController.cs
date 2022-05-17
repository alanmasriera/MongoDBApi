using Microsoft.AspNetCore.Mvc;
using MongoDbAPI.Models;
using MongoDbAPI.Repositories;

namespace MongoDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemFacturableController : Controller
    {
        private IItemFacturableCollection db = new ItemFacturableCollection();
        [HttpGet]
        public async Task<IActionResult> GetAllItemsFacturable()
        {
            return Ok(await db.GetAllItemsFacturable());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemFacturableDetails(string id)
        {
            return Ok(await db.GetItemFacturableById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateItemFacturable([FromBody] ItemFacturable itemFact)
        {
            if (itemFact == null)
                return BadRequest();
            if (itemFact.numero_afiliado == String.Empty)
            {
                ModelState.AddModelError("numero_afiliado", "EL numero de afiliado es obligatorio");
            }
            await db.InsertItemFacturable(itemFact);
            return Created("Created", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemFacturable([FromBody] ItemFacturable itemFact, string id)
        {
            if (itemFact == null)
                return BadRequest();
            //Para utilizar el ObjectId debo cambiar id por lo que esta comentado en la siguiente linea
            itemFact.Id = id;//new MongoDB.Bson.ObjectId(id);
            await db.UpdateItemFacturable(itemFact);
            return Created("Created", true);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemFacturable(string id)
        {
            await db.DeleteItemFacturable(id);
            return NoContent();
        }
    }
}
