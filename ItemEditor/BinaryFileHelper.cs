using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ItemEditor
{
    public static class BinaryFileHelper
    {
        /// <summary>
        ///     Read from stream and transform into an object based on a certain struct
        /// </summary>
        /// <param name="stream" type="System.IO.Stream">
        ///     <para>
        ///         A stream
        ///     </para>
        /// </param>
        /// <param name="t" type="System.Type">
        ///     <para>
        ///         Type of object to be transform
        ///     </para>
        /// </param>
        /// <returns>
        ///     Transformed object
        /// </returns>
        /// <remarks>
        ///     Warning! It's possible it doesn't work on class
        /// </remarks>
        public static object Read(Stream stream, Type t)
        {
            byte[] buffer = new byte[Marshal.SizeOf(t)];
            for (int read = 0; read < buffer.Length; read += stream.Read(buffer, read, buffer.Length)) ;
            GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            object o = Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), t);
            gcHandle.Free();
            return o;
        }

        /// <summary>
        ///     Write an Object into stream as array of bytes (Big Endian)
        /// </summary>
        /// <param name="stream" type="System.IO.Stream">
        ///     <para>
        ///         Stream to be written
        ///     </para>
        /// </param>
        /// <param name="o" type="object">
        ///     <para>
        ///         Object to be written
        ///     </para>
        /// </param>
        public static void Write(Stream stream, object o)
        {
            int objectSize = Marshal.SizeOf(o.GetType());
            byte[] buffer = new byte[objectSize];
            GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(o, gcHandle.AddrOfPinnedObject(), true);
            stream.Write(buffer, 0, buffer.Length);
            gcHandle.Free();
        }
    }
}
