using System;
using Sources.Game.Contexts.Abilities.Implementation.Controllers.Presenters;
using Sources.Game.Contexts.Abilities.Implementation.Domain.Models;
using Sources.Game.Contexts.Abilities.Implementation.Presentation.Views;
using Object = UnityEngine.Object;

namespace Sources.Game.Contexts.Abilities.Implementation.Infrastructure.Factories
{
    public class AbilityViewFactory
    {
        private readonly AbilityView _prefab;

        public AbilityViewFactory(AbilityView prefab)
        {
            _prefab = prefab ? prefab : throw new ArgumentNullException(nameof(prefab));
        }

        public AbilityView Create(Ability ability)
        {
            var view = Object.Instantiate(_prefab);
            var presenter = new AbilityPresenter(ability, view);
            view.Construct(presenter);
            
            return view;
        }
    }
}