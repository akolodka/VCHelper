using System.Runtime.InteropServices;
using ExcelDna.Integration.CustomUI;
using HelperUDF.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelperUDF.ExcelApi
{
    [ComVisible(true)]
    public class CustomRibbon : ExcelRibbon
    {
        public void OnRibbonLoad(IRibbonUI ribbon)
        {
            IHost host = CreateHost();

            var service = ActivatorUtilities.CreateInstance<CalculateService>(host.Services);

            ExcelWorksheetFunctions.Initialize(service);
        }

        private IHost CreateHost()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<ICalculateService, CalculateService>();
                })
                .Build();
        }

        public void OnHelpButtonPressed(IRibbonControl control)
         {
            var message = @"=ОКРУГЛГОСТ (value, uncertainty, isShowWithUncertainty)
                            
Округлить численное значение согласно правилу, изложенному в приложении Е ГОСТ Р 8736–2011.
                            
value - численное значение,

uncertainty - относительная неопределённость измерений, %

isShowWithUncertainty - отобразить результат как значение ± абсолютная неопределённость.

-----------------------------

=ОСКОСА (values)

Рассчитать относительное среднее квадратическое отклонение среднего арифметического оценки измеряемой величины согласно ГОСТ Р 8.736–2011, %.

values - cовокупность значений диапазона ячеек. Учитываются только численные значения, которых должно быть более одного.";

            MessageBox.Show(
                caption: "Пользовательские функции",
                text: message);
        }
    }
}
