using FluentValidation.Results;

namespace OrderWebApi.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public Dictionary<string, string[]> Errors { get; }
        public CustomValidationException() : base("one or more validation errors occured")
        {
            Errors = new Dictionary<string, string[]> ();
        }
        public CustomValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup =>  failureGroup.Key, failureGroupe =>  failureGroupe.ToArray());
        }

    }
}
