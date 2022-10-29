using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Core;

namespace Repository
{
    public class AlertRepository : RepositoryBase<Alert>, IAlertRepository
    {
        public AlertRepository(ApplicationDbContext context) : base(context) { }

        public void CreateAlert(Alert model)
        {
            Create(model);
        }

        public async Task<IEnumerable<Alert>> GetAll(List<IncludesGeneral> includes, bool trackChanges)
        {
            return await FindAll(includes, trackChanges).ToListAsync();
        }

        public async Task<Alert> Get(int Id, List<IncludesGeneral> includes, bool trackChanges)
        {
            return await FindSingleByCondition(x => x.Id == Id, includes, trackChanges);
        }
    }
}
