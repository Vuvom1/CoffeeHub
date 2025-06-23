using AutoMapper;
using CoffeeHub.Models.Domains;
using CoffeeHub.Models.DTOs.TableDtos;
using CoffeeHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;
        public TableController(ITableService tableService,
            IMapper mapper)
        {
            _tableService = tableService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTables()
        {
            var tables = await _tableService.GetAllAsync();
            var tableDtos = _mapper.Map<IEnumerable<TableDto>>(tables);
            return Ok(tableDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableById(Guid id)
        {
            var table = await _tableService.GetByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable([FromBody] AddTableDto tableDto)
        {
            if (tableDto == null)
            {
                return BadRequest("Table cannot be null.");
            }

            var table = _mapper.Map<Table>(tableDto);
            // Check if the table already exists in the database 

            await _tableService.AddAsync(table);
            return Ok("Table created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTable(Guid id, [FromBody] UpdateTableDto tableDto)
        {
            var table = _mapper.Map<Table>(tableDto);    

            await _tableService.UpdateAsync(table);
            return Ok("Table updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(Guid id)
        {
            var table = await _tableService.GetByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            await _tableService.DeleteAsync(table);
            return Ok("Table deleted successfully.");
        }
    }

}
