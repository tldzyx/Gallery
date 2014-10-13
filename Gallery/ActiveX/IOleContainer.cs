using System.Runtime.InteropServices;

namespace Gallery.ActiveX
{
    /// <summary>
    /// 
    /// </summary>
    [ComImport]
    [Guid("0000011B-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleContainer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grfFlags"></param>
        /// <param name="ppenum"></param>
        void EnumObjects(
            [In]
            [MarshalAs(UnmanagedType.U4)]
            int grfFlags,
            [Out]
            [MarshalAs(UnmanagedType.LPArray)]
            object[] ppenum);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pbc"></param>
        /// <param name="pszDisplayName"></param>
        /// <param name="pchEaten"></param>
        /// <param name="ppmkOut"></param>
        void ParseDisplayName(
            [In]
            [MarshalAs(UnmanagedType.Interface)]
            object pbc,
            [In]
            [MarshalAs(UnmanagedType.BStr)]
            string pszDisplayName,
            [Out]
            [MarshalAs(UnmanagedType.LPArray)]
            int[] pchEaten,
            [Out]
            [MarshalAs(UnmanagedType.LPArray)]
            object[] ppmkOut);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fLock"></param>
        void LockContainer(
            [In]
            [MarshalAs(UnmanagedType.I4)]
            int fLock);
    }
}
