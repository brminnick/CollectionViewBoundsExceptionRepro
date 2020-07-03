using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace CollectionViewBoundsExceptionRepro
{
    class CollectionViewPage : ContentPage
    {
        public CollectionViewPage()
        {
            BindingContext = new CollectionViewModel();

            Content = new RefreshView
            {
                Content = new CollectionView
                {
                    ItemTemplate = new GreenBoxDataTemplate(),
                    Footer = new BoxView { BackgroundColor = Color.Red, HeightRequest = 53 }
                }.Bind(CollectionView.ItemsSourceProperty, nameof(CollectionViewModel.ScoreCollectionList))

            }.Bind(RefreshView.CommandProperty, nameof(CollectionViewModel.PopulateCollectionCommand))
             .Bind(RefreshView.IsRefreshingProperty, nameof(CollectionViewModel.IsRefreshing));
        }

        class GreenBoxDataTemplate : DataTemplate
        {
            public GreenBoxDataTemplate() : base(CreateTemplate)
            {

            }

            static View CreateTemplate() => new StackLayout
            {
                Children =
                {
                    new BoxView
                    {
                        BackgroundColor = Color.Black,
                        HeightRequest = 5
                    },
                    new BoxView
                    {
                        BackgroundColor = Color.Green,
                        HeightRequest = 50
                    },
                    new BoxView
                    {
                        BackgroundColor = Color.Black,
                        HeightRequest = 5
                    }
                }
            };
        }
    }

}
