namespace LearnIt.MAUI.Services
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public class LocalStorageService
    {
        public void Add(string key, string value)
        {
            Preferences.Set(key, value);
        }

        public void Get(string key, string defaultValue = "")
        {
            Preferences.Get(key, defaultValue);
        }

        public void Remove(string key)
        {
            Preferences.Remove(key);
        }
    }
}