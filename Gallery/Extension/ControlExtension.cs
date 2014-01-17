

using System;
using System.Linq;
using System.Windows.Forms;

namespace Gallery.Extension
{
    /// <summary>
    /// 控件拓展
    /// </summary>
    public static class ControlExtension
    {
        /// <summary>
        /// 销毁原子控件集合, 并用新的子控件填充.
        /// </summary>
        /// <param name="controlCollection">原子控件集合</param>
        /// <param name="control">新的子控件</param>
        public static void Replace(this Control.ControlCollection controlCollection, Control control)
        {
            controlCollection.Replace(new[] {control});
        }

        /// <summary>
        /// 销毁原子控件集合, 并用新的子控件集合填充.
        /// </summary>
        /// <param name="controlCollection">原子控件集合</param>
        /// <param name="controls">新的子控件集合</param>
        public static void Replace(this Control.ControlCollection controlCollection, Control[] controls)
        {
            foreach (var item in controlCollection.OfType<IDisposable>())
            {
                item.Dispose();
            }
            controlCollection.Clear();
            controlCollection.AddRange(controls);
        }
    }
}