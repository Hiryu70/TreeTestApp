using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace TreeTestApp
{
    internal sealed class MainWindowViewModel : ViewModelBase
    {
        private Node _selectedNode;
        private bool _isSelected;

        public MainWindowViewModel()
        {
            GenerateData();
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete);
            SaveCommand = new RelayCommand(Save);
        }


        public ObservableCollection<Node> TreeRoot { get; set; }

        public RelayCommand AddCommand { get; set; }

        public RelayCommand DeleteCommand { get; set; }

        public RelayCommand SaveCommand { get; set; }


        public Node SelectedNode
        {
            get => _selectedNode;
            set => Set(() => SelectedNode, ref _selectedNode, value);
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    Set(() => IsSelected, ref _isSelected, value);
                    if (value)
                    {
                        SelectedNode = 
                    }
                }

                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                    if (_isSelected)
                    {
                        SelectedItem = this;
                    }
                }
            }
        }

        private void Add()
        {
            var newNode = new Node();
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
            SelectedNode?.Parent.Remove(SelectedNode);
        }

        private void Save()
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