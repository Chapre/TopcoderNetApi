using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopcoderNetApi.Model
{
    public class WatchLog
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the course.
        /// </summary>
        /// <value>
        ///     The course.
        /// </value>
        public Course Course { get; set; }

        /// <summary>
        ///     Gets or sets the lesson.
        /// </summary>
        /// <value>
        ///     The lesson.
        /// </value>
        public Lesson Lesson { get; set; }

        /// <summary>
        ///     Gets or sets the user.
        /// </summary>
        /// <value>
        ///     The user.
        /// </value>
        public User User { get; set; }

        /// <summary>
        ///     Gets or sets the percentage watched.
        /// </summary>
        /// <value>
        ///     The percentage watched.
        /// </value>
        [Range(0, 100)]
        public int PercentageWatched { get; set; }
    }
}