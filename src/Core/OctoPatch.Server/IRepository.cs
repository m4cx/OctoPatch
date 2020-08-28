﻿using System;
using System.Collections.Generic;
using OctoPatch.Descriptions;

namespace OctoPatch.Server
{
    /// <summary>
    /// Repository for some plugin driven types
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Returns all discovered messages
        /// </summary>
        /// <returns>all messages</returns>
        IEnumerable<TypeDescription> GetTypeDescriptions();

        /// <summary>
        /// Returns all discovered nodes
        /// </summary>
        /// <returns>all nodes</returns>
        IEnumerable<NodeDescription> GetNodeDescriptions();

        /// <summary>
        /// Returns all discovered adapters
        /// </summary>
        /// <returns></returns>
        IEnumerable<AdapterDescription> GetAdapterDescriptions();

        /// <summary>
        /// Generates a new node for the given key
        /// </summary>
        /// <param name="key">unique key of the node description</param>
        /// <param name="nodeId">id of the new node</param>
        /// <returns>new node instance</returns>
        INode CreateNode(string key, Guid nodeId);

        /// <summary>
        /// Generates a new adapter for the given key
        /// </summary>
        /// <param name="key">adapter key</param>
        /// <returns>new instance</returns>
        IAdapter CreateAdapter(string key);
    }
}
