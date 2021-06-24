﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TopcoderNetApi.Model
{
    public class Lesson
    {
        //Id: string (GUID)
        //Name: string (250 chars)
        //videoUrl: string (355 chars)
        //Order: number
        //sectionId: Foreign key to section.id
        
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
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the video URL.
        /// </summary>
        /// <value>
        /// The video URL.
        /// </value>
        [MaxLength(355)]
        public string VideoUrl { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        public Section Section { get; set; }
    }
}
