using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace CoronaHelp.ViewModels.Info
{
    public class InfoViewModel : BindableBase
    {
        public InfoViewModel()
        {



        }

        private DelegateCommand _PhoneCall;
        public DelegateCommand PhoneCall =>
            _PhoneCall ?? (_PhoneCall = new DelegateCommand(ExecutePhoneCall));

        void ExecutePhoneCall()
        {
            try
            {
                PhoneDialer.Open("+911123978046");
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        private DelegateCommand _TollFreeCall;
        public DelegateCommand TollFreeCall =>
            _TollFreeCall ?? (_TollFreeCall = new DelegateCommand(ExecuteTollFreeCallCall));

        void ExecuteTollFreeCallCall()
        {
            try
            {
                PhoneDialer.Open("1075");
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        private DelegateCommand _InEmail;
        public DelegateCommand InEmail =>
            _InEmail ?? (_InEmail = new DelegateCommand(ExecuteInEmail));

        async void ExecuteInEmail()
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = "Fight Against COVID19",
                    To = new List<string> { "ncov2019@gov.in" },
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }

        private DelegateCommand _GmailEmail;
        public DelegateCommand GmailEmail =>
            _GmailEmail ?? (_GmailEmail = new DelegateCommand(ExecuteGmailEmail));

        async void ExecuteGmailEmail()
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = "Fight Against COVID19",
                    To = new List<string> { "ncov2019@gmail.com" },
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
    }


}
