﻿namespace CreditApplicationSystem.ApplicationServices.API.Domain
{
    public class ResponseBase<T> : ErrorResponseBase
    {
        public T Data { get; set; }
    }
}
