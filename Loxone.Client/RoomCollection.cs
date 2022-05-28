// ----------------------------------------------------------------------
// <copyright file="RoomCollection.cs">
//     Copyright (c) The Loxone.NET Authors.  All rights reserved.
// </copyright>
// <license>
//     Use of this source code is governed by the MIT license that can be
//     found in the LICENSE.txt file.
// </license>
// ----------------------------------------------------------------------

namespace Loxone.Client
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using Loxone.Client.Contracts;

    public sealed class RoomCollection : IReadOnlyCollection<Room>
    {
        private readonly IDictionary<string, Transport.RoomDTO> _innerRooms;

        internal RoomCollection(IDictionary<string, Transport.RoomDTO> innerRooms)
        {
            Contract.Requires(innerRooms != null);
            this._innerRooms = innerRooms;
        }

        public int Count => _innerRooms.Count;

        public IEnumerator<Room> GetEnumerator()
        {
            foreach (var pair in _innerRooms)
            {
                yield return new Room(pair.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public string GetRoomName(Uuid roomId)
        {
            if (_innerRooms.TryGetValue(roomId.ToString(), out var room))
                return room.Name;

            return string.Empty;
        }
    }
}
