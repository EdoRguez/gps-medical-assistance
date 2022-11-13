using Entities.Models;
using Entities.RequestFeatures;

namespace Repository.Extensions
{
    public static class AlertRepositoryExtensions
    {
        public static IQueryable<Alert> SortBy(this IQueryable<Alert> alerts, AlertParameters parameters)
        {
            if (parameters.OrderBy == (int)OrderBy.CreationDate)
                return alerts.OrderByDescending(x => x.CreationDate);

            return alerts;
        }

        public static IQueryable<Alert> Filter(this IQueryable<Alert> alerts, AlertParameters parameters)
        {
            if (parameters.Includes.Count <= 0)
                return alerts;

            if (!String.IsNullOrEmpty(parameters.Name))
                 alerts = alerts.Where(x =>
                                            x.AlertUsers.First(x => x.Id_AlertUserType == parameters.AlertUserTypeId).User.Name
                                                        .ToUpper()
                                                        .Contains(parameters.Name.ToUpper()));

            if (!String.IsNullOrEmpty(parameters.LastName))
                 alerts = alerts.Where(x =>
                                            x.AlertUsers.First(x => x.Id_AlertUserType == parameters.AlertUserTypeId).User.LastName
                                                        .ToUpper()
                                                        .Contains(parameters.LastName.ToUpper()));

            if(!String.IsNullOrEmpty(parameters.IdentificationType))
                alerts = alerts.Where(x =>
                                            x.AlertUsers.First(x => x.Id_AlertUserType == parameters.AlertUserTypeId).User.Identification
                                                        .Contains(parameters.IdentificationType));

            if(!String.IsNullOrEmpty(parameters.Identification))
                alerts = alerts.Where(x =>
                                            x.AlertUsers.First(x => x.Id_AlertUserType == parameters.AlertUserTypeId).User.Identification
                                                        .Contains(parameters.Identification));

            if(parameters.Age is not null)
            {
                int currentYear = DateTime.Today.Year;
                alerts = alerts.Where(x =>
                                            (currentYear - x.AlertUsers.First(x => x.Id_AlertUserType == parameters.AlertUserTypeId).User.BirthDate.Year) == parameters.Age);
            }

            if(parameters.InitDate is not null)
                alerts = alerts.Where(x => x.CreationDate.Date >= parameters.InitDate.Value.Date);

            if(parameters.EndDate is not null)
                alerts = alerts.Where(x => x.CreationDate.Date <= parameters.EndDate.Value.Date);


            return alerts;
        }
    }
}
