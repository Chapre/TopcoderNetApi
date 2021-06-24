using System;
using System.ComponentModel.DataAnnotations;

namespace TopcoderNetApi.Model
{
    public class Section
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

        /// <summary>
        ///     Gets or sets the order.
        /// </summary>
        /// <value>
        ///     The order.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        ///     Gets or sets the course.
        /// </summary>
        /// <value>
        ///     The course.
        /// </value>
        public Course Course { get; set; }
    }
}