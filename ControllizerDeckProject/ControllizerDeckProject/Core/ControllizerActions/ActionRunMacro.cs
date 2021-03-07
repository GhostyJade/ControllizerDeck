using ControllizerCore.Input.Action;
using ControllizerCore.Input.Types;
using GregsStack.InputSimulatorStandard;
using GregsStack.InputSimulatorStandard.Native;
using System;
using System.Collections.Generic;

namespace ControllizerDeckProject.Core.ControllizerActions
{
    public class ActionRunMacro : DigitalInputActionBase
    {
        public enum MacroType
        {
            Keystroke = 0,
            Text = 1,
            Mouse = 2 // (mouse is a special one: it allows to move your mouse cursor with precise path (with ui to configure it)
        }

        private static InputSimulator _instance = new InputSimulator();

        private MacroType type;
        private List<VirtualKeyCode> macroModifiers;
        private List<VirtualKeyCode> macroKeys;
        private string text;

        public ActionRunMacro(MacroType type, string text = null) : base("Macro", DigitalActionType.Macro)
        {
            this.type = type;
            macroModifiers = new List<VirtualKeyCode>();
            macroKeys = new List<VirtualKeyCode>();
            this.text = text;
        }

        public override void Execute()
        {
            if (type == MacroType.Mouse) throw new NotSupportedException("Method not yet supported");
            if (type == MacroType.Keystroke)
                _instance.Keyboard.ModifiedKeyStroke(macroModifiers, macroKeys);
            else if (type == MacroType.Text && text != null)
                _instance.Keyboard.TextEntry(text);
            else
                foreach (var key in macroKeys)
                    _instance.Keyboard.KeyPress(key);
        }

        public override void Init()
        { }
    }
}
