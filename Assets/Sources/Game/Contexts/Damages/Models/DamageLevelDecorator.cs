using System;
using Sources.Game.Contexts.Heroes.Implementation.Domain.Models;

namespace Sources.Game.Contexts.Damages.Models
{
    public class DamageLevelDecorator : Damage
    {
        private readonly Damage _damage;
        private readonly Hero _hero;
        private readonly int _damagePerLevel;

        public DamageLevelDecorator(Damage damage, Hero hero, int damagePerLevel)
        {
            if (damagePerLevel <= 0) 
                throw new ArgumentOutOfRangeException(nameof(damagePerLevel));
            
            _damage = damage ?? throw new ArgumentNullException(nameof(damage));
            _hero = hero ?? throw new ArgumentNullException(nameof(hero));
            _damagePerLevel = damagePerLevel;
        }

        public override int Value => _damage.Value + _hero.Level * _damagePerLevel;
    }
}