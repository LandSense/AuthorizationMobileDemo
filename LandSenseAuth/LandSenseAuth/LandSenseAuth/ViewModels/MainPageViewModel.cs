//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MainPageViewModel.cs" company="IIASA">
//    EOS
//  </copyright>
//  <summary>
//   MainPageViewModel.cs
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace LandSenseAuth.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using LandSenseAuth.Authenticator;
    using LandSenseAuth.Constants;
    using LandSenseAuth.Model;

    using Newtonsoft.Json;

    using Prism.Commands;
    using Prism.Navigation;

    using Xamarin.Auth;
    using Xamarin.Auth.Presenters;
    using Xamarin.Forms;

    /// <summary>
    /// The main page view model.
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        /// <summary>
        ///     The client
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        ///     The navigation service
        /// </summary>
        private readonly INavigationService navigationService;

        /// <summary>
        ///     The store
        /// </summary>
        private readonly AccountStore store;

        /// <summary>
        ///     The account
        /// </summary>
        private Account account;

        /// <summary>
        ///     The authentication information
        /// </summary>
        private AuthInfo authInfo;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainPageViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">
        ///     The navigation service.
        /// </param>
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.Title = "Main Page";
            this.NavigateLoginAsyncCommand = new DelegateCommand(this.NavigateToLoginAsync);
        }

        // <summary>
        /// Gets or sets the navigate login asynchronous command.
        /// </summary>
        /// <value>
        ///     The navigate login asynchronous command.
        /// </value>
        public DelegateCommand NavigateLoginAsyncCommand { get; set; }

        /// <summary>
        ///     Gets the user data asynchronous.
        /// </summary>
        /// <param name="restUrl">The rest URL.</param>
        /// <param name="accessToken">The access token.</param>
        /// <returns></returns>
        public async Task<User> GetUserDataAsync(string restUrl, string accessToken)
        {
            try
            {
                // the below comment should be done first
                // Project->Properties->Andriod Option->Advance->HttpClientImplementation->Andriod
                var uri = new Uri(string.Format(restUrl));
                this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await this.client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<User>(content);
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }

        /// <summary>
        ///     The navigate to login async.
        /// </summary>
        public void NavigateToLoginAsync()
        {
            string clientId = null;
            string redirectUri = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = Constant.IOSClientId;
                    redirectUri = Constant.IOSRedirectUrl;
                    break;

                case Device.Android:
                    clientId = Constant.AndroidClientId;
                    redirectUri = Constant.AndroidRedirectUrl;
                    break;
            }

            Func<Dictionary<string, string>, string> super = (prop) => "Test";

            GetUsernameAsyncFunc getUsernameAsyncFunc = (prop) => { return Task.Run(() => string.Empty); };


            // TODO : add Native UI = true.
            var authenticator = new OAuth2AuthenticatorWithGrant(
                clientId,
                Constant.ClientIdSecret,
                Constant.Scope,
                new Uri(Constant.AuthorizeUrl),
                new Uri(Constant.AndroidRedirectUrl),
                new Uri(Constant.AccessTokenUrl));

            authenticator.AccessTokenUrl = new Uri(Constant.AccessTokenUrl);
            authenticator.Completed += this.OnAuthCompleted;
            authenticator.Error += this.OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        /// <summary>
        ///     Fills the authentication custom object.
        /// </summary>
        /// <param name="eventArgs">The <see cref="AuthenticatorCompletedEventArgs" /> instance containing the event data.</param>
        /// <param name="authInfoObj">The authentication information object.</param>
        /// <exception cref="ArgumentNullException">authInfoObj</exception>
        private void FillAuthCustomObject(AuthenticatorCompletedEventArgs eventArgs, ref AuthInfo authInfoObj)
        {
            if (authInfoObj == null)
            {
                throw new ArgumentNullException(nameof(authInfoObj));
            }

            if (eventArgs.IsAuthenticated)
            {
                var accessToken = eventArgs.Account.Properties["access_token"];
                var expiresIn = int.Parse(eventArgs.Account.Properties["expires_in"]);
                var tokenType = eventArgs.Account.Properties["token_type"];
                var scope = eventArgs.Account.Properties["scope"];
                authInfoObj = new AuthInfo
                                  {
                                      IsAuthenticated = eventArgs.IsAuthenticated,
                                      AccessToken = accessToken,
                                      ExpiresIn = expiresIn,
                                      Scope = scope,
                                      TokenType = tokenType
                                  };
            }
            else
            {
                authInfoObj = new AuthInfo { IsAuthenticated = eventArgs.IsAuthenticated };
            }
        }

        /// <summary>
        ///     Called when [authentication completed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AuthenticatorCompletedEventArgs" /> instance containing the event data.</param>
        private async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= this.OnAuthCompleted;
                authenticator.Error -= this.OnAuthError;
            }

            if (e.IsAuthenticated)
            {
                this.FillAuthCustomObject(e, ref this.authInfo);

                if (this.authInfo != null)
                {
                    var userInfo = await this.GetUserDataAsync(Constant.UserInfoUrl, this.authInfo.AccessToken);
                    await this.navigationService.NavigateAsync(
                        "ProfilePage",
                        new NavigationParameters { { "userInfo", userInfo } });
                }

                if (this.account != null) this.store.Delete(this.account, Constant.AppName);

                await this.store.SaveAsync(this.account = e.Account, Constant.AppName);
            }
        }

        /// <summary>
        ///     Called when [authentication error].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AuthenticatorErrorEventArgs" /> instance containing the event data.</param>
        private void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= this.OnAuthCompleted;
                authenticator.Error -= this.OnAuthError;
            }
        }
    }
}