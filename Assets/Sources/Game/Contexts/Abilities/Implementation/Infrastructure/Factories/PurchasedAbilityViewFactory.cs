using System;
using Sources.Game.Contexts.Abilities.Implementation.Controllers.Presenters;
using Sources.Game.Contexts.Abilities.Implementation.Domain.Models;
using Sources.Game.Contexts.Abilities.Implementation.Presentation.Views;
using Sources.Game.Contexts.Heroes.Implementation.Domain.Models;
using Object = UnityEngine.Object;

namespace Sources.Game.Contexts.Abilities.Implementation.Infrastructure.Factories
{
    public class PurchasedAbilityViewFactory
    {
            private readonly PurchasedAbilityView _prefab;

            public PurchasedAbilityViewFactory(PurchasedAbilityView prefab)
            {
                _prefab = prefab ? prefab : throw new ArgumentNullException(nameof(prefab));
            }

            public PurchasedAbilityView Create(Ability ability, Hero hero)
            {
                var view = Object.Instantiate(_prefab);
                var presenter = new PurchasedAbilityPresenter(ability, view, hero);
                view.Construct(presenter);
            
                return view;
            }
    }
}