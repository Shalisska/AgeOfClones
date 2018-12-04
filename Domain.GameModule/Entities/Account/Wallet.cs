namespace Domain.GameModule.Entities.Account
{
    public abstract class Wallet
    {
        public decimal Value { get; set; }

        public int AccountId { get; set; }
        public int CurrencyId { get; set; }

        public virtual void Increase(decimal value)
        {
            Value += value;
        }

        public virtual void Decrease(decimal value)
        {
            Value -= value;
        }
    }
}
