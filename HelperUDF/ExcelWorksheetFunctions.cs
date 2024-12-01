using ExcelDna.Integration;

namespace HelperUDF
{
    public static class ExcelWorksheetFunctions
    {
        [ExcelFunction(Description = "Округлить численное значение согласно правилу, изложенному в приложении Е ГОСТ Р 8736–2011")]
        public static object RoundGOST(

            [ExcelArgument(Description = "Численное значение")]
            double value,

            [ExcelArgument(Description = "Относительная неопределённость, %")]
            double uncertainty,

            [ExcelArgument(Description = "Отобразить результат как значение ± абсолютная неопределённость")]
            bool isShowWithUncertainty = false)
        {

            if (value <= 0 || uncertainty <= 0)
            {
                return ExcelError.ExcelErrorNA;
            }

            var absoluteUncertainty = value * uncertainty / 100;

            var digits = Core.GetRoundDigits(absoluteUncertainty);

            var result = (
                value: value.ToStringSafetyRounded(digits), 
                uncertainty: absoluteUncertainty.ToStringSafetyRounded(digits)
                );

            if(isShowWithUncertainty == true)
            {
                return $"{result.value} ± {result.uncertainty}";
            }

            return result.value;
        }

        [ExcelFunction(Description = "Рассчитать относительное среднее квадратическое отклонение среднего арифметического генеральной совокупности, %")]
        public static object MeanSquareAverage(

            [ExcelArgument(Description = "Совокупность значений диапазона ячеек. Учитываются только численные значения, которых должно быть более одного")]
            object[,] data)
        {
            var values = new List<double>();

            foreach (var d in data)
            {
                if (double.TryParse(d.ToString(), out var parsed) == true) 
                {
                    values.Add(parsed);
                }
            }

            if (values.Count < 2)
            {
                return ExcelError.ExcelErrorNA;
            }

            var average = values.Average();

            var squareValuesSum = values.Select(v => (v - average) * (v - average)).Sum();

            var result = 100 / average * Math.Sqrt(squareValuesSum / values.Count / (values.Count - 1));

            return result;
        }
    }
}