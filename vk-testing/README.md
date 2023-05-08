### Первый шаг - установи docker, а затем docker-compose.

### Второй шаг - быстренько глянуть глазами, потом ориентируемся на примеры.
Статьи для ознакомления:
1. [Как создать простое Rest API на .NET Core](https://habr.com/ru/articles/531106/)
2. [Ещё про REST API](https://www.freecodecamp.org/news/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28/)
3. [Basic Auth](https://www.codeguru.com/dotnet/authentication-asp-net/)
4. [Модели в ASP NET CORE](https://metanit.com/sharp/aspnet5/8.1.php)
5. [Официальная документация по вкаку в Entity Framework](https://learn.microsoft.com/ru-ru/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application)


Что было сделано:
1. Каркас приложения: контроллер, сервис, репозиторий, модели
2. Докер композ с Postgresql

### Третий шаг - сделать это.
Что надо сделать:
1. Написать нормальную логику в сервисе и репозитории
2. Сделать Enum классы для user_group и user_state 
2. Добавить обработку ошибок
3. Сделать Basic авторизацию
   3.1 Сделать 1 endpoint который возвращает HTML страничку для ввода данных
   3.2 Проверять корректность данных
4. Сделать миграции Flyway или другой инструмент
5. Доделать нормальный docker-compose.yml 
6. Написать Unit и Mock тесты 