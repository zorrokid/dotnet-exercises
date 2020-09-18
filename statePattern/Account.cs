using System;

namespace statePattern
{
    public class Account
    {
        public decimal Balance { get; private set; }

        private IAccountState state { get; set; }

        public Account(Action onUnfreeze)
        {
            state = new NotVerfied(onUnfreeze);
        }

        public void Deposit(decimal amount)
        {
            state = state.Deposit(() => { Balance += amount; });
        }

        public void Widthraw(decimal amount)
        {
            state = state.Widthraw(() => { Balance -= amount; });
        }

        public void HolderVerified()
        {
            state = state.HolderVerified();
        }

        public void Freeze()
        {
            state = state.Freeze();
        }

        public void Close()
        {
            state = state.Close();
        }
    }
}