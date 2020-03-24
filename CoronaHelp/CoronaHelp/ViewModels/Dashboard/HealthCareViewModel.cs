using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CoronaHelp.Models.Dashboard;
using Newtonsoft.Json;
using Prism.Commands;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CoronaHelp.ViewModels.Dashboard
{
    /// <summary>
    /// ViewModel for stock overview page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class HealthCareViewModel : BaseViewModel
    {
        #region Field

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<HealthCare> cardItems;

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<HealthCare> listItems;

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<LstCountryData> listCountryData; 

        /// <summary>
        /// To store the heart rate data collection.
        /// </summary>
        private ObservableCollection<ChartDataPoint> heartRateData;

        /// <summary>
        /// To store the calories burned data collection.
        /// </summary>
        private ObservableCollection<ChartDataPoint> caloriesBurnedData;

        /// <summary>
        /// To store the sleep time data collection.
        /// </summary>
        private ObservableCollection<ChartDataPoint> sleepTimeData;

        /// <summary>
        /// To store the water consumed data collection.
        /// </summary>
        private ObservableCollection<ChartDataPoint> waterConsumedData;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="HealthCareViewModel" /> class.
        /// </summary>
        public HealthCareViewModel()
        {
            //GetChartData();            

            client = new HttpClient();
           
            this.MenuCommand = new Command(this.MenuClicked);
            this.DownloadItems = new Command(this.DownloadListFunc);

            DownloadListFunc();
            
        }

        #endregion

        #region Properties

        private readonly HttpClient client;

        /// <summary>
        /// Gets or sets the profile image path.
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the health care items collection.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the health care items collection.
        /// </summary>
        public ObservableCollection<HealthCare> ListItems
        {
            get
            {
                return this.listItems;
            }

            set
            {
                this.listItems = value;
                this.NotifyPropertyChanged();
            }
        }


        public ObservableCollection<LstCountryData> ListCountryData
        {
            get
            {
                return this.listCountryData;
            }

            set
            {
                this.listCountryData = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Comments

        /// <summary>
        /// Gets or sets the command that will be executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }
        public Command DownloadItems { get; set; }   
        public Command UpdateCommand { get; }

        #endregion

        #region Methods

      

        /// <summary>
        /// Chart Data Collection
        /// </summary>
        private void GetChartData()
        {
            DateTime dateTime = new DateTime(2019, 5, 1);

            heartRateData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint(dateTime, 15),
                new ChartDataPoint(dateTime.AddMonths(1), 20),
                new ChartDataPoint(dateTime.AddMonths(2), 17),
                new ChartDataPoint(dateTime.AddMonths(3), 23),
                new ChartDataPoint(dateTime.AddMonths(4), 18),
                new ChartDataPoint(dateTime.AddMonths(5), 25),
                new ChartDataPoint(dateTime.AddMonths(6), 19),
                new ChartDataPoint(dateTime.AddMonths(7), 21),
            };

            caloriesBurnedData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint(dateTime, 940),
                new ChartDataPoint(dateTime.AddMonths(1), 960),
                new ChartDataPoint(dateTime.AddMonths(2), 942),
                new ChartDataPoint(dateTime.AddMonths(3), 957),
                new ChartDataPoint(dateTime.AddMonths(4), 940),
                new ChartDataPoint(dateTime.AddMonths(5), 942),
            };

            sleepTimeData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint(dateTime, 7.8),
                new ChartDataPoint(dateTime.AddMonths(1), 7.2),
                new ChartDataPoint(dateTime.AddMonths(2), 8.0),
                new ChartDataPoint(dateTime.AddMonths(3), 6.8),
                new ChartDataPoint(dateTime.AddMonths(4), 7.6),
                new ChartDataPoint(dateTime.AddMonths(5), 7.0),
                new ChartDataPoint(dateTime.AddMonths(6), 7.5),
            };

            waterConsumedData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint(dateTime, 36),
                new ChartDataPoint(dateTime.AddMonths(1), 41),
                new ChartDataPoint(dateTime.AddMonths(2), 38),
                new ChartDataPoint(dateTime.AddMonths(3), 41),
                new ChartDataPoint(dateTime.AddMonths(4), 35),
                new ChartDataPoint(dateTime.AddMonths(5), 37),
                new ChartDataPoint(dateTime.AddMonths(6), 38),
                new ChartDataPoint(dateTime.AddMonths(7), 36),
            };
        }

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void MenuClicked(object obj)
        {
            // Do something
        }

        private async void DownloadListFunc()
        {

            //await Task.Run(() => { 
            //    UserDialogs.Instance.ShowLoading("Please wait", MaskType.Black); 
            //    GetWorldData().ConfigureAwait(false); 
            //    GetCountryData().ConfigureAwait(false);
            //    UserDialogs.Instance.HideLoading();
            //});

          
                UserDialogs.Instance.ShowLoading("Please wait", MaskType.Black);
            await GetWorldData().ConfigureAwait(false);
            await GetCountryData().ConfigureAwait(false);
                UserDialogs.Instance.HideLoading();
        

        }



        public async Task GetCountryData()
        {
           

            var Items = await LoadCountryDataAsync();

            if (Items != null)
            {
                ListCountryData = new ObservableCollection<LstCountryData>();

               
                    foreach (var item in Items)
                    {
                        LstCountryData countryData = new LstCountryData()
                        {
                            Country = item.Country,
                            Cases = item.Cases.ToString(),
                            Deaths = item.Deaths.ToString(),
                            TodayCases = item.TodayCases.ToString(),
                            TodayDeaths = item.TodayDeaths.ToString()
                        };

                        ListCountryData.Add(countryData);
                    }
                
            }
           
        }

        public async Task GetWorldData()
        {
           
            var Items = await LoadWorldDataAsync();

            if (Items != null)
            {
                CardItems = new ObservableCollection<HealthCare>(){
                new HealthCare()
                {
                    Category = "Cases",
                    CategoryValue = Items.cases.ToString(),
                    //ChartData = heartRateData,
                    BackgroundGradientStart = "#f59083",
                    BackgroundGradientEnd = "#fae188",
                },
                new HealthCare()
                {
                    Category = "Deaths",
                    CategoryValue = Items.deaths.ToString(),
                    //ChartData = caloriesBurnedData,
                    BackgroundGradientStart = "#ff7272",
                    BackgroundGradientEnd = "#f650c5"
                },
                new HealthCare()
                {
                    Category = "Recovered",
                    CategoryValue = Items.recovered.ToString(),
                    //ChartData = sleepTimeData,
                    BackgroundGradientStart = "#5e7cea",
                    BackgroundGradientEnd = "#1dcce3"
                }
                };

                
            }
           

        }



        public async Task<IEnumerable<CountryData>> LoadCountryDataAsync()
        {
            

            var uri = new Uri("https://corona.lmao.ninja/countries");
            var response = await client.GetAsync(uri);
          
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.NullValueHandling = NullValueHandling.Ignore;
                return JsonConvert.DeserializeObject<List<CountryData>>(content, serializerSettings);
            }

           

            throw new HttpRequestException("Failed to retrieve countries data from server.");

            
        }

        public async Task<WorldData> LoadWorldDataAsync()
        {
            

            var uri = new Uri("https://corona.lmao.ninja/all");
          
            var response = await client.GetAsync(uri);
           
            if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var serializerSettings = new JsonSerializerSettings();
                    serializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    return  JsonConvert.DeserializeObject<WorldData>(content, serializerSettings);


                }

            

            throw new HttpRequestException("Failed to retrieve countries data from server.");
           


        }

        #endregion
    }
}
