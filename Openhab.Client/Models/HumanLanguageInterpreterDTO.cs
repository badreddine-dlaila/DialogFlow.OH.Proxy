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

    public partial class HumanLanguageInterpreterDTO
    {
        /// <summary>
        /// Initializes a new instance of the HumanLanguageInterpreterDTO
        /// class.
        /// </summary>
        public HumanLanguageInterpreterDTO()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the HumanLanguageInterpreterDTO
        /// class.
        /// </summary>
        public HumanLanguageInterpreterDTO(string id = default(string), string label = default(string), IList<string> locales = default(IList<string>))
        {
            Id = id;
            Label = label;
            Locales = locales;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "locales")]
        public IList<string> Locales { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Locales != null)
            {
                if (Locales.Count != System.Linq.Enumerable.Count(System.Linq.Enumerable.Distinct(Locales)))
                {
                    throw new ValidationException(ValidationRules.UniqueItems, "Locales");
                }
            }
        }
    }
}
