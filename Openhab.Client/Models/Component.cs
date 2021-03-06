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

    public partial class Component
    {
        /// <summary>
        /// Initializes a new instance of the Component class.
        /// </summary>
        public Component()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Component class.
        /// </summary>
        public Component(IDictionary<string, object> config = default(IDictionary<string, object>), IDictionary<string, IList<Component>> slots = default(IDictionary<string, IList<Component>>), string name = default(string))
        {
            Config = config;
            Slots = slots;
            Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "config")]
        public IDictionary<string, object> Config { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "slots")]
        public IDictionary<string, IList<Component>> Slots { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

    }
}
