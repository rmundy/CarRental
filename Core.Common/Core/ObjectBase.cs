// <copyright file="ObjectBase.cs" company="Cylex">
//      All rights are reserved. Reproduction or transmission in whole or
//      in part, in any form or by any means, electronic, mechanical or
//      otherwise, is prohibited without the prior written consent of the 
//      copyright owner.
// </copyright>
// 
// <summary>
//      Definition of the ObjectBase.cs class.
// </summary>
namespace Core.Common.Core
{
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using global::Core.Common.Utils;

    #endregion

    /// <summary>
    ///     ObjectBase class
    /// </summary>
    public class ObjectBase : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// The property changed subscribers
        /// </summary>
        private readonly List<PropertyChangedEventHandler> propertyChangedSubscribers =
            new List<PropertyChangedEventHandler>();

        #endregion

        #region Public Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (!this.propertyChangedSubscribers.Contains(value))
                {
                    this.propertyChanged += value;
                    this.propertyChangedSubscribers.Add(value);
                }
            }
            remove
            {
                this.propertyChanged -= value;
                this.propertyChangedSubscribers.Remove(value);
            }
        }

        #endregion

        #region Events

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        private event PropertyChangedEventHandler propertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether [is dirty].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is dirty]; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsDirty { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="System.ArgumentNullException">propertyName cannot be null.</exception>
        protected virtual void OnPropertyChanged(String propertyName)
        {
            this.OnPropertyChanged(propertyName, true);
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="makeDirty">if set to <c>true</c> [make dirty].</param>
        /// <exception cref="System.ArgumentNullException">propertyName</exception>
        protected virtual void OnPropertyChanged(String propertyName, Boolean makeDirty)
        {
            if (String.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            if (this.propertyChanged != null)
            {
                this.propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            if (makeDirty)
            {
                this.IsDirty = true;
            }
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <typeparam name="T">Property type</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName);
        }

        #endregion
    }
}