using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using CoronaHelp.Models.Navigation;
using CoronaHelp.DataService;
using System;
using Xamarin.Essentials;
using Syncfusion.ListView.XForms;

namespace CoronaHelp.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for documents page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class DocumentsViewModel : BaseViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="DocumentsViewModel"/> class.
        /// </summary>
        public DocumentsViewModel()
        {
            DocumentsList = new ObservableCollection<Document>();

            DocumentsList = DocumentsListDataService.Instance.DocumentsViewModel.DocumentsList;

            
            //this.ItemTappedCommand = new Command(this.MenuClicked);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command<object>(this.NavigateToNextPage));
            }
        }

        /// <summary>
        /// Gets or sets a collction of value to be displayed in documents list page.
        /// </summary>
        [DataMember(Name = "documentsPageList")]
        public ObservableCollection<Document> DocumentsList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the documents list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            var item = selectedItem as Syncfusion.ListView.XForms.ItemTappedEventArgs;
            var result = item.ItemData as Document;
            // Do something
            Launcher.OpenAsync(new Uri(result.DocumentUrl));
        }

        #endregion
    }
}