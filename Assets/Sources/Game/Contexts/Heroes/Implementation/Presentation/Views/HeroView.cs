using Sources.Game.Contexts.Heroes.Implementation.Controllers.Presenters;
using Sources.Game.Contexts.Heroes.Interfaces.Presentation.Views;
using Sources.Libraries.Mvp.Implementation.Views;
using Sources.Libraries.Mvp.Interfaces.Views;
using UnityEngine;

namespace Sources.Game.Contexts.Heroes.Implementation.Presentation.Views
{
    public class HeroView : PresentationView<HeroPresenter>, IHeroView
    {
        [SerializeField] private Transform _abilitiesContainer;

        public override void Add(IView view)
        {
            view.SetParent(_abilitiesContainer);
        }

        public void AddPurchased(IView view)
        {
            view.SetParent(_abilitiesContainer);
            view.Hide();
        }
    }
} 