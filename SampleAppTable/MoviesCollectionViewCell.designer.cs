// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SampleAppTable
{
	[Register ("MoviesCollectionViewCell")]
	partial class MoviesCollectionViewCell
	{
		[Outlet]
		public UIKit.UIImageView Image { get; set; }

		[Outlet]
		public UIKit.UILabel Title { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Title != null) {
				Title.Dispose ();
				Title = null;
			}

			if (Image != null) {
				Image.Dispose ();
				Image = null;
			}
		}
	}
}
