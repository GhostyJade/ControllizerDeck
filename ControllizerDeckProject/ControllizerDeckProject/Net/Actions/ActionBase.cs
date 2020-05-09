namespace ControllizerDeckProject.Net.Actions
{
    public abstract class ActionBase
    {
        public enum HTTPType
        {
            GET,POST
        }

        public string ActionName { get; private set; }
        public string ActionURI { get; private set; }
        public HTTPType ActionType { get; private set; }

        public ActionBase(string name, string uri, HTTPType type)
        {
            ActionName = name;
            ActionURI = uri;
            ActionType = type;
        }

        public virtual void OnPost() { }
        public virtual void OnGet() { }

    }
}
