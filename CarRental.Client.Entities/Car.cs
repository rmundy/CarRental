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

namespace CarRental.Client.Entities
{
    #region

    using System;

    using CarRental.Client.Entities.Validators;

    using Core.Common.Core;

    using FluentValidation;

    #endregion

    /// <summary>
    ///     Car class
    /// </summary>
    public sealed class Car : ObjectBase
    {
        #region Fields

        /// <summary>
        ///     The car identifier
        /// </summary>
        private Guid carId;

        /// <summary>
        ///     The color
        /// </summary>
        private String color;

        /// <summary>
        ///     The currently rented
        /// </summary>
        private Boolean currentlyRented;

        /// <summary>
        ///     The description
        /// </summary>
        private String description;

        /// <summary>
        ///     The rental price
        /// </summary>
        private Decimal rentalPrice;

        /// <summary>
        ///     The year
        /// </summary>
        private Int32 year;

        #endregion

        #region Public Properties

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
        ///     Gets or sets the color.
        /// </summary>
        /// <value>
        ///     The color.
        /// </value>
        public String Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
                this.OnPropertyChanged(() => this.Color);
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [currently rented].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [currently rented]; otherwise, <c>false</c>.
        /// </value>
        public Boolean CurrentlyRented
        {
            get
            {
                return this.currentlyRented;
            }
            set
            {
                this.currentlyRented = value;
                this.OnPropertyChanged(() => this.CurrentlyRented);
            }
        }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public String Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                this.OnPropertyChanged(() => this.Description);
            }
        }

        /// <summary>
        ///     Gets or sets the rental price.
        /// </summary>
        /// <value>
        ///     The rental price.
        /// </value>
        public Decimal RentalPrice
        {
            get
            {
                return this.rentalPrice;
            }
            set
            {
                this.rentalPrice = value;
                this.OnPropertyChanged(() => this.RentalPrice);
            }
        }

        /// <summary>
        ///     Gets or sets the year.
        /// </summary>
        /// <value>
        ///     The year.
        /// </value>
        public Int32 Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
                this.OnPropertyChanged(() => this.Year);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the validator.
        /// </summary>
        /// <returns>
        ///     The proper validator.
        /// </returns>
        protected override IValidator GetValidator()
        {
            return new CarValidator();
        }

        #endregion
    }
}