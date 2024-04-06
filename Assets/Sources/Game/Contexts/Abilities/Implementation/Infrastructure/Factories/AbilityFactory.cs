using System;
using System.Collections.Generic;
using Sources.Game.Contexts.Abilities.Implementation.Data.Dtos;
using Sources.Game.Contexts.Abilities.Implementation.Domain.Models;
using Sources.Game.Contexts.Abilities.Implementation.Infrastructure.Factories.Types;
using Sources.Game.Contexts.Abilities.Interfaces.Infrastructure.Factories;

namespace Sources.Game.Contexts.Abilities.Implementation.Infrastructure.Factories
{
    public class AbilityFactory
    {
        private readonly Dictionary<string, IAbilityFactory> _factories;

        public AbilityFactory() =>
            _factories = new Dictionary<string, IAbilityFactory>()
            {
                ["Ability 1"] = new Ability1Factory(),
                ["Ability 2"] = new Ability2Factory(),
                ["Ability 3"] = new Ability3Factory(),
                ["Ability 4"] = new Ability4Factory(),
            };

        public Ability Create(AbilityData data, int order)
        {
            if(_factories.ContainsKey(data.Name) == false)
                throw new InvalidOperationException($"Ability with name {data.Name} not found");
            
            return _factories[data.Name].Create(data, order);
        }
    }
}