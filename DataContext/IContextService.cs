namespace TopcoderNetApi.DataContext
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContextService
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IContextService"/> is initialised.
        /// </summary>
        /// <value>
        ///   <c>true</c> if initialised; otherwise, <c>false</c>.
        /// </value>
        bool Initialised { get; }

        /// <summary>
        /// Initialises this instance.
        /// </summary>
        void Initialise();
    }
}
