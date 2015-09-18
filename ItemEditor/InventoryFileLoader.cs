using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ItemEditor
{
    /// <summary>
    ///     Use to load items_730.bin, 1st step before doing anything
    /// </summary>
    /// <remarks>
    ///     
    /// </remarks>
    public class InventoryFileLoader
    {
        private InventoryManager _manager;

        public InventoryManager Manager
        {
            get { return _manager; }
            private set { _manager = value; }
        }

        private SSEHeader _header;

        public InventoryFileLoader(string filePath)
        {
            FileLoadResult = this.LoadFile(filePath);

            if (FileLoadResult == LoadFileReturnValue.ValidAndUseable)
            {
                Manager = new InventoryManager(filePath);
            }
        }

        /// <summary>
        ///     Verify whether file items_730.bin is valid
        /// </summary>
        /// <param name="stream" type="System.IO.Stream">
        ///     <para>
        ///         Stream of items_730.bin
        ///     </para>
        /// </param>
        /// 
        /// <returns>
        ///     True if file is valid, false otherwise
        /// </returns>
        internal bool VerifyHeader(Stream file)
        {
            try
            {
                using (file)
                {
                    _header = (SSEHeader)BinaryFileHelper.Read(file, typeof(SSEHeader));
                }

                if (_header.FileHeader.Equals("SSEItem", StringComparison.CurrentCulture)
                    && _header.ItemCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                return false;
            }
        }

        /// <summary>
        ///     Load items_730.bin
        /// </summary>
        /// <param name="filePath" type="string">
        ///     <para>
        ///         items_730.bin path obviously
        ///     </para>
        /// </param>
        /// <returns>
        ///     Value of verify file result
        /// </returns>
        private LoadFileReturnValue LoadFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    FileInfo fi = new FileInfo(Path.GetFullPath(filePath));
                    
                    if (fi.IsReadOnly)
                    {
                        return LoadFileReturnValue.ReadOnly;
                    }
                    else
                    {
                        using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                        {
                            bool isFileValid = this.VerifyHeader(stream);

                            if (isFileValid)
                            {
                                return LoadFileReturnValue.ValidAndUseable;
                            }
                            else
                            {
                                return LoadFileReturnValue.NotValid;
                            }
                        }
                    }
                }
                else
                {
                    return LoadFileReturnValue.NotExist;
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Close()
        {
            _manager.Close();
        }

        public LoadFileReturnValue FileLoadResult
        { 
            get; 
            private set; 
        }
    }

    public enum LoadFileReturnValue
    {
        ValidAndUseable = 0,
        ReadOnly,
        ValidHeaderBrokenInside,
        NotValid,
        NotExist
    }
}
