// Programmer : Mehdi Ahmadiyan Kaji -- Date : 1400/04/16 -- Time : 07:45 ق.ظ

using Clean14000716.Application.Common.Interfaces.IUnitOfWork.OtherORM.Dapper.IRepositories;

namespace Clean14000716.Application.Common.Interfaces.IUnitOfWork.OtherORM.Dapper
{
    public interface IUnitOfWork 
    {
        public ISchoolRepository SchoolRepository { get; }
 
        void Commit();
    }
}