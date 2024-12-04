namespace Tp.Character.IMana
{

    public interface IMana
    {
        int Mana { get; set; }
        int MaxMana { get; set; }
        
        void DrinkMana();
        void UseMana(int mana);

    }
}