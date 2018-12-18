// <copyright file="IConsumableValidator.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.BarcodeTraceability
{
    using System.Collections.Generic;
    using DataModel;
    using Model;

    public interface IConsumableValidator
    {
        bool Validate(BarcodeModel consumableModel, ReadPatients_Result currentPatient, IEnumerable<BarcodeModel> barcodeList, IEnumerable<InvestigationConsumable> requiredConsumables);
    }
}