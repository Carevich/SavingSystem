using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
namespace SavingSystem.MVC.Domain
{
    public class SavSysEmailValidatorAttribute : ValidationAttribute, IClientValidatable
    {
        private static readonly List<string> _busyEmail = new List<string>();

        public SavSysEmailValidatorAttribute()
        {
            //var db = new LayerConnectDb();
            //Profile profile = null;
            //var profiles = db.ReadTable(profile, "Profiles");
            //foreach (var p in profiles)
            //{
            //    _busyEmail.Add(p.Email);
            //}
            //ErrorMessage = "Emeil уже занят";
        }

        public override bool IsValid(object value)
        {
            if (_busyEmail.Contains(value))
            {
                return false;
            }
            return true;
        }

        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    if (_busyEmail.Contains(value))
        //    {
        //        var errorMessage = FormatErrorMessage(validationContext.DisplayName);
        //        return new ValidationResult(errorMessage);
        //    }
        //    return ValidationResult.Success;
        //}

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
            ControllerContext context)
        {
            return new List<ModelClientValidationRule>
            {
                new ModelClientValidationRule()
                {
                    ValidationType = "email",
                    ErrorMessage = this.ErrorMessage
                }
            };
        }

    }
}