using Foundation;
using Newtonsoft.Json;
using System;
using System.IO;
using UIKit;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace SampleAppTable
{
    public partial class ViewController : UIViewController
    {
        ItemModel items;
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            RegisterNibs();
            ItemModel data = LoadDataFromJSON();
            if(data != null)
            {
                Console.WriteLine("JSON Deserialized" + data);


                data.CatetoriesMoviesList = new List<MovieCategoriesList>();
                foreach (var genres in data.genres)
                {
                    var movieList =  data.movies.FindAll(movieData => movieData.genres.Contains(genres));
                    data.CatetoriesMoviesList.Add(new MovieCategoriesList(genres, movieList));
                    //Console.WriteLine("got list" + movieList);

                }
                this.MovieTableView.Source = new MainTableDataSource(data);
            }
        }

        private void RegisterNibs()
        {
            MovieTableView.RegisterNibForCellReuse(MovieViewCell.Nib, "MovieViewCell");
            MovieTableView.RegisterNibForCellReuse(CollectionViewCell.Nib, "CollectionViewCell");

        }
        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        private ItemModel LoadDataFromJSON()
        {
            string mainBundlePath = NSBundle.MainBundle.BundlePath;


            // Specify the folder and file name within the main bundle
            string dataFolderPath = Path.Combine(mainBundlePath, "Data");
            string jsonFileName = "MovieListJson.json";
            string jsonFilePath = Path.Combine(dataFolderPath, jsonFileName);

            // Check if the file exists
            if (File.Exists(jsonFilePath))
            {
                // Read and deserialize JSON

                using (StreamReader reader = new StreamReader(jsonFilePath))
                {
                    string json = reader.ReadToEnd();
                    return  JsonConvert.DeserializeObject<ItemModel>(json);
                }
               
            }
            else
            {
                // Handle the case where the file is not found
                return null;
            }
        }
    }
}
