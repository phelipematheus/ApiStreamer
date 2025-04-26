using System.Net;
using FluentValidation.Results;
namespace CrossCutting.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected BaseException()
        { }

        protected BaseException(string? message) : base(message)
        { }

        protected BaseException(string? message, Exception? innerException) : base(message, innerException)
        { }

        public virtual string Title { get; set; } = string.Empty;
        public virtual HttpStatusCode StatusCode { get; set; }
        public virtual IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
