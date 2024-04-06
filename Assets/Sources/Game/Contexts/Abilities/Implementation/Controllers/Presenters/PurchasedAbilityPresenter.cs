using System;
using Sources.Game.Contexts.Abilities.Implementation.Domain.Models;
using Sources.Game.Contexts.Abilities.Implementation.Presentation.Views;
using Sources.Game.Contexts.Heroes.Implementation.Domain.Models;
using Sources.Libraries.Mvp.Implementation.Presenters;

namespace Sources.Game.Contexts.Abilities.Implementation.Controllers.Presenters
{
    public class PurchasedAbilityPresenter : PresenterBase
    {
        private readonly Ability _model;
        private readonly PurchasedAbilityView _view;
        private readonly Hero _hero;

        public PurchasedAbilityPresenter(Ability model, PurchasedAbilityView view, Hero hero)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ? view : throw new ArgumentNullException(nameof(view));
            _hero = hero ?? throw new ArgumentNullException(nameof(hero));
        }

        public override void Enable() =>
            _view.AddClickListener(OnButtonClick);

        public override void Disable() =>
            _view.RemoveClickListener(OnButtonClick);

        private void OnButtonClick()
        {
            _hero.AddAbility(_model);
            _view.Destroy();
        }
    }
}