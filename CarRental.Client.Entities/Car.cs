using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Client.Entities
{
    using Core.Common.Core;

    public sealed class Car : ObjectBase
    {
        private Guid carId;
       
        private String color;

        private Boolean currentlyRented;

        private String description;

        private Decimal rentalPrice;

        private Int32 year;
        
        public Guid CarId
        {
            get
            {
                return this.carId;
            }
            set
            {
                this.carId = value;
                OnPropertyChanged(() => this.CarId);
            }
        }
    }
}
