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
	[Register ("MovieViewCell")]
	partial class MovieViewCell
	{
		[Outlet]
		public UIKit.UILabel Description { get; private set; }

		[Outlet]
		public UIKit.UIImageView MovieImage { get; set; }

		[Outlet]
		public UIKit.UILabel Title { get; private set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Description != null) {
				Description.Dispose ();
				Description = null;
			}

			if (Title != null) {
				Title.Dispose ();
				Title = null;
			}

			if (MovieImage != null) {
				MovieImage.Dispose ();
				MovieImage = null;
			}
		}
	}
}
