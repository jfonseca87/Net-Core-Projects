using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;
using TestAPI.Repository.Interfaces;

namespace TestAPI.Repository.Implementations
{
    public class TableTwoRepository : ITableTwoRepository
    {
        private readonly TestdbContext _db;

        public TableTwoRepository(TestdbContext db)
        {
            _db = db;
        }

        public bool CreateRecord(Table2 tableTwo)
        {
            _db.Add(tableTwo);
            return _db.SaveChanges() > 0;
        }

        public bool DeleteRecord(int id)
        {
            Table1 deleteRecord = _db.Table1.FirstOrDefault(x => x.IdTable == id);
            _db.Remove(deleteRecord);
            return _db.SaveChanges() > 0;
        }

        public Table2 GetRecordById(int id)
        {
            return _db.Table2.FirstOrDefault(x => x.IdTable == id);
        }

        public IEnumerable<Table2> GetRecords()
        {
            return _db.Table2.ToList();
        }

        public bool UpdateRecord(Table2 tableTwo)
        {
            Table2 updateRecord = _db.Table2.FirstOrDefault(x => x.IdTable == tableTwo.IdTable);

            if (updateRecord != null)
            {
                updateRecord.Field1 = tableTwo.Field1;
                updateRecord.Field2 = tableTwo.Field2;
                updateRecord.Field3 = tableTwo.Field3;
                updateRecord.Field4 = tableTwo.Field4;
                updateRecord.Field5 = tableTwo.Field5;

                _db.Update(updateRecord);
                return _db.SaveChanges() > 0;
            }

            return false;
        }
    }
}
