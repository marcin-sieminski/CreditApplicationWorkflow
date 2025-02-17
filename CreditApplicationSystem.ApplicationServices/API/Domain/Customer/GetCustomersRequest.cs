﻿using MediatR;

namespace CreditApplicationSystem.ApplicationServices.API.Domain.Customer
{
    public class GetCustomersRequest : IRequest<GetCustomersResponse>
    {
        public string Name { get; set; }
    }
}