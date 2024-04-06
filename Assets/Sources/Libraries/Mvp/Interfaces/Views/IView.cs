using UnityEngine;

namespace Sources.Libraries.Mvp.Interfaces.Views
{
    public interface IView
    {
        void Show();
        void Hide();
        void Add(IView view);
        void Add(IView view, int order);
        void Remove(IView view);
        void SetParent(Transform parent);
        void Destroy();
    }
}