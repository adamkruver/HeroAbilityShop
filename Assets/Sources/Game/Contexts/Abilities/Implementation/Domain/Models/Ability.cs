using Sources.Game.Contexts.Abilities.Implementation.Data.Dtos;

namespace Sources.Game.Contexts.Abilities.Implementation.Domain.Models
{
    public abstract class Ability
    {
        protected Ability(AbilityData data, int order)
        {
            Order = order;
            Name = data.Name;
            Bonus = data.Bonus;
        }


        public string Name { get; }
        public int Bonus { get; }
        public int Order { get; }
    }
}