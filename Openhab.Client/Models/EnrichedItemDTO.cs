// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Openhab.Clinet.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class EnrichedItemDTO
    {
        /// <summary>
        /// Initializes a new instance of the EnrichedItemDTO class.
        /// </summary>
        public EnrichedItemDTO()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the EnrichedItemDTO class.
        /// </summary>
        public EnrichedItemDTO(string type = default(string), string name = default(string), string label = default(string), string category = default(string), IList<string> tags = default(IList<string>), IList<string> groupNames = default(IList<string>), string link = default(string), string state = default(string), string transformedState = default(string), StateDescription stateDescription = default(StateDescription), IDictionary<string, object> metadata = default(IDictionary<string, object>), bool? editable = default(bool?))
        {
            Type = type;
            Name = name;
            Label = label;
            Category = category;
            Tags = tags;
            GroupNames = groupNames;
            Link = link;
            State = state;
            TransformedState = transformedState;
            StateDescription = stateDescription;
            Metadata = metadata;
            Editable = editable;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IList<string> Tags { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "groupNames")]
        public IList<string> GroupNames { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "transformedState")]
        public string TransformedState { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "stateDescription")]
        public StateDescription StateDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "metadata")]
        public IDictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "editable")]
        public bool? Editable { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Tags != null)
            {
                if (Tags.Count != System.Linq.Enumerable.Count(System.Linq.Enumerable.Distinct(Tags)))
                {
                    throw new ValidationException(ValidationRules.UniqueItems, "Tags");
                }
            }
        }
    }
}
