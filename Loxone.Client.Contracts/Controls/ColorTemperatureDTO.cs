// ----------------------------------------------------------------------
// <copyright file="StructureFile.cs">
//     Copyright (c) The Loxone.NET Authors.  All rights reserved.
// </copyright>
// <license>
//     Use of this source code is governed by the MIT license that can be
//     found in the LICENSE.txt file.
// </license>
// ----------------------------------------------------------------------

namespace Loxone.Client.Contracts.Controls
{
    public class ColorTemperatureDTO
    {
        public int Brightness { get; set; }
        public int TemperatureInKelvin { get; set; }

        public override string ToString()
        {
            return $"TEMP - brightness = {Brightness} - Kelvin = {TemperatureInKelvin}";
        }
    }
}
