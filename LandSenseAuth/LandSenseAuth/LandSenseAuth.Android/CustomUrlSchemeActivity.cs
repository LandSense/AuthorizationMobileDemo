//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CustomUrlSchemeActivity.cs" company="IIASA">
//    EOS
//  </copyright>
//  <summary>
//   CustomUrlSchemeActivity.cs
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace LandSenseAuth.Droid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Android.App;
    using Android.Content;
    using Android.Content.PM;
    using Android.OS;

    using LandSenseAuth.Authenticator;
    using LandSenseAuth.Constants;

    using Prism.Navigation;

    using RestSharp;
    using RestSharp.Authenticators;

    using Method = Java.Lang.Reflect.Method;

    /// <summary>
    ///     Custom Url Schema
    /// </summary>
    /// <seealso cref="Android.App.Activity" />
    [Activity(Label = "CustomUrlSchemeActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(
        new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataSchemes = new[] { "eu.landsense" })]
    public class CustomUrlSchemeActivity : Activity
    {
        /// <summary>
        ///     The navigation service
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        ///     Called when the activity is starting.
        /// </summary>
        /// <param name="savedInstanceState">
        ///     If the activity is being re-initialized after
        ///     previously being shut down then this Bundle contains the data it most
        ///     recently supplied in
        ///     <c>
        ///         <see cref="M:Android.App.Activity.OnSaveInstanceState(Android.OS.Bundle)" />
        ///     </c>
        ///     .
        ///     <format type="text/html">
        ///         <b>
        ///             <i>Note: Otherwise it is null.</i>
        ///         </b>
        ///     </format>
        /// </param>
        /// <remarks>
        ///     <para tool="javadoc-to-mdoc">
        ///         Called when the activity is starting.  This is where most initialization
        ///         should go: calling
        ///         <c>
        ///             <see cref="M:Android.App.Activity.SetContentView(System.Int32)" />
        ///         </c>
        ///         to inflate the
        ///         activity's UI, using
        ///         <c>
        ///             <see cref="M:Android.App.Activity.FindViewById(System.Int32)" />
        ///         </c>
        ///         to programmatically interact
        ///         with widgets in the UI, calling
        ///         <c>
        ///             <see
        ///                 cref="M:Android.App.Activity.ManagedQuery(Android.Net.Uri, System.String[], System.String[], System.String[], System.String[])" />
        ///         </c>
        ///         to retrieve
        ///         cursors for data being displayed, etc.
        ///     </para>
        ///     <para tool="javadoc-to-mdoc">
        ///         You can call
        ///         <c>
        ///             <see cref="M:Android.App.Activity.Finish" />
        ///         </c>
        ///         from within this function, in
        ///         which case onDestroy() will be immediately called without any of the rest
        ///         of the activity lifecycle (
        ///         <c>
        ///             <see cref="M:Android.App.Activity.OnStart" />
        ///         </c>
        ///         ,
        ///         <c>
        ///             <see cref="M:Android.App.Activity.OnResume" />
        ///         </c>
        ///         ,
        ///         <c>
        ///             <see cref="M:Android.App.Activity.OnPause" />
        ///         </c>
        ///         , etc) executing.
        ///     </para>
        ///     <para tool="javadoc-to-mdoc">
        ///         <i>
        ///             Derived classes must call through to the super class's
        ///             implementation of this method.  If they do not, an exception will be
        ///             thrown.
        ///         </i>
        ///     </para>
        ///     <para tool="javadoc-to-mdoc">
        ///         <format type="text/html">
        ///             <a href="http://developer.android.com/reference/android/app/Activity.html#onCreate(android.os.Bundle)"
        ///                 target="_blank">
        ///                 [Android Documentation]
        ///             </a>
        ///         </format>
        ///     </para>
        /// </remarks>
        /// <since version="Added in API level 1" />
        /// <altmember cref="M:Android.App.Activity.OnStart" />
        /// <altmember cref="M:Android.App.Activity.OnSaveInstanceState(Android.OS.Bundle)" />
        /// <altmember cref="M:Android.App.Activity.OnRestoreInstanceState(Android.OS.Bundle)" />
        /// <altmember cref="M:Android.App.Activity.OnPostCreate(Android.OS.Bundle)" />
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Convert Android.Net.Url to Uri
            var uri = new Uri(this.Intent.Data.ToString());


            //// Load redirectUrl page
            AuthenticationState.Authenticator.OnPageLoading(uri);

            //var queryValues = ParseQueryValues(uri);
            //var code = queryValues["code"];
            //var state = queryValues["state"];

            //var client = new RestClient(Constant.AccessTokenUrl)
            //                 {
            //                     Authenticator = new HttpBasicAuthenticator(
            //                         Constant.AndroidClientId,
            //                         Constant.ClientIdSecret)
            //                 };
            //var request = new RestRequest(RestSharp.Method.POST);
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Accept", "application/json");
            //request.AddParameter("grant_type", "authorization_code");
            //request.AddParameter("client_id", Constant.AndroidClientId);
            //request.AddParameter("client_secret", Constant.ClientIdSecret);
            //request.AddParameter("redirect_uri", Constant.AndroidRedirectUrl);
            //request.AddParameter("code", code);

            //var response = client.Execute(request);

            //if (response.IsSuccessful)
            //{
            //    AuthenticationState.Authenticator.ParseResponse(response.Content);
            //}
            //else
            //{
            //    //// Load redirectUrl page
            //    AuthenticationState.Authenticator.OnPageLoading(uri);
            //}

            this.Finish();
        }

        /// <summary>
        ///     Parses the query values.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        private static Dictionary<string, string> ParseQueryValues(Uri uri)
        {
            var queryValues = uri.Query.TrimStart('?').Split(new[] { '&', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parameter => parameter.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries)).GroupBy(
                    parts => parts[0],
                    parts => parts.Length > 2
                                 ? string.Join("=", parts, 1, parts.Length - 1)
                                 : (parts.Length > 1 ? parts[1] : string.Empty)).ToDictionary(
                    grouping => grouping.Key,
                    grouping => string.Join(",", grouping));
            return queryValues;
        }
    }
}