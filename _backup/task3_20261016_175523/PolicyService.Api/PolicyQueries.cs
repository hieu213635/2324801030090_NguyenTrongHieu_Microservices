using System;
using System.Collections.Generic;
namespace PolicyService.Api.Queries;
public class PolicyCoverDto { public string Code { get; set; } public string Name { get; set; } }
public class PolicyDetailsDto
{
    public string Number { get; set; }
    public string ProductCode { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public string PolicyHolder { get; set; }
    public string Status { get; set; }
    public decimal TotalPremium { get; set; }
    public List<string> Covers { get; set; } = new();
}
public class GetPolicyDetailsQueryResult { public PolicyDetailsDto Policy { get; set; } }
