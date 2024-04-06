using System;
using Sources.Game.Contexts.Abilities.Implementation.Domain.Models;
using Sources.Game.Contexts.Abilities.Implementation.Infrastructure.Factories;
using Sources.Game.Contexts.Heroes.Implementation.Domain.Models;
using Sources.Game.Contexts.Heroes.Interfaces.Presentation.Views;
using Sources.Libraries.Mvp.Implementation.Presenters;

namespace Sources.Game.Contexts.Heroes.Implementation.Controllers.Presenters
{
    public class HeroPresenter : PresenterBase
    {
        private readonly Hero _model;

        private readonly IHeroView _view;
        private readonly AbilityViewFactory _abilityViewFactory;

        public HeroPresenter(Hero model, IHeroView view, AbilityViewFactory abilityViewFactory)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _abilityViewFactory = abilityViewFactory ?? throw new ArgumentNullException(nameof(abilityViewFactory));
        }

        public override void Enable() => 
            _model.AbilityAdded += OnAbilityAdded;

        public override void Disable() => 
            _model.AbilityAdded -= OnAbilityAdded;

        private void OnAbilityAdded(Ability ability)
        {
            var abilityView = _abilityViewFactory.Create(ability);
       //     _view.Add(abilityView);
        }
    }
}