using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCDesignmonster.WordCount
{
    public class WordCountAttribute : ValidationAttribute, IClientValidatable
    {
        public int MaxWords { get; set; }
        public int MinWords { get; set; }

        public WordCountAttribute(int minWords, int Maxwords) : base ("{0} has too many or too few words.")
        {
            MinWords = minWords;
            MaxWords = Maxwords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                var wordCountOfvalue = valueAsString.Split(' ').Length;
                if (wordCountOfvalue > MaxWords || wordCountOfvalue < MinWords)
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
            //TODO fix min AND max here for client val as well... Also check Scripts/App/CustomValidator.js
            rule.ValidationParameters.Add("maxwords", MaxWords);
            rule.ValidationType = "wordcount";
            rule.ValidationParameters.Add("minwords", MinWords);
            rule.ValidationType = "wordcount";
            yield return rule;
        }

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    var rule = new ModelClientValidationRule();
        //    rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
        //    rule.ValidationParameters.Add("wordcount", WordCount);
        //    rule.ValidationType = "maxwords";
        //    yield return rule;
        //}
    }
}
