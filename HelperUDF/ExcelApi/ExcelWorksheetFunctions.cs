using ExcelDna.Integration;
using HelperUDF.Extensions;
using HelperUDF.Core;

namespace HelperUDF.ExcelApi
{
    public static class ExcelWorksheetFunctions
    {
        private static ICalculateService Calc;
        internal static void Initialize (ICalculateService service)
        {
            Calc = service;
        }

        [ExcelFunction(
            Name = "ОКРУГЛГОСТ", 
            Description = "Округлить число согласно правилу, изложенному в приложении Е ГОСТ Р 8736–2011")]
        public static object RoundGOST(

            [ExcelArgument(Description = "Численное значение")]
            double value,

            [ExcelArgument(Description = "Относительная неопределённость, %")]
            double uncertainty,

            [ExcelArgument(Description = "Отобразить значение ± абсолютная неопределённость")]
            bool isShowWithUncertainty = false)
        {

            if (value <= 0 || uncertainty <= 0)
            {
                return ExcelError.ExcelErrorNA;
            }

            var absoluteUncertainty = value * uncertainty / 100;

            var digits = Calc.GetRoundDigits(absoluteUncertainty);

            var result = (
                value: value.ToStringRoundedSafety(digits), 
                uncertainty: absoluteUncertainty.ToStringRoundedSafety(digits));

            if (isShowWithUncertainty == true)
            {
                return $"{result.value} ± {result.uncertainty}";
            }

            return result.value;
        }

        [ExcelFunction(
            Name = "ОСКОСА",
            Description = "Рассчитать относительное среднее квадратическое отклонение среднего арифметического оценки измеряемой величины согласно ГОСТ Р 8.736–2011, %")]
        public static object MeanSquareAverage(

            [ExcelArgument(Description = "Совокупность значений диапазона ячеек. Учитываются только численные значения, которых должно быть более одного")]
            object[,] values)
        {
            var numValues = new List<double>();

            foreach (var d in values)
            {
                if (double.TryParse(d.ToString(), out var parsed) == true) 
                {
                    numValues.Add(parsed);
                }
            }

            if (numValues.Count < 2)
            {
                return ExcelError.ExcelErrorNA;
            }

            var average = numValues.Average();

            var squareValuesSum = numValues.Select(v => (v - average) * (v - average)).Sum();

            var result = 100 / average * Math.Sqrt(squareValuesSum / numValues.Count / (numValues.Count - 1));

            return result;
        }
    }
}