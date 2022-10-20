using Entities;
using Entities.Models;
using Interfaces;
using Repository.Core;

namespace Repository
{
    public class AlertRepository : RepositoryBase<Alert>, IAlertRepository
    {
        public AlertRepository(ApplicationDbContext context) : base(context) { }

        public void Create(Alert model)
        {
            Create(model);
        }
    }
}
