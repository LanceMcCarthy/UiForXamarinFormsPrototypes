using CoreGraphics;
using CustomPrototypes.iOS.CustomRenderers.Calendar;
using Telerik.XamarinForms.Input;
using Telerik.XamarinForms.InputRenderer.iOS;
using TelerikUI;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RadCalendar), typeof(CustomCalendarRenderer))]
namespace CustomPrototypes.iOS.CustomRenderers.Calendar
{
    public class CustomCalendarRenderer : CalendarRenderer
    {
        protected override CalendarDelegate CreateCalendarDelegateOverride()
        {
            return new CustomCalendarDelegate();
        }
    }

    public class CustomCalendarDelegate : CalendarDelegate
    {
        public override void UpdateVisualsForCell(TKCalendar calendar, TKCalendarCell cell)
        {
            if (cell is TKCalendarDayCell dayCell)
            {
                TKCalendarDayState todayState = TKCalendarDayState.Today;
                if ((dayCell.State & todayState) == todayState)
                {
                    var borderColor = Color.FromHex("#0044FF").ToUIColor();

                    dayCell.Style.ShapeFill = null;
                    
                    cell.Style.TopBorderColor = borderColor;
                    cell.Style.LeftBorderColor = borderColor;
                    cell.Style.RightBorderColor = borderColor;
                    cell.Style.BottomBorderColor = borderColor;

                    cell.Style.TopBorderWidth = 2;
                    cell.Style.LeftBorderWidth = 2;
                    cell.Style.RightBorderWidth = 2;
                    cell.Style.BottomBorderWidth = 2;
                }

                TKCalendarDayState selectedState = TKCalendarDayState.Selected;
                if ((dayCell.State & selectedState) == selectedState)
                {
                    var borderColor = Color.FromHex("#00FF44").ToUIColor();

                    dayCell.Style.Shape = new TKPredefinedShape(TKShapeType.Square, new CGSize(30,25));
                    dayCell.Style.ShapeFill = new TKSolidFill(borderColor);

                    cell.Style.TopBorderColor = borderColor;
                    cell.Style.LeftBorderColor = borderColor;
                    cell.Style.RightBorderColor = borderColor;
                    cell.Style.BottomBorderColor = borderColor;

                    cell.Style.TopBorderWidth = 2;
                    cell.Style.LeftBorderWidth = 2;
                    cell.Style.RightBorderWidth = 2;
                    cell.Style.BottomBorderWidth = 2;
                }
            }
        }
        
    }
}