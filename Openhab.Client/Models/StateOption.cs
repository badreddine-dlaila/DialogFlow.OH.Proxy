// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Openhab.Clinet.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class StateOption
    {
        /// <summary>
        /// Initializes a new instance of the StateOption class.
        /// </summary>
        public StateOption()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the StateOption class.
        /// </summary>
        public StateOption(string value = default(string), string label = default(string))
        {
            Value = value;
            Label = label;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

    }
}