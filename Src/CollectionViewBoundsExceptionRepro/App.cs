using Xamarin.Forms;

namespace CollectionViewBoundsExceptionRepro
{
    public class App : Application
    {
        public App()
        {
            Device.SetFlags(new[] { "Markup_Experimental" });
            MainPage = new TabbedPage
            {
                Children =
                {
                    new BlankPage(),
                    new CollectionViewPage()
                }
            };
        }
    }
}
