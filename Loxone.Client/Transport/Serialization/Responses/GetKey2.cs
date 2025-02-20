// ----------------------------------------------------------------------
// <copyright file="GetKey2.cs">
//     Copyright (c) The Loxone.NET Authors.  All rights reserved.
// </copyright>
// <license>
//     Use of this source code is governed by the MIT license that can be
//     found in the LICENSE.txt file.
// </license>
// ----------------------------------------------------------------------

namespace Loxone.Client.Transport.Serialization.Responses
{
    using Newtonsoft.Json;

    internal sealed class GetKey2
    {
        public string Key { get; set; }

        public string Salt { get; set; }

        [JsonProperty("hashAlg")]
        public string HashAlgorithm { get; set; }
    }
}
