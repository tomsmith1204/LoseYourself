using SeniorProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeniorProject.DAL
{
    public static class Relord
    {

        public static void ReloadEntity<TEntity>(
                       this LoseContext db,
                       TEntity entity)
                       where TEntity : class
        {
            db.Entry(entity).Reload();
        }
    }

}