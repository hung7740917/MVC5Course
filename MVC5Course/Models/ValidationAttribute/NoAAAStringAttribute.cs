using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ValidationAttribute
{
    public class NoAAAStringAttribute : DataTypeAttribute
    {
        public NoAAAStringAttribute() : base(DataType.Text)
        {
        }

        public override bool IsValid(object value)
        {
            string str = Convert.ToString(value);

            if (str.Contains("aaa"))
            {
                return false;
            }
            return true;
        }
    }
}