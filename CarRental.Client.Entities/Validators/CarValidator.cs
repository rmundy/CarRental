using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Client.Entities.Validators
{
    using FluentValidation;

    public class CarValidator : AbstractValidator<Car>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CarValidator"/> class.
        /// </summary>
        public CarValidator()
        {
            RuleFor(car => car.Description).NotEmpty();
            RuleFor(car => car.Color).NotEmpty();
            RuleFor(car => car.RentalPrice).GreaterThan(0);
            RuleFor(car => car.Year).GreaterThan(2000).LessThanOrEqualTo(DateTime.Now.Year);
        }
    }
}
