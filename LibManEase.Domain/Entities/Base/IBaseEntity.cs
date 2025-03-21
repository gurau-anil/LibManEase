namespace LibManEase.Domain.Entities.Base
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? UpdatedOn { get; set; }
    }
}
