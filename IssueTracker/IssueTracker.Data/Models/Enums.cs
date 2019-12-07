using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Data.Models
{
    public enum EnumStatus
    {
        Active,
        InActive
    }

    public enum EnumProjectType
    {
        New_Project,
        CR,
        Long_Term
    }

    public enum EnumProjectStatus
    {
        Live,
        Under_Developed,
        InActive
    }

    public enum EnumIssuePriority
    {
        High,
        Medium, 
        Low
    }

    public enum EnumIssueType
    {
        Issue_Solve,
        New_Development,
        Outside_Duty
    }

    public enum EnumRelationWithClient
    {
        Good,
        Excellent,
        Needs_to_improve
    }
}
