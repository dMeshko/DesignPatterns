// Composes objects into tree structures to represent part-whole hierarchies. 
// This pattern lets clients treat individual objects and compositions of objects uniformly
namespace Composite
{
    /// <summary>
    /// Component
    /// </summary>
    public abstract class FileSystemItem
    {
        public string Name { get; set; }

        public abstract long GetSize();

        protected FileSystemItem(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    /// Leaf
    /// </summary>
    public class File : FileSystemItem
    {
        private readonly long _size;

        public File(string name, long size) : base(name)
        {
            _size = size;
        }

        public override long GetSize()
        {
            return _size;
        }
    }

    public class Directory : FileSystemItem
    {
        private readonly IList<FileSystemItem> _files;
        private readonly long _size;

        public Directory(string name, long size) : base(name)
        {
            _size = size;
            _files = new List<FileSystemItem>();
        }

        public override long GetSize()
        {
            var treeSize = _size;

            foreach (var fileSystemItem in _files)
            {
                treeSize += fileSystemItem.GetSize();
            }

            return treeSize;
        }

        public void Add(FileSystemItem file)
        {
            if (!_files.Contains(file))
            {
                _files.Add(file);
            }
        }

        public void Remove(FileSystemItem file)
        {
            if (_files.Contains(file))
            {
                _files.Remove(file);
            }
        }
    }
}
