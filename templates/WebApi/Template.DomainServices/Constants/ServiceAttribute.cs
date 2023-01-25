using System;

namespace Template.DomainServices.Constants
{
    /// <summary>
    /// Apply this attribute to each service class so it can be auto-registered for dependency injection
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    sealed public class ServiceAttribute : Attribute
    {
    }
}
