using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TT_WebAPI.Models;
using TT_WebAPI.Controllers;
using TT_WebAPI.ViewModels;

namespace TT_WebAPI.Controllers
{
    public class ReportController : ApiController
    {
        private ToolTrackerEntities db = new ToolTrackerEntities();

        [HttpGet]
        [Route("api/Report/GetLoanedToolsReport")]
        public IEnumerable<LoanedToolsViewModel> GetLoanedToolsReport()
        {
                      string SQLQuery = "SELECT Tool.ToolID, BrandName, ToolName, Loan.LoanID, WorkspaceName, BorrowerName, DateBorrowed " +
                             "FROM Tool " +
                             "JOIN Brand ON Tool.BrandID = Brand.BrandID " +
                             "JOIN LoanTool ON Tool.ToolID = LoanTool.ToolID " +
                             "JOIN Loan on LoanTool.loanID = Loan.LoanID " +
                             "JOIN Workspace ON Loan.WorkspaceID = Workspace.WorkspaceID " +
                             "JOIN Borrower ON Loan.BorrowerID = Borrower.BorrowerID " +
                             "WHERE DateReturned IS null ;";
            return db.Database.SqlQuery<LoanedToolsViewModel>(SQLQuery).ToList();
        }

        [HttpGet]
        [Route("api/Report/GetToolInventoryReport")]
        public IEnumerable<ToolInventoryViewModel> GetToolInventoryReport()
        {
            string SQLQuery =
            "SELECT Tool.ToolID, BrandName, ToolName , Decomissioned, Count(DateBorrowed) - Count(DateReturned) as 'Loaned', MAX(LoanTool.LoanID) as 'Latest' " +
            "FROM Tool " +
            "LEFT JOIN LoanTool ON LoanTool.ToolID = Tool.ToolID " +
            "LEFT JOIN Brand on Tool.BrandID = Brand.BrandID " +
            "LEFT JOIN Loan ON LoanTool.LoanID = Loan.LoanID " +
            "GROUP BY Tool.ToolID, BrandName, ToolName, Decomissioned ";
            return db.Database.SqlQuery<ToolInventoryViewModel>(SQLQuery).ToList();
        }

        [HttpGet]
        [Route("api/Report/GetToolBorrowCount")]
        public IEnumerable<ToolBorrowCountViewModel> GetToolBorrowCount()
        {

            string SQLQuery =
                "SELECT Tool.ToolID, Tool.ToolName, COuNT(LoanToolID) AS BorrowCount, Tool.picFileName " +
                "FROM Tool " +
                "LEFT JOIN LoanTool ON Tool.ToolID = LoanTool.ToolID " +
                "GROUP BY Tool.ToolID, Tool.ToolName, Tool.picFileName " +
                "ORDER BY BorrowCount DESC ; ";
            return db.Database.SqlQuery<ToolBorrowCountViewModel>(SQLQuery).ToList();
        }
    }
}
