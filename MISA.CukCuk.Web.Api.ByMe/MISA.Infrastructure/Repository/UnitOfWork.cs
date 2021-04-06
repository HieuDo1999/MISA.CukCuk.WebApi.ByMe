﻿using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository Customer
        {
            get;
        }
        public UnitOfWork (ICustomerRepository customerRepository)
        {
            Customer = customerRepository;
        }
       
    }
}