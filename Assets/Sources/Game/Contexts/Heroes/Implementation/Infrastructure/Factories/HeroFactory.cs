using Sources.Game.Contexts.Damages.Models;
using Sources.Game.Contexts.Heroes.Implementation.Data.Dto;
using Sources.Game.Contexts.Heroes.Implementation.Domain.Models;

namespace Sources.Game.Contexts.Heroes.Implementation.Infrastructure.Factories
{
    public class HeroFactory
    {
        public Hero Create(HeroData data)
        {
            var damage = new Damage() { Value = data.Damage };
            
            return new Hero(damage, data.Level, data.DamagePerLevel);
        }
    }
}