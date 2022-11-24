// Uses sharing to support large numbers of fine-grained objects efficiently.
// It does that by sharing parts of the state between these objects instead of keeping
// all that state in all of the objects
namespace Flyweight
{
    /// <summary>
    /// Flyweight
    /// </summary>
    public interface ICharacter
    {
        void Draw(string fontFamily, int fontSize);
    }

    /// <summary>
    /// ConcreteFlyweight
    /// </summary>
    public class CharacterA : ICharacter
    {
        private char _char = 'A';
        private string _fontFamily;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;
            Console.WriteLine($"Drawing {_char}, {_fontFamily} {_fontSize}");
        }
    }

    /// <summary>
    /// ConcreteFlyweight
    /// </summary>
    public class CharacterB : ICharacter
    {
        private char _char = 'B';
        private string _fontFamily;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;
            Console.WriteLine($"Drawing {_char}, {_fontFamily} {_fontSize}");
        }
    }

    /// <summary>
    /// UnsharedConcreteFlyweight
    /// </summary>
    public class Paragraph : ICharacter
    {
        private int _location;
        private IList<ICharacter> _characters;

        public Paragraph(int location, IList<ICharacter> characters)
        {
            _location = location;
            _characters = characters;
        }

        public void Draw(string fontFamily, int fontSize)
        {
            Console.WriteLine($"Drawing in paragraph at location {_location}");
            foreach (var character in _characters)
            {
                character.Draw(fontFamily, fontSize);
            }
        }
    }

    /// <summary>
    /// FlyweightFactory
    /// </summary>
    public class CharacterFactory
    {
        private readonly IDictionary<char, ICharacter> _characters = new Dictionary<char, ICharacter>();

        public ICharacter? GetCharacter(char character)
        {
            if (!_characters.ContainsKey(character))
            {
                switch (character)
                {
                    case 'A':
                    case 'a': 
                        _characters.Add(character, new CharacterA());
                        break;
                    case 'B':
                    case 'b':
                        _characters.Add(character, new CharacterB());
                        break;
                }
            }
            else
            {
                Console.WriteLine("character reuse!");
            }

            return _characters[character];
        }

        public ICharacter CreateParagraph(IList<ICharacter> characters, int location)
        {
            return new Paragraph(location, characters);
        }
    }
}
