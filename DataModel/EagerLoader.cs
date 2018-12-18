// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// This class touches all items in public list properties to ensure all elements have been loaded by Entity Framework.
    /// </summary>
    public static class EagerLoader
    {
        /// <summary>
        /// Touches all items in public list properties to ensure all elements have been loaded by Entity Framework
        /// </summary>
        /// <param name="subject">The target for eager loading</param>
        /// <param name="ignoreProperties">
        ///     The property names to ignore, Entity Framework creates navigational properties back and forth.
        ///     This property can be used to avoid loading too much by traversing in the wrong direction.
        /// </param>
        public static void Load(object subject, string[] ignoreProperties)
        {
            var processedObjects = new HashSet<object>();
            LoadInternal(ref processedObjects, subject, ignoreProperties);
        }

        private static void LoadInternal(ref HashSet<object> processedObjects, object subject, string[] ignoreProperties)
        {
            if (subject == null)
                return;

            if (processedObjects.Contains(subject))
                return;

            processedObjects.Add(subject);

            var type = subject.GetType();
            var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.PropertyType == typeof(string) || ignoreProperties.Contains(propertyInfo.Name))
                    continue;

                var value = propertyInfo.GetValue(subject);
                if (processedObjects.Contains(value))
                    continue;

                var collection = value as IEnumerable;
                if (collection != null)
                {
                    foreach (var item in collection)
                    {
                        if (item == null || item.GetType().IsValueType)
                            continue;

                        LoadInternal(ref processedObjects, item, ignoreProperties);
                    }
                }
                else if (!propertyInfo.PropertyType.IsValueType)
                {
                    LoadInternal(ref processedObjects, value, ignoreProperties);
                }
            }
        }
    }
}
