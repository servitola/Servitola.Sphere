/****************************** Module Header ******************************\
 * Module Name:  SelectedRegion.cs
 * Project:      CSWindowsStoreAppCropBitmap
 * Copyright (c) Microsoft Corporation.
 * 
 * This class represents the selected region. It implements the INotifyPropertyChanged
 * interface and can be bound to the Xaml element
 *  
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using Windows.UI.Xaml.Media.Animation;

namespace XamlBrewer.Uwp.Controls.Helpers
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using Windows.Foundation;

    public class SelectedRegion : INotifyPropertyChanged
    {
        //private const string TopLeftCornerCanvasLeftPropertyName = "LeftCornerCanvas";
        //private const string TopLeftCornerCanvasTopPropertyName = "TopCornerCanvas";
        //private const string BottomRightCornerCanvasLeftPropertyName = "BottomCornerCanvas";
        //private const string BottomRightCornerCanvasTopPropertyName = "rightCornerCanvas";
        //private const string OutterRectPropertyName = "OuterRect";
        //private const string SelectedRectPropertyName = "SelectedRect";

        //public const string TopLeftCornerName = "TopLeftCorner";
        //public const string TopRightCornerName = "TopRightCorner";
        //public const string BottomLeftCornerName = "BottomLeftCorner";
        //public const string BottomRightCornerName = "BottomRightCorner";

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The minimum size of the selected region
        /// </summary>
        public double MinSelectRegionSize { get; set; }

        private double _leftCornerCanvas;

        /// <summary>
        /// The Canvas.Left property of the TopLeft corner.
        /// </summary>
        public double LeftCornerCanvas
        {
            get { return _leftCornerCanvas; }
            protected set
            {
                if (_leftCornerCanvas != value)
                {
                    _leftCornerCanvas = value;

                    OnPropertyChanged(nameof(LeftCornerCanvas));
                }
            }
        }

        private double _topCornerCanvas;
        public double TopCornerCanvas
        {
            get { return _topCornerCanvas; }
            protected set
            {
                if (_topCornerCanvas != value)
                {
                    _topCornerCanvas = value;
                    OnPropertyChanged(nameof(TopCornerCanvas));
                }
            }
        }

        private double _bottomCornerCanvas;
        public double BottomCornerCanvas
        {
            get { return _bottomCornerCanvas; }
            protected set
            {
                if (_bottomCornerCanvas != value)
                {
                    _bottomCornerCanvas = value;

                    OnPropertyChanged(nameof(BottomCornerCanvas));
                }
            }
        }

        private double _rightCornerCanvas;
        public double RightCornerCanvas
        {
            get { return _rightCornerCanvas; }
            protected set
            {
                if (_rightCornerCanvas != value)
                {
                    _rightCornerCanvas = value;
                    this.OnPropertyChanged(nameof(RightCornerCanvas));
                }
            }
        }

	    private Point _outerCenter;
		public Point OuterCenter
		{
		    get { return _outerCenter; }
		    set
		    {
				_outerCenter = value;
				OnPropertyChanged(nameof(OuterCenter));
		    }
	    }

		private Point _selectedCenter;
	    public Point SelectedCenter
		{
			get { return _selectedCenter; }
			set
			{
				_selectedCenter = value;
				OnPropertyChanged(nameof(SelectedCenter));
			}
		}

		private double _outerRadius;
		public double OuterRadius
	    {
		    get { return _outerRadius; }
			set
			{
				_outerRadius = value;
				OnPropertyChanged(nameof(OuterRadius));
			}
	    }

		private double _selectedRadius;
		public double SelectedRadius
		{
			get { return _selectedRadius; }
			set
			{
				_selectedRadius = value;
				OnPropertyChanged(nameof(SelectedRadius));
			}
		}

		protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            // When the corner is moved, update the SelectedRect.
            if (propertyName == nameof(BottomCornerCanvas) ||
                propertyName == nameof(LeftCornerCanvas) ||
                propertyName == nameof(RightCornerCanvas) ||
                propertyName == nameof(TopCornerCanvas))
            {
				SelectedCenter = new Point((RightCornerCanvas - LeftCornerCanvas) / 2, (TopCornerCanvas - BottomCornerCanvas) / 2);
	            SelectedRadius = RightCornerCanvas - LeftCornerCanvas;
            }
        }


        public void ResetCorner(double leftCornerCanvas, double topCornerCanvas,
            double bottomCornerCanvas, double rightCornerCanvas)
        {
            LeftCornerCanvas = leftCornerCanvas;
            TopCornerCanvas = topCornerCanvas;
            BottomCornerCanvas = bottomCornerCanvas;
            RightCornerCanvas = rightCornerCanvas;
        }

        /// <summary>
        /// Update the Canvas.Top and Canvas.Left of the corner.
        /// </summary>
        public void UpdateCorner(string cornerName, double leftUpdate, double topUpdate, double minWidthSize, double minHeightSize)
        {
     //       switch (cornerName)
     //       {
     //           case nameof(TopCornerCanvas):
		   //         BottomCornerCanvas -= topUpdate;
		   //         LeftCornerCanvas = minWidthSize - (TopCornerCanvas - BottomCornerCanvas)/2;
		   //         RightCornerCanvas = minWidthSize - (TopCornerCanvas - BottomCornerCanvas)/2;


					////LeftCornerCanvas = ValidateValue(_leftCornerCanvas + leftUpdate,
     ////                   0, _bottomCornerCanvas - minWidthSize);
     ////               TopCornerCanvas = ValidateValue(_topCornerCanvas + topUpdate,
     ////                   0, _rightCornerCanvas - minHeightSize);
     //               break;
     //           case nameof() SelectedRegion.TopRightCornerName:
     //               BottomCornerCanvas = ValidateValue(_bottomCornerCanvas + leftUpdate,
     //                   _leftCornerCanvas + minWidthSize, outerRect.Width);
     //               TopCornerCanvas = ValidateValue(_topCornerCanvas + topUpdate,
     //                   0, _rightCornerCanvas - minHeightSize);
     //               break;
     //           case SelectedRegion.BottomLeftCornerName:
     //               LeftCornerCanvas = ValidateValue(_leftCornerCanvas + leftUpdate,
     //                   0, _bottomCornerCanvas - minWidthSize);
     //               RightCornerCanvas = ValidateValue(_rightCornerCanvas + topUpdate,
     //                   _topCornerCanvas + minHeightSize, outerRect.Height);
     //               break;
     //           case SelectedRegion.BottomRightCornerName:
     //               BottomCornerCanvas = ValidateValue(_bottomCornerCanvas + leftUpdate,
     //                   _leftCornerCanvas + minWidthSize, outerRect.Width);
     //               RightCornerCanvas = ValidateValue(_rightCornerCanvas + topUpdate,
     //                   _topCornerCanvas + minHeightSize, outerRect.Height);
     //               break;
     //           default:
     //               throw new ArgumentException("cornerName: " + cornerName + "  is not recognized.");
     //       }

        }

        private double ValidateValue(double tempValue, double from, double to)
        {
	        if (tempValue < from)
		        tempValue = from;

	        if (tempValue > to)
		        tempValue = to;

	        return tempValue;
        }

        /// <summary>
        /// Update the SelectedRect when it is moved or scaled.
        /// </summary>
        public void UpdateSelectedRect(double scale, double leftUpdate, double topUpdate)
        {
            double width = _bottomCornerCanvas - _leftCornerCanvas;
            double height = _rightCornerCanvas - _topCornerCanvas;

            if (scale != 1)
            {
                double scaledLeftUpdate = width * (scale - 1) / 2;
                double scaledTopUpdate = height * (scale - 1) / 2;

                if (scale > 1)
                {
                    //this.UpdateCorner(nameof(BottomCornerCanvas), scaledLeftUpdate, scaledTopUpdate);
                    //this.UpdateCorner(nameof(TopCornerCanvas), -scaledLeftUpdate, -scaledTopUpdate);
                }
                else
                {
                    //this.UpdateCorner(nameof(TopCornerCanvas), -scaledLeftUpdate, -scaledTopUpdate);
                    //this.UpdateCorner(nameof(BottomCornerCanvas), scaledLeftUpdate, scaledTopUpdate);
                }

                return;
            }

            double minWidth = Math.Max(this.MinSelectRegionSize, width * scale);
            double minHeight = Math.Max(this.MinSelectRegionSize, height * scale);

            // Move towards BottomRight: Move BottomRightCorner first, and then move TopLeftCorner.
            if (leftUpdate >= 0 && topUpdate >= 0)
            {
                //this.UpdateCorner(nameof() SelectedRegion.BottomRightCornerName, leftUpdate, topUpdate, minWidth, minHeight);
                //this.UpdateCorner(SelectedRegion.TopLeftCornerName, leftUpdate, topUpdate, minWidth, minHeight);
            }

            // Move towards TopRight: Move TopRightCorner first, and then move BottomLeftCorner.
            else if (leftUpdate >= 0 && topUpdate < 0)
            {
                //this.UpdateCorner(SelectedRegion.TopRightCornerName, leftUpdate, topUpdate, minWidth, minHeight);
                //this.UpdateCorner(SelectedRegion.BottomLeftCornerName, leftUpdate, topUpdate, minWidth, minHeight);
            }

            // Move towards BottomLeft: Move BottomLeftCorner first, and then move TopRightCorner.
            else if (leftUpdate < 0 && topUpdate >= 0)
            {
                //this.UpdateCorner(SelectedRegion.BottomLeftCornerName, leftUpdate, topUpdate, minWidth, minHeight);
                //this.UpdateCorner(SelectedRegion.TopRightCornerName, leftUpdate, topUpdate, minWidth, minHeight);
            }

            // Move towards TopLeft: Move TopLeftCorner first, and then move BottomRightCorner.
            else if (leftUpdate < 0 && topUpdate < 0)
            {
                //this.UpdateCorner(SelectedRegion.TopLeftCornerName, leftUpdate, topUpdate, minWidth, minHeight);
                //this.UpdateCorner(SelectedRegion.BottomRightCornerName, leftUpdate, topUpdate, minWidth, minHeight);
            }
        }
    }
}
