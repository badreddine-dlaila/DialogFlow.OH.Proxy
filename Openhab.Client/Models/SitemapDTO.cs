// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Openhab.Clinet.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class SitemapDTO
    {
        /// <summary>
        /// Initializes a new instance of the SitemapDTO class.
        /// </summary>
        public SitemapDTO()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SitemapDTO class.
        /// </summary>
        public SitemapDTO(string name = default(string), string icon = default(string), string label = default(string), string link = default(string), PageDTO homepage = default(PageDTO))
        {
            Name = name;
            Icon = icon;
            Label = label;
            Link = link;
            Homepage = homepage;
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
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "homepage")]
        public PageDTO Homepage { get; set; }

    }
}
