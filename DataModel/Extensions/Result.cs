// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;
    using System.Collections.Generic;

    public partial class Result
    {
        public IEnumerable<Result> Children => ChildrenPrivate;

        public int ChildrenCount
        {
            get
            {
                return ChildrenPrivate.Count;
            }
        }

        public void AddChild(Result child)
        {
            ChildrenPrivate.Add(child);
            child.Parent = this;
        }
    }
}
