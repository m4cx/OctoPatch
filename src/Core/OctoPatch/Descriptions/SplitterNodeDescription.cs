﻿using System;

namespace OctoPatch.Descriptions
{
    /// <summary>
    /// Node to split up complex types into its properties
    /// </summary>
    public sealed class SplitterNodeDescription : NodeDescription
    {
        /// <summary>
        /// Gets the complex type name to split
        /// </summary>
        public string ComplexTypeName { get; set; }

        private SplitterNodeDescription(string key, string displayName, string displayDescription) 
            : base(key, displayName, displayDescription)
        {
        }

        /// <summary>
        /// Creates a new description for splitter nodes
        /// </summary>
        /// <typeparam name="T">node type</typeparam>
        /// <param name="pluginId">plugin id</param>
        /// <param name="displayName">name of the node</param>
        /// <param name="displayDescription">optional description</param>
        /// <returns>node description</returns>
        public static SplitterNodeDescription CreateSplitter<T>(Guid pluginId, string displayName, string displayDescription)
        {
            return new SplitterNodeDescription($"{pluginId}:{typeof(T).Name}", displayName, displayDescription);
        }
    }
}
