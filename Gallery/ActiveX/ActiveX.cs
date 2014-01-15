using System;
using Gallery.Extension;

namespace Gallery.ActiveX
{
    /// <summary>
    /// 
    /// </summary>
    public class ActiveX : IObjectSafety
    {
        private const string _IID_IDispatch = "{00020400-0000-0000-C000-000000000046}";
        private const string _IID_IDispatchEx = "{A6EF9860-C720-11D0-9337-00A0C90DCAA9}";
        private const string _IID_IPersistStorage = "{0000010A-0000-0000-C000-000000000046}";
        private const string _IID_IPersistStream = "{00000109-0000-0000-C000-000000000046}";
        private const string _IID_IPersistPropertyBag = "{37D84F60-42CB-11CE-8135-00AA004BB851}";

        private const int INTERFACESAFE_FOR_UNTRUSTED_CALLER = 0x00000001;
        private const int INTERFACESAFE_FOR_UNTRUSTED_DATA = 0x00000002;
        private const int S_OK = 0;
        private const int E_FAIL = unchecked((int)0x80004005);
        private const int E_NOINTERFACE = unchecked((int)0x80004002);

        private const bool _fSafeForScripting = true;
        private const bool _fSafeForInitializing = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="riid"></param>
        /// <param name="pdwSupportedOptions"></param>
        /// <param name="pdwEnabledOptions"></param>
        /// <returns></returns>
        public static int GetInterfaceSafetyOptions(
            ref Guid riid,
            ref int pdwSupportedOptions,
            ref int pdwEnabledOptions)
        {
            int Rslt = E_FAIL;

            string strGUID = riid.ToString("B").ToUpperOrdinal();
            pdwSupportedOptions = INTERFACESAFE_FOR_UNTRUSTED_CALLER | INTERFACESAFE_FOR_UNTRUSTED_DATA;
            switch (strGUID)
            {
                case _IID_IDispatch:
                case _IID_IDispatchEx:
                    Rslt = S_OK;
                    pdwEnabledOptions = 0;
                    if (_fSafeForScripting)
                        pdwEnabledOptions = INTERFACESAFE_FOR_UNTRUSTED_CALLER;
                    break;
                case _IID_IPersistStorage:
                case _IID_IPersistStream:
                case _IID_IPersistPropertyBag:
                    Rslt = S_OK;
                    pdwEnabledOptions = 0;
                    if (_fSafeForInitializing)
                        pdwEnabledOptions = INTERFACESAFE_FOR_UNTRUSTED_DATA;
                    break;
                default:
                    Rslt = E_NOINTERFACE;
                    break;
            }
            return Rslt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="riid"></param>
        /// <param name="dwOptionSetMask"></param>
        /// <param name="dwEnabledOptions"></param>
        /// <returns></returns>
        public static int SetInterfaceSafetyOptions(
            ref Guid riid,
            int dwOptionSetMask,
            int dwEnabledOptions)
        {
            int Rslt = E_FAIL;
            string strGUID = riid.ToString("B").ToUpperOrdinal();
            switch (strGUID)
            {
                case _IID_IDispatch:
                case _IID_IDispatchEx:
                    if (_fSafeForScripting &&
                        ((dwEnabledOptions & dwOptionSetMask) == INTERFACESAFE_FOR_UNTRUSTED_CALLER))
                        Rslt = S_OK;
                    break;
                case _IID_IPersistStorage:
                case _IID_IPersistStream:
                case _IID_IPersistPropertyBag:
                    if (_fSafeForInitializing &&
                        ((dwEnabledOptions & dwOptionSetMask) == INTERFACESAFE_FOR_UNTRUSTED_DATA))
                        Rslt = S_OK;
                    break;
                default:
                    Rslt = E_NOINTERFACE;
                    break;
            }
            return Rslt;
        }

        int IObjectSafety.GetInterfaceSafetyOptions(
            ref Guid riid,
            ref int pdwSupportedOptions,
            ref int pdwEnabledOptions)
        {
            return GetInterfaceSafetyOptions(
                ref riid,
                ref pdwSupportedOptions,
                ref pdwEnabledOptions);
        }

        int IObjectSafety.SetInterfaceSafetyOptions(
            ref Guid riid,
            int dwOptionSetMask,
            int dwEnabledOptions)
        {
            return SetInterfaceSafetyOptions(
                ref riid,
                dwOptionSetMask,
                dwEnabledOptions);
        }
    }
}
