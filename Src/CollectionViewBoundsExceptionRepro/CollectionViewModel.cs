using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CollectionViewBoundsExceptionRepro
{
    class CollectionViewModel : INotifyPropertyChanged
    {
        bool _isRefreshing;
        IList<int>? _scoreCollectionList;

        public CollectionViewModel()
        {
            PopulateCollectionCommand = new Command(ExecuteRefreshCommand);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand PopulateCollectionCommand { get; }

        public IList<int> ScoreCollectionList
        {
            get => _scoreCollectionList ??= Enumerable.Empty<int>().ToList();
            set
            {
                _scoreCollectionList = value;
                OnPropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (IsRefreshing != value)
                {
                    _isRefreshing = value;
                    OnPropertyChanged();
                }
            }
        }

        void ExecuteRefreshCommand() => ScoreCollectionList = Enumerable.Range(0, 100).ToList();

        void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
