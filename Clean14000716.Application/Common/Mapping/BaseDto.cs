// Programmer : Mehdi Ahmadiyan Kaji -- Date : 1400/05/27 -- Time : 12:10 ب.ظ

using AutoMapper;
using Clean14000716.Domain.Entities.Base;

namespace Clean14000716.Application.Common.Mapping
{
    public abstract class BaseDto<TEntityDto, TEntity, TKey> : IHaveMapping
    where TEntityDto : class, new()
    where TEntity : IBaseEntity<TKey>, new()
    {

        public TKey Id { get; set; }
      
        public static TEntityDto FromEntity(TEntity model)
        {
            var config = new MapperConfiguration(
                expression => expression.CreateMap(typeof(TEntityDto), typeof(TEntity)).ReverseMap()
                );

            var mapper = config.CreateMapper();
            return mapper.Map<TEntityDto>(model);
        }
        protected TEntityDto CastToDerivedClass(BaseDto<TEntityDto, TEntity, TKey> baseInstance)
        {
            var config = new MapperConfiguration(
                expression => expression.CreateMap(typeof(TEntityDto), typeof(TEntity)).ReverseMap()
            );
            var mapper = config.CreateMapper();
            var sed = mapper.Map<TEntityDto>(baseInstance);
            return sed;
        }

        public TEntity ToEntity(TEntity entity)
        {
            var config = new MapperConfiguration(
                expression => expression.CreateMap(typeof(TEntityDto), typeof(TEntity)).ReverseMap()
            );
            var entityDto = CastToDerivedClass(this);
            var mapper = config.CreateMapper();
            mapper.Map(entityDto, entity);
            return entity;
        }

        public TEntity ToEntity()
        {
            var config = new MapperConfiguration(
                expression => expression.CreateMap(typeof(TEntityDto), typeof(TEntity)).ReverseMap()
            );
            var entityDto = CastToDerivedClass(this);
            var mapper = config.CreateMapper();
            return mapper.Map<TEntity>(entityDto);
        }

        public void CreateMapping(Profile profile)
        {
            var mappingExpression = profile.CreateMap<TEntityDto, TEntity>();

            var dtoType = typeof(TEntityDto);
            var entityType = typeof(TEntity);
            //Ignore any property of source (like Post.Author) that dose not contains in destination 
            foreach (var property in entityType.GetProperties())
            {
                if (dtoType.GetProperty(property.Name) == null)
                    mappingExpression.ForMember(property.Name, opt => opt.Ignore());
            }

            CustomMappings(mappingExpression.ReverseMap());
        }
        public virtual void CustomMappings(IMappingExpression<TEntity, TEntityDto> mapping)
        {
        }

       
    }
    
    public abstract class BaseDto<TDto, TEntity> : BaseDto<TDto, TEntity, int>
        where TDto : class, new()
        where TEntity : IBaseEntity, new()

    {

    }
}