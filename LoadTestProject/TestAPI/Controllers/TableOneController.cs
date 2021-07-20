using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;
using TestAPI.Services.Interfaces;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/tableone")]
    public class TableOneController : ControllerBase
    {
        private readonly ITableOneBusiness _business;

        public TableOneController(ITableOneBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecords()
        {
            try
            {
                return Ok(
                    await _business.GetRecords()
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecordById(int id)
        {
            try
            {
                return Ok(
                    await _business.GetRecordById(id)
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecord(Table1 tableOne)
        {
            try
            {
                return Ok(
                    await _business.CreateRecord(tableOne)
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecord(Table1 tableOne)
        {
            try
            {
                return Ok(
                    await _business.UpdateRecord(tableOne)
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            try
            {
                return Ok(
                    await _business.DeleteRecord(id)
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
