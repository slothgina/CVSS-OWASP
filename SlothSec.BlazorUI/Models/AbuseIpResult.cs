public class AbuseIpResult
{
    public AbuseIpData Data { get; set; }
}

public class AbuseIpData
{
    public string IpAddress { get; set; }
    public bool IsPublic { get; set; }
    public bool IsWhiteListed { get; set; }
    public int AbuseConfidenceScore { get; set; }
    public string CountryCode { get; set; }
    public string UsageType { get; set; }
    public string Isp { get; set; }
    public string Domain { get; set; }
    public int TotalReports { get; set; }
    public int NumDistinctUsers { get; set; }
    public DateTime? LastReportedAt { get; set; }
}