using System;

namespace PermisosApp.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class NavigationPropertyAttribute : Attribute
    {
        public NavigationPropertyAttribute() { }
    }
}
