using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Casino.ComponentTests.Extensions
{
    public static class ApiAssertionExtensions
    {
        public static ApiAssertions<T> Should<T>(this ApiResponse<T> apiResponse)
        {
            return new ApiAssertions<T>(apiResponse);
        }
    }

    public class ApiAssertions<T> : ReferenceTypeAssertions<ApiResponse<T>, ApiAssertions<T>>
    {
        protected override string Identifier => $"{nameof(IApiResponse)}";

        public ApiAssertions(ApiResponse<T> apiResponse) : base(apiResponse)
        {
        }

        public ApiAssertions<T> BeHttpResponse(HttpStatusCode status)
        {
            Execute.Assertion
                .ForCondition(Subject != null)
                .FailWith("Expected response but recieved null")
                .Then
                .ForCondition(Subject!.StatusCode == status)
                .FailWith("Expected response to be {0}, but recieved {1}", status, Subject.StatusCode);
            return this;
        }
        public ApiAssertions<T> BeOkResponse() => BeHttpResponse(HttpStatusCode.OK);
    }
}
