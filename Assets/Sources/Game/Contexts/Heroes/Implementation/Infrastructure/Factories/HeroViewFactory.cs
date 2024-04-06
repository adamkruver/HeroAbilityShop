using System;
using Sources.Game.Contexts.Abilities.Implementation.Infrastructure.Factories;
using Sources.Game.Contexts.Heroes.Implementation.Controllers.Presenters;
using Sources.Game.Contexts.Heroes.Implementation.Domain.Models;
using Sources.Game.Contexts.Heroes.Implementation.Presentation.Views;
using Sources.Game.Contexts.Heroes.Interfaces.Presentation.Views;
using Object = UnityEngine.Object;

namespace Sources.Game.Contexts.Heroes.Implementation.Infrastructure.Factories
{
    public class HeroViewFactory
    {
        private readonly AbilityViewFactory _abilityViewFactory;
        private readonly HeroView _prefab;

        public HeroViewFactory(AbilityViewFactory abilityViewFactory, HeroView prefab)
        {
            _abilityViewFactory = abilityViewFactory ?? throw new ArgumentNullException(nameof(abilityViewFactory));
            _prefab = prefab ? prefab : throw new ArgumentNullException(nameof(prefab));
        }

        public IHeroView Create(Hero hero)
        {
            var view = Object.Instantiate(_prefab);
            var presenter = new HeroPresenter(hero, view, _abilityViewFactory);

            view.Construct(presenter);

            return view;
        }
    }
}