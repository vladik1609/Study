using Microsoft.Win32;
using System;

namespace Sokoban
{
    internal class RegistrySettings
    {
        private readonly RegistryKey registryKey;

        public RegistrySettings()
        {
            registryKey = Registry.CurrentUser.CreateSubKey(RegistryConstants.REGISTRY_ROOT);
        }

        public int SkinId
        {
            get { return GetRegistryKey(RegistryConstants.SKINS_KEY, 0); }
            set { SetRegistryKey(RegistryConstants.SKINS_KEY, value); }
        }

        public bool SoundIsEnabled
        {
            get { return GetRegistryKey(RegistryConstants.SOUND_KEY, true); }
            set { SetRegistryKey(RegistryConstants.SOUND_KEY, value); }
        }

        private T GetRegistryKey<T>(string key, T defaultValue)
        {
            try
            {
                string value = registryKey.GetValue(key)?.ToString();
                if (value != null)
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
            }
            catch
            {
                // ДОБАВИТЬ ОБРАБОТКУ ошибок преобразования или раздел реестра не найден
            }
            return defaultValue;
        }

        private void SetRegistryKey<T>(string key, T value)
        {
            registryKey.SetValue(key, value.ToString());
        }
    }
}