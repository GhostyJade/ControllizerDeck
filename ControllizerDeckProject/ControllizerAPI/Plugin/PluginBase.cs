namespace ControllizerAPI.Plugin
{
    public abstract class PluginBase
    {
        public string PluginName { get; private set; }
        public string PluginVersion { get; private set; }

        protected PluginBase(string name, string version)
        {
            PluginName = name;
            PluginVersion = version;
        }

        public abstract void InitPlugin();
        public abstract void ExecutePlugin();
        public abstract void DestroyPlugin();
    }
}
