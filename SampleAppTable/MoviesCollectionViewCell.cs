using System;

using Foundation;
using UIKit;

namespace SampleAppTable
{
	public partial class MoviesCollectionViewCell : UICollectionViewCell
	{
		public static readonly NSString Key = new NSString ("MoviesCollectionViewCell");
		public static readonly UINib Nib;

		static MoviesCollectionViewCell ()
		{
			Nib = UINib.FromName ("MoviesCollectionViewCell", NSBundle.MainBundle);
		}

		protected MoviesCollectionViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
