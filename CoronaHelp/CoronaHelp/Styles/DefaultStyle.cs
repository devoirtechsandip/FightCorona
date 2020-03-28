﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfDataGrid.XForms;

using Xamarin.Forms;



namespace CoronaHelp.Styles
{
   



    /// <summary>
    /// Derived from DataGridStyle to add the custom styles
    /// </summary>
    public class DefaultStyle : DataGridStyle
    {
        /// <summary>
        /// Initializes a new instance of the DefaultStyle class.
        /// </summary>
        public DefaultStyle()
        {
        }

        /// <summary>
        /// Overrides this method to write a custom style for header back ground color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetHeaderBackgroundColor()
        {
            return Color.FromHex("#e0e0e0");
        }

        /// <summary>
        /// Overrides this method to write a custom style for selection background color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetSelectionBackgroundColor()
        {
            return Color.FromHex("#b2d8f7");
        }

        /// <summary>
        /// Overrides this method to write a custom style for selection foreground color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetSelectionForegroundColor()
        {
            return Color.Black;
        }

        /// <summary>
        /// Overrides this method to write a custom style for record foreground color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetRecordForegroundColor()
        {
            return Color.Black;
        }

        /// <summary>
        /// Overrides this method to write a custom style for caption summary row background color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetCaptionSummaryRowBackgroundColor()
        {
            return Color.FromHex("#e6e6e6");
        }

        /// <summary>
        /// Overrides this method to write a custom style for record background color
        /// </summary>
        /// <returns>Returns From R g b Color</returns>
        public override Color GetRecordBackgroundColor()
        {
            return Color.White;
        }

        /// <summary>
        /// override to get a Custom group collapse icon
        /// </summary>
        /// <returns>GetGroupCollapseIcon() method returns null value</returns>
        public override ImageSource GetGroupCollapseIcon()
        {
            if (Device.RuntimePlatform == Device.macOS)
            {
                return base.GetGroupCollapseIcon();
            }

            return null;
        }

        /// <summary>
        /// override to get a Custom group GetHeaderSortIndicatorUp icon
        /// </summary>
        /// <returns>GetHeaderSortIndicatorUp() method returns GetHeaderSortIndicatorUp value</returns>
        public override ImageSource GetHeaderSortIndicatorUp()
        {
            return base.GetHeaderSortIndicatorUp();
        }

        /// <summary>
        /// override to get a Custom group GetHeaderSortIndicatorDown icon
        /// </summary>
        /// <returns>GetHeaderSortIndicatorDown() method returns GetHeaderSortIndicatorDown value</returns>
        public override ImageSource GetHeaderSortIndicatorDown()
        {
            if (Device.RuntimePlatform == Device.macOS)
            {
                return base.GetHeaderSortIndicatorDown();
            }

            return null;
        }
    }
}
