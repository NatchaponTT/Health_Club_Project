using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pro02.Services
{
    public class ObjectGenerator
    {
        // Collection for movie in app
        public ObservableCollection<Models.Movie> Movies { get; set; }
        public ObservableCollection<Models.Movie> MovieAll { get; set; }
        public ObservableCollection<String> MovieTypes { get; set; }

        // property youtube movie code
        public List<string> MovieUrl { get; set; }

        // URL for get youtebe info.
        string youtubeInfo =
            @"https://www.youtube.com/oembed?format=json&url=https://www.youtube.com/watch?v=";


        // Contructor of class ObjectGenerator
        // Run at create object of ObjectGenerator
        public ObjectGenerator()
        {
            // create object => Allocate memorry => keyword new
            Movies = new ObservableCollection<Models.Movie>();
            MovieAll = new ObservableCollection<Models.Movie>();
            MovieTypes = new ObservableCollection<string>();
            MovieUrl = new List<string>();

            // Add youtube movie code to list
            MovieUrl.Add("4H2h68ABVwo:Upper body");
            MovieUrl.Add("hb-ieFfdhpg:Upper body");
            MovieUrl.Add("Yav1ktiE6A8&t=1s:Shoulder part");
            MovieUrl.Add("1saaW84yRIw:Shoulder part");
            MovieUrl.Add("HuVDb59oNkc&t=1s:Shoulder part");
            MovieUrl.Add("M87Uu-uOIqU&t=1s:Back part");
            MovieUrl.Add("cVR_Zi0tahw:Back part");
            MovieUrl.Add("6DBRuCRoPEQ&t=1s:Arm");
            MovieUrl.Add("OLSzzGYVmkI:Arm");
            MovieUrl.Add("oK5KL0xHeZs:Hip");
            MovieUrl.Add("_GFV8fguPKI:Hip");
            MovieUrl.Add("fEM2r-I_i5M:Hip");
            MovieUrl.Add("9mNXLSXcvuM:Leg");
            MovieUrl.Add("IaPhCX09WJo:Leg");
            MovieUrl.Add("HrK7C7q35t8:Leg");
        }

        // Load movie from youtube
        public void LoadMovie()
        {
            // Remove all object in collection Movies
            Movies.Clear();

            // loop for get youtube info from movie code
            foreach (var rowx in MovieUrl)
            {
                // sub string with function Split
                string[] arr = rowx.Split(':'); // Ex. rowx = Zco1nhqaQRQ:Mystery
                LoadFromYoutube(arr[0], arr[1]); // Ex. arr[0] = Zco1nhqaQRQ // arr[1] = Mystery
            }
        }

        // Load youtube info from internet
        // *** Require internet connection
        public async void LoadFromYoutube(string pMovieCode, string pMovieType)
        {
            try
            {
                // Create http client for connect to internet
                var client = new HttpClient();
                // define url youtube for get info
                var _url = youtubeInfo + pMovieCode;
                // Send request to youtube by http get
                // and await for reponse from youtube
                var reponse = await client.GetAsync(_url);
                // If the response status code indicates success, parse the JSON data
                if (reponse.IsSuccessStatusCode)
                {
                    // read infomation to json format
                    var json = await reponse.Content.ReadAsStringAsync();
                    // convert json string to object of movie class
                    var youtubeInfo = JsonSerializer.Deserialize<Models.Movie>(json);
                    // recheck data
                    if (youtubeInfo != null)
                    {
                        // dafine movie code to object
                        youtubeInfo.movieCode = pMovieCode;
                        youtubeInfo.movieType = pMovieType;
                        // add movie info to collection
                        Movies.Add(youtubeInfo);
                        MovieAll.Add(youtubeInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                // Error detected : scope issue on a try catch statement
                string msg = ex.InnerException != null ? ex.InnerException.Message :
                    ex.Message;
                // Alert error message to main display
                await App.Current.MainPage.DisplayAlert("Exception", msg, "OK");
            }
        }
        public void LoadMovieType()
        {
            MovieTypes.Add(":: All ::");
            MovieTypes.Add("Leg");
            MovieTypes.Add("Hip");
            MovieTypes.Add("Arm");
            MovieTypes.Add("Back part");
            MovieTypes.Add("Shoulder part");
            MovieTypes.Add("Upper body");
        }
    }
}
