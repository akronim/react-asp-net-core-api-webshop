using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApiCore.Models;

namespace WebShopApiCore.DTO
{
    public class CustomerDTO
    {
        public Int32 CustomerID { get; set; }

        public String Email { get; set; }

        public String Address { get; set; }

        public String CreditCard { get; set; }

        public static CustomerDTO FromEntity(Customer entity)
        {
            return new CustomerDTO
            {
                CustomerID = entity.CustomerID,
                Email = entity.Email,
                Address = entity.Address,
                CreditCard = entity.CreditCard
            };
        }

        public void ToEntity(Customer entity)
        {
            entity.CustomerID = CustomerID;
            entity.Email = Email;
            entity.Address = Address;
            entity.CreditCard = CreditCard;
        }
    }
}
