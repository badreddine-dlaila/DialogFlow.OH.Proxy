// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Openhab.Clinet.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Type
    {
        /// <summary>
        /// Initializes a new instance of the Type class.
        /// </summary>
        public Type()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Type class.
        /// </summary>
        public Type(string typeName = default(string))
        {
            TypeName = typeName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "typeName")]
        public string TypeName { get; set; }

    }
}
