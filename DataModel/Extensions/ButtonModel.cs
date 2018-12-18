// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension to the Entity Framework auto generated ButtonModel class
    /// </summary>
    public partial class ButtonModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonModel"/> class. 
        /// </summary>
        /// <param name="baseControl">Enum describing a default button</param>
        /// <param name="row">Row in the control panel where the control positioned</param>
        /// <param name="col">Column in the control panel where the control positioned</param>
        public ButtonModel(PresetControl baseControl, int row, int col)
        {
            X = col;
            Y = row;
            //// BaseControlPreset = baseControl; TODO uncomment when new field added to ButtonModel
        }

        /// <summary>
        /// Creates a list of control models from paired control actions and labels
        /// </summary>
        /// <param name="actionTuples">Tuples containing control action and text for action label</param>
        /// <returns>List of control models for the button</returns>
        public List<ControlModel> CreateControlModelsFromActions(List<Tuple<ControlAction, string>> actionTuples)
        {
            return actionTuples.Select(tuple => new ControlModel { ActionIdentifier = tuple.Item1, Label = tuple.Item2 }).ToList();
        }
    }
}
