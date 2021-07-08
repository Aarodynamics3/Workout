using System;
using System.Globalization;

namespace Workout {
    static class Formatting {
        public static String ToTitleCase(this string title) {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }
    }
}
