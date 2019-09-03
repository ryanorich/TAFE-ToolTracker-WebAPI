using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TT_WebAPI.ViewModels
{
    public class ToolBorrowCountViewModel
    { 
        public int ToolID { get; set; }
        public string ToolName { get; set; }
        public int BorrowCount { get; set; }
        public string picFileName { get; set; }
        
    }
}

// Query
// SELECT Tool.ToolID, Tool.ToolName, COuNT(LoanToolID) AS BorrowCount, Tool.picFileName
// FROM Tool
// LEFT JOIN LoanTool ON Tool.ToolID = LoanTool.ToolID
// GROUP BY Tool.ToolID, Tool.ToolName, Tool.picFileName
// ORDER BY BorrowCount DESC