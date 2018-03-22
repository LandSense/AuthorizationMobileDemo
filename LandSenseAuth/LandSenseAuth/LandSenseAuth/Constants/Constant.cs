//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Constant.cs" company="IIASA">
//    EOS
//  </copyright>
//  <summary>
//   Constant.cs
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace LandSenseAuth.Constants
{
    /// <summary>
    ///     The constants.
    /// </summary>
    public static class Constant
    {
        /// <summary>
        ///     The access token URL
        /// </summary>
        public const string AccessTokenUrl = "https://as.landsense.eu/oauth/token";

        /// <summary>
        ///     The android client identifier
        /// </summary>
        public const string AndroidClientId = "a6136f07-a8dc-8bce-725a-7a07489f7d0b@as.landsense.eu";

        /// <summary>
        ///     The android redirect URL, make sure it is lower case and has a trailing slash
        /// </summary>
        public const string AndroidRedirectUrl = "eu.landsense://landsenseauth/";

        /// <summary>
        ///     The authorize URL
        /// </summary>
        public const string AuthorizeUrl = "https://as.landsense.eu/oauth/authorize";

        /// <summary>
        ///     The client identifier secret
        /// </summary>
        public const string ClientIdSecret = "8fef63480edba7bdb717b9d1cf140050f3287780eae4d805b0fdd71490fd3e3f";

        /// <summary>
        ///     The scope
        /// </summary>
        public const string Scope = "openid profile email landsense"; // TODO: offline_access

        /// <summary>
        ///     The user information URL
        /// </summary>
        public const string UserInfoUrl = "https://as.landsense.eu/oauth/userinfo";

        /// <summary>
        ///     The application name
        /// </summary>
        public static string AppName = "LandSenseAuth";

        /// <summary>
        ///     The ios client identifier
        /// </summary>
        public static string IOSClientId = "<insert IOS client ID here>";

        /// <summary>
        ///     The ios redirect URL
        /// </summary>
        public static string IOSRedirectUrl = "<insert IOS redirect URL here>";
    }
}