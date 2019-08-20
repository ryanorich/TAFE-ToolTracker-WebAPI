using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TT_WebAPI.ViewModels
{
    public class LoanedToolsViewModel
    {
        public int ToolID { get; set; }
        public string BrandName { get; set; }
        public string ToolName { get; set; }
        public int LoanID { get; set; }
        public string WorkspaceName { get; set; }
        public string BorrowerName { get; set; }
        public DateTime DateBorrowed { get; set; }
    }
}

// Query
// ToolID, BrandName, ToolName, Loan.LoanID, 
// WorkspaceName, BorrowerName, DateBorrowed " +
                             