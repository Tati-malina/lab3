using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace lab3
{
    [Serializable]
    public class CustomString : IAddable, ISerializable
    {

        public string str;
        public int stringLength;

        public string GetStringValue()
        {
            return str;
        }

        public CustomString()
        {
            str = string.Empty;
            stringLength = str.Length;
        }
        public CustomString(string value)
        {
            str = value;
            stringLength = str.Length;
        }
        public CustomString(CustomString str)
        {
            this.str = str.str;
            stringLength = str.stringLength;
        }


        public void AddString(string addableString)
        {
            str += addableString;
        }

        public CustomString (SerializationInfo info, StreamingContext context)
        {
            str = info.GetString("CUSTOM_STR");
            stringLength = info.GetInt32("CUSTOM_STRING_LENGTH");
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CUSTOM_STR", str);
            info.AddValue("CUSTOM_STRING_LENGTH", stringLength);
        }
    }
}

