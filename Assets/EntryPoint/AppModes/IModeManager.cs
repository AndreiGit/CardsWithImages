namespace EntryPoint.AppModes
{
    public interface IModeManager
    {
        bool ChangeModeTo(string modeName);

        IAppMode CurrentMode { get; }

        void InitFirst(string modeName);

    }
}