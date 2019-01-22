using System.Threading.Tasks;

namespace Yaringa.Services {
    /// <summary>
    /// Interface to provide API to access platform specific data store.
    /// </summary>
    public interface IApplicationStore {
        T GetValueOrDefault<T>(string key, T defaultValue = default(T));
        Task AddOrUpdateValue<T>(string key, T value);
    }
}
