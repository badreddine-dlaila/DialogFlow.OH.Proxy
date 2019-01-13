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

    public partial class ItemHistoryDTO
    {
        /// <summary>
        /// Initializes a new instance of the ItemHistoryDTO class.
        /// </summary>
        public ItemHistoryDTO()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ItemHistoryDTO class.
        /// </summary>
        public ItemHistoryDTO(string name = default(string), string totalrecords = default(string), string datapoints = default(string), IList<HistoryDataBean> data = default(IList<HistoryDataBean>))
        {
            Name = name;
            Totalrecords = totalrecords;
            Datapoints = datapoints;
            Data = data;
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
        [JsonProperty(PropertyName = "totalrecords")]
        public string Totalrecords { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "datapoints")]
        public string Datapoints { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public IList<HistoryDataBean> Data { get; set; }

    }
}