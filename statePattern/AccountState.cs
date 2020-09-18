using System;

namespace statePattern
{
     public interface IAccountState
    {
        IAccountState Deposit(Action addToBalance);
        IAccountState Widthraw(Action subtractFromBalance);
        IAccountState HolderVerified();
        IAccountState Freeze();
        IAccountState Close();
    }

    public class NotVerfied : IAccountState
    {
        private Action onUnfreeze { get; }

        public NotVerfied(Action onUnfreeze)
        {
            this.onUnfreeze = onUnfreeze;
        }

        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active(onUnfreeze);

        public IAccountState Widthraw(Action subtractFromBalance) => this;
    }

    public class Active : IAccountState
    {

        private Action onUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            this.onUnfreeze = onUnfreeze;
        }

        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Freeze() => new Frozen(onUnfreeze);

        public IAccountState HolderVerified() => this;

        public IAccountState Widthraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }
    }

    public class Frozen : IAccountState
    {

        private Action onUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            this.onUnfreeze = onUnfreeze;
        }

        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance)
        {
            onUnfreeze();
            addToBalance();
            return new Active(onUnfreeze);
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Widthraw(Action subtractFromBalance)
        {
            onUnfreeze();
            subtractFromBalance();
            return new Active(onUnfreeze);
        }
    }

    public class Closed : IAccountState
    {
        public IAccountState Close() => this;

        public IAccountState Deposit(Action addToBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Widthraw(Action subtractFromBalance) => this;
    }
}
