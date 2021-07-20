using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;
using TestAPI.Repository.Interfaces;
using TestAPI.Services.Interfaces;

namespace TestAPI.Services.Implementations
{
    public class TableTwoBusiness : ITableTwoBusiness
    {
        private readonly ITableTwoRepository _repository;

        public TableTwoBusiness(ITableTwoRepository repository)
        {
            _repository = repository;
        }
        public bool CreateRecord(Table2 tableTwo)
        {
            return _repository.CreateRecord(tableTwo);
        }

        public bool DeleteRecord(int id)
        {
            return _repository.DeleteRecord(id);
        }

        public Table2 GetRecordById(int id)
        {
            return _repository.GetRecordById(id);
        }

        public IEnumerable<Table2> GetRecords()
        {
            return _repository.GetRecords();
        }

        public bool UpdateRecord(Table2 tableTwo)
        {
            return _repository.UpdateRecord(tableTwo);
        }
    }
}
