using Xamarin.Forms.Internals;
using CoronaHelp.Models.Navigation;

namespace CoronaHelp.Controls
{
    /// <summary>
    /// This class extends the behavior of the SearchableListView control to filter the ListViewItem based on text.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SearchableDocumentsList : SearchableListView
    {
        #region Method

        /// <summary>
        /// Filtering the list view items based on the search text.
        /// </summary>
        /// <param name="obj">The list view item</param>
        /// <returns>Returns the filtered item</returns>
        public override bool FilterContacts(object obj)
        {
            if (base.FilterContacts(obj))
            {
                var taskInfo = obj as Document;
                if (taskInfo == null || string.IsNullOrEmpty(taskInfo.DocumentName) )
                {
                    return false;
                }

                return taskInfo.DocumentName.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant() );
            }

            return false;
        }

        #endregion
    }
}