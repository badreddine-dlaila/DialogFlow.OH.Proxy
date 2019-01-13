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

    public partial class GroupItemDTO
    {
        /// <summary>
        /// Initializes a new instance of the GroupItemDTO class.
        /// </summary>
        public GroupItemDTO()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GroupItemDTO class.
        /// </summary>
        public GroupItemDTO(string type = default(string), string name = default(string), string label = default(string), string category = default(string), IList<string> tags = default(IList<string>), IList<string> groupNames = default(IList<string>), string groupType = default(string), GroupFunctionDTO function = default(GroupFunctionDTO))
        {
            Type = type;
            Name = name;
            Label = label;
            Category = category;
            Tags = tags;
            GroupNames = groupNames;
            GroupType = groupType;
            Function = function;
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
        [JsonProperty(PropertyName = "groupType")]
        public string GroupType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "function")]
        public GroupFunctionDTO Function { get; set; }

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
