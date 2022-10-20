using Entities.Models;
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
        Task<Alert> Get(int Id, List<string> includes, bool trackChanges);
    }
}
