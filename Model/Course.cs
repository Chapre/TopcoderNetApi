using System;
using System.ComponentModel.DataAnnotations;

namespace TopcoderNetApi.Model
{
    /// <summary>
    /// </summary>
    public class Course
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }
}