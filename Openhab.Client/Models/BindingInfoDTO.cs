// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Openhab.Clinet.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class BindingInfoDTO
    {
        /// <summary>
        /// Initializes a new instance of the BindingInfoDTO class.
        /// </summary>
        public BindingInfoDTO()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BindingInfoDTO class.
        /// </summary>
        public BindingInfoDTO(string author = default(string), string description = default(string), string id = default(string), string name = default(string), string configDescriptionURI = default(string))
        {
            Author = author;
            Description = description;
            Id = id;
            Name = name;
            ConfigDescriptionURI = configDescriptionURI;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "configDescriptionURI")]
        public string ConfigDescriptionURI { get; set; }

    }
}
