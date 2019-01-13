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

    public partial class WidgetDTO
    {
        /// <summary>
        /// Initializes a new instance of the WidgetDTO class.
        /// </summary>
        public WidgetDTO()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WidgetDTO class.
        /// </summary>
        public WidgetDTO(string widgetId = default(string), string type = default(string), string name = default(string), string label = default(string), string icon = default(string), string labelcolor = default(string), string valuecolor = default(string), IList<MappingDTO> mappings = default(IList<MappingDTO>), bool? switchSupport = default(bool?), int? sendFrequency = default(int?), string separator = default(string), int? refresh = default(int?), int? height = default(int?), double? minValue = default(double?), double? maxValue = default(double?), double? step = default(double?), string url = default(string), string encoding = default(string), string service = default(string), string period = default(string), bool? legend = default(bool?), string state = default(string), EnrichedItemDTO item = default(EnrichedItemDTO), PageDTO linkedPage = default(PageDTO), IList<WidgetDTO> widgets = default(IList<WidgetDTO>))
        {
            WidgetId = widgetId;
            Type = type;
            Name = name;
            Label = label;
            Icon = icon;
            Labelcolor = labelcolor;
            Valuecolor = valuecolor;
            Mappings = mappings;
            SwitchSupport = switchSupport;
            SendFrequency = sendFrequency;
            Separator = separator;
            Refresh = refresh;
            Height = height;
            MinValue = minValue;
            MaxValue = maxValue;
            Step = step;
            Url = url;
            Encoding = encoding;
            Service = service;
            Period = period;
            Legend = legend;
            State = state;
            Item = item;
            LinkedPage = linkedPage;
            Widgets = widgets;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "widgetId")]
        public string WidgetId { get; set; }

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
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "labelcolor")]
        public string Labelcolor { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "valuecolor")]
        public string Valuecolor { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mappings")]
        public IList<MappingDTO> Mappings { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "switchSupport")]
        public bool? SwitchSupport { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sendFrequency")]
        public int? SendFrequency { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "separator")]
        public string Separator { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "refresh")]
        public int? Refresh { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public int? Height { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "minValue")]
        public double? MinValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "maxValue")]
        public double? MaxValue { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "step")]
        public double? Step { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "encoding")]
        public string Encoding { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "service")]
        public string Service { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "period")]
        public string Period { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "legend")]
        public bool? Legend { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "item")]
        public EnrichedItemDTO Item { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "linkedPage")]
        public PageDTO LinkedPage { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "widgets")]
        public IList<WidgetDTO> Widgets { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Item != null)
            {
                Item.Validate();
            }
            if (Widgets != null)
            {
                foreach (var element in Widgets)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
