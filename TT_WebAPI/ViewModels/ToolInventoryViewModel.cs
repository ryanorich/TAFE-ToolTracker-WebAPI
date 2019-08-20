using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TT_WebAPI.ViewModels
{
    public class ToolInventoryViewModel
    {
        public int ToolID { get; set; }
        public string BrandName { get; set; }
        public string ToolName { get; set; }
        public bool Decomissioned { get; set; }
        public int Loaned { get; set; }
        public int? Latest { get; set; }
    }
}

// Query
// Tool.ToolID, BrandName, ToolName , Decomissioned, 
// Count(DateBorrowed) - Count(DateReturned) as 'Loaned', 
// MAX(LoanTool.LoanID) as 'Latest'