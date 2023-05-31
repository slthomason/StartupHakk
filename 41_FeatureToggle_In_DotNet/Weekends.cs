public class OnlyOnWeekends : IFeatureToggle
{
    public bool FeatureEnabled
    {
        get
        {
            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return true;

                default:
                    return false;
            }
        }
    }
}