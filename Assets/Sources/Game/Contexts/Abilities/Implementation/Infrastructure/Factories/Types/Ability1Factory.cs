using System;
using Sources.Game.Contexts.Abilities.Implementation.Data.Dtos;
using Sources.Game.Contexts.Abilities.Implementation.Domain.Models;
using Sources.Game.Contexts.Abilities.Interfaces.Infrastructure.Factories;

namespace Sources.Game.Contexts.Abilities.Implementation.Infrastructure.Factories.Types
{
    public class Ability1Factory : IAbilityFactory
    {
        public Ability Create(AbilityData data, int order)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return new DamageAbility(data, order);
        }
    }
}