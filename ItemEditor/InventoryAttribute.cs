using System;
using System.Runtime.InteropServices;

namespace ItemEditor
{
    /// <summary>
    ///     Handle file header structure
    /// </summary>
    /// <remarks>
    ///     
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 12, Pack = 1)]
    public struct SSEHeader
    {
        /// <summary>
        ///     It should be "SSEItem"
        /// </summary>
        /// <remarks>
        ///     
        /// </remarks>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
      	public string FileHeader;

        /// <summary>
        ///     Number of item inside items_730.bin
        /// </summary>
        /// <remarks>
        ///     
        /// </remarks>
        [MarshalAs(UnmanagedType.U4)]
        public int ItemCount;
    }
    
    /// <summary>
    ///     Header to recognize serialized protobuf item and the next one
    /// </summary>
    /// <remarks>
    ///     
    /// </remarks>
    public struct ItemData
    {
        /// <summary>
        ///     It will always filled by 1
        /// </summary>
        /// <remarks>
        ///     
        /// </remarks>
        public int Type;

        /// <summary>
        ///     Serialized protobuf item's length
        /// </summary>
        /// <remarks>
        ///     
        /// </remarks>
        public int Length;
    }
}
