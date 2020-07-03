using Xamarin.Forms;

namespace CollectionViewBoundsExceptionRepro
{
    class BlankPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(Parent is TabbedPage tabbedPage
                && tabbedPage.Children[1] is CollectionViewPage collectionViewPage
                && collectionViewPage.Content is RefreshView refreshView)
            {
                refreshView.IsRefreshing = true;
            }
        }
    }
}
