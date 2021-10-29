namespace Clean14000716.Domain.Entities.Base
{
    public interface IEntity
    {
    }
    public interface IBaseEntity<TType> : IEntity
    {
        public TType Id { get; set; }
    }
    public interface IBaseEntity : IBaseEntity<int>
    {
    }

}