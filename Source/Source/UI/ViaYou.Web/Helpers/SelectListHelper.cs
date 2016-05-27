using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViaYou.Web.Helpers
{
    public static class SelectListHelper
    {
        public static IEnumerable<SelectListItem> CreateSelectListItems<T>(this IEnumerable<T> items,
           Func<T, string> getText, Func<T, string> getValue, Func<T, bool> isSelected = null)
        {
            return items.Select(item => new SelectListItem
            {
                Text = getText(item),
                Value = getValue(item),
                Selected = isSelected?.Invoke(item) ?? false
            });
        }
    }
}