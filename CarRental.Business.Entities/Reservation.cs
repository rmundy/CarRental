// <copyright file="Reservation.cs" company="Cylex">
//      All rights are reserved. Reproduction or transmission in whole or
//      in part, in any form or by any means, electronic, mechanical or
//      otherwise, is prohibited without the prior written consent of the 
//      copyright owner.
// </copyright>
// 
// <summary>
//      Definition of the Reservation.cs class.
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
    ///     Reservation class
    /// </summary>
    [DataContract]
    public sealed class Reservation : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the account identifier.
        /// </summary>
        /// <value>
        ///     The account identifier.
        /// </value>
        [DataMember]
        public Guid AccountId { get; set; }

        /// <summary>
        ///     Gets or sets the car identifier.
        /// </summary>
        /// <value>
        ///     The car identifier.
        /// </value>
        [DataMember]
        public Guid CarId { get; set; }

        /// <summary>
        ///     Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        ///     The entity identifier.
        /// </value>
        [DataMember]
        public Guid EntityId
        {
            get
            {
                return this.CarId;
            }
            set
            {
                this.CarId = value;
            }
        }

        /// <summary>
        ///     Gets or sets the rental date.
        /// </summary>
        /// <value>
        ///     The rental date.
        /// </value>
        [DataMember]
        public DateTime RentalDate { get; set; }

        /// <summary>
        ///     Gets or sets the reservation identifier.
        /// </summary>
        /// <value>
        ///     The reservation identifier.
        /// </value>
        [DataMember]
        public Guid ReservationId { get; set; }

        /// <summary>
        ///     Gets or sets the return date.
        /// </summary>
        /// <value>
        ///     The return date.
        /// </value>
        [DataMember]
        public DateTime ReturnDate { get; set; }

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