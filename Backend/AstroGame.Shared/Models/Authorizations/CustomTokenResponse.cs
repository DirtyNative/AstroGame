using System.Collections.Generic;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Authorizations
{
    public class CustomTokenResponse
    {
        /// <summary>
        /// Gets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets the identity token.
        /// </summary>
        /// <value>
        /// The identity token.
        /// </value>
        [JsonProperty("identity_token")]
        public string IdentityToken { get; set; }

        /// <summary>
        /// Gets the scope.
        /// </summary>
        /// <value>
        /// The scope.
        /// </value>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Gets the issued token type.
        /// </summary>
        /// <value>
        /// The issued token type.
        /// </value>
        [JsonProperty("issued_token_type")]
        public string IssuedTokenType { get; set; }

        /// <summary>
        /// Gets the type of the token.
        /// </summary>
        /// <value>
        /// The type of the token.
        /// </value>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets the refresh token.
        /// </summary>
        /// <value>
        /// The refresh token.
        /// </value>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets the error description.
        /// </summary>
        /// <value>
        /// The error description.
        /// </value>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets the expires in.
        /// </summary>
        /// <value>
        /// The expires in.
        /// </value>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        public static CustomTokenResponse Parse(Dictionary<string, dynamic> dictionary)
        {
            var response =  new CustomTokenResponse()
            {
                AccessToken = dictionary["access_token"],
                //IdentityToken = dictionary["identity_token"],
                Scope = dictionary["scope"],
                //IssuedTokenType = dictionary["issued_token_type"],
                TokenType = dictionary["token_type"],
                RefreshToken = dictionary["refresh_token"],
                //ErrorDescription = dictionary["error_description"],
                ExpiresIn = (int)dictionary["expires_in"]
            };

            return response;
        }
    }
}
