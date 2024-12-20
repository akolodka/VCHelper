# Помощник ПКР -- UDF Excel

Пример реализации возможностей платформы .NET при создании пользовательских функций Excel.

Для работы требуется .NET 6 runtime.

## Начало работы

Запустить VCHelperUDF-packed.xll / VCHelperUDF64-packed.xll (в зависимости от разрядности Excel)

На вкладке «Главная» появится дополнительная кнопка со справкой по доступным UDF:

![Title](https://github.com/akolodka/helperUDF/blob/master/resources/helperUDF_ribbonButton.png)

## Функция ОКРУГЛГОСТ. Округление согласно ГОСТ Р 8.736–2011

В ячейке листа ввести наименование функции и передать параметры:

![Title](https://github.com/akolodka/helperUDF/blob/master/resources/RoundExample1.png)
![Title](https://github.com/akolodka/helperUDF/blob/master/resources/RoundExample%20-2.png)

## Функция ОСКОСА. Вычисление относительного среднего квадратического отклонения среднего арифметического оценки измеряемой величины согласно ГОСТ Р 8.736–2011

В ячейке листа ввести наименование функции и передать параметры. Нечисловые значения игнорируются:

![Title](https://github.com/akolodka/helperUDF/blob/master/resources/MeanSquareExample.png)
![Title](https://github.com/akolodka/helperUDF/blob/master/resources/MeanSquareExample%20-2.png)

Аналогичное вычисление с применением встроенных функций Excel:

![Title](https://github.com/akolodka/helperUDF/blob/master/resources/MeanSquareExample%20-3.png)

Сопоставление результатов вычислений:

![Title](https://github.com/akolodka/helperUDF/blob/master/resources/MeanSquareExample%20-4.png)
![Title](https://github.com/akolodka/helperUDF/blob/master/resources/MeanSquareExample%20-5.png)
