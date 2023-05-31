public class UseNewAnalyzer : SimpleFeatureToggle
{
    private static readonly UseNewAnalyzer Instance = new UseNewAnalyzer();

    public static bool IsFeatureEnabled => Instance.FeatureEnabled;
}

private static IResumeAnalyzer GetResumeAnalyzer()
{
    if (UseNewAnalyzer.IsFeatureEnabled)
    {
        return new RewrittenAnalyzer();
    }
    else
    {
        return new ResumeAnalyzer();
    }
}