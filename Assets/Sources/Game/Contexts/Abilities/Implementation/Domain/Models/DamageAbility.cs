using Sources.Game.Contexts.Abilities.Implementation.Data.Dtos;

namespace Sources.Game.Contexts.Abilities.Implementation.Domain.Models
{
    public class DamageAbility : Ability
    {
        public DamageAbility(AbilityData data, int order) : base(data, order)
        {
        }
    }
}