﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumblrUniversal.Tumblr;

namespace TumblrUniversal.Services.Request {

    /// <summary>
    /// Initializes a dictionary to store client application parameters for 
    /// a Http request.
    /// </summary>
    internal class RequestParameters : SortedDictionary<string, string> {

        /// <summary>
        /// Format and return the dictionary as a string representation.
        /// </summary>
        /// <returns>Return a formatted string represntation of the parameters in the
        /// dictionary.</returns>
        public override string ToString() {
            return string.Join("&",
                this.Select(p => string.Format("{0}={1}", p.Key,
                RequestBuilder.Instance.Encode(p.Value))));
        }

        /// <summary>
        /// Append default application call parameters to dictionary.
        /// </summary>
        /// <param name="nonce">Unique request identifier.</param>
        /// <param name="timestamp">Request creation timestamp.</param>
        public void AppendDefault(string nonce, string timestamp) {
            this.Add("oauth_consumer_key", TumblrClient.ConsumerKey);
            this.Add("oauth_nonce", nonce);
            this.Add("oauth_signature_method", "HMAC-SHA1");
            this.Add("oauth_timestamp", timestamp);
            this.Add("oauth_token", Authentication.Token);
            this.Add("oauth_verifier", Authentication.TokenVerifier);
            this.Add("oauth_version", "1.0");
        }
    }
}