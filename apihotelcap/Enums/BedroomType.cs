using System.ComponentModel;

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
