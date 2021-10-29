// Programmer : Mehdi Ahmadiyan Kaji -- Date : 1400/04/16 -- Time : 08:42 ق.ظ

using System.Data;

namespace Clean14000716.Persistence.OtherORM.Dapper.Repositories.Base
{
    public abstract class BaseRepository
    {
        protected IDbTransaction Transaction { get;}
        protected IDbConnection Connection => Transaction.Connection;

        protected BaseRepository(IDbTransaction transaction)
        {
            Transaction = transaction;
        }
    }

     
}