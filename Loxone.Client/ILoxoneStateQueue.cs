// ----------------------------------------------------------------------
// <copyright file="StructureFile.cs">
//     Copyright (c) The Loxone.NET Authors.  All rights reserved.
// </copyright>
// <license>
//     Use of this source code is governed by the MIT license that can be
//     found in the LICENSE.txt file.
// </license>
// ----------------------------------------------------------------------

namespace Loxone.Client
{
    using System.Threading.Tasks;
    using Loxone.Client.Contracts;

    public interface ILoxoneStateQueue
    {
        Task EnqueueAsync(IStateChange stateChange);
        Task<(bool success, IStateChange stateChange)> TryDequeueAsync();
        int Count();
    }
}
