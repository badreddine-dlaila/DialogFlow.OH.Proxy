// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Openhab.Clinet.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class StrippedThingTypeDTO
    {
        /// <summary>
        /// Initializes a new instance of the StrippedThingTypeDTO class.
        /// </summary>
        public StrippedThingTypeDTO()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the StrippedThingTypeDTO class.
        /// </summary>
        public StrippedThingTypeDTO(string uID = default(string), string label = default(string), string description = default(string), string category = default(string), bool? listed = default(bool?), IList<string> supportedBridgeTypeUIDs = default(IList<string>), bool? bridge = default(bool?))
        {
            UID = uID;
            Label = label;
            Description = description;
            Category = category;
            Listed = listed;
            SupportedBridgeTypeUIDs = supportedBridgeTypeUIDs;
            Bridge = bridge;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UID")]
        public string UID { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "listed")]
        public bool? Listed { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "supportedBridgeTypeUIDs")]
        public IList<string> SupportedBridgeTypeUIDs { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bridge")]
        public bool? Bridge { get; set; }

    }
}
