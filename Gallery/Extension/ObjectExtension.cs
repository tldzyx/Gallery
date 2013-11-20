using System;
using Gallery.Interface;

namespace Gallery.Extension
{
    public static class ObjectExtension
    {
        public static TResult Clone<TResult>(this object obj)
        {
            if (obj is ICloneable<TResult>)
            {
                return ((ICloneable<TResult>)obj).Clone();
            }
            if (obj is ICloneable)
            {
                object result = ((ICloneable)obj).Clone();
                if (result is TResult)
                    return (TResult)result;
            }
            return default(TResult);
        }
    }
}
