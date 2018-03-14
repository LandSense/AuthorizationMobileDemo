namespace LandSenseAuth.Authenticator
{
    using LandSenseAuth.Constants;
    using LandSenseAuth.Model;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Xamarin.Auth;

    /// <summary>
    /// OAuth2 Auth
    /// </summary>
    /// <seealso cref="Xamarin.Auth.OAuth2Authenticator" />
    public class OAuth2AuthenticatorWithGrant : OAuth2Authenticator
    {
        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth2AuthenticatorWithGrant"/> class.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="scope">The scope.</param>
        /// <param name="authorizeUrl">The authorize URL.</param>
        /// <param name="redirectUrl">The redirect URL.</param>
        /// <param name="getUsernameAsync">The get username asynchronous.</param>
        /// <param name="isUsingNativeUI">if set to <c>true</c> [is using native UI].</param>
        public OAuth2AuthenticatorWithGrant(string clientId, string scope, Uri authorizeUrl, Uri redirectUrl, GetUsernameAsyncFunc getUsernameAsync = null, bool isUsingNativeUI = false) : base(clientId, scope, authorizeUrl, redirectUrl, getUsernameAsync, isUsingNativeUI)
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth2AuthenticatorWithGrant"/> class.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="scope">The scope.</param>
        /// <param name="authorizeUrl">The authorize URL.</param>
        /// <param name="redirectUrl">The redirect URL.</param>
        /// <param name="accessTokenUrl">The access token URL.</param>
        /// <param name="getUsernameAsync">The get username asynchronous.</param>
        /// <param name="isUsingNativeUI">if set to <c>true</c> [is using native UI].</param>
        public OAuth2AuthenticatorWithGrant(string clientId, string clientSecret, string scope, Uri authorizeUrl, Uri redirectUrl, Uri accessTokenUrl, GetUsernameAsyncFunc getUsernameAsync = null, bool isUsingNativeUI = false) : base(clientId, clientSecret, scope, authorizeUrl, redirectUrl, accessTokenUrl, getUsernameAsync, isUsingNativeUI)
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// Called when [creating initial URL].
        /// </summary>
        /// <param name="query">The query.</param>
        protected override void OnCreatingInitialUrl(IDictionary<string, string> query)
        {
            query.Add("grant_type", "authorization_code");
            //query.Add("client_secret", Constant.ClientIdSecret);
            //query.Add("token_endpoint", Constant.AccessTokenUrl);
        }

        /// <summary>
        /// Parses the response.
        /// </summary>
        /// <param name="response">The response.</param>
        public void ParseResponse(string response)
        {
            var authToken = JsonConvert.DeserializeObject<AuthToken>(response);
            var userInfo = GetUserDataAsync(authToken.AccessToken).Result;

            //var userName = userInfo.Email;
        }

        /// <summary>
        /// Gets the user data asynchronous.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="restUrl">The rest URL.</param>
        /// <returns></returns>
        public async Task<User> GetUserDataAsync(string accessToken, string restUrl = Constant.UserInfoUrl)
        {
            try
            {
                // the below comment should be done first
                //Project->Properties->Andriod Option->Advance->HttpClientImplementation->Andriod

                var uri = new Uri(string.Format(restUrl));
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _client.GetAsync(uri);
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
    }
}