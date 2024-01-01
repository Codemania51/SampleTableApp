using System;

using Foundation;
using UIKit;

namespace SampleAppTable
{
	public partial class MovieViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("MovieViewCell");
		public static readonly UINib Nib;

		static MovieViewCell ()
		{
			Nib = UINib.FromName ("MovieViewCell", NSBundle.MainBundle);
		}

		protected MovieViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
