// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Represent the element in a given report template
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class QualityControlStepModel
    {
        /// <summary>
        /// Gets or sets the current quality control step element id.
        /// </summary>
        [JsonProperty]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the current tree item width.
        /// </summary>
        [JsonProperty]
        public double TreeItemWidth { get; set; }

        /// <summary>
        /// Gets or sets the current tree item height.
        /// </summary>
        [JsonProperty]
        public double TreeItemHeight { get; set; }

        /// <summary>
        /// Gets or sets the margin top of tree vertical line
        /// </summary>
        [JsonProperty]
        public double MarginTop { get; set; }

        /// <summary>
        /// Gets or sets the margin left of tree vertical line
        /// </summary>
        [JsonProperty]
        public double MarginLeft { get; set; }

        /// <summary>
        /// Gets or sets the margin bottom of tree vertical line
        /// </summary>
        [JsonProperty]
        public double MarginBottom { get; set; }

        /// <summary>
        /// Gets or sets the margin right of tree vertical line
        /// </summary>
        [JsonProperty]
        public double MarginRight { get; set; }

        /// <summary>
        /// Gets or sets the margin of tree vertical height
        /// </summary>
        [JsonProperty]
        public double TreeVerticalHeight { get; set; }

        /// <summary>
        /// Gets or sets the current step status.
        /// </summary>
        [JsonProperty]
        public QualityStepModelStatus StepStatus { get; set; }

        /// <summary>
        /// Gets or sets the tag of the current step type
        /// </summary>
        [JsonProperty]
        public QualityStepModelTypes Type { get; set; }

        /// <summary>
        /// Gets or sets the child elements
        /// </summary>
        [JsonProperty]
        public List<QualityControlStepModel> Children { get; set; }

        /// <summary>
        /// Gets or sets the parent Id of the current quality control step
        /// </summary>
        [JsonProperty]
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets the display text of current quality control step. 
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the step is selected on the treeview node.
        /// </summary>
        public bool IsSelected { get; set; }

        public IEnumerable<QualityControlStepModel> Descendants()
        {
            var children = new Stack<QualityControlStepModel>(new[] { this });
            while (children.Any())
            {
                var child = children.Pop();
                yield return child;
                if (child.Children == null) continue;
                foreach (var item in child.Children) children.Push(item);
            }
        }
    }
}
