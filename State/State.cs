// Allows an object to alter its behaviour when its internal state changes.
// This object will appear to change its class
namespace State
{
    /// <summary>
    /// State
    /// </summary>
    public interface IBankAccountState
    {
        public BankAccount BankAccount { get; protected set; }
        public decimal Balance { get; protected set; }
        public void Deposit(decimal amount);
        public void Withdraw(decimal amount);
    }

    /// <summary>
    /// ConcreteState
    /// </summary>
    public class RegularState : IBankAccountState
    {
        private BankAccount _bankAccount;
        private decimal _balance;

        public RegularState(BankAccount bankAccount, decimal balance)
        {
            _bankAccount = bankAccount;
            _balance = balance;
        }

        BankAccount IBankAccountState.BankAccount
        {
            get => _bankAccount;
            set => _bankAccount = value;
        }

        decimal IBankAccountState.Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()} depositing {amount}");
            _balance += amount;
            if (_balance >= 1000)
            {
                _bankAccount.State = new GoldState(_bankAccount, _balance);
            }
        }

        public void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()} withdrawing {amount} from {_balance}");
            _balance -= amount;
            if (_balance < 0)
            {
                _bankAccount.State = new OverdrawnState(_bankAccount, _balance);
            }
        }
    }

    /// <summary>
    /// ConcreteState
    /// </summary>
    public class OverdrawnState : IBankAccountState
    {
        private BankAccount _bankAccount;
        private decimal _balance;

        public OverdrawnState(BankAccount bankAccount, decimal balance)
        {
            _bankAccount = bankAccount;
            _balance = balance;
        }

        BankAccount IBankAccountState.BankAccount
        {
            get => _bankAccount;
            set => _bankAccount = value;
        }

        decimal IBankAccountState.Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()} depositing {amount}");
            _balance += amount;
            if (_balance >= 0)
            {
                _bankAccount.State = new RegularState(_bankAccount, _balance);
            }
        }

        public void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()} can't withdraw {amount} from {_balance}");
        }
    }

    /// <summary>
    /// ConcreteState
    /// </summary>
    public class GoldState : IBankAccountState
    {
        private BankAccount _bankAccount;
        private decimal _balance;

        public GoldState(BankAccount bankAccount, decimal balance)
        {
            _bankAccount = bankAccount;
            _balance = balance;
        }

        BankAccount IBankAccountState.BankAccount
        {
            get => _bankAccount;
            set => _bankAccount = value;
        }

        decimal IBankAccountState.Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()} depositing {amount} + 10% bonus: {amount/10}");
            _balance += amount + amount / 10;
        }

        public void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()} withdrawing {amount} from {_balance}");
            _balance -= amount;
            if (_balance is < 1000 and >= 0)
            {
                _bankAccount.State = new RegularState(_bankAccount, _balance);
            }
            else if (_balance < 0)
            {
                _bankAccount.State = new OverdrawnState(_bankAccount, _balance);
            }
        }
    }

    /// <summary>
    /// Context
    /// </summary>
    public class BankAccount
    {
        public IBankAccountState State { get; set; }
        public decimal Balance => State.Balance;

        public BankAccount()
        {
            State = new RegularState(this, 200);
        }

        public void Deposit(decimal amount)
        {
            Console.WriteLine($"Current balance: {Balance}");
            State.Deposit(amount);
            Console.WriteLine("----------------------------");
        }

        public void Withdraw(decimal amount)
        {
            Console.WriteLine($"Current balance: {Balance}");
            State.Withdraw(amount);
            Console.WriteLine("----------------------------");
        }
    }
}
