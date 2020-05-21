using CinemaWatch.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWatch.ViewModels
{
    public class CustomerFormViewModel
    {
        //use IEnumberable instead of list 
        //in view do no need to use MembershipTypes as object
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                {
                    return "Edit Customer";
                }

                return "New Customer";
            }
        }
    }
}