using System;
using Gallery.Interface;

namespace Gallery.Extension
{
    public static class ObjectExtension
    {
        public static TResult Clone<TResult>(this object obj)
        {
            ICloneable<TResult> cloneableT = obj as ICloneable<TResult>;
            if (null != cloneableT)
            {
                return cloneableT.Clone();
            }
            ICloneable cloneable = obj as ICloneable;
            if (null != cloneable)
            {
                object result = cloneable.Clone();
                if (result is TResult)
                    return (TResult)result;
            }
            return default(TResult);
        }
    }
}
