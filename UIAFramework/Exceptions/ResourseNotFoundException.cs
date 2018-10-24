﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAFramework
{
    public class ResourceNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceNotFoundException"/> class.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="type">The type.</param>
        /// <param name="resourceName">Name of the resource.</param>
        public ResourceNotFoundException(string assemblyName, string type, string resourceName)
            : base(string.Format("Failed to get resource '{0}' from type '{1}' and assembly '{2}'.", resourceName, type, assemblyName))
        { }
    }
}
