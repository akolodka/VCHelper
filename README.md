# helperUDF 
Пример размещения пользовательских функции Excel в надстроке .xll.

## Начало работы
Для работы надстройки требуется .NET 6 runtime.

Запустить HelperUDF-AddIn.xll.

На вкладке «Главная» появится дополнительная кнопка со справкой по доступным пользовательским функциям:

![Title](https://github.com/akolodka/helperUDF/blob/master/resources/helperUDF_ribbonButton.png)

Содержимое справки:

![Title](https://github.com/akolodka/helperUDF/blob/master/resources/helperUDF%20--%20messagebox.png)

## Пример округления

В любой ячейке листа ввести наименование функции и передать параметры:

![Title](https://github.com/akolodka/helperUDF/blob/master/resources/helperUDF%20--%20cell_function.png)

Результат выполнения будет помещен в ячейку, из которой вызвана функция:
![Title](https://github.com/akolodka/helperUDF/blob/master/resources/heplerUDF%20--%20result.png)

## Пример вычисления относительного среднего квадратического отклонения среднего арифметического оценки измеряемой величины

Ввод функции в ячейке листа. Нечисловые значения игнорируются:

![Title](https://github.com/akolodka/helperUDF/blob/master/resources/helperUDF%20--%20MeanSquareAverage.png)

Результат вычислений:

![Title](https://github.com/akolodka/helperUDF/blob/master/resources/helperUDF%20--%20MeanSquareAverage_result.png)

Вычисление с помощью встроенных функций Excel:

![Title](https://github.com/akolodka/helperUDF/blob/master/resources/helperUDF%20--%20MeanSquareAverage_checking.png)

Сопоставление результатов:

![Title](https://github.com/akolodka/helperUDF/blob/master/resources/helperUDF%20--%20MeanSquareAverage_check%20result.png)
