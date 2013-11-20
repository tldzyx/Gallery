using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallery.Interface
{
    public interface ICloneable<out T> : ICloneable
    {

        /// <summary>
        /// 创建作为当前实例副本的新对象。
        /// </summary>
        /// <returns>作为此实例副本的新对象。</returns>
        new T Clone();
    }
}
