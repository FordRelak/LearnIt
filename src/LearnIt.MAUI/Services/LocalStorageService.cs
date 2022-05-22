namespace LearnIt.MAUI.Services
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public class LocalStorageService
    {
        public void Add(string key, string value)
        {
            Preferences.Set(key, value);
        }
        public void Add(string key, bool value)
        {
            Preferences.Set(key, value);
        }

        public string Get(string key, string defaultValue = "")
        {
            return Preferences.Get(key, defaultValue);
        }

        public bool Get(string key, bool defaultValue = false)
        {
            return Preferences.Get(key, defaultValue);
        }

        public void Remove(string key)
        {
            Preferences.Remove(key);
        }

        public void Clear()
        {
            Preferences.Clear();
        }
    }
}