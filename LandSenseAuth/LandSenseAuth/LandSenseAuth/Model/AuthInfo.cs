//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AuthInfo.cs" company="IIASA">
//    EOS
//  </copyright>
//  <summary>
//   AuthInfo.cs
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace LandSenseAuth.Model
{
    /// <summary>
    ///     Auth info
    /// </summary>
    public class AuthInfo
    {
        /// <summary>
        ///     Gets or sets the access token.
        /// </summary>
        /// <value>
        ///     The access token.
        /// </value>
        public string AccessToken { get; set; }

        /// <summary>
        ///     Gets or sets the expires in.
        /// </summary>
        /// <value>
        ///     The expires in.
        /// </value>
        public int ExpiresIn { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
        /// </value>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        ///     Gets or sets the refresh token.
        /// </summary>
        /// <value>
        ///     The refresh token.
        /// </value>
        public string RefreshToken { get; set; }

        /// <summary>
        ///     Gets or sets the scope.
        /// </summary>
        /// <value>
        ///     The scope.
        /// </value>
        public string Scope { get; set; }

        /// <summary>
        ///     Gets or sets the type of the token.
        /// </summary>
        /// <value>
        ///     The type of the token.
        /// </value>
        public string TokenType { get; set; }
    }
}