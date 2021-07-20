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
    [Route("api/tabletwo")]
    public class TableTwoController : ControllerBase
    {
        private readonly ITableTwoBusiness _business;

        public TableTwoController(ITableTwoBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public IActionResult GetRecords()
        {
            try
            {
                return Ok(
                    _business.GetRecords()
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        [HttpGet("{id}")]
        public IActionResult GetRecordById(int id)
        {
            try
            {
                return Ok(
                    _business.GetRecordById(id)
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateRecord(Table2 tableTwo)
        {
            try
            {
                return Ok(
                    _business.CreateRecord(tableTwo)
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateRecord(Table2 tableTwo)
        {
            try
            {
                return Ok(
                    _business.UpdateRecord(tableTwo)
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(int id)
        {
            try
            {
                return Ok(
                    _business.DeleteRecord(id)
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
