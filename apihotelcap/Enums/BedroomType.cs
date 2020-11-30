using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Enums
{
    public class BedroomType
    {
        public enum BedroomTypeValues
        {
            /// <summary>
            /// Active
            /// </summary>
            [Description("Active")]
            A,

            /// <summary>
            /// Inactive
            /// </summary>
            [Description("Inactive")]
            I
        }
    }
}
