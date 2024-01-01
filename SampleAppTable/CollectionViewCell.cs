using System;

using Foundation;
using UIKit;

namespace SampleAppTable
{
	public partial class CollectionViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("CollectionViewCell");
		public static readonly UINib Nib;

		static CollectionViewCell ()
		{
			Nib = UINib.FromName ("CollectionViewCell", NSBundle.MainBundle);
		}

		protected CollectionViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
