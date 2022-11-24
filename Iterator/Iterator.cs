// Provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation
namespace Iterator
{
    public class Person
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public Person(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }

    /// <summary>
    /// Iterator
    /// </summary>
    public interface IPeopleIterator
    {
        Person First();
        Person Next();
        bool IsDone { get; }
        Person CurrentItem { get; }
    }

    /// <summary>
    /// Aggregate
    /// </summary>
    public interface IPeopleCollection
    {
        IPeopleIterator CreateIterator();
    }

    /// <summary>
    /// ConcreteAggregate
    /// </summary>
    public class PeopleCollection : List<Person>, IPeopleCollection
    {
        public IPeopleIterator CreateIterator()
        {
            return new PeopleIterator(this);
        }
    }

    /// <summary>
    /// ConcreteIterator
    /// </summary>
    public class PeopleIterator : IPeopleIterator
    {
        private PeopleCollection _peopleCollection;
        private int _currentIndex;

        public PeopleIterator(PeopleCollection peopleCollection)
        {
            _peopleCollection = peopleCollection;
            _currentIndex = 0;
        }

        public Person First()
        {
            _currentIndex = 0;
            return _peopleCollection.OrderBy(x => x.Name).FirstOrDefault();
        }

        public Person Next()
        {
            _currentIndex++;
            if (!IsDone)
            {
                return _peopleCollection.OrderBy(x => x.Name).ToList()[_currentIndex];
            }

            return null;
        }

        public bool IsDone => _currentIndex >= _peopleCollection.Count;
        public Person CurrentItem => _peopleCollection.OrderBy(x => x.Name).ToList()[_currentIndex];
    }
}
