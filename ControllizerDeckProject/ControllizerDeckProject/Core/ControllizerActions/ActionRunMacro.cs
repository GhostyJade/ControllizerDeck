using ControllizerCore.Input.Action;
using ControllizerCore.Input.Types;

namespace ControllizerDeckProject.Core.ControllizerActions
{
    public class ActionRunMacro : DigitalInputActionBase
    {
        public ActionRunMacro() : base("Macro", DigitalActionType.Macro)
        { }

        public override void Execute()
        {
            
        }

        public override void Init()
        { }
    }
}
