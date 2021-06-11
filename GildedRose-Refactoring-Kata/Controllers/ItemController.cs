using GildedRose_Refactoring_Kata.Factories;
using GildedRose_Refactoring_Kata.Model;
using GildedRose_Refactoring_Kata.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GildedRose_Refactoring_Kata.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemUpdaterService _service;

        public ItemController(IItemUpdaterService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return new ObjectResult(_service.GetAll());
        }

        /// <response code="200">Produto criado com sucesso.</response>
        /// <response code="400">Dados inválido.</response>
        [HttpPost("Cadastrar um produto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostItem([FromBody] Item item, ItemTypes type)
        {
            var actualItem = _service.Add(item, type);
            return CreatedAtAction(nameof(GetItem), new { id = actualItem.Id }, item);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = _service.Find(id);
            if (item == null)
                return NotFound();
            return new ObjectResult(item as Item);
        }

        [HttpPost]
        [Route("Update quality")]
        public IActionResult UpdateItems()
        {
            _service.UpdateQuality();
            return GetItems();
        }
    }
}
