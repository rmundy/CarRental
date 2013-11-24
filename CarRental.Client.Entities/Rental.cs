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
namespace CarRental.Client.Entities
{
    #region

    using System;

    using Core.Common.Core;

    #endregion

    public sealed class Rental : ObjectBase
    {
        #region Fields

        /// <summary>
        ///     The account identifier
        /// </summary>
        private Guid accountId;

        /// <summary>
        ///     The car identifier
        /// </summary>
        private Guid carId;

        /// <summary>
        /// The rental identifier
        /// </summary>
        private Guid rentalId;

        /// <summary>
        ///     The date rented
        /// </summary>
        private DateTime dateRented;

        /// <summary>
        ///     The date returned
        /// </summary>
        private DateTime? dateReturned;

        /// <summary>
        ///     The datedue
        /// </summary>
        private DateTime datedue;

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the account identifier.
        /// </summary>
        /// <value>
        ///     The account identifier.
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
        ///     Gets or sets the car identifier.
        /// </summary>
        /// <value>
        ///     The car identifier.
        /// </value>
        public Guid CarId
        {
            get
            {
                return this.carId;
            }
            set
            {
                this.carId = value;
                this.OnPropertyChanged(() => this.CarId);
            }
        }

        /// <summary>
        ///     Gets or sets the date due.
        /// </summary>
        /// <value>
        ///     The date due.
        /// </value>
        public DateTime DateDue
        {
            get
            {
                return this.datedue;
            }
            set
            {
                this.datedue = value;
                this.OnPropertyChanged(() => this.DateDue);
            }
        }

        /// <summary>
        ///     Gets or sets the date rented.
        /// </summary>
        /// <value>
        ///     The date rented.
        /// </value>
        public DateTime DateRented
        {
            get
            {
                return this.dateRented;
            }
            set
            {
                this.dateRented = value;
                this.OnPropertyChanged(() => this.DateRented);
            }
        }

        /// <summary>
        ///     Gets or sets the date returned.
        /// </summary>
        /// <value>
        ///     The date returned.
        /// </value>
        public DateTime? DateReturned
        {
            get
            {
                return this.dateReturned;
            }
            set
            {
                this.dateReturned = value;
                this.OnPropertyChanged(() => this.DateReturned);
            }
        }

        /// <summary>
        /// Gets or sets the rental identifier.
        /// </summary>
        /// <value>
        /// The rental identifier.
        /// </value>
        public Guid RentalId
        {
            get
            {
                return this.rentalId;
            }
            set
            {
                this.rentalId = value;
                this.OnPropertyChanged(() => this.RentalId);
            }
        }

        #endregion
    }
}