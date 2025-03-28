using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace canva.ENUM
{

    [DataContract]
    public enum EAppOrientation
    {

        [EnumMember] VERTICAL,
        [EnumMember] HORIZONTAL,

    }
}
