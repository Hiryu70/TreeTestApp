using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace TreeTestApp
{
    internal sealed class Node : ViewModelBase
    {
        private string _name;
        private string _description;

        public string Name
        {
            get => _name;
            set => Set(() => Name, ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => Set(() => Description, ref _description, value);
        }

        public Node Parent { get; private set; }

        public ObservableCollection<Node> Children { get; set; } = new ObservableCollection<Node>();

        public void Add(Node node)
        {
            node.Parent = this;
            Children.Add(node);
        }

        public void Remove(Node node)
        {
            node.Parent = null;
            Children.Remove(node);
        }
    }
}