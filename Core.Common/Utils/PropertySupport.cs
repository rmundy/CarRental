// <copyright file="PropertySupport.cs" company="Cylex">
//      All rights are reserved. Reproduction or transmission in whole or
//      in part, in any form or by any means, electronic, mechanical or
//      otherwise, is prohibited without the prior written consent of the 
//      copyright owner.
// </copyright>
// 
// <summary>
//      Definition of the PropertySupport.cs class.
// </summary>
namespace Core.Common.Utils
{
    #region

    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    #endregion

    /// <summary>
    /// PropertySupport class
    /// </summary>
    public static class PropertySupport
    {
        #region Public Methods and Operators

        /// <summary>
        /// Extracts the name of the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">The lambda expression 'property' should point to a valid Property</exception>
        public static String ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                return String.Empty;
            }

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
            {
                throw new ArgumentException("The lambda expression 'propertyExpression' should point to a valid Property");
            }
            return propertyInfo.Name;
        }

        #endregion
    }
}