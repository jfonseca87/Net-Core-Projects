using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Repository.Interfaces
{
    public interface ITableOneRepository
    {
        public Task<IEnumerable<Table1>> GetRecords();
        public Task<Table1> GetRecordById(int id);
        public Task<bool> CreateRecord(Table1 tableOne);
        public Task<bool> UpdateRecord(Table1 tableOne);
        public Task<bool> DeleteRecord(int id);
    }
}
