namespace CleanArchitecture.Application.Common.Models;

public class Result
{
    public bool Succeeded { get; set; }

    public string[] Errors { get; set; } =new string[0];
    public object Data { get; set; }
    internal Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }
    internal Result()
    {
    }
    public static Result Success(object data)
    {
        return new Result()
        {
            Succeeded= true,
            Data= data
        };
    }

    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(false, errors);
    }
}
