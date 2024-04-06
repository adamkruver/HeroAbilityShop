using Sources.Game.Contexts.Abilities.Implementation.Controllers.Presenters;
using Sources.Libraries.Mvp.Implementation.Views;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Sources.Game.Contexts.Abilities.Implementation.Presentation.Views
{
    public class AbilityView : PresentationView<AbilityPresenter>
    {
        [SerializeField] private Button _button;

        public void AddClickListener(UnityAction action) =>
            _button.onClick.AddListener(action);

        public void RemoveClickListener(UnityAction action) =>
            _button.onClick.RemoveListener(action);
    }
}