using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Yaringa.Services {
    /// <summary>
    /// Wrapper class of Application.Current.Properties in Xamarin.Forms.
    /// </summary>
    public class ApplicationStore : IApplicationStore {
        #region Public Methods

        public Task AddOrUpdateValue<T>(string key, T value) => AddOrUpdateValueInternal(key, value);

        public T GetValueOrDefault<T>(string key, T defaultValue = default(T)) =>
            GetValueOrDefaultInternal(key, defaultValue);

        #endregion

        #region Internal Implementation

        async Task AddOrUpdateValueInternal<T>(string key, T value) {
            if (value == null) {
                await Remove(key);
            }

            Application.Current.Properties[key] = value;
            try {
                await Application.Current.SavePropertiesAsync();
            } catch (Exception) {
                throw;
            }
        }

        T GetValueOrDefaultInternal<T>(string key, T defaultValue = default(T)) {
            object value = null;
            if (Application.Current.Properties.ContainsKey(key)) {
                value = Application.Current.Properties[key];
            }
            return null != value ? (T)value : defaultValue;
        }

        async Task Remove(string key) {
            try {
                if (Application.Current.Properties[key] != null) {
                    Application.Current.Properties.Remove(key);
                    await Application.Current.SavePropertiesAsync();
                }
            } catch (Exception) {
                throw;
            }
        }

        #endregion
    }
}