using SlothSec.RiskCore.Models;
using SlothSec.RiskCore.Services;

Console.WriteLine("=== SlothSec CVSS + OWASP Risk Calculator ===\n");

var metrics = new CvssMetrics();

Console.Write("Attack Vector (numeric): ");
metrics.AttackVector = double.Parse(Console.ReadLine());

Console.Write("Attack Complexity (numeric): ");
metrics.AttackComplexity = double.Parse(Console.ReadLine());

Console.Write("Privileges Required (numeric): ");
metrics.PrivilegesRequired = double.Parse(Console.ReadLine());

Console.Write("User Interaction (numeric): ");
metrics.UserInteraction = double.Parse(Console.ReadLine());

var cvssCalc = new CvssCalculator();
double cvssScore = cvssCalc.CalculateBaseScore(metrics);

Console.WriteLine($"\nCVSS Score: {cvssScore:F2}");


var owasp = new OwaspRiskInput();

Console.Write("\nOWASP Likelihood (1–9): ");
owasp.Likelihood = int.Parse(Console.ReadLine());

Console.Write("OWASP Impact (1–9): ");
owasp.Impact = int.Parse(Console.ReadLine());

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
