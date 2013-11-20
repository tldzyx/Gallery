using System;
using System.Runtime.InteropServices;

namespace Gallery.Helper
{
    public static class StructHelper
    {
        /// <summary>
        /// 结构体转字节流
        /// </summary>
        /// <typeparam name="T">结构体类型</typeparam>
        /// <param name="structObject">结构体对象</param>
        /// <returns>字节流</returns>
        public static byte[] StructToBytes<T>(T structObject)
            where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structObject, buffer, true);
                byte[] byteStream = new byte[size];
                Marshal.Copy(buffer, byteStream, 0, size);
                return byteStream;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        /// <summary>
        /// 字节流转结构体
        /// </summary>
        /// <typeparam name="T">结构体类型</typeparam>
        /// <param name="byteStream">字节流</param>
        /// <returns>结构体</returns>
        public static T BytesToStruct<T>(byte[] byteStream)
            where T : struct
        {
            if (null == byteStream)
            {
                throw new ArgumentNullException(
                    "byteStream", "字节流不能为空");
            }
            Type strcutType = typeof(T);
            int size = Marshal.SizeOf(strcutType);
            if (byteStream.Length != size)
            {
                throw new ArgumentOutOfRangeException(
                    "byteStream", "字节流长度与结构体大小不匹配");
            }
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(byteStream, 0, buffer, size);
                return (T)Marshal.PtrToStructure(buffer, strcutType);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
    }
}
