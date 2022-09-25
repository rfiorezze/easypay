using Newtonsoft.Json;

namespace com.easypay.be.api.Dtos;

public class ErrorDto
{
    public IEnumerable<string> Errors { get; }

    public ErrorDto(string message)
    {
        var errors = new List<string>
        {
            message
        };

        Errors = errors;
    }

    public ErrorDto(IEnumerable<string> errors)
    {
        Errors = errors;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
