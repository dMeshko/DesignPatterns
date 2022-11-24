// Ensures a class has only oen instance, and to provide a global point of access to it
// (private constructor - can not be created in any other way)
namespace Singleton
{
    public class Logger
    {
        private static readonly Lazy<Logger> _instance = new(() => new Logger());

        protected Logger() { }

        /// <summary>
        /// Instance
        /// </summary>
        public static Logger Instance => _instance.Value;

        /// <summary>
        /// SingletonOperation
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            Console.WriteLine($"Message to log: {message}");
        } 
    }
}
