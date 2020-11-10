﻿namespace AllAboutGames.Services.Data.CustomAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ValidUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Uri uri;
            bool valid = Uri.TryCreate(Convert.ToString(value), UriKind.Absolute, out uri);

            if (!valid)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
