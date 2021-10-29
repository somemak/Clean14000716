// Programmer : Mehdi Ahmadiyan Kaji -- Date : 1400/04/16 -- Time : 08:22 ق.ظ

using System.Data;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.OtherORM.Dapper;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.OtherORM.Dapper.IRepositories;
using Clean14000716.Persistence.OtherORM.Dapper.Repositories;
using Microsoft.Data.SqlClient;

namespace Clean14000716.Persistence.OtherORM.Dapper.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connectionString = "Server=.;Database=library1000;Trusted_Connection=True;";
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;
        private ISchoolRepository _schoolRepository;


        public UnitOfWork()
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public ISchoolRepository SchoolRepository => _schoolRepository ??= new SchoolRepository(_transaction);



        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        private void ResetRepositories()
        {
            _schoolRepository = null;

        }


    }
}