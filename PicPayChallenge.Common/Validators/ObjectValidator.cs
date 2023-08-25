using PicPayChallenge.Common.Exceptions;
using PicPayChallenge.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Common.Validators
{
    public static class ObjectValidator
    {
        public static void NullValidator(this object value, string propertyName)
        {
            if (value.IsNull())
                throw new BadRequestException($"The {propertyName} cannot be null");
        }

        public static void NullValidator(this object value)
        {
            if (value.IsNull())
                throw new BadRequestException($"The property cannot be null");
        }
    }
}
