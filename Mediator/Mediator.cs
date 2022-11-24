// Defines an object that encapsulates how a set of objects interact. 
// Mediator promotes loose coupling by keeping objects from referring to each other explicitly, 
// and it lets you vary their interaction independently
namespace Mediator
{
    /// <summary>
    /// Mediator
    /// </summary>
    public interface IChatRoom
    {
        public void Register(TeamMember teamMember);
        public void SendMessage(string from, string message);
        public void SendMessage(string from, string to, string message);
        void SendTo<T>(string from, string message) where T : TeamMember;
    }

    /// <summary>
    /// Collegue
    /// </summary>
    public abstract class TeamMember
    {
        private IChatRoom? _chatRoom;

        public string Name { get; set; }

        protected TeamMember(string name)
        {
            Name = name;
        }

        internal void SetChatRoom(IChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }

        public void Send(string message)
        {
            _chatRoom?.SendMessage(Name, message);
        }

        public void Send(string to, string message)
        {
            _chatRoom?.SendMessage(Name, to, message);
        }

        public void SendTo<T>(string message) where T : TeamMember
        {
            _chatRoom?.SendTo<T>(Name, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"Message from {from} to {Name}: {message}");
        }
    }

    /// <summary>
    /// ConcreteCollegue
    /// </summary>
    public class Lawyer : TeamMember
    {
        public Lawyer(string name) : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(Lawyer)} {Name} received: ");
            base.Receive(from, message);
        }
    }

    /// <summary>
    /// ConcreteCollegue
    /// </summary>
    public class AccountManager : TeamMember
    {
        public AccountManager(string name) : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(AccountManager)} {Name} received: ");
            base.Receive(from, message);
        }
    }

    public class TeamChatRoom : IChatRoom
    {
        private Dictionary<string, TeamMember> _teamMembers = new();

        public void Register(TeamMember teamMember)
        {
            teamMember.SetChatRoom(this);
            if (!_teamMembers.ContainsKey(teamMember.Name))
            {
                _teamMembers.Add(teamMember.Name, teamMember);
            }
        }

        public void SendMessage(string from, string message)
        {
            foreach (var teamMember in _teamMembers.Values)
            {
                teamMember.Receive(from, message);
            }
        }

        public void SendMessage(string from, string to, string message)
        {
            _teamMembers[to].Receive(from, message);
        }

        public void SendTo<T>(string from, string message) where T : TeamMember
        {
            foreach (var teamMember in _teamMembers.Values.OfType<T>())
            {
                teamMember.Receive(from, message);
            }
        }
    }
}
