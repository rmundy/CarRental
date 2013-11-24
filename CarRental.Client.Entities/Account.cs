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
namespace CarRental.Client.Entities
{
    #region

    using System;

    using Core.Common.Core;

    #endregion

    /// <summary>
    /// Account class
    /// </summary>
    public sealed class Account : ObjectBase
    {
        #region Fields

        /// <summary>
        /// The account identifier
        /// </summary>
        private Guid accountId;

        /// <summary>
        /// The address
        /// </summary>
        private String address;

        /// <summary>
        /// The city
        /// </summary>
        private String city;

        /// <summary>
        /// The credit card
        /// </summary>
        private String creditCard;

        /// <summary>
        /// The expiration date
        /// </summary>
        private DateTime expirationDate;

        /// <summary>
        /// The first name
        /// </summary>
        private String firstName;

        /// <summary>
        /// The last name
        /// </summary>
        private String lastName;

        /// <summary>
        /// The login email
        /// </summary>
        private String loginEmail;

        /// <summary>
        /// The state
        /// </summary>
        private String state;

        /// <summary>
        /// The zip code
        /// </summary>
        private String zipCode;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public Guid AccountId
        {
            get
            {
                return this.accountId;
            }
            set
            {
                this.accountId = value;
                this.OnPropertyChanged(() => this.AccountId);
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public String Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
                this.OnPropertyChanged(() => this.Address);
            }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public String City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
                this.OnPropertyChanged(() => this.City);
            }
        }

        /// <summary>
        /// Gets or sets the credit card.
        /// </summary>
        /// <value>
        /// The credit card.
        /// </value>
        public String CreditCard
        {
            get
            {
                return this.creditCard;
            }
            set
            {
                this.creditCard = value;
                this.OnPropertyChanged(() => this.CreditCard);
            }
        }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        public DateTime ExpirationDate
        {
            get
            {
                return this.expirationDate;
            }
            set
            {
                this.expirationDate = value;
                this.OnPropertyChanged(() => this.ExpirationDate);
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public String FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
                this.OnPropertyChanged(() => this.FirstName);
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public String LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
                this.OnPropertyChanged(() => this.LastName);
            }
        }

        /// <summary>
        /// Gets or sets the login email.
        /// </summary>
        /// <value>
        /// The login email.
        /// </value>
        public String LoginEmail
        {
            get
            {
                return this.loginEmail;
            }
            set
            {
                this.loginEmail = value;
                this.OnPropertyChanged(() => this.LoginEmail);
            }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public String State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
                this.OnPropertyChanged(() => this.State);
            }
        }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        public String ZipCode
        {
            get
            {
                return this.zipCode;
            }
            set
            {
                this.zipCode = value;
                this.OnPropertyChanged(() => this.ZipCode);
            }
        }

        #endregion
    }
}