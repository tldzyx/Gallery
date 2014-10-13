using System;

namespace Gallery.Interface
{
    /// <summary>
    /// 支持克隆，即用与现有实例相同的值创建类的新实例。
    /// </summary>
    /// <typeparam name="T">副本类型</typeparam>
    public interface ICloneable<out T> : ICloneable
    {

        /// <summary>
        /// 创建作为当前实例副本的新对象。
        /// </summary>
        /// <returns>作为此实例副本的新对象。</returns>
        new T Clone();
    }
}
