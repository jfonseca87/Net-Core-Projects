using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Services.Interfaces
{
    public interface ITableTwoBusiness
    {
        public IEnumerable<Table2> GetRecords();
        public Table2 GetRecordById(int id);
        public bool CreateRecord(Table2 tableTwo);
        public bool UpdateRecord(Table2 tableTwo);
        public bool DeleteRecord(int id);
    }
}
