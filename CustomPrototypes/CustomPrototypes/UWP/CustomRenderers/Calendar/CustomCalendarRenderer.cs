using System;
using Telerik.XamarinForms.Input;
using Telerik.XamarinForms.InputRenderer.UWP;
using Windows.UI.Xaml;
using CustomPrototypes.UWP.CustomRenderers.Calendar;
using Xamarin.Forms.Platform.UWP;
using CalendarCellStyle = Telerik.UI.Xaml.Controls.Input.CalendarCellStyle;

[assembly: ExportRenderer(typeof(RadCalendar), typeof(CustomCalendarRenderer))]
namespace CustomPrototypes.UWP.CustomRenderers.Calendar
{
    public class CustomCalendarRenderer : CalendarRenderer
    {
        static CustomCalendarRenderer()
        {
            // Merge the resource dictionary containing the styles, or you can just put them directly in App.xaml
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("ms-appx:///CustomRenderers/Calendar/CustomCalendarStyles.xaml") });
        }

        protected override void OnElementChanged(ElementChangedEventArgs<RadCalendar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.NormalCellStyle = new CalendarCellStyle
                {
                    ContentStyle = (Style)Application.Current.Resources["NormalCellContentStyle"],
                    DecorationStyle = (Style)Application.Current.Resources["NormalCellDecorationStyle"]
                };

                Control.SelectedCellStyle = new CalendarCellStyle
                {
                    ContentStyle = (Style)Application.Current.Resources["NormalCellContentStyle"],
                    DecorationStyle = (Style)Application.Current.Resources["SelectedCellDecorationStyle"]
                };

                Control.AnotherViewCellStyle = new CalendarCellStyle
                {
                    ContentStyle = (Style)Application.Current.Resources["AnotherViewCellContentStyle"],
                    DecorationStyle = (Style)Application.Current.Resources["AnotherViewCellDecorationStyle"],
                };

                Control.CurrentCellStyle = new CalendarCellStyle
                {
                    ContentStyle = (Style)Application.Current.Resources["NormalCellContentStyle"],
                    DecorationStyle = (Style)Application.Current.Resources["CurrentCellDecorationStyle"],
                };

                Control.HighlightedCellStyle = new CalendarCellStyle
                {
                    ContentStyle = (Style)Application.Current.Resources["HighlightedCellContentStyle"],
                    DecorationStyle = (Style)Application.Current.Resources["HighlightedCellDecorationStyle"],
                };

                Control.DayNameCellStyle = new CalendarCellStyle
                {
                    ContentStyle = (Style)Application.Current.Resources["DayNameCellContentStyle"],
                    DecorationStyle = (Style)Application.Current.Resources["DayNameCellDecorationStyle"],
                };
            }
        }
    }
}