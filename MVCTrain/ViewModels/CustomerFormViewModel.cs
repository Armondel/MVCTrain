﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCTrain.Models;

namespace MVCTrain.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}