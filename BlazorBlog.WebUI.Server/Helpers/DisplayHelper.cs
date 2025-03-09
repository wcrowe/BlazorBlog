using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace BlazorBlog.WebUI.Server.Helpers
{


    public static class DisplayHelper
    {
        /// <summary>
        /// Retrieves the display name of a property from its attributes (`DisplayNameAttribute` or `DisplayAttribute`).
        /// </summary>
        /// <typeparam name="TModel">The type of the model containing the property.</typeparam>
        /// <typeparam name="TValue">The type of the property's value.</typeparam>
        /// <param name="expression">A lambda expression selecting the property (e.g., `() => model.PropertyName`).</param>
        /// <returns>
        /// The display name specified in the `DisplayNameAttribute` or `DisplayAttribute`, 
        /// or the property name if no attribute is found.
        /// </returns>
        public static string GetDisplayName<TModel, TValue>(TModel model, Expression<Func<TModel, TValue>> expression)
        {
            if (expression.Body is MemberExpression memberExpression)
            {
                var property = typeof(TModel).GetProperty(memberExpression.Member.Name);
                if (property != null)
                {
                    var displayNameAttribute = property.GetCustomAttribute<DisplayNameAttribute>();
                    if (displayNameAttribute != null)
                    {
                        return displayNameAttribute.DisplayName;
                    }

                    var displayAttribute = property.GetCustomAttribute<DisplayAttribute>();
                    if (displayAttribute != null && displayAttribute.Name != null)
                    {
                        return displayAttribute.Name;
                    }
                }
                return memberExpression.Member.Name;
            }
            return string.Empty;
        }
    }

}
