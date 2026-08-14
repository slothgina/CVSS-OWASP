using SlothSec.RiskCore.Models;
using SlothSec.RiskCore.Services;

Console.WriteLine("=== SlothSec CVSS + OWASP Risk Calculator ===\n");

double ReadDouble(string prompt)
{
    double value;
    while (true)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        
        if (double.TryParse(input, out value) && value >= 0 && value <= 10)
            return value;
            
        Console.WriteLine("Invalid input. Please enter a number between 0 and 10.\n");
             
    }
}

int ReadInt(string prompt)
{
    int value;
    while (true)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        
        if (int.TryParse(input,out value) && value >= 1 && value <= 10)
            return value;
            
        Console.WriteLine("Invalid input. Please enter a number between 1 and 10.\n");
             
    }
}

var metrics = new CvssMetrics
{
    AttackVector = ReadDouble("Attack Vector (0-10): "),
    AttackComplexity = ReadDouble("Attack Complexity (0-10): "),
    PrivilegesRequired = ReadDouble("Privileges Required (0-10): "),
    UserInteraction = ReadDouble("User Interaction (0-10): ")
};


var cvssCalc = new CvssCalculator();
double cvssScore = cvssCalc.CalculateBaseScore(metrics);

Console.WriteLine($"\nCVSS Score: {cvssScore:F2}");


int ReadOwaspValue(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        
        if (int.TryParse(input, out int value) && value >= 1 && value <= 9)
            return value;
            
        Console.WriteLine("Invalid input. Please enter a number between 1 and 9.\n");
    }
}

var owasp = new OwaspRiskInput
{
    Likelihood = ReadOwaspValue("\nOWASP Likelihood (1–9): "),
    Impact = ReadOwaspValue("OWASP Impact (1–9): ")
};

var owaspEngine = new OwaspRiskEngine();
double owaspScore = owaspEngine.CalculateRisk(owasp);

Console.WriteLine($"OWASP Score: {owaspScore:F2}");


double combined = (cvssScore * 0.6) + (owaspScore * 0.4);

Console.WriteLine($"\nCombined Risk Score: {combined:F2}");

if (combined >= 8.0) Console.WriteLine("Severity: CRITICAL");
else if (combined >= 6.0) Console.WriteLine("Severity: HIGH");
else if (combined >= 4.0) Console.WriteLine("Severity: MEDIUM");
else Console.WriteLine("Severity: LOW");

Console.WriteLine("\n=== Calculation Complete ===");
