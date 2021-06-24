using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopcoderNetApi.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
