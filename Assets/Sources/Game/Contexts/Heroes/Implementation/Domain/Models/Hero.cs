using System;
using System.Collections.Generic;
using Sources.Game.Contexts.Abilities.Implementation.Domain.Models;
using Sources.Game.Contexts.Damages.Models;

namespace Sources.Game.Contexts.Heroes.Implementation.Domain.Models
{
    public class Hero
    {
        private readonly List<Ability> _abilities;
        private readonly Damage _baseDamage;
        private readonly Damage _damage;

        public Hero(Damage damage, int level, int damagePerLevel = 10)
        {
            if (level <= 0)
                throw new ArgumentOutOfRangeException(nameof(level));

            _baseDamage = damage ?? throw new ArgumentNullException(nameof(damage));
            _damage = new DamageLevelDecorator(_baseDamage, this, damagePerLevel);
            Level = level;
            _abilities = new List<Ability>();
        }

        public event Action<Ability> AbilityAdded = delegate { };
        public event Action<int> LevelUp = delegate { };

        public IReadOnlyList<Ability> Abilities => _abilities;

        public int Damage => _damage.Value;
        public int BaseDamage => _baseDamage.Value;
        public int Level { get; private set; }

        public void UpLevel()
        {
            Level++;
            LevelUp.Invoke(Level);
        }

        public void AddAbility(Ability ability)
        {
            if (ability == null)
                throw new ArgumentNullException(nameof(ability));

            if (_abilities.Contains(ability))
                throw new InvalidOperationException(nameof(ability));

            _abilities.Add(ability);
            AbilityAdded.Invoke(ability);
        }
    }
}