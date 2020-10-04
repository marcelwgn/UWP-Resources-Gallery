namespace UWPResourcesGallery.ResourceModel
{
    /// <summary>
    /// Interface used for filtering items
    /// </summary>
    public interface IFilterable
    {
        /// <summary>
        /// Method called to check if an object fits a filter or not
        /// </summary>
        /// <param name="keywords">The string of keywords that the object must fulfill</param>
        /// <returns>True if the object meets the filter</returns>
        bool FitsFilter(string[] keywords);
    }
}
