
![Logo](https://i.ibb.co/4PGFpYD/Logo-trans-white2.png)

![enter image description here](https://img.shields.io/badge/C%20Sharp-239120.svg?style=for-the-badge&logo=C-Sharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![MySQL](https://img.shields.io/badge/mysql-%2300f.svg?style=for-the-badge&logo=mysql&logoColor=white) ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Sever-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white) ![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)

![jQuery](https://img.shields.io/badge/jquery-%230769AD.svg?style=for-the-badge&logo=jquery&logoColor=white) ![Bootstrap](https://img.shields.io/badge/bootstrap-%23563D7C.svg?style=for-the-badge&logo=bootstrap&logoColor=white) ![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white) ![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)

:uk:

### AutoVertical - VEHICLE SALES APP

AutoVertical is a aplication created on the .NET platform, using ASP NET CORE. This is my first project in witch I used ASP technology.

#### PROJECT OBJECTIVES:

The major objectives was supply application witch enable publish, promote and control automotive adverts in the easy and convenient way. Additionally the application helps companies, witch bussines is selling vehicles. There is possibility establish/add own company and invite employees to publish ads together and sign as one organisation. AutoVertical also enables, publish a advertisements, with will be displayed for specified time in the most important places on the website.

  

#### USED TECHNOLOGIES

  

1. ASP .NET CORE

2. .NET 7 & C#11

3. MVC PATTERN

4. REPOSITORY PATTERN

5. Entity Framework

6. JavaScript

7. JQuery

8. Bootstrap

9. HTML 5 & CSS3

  

#### HOW TO RUN APPLICATION:

  

##### 1) Install DOTNET RUNTIME SDK

- To run the application, you need to download the .NET SDK runtime environment, version 7.0 

```git

https://dotnet.microsoft.com/en-us/download

```

##### 2) Configuring MS SQL

- To run the server application (backend), you first need to configure a local database server. This is essential for the proper functioning of the application.

- Download and install the MS SQL Server Express application from the link below:

```
https://download.microsoft.com/download/5/1/4/5145fe04-4d30-4b85-b0d1-39533663a2f1/SQL2022-SSEI-Expr.exe
```
- After the installation of MS SQL Server completes, the installer will display the name of the created server. In most cases, it will be `localhost\SQLEXPRESS`.
- Once MS SQL Server is installed, you need to prepare a database to be used by AutoVertical. To do this, open the CMD or PowerShell terminal and connect to the server with the following command:
```
	sqlcmd -S localhost\SQLEXPRESS -E
```
- After logging in to SQL Server, you can run the following SQL query to create a database:
```
1> CREATE DATABASE AutoVertical; 
2> GO
```
- If you followed all the steps correctly, you should have a database ready for use.

##### 3) Cloning the Repository

- To clone the repository, navigate to your chosen folder on your computer and use the following command:

```c#

git clone https://github.com/jczarnecki014/ASP.NET-Core---AutoVertical.git

```
##### 4) Configuring `appsettings.json` File
In this file, you need to configure the correct connection to the previously created database. To do this, edit the following lines:
```
"ConnectionStrings": { 
"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=AutoVertical2;Trusted_Connection=True;TrustServerCertificate=True", 
},
```
-   In the `Server` field, enter the SQL server name displayed during the MS SQL Server installation.
-   In the `Database` field, enter the name of the database you created.
- When the application is run for the first time, the full database configuration will be automatically deployed.

##### 5) Running the Application
To run the application, open the main project folder in console mode and run the application with the command `dotnet run`.
```
\ASP.NET-Core---AutoVertical\AutoVertical(main -> origin) 
λ dotnet.exe run
```
 - After starting, the compiler will return an address that you need to paste into your browser:
 ```
info: Microsoft.Hosting.Lifetime[14] 
Now listening on: http://localhost:5291
 ```
 
In my case, I should enter the address `http://localhost:5291` in the browser.

#### How you are able to see this application without cloning the repository ?

For this purpose I have prepared for you video in with I have described every objectives of project and presented each implemented feature step by step

  

To wath vide click the icon [![YouTube](https://img.shields.io/badge/YouTube-%23FF0000.svg?style=for-the-badge&logo=YouTube&logoColor=white)](https://www.youtube.com/watch?v=NZTqcjDDxBU)

  

  
  

## If you will have a problem

I hope you run my application without any problems. If you will have some questions, i invite to contact me .

  

##### Contact with me:

[![Outlook](https://img.shields.io/badge/Microsoft_Outlook-0078D4?style=for-the-badge&logo=microsoft-outlook&logoColor=white)](mailto:czarnecki.web@outlook.com) [![Facebook](https://img.shields.io/badge/Facebook-%231877F2.svg?style=for-the-badge&logo=Facebook&logoColor=white)](https://www.facebook.com/kuba.czarnecki.142/) [![Instagram](https://img.shields.io/badge/Instagram-%23E4405F.svg?style=for-the-badge&logo=Instagram&logoColor=white)](https://www.instagram.com/_czarnecky_/)

#

  

:poland:

  

### AutoVertical - VEHICLE SALES APP

AutoVertical jest aplikacją, która powstała na platformie .NET wykorzystując technologie ASP NET CORE. Jest to mój pierwszy projekt w, którym korzystam z technologii ASP.

#### CELE PROJEKTOWE:

Głównymi celami projektowymi było dostarczenie klientom aplikacji pozwalającej w prosty i wygodny sposób publikować ogłoszenia motoryzacyjne, promować je oraz kontrolować ich statystyki (takie jak wyświetlenia). Dodatkowo aplikacja wychodzi na przeciw firmą, które zawodowo zajmują się sprzedażą samochodów. Istnieje możliwość zarejestrowania swojej działalności oraz zaproszenia do niej pracowników aby wspólnie publikować treści na stronie podpisując się jako jedna organizacja.

AutoVertical umożliwia również, publikowanie reklam, które będą wyświetlane przez określony czas w kluczowych miejscach witryny.

  

#### ZASTOSOWANE TECHNOLOGIE

  

1. ASP .NET CORE

2. .NET 7 & C#11

3. Wzorzec MVC

4. Wzorzec Repozytorium

5. Entity Framework

6. JavaScript

7. JQuery

8. Bootstrap

9. HTML 5 & CSS3

  

Sposób uruchomienia aplikacji:

  

1) Instalacja DOTNET RUNTIME SDK

- Aby uruchomić aplikacje, potrzebujemy pobrać środowisko uruchomieniowe .NET SDK minimum w wersji 7.0

```git

https://dotnet.microsoft.com/en-us/download

```

2) Konfiguracja MS SQL
Aby uruchomić aplikację serwerową (backend) w pierwszej kolejności należy skonfigurować lokalny serwer bazodanowy. Jest on niezbędny do prawidłowego uruchomienia aplikacji.

- Pobierz i zainstaluj aplikacje MS SQL Serwer Express z linku
```
https://download.microsoft.com/download/5/1/4/5145fe04-4d30-4b85-b0d1-39533663a2f1/SQL2022-SSEI-Expr.exe
```
- Gdy zakończy się instalacja MS SQL Serwer instalator wyświetli nazwę utworzonego serwera. W większości przypadków jest to `localhost\SQLEXPRESS`
- Gdy zainstalujesz MS SQL Serwer musisz przygotowac bazę danych, która będzie wykorzystywana przez AutoVertical. W tym celu uruchom terminal CMD lub PowerShell i nawiąż połączenie z serwerem komendą:
    ``` 
    c:/>
    sqlcmd -S localhost\SQLEXPRESS -E
    ```
- Po zalogowaniu się do SQL Server, możesz wykonać zapytanie SQL, aby utworzyć bazę danych:
    ```
    1> CREATE DATABASE AutoVertical;
    2> GO
    ```
- Jeżeli wykonałeś wszystkie operacje zgodnie z instrukcją powinieneś mieć wstępnie utworzoną bazę danych gotową do pracy.

3) Pobranie repozytorium

- Aby pobrać repozytorium proszę wejść w wybrany folder na komputerze i zastosować komendę:

```cmd

git clone https://github.com/jczarnecki014/ASP.NET-Core---AutoVertical.git

```

4) Konfiguracja pliku appsettings.json
W tym pliku należy skonfigurować prawidłowe połączenie z utworzoną wcześniej bazą danych aby to zrobić należy edytować linie:
```
"ConnectionStrings": {
	"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=AutoVertical2;Trusted_Connection=True;TrustServerCertificate=True",
},
```
- W miejscu server powinieneś wpisać nazwę serwera SQL, która została ci zwrócona podczas instalacji MSSQL servera
- Database: tu wpisz nazwę utworzonej przez ciebie bazy danych
W momencie pierwszego uruchomienia aplikacji pełna konfiguracja bazy danych zostanie wdrożona automatycznie.
5) Uruchomienie aplikacji

- Aby uruchomić aplikacje, proszę otworzyć w trybie konsolowym folder z projektem głównym a następnie uruchomić aplikację komendą "dotnet run"

```c#

\ASP.NET-Core---AutoVertical\AutoVertical

```

```c#

\ASP.NET-Core---AutoVertical\AutoVertical(main -> origin)

λ  dotnet.exe  run

```

- Po uruchomieniu, kompilator zwróci Państwu adres, który należy wkleić do przeglądarki

```c#

info: Microsoft.Hosting.Lifetime[14]

Now  listening  on: http://localhost:5291

```

  

- W moim przypadku w przeglądarce powinniśmy wpisać adres "http://localhost:5291"

  

#### Jak zobaczyć aplikację bez pobierania i kompilowania repozytorium ?

W tym celu przygotowałem dla Państwa materiał wideo, w którym szczegółowo opowiadam na temat projektu oraz prezentuję krok po kroku każdą zaimplementowaną funkcjonalność

  

Aby zobaczyć materiał, kliknij w ikonę [![YouTube](https://img.shields.io/badge/YouTube-%23FF0000.svg?style=for-the-badge&logo=YouTube&logoColor=white)](https://www.youtube.com/watch?v=NZTqcjDDxBU)

  

  
  

## Mam nadzieje, że wszystko zadziała bez problemu. W razie pytań zapraszam do kontaktu.

W razie jakiś problemów z uruchomieniem projektu, zapraszam do kontaktu ze mną

  

##### Contact with me:

[![Outlook](https://img.shields.io/badge/Microsoft_Outlook-0078D4?style=for-the-badge&logo=microsoft-outlook&logoColor=white)](mailto:czarnecki.web@outlook.com) [![Facebook](https://img.shields.io/badge/Facebook-%231877F2.svg?style=for-the-badge&logo=Facebook&logoColor=white)](https://www.facebook.com/kuba.czarnecki.142/) [![Instagram](https://img.shields.io/badge/Instagram-%23E4405F.svg?style=for-the-badge&logo=Instagram&logoColor=white)](https://www.instagram.com/_czarnecky_/)

#

![Logo](https://i.ibb.co/7Q3Kygd/baner-kolor.png)

![enter image description here](https://img.shields.io/badge/C%20Sharp-239120.svg?style=for-the-badge&logo=C-Sharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![Python](https://img.shields.io/badge/python-3670A0?style=for-the-badge&logo=python&logoColor=ffdd54) ![MySQL](https://img.shields.io/badge/mysql-%2300f.svg?style=for-the-badge&logo=mysql&logoColor=white) ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Sever-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white) ![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E) ![Bootstrap](https://img.shields.io/badge/bootstrap-%23563D7C.svg?style=for-the-badge&logo=bootstrap&logoColor=white) ![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white) ![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)