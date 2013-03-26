using System.Windows.Forms;

namespace QLaunchConfig
{
    /// <summary>
    /// Presents information stored in the registry key for each quick launch item.
    /// </summary>
    class QLaunchItem
    {
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the file path to be launched.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the command line arguments for the launched application.
        /// </summary>
        public string CmdParameters { get; set; }

        /// <summary>
        /// Gets or sets the code of the asyncronous key for hotkey combination.
        /// </summary>
        public Keys AsyncKeyCode { get; set; }

        /// <summary>
        /// Gets or sets the main key code.
        /// </summary>
        public Keys MainKeyCode { get; set; }

        /// <summary>
        /// Gets or sets the state for the launched application window.
        /// </summary>
        /// <value>The state of the window.</value>
        public WindowState WindowState { get; set; }

        /// <summary>
        /// Gets or sets the index of the monitor to show launched application on.
        /// </summary>
        public int MonitorIndex { get; set; }
    }
}