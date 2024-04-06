using Sources.Game.Contexts.Abilities.Implementation.Infrastructure.Factories;
using Sources.Game.Contexts.Abilities.Implementation.Presentation.Views;
using Sources.Game.Contexts.AbilityShops.Implementation.Presentation.Views;
using Sources.Game.Contexts.Heroes.Implementation.Infrastructure.Factories;
using Sources.Game.Contexts.Heroes.Implementation.Presentation.Views;
using UnityEngine;
using Zenject;

namespace Sources.MonoInstallers
{
    public class SceneMonoInstaller : MonoInstaller 
    {
        [SerializeField] private AbilityShopView _abilityShopView;
        [SerializeField] private HeroView _heroViewPrefab;
        [SerializeField] private AbilityView _abilityViewPrefab;
        [SerializeField] private PurchasedAbilityView _purchasedAbilityViewPrefab;

        public override void InstallBindings()
        {
            Container.Bind<HeroView>().FromInstance(_heroViewPrefab);
            Container.Bind<AbilityView>().FromInstance(_abilityViewPrefab);
            Container.Bind<PurchasedAbilityView>().FromInstance(_purchasedAbilityViewPrefab);
            Container.Bind<AbilityShopView>().FromInstance(_abilityShopView);
            Container.Bind<HeroViewFactory>().AsSingle();
            Container.Bind<HeroFactory>().AsSingle();
            Container.Bind<AbilityFactory>().AsSingle();
            Container.Bind<AbilityViewFactory>().AsSingle();
            Container.Bind<PurchasedAbilityViewFactory>().AsSingle();
        }
    }
}