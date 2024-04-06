using Sources.Game.Contexts.Heroes.Implementation.Data.Dto;
using Sources.Game.Contexts.Heroes.Implementation.Domain.Models;

namespace Sources.Game.Contexts.Heroes.Interfaces.Infrastructure.Factories
{
    public interface IHeroFactory
    {
        Hero Create(HeroData data);
    }
}