using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsgoItemDataType
{
    /// <summary>
    ///     Store attribute info that has been read from item_games.txt
    /// </summary>
    /// <remarks>
    ///     
    /// </remarks>
    public struct AttributeInfo
    {
        public static string KeyName = "attributes";
        public static string SubKeyCodedName = "name";
        public static string SubKeyRealName = "description_string";
        public static string IsIntegerStr = "stored_as_integer";
        public static string IsStringStr = "attribute_type";

        /// <summary>
        ///     Attribute's ID
        /// </summary>
        /// <value>
        ///     <para>
        ///         Valid int value of "attributes" key from item_games.txt
        ///     </para>
        /// </value>
        /// <remarks>
        ///     
        /// </remarks>
        public int CodedValue
        {
            get;
            set;
        }

        /// <summary>
        ///     Attribute short description
        /// </summary>
        /// <value>
        ///     <para>
        ///         Valid int value taken from "name" subkey of "attributes" from item_games.txt
        ///     </para>
        /// </value>
        /// <remarks>
        ///     
        /// </remarks>
        public string CodedName
        {
            get;
            set;
        }

        public string RealName
        {
            get;
            set;
        }

        /// <summary>
        ///     Information whether value is stored as integer or float
        /// </summary>
        /// <value>
        ///     <para>
        ///         If "stored_as_integer" subkey of "attributes" from item_games.txt is 1, it's true
        ///     </para>
        /// </value>
        /// <remarks>
        ///     
        /// </remarks>
        public bool IsInteger
        {
            get;
            set;
        }

        public bool IsString { get; set; }

        public override string ToString()
        {
            return CodedName;
        }
    }
}
