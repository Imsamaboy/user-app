using System.ComponentModel.DataAnnotations;

namespace vk_testing.Dtos;

[AttributeUsage(AttributeTargets.Property)]
public class IsEnumDisplayAttribute<T> : ValidationAttribute where T : Enum
{
    public IsEnumDisplayAttribute(string errorMessage) : base(errorMessage)
    {
        
    }

    public override bool IsValid(object? value)
    {
        if (value is string str)
        {
            return Enum.TryParse(typeof(T), str, ignoreCase: true, out _);
        }
        return false;
    }
}