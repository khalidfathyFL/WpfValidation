using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfValidation;

/// <summary>
/// Serves as a base class for entities, providing common functionality for property validation.
/// </summary>
/// <remarks>This class includes a method for validating individual property values against data annotations or
/// other validation rules. Derived classes can override the validation behavior by overriding the <see
/// cref="ValidateProperty(string, object)"/> method.</remarks>
public class EntityBase
{

    /// <summary>
    /// Validates the specified property value against the validation attributes applied to the property.
    /// </summary>
    /// <remarks>This method uses the <see cref="System.ComponentModel.DataAnnotations.Validator"/> class to
    /// validate the property value based on the validation attributes applied to the property. If the value is invalid,
    /// a <see cref="System.ComponentModel.DataAnnotations.ValidationException"/> is thrown.</remarks>
    /// <param name="propertyName">The name of the property to validate. This must match the name of a property on the current object.</param>
    /// <param name="value">The value of the property to validate.</param>
    protected virtual void ValidateProperty(string propertyName, object value)
    {
        ValidationContext context = new ValidationContext(this) { MemberName = propertyName };
        Validator.ValidateProperty(value,context);
    }
}
