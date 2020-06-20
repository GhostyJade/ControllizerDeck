namespace ControllizerDeckProject.Core
{
    public abstract class InputActionBase
    {
        public string Name { get; private set; }

        public InputActionBase(string name) { Name = name; }

        public abstract void Init();
        public abstract void Execute();
    }
}
