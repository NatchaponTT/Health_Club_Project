namespace Pro02.Views;

public partial class ServicePage : ContentPage
{
    Services.ObjectGenerator gen
        = new Services.ObjectGenerator();
    public ServicePage()
	{

        InitializeComponent();

        LoadMovieToPage();
    }

    private void LoadMovieToPage()
    {
        gen.LoadMovie();
        gen.LoadMovieType();

        this.BindingContext = gen;
    }

    async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Convert Row to Movie
        Models.Movie movie = (Models.Movie)e.CurrentSelection[0];
        try
        {
            // To use the Launcher fuctionality
            // OpenAsync method and pass in a String or Uri representing
            // the app to open.
            await Launcher.Default.OpenAsync("https://www.youtube.com/watch?v=" + movie.movieCode);
        }
        catch (Exception ex)
        {
            await DisplayAlert("No Support", ex.Message, "OK");
        }
    }

    void pickerTypeMovie_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Check: User selected type from picker
        if (pickerTypeMovie.SelectedItem != null)
        {
            // convert type name from object to string
            string _typeName = pickerTypeMovie.SelectedItem.ToString();

            // cleate temp list for type selected
            gen.Movies.Clear();

            // create temp list for type selected
            List<Models.Movie> result = null;

            // show all movies
            if (_typeName == ":: All ::")
            {
                // MovieAll = All movie information
                result = gen.MovieAll.ToList();
            }
            else // show type selected
            {
                // LINQ & Lambda expression
                //  where >> Select only movies from the type selected
                // OrderBy [Sort No.1] >> Arrange title name in order from lowest to highest
                // ThenBy [Sort No.2] >>  Arrange movie author_name in order from lowest to
                // Tolist >> Convert result from this statment to List<Models.Movie>
                result = gen.MovieAll
                    .Where(x => x.movieType == _typeName)
                    .OrderBy(x => x.title)
                    .ThenBy(x => x.author_name)
                    .ToList();
            }

            // Loop : Put the results from above into Movies
            foreach (var rowx in result)
            {
                gen.Movies.Add(rowx);
            }
        }
    }
}