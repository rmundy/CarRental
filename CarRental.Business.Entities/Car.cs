// <copyright file="Car.cs" company="Cylex">
//      All rights are reserved. Reproduction or transmission in whole or
//      in part, in any form or by any means, electronic, mechanical or
//      otherwise, is prohibited without the prior written consent of the 
//      copyright owner.
// </copyright>
// 
// <summary>
//      Definition of the Car.cs class.
// </summary>
namespace CarRental.Business.Entities
{
    #region

    using System;
    using System.Runtime.Serialization;

    using Core.Common.Contracts;
    using Core.Common.Core;

    #endregion

    /// <summary>
    /// Car class
    /// </summary>
    [DataContract]
    public sealed class Car : EntityBase, IIdentifiableEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the car identifier.
        /// </summary>
        /// <value>
        /// The car identifier.
        /// </value>
        [DataMember]
        public Guid CarId { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        [DataMember]
        public String Color { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the car is [currently rented].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [currently rented]; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public Boolean CurrentlyRented { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DataMember]
        public String Description { get; set; }

        /// <summary>
        ///     Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        ///     The entity identifier.
        /// </value>
        public Guid EntityId
        {
            get { return this.CarId; }
            set { this.CarId = value; }
        }

        /// <summary>
        /// Gets or sets the rental price.
        /// </summary>
        /// <value>
        /// The rental price.
        /// </value>
        [DataMember]
        public Decimal RentalPrice { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        [DataMember]
        public Int32 Year { get; set; }

        #endregion
    }
}