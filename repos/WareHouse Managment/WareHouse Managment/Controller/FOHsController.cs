using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using WareHouse_Managment.Data;
using WareHouse_Managment.Models;
using WareHouse_Managment.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WareHouse_Managment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FOHsController : ControllerBase
    {
        private readonly IFOHService _fohService;

        public FOHsController(IFOHService fohService)
        {
            _fohService = fohService;
        }

        // GET: api/FOHs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FOH>>> GetFOH()
        {
            try
            {
                var fohs = await _fohService.GetAllFOHsAsync();
                return Ok(fohs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/FOHs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FOH>> GetFOH(int id)
        {
            try
            {
                var foh = await _fohService.GetFOHByIdAsync(id);
                if (foh == null)
                {
                    return NotFound();
                }

                return Ok(foh);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/FOHs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFOH(int id, FOH foh)
        {
            try
            {
                if (id != foh.Id)
                {
                    return BadRequest();
                }

                await _fohService.UpdateFOHAsync(foh);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/FOHs
        [HttpPost]
        public async Task<ActionResult<FOH>> PostFOH(FOH foh)
        {
            try
            {
                await _fohService.AddFOHAsync(foh);
                return CreatedAtAction("GetFOH", new { id = foh.Id }, foh);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/FOHs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFOH(int id)
        {
            try
            {
                await _fohService.DeleteFOHAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PATCH: api/FOHs/5
        [HttpPatch("Sale/{id}")]
        public async Task<IActionResult> PatchFOH(int id)
        {
            try
            {
                var existingFOH = await _fohService.GetFOHByIdAsync(id);

                if (existingFOH == null)
                {
                    return NotFound();
                }

                // Automatically update the SellDate to the current datetime
                existingFOH.SellDate = DateTime.Now;

                // Set IsActive to 0 (false)
                existingFOH.IsActive = false;

                await _fohService.UpdateFOHAsync(existingFOH);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

