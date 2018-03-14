using Newtonsoft.Json;

namespace LandSenseAuth.Authenticator
{
    /// <summary>
    /// Auth Token
    /// </summary>
    public class AuthToken
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the expires in.
        /// </summary>
        /// <value>
        /// The expires in.
        /// </value>
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>
        /// The type of the token.
        /// </value>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        /// <value>
        /// The scope.
        /// </value>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the identifier token.
        /// </summary>
        /// <value>
        /// The identifier token.
        /// </value>
        [JsonProperty("id_token")]
        public string IdToken { get; set; }

        /// <summary>
        /// Gets or sets the userinfo encrypted response alg.
        /// </summary>
        /// <value>
        /// The userinfo encrypted response alg.
        /// </value>
        [JsonProperty("userinfo_encrypted_response_alg")]
        public string UserinfoEncryptedResponseAlg { get; set; }

        /// <summary>
        /// Gets or sets the userinfo encrypted response enc.
        /// </summary>
        /// <value>
        /// The userinfo encrypted response enc.
        /// </value>
        [JsonProperty("userinfo_encrypted_response_enc")]
        public string UserinfoEncryptedResponseEnc { get; set; }

        /// <summary>
        /// Gets or sets the userinfo secret.
        /// </summary>
        /// <value>
        /// The userinfo secret.
        /// </value>
        [JsonProperty("userinfo_secret")]
        public string UserinfoSecret { get; set; }
    }
}