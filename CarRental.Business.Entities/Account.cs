// <copyright file="Account.cs" company="Cylex">
//      All rights are reserved. Reproduction or transmission in whole or
//      in part, in any form or by any means, electronic, mechanical or
//      otherwise, is prohibited without the prior written consent of the 
//      copyright owner.
// </copyright>
// 
// <summary>
//      Definition of the Account.cs class.
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
    ///     Account class
    /// </summary>
    [DataContract]
    public sealed class Account : EntityBase, IIdentifiableEntity
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the account identifier.
        /// </summary>
        /// <value>
        ///     The account identifier.
        /// </value>
        [DataMember]
        [PrimaryKey]
        public Guid AccountId { get; set; }

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        /// <value>
        ///     The address.
        /// </value>
        [DataMember]
        public String Address { get; set; }

        /// <summary>
        ///     Gets or sets the city.
        /// </summary>
        /// <value>
        ///     The city.
        /// </value>
        [DataMember]
        public String City { get; set; }

        /// <summary>
        ///     Gets or sets the credit card.
        /// </summary>
        /// <value>
        ///     The credit card.
        /// </value>
        [DataMember]
        public String CreditCard { get; set; }

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
                return this.AccountId;
            }
            set
            {
                this.AccountId = value;
            }
        }

        /// <summary>
        ///     Gets or sets the expiration date.
        /// </summary>
        /// <value>
        ///     The expiration date.
        /// </value>
        [DataMember]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>
        ///     The first name.
        /// </value>
        [DataMember]
        public String FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>
        ///     The last name.
        /// </value>
        [DataMember]
        public String LastName { get; set; }

        /// <summary>
        ///     Gets or sets the login email.
        /// </summary>
        /// <value>
        ///     The login email.
        /// </value>
        [DataMember]
        [Index(Unique = true)]
        public String LoginEmail { get; set; }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        /// <value>
        ///     The state.
        /// </value>
        [DataMember]
        public String State { get; set; }

        /// <summary>
        ///     Gets or sets the zip code.
        /// </summary>
        /// <value>
        ///     The zip code.
        /// </value>
        [DataMember]
        public String ZipCode { get; set; }

        #endregion
    }
}