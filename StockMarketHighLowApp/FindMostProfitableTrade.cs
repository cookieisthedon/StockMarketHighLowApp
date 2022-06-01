using Computershare.Shared;
using StockMarketHighLowApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StockMarketHighLowApp
{
    public static class FindMostProfitableTrade
    {
        public static ResultModel FindMostProfitableTradeForMonth(string monthInput)
        {
            int lowIndex = 0;
            decimal lowValue = 0;
            int highIndex = 0;
            decimal highValue = 0;
            decimal priceDifference = 0;
            int firstLoopCount = 1;
            ResultModel mostProfitableDayOprnTradeResult = new ResultModel
            {
                Result = string.Empty,
                IsSuccess = true,
                Error = string.Empty
            };

            try
            {
                List<decimal> dailyStockValues = monthInput.Split(Constants.StringToListSplitValue).Select(d => decimal.Parse(d)).ToList();

                foreach (decimal dailyStockValue in dailyStockValues)
                {
                    int secondLoopCount = firstLoopCount;
                    foreach (decimal compareValue in dailyStockValues.Skip(firstLoopCount - 1)) // subtract one as lists are 0 based
                    {
                        decimal comparePriceDifference = compareValue - dailyStockValue;
                        if (comparePriceDifference > priceDifference)
                        {
                            priceDifference = comparePriceDifference;
                            lowIndex = firstLoopCount;
                            lowValue = dailyStockValue;
                            highIndex = secondLoopCount;
                            highValue = compareValue;
                        }

                        secondLoopCount++;
                    }

                    firstLoopCount++;
                }

                mostProfitableDayOprnTradeResult.Result = $"{lowIndex}({lowValue}),{highIndex}({highValue})";
            }
            catch (Exception ex)
            {
                mostProfitableDayOprnTradeResult.IsSuccess = false;
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrame(0);
                StringBuilder errorMessageBuilder = new StringBuilder();
                errorMessageBuilder.AppendLine($"Exception Occured in file: {frame.GetFileName()}");
                errorMessageBuilder.AppendLine($"Error method: {frame.GetMethod()?.Name}");
                errorMessageBuilder.AppendLine($"Error line: {frame.GetFileLineNumber()}");
                errorMessageBuilder.AppendLine($"Error message: {ex.Message}");
                mostProfitableDayOprnTradeResult.Error = errorMessageBuilder.ToString();
            }

            return mostProfitableDayOprnTradeResult;
        }
    }
}
