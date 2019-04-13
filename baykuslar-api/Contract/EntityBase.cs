using System.ComponentModel.DataAnnotations;

namespace baykuslar_api.Contract
{
    public class EntityBase<T> where T : struct
    {
        [Key] public T Id { get; set; } = default(T);
    }
}