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
// Generated by IDLImporter from file nsISupportsPriority.idl
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
    /// This interface exposes the general notion of a scheduled object with a
    /// integral priority value.  Following UNIX conventions, smaller (and possibly
    /// negative) values have higher priority.
    ///
    /// This interface does not strictly define what happens when the priority of an
    /// object is changed.  An implementation of this interface is free to define
    /// the side-effects of changing the priority of an object.  In some cases,
    /// changing the priority of an object may be disallowed (resulting in an
    /// exception being thrown) or may simply be ignored.
    /// </summary>
    [ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("aa578b44-abd5-4c19-8b14-36d4de6fdc36")]
	public interface nsISupportsPriority
	{
		
		/// <summary>
        /// This attribute may be modified to change the priority of this object.  The
        /// implementation of this interface is free to truncate a given priority
        /// value to whatever limits are appropriate.  Typically, this attribute is
        /// initialized to PRIORITY_NORMAL, but implementations may choose to assign a
        /// different initial value.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetPriorityAttribute();
		
		/// <summary>
        /// This attribute may be modified to change the priority of this object.  The
        /// implementation of this interface is free to truncate a given priority
        /// value to whatever limits are appropriate.  Typically, this attribute is
        /// initialized to PRIORITY_NORMAL, but implementations may choose to assign a
        /// different initial value.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetPriorityAttribute(int aPriority);
		
		/// <summary>
        /// This method adjusts the priority attribute by a given delta.  It helps
        /// reduce the amount of coding required to increment or decrement the value
        /// of the priority attribute.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void AdjustPriority(int delta);
	}
	
	/// <summary>nsISupportsPriorityConsts </summary>
	public class nsISupportsPriorityConsts
	{
		
		// <summary>
        // Typical priority values.
        // </summary>
		public const long PRIORITY_HIGHEST = -20;
		
		// 
		public const long PRIORITY_HIGH = -10;
		
		// 
		public const long PRIORITY_NORMAL = 0;
		
		// 
		public const long PRIORITY_LOW = 10;
		
		// 
		public const long PRIORITY_LOWEST = 20;
	}
}
