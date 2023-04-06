# PetProject

Структура: 
1) либо блог, где будут статьи публиковаться, дневник, либо же заметки
2) что-то связанное с авторизацией пользователя
3) интересный вариант с фильмами, показывать список фильмов, которые хочется посмотреть 
и извлекать из из бд (в качестве бд microsoft sql server) мб показывать их постеры ещё
возможно сделать доступ получения данных о фильмах из imdv: https://translated.turbopages.org/proxy_u/en-ru.ru.107ac18f-6401177d-aaa3c7a0-74722d776562/https/www.imdb.com/
приложение должно:
- Храните данные о новом фильме
- Извлеките данные о фильме, который существует в библиотеке
- Включите функцию поиска и возможность редактирования записей
 
 * проект должен был написать с помощью фрэймворка ASP.NET весь html код должен быть записал в качестве cshtml
 * может быть попробовать как вариант написать на обычном html и использовать часть js длля фронта (а ещё лучше typescript)
 * для работы с бд (microsoft sql server) будет использоваться фрэймворк Entity
 * также жолжна быть реализация dependency injection, то есть должны хорошо реализованы интерфейсы, которые будут передаваться в конструктор
 * должны быть свои контроллеры и свои аркестраторы для работы бэка 
 * сделать отдельный файл (типо ApiNSFacade) в котором будут методы для добавления, или удаление записей, эти 
 методы должны реализовывать проверки на неправильные запросы
 * должен быть свой сваггер
 
 
 * структура проекта под блог:
 на начальной страничке должна показываться приветственная информация с красивым оформлением (или не очень), а так же милые картинки, например с котиками
 также должна быть вторая страница уже с самим блогом:
  - должна быть под шапкой кнопка, которая отвечает за создание новой записи
  - под этой кнопкой будут расположены наши записи, постараться реализовать добавление комментариев под каждую запись 
  - если времени хватит постараться реализовать авторизацию с заполнением имени профиля и установки своей аватарки

## Миграции
-- add-migration Initial -context PostgreSqlContext
Чтобы накатить миграцию, открываем в VS 'View'-'Other Windows'-'Pakage Manager Console'
В 'Default project' выбираем 'Neolant.NsPlugin.DataContext.PostgreSql'
Вставляем и выполняем команду add-migration <Название миграции + краткая инфо>
Проверяем миграцию в проекте Neolant.NsPlugin.DataContext.PostgreSql
Через Debug запускаем проект Neolant.NsPlugin.DbUpdater

Для пересозадния БД в проекте Neolant.NsPlugin.DbUpdater ищем launchSettings.json и меняем -m на -r
Для подклчюения к неосинтезу в таблицу SettingSystemAccount, в BaseAddress нужно будет вставить https://kaskad-dev.io.neolant.su


## Средства разработки
- Microsoft Visual Studio 2017 и выше
- Visual Studio Code

## Особенности

  - Язык разработки backend - c# (.NET Core 2.2)
  - Язык разработки frontend - TypeScript ([Angular](https://angular.io/))
  - CSS Framework [Angular Material](https://material.angular.io/)
  - СУБД - MS SQL (не обязательно)

## Сборка Web клиента

- Установить [Node.js](https://nodejs.org/ "Node.js")

```
cd .\NsPluginExample\frontend\angular\my-app
npm install
npm run build
```

## Сборка и запус Web приложения

- Установить [.NET Core](https://www.microsoft.com/net/download ".NET Core")
```
dotnet restore NsPluginExample
dotnet build NsPluginExample
dotnet NsPluginExample
```

## Сборка и запуск приложения в IDE 

Приложение разделено на две части (backend и frontend).  
Backend запускается в MS VS как любое другое .NET Core приложение.  
Frontend запускается командой 
```
npm run start
```

При запуске из IDE используется appsettings.Development.json
При хостинге - appsettings.json