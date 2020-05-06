using ControllizerDeckProject.Net.Actions;

using System.Collections.Generic;

namespace ControllizerDeckProject.Net
{
    public static class ActionManager
    {
        public static Dictionary<string, ActionBase> actions = new Dictionary<string, ActionBase>();

        public static void INIT()
        {
            RegisterAction(new ActionExit());
        }

        public static void RegisterAction(ActionBase a)
        {
            actions.Add(a.ActionName, a);
        }

        public static List<ActionBase> GetPOSTActions()
        {
            List<ActionBase> a = new List<ActionBase>();
            foreach (ActionBase action in actions.Values)
            {
                if (action.ActionType == ActionBase.HTTPType.POST)
                    a.Add(action);
            }
            return a;
        }
    }
}
