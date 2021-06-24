using System;
using System.Collections.Generic;
using TopcoderNetApi.Model;

namespace TopcoderNetApi.Services.Sections
{
    public interface ISectionService
    {
        /// <summary>
        ///     Gets the section.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Section GetSection(Guid id);

        /// <summary>
        ///     Gets the sections.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Section> GetSections();

        /// <summary>
        ///     Adds the setion.
        /// </summary>
        /// <param name="section">The section.</param>
        void AddSetion(Section section);
    }
}