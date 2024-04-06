using Sources.Game.Contexts.Abilities.Implementation.Data.Dtos;
using Sources.Game.Contexts.Abilities.Implementation.Domain.Models;

namespace Sources.Game.Contexts.Abilities.Interfaces.Infrastructure.Factories
{
    public interface IAbilityFactory
    {
        Ability Create(AbilityData data, int order);
    }
}