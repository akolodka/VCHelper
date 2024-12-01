using ExcelDna.Integration.CustomUI;
using System.Runtime.InteropServices;

namespace HelperUDF
{
    [ComVisible(true)]
    public class RibbonControl : ExcelRibbon
    {
        public void ShowHelp(IRibbonControl control)
        {
            var message = @"=RoundGOST(value, uncertainty, isShowWithUncertainty)
                            
Округлить численное значение согласно правилу, изложенному в приложении Е ГОСТ Р 8736–2011.
                            
value - численное значение,

uncertainty - относительная неопределённость измерений, %

isShowWithUncertainty - Отобразить результат как значение ± абсолютная неопределённость.

-----------------------------

=MeanSquareAverage(data)

Рассчитать относительное среднее квадратическое отклонение среднего арифметического генеральной совокупности, %.

data - cовокупность значений диапазона ячеек. Учитываются только численные значения, которых должно быть более одного.";

            MessageBox.Show(text: message, caption: "Пользовательские функции");
        }
    }
}
