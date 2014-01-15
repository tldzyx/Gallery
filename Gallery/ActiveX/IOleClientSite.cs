using System.Runtime.InteropServices;

namespace Gallery.ActiveX
{
    /// <summary>
    /// 
    /// </summary>
    [ComImport]
    [Guid("00000118-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleClientSite
    {
        /// <summary>
        /// 
        /// </summary>
        void SaveObject();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwAssign"></param>
        /// <param name="dwWhichMoniker"></param>
        /// <param name="ppmk"></param>
        void GetMoniker(uint dwAssign, uint dwWhichMoniker, object ppmk);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ppContainer"></param>
        void GetContainer(out IOleContainer ppContainer);

        /// <summary>
        /// 
        /// </summary>
        void ShowObject();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fShow"></param>
        void OnShowWindow(bool fShow);

        /// <summary>
        /// 
        /// </summary>
        void RequestNewObjectLayout();
    }
}
