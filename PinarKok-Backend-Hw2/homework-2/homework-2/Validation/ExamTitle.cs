using homework_2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_2.Validation
{
    public class ExamTitle: ValidationAttribute
    {
        private int _maxLength;

        public ExamTitle(int maxLength)
        {
            _maxLength = maxLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ExamDto examDto = (ExamDto)validationContext.ObjectInstance;

            if (examDto.Title.Length > _maxLength)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
            }

            return ValidationResult.Success;
        }
    }
}
