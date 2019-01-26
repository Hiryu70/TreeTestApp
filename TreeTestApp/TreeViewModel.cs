using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace TreeTestApp
{
    class TreeViewModel : ViewModelBase
    {
        private object _selectedItem = null;




        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set => Set(() => IsSelected, ref _isSelected, value);

        }
    }
}
