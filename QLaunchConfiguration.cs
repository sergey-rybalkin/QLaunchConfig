using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Win32;

namespace QLaunchConfig
{
    // Copied from WinUser.h - possible values for nShow field of SHELLEXECUTEINFO structure
    enum WindowState
    {
        SW_HIDE = 0,
        SW_NORMAL = 1,
        SW_MINIMIZE = 2,
        SW_MAXIMIZE = 3
    }

    /// <summary>
    /// Takes care of reading/writing quick launch configuration.
    /// </summary>
    static class QLaunchConfiguration
    {
        #region Constants

        private static string ExecutorKeyName
        {
            get
            {
                return ConfigurationManager.AppSettings["RegKeyName"];
            }
        }

        // Copied from WinUser.h - possible values of fsModifiers parameter for RegisterHotKey
        // WinAPI function
        private const int MOD_ALT = 0x0001;
        private const int MOD_CONTROL = 0x0002;
        private const int MOD_SHIFT = 0x0004;
        private const int MOD_WIN = 0x0008;
        
        // Need to be syncronized with Shell Extender and QLaunch
        private const string ValueAsyncKeys = "AsyncKeys";
        private const string ValueParams = "Params";
        private const string ValuePath = "Path";
        private const string ValueMainKey = "MainKey";
        private const string ValueMonitor = "Monitor";
        private const string ValueWindowState = "WindowState";
        
        #endregion

        #region Methods

        /// <summary>
        /// Reads the quick launher configuration from registry.
        /// </summary>
        /// <returns>
        /// List of the quick launch items currently stored in the system registry.
        /// </returns>
        public static List<QLaunchItem> ReadConfiguration()
        {
            RegistryKey qlaunchKey = Registry.CurrentUser.OpenSubKey(ExecutorKeyName, false);

            // All registered quick launch items are stored as subkeys, iterate through them and
            // parse their data
            string[] itemNames = qlaunchKey.GetSubKeyNames();
            List<QLaunchItem> retVal = new List<QLaunchItem>(itemNames.Length);
            foreach (string itemName in itemNames)
            {
                RegistryKey itemConfig = qlaunchKey.OpenSubKey(itemName, false);

                QLaunchItem item = new QLaunchItem
                    {
                        Name = itemName,
                        AsyncKeyCode = 
                            (Keys)KeyCodeFromModifier((int) itemConfig.GetValue(ValueAsyncKeys)),
                        CmdParameters = (string) itemConfig.GetValue(ValueParams),
                        FilePath = (string)      itemConfig.GetValue(ValuePath),
                        MainKeyCode = (Keys)     itemConfig.GetValue(ValueMainKey),
                        MonitorIndex = (int)    (itemConfig.GetValue(ValueMonitor)??0),
                        WindowState = (WindowState)
                            (itemConfig.GetValue(ValueWindowState) ?? WindowState.SW_NORMAL)
                    };
                retVal.Add(item);

                itemConfig.Close();
            }

            qlaunchKey.Close();

            return retVal;
        }

        /// <summary>
        /// Updates the specified quick launch item configuration in the system registry.
        /// </summary>
        /// <param name="item">The quick launch item to update configuration for.</param>
        public static void UpdateItem(QLaunchItem item)
        {
            RegistryKey qlaunchKey =
                Registry.CurrentUser.OpenSubKey(ExecutorKeyName, true);

            RegistryKey itemConfig = qlaunchKey.OpenSubKey(item.Name, true);
            if (null != itemConfig)
            {
                itemConfig.SetValue(ValueAsyncKeys, 
                                    ModifierCodeFromKey((int)item.AsyncKeyCode), 
                                    RegistryValueKind.DWord);
                itemConfig.SetValue(ValueParams, item.CmdParameters, RegistryValueKind.String);
                itemConfig.SetValue(ValuePath, item.FilePath, RegistryValueKind.String);
                itemConfig.SetValue(ValueMainKey, (int)item.MainKeyCode, RegistryValueKind.DWord);
                itemConfig.SetValue(ValueMonitor, item.MonitorIndex, RegistryValueKind.DWord);
                itemConfig.SetValue(ValueWindowState, item.WindowState, RegistryValueKind.DWord);

                itemConfig.Close();
            }

            qlaunchKey.Close();
        }

        /// <summary>
        /// Adds the specified quick launch item configuration to the system registry.
        /// </summary>
        /// <param name="item">The quick launch item to create configuration for.</param>
        public static void AddItem(QLaunchItem item)
        {
            RegistryKey qlaunchKey = Registry.CurrentUser.OpenSubKey(ExecutorKeyName, true);

            qlaunchKey.CreateSubKey(item.Name).Close();
            UpdateItem(item);
        }

        /// <summary>
        /// Removes configuration for the specified item from the system registry.
        /// </summary>
        /// <param name="item">The item whose configuration is to be removed.</param>
        public static void RemoveItem(QLaunchItem item)
        {
            RegistryKey qlaunchKey =
                Registry.CurrentUser.OpenSubKey(ExecutorKeyName, true);

            qlaunchKey.DeleteSubKey(item.Name);
            
            qlaunchKey.Close();
        }

        /// <summary>
        /// Converts modifier code (used in RegisterHotkey WinAPI) to key code.
        /// </summary>
        /// <param name="modifier">The modifier code to convert.</param>
        /// <returns>Int32 value of the correcponding Keys enumeration member.</returns>
        public static int KeyCodeFromModifier(int modifier)
        {
            switch (modifier)
            {
                case MOD_ALT:
                    return (int) Keys.Alt;
                case MOD_CONTROL:
                    return (int)Keys.Control;
                case MOD_SHIFT:
                    return (int)Keys.Shift;
                case MOD_WIN:
                    return (int)Keys.LWin;
                default:
                    return modifier;
            }
        }

        /// <summary>
        /// Converts key code to modifier code (used in RegisterHotkey WinAPI).
        /// </summary>
        /// <param name="keyCode">The key code to convert.</param>
        /// <returns>Int32 value that RegisterHotkey WinAPI method will understand.</returns>
        public static int ModifierCodeFromKey(int keyCode)
        {
            if (((int)Keys.Alt == keyCode) || 
                ((int)Keys.Menu == keyCode) || 
                ((int)Keys.LMenu == keyCode) || 
                ((int)Keys.RMenu == keyCode))
                return MOD_ALT;

            if (((int)Keys.Control == keyCode) ||
                ((int)Keys.ControlKey == keyCode) ||
                ((int)Keys.LControlKey == keyCode) ||
                ((int)Keys.RControlKey == keyCode))
                return MOD_CONTROL;

            if (((int)Keys.ShiftKey == keyCode) ||
                ((int)Keys.Shift == keyCode) ||
                ((int)Keys.LShiftKey == keyCode) ||
                ((int)Keys.RShiftKey == keyCode))
                return MOD_SHIFT;

            if (((int)Keys.LWin == keyCode) ||
                ((int)Keys.RWin == keyCode))
                return MOD_WIN;

            return 0;
        }

        #endregion
    }
}