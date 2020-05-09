/*
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

using ControllizerAPI.Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ControllizerDeckProject.PluginSystem
{
    public static class PluginLoader
    {
        private const string DefaultPluginExtension = "*.dll";
        private static List<Thread> pluginThreadPool = new List<Thread>();

        private static Dictionary<string, PluginBase> PluginInstances = new Dictionary<string, PluginBase>();

        public static bool GetAllPluginsInPath(string path)
        {
            if (!Directory.Exists(path))
                return false;
            foreach (string filename in Directory.GetFiles(path, DefaultPluginExtension, SearchOption.AllDirectories))
            {
                Assembly pluginDll = Assembly.LoadFile(filename);
                foreach (var assemblyType in pluginDll.GetExportedTypes())
                {
                    if (assemblyType.IsSubclassOf(typeof(PluginBase))){

                        var plugin = Activator.CreateInstance(assemblyType) as PluginBase;
                        PluginInstances.Add(plugin.PluginName, plugin);
                    }
                }
            }
            return true;
        }

        public static void InitAll()
        {
            foreach(PluginBase p in PluginInstances.Values)
            {
                p.InitPlugin();
            }
        }

        public static void ExecuteAll()
        {
            foreach (PluginBase p in PluginInstances.Values)
            {
                pluginThreadPool.Add(new Thread(p.ExecutePlugin));
            }
            pluginThreadPool.ForEach(e => e.Start());
        }

        public static void DestroyAll()
        {
            pluginThreadPool.ForEach(e => e.Join());
            foreach (PluginBase p in PluginInstances.Values)
            {
                p.DestroyPlugin();
            }
        }

    }
}
