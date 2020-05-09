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
            actions.Add(a.ActionURI, a);
        }

        public static List<ActionBase> GetPOSTActions()
        {
            List<ActionBase> a = new List<ActionBase>(); //I know that this is stupid and impact on performances...but I don't care :3
            foreach (ActionBase action in actions.Values)
            {
                if (action.ActionType == ActionBase.HTTPType.POST)
                    a.Add(action);
            }
            return a;
        }

        public static List<ActionBase> GetGETActions()
        {
            List<ActionBase> a = new List<ActionBase>(); //I know that this is stupid and impact on performances, again...but I don't care :3
            foreach (ActionBase action in actions.Values)
            {
                if (action.ActionType == ActionBase.HTTPType.GET)
                    a.Add(action);
            }
            return a;
        }
    }
}
