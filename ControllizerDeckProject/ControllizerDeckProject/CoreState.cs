﻿/*
    Controllizer Deck - A DIY customizable controller deck
    Copyright (C) 2020  GhostyJade <ghostyjade2410@gmail.com>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using ControllizerDeckProject.Utils;

using System;
using System.Collections.Generic;

namespace ControllizerDeckProject
{
    public static class CoreState
    {
        public static bool HasCloseRequested { get; set; } = false;
        public static string COMPort { get; set; } = string.Empty;

        public static List<Action> DisposableElements { get; } = new List<Action>();

        public static void AddDisposable(Action e) { if (!e.Method.Name.Equals("Dispose")) { ConsoleManager.LogError("Invalid dispose method name " + e.Method.Name); return; } DisposableElements.Add(e); }
    }
}
