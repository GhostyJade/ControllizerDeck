using ControllizerDeckProject.Core.Input;

using System.Collections.Generic;

namespace ControllizerDeckProject.Core.Hardware
{
    public class HardwareData
    {
        /// <summary>
        /// A list of PushButtons
        /// </summary>
        public List<PushButton> PushButtons { get; private set; } = new List<PushButton>();

        /// <summary>
        /// A list of Rotary Encoders
        /// </summary>
        public List<RotaryEncoder> RotaryEncoders { get; private set; } = new List<RotaryEncoder>();

        /// <summary>
        /// A list of Knobs
        /// </summary>
        public List<Knob> Knobs { get; private set; } = new List<Knob>();

        public bool HasInitializedAsMatrix = false;

        public string MatrixLayout;

    }
}
