using BufTools.DataAnnotations.Schema;
using BufTools.DataStorage;
using Template.DomainServices.Functions;

namespace Template.Infrastructure
{
    /// <summary>
    /// A context class used by DataStorage to knwo what class to use for storage
    /// </summary>
    public class DataContext : AbstractDataContext
    {
        /// <summary>
        /// Constructs an instance of a context
        /// </summary>
        public DataContext()
        {
            IncludeWithClassAttribute<EntityAttribute>(GetType().Assembly);
            IncludeWithClassAttribute<ViewAttribute>(GetType().Assembly);
            Include(typeof(Funcs));
        }
    }
}
