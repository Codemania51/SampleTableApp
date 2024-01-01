using System;
using FFImageLoading;
using FFImageLoading.Work;
using Foundation;
using UIKit;

namespace SampleAppTable
{
	public class MainTableDataSource : UITableViewSource
	{
        ItemModel items;
		public MainTableDataSource(ItemModel data)
		{
            this.items = data;
		}

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //var cell = (MovieViewCell)tableView.DequeueReusableCell("MovieViewCell", indexPath);
            var movieItem = items.CatetoriesMoviesList[indexPath.Section].movieList;
            //cell.Title.Text = movieItem.title;
            //cell.Description.Text = movieItem.plot;

            //ImageService.Instance.LoadUrl(movieItem.posterUrl)
            //.Into(cell.MovieImage);
            var cell = (CollectionViewCell)tableView.DequeueReusableCell("CollectionViewCell", indexPath);
            cell.CollectionView.RegisterNibForCell(MoviesCollectionViewCell.Nib, "MoviesCollectionViewCell");
            cell.CollectionView.DataSource = new CollectionViewDataSource(movieItem);
            cell.CollectionView.CollectionViewLayout = new TwoDScrollingLayout();
            return cell;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return items.CatetoriesMoviesList[Convert.ToInt32(section)].genres;
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return 1;//items.CatetoriesMoviesList[Convert.ToInt32(section)].movieList.Count; 
        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            // Set the desired height for the section header
            return 50.0f; // Adjust as needed
        }
        public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
        {
            UITableViewHeaderFooterView header = headerView as UITableViewHeaderFooterView;
            if (header != null)
            {
                // Set the background color of the section header
                header.ContentView.BackgroundColor = UIColor.FromRGB(229, 228, 226); // Replace with your desired color
            }

        }
    
    

        public override nint NumberOfSections(UITableView tableView)
        {
            return items.CatetoriesMoviesList.Count;
        }
    }
}

