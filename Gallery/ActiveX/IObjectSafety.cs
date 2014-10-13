using System;
using System.Runtime.InteropServices;

namespace Gallery.ActiveX
{
    /// <summary> 
    /// 把控件发布成com组件时必须实现的接口.该接口的GUID是固定的,不能修改,否则组件发布不成功.
    /// </summary> 
    [ComImport]
    [Guid("CB5BDC81-93C1-11CF-8F20-00805F2CD064")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IObjectSafety
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="riid"></param>
        /// <param name="pdwSupportedOptions"></param>
        /// <param name="pdwEnabledOptions"></param>
        /// <returns></returns>
        [PreserveSig]
        int GetInterfaceSafetyOptions(
            ref Guid riid,
            [MarshalAs(UnmanagedType.U4)]
            ref int pdwSupportedOptions,
            [MarshalAs(UnmanagedType.U4)]
            ref int pdwEnabledOptions);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="riid"></param>
        /// <param name="dwOptionSetMask"></param>
        /// <param name="dwEnabledOptions"></param>
        /// <returns></returns>
        [PreserveSig]
        int SetInterfaceSafetyOptions(
            ref Guid riid,
            [MarshalAs(UnmanagedType.U4)]
            int dwOptionSetMask,
            [MarshalAs(UnmanagedType.U4)]
            int dwEnabledOptions);
    }
}
