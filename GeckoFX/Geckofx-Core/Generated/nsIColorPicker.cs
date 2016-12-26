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
// Generated by IDLImporter from file nsIColorPicker.idl
// 
// You should use these interfaces when you access the COM objects defined in the mentioned
// IDL/IDH file.
// </remarks>
// --------------------------------------------------------------------------------------------
namespace Gecko
{
	using System;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	using System.Runtime.CompilerServices;
	
	
	/// <summary>
    /// nsIColorPicker is representing colors as strings because the internal
    /// representation will depend on the underlying backend.
    /// The format of the colors taken in input and returned will always follow the
    /// format of the <input type='color'> value as described in the HTML
    /// specifications.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("d2ce78d1-40b5-49d1-b66d-5801fcb9a385")]
	public interface nsIColorPickerShownCallback
	{
		
		/// <summary>
        /// Callback called when the color picker requests a color update.
        /// This callback can not be called after done() was called.
        /// When this callback is used, the consumer can assume that the color value has
        /// changed.
        ///
        /// @param  color  The new selected color value following the format specifed on
        /// top of this file.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Update([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase color);
		
		/// <summary>
        /// Callback called when the color picker is dismissed.
        /// When this callback is used, the color might have changed or could stay the
        /// same.
        /// If the color has not changed, the color parameter will be the empty string.
        ///
        /// @param  color  The new selected color value following the format specifed on
        /// top of this file or the empty string.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Done([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase color);
	}
	
	/// <summary>nsIColorPicker </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("3c3bdcce-54b1-4ae2-8647-1a8d4712ef2e")]
	public interface nsIColorPicker
	{
		
		/// <summary>
        /// Initialize the color picker widget. The color picker will not be shown until
        /// open() is called.
        /// If the backend doesn't support setting a title to the native color picker
        /// widget, the title parameter might be ignored.
        /// If the initialColor parameter does not follow the format specified on top of
        /// this file, the behavior will be unspecified. The initialColor could be the
        /// one used by the underlying backend or an arbitrary one. The backend could
        /// also assert.
        ///
        /// @param      parent       nsIDOMWindow parent. This dialog will be dependent
        /// on this parent. parent must be non-null.
        /// @param      title        The title for the color picker widget.
        /// @param      initialColor The color to show when the widget is opened. The
        /// parameter has to follow the format specified on top
        /// of this file.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Init([MarshalAs(UnmanagedType.Interface)] nsIDOMWindow parent, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase title, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "Gecko.CustomMarshalers.AStringMarshaler")] nsAStringBase initialColor);
		
		/// <summary>
        /// Opens the color dialog asynchrounously.
        /// The results are provided via the callback object.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Open([MarshalAs(UnmanagedType.Interface)] nsIColorPickerShownCallback aColorPickerShownCallback);
	}
}
