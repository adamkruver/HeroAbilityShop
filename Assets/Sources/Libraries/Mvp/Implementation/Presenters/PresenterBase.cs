using Sources.Libraries.Mvp.Interfaces.Presenters;

namespace Sources.Libraries.Mvp.Implementation.Presenters
{
    public class PresenterBase : IPresenter
    {
        public virtual void Initialize()
        {
        }

        public virtual void Enable()
        {
        }

        public virtual void Disable()
        {
        }

        public virtual void Destroy()
        {
        }
    }
}