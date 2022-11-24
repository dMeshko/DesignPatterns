// Specifies the kind of objects to create using a prototypical instance,
// and creates new objects by copying this prototype

using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Prototype
{
    /// <summary>
    /// Prototype
    /// </summary>
    public abstract class Person
    {
        public abstract string Name { get; set; }

        public abstract Person Clone(bool deepClone = false);
    }

    /// <summary>
    /// ConcretePrototype
    /// </summary>
    public class Manager : Person
    {
        public Manager(string name)
        {
            Name = name;
        }

        public sealed override string Name { get; set; }

        public override Person Clone(bool deepClone = false)
        {
            if (!deepClone)
            {
                return (Person)MemberwiseClone();
            }

            var json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Manager>(json)!;
        }
    }

    /// <summary>
    /// ConcretePrototype
    /// </summary>
    public class Employee : Person
    {
        public Employee(string name, Manager manager)
        {
            Name = name;
            Manager = manager;
        }

        public sealed override string Name { get; set; }
        public Manager Manager { get; set; }

        public override Person Clone(bool deepClone = false)
        {
            if (!deepClone)
            {
                return (Person)MemberwiseClone();
            }

            var json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Employee>(json)!;
        }
    }
}
