using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace TreeTestApp
{
    internal sealed class MainWindowViewModel : ViewModelBase
    {
        private Node _selectedNode;

        public MainWindowViewModel()
        {
            GenerateData();
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete);
            SaveCommand = new RelayCommand(Save);
        }


        public ObservableCollection<Node> TreeRoot { get; set; } = new ObservableCollection<Node>();

        public Node SelectedNode
        {
            get => _selectedNode;
            set => Set(() => SelectedNode, ref _selectedNode, value);
        }

        public RelayCommand AddCommand { get; set; }

        public RelayCommand DeleteCommand { get; set; }

        public RelayCommand SaveCommand { get; set; }


        private void Add()
        {
            var newNode = new Node()
            {
                Name = "NewNode"
            };
            if (SelectedNode != null)
            {
                SelectedNode.Add(newNode);
            }
            else
            {
                TreeRoot.Add(newNode);
            }

            SelectedNode = newNode;
        }

        private void Delete()
        {
            if (SelectedNode?.Parent == null)
            {
                TreeRoot.Remove(SelectedNode);
            }
            else
            {
                SelectedNode?.Parent?.Remove(SelectedNode);
            }
        }

        private static void Save()
        {
        }

        private void GenerateData()
        {
            var node1 = new Node
            {
                Name = "name1",
                Description = "desc1"
            };
            TreeRoot.Add(node1);

            var node2 = new Node
            {
                Name = "name2",
                Description = "desc2"
            };
            TreeRoot.Add(node2);

            var node11 = new Node
            {
                Name = "name11",
                Description = "desc11"
            };
            node1.Add(node11);

            var node12 = new Node
            {
                Name = "name12",
                Description = "desc12"
            };
            node1.Add(node12);
        }
    }
}