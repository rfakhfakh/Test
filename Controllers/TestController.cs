using Microsoft.AspNetCore.Mvc;

namespace FuwearTestTechnique.Controllers
{
    [ApiController]
    [Route("/")]
    public class TestController : ControllerBase
    {
       
        private static readonly string[] actions = new[] { "AMZN", "CACC", "EQIX", "GOOG", "ORLY", "ULTA" };

        private static readonly double[,] prices = new[,]
        {

            { 12.81, 11.09, 12.11, 10.93, 9.83, 8.14 },

            { 10.34, 10.56, 10.14, 12.17, 13.1, 11.22 },

            { 11.53, 10.67, 10.42, 11.88, 11.77, 10.21 }

        };

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Fibonnaci/{n}")]
        public int Fibonnaci(int n)
        {
            if( n < 1 || n > 100)
            {
                return -1;
            }
            if(n ==1) {
                return 1;
            }
            int a = 1;
            int b = 1;
            int c = 0;
            for (int i = 2; i < n; i++) {
                c = a + b;
                a = b;
                b = c;   
            }
            return c;
        }

        [HttpGet("Action")]
        public object Action()
        {
            var avgPrices = new double[actions.Length];
            for (int i = 0; i < actions.Length; i++)
            {
                double sum = 0;
              for (int j = 0; j < prices.GetLength(0); j++)
                {
                    sum += prices[j, i];
                }
                avgPrices[i] = sum / prices.GetLength(0);
            }
            int maxIndex = Array.IndexOf(avgPrices, avgPrices.Max());
            return new
            {
                Name = actions[maxIndex],
                AvgPrice = avgPrices[maxIndex]
            };

        }
    }
}