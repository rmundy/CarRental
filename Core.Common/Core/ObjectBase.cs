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
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text;

    using FluentValidation;
    using FluentValidation.Results;

    using global::Core.Common.Contracts;
    using global::Core.Common.Utils;

    #endregion

    /// <summary>
    ///     ObjectBase class
    /// </summary>
    public abstract class ObjectBase : NotificationObject,
        IDirtyCapable,
        IExtensibleDataObject,
        INotifyPropertyChanged,
        IDataErrorInfo
    {
        #region Fields

        protected IValidator Validator;

        protected Boolean isDirty;

        /// <summary>
        ///     The property changed subscribers
        /// </summary>
        private readonly List<PropertyChangedEventHandler> propertyChangedSubscribers =
            new List<PropertyChangedEventHandler>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectBase"/> class.
        /// </summary>
        protected ObjectBase()
        {
            this.Validator = this.GetValidator();
            this.Validate();
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     Occurs when a property value changes.
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
        // ReSharper disable once InconsistentNaming
        private event PropertyChangedEventHandler propertyChanged;

        #endregion

        #region Public Properties

        public ExtensionDataObject ExtensionData { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [is dirty].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [is dirty]; otherwise, <c>false</c>.
        /// </value>
        [NotNavigable]
        public Boolean IsDirty { get; set; }

        /// <summary>
        ///     Gets a value indicating whether [is valid].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [is valid]; otherwise, <c>false</c>.
        /// </value>
        [NotNavigable]
        public virtual Boolean IsValid
        {
            get
            {
                return this.ValidationErrors == null || !this.ValidationErrors.Any();
            }
        }

        /// <summary>
        /// Gets or sets the validation errors.
        /// </summary>
        /// <value>
        /// The validation errors.
        /// </value>
        [NotNavigable]
        public IEnumerable<ValidationFailure> ValidationErrors { get; protected set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        ///     Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        String IDataErrorInfo.Error
        {
            get
            {
                return String.Empty;
            }
        }

        #endregion

        #region Explicit Interface Indexers

        /// <summary>
        ///     Gets the error message for the property with the given name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        String IDataErrorInfo.this[String columnName]
        {
            get
            {
                var errors = new StringBuilder();
                if (this.ValidationErrors == null || !this.ValidationErrors.Any())
                {
                    return errors.ToString();
                }

                foreach (
                    var validationFailure in
                        this.ValidationErrors.Where(validationFailure => validationFailure.PropertyName == columnName))
                {
                    errors.Append(validationFailure.ErrorMessage);
                }

                return errors.ToString();
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Cleans all.
        /// </summary>
        public void CleanAll()
        {
            this.WalkObjectGraph(
                o =>
                {
                    if (o.IsDirty)
                    {
                        o.IsDirty = false;
                    }

                    return false;
                },
                coll => { });
        }

        /// <summary>
        ///     Gets the dirty objects.
        /// </summary>
        /// <returns></returns>
        public List<ObjectBase> GetDirtyObjects()
        {
            var dirtyObjects = new List<ObjectBase>();

            this.WalkObjectGraph(
                o =>
                {
                    if (o.IsDirty)
                    {
                        dirtyObjects.Add(o);
                    }

                    return false;
                },
                coll => { });

            return dirtyObjects;
        }

        /// <summary>
        ///     Determines whether [is anything dirty].
        /// </summary>
        /// <returns></returns>
        public virtual Boolean IsAnythingDirty()
        {
            var anythingDirty = false;
            this.WalkObjectGraph(
                o =>
                {
                    if (o.IsDirty)
                    {
                        anythingDirty = true;
                        return true;
                    }

                    return false;
                },
                coll => { });

            return anythingDirty;
        }

        public void Validate()
        {
            if (this.Validator == null)
            {
                return;
            }

            var results = this.Validator.Validate(this);
            this.ValidationErrors = results.Errors;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the validator.
        /// </summary>
        /// <returns>The proper validator.</returns>
        protected virtual IValidator GetValidator()
        {
            return null;
        }

        /// <summary>
        ///     Called when [proiperty changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="System.ArgumentNullException">propertyName cannot be null.</exception>
        protected virtual void OnPropertyChanged(String propertyName)
        {
            this.OnPropertyChanged(propertyName, true);
        }

        /// <summary>
        ///     Called when [property changed].
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

            this.Validate();
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <typeparam name="T">Property type</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.OnPropertyChanged(propertyName);
        }

        /// <summary>
        ///     Walks the object graph.
        /// </summary>
        /// <param name="snippetForObject">The snippet for object.</param>
        /// <param name="snippetForCollection">The snippet for collection.</param>
        /// <param name="exemptProperties">The exempt properties.</param>
        protected void WalkObjectGraph(
            Func<ObjectBase, Boolean> snippetForObject,
            Action<IList> snippetForCollection,
            params String[] exemptProperties)
        {
            var visited = new List<ObjectBase>();
            Action<ObjectBase> walk = null;

            walk = o =>
            {
                if (o != null && !visited.Contains(o))
                {
                    visited.Add(o);

                    var exitWalk = snippetForObject.Invoke(o);
                    if (!exitWalk)
                    {
                        var properties = o.GetBrowsableProperties();
                        foreach (var property in properties.Where(property => !exemptProperties.Contains(property.Name))
                            )
                        {
                            if (property.PropertyType.IsSubclassOf(typeof(ObjectBase)))
                            {
                                var obj = (ObjectBase)property.GetValue(o, null);
                                walk(obj);
                            }
                            else
                            {
                                var coll = property.GetValue(o, null) as IList;
                                if (coll != null)
                                {
                                    snippetForCollection.Invoke(coll);

                                    foreach (var @base in coll.OfType<ObjectBase>())
                                    {
                                        walk(@base);
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        /// <summary>
        ///     Gets the browsable properties.
        /// </summary>
        /// <returns> A list of browsable properties</returns>
        private IEnumerable<PropertyInfo> GetBrowsableProperties()
        {
            var properties =
                typeof(ObjectBase).GetProperties()
                    .Where(property => !property.GetCustomAttributes(typeof(NotNavigableAttribute), true).Any())
                    .ToList();
            return properties;
        }

        #endregion
    }
}