using System;
namespace CS321_W5D2_BlogAPI.Core.Models
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
