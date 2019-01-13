// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Openhab.Clinet.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ConfigDescriptionParameterGroupDTO
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ConfigDescriptionParameterGroupDTO class.
        /// </summary>
        public ConfigDescriptionParameterGroupDTO()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ConfigDescriptionParameterGroupDTO class.
        /// </summary>
        public ConfigDescriptionParameterGroupDTO(string name = default(string), string context = default(string), bool? advanced = default(bool?), string label = default(string), string description = default(string))
        {
            Name = name;
            Context = context;
            Advanced = advanced;
            Label = label;
            Description = description;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "context")]
        public string Context { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "advanced")]
        public bool? Advanced { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

    }
}