using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;
using TestAPI.Repository.Interfaces;

namespace TestAPI.Repository.Implementations
{
    public class TableOneRepository : ITableOneRepository
    {
        private readonly TestdbContext _db;

        public TableOneRepository(TestdbContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateRecord(Table1 tableOne)
        {
            await _db.AddAsync(tableOne);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRecord(int id)
        {
            Table1 deleteRecord = await _db.Table1.FirstOrDefaultAsync(x => x.IdTable == id);
            _db.Remove(deleteRecord);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Table1> GetRecordById(int id)
        {
            return await _db.Table1.FirstOrDefaultAsync(x => x.IdTable == id);
        }

        public async Task<IEnumerable<Table1>> GetRecords()
        {
            return await _db.Table1.ToListAsync();
        }

        public async Task<bool> UpdateRecord(Table1 tableOne)
        {
            Table1 updateRecord = await _db.Table1.FirstOrDefaultAsync(x => x.IdTable == tableOne.IdTable);

            if (updateRecord != null)
            {
                updateRecord.Field1 = tableOne.Field1;
                updateRecord.Field2 = tableOne.Field2;
                updateRecord.Field3 = tableOne.Field3;
                updateRecord.Field4 = tableOne.Field4;
                updateRecord.Field5 = tableOne.Field5;

                _db.Update(updateRecord);
                return await _db.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
