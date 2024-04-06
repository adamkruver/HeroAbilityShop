using Sources.Game.Contexts.Heroes.Implementation.Controllers.Presenters;
using Sources.Libraries.Mvp.Interfaces.Views;

namespace Sources.Game.Contexts.Heroes.Interfaces.Presentation.Views
{
    public interface IHeroView : IPresentationView<HeroPresenter>
    {
        void AddPurchased(IView view);
    }
}