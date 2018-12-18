// <copyright file="LoginFailureInfo.cs" company="Laborie">
// Copyright (c) Laborie. All rights reserved.
// </copyright>

namespace Laborie.Synergy.DataModel
{
    using System;

    /// <summary>
    /// Extension to the Entity Framework auto generated <see cref="LoginFailureInfo"/> class
    /// </summary>
    public partial class LoginFailureInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginFailureInfo"/> class. 
        /// </summary>
        public LoginFailureInfo()
        {
            Id = 1;
            MachineName = Environment.MachineName;
        }
    }
}
