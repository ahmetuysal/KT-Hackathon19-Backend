namespace baykuslar_api.Mappers
{
    public interface IMapper<TEntity, TModel>
    {
        TModel ToModel(TEntity entity);
        TEntity ToEntity(TModel model);
    }
}