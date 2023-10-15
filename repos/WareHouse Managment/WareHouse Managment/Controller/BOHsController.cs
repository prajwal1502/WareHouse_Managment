using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WareHouse_Managment.Data;
using WareHouse_Managment.DTO; // Import the DTO for data transfer
using WareHouse_Managment.Models;
using WareHouse_Managment.Service;

namespace WareHouse_Managment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BOHController : ControllerBase
    {
        private readonly IBOHService _bohService;
        private readonly WareHouse_ManagmentContext _context;


        public BOHController(IBOHService bohService, WareHouse_ManagmentContext context)
        {
            _bohService = bohService;
            _context = context;
        }

        // GET: api/BOH
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BOH>>> GetBOH()
        {
            try
            {
                var bohItems = await _bohService.GetAllBOHsAsync();
                return Ok(bohItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/BOH/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BOH>> GetBOH(int id)
        {
            try
            {
                var bohItem = await _bohService.GetBOHByIdAsync(id);
                if (bohItem == null)
                {
                    return NotFound();
                }

                return Ok(bohItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/BOH/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBOH(int id, BOH boh)
        {
            try
            {
                if (id != boh.Id)
                {
                    return BadRequest();
                }

                await _bohService.UpdateBOHAsync(boh);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/BOH
        [HttpPost]
        public async Task<ActionResult<BOH>> PostBOH(BOH boh)
        {
            try
            {
                await _bohService.AddBOHAsync(boh);
                return CreatedAtAction("GetBOH", new { id = boh.Id }, boh);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/BOH/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBOH(int id)
        {
            try
            {
                await _bohService.DeleteBOHAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferData([FromBody] TransferDataModel2 model)
        {
            try
            {
                // Define the name of your stored procedure
                var storedProcedureName = "TransferDataFromBOHToFOH";

                var BIdParam = new SqlParameter("@BOHId", SqlDbType.Int) { Value = model.BId };

                // Execute the stored procedure using raw SQL
                await _context.Database.ExecuteSqlRawAsync($"{storedProcedureName} @BOHId", BIdParam);

                return Ok("Data transferred successfully from BOH to FOH.");
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}
