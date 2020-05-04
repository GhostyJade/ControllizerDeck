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
