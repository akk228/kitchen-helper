using System.Collections;
using System.ComponentModel.DataAnnotations;
using BindingFlags = System.Reflection.BindingFlags;

namespace FridgeAndRecipesStorage.Recipies.CustomValidations;

public class NonEmptyCollectionAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (!base.IsValid(value))
        {
            return false;
        }
        
        try
        {
            var enumerable = value as IEnumerable;
            
            foreach (var obj in enumerable)
            {
                return true;
            }
        }
        catch(Exception e)
        {
            return false;
        }

        return false;
    }
}