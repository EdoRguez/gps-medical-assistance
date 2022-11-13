using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class UserRepositoryExtensions
    {
        public static IQueryable<User> FilterUsers(this IQueryable<User> users, UserParameters userParameters)
        {
            if(userParameters.Identificationtype == null || string.IsNullOrEmpty(userParameters.Identification))
                return users;


            return users.Where(x =>
                                    x.Identification.Contains(userParameters.Identificationtype.ToString()) &&
                                    x.Identification.Contains(userParameters.Identification
            ));
        }
    }
}
