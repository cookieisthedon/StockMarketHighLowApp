using NUnit.Framework;
using StockMarketHighLowApp;

namespace StockMarketHighLowUnitTests
{
    [TestFixture]
    public static class MostProfitableOpeningDayUnitTests
    {
        [Test(Description = "Test high low finder")]
        [TestCase("18.93,20.25,17.05,16.59,21.09,16.22,21.43,27.13,18.62,21.31,23.96,25.52,19.64,23.49,15.28,22.77,23.1,26.58,27.03,23.75,27.39,15.93,17.83,18.82,21.56,25.33,25,19.33,22.08,24.03", "15(15.28),21(27.39)")]
        [TestCase("22.74,22.27,20.61,26.15,21.68,21.51,19.66,24.11,20.63,20.96,26.56,26.67,26.02,27.20,19.13,16.57,26.71,25.91,17.51,15.79,26.19,18.57,19.03,19.02,19.97,19.04,21.06,25.94,17.03,15.61", "20(15.79),21(26.19)")]
        [TestCase("10.74,22.27,20.61,26.15,160.68,21.51,19.66,24.11,20.63,5.96,26.56,26.67,26.02,27.20,66.13,16.57,26.71,25.91,17.51,15.79,26.19,18.57,19.03,19.02,19.97,19.04,21.06,25.94,17.03,15.61", "1(10.74),5(160.68)")]
        public static void TestHighLowApp(string inputData, string expectedAnswer)
        {
            var result = FindMostProfitableTrade.FindMostProfitableTradeForMonth(inputData);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(expectedAnswer, result.Result);
            Assert.IsEmpty(result.Error);
        }

        [Test(Description = "Test error handling model gets correctly created")]
        [TestCase("18.93,20.25,17.05,16.59,21.09,16.22,21.43,27.13,18.62,21.31,23.96,25.sfsd52,19.64,23.49,15.28,22.77,23.1,26.58,27.03,23.75,27.39,15.93,17.83,18.82,21.56,25.33,25,19.33,22.08,24.03")]
        [TestCase("10.74,22.27,20.61,26.15,160.68,21.51,19.66,24.11,20.63,5.96,26.56,,26.02,27.20,66.13,16.57,26.71,25.91,17.51,15.79,26.19,18.57,19.03,19.02,19.97,19.04,21.06,25.94,17.03,15.61")]
        [TestCase("")]
        public static void ErrorTestHighLowApp(string inputData)
        {
            var result = FindMostProfitableTrade.FindMostProfitableTradeForMonth(inputData);
            Assert.IsFalse(result.IsSuccess);
            Assert.IsEmpty(result.Result);
            Assert.IsNotEmpty(result.Error);
        }
    }
}