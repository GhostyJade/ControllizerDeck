﻿using ControllizerCore.Net;

using ControllizerDeckProject.Net.Actions;

namespace ControllizerDeckProject.Utils
{
    public static class ActionRegister
    {
        public static void Register()
        {
            ActionManager.RegisterAction(new ActionExit());
            ActionManager.RegisterAction(new ActionGetSettings());
            ActionManager.RegisterAction(new ActionChangeSettings());
            ActionManager.RegisterAction(new ActionGetHardwareComponents());
            ActionManager.RegisterAction(new ActionSetHardwareFunctions());
            ActionManager.RegisterAction(new ActionFirstLaunch());
            ActionManager.RegisterAction(new ActionWelcome());
        }
    }
}
