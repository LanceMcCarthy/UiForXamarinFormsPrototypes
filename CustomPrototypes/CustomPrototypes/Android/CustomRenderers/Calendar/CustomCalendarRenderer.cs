using Android.Graphics;
using Android.Runtime;
using Com.Telerik.Android.Common;
using Com.Telerik.Widget.Calendar;
using CustomPrototypes.Android.CustomRenderers.Calendar;
using Java.Util;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Telerik.XamarinForms.InputRenderer.Android;
using static Java.Util.Calendar;
using static Java.Util.CalendarField;
using static Android.Graphics.Color;

[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Input.RadCalendar), typeof(CustomCalendarRenderer))]
namespace CustomPrototypes.Android.CustomRenderers.Calendar
{
    public class CustomCalendarRenderer : CalendarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Telerik.XamarinForms.Input.RadCalendar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.CustomizationRule = new CustomizationRule();

                Control.CellDecorationsLayer.Color = ParseColor("#0044FF");
            }
        }
    }

    public class CustomizationRule : Java.Lang.Object, IProcedure
    {
        private readonly Java.Util.Calendar calendar = Instance;

        public void Apply(Java.Lang.Object p0)
        {
            if (p0 is CalendarDayCell calendarCell && calendarCell.CellType == CalendarCellType.Date)
            {
                // p0 is enabled color, p1 is disabled color
                // calendarCell.SetBackgroundColor(p0, p1)

                calendarCell.SetBackgroundColor(ParseColor("#F8F8F8"),ParseColor("#E0E0E0"));
                calendarCell.SetTextColor(ParseColor("#000000"), ParseColor("#FFFFFF")); 

                calendar.TimeInMillis = calendarCell.Date;

                var weekDay = calendar.Get(CalendarField.DayOfWeek);
                if (weekDay == 1 || weekDay == 7)
                {
                    calendarCell.SetBackgroundColor(ParseColor("#EEEEEE"), ParseColor("#E0E0E0")); 
                    calendarCell.SetTextColor(ParseColor("#999999"), ParseColor("#AAAAAA")); 
                }
            
                var boldTypeface = Typeface.Create(calendarCell.TextPaint.Typeface, TypefaceStyle.Bold);

                if (calendar.Get(CalendarField.Date) == Instance.Get(CalendarField.Date) &&
                    calendar.Get(CalendarField.Month) == Instance.Get(CalendarField.Month) &&
                    calendar.Get(CalendarField.Year) == Instance.Get(CalendarField.Year))
                {
                    calendarCell.BorderColor = ParseColor("#00FF44");
                    calendarCell.BorderWidth = Forms.Context.ToPixels(2);
                    calendarCell.Typeface = boldTypeface;
                }

                if (calendarCell.Selected)
                {
                    calendarCell.Typeface = boldTypeface;
                }
            }
        }
    }
}