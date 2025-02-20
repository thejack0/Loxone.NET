// ----------------------------------------------------------------------
// <copyright file="DeserializationTests.cs">
//     Copyright (c) The Loxone.NET Authors.  All rights reserved.
// </copyright>
// <license>
//     Use of this source code is governed by the MIT license that can be
//     found in the LICENSE.txt file.
// </license>
// ----------------------------------------------------------------------

namespace Loxone.Client.Tests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Loxone.Client.Contracts;
    using Loxone.Client.Contracts.Controls;
    using Loxone.Client.Transport.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public async Task SerializeReadOnlyControl()
        {
            const string CONTROL_TYPE = "InfoOnlyDigital";
            Uuid CONTROL_UUID = Uuid.Parse("991bed10-01f9-2b85-ffff5e20fb3695f6");
            Uuid CATEGORY_UUID = Uuid.Parse("0b734138-036d-0334-ffff403fb0c34b9e");
            Uuid ACTIVE_STATE_UUID = Uuid.Parse("184100e8-034a-d296-ffff95544eebe62f");
            Uuid ROOM_UUID = Uuid.Parse("0b734138-038c-035e-ffff403fb0c34b9e");
            const string CONTROL_NAME = "Test control";
            const int DEFAULT_RATING = 2;
            const string ROOM_NAME = "My room";
            const string CATEGORY_NAME = "My category";
            const bool IS_FAVORITE = true;
            const bool IS_SECURED = true;

            var DetailsTextElement = JsonDocument.Parse(@"{
					""off"": ""Uit"",
					""on"": ""Aan""
				}").RootElement;
            var DetailsColorElement = JsonDocument.Parse(@"{
                    ""off"": ""#E73246"",
					""on"": ""#69C350""
                }").RootElement;

            var control = new InfoOnlyDigital(
                new ControlDTO {
                    Uuid = CONTROL_UUID,
                    ControlType = CONTROL_TYPE,
                    Category = CATEGORY_UUID,
                    IsFavorite = IS_FAVORITE,
                    DefaultRating = DEFAULT_RATING,
                    IsSecured = IS_SECURED,
                    Room = ROOM_UUID,
                    Name = CONTROL_NAME,
                    Details = new System.Collections.Generic.Dictionary<string, object> {
                        { "jLockable", true },
                        { "text",  DetailsTextElement },
                        { "color", DetailsColorElement }
                    },
                    States = new System.Collections.Generic.Dictionary<string, string>
                    {
                        {"active", ACTIVE_STATE_UUID.ToString() }
                    },
                });
            control.RoomName = ROOM_NAME;
            control.CategoryName = CATEGORY_NAME;
            var valueState = new ValueState(ACTIVE_STATE_UUID, 5d, DateTimeOffset.Now);
            control.UpdateStateValue(valueState);

            var json = await SerializationHelper.Serialize(control);
            Assert.IsNotNull(json);
            Assert.IsTrue(json.StartsWith('{'));

            var deserializedControl = SerializationHelper.Deserialize<InfoOnlyDigital>(json);
            Assert.IsNotNull(deserializedControl);
            Assert.AreEqual(deserializedControl.CategoryId, CATEGORY_UUID);
            Assert.AreEqual(deserializedControl.ControlType, "InfoOnlyDigital");
            Assert.AreEqual(deserializedControl.StateValues.Count, 1);
            var firstStateValue = deserializedControl.StateValues.First();
            Assert.AreEqual(firstStateValue.Key, ACTIVE_STATE_UUID);
            Assert.AreEqual(firstStateValue.Value.Value, 5d);
            Assert.AreEqual(firstStateValue.Value.LastModified.ToString(), valueState.LastModified.ToString());
            Assert.AreEqual(deserializedControl.RoomId, ROOM_UUID);
            Assert.AreEqual(deserializedControl.Name, CONTROL_NAME);
            Assert.AreEqual(deserializedControl.DefaultRating, DEFAULT_RATING);
            Assert.AreEqual(deserializedControl.RoomName, ROOM_NAME);
            Assert.AreEqual(deserializedControl.CategoryName, CATEGORY_NAME);
            Assert.AreEqual(deserializedControl.IsFavorite, IS_FAVORITE);
            Assert.AreEqual(deserializedControl.IsSecured, IS_SECURED);
            Assert.AreEqual(deserializedControl.TextOff, "Uit");
            Assert.AreEqual(deserializedControl.TextOn, "Aan");
        }

        [TestMethod]
        public async Task SerializeStructureFile()
        {
            var jsonBytes = Properties.Resources.LoxAPP3_504F94A0DDB8_json;
            var stream = new StreamReader(new MemoryStream(jsonBytes));
            //var text = await SerializationHelper.DeserializeAsync<StructureFile>(stream);
            /*
            Assert.IsNotNull(text);
            Assert.IsTrue(text.)
            */

            //var file = Newtonsoft.Json.JsonConvert.DeserializeObject<StructureFile>(text);
        }
    }
}
