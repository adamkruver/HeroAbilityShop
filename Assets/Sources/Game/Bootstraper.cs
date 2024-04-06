using System;
using System.Linq;
using Sources.Game.Contexts.Abilities.Implementation.Data.Dtos;
using Sources.Game.Contexts.Abilities.Implementation.Domain.Models;
using Sources.Game.Contexts.Abilities.Implementation.Infrastructure.Factories;
using Sources.Game.Contexts.Abilities.Implementation.Presentation.Views;
using Sources.Game.Contexts.AbilityShops.Implementation.Presentation.Views;
using Sources.Game.Contexts.Heroes.Implementation.Data.Dto;
using Sources.Game.Contexts.Heroes.Implementation.Domain.Models;
using Sources.Game.Contexts.Heroes.Implementation.Infrastructure.Factories;
using Sources.Game.Contexts.Heroes.Implementation.Presentation.Views;
using Sources.Game.Contexts.Heroes.Interfaces.Presentation.Views;
using UnityEngine;
using Zenject;

namespace Sources.Game
{
    public class Bootstraper : MonoBehaviour
    {
        private HeroFactory _heroFactory;
        private HeroViewFactory _heroViewFactory;
        private AbilityFactory _abilityFactory;
        private AbilityViewFactory _abilityViewFactory;

        [Inject]
        private void Construct(
            HeroFactory heroFactory,
            HeroViewFactory heroViewFactory,
            AbilityShopView abilityShopView,
            AbilityFactory abilityFactory,
            AbilityViewFactory abilityViewFactory,
            PurchasedAbilityViewFactory purchasedAbilityViewFactory
        )
        {
            _abilityViewFactory = abilityViewFactory ?? throw new ArgumentNullException(nameof(abilityViewFactory));
            _abilityFactory = abilityFactory ?? throw new ArgumentNullException(nameof(abilityFactory));
            _heroViewFactory = heroViewFactory ?? throw new ArgumentNullException(nameof(heroViewFactory));
            _heroFactory = heroFactory ?? throw new ArgumentNullException(nameof(heroFactory));


            int order = 0;
            LoadData(out var heroData, out var abilityDatas);
            CreateDomain(heroData, abilityDatas, out var hero, out var abilities);
            // CreatePresentation(hero, abilities, abilityShopView, out var heroView);
            
            var heroView = _heroViewFactory.Create(hero);
            abilityShopView.Add(heroView);


            foreach (var ability in abilities)
            {
                heroView.Add(purchasedAbilityViewFactory.Create(ability, hero));
                heroView.AddPurchased(_abilityViewFactory.Create(ability));
            }

            // PurchaseAbilities(heroData, abilities, hero, out abilities);
        }

        private void LoadData(out HeroData heroData, out AbilityData[] abilityDatas)
        {
            heroData = new HeroData()
            {
                Damage = 10,
                Level = 1,
                DamagePerLevel = 10,
                PurchasedAbilities = new string[] { "Ability 1", "Ability 2" }
            };

            abilityDatas = new AbilityData[]
            {
                new AbilityData()
                {
                    Name = "Ability 1",
                    Bonus = 10
                },
                new AbilityData()
                {
                    Name = "Ability 2",
                    Bonus = 20
                },
                new AbilityData()
                {
                    Name = "Ability 3",
                    Bonus = 30
                },
                new AbilityData()
                {
                    Name = "Ability 4",
                    Bonus = 60
                },
            };
        }

        private void CreateDomain(HeroData heroData, AbilityData[] abilityDatas, out Hero hero, out Ability[] abilities)
        {
            hero = _heroFactory.Create(heroData);

            int order = 0;
            
            abilities = abilityDatas
                .Select(data => _abilityFactory.Create(data, ++order))
                .ToArray();
        }

        private void PurchaseAbilities(HeroData heroData, Ability[] allAbilities, Hero hero, out Ability[] abilities)
        {
            heroData.PurchasedAbilities.ToList().ForEach(
                abilityName =>
                {
                    var ability = allAbilities.First(ability => ability.Name == abilityName);

                    hero.AddAbility(ability);
                }
            );

            abilities = allAbilities.Except(hero.Abilities).ToArray();
        }

        // private void CreatePresentation(
        //     Hero hero,
        //     Ability[] abilities,
        //     AbilityShopView abilityShopView,
        //     out IHeroView heroView
        // )
        // {
        //
        // }
    }
}