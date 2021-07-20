using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;
using TestAPI.Repository.Interfaces;
using TestAPI.Services.Interfaces;

namespace TestAPI.Services.Implementations
{
    public class TableOneBusiness : ITableOneBusiness
    {
        private readonly ITableOneRepository _repository;

        public TableOneBusiness(ITableOneRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateRecord(Table1 tableOne)
        {
            return await _repository.CreateRecord(tableOne);
        }

        public async Task<bool> DeleteRecord(int id)
        {
            return await _repository.DeleteRecord(id);
        }

        public async Task<Table1> GetRecordById(int id)
        {
            return await _repository.GetRecordById(id);
        }

        public async Task<IEnumerable<Table1>> GetRecords()
        {
            return await _repository.GetRecords();
        }

        public async Task<bool> UpdateRecord(Table1 tableOne)
        {
            return await _repository.UpdateRecord(tableOne);
        }
    }
}
