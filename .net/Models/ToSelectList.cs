using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace scholarsnet.Models
{

    public static partial class Helpers
    {

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value)
        {
            return enumerable.ToSelectList(value, value, false);
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectedValue">The selected value.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, int selectedValue)
        {
            return enumerable.ToSelectList(value, value, new string[] { selectedValue.ToString() }.ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectedValue">The selected value.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, string selectedValue)
        {
            return enumerable.ToSelectList(value, value, new string[] { selectedValue }.ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, int[] selectedValues)
        {
            if (selectedValues == null)
            {
                throw new ArgumentNullException("selectedValues");
            }
            return enumerable.ToSelectList(value, value, selectedValues.ToList().ConvertAll<string>(i => i.ToString()));
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, IList<int> selectedValues)
        {
            return enumerable.ToSelectList(value, value, selectedValues.Cast<string>().ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, string[] selectedValues)
        {
            return enumerable.ToSelectList(value, value, selectedValues.ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, IList<string> selectedValues)
        {
            return enumerable.ToSelectList(value, value, selectedValues);
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field and the data text field.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text)
        {
            return enumerable.ToSelectList(value, text, false);
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field, the data text field, and a selected value.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValue">The selected value.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, int selectedValue)
        {
            return enumerable.ToSelectList(value, text, new string[] { selectedValue.ToString() }.ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field, the data text field, and a selected value.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValue">The selected value.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, string selectedValue)
        {
            return enumerable.ToSelectList(value, text, new string[] { selectedValue }.ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field, the data text field, and the selected values.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, int[] selectedValues)
        {
            if (selectedValues == null)
            {
                throw new ArgumentNullException("selectedValues");
            }
            return enumerable.ToSelectList(value, text, selectedValues.ToList().ConvertAll<string>(i => i.ToString()));
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field, the data text field, and the selected values.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, IList<int> selectedValues)
        {
            return enumerable.ToSelectList(value, text, selectedValues.Cast<string>().ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field, the data text field, and the selected values.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, string[] selectedValues)
        {
            if (selectedValues == null)
            {
                throw new ArgumentNullException("selectedValues");
            }
            return enumerable.ToSelectList(value, text, selectedValues.ToList());
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field, the data text field, and the selected values.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectedValues">The selected values.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, IList<string> selectedValues)
        {
            foreach (var f in enumerable)
            {
                yield return new SelectListItem()
                {
                    Value = value(f),
                    Text = text(f),
                    Selected = selectedValues.Contains(value(f))
                };
            }
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field and a selected value.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="selectAll">Whether all values are selected.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, bool selectAll)
        {
            return enumerable.ToSelectList(value, value, selectAll);
        }

        /// <summary>
        /// Returns an IEnumerable&lt;SelectListItem&gt; by using the specified checkboxes for data value field, the data text field, and the selected values.
        /// </summary>
        /// <param name="enumerable">The checkboxes.</param>
        /// <param name="value">The data value field.</param>
        /// <param name="text">The data text field.</param>
        /// <param name="selectAll">Whether all values are selected.</param>
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> value, Func<T, string> text, bool selectAll)
        {
            foreach (var f in enumerable)
            {
                yield return new SelectListItem()
                {
                    Value = value(f),
                    Text = text(f),
                    Selected = selectAll
                };
            }
        }

    }
}