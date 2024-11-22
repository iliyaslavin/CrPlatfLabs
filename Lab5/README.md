# Lab 5: ASP.NET Core MVC Web Application

## Опис роботи
Ця лабораторна робота демонструє створення веб-застосунку за допомогою **ASP.NET Core MVC** з використанням наступних функцій:
1. **Структура проекту**:
   - Веб-застосунок (`Lab5WebApp`).
   - Бібліотека класів (`LabsLibrary`), яка містить функціонал з попередніх лабораторних.
2. **Інтеграція IdentityServer**:
   - Реалізовано систему авторизації та аутентифікації за допомогою `Duende.IdentityServer`.
3. **Ключові сторінки**:
   - **Головна сторінка**: Інформація про застосунок.
   - **Сторінка реєстрації**: Створення нового користувача.
   - **Сторінка логіну**: Аутентифікація користувачів.
   - **Сторінка профілю**: Відображення інформації про зареєстрованого користувача.
   - **Сторінка лабораторних**: Доступ до лабораторних завдань (Lab1, Lab2, Lab3).

## Функціональність
- **Реєстрація**:
  - Поля: Ім'я користувача, ПІБ, пароль, підтвердження пароля, телефон та електронна пошта.
  - Валідація: Перевірка довжини пароля, форматів телефону та email.
- **Логін**:
  - Перевірка наявності користувача у системі.
  - Після успішного логіну переадресація на сторінку профілю.
- **Профіль**:
  - Відображення даних користувача: ім'я, ПІБ, email, телефон.
  - Інформація тільки для перегляду, без можливості редагування.
- **Сторінка лабораторних**:
  - Три кнопки для переходу до реалізації функціоналу попередніх лабораторних робіт.

Запускається на хості `https://localhost:7214`.


## Висновок
У ході виконання лабораторної роботи я славін ілія:
1. Ознайомився з розробкою веб-застосунків за допомогою ASP.NET Core MVC.
2. Навчився інтегрувати та налаштовувати **IdentityServer** для аутентифікації та авторизації.
3. Реалізував базові CRUD-операції для користувачів через сторінки реєстрації, логіну та профілю.
4. Організував навігацію між сторінками.
5. Дізнався, як автоматизувати розгортання проєкту за допомогою віртуальних машин і скриптів.