using System;
using Sources.Game.Contexts.Abilities.Implementation.Domain.Models;
using Sources.Game.Contexts.Abilities.Implementation.Presentation.Views;
using Sources.Libraries.Mvp.Implementation.Presenters;
using Unity.VisualScripting;
using UnityEngine;

namespace Sources.Game.Contexts.Abilities.Implementation.Controllers.Presenters
{
    public class AbilityPresenter : PresenterBase
    {
        private readonly Ability _model;
        private readonly AbilityView _view;

        public AbilityPresenter(Ability model, AbilityView view)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _view = view ? view : throw new ArgumentNullException(nameof(view));
        }

        public override void Enable() => 
            _view.AddClickListener(OnButtonClick);

        public override void Disable() => 
            _view.RemoveClickListener(OnButtonClick);

        private void OnButtonClick()
        {
            Debug.Log("Button clicked");
        }
    }
}