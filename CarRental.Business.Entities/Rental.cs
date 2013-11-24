// <copyright file="Rental.cs" company="Cylex">
//      All rights are reserved. Reproduction or transmission in whole or
//      in part, in any form or by any means, electronic, mechanical or
//      otherwise, is prohibited without the prior written consent of the 
//      copyright owner.
// </copyright>
// 
// <summary>
//      Definition of the Rental.cs class.
// </summary>

namespace CarRental.Business.Entities
{
    #region

    using System;
    using System.Runtime.Serialization;

    using Core.Common.Contracts;
    using Core.Common.Core;

    using ServiceStack.DataAnnotations;

    #endregion

    /// <summary>
    ///     Rental class
    /// </summary>
    [DataContract]
    public sealed class Rental : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the account identifier.
        /// </summary>
        /// <value>
        ///     The account identifier.
        /// </value>
        [DataMember]
        [References(typeof(Account))]
        public Guid AccountId { get; set; }

        /// <summary>
        ///     Gets or sets the car identifier.
        /// </summary>
        /// <value>
        ///     The car identifier.
        /// </value>
        [DataMember]
        [References(typeof(Car))]
        public Guid CarId { get; set; }

        /// <summary>
        ///     Gets or sets the date due.
        /// </summary>
        /// <value>
        ///     The date due.
        /// </value>
        [DataMember]
        public DateTime DateDue { get; set; }

        /// <summary>
        ///     Gets or sets the date rented.
        /// </summary>
        /// <value>
        ///     The date rented.
        /// </value>
        [DataMember]
        public DateTime DateRented { get; set; }

        /// <summary>
        ///     Gets or sets the date returned.
        /// </summary>
        /// <value>
        ///     The date returned.
        /// </value>
        [DataMember]
        public DateTime? DateReturned { get; set; }

        /// <summary>
        ///     Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        ///     The entity identifier.
        /// </value>
        public Guid EntityId
        {
            get
            {
                return this.RentalId;
            }
            set
            {
                this.RentalId = value;
            }
        }

        /// <summary>
        ///     Gets or sets the rental identifier.
        /// </summary>
        /// <value>
        ///     The rental identifier.
        /// </value>
        [PrimaryKey]
        public Guid RentalId { get; set; }

        #endregion

        #region Explicit Interface Properties

        /// <summary>
        ///     Gets or sets the owner account identifier.
        /// </summary>
        /// <value>
        ///     The owner account identifier.
        /// </value>
        Guid IAccountOwnedEntity.OwnerAccountId
        {
            get
            {
                return this.AccountId;
            }
            set
            {
                this.AccountId = value;
            }
        }

        #endregion
    }
}