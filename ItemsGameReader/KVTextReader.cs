using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ValveKvReader
{
    class KVTextReader : StreamReader
    {
        static Dictionary<char, char> escapedMapping = new Dictionary<char, char>
        {
            { 'n', '\n' },
            { 'r', '\r' },
            { 't', '\t' },
            // todo: any others?
        };

        public KVTextReader(KeyValue kv, Stream input)
            : base(input)
        {
            bool wasQuoted;
            bool wasConditional;

            KeyValue currentKey = kv;

            do
            {
                // bool bAccepted = true;

                string s = ReadToken(out wasQuoted, out wasConditional);

                if (string.IsNullOrEmpty(s))
                    break;

                if (currentKey == null)
                {
                    currentKey = new KeyValue(s);
                }
                else
                {
                    currentKey.Name = s;
                }

                s = ReadToken(out wasQuoted, out wasConditional);

                if (wasConditional)
                {
                    // bAccepted = ( s == "[$WIN32]" );

                    // Now get the '{'
                    s = ReadToken(out wasQuoted, out wasConditional);
                }

                if (s.StartsWith("{") && !wasQuoted)
                {
                    // header is valid so load the file
                    currentKey.RecursiveLoadFromBuffer(this);
                }
                else
                {
                    throw new Exception("LoadFromBuffer: missing {");
                }

                currentKey = null;
            }
            while (!EndOfStream);
        }

        private void EatWhiteSpace()
        {
            while (!EndOfStream)
            {
                if (!Char.IsWhiteSpace((char)Peek()))
                {
                    break;
                }

                Read();
            }
        }

        private bool EatCPPComment()
        {
            if (!EndOfStream)
            {
                char next = (char)Peek();
                if (next == '/')
                {
                    Read();
                    if (next == '/')
                    {
                        ReadLine();
                        return true;
                    }
                    else
                    {
                        throw new Exception("BARE / WHAT ARE YOU DOIOIOIINODGNOIGNONGOIGNGGGGGGG");
                    }
                }

                return false;
            }

            return false;
        }

        public string ReadToken(out bool wasQuoted, out bool wasConditional)
        {
            wasQuoted = false;
            wasConditional = false;

            while (true)
            {
                EatWhiteSpace();

                if (EndOfStream)
                {
                    return null;
                }

                if (!EatCPPComment())
                {
                    break;
                }
            }

            if (EndOfStream)
                return null;

            char next = (char)Peek();
            if (next == '"')
            {
                wasQuoted = true;

                // "
                Read();

                var sb = new StringBuilder();
                while (!EndOfStream)
                {
                    if (Peek() == '\\')
                    {
                        Read();

                        char escapedChar = (char)Read();
                        char replacedChar;

                        if (escapedMapping.TryGetValue(escapedChar, out replacedChar))
                            sb.Append(replacedChar);
                        else
                            sb.Append(escapedChar);

                        continue;
                    }

                    if (Peek() == '"')
                        break;

                    sb.Append((char)Read());
                }

                // "
                Read();

                return sb.ToString();
            }

            if (next == '{' || next == '}')
            {
                Read();
                return next.ToString();
            }

            bool bConditionalStart = false;
            int count = 0;
            var ret = new StringBuilder();
            while (!EndOfStream)
            {
                next = (char)Peek();

                if (next == '"' || next == '{' || next == '}')
                    break;

                if (next == '[')
                    bConditionalStart = true;

                if (next == ']' && bConditionalStart)
                    wasConditional = true;

                if (Char.IsWhiteSpace(next))
                    break;

                if (count < 1023)
                {
                    ret.Append(next);
                }
                else
                {
                    throw new Exception("ReadToken overflow");
                }

                Read();
            }

            return ret.ToString();
        }
    }
}
