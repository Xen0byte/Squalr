// --------------------------------------------------------------------------------------------
// Version: MPL 1.1/GPL 2.0/LGPL 2.1
// 
// The contents of this file are subject to the Mozilla Public License Version
// 1.1 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
// http://www.mozilla.org/MPL/
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
// for the specific language governing rights and limitations under the
// License.
// 
// <remarks>
// Generated by IDLImporter from file nsIProtocolProxyService.idl
// 
// You should use these interfaces when you access the COM objects defined in the mentioned
// IDL/IDH file.
// </remarks>
// --------------------------------------------------------------------------------------------
namespace Gecko
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;


    /// <summary>
    /// nsIProtocolProxyService provides methods to access information about
    /// various network proxies.
    /// </summary>
    [ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("e77c642b-026f-41ce-9b23-f829a6e3f300")]
	public interface nsIProtocolProxyService
	{
		
		/// <summary>
        /// This method returns via callback a nsIProxyInfo instance that identifies
        /// a proxy to be used for loading the given URI.  Otherwise, this method returns
        /// null indicating that a direct connection should be used.
        ///
        /// @param aURI
        /// The URI to test.
        /// @param aFlags
        /// A bit-wise combination of the RESOLVE_ flags defined above.  Pass
        /// 0 to specify the default behavior.  Any additional bits that do
        /// not correspond to a RESOLVE_ flag are reserved for future use.
        /// @param aCallback
        /// The object to be notified when the result is available.
        ///
        /// @return An object that can be used to cancel the asychronous operation.
        /// If canceled, the cancelation status (aReason) will be forwarded
        /// to the callback's onProxyAvailable method via the aStatus param.
        ///
        /// NOTE: If this proxy is unavailable, getFailoverForProxy may be called
        /// to determine the correct secondary proxy to be used.
        ///
        /// NOTE: If the protocol handler for the given URI supports
        /// nsIProxiedProtocolHandler, then the nsIProxyInfo instance returned from
        /// resolve may be passed to the newProxiedChannel method to create a
        /// nsIChannel to the given URI that uses the specified proxy.
        ///
        /// NOTE: However, if the nsIProxyInfo type is "http", then it means that
        /// the given URI should be loaded using the HTTP protocol handler, which
        /// also supports nsIProxiedProtocolHandler.
        ///
        /// @see nsIProxiedProtocolHandler::newProxiedChannel
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsICancelable AsyncResolve([MarshalAs(UnmanagedType.Interface)] nsIURI aURI, uint aFlags, [MarshalAs(UnmanagedType.Interface)] nsIProtocolProxyCallback aCallback);
		
		/// <summary>
        /// This method may be called to construct a nsIProxyInfo instance from
        /// the given parameters.  This method may be useful in conjunction with
        /// nsISocketTransportService::createTransport for creating, for example,
        /// a SOCKS connection.
        ///
        /// @param aType
        /// The proxy type.  This is a string value that identifies the proxy
        /// type.  Standard values include:
        /// "http"    - specifies a HTTP proxy
        /// "socks"   - specifies a SOCKS version 5 proxy
        /// "socks4"  - specifies a SOCKS version 4 proxy
        /// "direct"  - specifies a direct connection (useful for failover)
        /// The type name is case-insensitive.  Other string values may be
        /// possible, and new types may be defined by a future version of
        /// this interface.
        /// @param aHost
        /// The proxy hostname or IP address.
        /// @param aPort
        /// The proxy port.
        /// @param aFlags
        /// Flags associated with this connection.  See nsIProxyInfo.idl
        /// for currently defined flags.
        /// @param aFailoverTimeout
        /// Specifies the length of time (in seconds) to ignore this proxy if
        /// this proxy fails.  Pass UINT32_MAX to specify the default
        /// timeout value, causing nsIProxyInfo::failoverTimeout to be
        /// assigned the default value.
        /// @param aFailoverProxy
        /// Specifies the next proxy to try if this proxy fails.  This
        /// parameter may be null.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIProxyInfo NewProxyInfo([MarshalAs(UnmanagedType.LPStruct)] nsACStringBase aType, [MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aHost, int aPort, uint aFlags, uint aFailoverTimeout, [MarshalAs(UnmanagedType.Interface)] nsIProxyInfo aFailoverProxy);
		
		/// <summary>
        /// If the proxy identified by aProxyInfo is unavailable for some reason,
        /// this method may be called to access an alternate proxy that may be used
        /// instead.  As a side-effect, this method may affect future result values
        /// from resolve/asyncResolve as well as from getFailoverForProxy.
        ///
        /// @param aProxyInfo
        /// The proxy that was unavailable.
        /// @param aURI
        /// The URI that was originally passed to resolve/asyncResolve.
        /// @param aReason
        /// The error code corresponding to the proxy failure.  This value
        /// may be used to tune the delay before this proxy is used again.
        ///
        /// @throw NS_ERROR_NOT_AVAILABLE if there is no alternate proxy available.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIProxyInfo GetFailoverForProxy([MarshalAs(UnmanagedType.Interface)] nsIProxyInfo aProxyInfo, [MarshalAs(UnmanagedType.Interface)] nsIURI aURI, int aReason);
		
		/// <summary>
        /// This method may be used to register a proxy filter instance.  Each proxy
        /// filter is registered with an associated position that determines the
        /// order in which the filters are applied (starting from position 0).  When
        /// resolve/asyncResolve is called, it generates a list of proxies for the
        /// given URI, and then it applies the proxy filters.  The filters have the
        /// opportunity to modify the list of proxies.
        ///
        /// If two filters register for the same position, then the filters will be
        /// visited in the order in which they were registered.
        ///
        /// If the filter is already registered, then its position will be updated.
        ///
        /// After filters have been run, any disabled or disallowed proxies will be
        /// removed from the list.  A proxy is disabled if it had previously failed-
        /// over to another proxy (see getFailoverForProxy).  A proxy is disallowed,
        /// for example, if it is a HTTP proxy and the nsIProtocolHandler for the
        /// queried URI does not permit proxying via HTTP.
        ///
        /// If a nsIProtocolHandler disallows all proxying, then filters will never
        /// have a chance to intercept proxy requests for such URLs.
        ///
        /// @param aFilter
        /// The nsIProtocolProxyFilter instance to be registered.
        /// @param aPosition
        /// The position of the filter.
        ///
        /// NOTE: It is possible to construct filters that compete with one another
        /// in undesirable ways.  This API does not attempt to protect against such
        /// problems.  It is recommended that any extensions that choose to call
        /// this method make their position value configurable at runtime (perhaps
        /// via the preferences service).
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void RegisterFilter([MarshalAs(UnmanagedType.Interface)] nsIProtocolProxyFilter aFilter, uint aPosition);
		
		/// <summary>
        /// This method may be used to unregister a proxy filter instance.  All
        /// filters will be automatically unregistered at XPCOM shutdown.
        ///
        /// @param aFilter
        /// The nsIProtocolProxyFilter instance to be unregistered.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void UnregisterFilter([MarshalAs(UnmanagedType.Interface)] nsIProtocolProxyFilter aFilter);
		
		/// <summary>
        /// This attribute specifies the current type of proxy configuration.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetProxyConfigTypeAttribute();
	}
	
	/// <summary>nsIProtocolProxyServiceConsts </summary>
	public class nsIProtocolProxyServiceConsts
	{
		
		// <summary>
        // When the proxy configuration is manual this flag may be passed to the
        // resolve and asyncResolve methods to request to prefer the SOCKS proxy
        // to HTTP ones.
        // </summary>
		public const ulong RESOLVE_PREFER_SOCKS_PROXY = 1<<1;
		
		// <summary>
        // When the proxy configuration is manual this flag may be passed to the
        // resolve and asyncResolve methods to request to not analyze the uri's
        // scheme specific proxy. When this flag is set the main HTTP proxy is the
        // preferred one.
        //
        // NOTE: if RESOLVE_PREFER_SOCKS_PROXY is set then the SOCKS proxy is
        // the preferred one.
        //
        // NOTE: if RESOLVE_PREFER_HTTPS_PROXY is set then the HTTPS proxy
        // is the preferred one.
        // </summary>
		public const ulong RESOLVE_IGNORE_URI_SCHEME = 1<<2;
		
		// <summary>
        // When the proxy configuration is manual this flag may be passed to the
        // resolve and asyncResolve methods to request to prefer the HTTPS proxy
        // to the others HTTP ones.
        //
        // NOTE: RESOLVE_PREFER_SOCKS_PROXY takes precedence over this flag.
        //
        // NOTE: This flag implies RESOLVE_IGNORE_URI_SCHEME.
        // </summary>
		public const ulong RESOLVE_PREFER_HTTPS_PROXY = (1<<3)|RESOLVE_IGNORE_URI_SCHEME;
		
		// <summary>
        // When the proxy configuration is manual this flag may be passed to the
        // resolve and asyncResolve methods to that all methods will be tunneled via
        // CONNECT through the http proxy.
        // </summary>
		public const ulong RESOLVE_ALWAYS_TUNNEL = (1<<4);
		
		// <summary>
        // These values correspond to the possible integer values for the
        // network.proxy.type preference.
        // </summary>
		public const ulong PROXYCONFIG_DIRECT = 0;
		
		// 
		public const ulong PROXYCONFIG_MANUAL = 1;
		
		// 
		public const ulong PROXYCONFIG_PAC = 2;
		
		// 
		public const ulong PROXYCONFIG_WPAD = 4;
		
		// 
		public const ulong PROXYCONFIG_SYSTEM = 5;
	}
}
