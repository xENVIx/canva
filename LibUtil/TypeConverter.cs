using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUtil
{
    public static class TypeConverter
    {

        public static List<byte> ConvertByteArrToList(byte[] bytes)
        {

            List<byte> res = new List<byte>();

            for (int i = 0; i < bytes.Length; i++)
            {
                res.Add(bytes[i]);
            }

            return res;

        }
    }
}
