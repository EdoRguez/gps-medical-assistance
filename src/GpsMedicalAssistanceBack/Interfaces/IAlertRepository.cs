using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAlertRepository
    {
        void CreateAlert(Alert model);
        Task<IEnumerable<Alert>> GetAll(List<IncludesGeneral> includes, bool trackChanges);
        Task<Alert> Get(int Id, List<IncludesGeneral> includes, bool trackChanges);
    }
}
