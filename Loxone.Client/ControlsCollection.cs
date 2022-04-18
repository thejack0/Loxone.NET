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
    using System.Collections;
    using System.Collections.Generic;
    using Loxone.Client.Transport;

    public class ControlsCollection : IReadOnlyCollection<ILoxoneControl>, IEnumerable<ILoxoneControl>
    {
        private readonly IReadOnlyDictionary<string, ILoxoneControl> _controls;

        internal ControlsCollection(IDictionary<string, ControlDTO> controls, IControlFactory controlFactory)
        {
            _controls = controlFactory.Create(controls);
        }

        public int Count => _controls.Count;

        public IEnumerator<ILoxoneControl> GetEnumerator()
        {
            foreach (var pair in _controls)
            {
                yield return pair.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class LightControllerV2Control : ReadOnlyControl
    {
        public LightControllerV2Control(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class AudioZoneV2Control : ReadOnlyControl
    {
        public AudioZoneV2Control(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class RoomControllerV2Control : ReadOnlyControl
    {
        public RoomControllerV2Control(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class PresenceDetectorControl : ReadOnlyControl
    {
        public PresenceDetectorControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class JalousieControl : ReadOnlyControl
    {
        public JalousieControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class CentralAudioZoneControl : ReadOnlyControl
    {
        public CentralAudioZoneControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class ClimateControllerControl : ReadOnlyControl
    {
        public ClimateControllerControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class SwitchControl : ReadOnlyControl
    {
        public SwitchControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class LoadManagerControl : ReadOnlyControl
    {
        public LoadManagerControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class CentralLightControllerControl : ReadOnlyControl
    {
        public CentralLightControllerControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class WebpageControl : ReadOnlyControl
    {
        public WebpageControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class PulseAtControl : ReadOnlyControl
    {
        public PulseAtControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class AalSmartAlarmControl : ReadOnlyControl
    {
        public AalSmartAlarmControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class AlarmControl : ReadOnlyControl
    {
        public AlarmControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class SmokeAlarmControl : ReadOnlyControl
    {
        public SmokeAlarmControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class CentralJalousieControl : ReadOnlyControl
    {
        public CentralJalousieControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class WindowMonitorControl : ReadOnlyControl
    {
        public WindowMonitorControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class AalEmergencyControl : ReadOnlyControl
    {
        public AalEmergencyControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class CarChargerControl : ReadOnlyControl
    {
        public CarChargerControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class RemoteControl : ReadOnlyControl
    {
        public RemoteControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class AlarmClockControl : ReadOnlyControl
    {
        public AlarmClockControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class EnergyManagerControl : ReadOnlyControl
    {
        public EnergyManagerControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class FroniusControl : ReadOnlyControl
    {
        public FroniusControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class NfcCodeTouchControl : ReadOnlyControl
    {
        public NfcCodeTouchControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
    public class IntercomControl : ReadOnlyControl
    {
        public IntercomControl(ControlDTO controlDTO) : base(controlDTO)
        {
        }
    }
}
