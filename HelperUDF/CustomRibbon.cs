using ExcelDna.Integration.CustomUI;
using System.Runtime.InteropServices;


namespace HelperUDF
{
    [ComVisible(true)]
    public class CustomRibbon : ExcelRibbon
    {
        public void OnRibbonLoad(IRibbonUI ribbon)
        {
            return;
        }

        public void ShowHelp(IRibbonControl control)
        {
            var message = @"=RoundGOST(value, uncertainty, isShowWithUncertainty)
                            
Округлить численное значение согласно правилу, изложенному в приложении Е ГОСТ Р 8736–2011.
                            
value - численное значение,

uncertainty - относительная неопределённость измерений, %

isShowWithUncertainty - Отобразить результат как значение ± абсолютная неопределённость.

-----------------------------

=MeanSquareAverage(values)

Рассчитать относительное среднее квадратическое отклонение среднего арифметического оценки измеряемой величины согласно ГОСТ Р 8.736–2011, %.

values - cовокупность значений диапазона ячеек. Учитываются только численные значения, которых должно быть более одного.";

            MessageBox.Show(text: message, caption: "Пользовательские функции");
        }
    }
}
