
namespace Template.Domain.Entities
{
    /// <summary>
    /// An example of a person entity
    /// </summary>
    public class Person
    {
        /// <summary>
        /// A unique identifier for this entity
        /// </summary>
        /// <example>8845</example>
        public int ExampleId { get; set; }

        /// <summary>
        /// The name of the person
        /// </summary>
        /// <example>John Q Public</example>
        public string Name { get; set; }

        /// <summary>
        /// A description of the person
        /// </summary>
        /// <example>John like baseball and apple pie.</example>
        public string Description { get; set; }

        /// <summary>
        /// The max price the person will pay for a slice of pie
        /// </summary>
        /// <example>10.65</example>
        public float MaxPieSlicePrice { get; set; }

    }
}
