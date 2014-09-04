//-----------------------------------------------------------------------
// <copyright file="SetHTML.cs" company="AppFactory Team">
//     Copyright AppFactory Team. All Rights Reserved. This code released under the terms of the Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.) This is sample code only, do not use in production environments.
// </copyright>
//-----------------------------------------------------------------------

namespace appfactory.core.attached
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class SetHTML : DependencyObject
    {
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached("Html", typeof(string), typeof(SetHTML), new PropertyMetadata("", Changed));

        public static string GetHtml(DependencyObject obj)
        {
            return (string)obj.GetValue(HtmlProperty);
        }

        public static void SetHtml(DependencyObject obj, string value)
        {
            obj.SetValue(HtmlProperty, value);
        }

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var webbrowser = d as WebView;
            var html = GetHtml(d);
            if (string.IsNullOrWhiteSpace(html))
            {
                return;
            }

            webbrowser.NavigateToString(html);
        }
    }
}