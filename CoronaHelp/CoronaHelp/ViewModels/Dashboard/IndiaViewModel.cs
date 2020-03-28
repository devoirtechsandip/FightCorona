using Acr.UserDialogs;
using CoronaHelp.Models;
using CoronaHelp.Models.Dashboard;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CoronaHelp.ViewModels.India
{
    [Preserve(AllMembers = true)]
    public class IndiaViewModel : BaseViewModel
    {

        

        private ObservableCollection<Regional> _ListIndiaData;
        public ObservableCollection<Regional> ListIndiaData
{
            get
            {
                return this._ListIndiaData;
            }

            set
            {
                this._ListIndiaData = value;
                this.NotifyPropertyChanged();
            }
            //get { return _ListIndiaData; }
            //set { SetProperty(ref _ListIndiaData, value); }
        }


        private ObservableCollection<HealthCare> cardItems;
        public ObservableCollection<HealthCare> CardItems
        {
            get
            {
                return this.cardItems;
            }

            set
            {
                this.cardItems = value;
                this.NotifyPropertyChanged();
            }
        }

        public Command DownloadItems { get; set; }

        public IndiaViewModel()
        {
            try
            {
                ListIndiaData = new ObservableCollection<Regional>();
                CardItems = new ObservableCollection<HealthCare>();
                this.DownloadItems = new Command(this.DownloadListFunc);
                DownloadListFunc();
            }
            catch (Exception ex)
            { }
            }

        private async void DownloadListFunc()
        {

            UserDialogs.Instance.ShowLoading("Please wait", MaskType.Black);
            await GetIndiaData();

            UserDialogs.Instance.HideLoading();

        }

        public async Task GetIndiaData()
        {
            try
            {
                var Items = await LoadIndiaDataAsync();

                if (Items != null)
                {
                    ListIndiaData.Clear();

                    CardItems.Clear();

                    CardItems.Add(new HealthCare()
                    {
                        Category = "Cases",
                        CategoryValue = Items.data.summary.total.ToString(),
                        //ChartData = heartRateData,
                        BackgroundGradientStart = "#f59083",
                        BackgroundGradientEnd = "#fae188",
                    });
                    CardItems.Add(new HealthCare()
                    {
                        Category = "Deaths",
                        CategoryValue = Items.data.summary.deaths.ToString(),
                        //ChartData = caloriesBurnedData,
                        BackgroundGradientStart = "#ff7272",
                        BackgroundGradientEnd = "#f650c5"
                    });
                    CardItems.Add(new HealthCare()
                    {
                        Category = "Recovered",
                        CategoryValue = Items.data.summary.discharged.ToString(),
                        //ChartData = sleepTimeData,
                        BackgroundGradientStart = "#5e7cea",
                        BackgroundGradientEnd = "#1dcce3"
                    });

                    foreach (var item in Items.data.regional)
                    {
                        ListIndiaData.Add(item);
                    }


                }
            }
            catch (Exception ex)
            {
                
            }


        }

        public async Task<IndianData> LoadIndiaDataAsync()
        {
            var uri = new Uri("https://api.rootnet.in/covid19-in/stats/latest");

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var serializerSettings = new JsonSerializerSettings();
                    serializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    return JsonConvert.DeserializeObject<IndianData>(content, serializerSettings);


                }
            }

            throw new HttpRequestException("Failed to retrieve countries data from server.");
        }



        //private DelegateCommand _PhoneCall;
        //public DelegateCommand PhoneCall =>
        //    _PhoneCall ?? (_PhoneCall = new DelegateCommand(ExecutePhoneCall));

        //void ExecutePhoneCall()
        //{
        //    try
        //    {
        //        PhoneDialer.Open("+911123978046");
        //    }
        //    catch (ArgumentNullException anEx)
        //    {
        //        // Number was null or white space
        //    }
        //    catch (FeatureNotSupportedException ex)
        //    {
        //        // Phone Dialer is not supported on this device.
        //    }
        //    catch (Exception ex)
        //    {
        //        // Other error has occurred.
        //    }
        //}

        //private DelegateCommand _TollFreeCall;
        //public DelegateCommand TollFreeCall =>
        //    _TollFreeCall ?? (_TollFreeCall = new DelegateCommand(ExecuteTollFreeCallCall));

        //void ExecuteTollFreeCallCall()
        //{
        //    try
        //    {
        //        PhoneDialer.Open("1075");
        //    }
        //    catch (ArgumentNullException anEx)
        //    {
        //        // Number was null or white space
        //    }
        //    catch (FeatureNotSupportedException ex)
        //    {
        //        // Phone Dialer is not supported on this device.
        //    }
        //    catch (Exception ex)
        //    {
        //        // Other error has occurred.
        //    }
        //}

        //private DelegateCommand _InEmail;
        //public DelegateCommand InEmail =>
        //    _InEmail ?? (_InEmail = new DelegateCommand(ExecuteInEmail));

        //async void ExecuteInEmail()
        //{
        //    try
        //    {
        //        var message = new EmailMessage
        //        {
        //            Subject = "Fight Against COVID19",                    
        //            To = new List<string> { "ncov2019@gov.in" },
        //            //Cc = ccRecipients,
        //            //Bcc = bccRecipients
        //        };
        //        await Email.ComposeAsync(message);
        //    }
        //    catch (FeatureNotSupportedException fbsEx)
        //    {
        //        // Email is not supported on this device
        //    }
        //    catch (Exception ex)
        //    {
        //        // Some other exception occurred
        //    }
        //}

        //private DelegateCommand _GmailEmail;
        //public DelegateCommand GmailEmail =>
        //    _GmailEmail ?? (_GmailEmail = new DelegateCommand(ExecuteGmailEmail));

        //async void ExecuteGmailEmail()
        //{
        //    try
        //    {
        //        var message = new EmailMessage
        //        {
        //            Subject = "Fight Against COVID19",
        //            To = new List<string> { "ncov2019@gmail.com" },
        //            //Cc = ccRecipients,
        //            //Bcc = bccRecipients
        //        };
        //        await Email.ComposeAsync(message);
        //    }
        //    catch (FeatureNotSupportedException fbsEx)
        //    {
        //        // Email is not supported on this device
        //    }
        //    catch (Exception ex)
        //    {
        //        // Some other exception occurred
        //    }
        //}
    }
}
