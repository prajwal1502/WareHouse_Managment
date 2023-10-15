using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse_Managment.DTO;
using WareHouse_Managment.Migrations;
using WareHouse_Managment.Models;
using WareHouse_Managment.Service;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using WareHouse_Managment.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WareHouse_Managment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WareHouseController : ControllerBase
    {
        private readonly IClothService _clothService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IBOHService _bohService;
        private readonly WareHouse_ManagmentContext _context;

        public WareHouseController(IClothService clothService, IHttpClientFactory httpClientFactory, IBOHService bohService, WareHouse_ManagmentContext context)
        {
            _clothService = clothService;
            _httpClientFactory = httpClientFactory;
            _bohService = bohService;
            _context = context;
        }

        // GET: api/WareHouse
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Cloth>>> GetCloth()

        {
            try
            {
                var clothes = await _clothService.GetAllClothesAsync();
                return Ok(clothes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/WareHouse/5
        [HttpGet]
        [Route(("{id}"))]
        public async Task<ActionResult<Cloth>> GetCloth(int id)
        {
            try
            {
                var cloth = await _clothService.GetClothByIdAsync(id);
                if (cloth == null)
                {
                    return NotFound();
                }

                return Ok(cloth);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/WareHouse/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCloth(int id, Cloth cloth)
        {
            try
            {
                if (id != cloth.ClothId)
                {
                    return BadRequest();
                }

                await _clothService.UpdateClothAsync(cloth);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/WareHouse
        [HttpPost]
        public async Task<ActionResult<Cloth>> PostCloth(Cloth cloth)
        {
            try
            {
                await _clothService.AddClothAsync(cloth);
                return CreatedAtAction("GetCloth", new { id = cloth.ClothId }, cloth);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/WareHouse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCloth(int id)
        {
            try
            {
                await _clothService.DeleteClothAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #region
        //[httppost("move")]
        //public async task<iactionresult> moveclothtoboh([frombody] clothtobohtransferdto transferdto)
        //{
        //    try
        //    {
        //        // you can validate the received data here.

        //        // create an instance of httpclient using the factory.
        //        var httpclient = _httpclientfactory.createclient("myapi"); // use the named client you configured.

        //        // call the api endpoint to add data to the boh table.
        //        var bohapiresponse = await httpclient.postasjsonasync("api/boh", transferdto);

        //        if (!bohapiresponse.issuccessstatuscode)
        //        {
        //            return badrequest("failed to move data to boh");
        //        }

        //        // optionally, you can call the api endpoint to delete data from the cloth table.
        //        var clothdeleteapiresponse = await httpclient.deleteasync($"api/warehouse/{transferdto.id}");

        //        if (!clothdeleteapiresponse.issuccessstatuscode)
        //        {
        //            // handle the error or log it.
        //        }

        //        return ok("data moved successfully");
        //    }
        //    catch (exception ex)
        //    {
        //        return statuscode(500, $"internal server error: {ex.message}");
        //    }
        //}
        #endregion

        #region
        // [HttpPost("move")]
        //public async Task<IActionResult> MoveClothToBOH([FromBody] ClothDto cloth)
        //{
        //    try
        //    {
        //        // Assuming you have a Cloth service to retrieve Cloth data by Id.
        //        // var cloth1 = await _clothService.GetClothByIdAsync(cloth.Id);
        //        var cloth1 = await _context.Cloth.FindAsync(cloth.Id);
        //        if (cloth1 == null)
        //        {
        //            return NotFound("Cloth not found");
        //        }

        //        var bohDto = new BOHDto
        //        {
        //            EAN = cloth1.EAN,
        //            EpcNo = cloth1.EpcNo,
        //            Type = cloth1.Type,
        //            Size = cloth1.Size
        //        };

        //        //var boh = await _bohService.AddBOHAsync(BOHDto);
        //        //return CreatedAtAction("GetBOH", new { id = bohDto.Id }, bohDto);

        //        //_context.BOH.Add(bohDto);
        //        //var boh = await _context.SaveChangesAsync();

        //        var httpClient = new HttpClient();
        //        httpClient.BaseAddress = new Uri("https://localhost:7251");
        //        var boh = await httpClient.PostAsJsonAsync("/api/BOH", bohDto);

        //        if (boh == null)
        //        {
        //            return BadRequest("Failed to move data to BOH");
        //        }

        //        return Ok("Data moved successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        #endregion

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferData([FromBody] TransferDataModel model)
        {
            try
            {
                var storedProcedure = "TransferClothToBOH";

                var clothIdParam = new SqlParameter("@ClothId", SqlDbType.Int) { Value = model.ClothId };
                var storeIdParam = new SqlParameter("@StoreId", SqlDbType.Int) { Value = model.StoreId };

                await _context.Database.ExecuteSqlRawAsync($"{storedProcedure} @ClothId, @StoreId", clothIdParam, storeIdParam);

                return Ok("Data transferred successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}