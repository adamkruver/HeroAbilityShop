using Sources.Libraries.Mvp.Interfaces.Presenters;

namespace Sources.Libraries.Mvp.Interfaces.Views
{
    public interface IPresentationView<T> : IView where T : IPresenter
    {
    }
}