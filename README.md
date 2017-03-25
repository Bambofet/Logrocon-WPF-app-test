# Logrocon-WPF-app-test
WPF app using MVVM for Logrocon

1.Требуется разработать WPF-приложение, используя C#.
2. Приложение должно позволять размещать информацию о клиентах и их заказах.
3. Система должна реализовывать следующие функции:
Добавление клиента,
Удаление клиента,
Добавление заказа на товар для клиента,
Редактирование заказа,
Удаление заказа.
4. Обисание сущностей:
Атрибуты Клиента:
Name (string),
Address (string),
VIP (bool).
Атрибуты Заказа:
Number (int) уникальный,
Description (string).
5. Реализация приложения на основе применения паттерна MVVM.
6. Приложение должно содержать форму с 2 областями (Master-Detail)
7. Первая область должна отображать список клиентов
8. Вторая область должна отображать заказы для клиента, выбранного в первой области.
9. Клиенты с признаком VIP должны выделяться в списке цветом.
10. Можно сделать хранение списков in-memory, реализация хранения в БД будет дополнительным плюсом.