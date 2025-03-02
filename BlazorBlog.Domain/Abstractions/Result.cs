using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Domain.Abstractions
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool Failure => !IsSuccess;
        public string? Error { get; }
        protected Result(bool isSuccess, string? errorMessage = null)
        {
            IsSuccess = isSuccess;
            Error = errorMessage;
        }

        public static Result Ok() => new(true);
        public static Result Fail(string errorMessage) => new(false, errorMessage);
        public static Result<T> Ok<T>(T value) => new(value, true, string.Empty);
        public static Result<T> Fail<T>(string errorMessage) => new(default, false, errorMessage);

        public static Result<T> FromValue<T>(T? value) => value != null ? Ok(value) : Fail<T>("Provided value is null");


    }

    public class Result<T> : Result
    {
        public T? Value { get; }
        protected internal Result(T? value, bool success, string errorMessage = null) : base(success, errorMessage)
        {
            Value = value;
        }
        public static Result<T> Ok(T value) => new(value, true);
        public new static Result<T> Fail(string errorMessage) => new(default!, false, errorMessage);

        public static implicit operator Result<T>(T value) => FromValue(value);
    }
}
