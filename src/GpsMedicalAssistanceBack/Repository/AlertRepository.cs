using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Core;
using Repository.Extensions;

namespace Repository
{
    public class AlertRepository : RepositoryBase<Alert>, IAlertRepository
    {
        public AlertRepository(ApplicationDbContext context) : base(context) { }

        public void CreateAlert(Alert model)
        {
            Create(model);
        }

        public async Task<IEnumerable<Alert>> GetAll(AlertParameters parameters, bool trackChanges)
        {
            return await FindAll(parameters.Includes, trackChanges).Filter(parameters).SortBy(parameters).ToListAsync();
        }

        public async Task<Alert> Get(int Id, List<IncludesGeneral> includes, bool trackChanges)
        {
            return await FindSingleByCondition(x => x.Id == Id, includes, trackChanges);
        }
    }
}
