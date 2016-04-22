using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCDesignmonster.Service.WordCount
{
    public class MaxWordsAttribute : ValidationAttribute, IClientValidatable
    {
        public int MaxWords { get; set; }

        public MaxWordsAttribute(int maxWords) : base("{0} has too many words.")
        {
            MaxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > MaxWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("wordcount", MaxWords);
            rule.ValidationType = "maxwords";
            yield return rule;
        }
    }
}
