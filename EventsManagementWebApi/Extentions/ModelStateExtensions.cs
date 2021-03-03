using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace EventsManagementWebApi.Extentions
{
    public static class ModelStateExtensions
    {
        public static String GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return string.Join("; ", dictionary.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
        }
    }
}