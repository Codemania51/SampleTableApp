using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using FFImageLoading;
using CoreGraphics;

namespace SampleAppTable
{
    public class CollectionViewDataSource : UICollectionViewDataSource
    {
        private List<Movie> movieItems;
        private int RowCount = 0;


        public CollectionViewDataSource(List<Movie> movieItems)
        {
            this.movieItems = movieItems;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {

            var cell = (MoviesCollectionViewCell)collectionView.DequeueReusableCell("MoviesCollectionViewCell", indexPath);
         
            
            if (RowCount < movieItems.Count) { 
            var item = movieItems[RowCount];
            RowCount++;

            ImageService.Instance.LoadUrl(item.posterUrl)
               .Into(cell.Image);
            cell.Title.Text = item.title;
            }
            return cell; 
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 5;
        }


        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 7;
        }
    }


    class TwoDScrollingLayout : UICollectionViewLayout
    {
        private CGSize contentSize = CGSize.Empty;
        private NSMutableDictionary<NSIndexPath, UICollectionViewLayoutAttributes> layoutAttributes = new NSMutableDictionary<NSIndexPath, UICollectionViewLayoutAttributes>();

        public override void PrepareLayout()
        {
            base.PrepareLayout();

            if (CollectionView == null)
                return;

            layoutAttributes = new NSMutableDictionary<NSIndexPath, UICollectionViewLayoutAttributes>();
            nfloat xOffset = 0;
            nfloat yOffset = 0;

            for (nint section = 0; section < CollectionView.NumberOfSections(); section++)
            {
                xOffset = 0;

                for (nint item = 0; item < CollectionView.NumberOfItemsInSection(section); item++)
                {
                    var indexPath = NSIndexPath.FromItemSection(item, section);
                    var attributes = UICollectionViewLayoutAttributes.CreateForCell(indexPath);
                    var itemSize = new CGSize(200, 100); // Adjust the size as needed

                    attributes.Frame = new CGRect(xOffset, yOffset, itemSize.Width, itemSize.Height);
                    layoutAttributes.Add(indexPath, attributes);

                    xOffset += itemSize.Width;
                }

                yOffset += 100; // Adjust the height between rows
            }

            contentSize = new CGSize(xOffset, yOffset);
        }
        public override void FinalizeCollectionViewUpdates()
        {
            base.FinalizeCollectionViewUpdates();
        }
        public override CGSize CollectionViewContentSize => contentSize;

        public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
        {
            var attributes = new List<UICollectionViewLayoutAttributes>();

            foreach (var attribute in layoutAttributes.Values)
            {
                if (rect.IntersectsWith(attribute.Frame))
                {
                    attributes.Add(attribute);
                }
            }

            return attributes.ToArray();
        }

        public override UICollectionViewLayoutAttributes LayoutAttributesForItem(NSIndexPath indexPath)
        {
            return layoutAttributes[indexPath];
        }
        public override bool ShouldInvalidateLayoutForBoundsChange(CGRect newBounds)
        {
            return true;
        }
    }
}

