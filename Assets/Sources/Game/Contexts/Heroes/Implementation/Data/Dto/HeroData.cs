namespace Sources.Game.Contexts.Heroes.Implementation.Data.Dto
{
    public class HeroData
    {
        public int Level { get; set; }
        public int Damage { get; set; }
        public int DamagePerLevel { get; set; }
        
        public string[] PurchasedAbilities { get; set; }
    }
}