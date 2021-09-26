using System.ComponentModel.DataAnnotations;
using Workshop.Core.Validation;

namespace Workshop.Core.Settings
{
    public abstract class DataAnnotationSetting : IValidatable
    {
        public void Validate()
        {
            Validator.ValidateObject(this, new ValidationContext(this), validateAllProperties: true);
        }
    }
}