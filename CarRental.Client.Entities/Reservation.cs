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
namespace CarRental.Client.Entities
{
    #region

    using System;

    using Core.Common.Core;

    #endregion

    /// <summary>
    /// Reservation class
    /// </summary>
    public class Reservation : ObjectBase
    {
        #region Fields

        /// <summary>
        /// The account identifier
        /// </summary>
        private Guid accountId;

        /// <summary>
        /// The car identifier
        /// </summary>
        private Guid carId;

        /// <summary>
        /// The rental date
        /// </summary>
        private DateTime rentalDate;

        /// <summary>
        /// The reservation identifier
        /// </summary>
        private Guid reservationId;

        /// <summary>
        /// The return date
        /// </summary>
        private DateTime returnDate;

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
        /// Gets or sets the car identifier.
        /// </summary>
        /// <value>
        /// The car identifier.
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
        /// Gets or sets the rental date.
        /// </summary>
        /// <value>
        /// The rental date.
        /// </value>
        public DateTime RentalDate
        {
            get
            {
                return this.rentalDate;
            }
            set
            {
                this.rentalDate = value;
                this.OnPropertyChanged(() => this.RentalDate);
            }
        }

        /// <summary>
        /// Gets or sets the reservation identifier.
        /// </summary>
        /// <value>
        /// The reservation identifier.
        /// </value>
        public Guid ReservationId
        {
            get
            {
                return this.reservationId;
            }
            set
            {
                this.reservationId = value;
                this.OnPropertyChanged(() => this.ReservationId);
            }
        }

        /// <summary>
        /// Gets or sets the return date.
        /// </summary>
        /// <value>
        /// The return date.
        /// </value>
        public DateTime ReturnDate
        {
            get
            {
                return this.returnDate;
            }
            set
            {
                this.returnDate = value;
                this.OnPropertyChanged(() => this.ReturnDate);
            }
        }

        #endregion
    }
}