// Programmer : Mehdi Ahmadiyan Kaji -- Date : 1400/04/16 -- Time : 08:40 ق.ظ

using System.Data;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.OtherORM.Dapper.IRepositories;
using Clean14000716.Domain.Entities;
using Clean14000716.Persistence.OtherORM.Dapper.Repositories.Base;

namespace Clean14000716.Persistence.OtherORM.Dapper.Repositories
{
    public class SchoolRepository : CrudRepository<School, int>, ISchoolRepository
    {
        public SchoolRepository(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}