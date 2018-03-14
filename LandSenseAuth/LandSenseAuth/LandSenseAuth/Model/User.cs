// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="IIASA">
//   EOS
// </copyright>
// <summary>
//   The constants.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LandSenseAuth.Model
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Users
    /// </summary>
    [JsonObject]
    public class User
    {
        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>
        ///     The email.
        /// </value>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the name of the family.
        /// </summary>
        /// <value>
        ///     The name of the family.
        /// </value>
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>
        ///     The gender.
        /// </value>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        ///     Gets or sets the name of the given.
        /// </summary>
        /// <value>
        ///     The name of the given.
        /// </value>
        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the link.
        /// </summary>
        /// <value>
        ///     The link.
        /// </value>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the picture.
        /// </summary>
        /// <value>
        ///     The picture.
        /// </value>
        [JsonProperty("picture")]
        public string Picture { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [verified email].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [verified email]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("verified_email")]
        public bool VerifiedEmail { get; set; }
    }
}