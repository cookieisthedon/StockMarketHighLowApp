using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarketHighLowApp.Models
{
    public class ResultModel
    {
        public string Result { get; set; }

        public bool IsSuccess { get; set; }

        public string Error { get; set; }
    }
}
