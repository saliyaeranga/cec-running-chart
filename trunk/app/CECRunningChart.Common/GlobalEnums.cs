
namespace CECRunningChart.Common
{
    public enum UserRole
    {
        None = 0,
        [StringValueAttribute("Admin")]
        Admin = 1,
        [StringValueAttribute("Running Chart Operator")]
        RunningChartOperator = 2,
        [StringValueAttribute("Running Chart Inspector")]
        RunningChartInspector = 3
    }
}
