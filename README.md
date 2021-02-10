# XPC-MW5 Programming in .NET and C#, Organizational Details

# MS Teams

Pro připojení do týmu **XPC-MW5-2021** použijte přístupový kód **z4pwlvv**.

---
# Aktuality k předmětu 

- **22.09.2020** | *Jan Pluskal* | [Visual Studio 2019 Enterprise](https://aka.ms/devtoolsforteaching) je nově dostupné v Azure Dev Tools for Teaching. Přihlášení je nutné s loginem z domény VUT, tj xlogin00@vutbr.cz
- **07.02.2021** | *Patrik Švikuha* | Při vytváření repozitáře respektujte schéma ze [zadání](/Project/README.md) *https://dev.azure.com/xpc-mw5-2021-team0000/project*. Je nezbytně nutné použít Vaše účty z doménu *vutbr.cz*. Do Vašich repozitářů pro projekt přidejte účet **uciteliw5@vutbr.cz**. Pokud uděláte chybu a pouze nesedí url, dá se v nastavení změnit.
  - Pokud máte vytvořeno pod soukromými účty, je třeba vytvořit projekt znovu pod univerzitními a pushnout existující repozitář tak, aby Vám zůstala historie včetně správných časů commitů. 
  - Pokud bude kolize s existující organizací, použijte suffix *team0000-01*.

---
# Přednášky

[Organizace kurzu](https://gitpitch.com/fitiw/xpc-mw5?grs=github&t=white&p=Lectures%2FLecture_00#/)

| Fakulta | Místnost    | Čas            |
| ------- | ----------- | -------------- |
| FEKT    | T12/SD 2.99 | Čt 15:00-16:50 |

+++

| Datum   | Téma přednášky                                                 |
| ------- | -------------------------------------------------------------- |
| 11. 02. | Úvod do kurzu, Úvod do jazyka C# a platformy .NET, část 1.     |
| 18. 02. | Úvod do objektově orientovaného programování                   |
| 25. 02. | Úvod do jazyka C# a platformy .NET, část 2.                    |
| 04. 03. | Generic host (Inversion of Control, logging, konfigurace)      |
| 11. 03. | ASP.NET Core (Web API, MVC), CI/CD na Azure DevOps a Azure     |
| 18. 03. | Clean Code                                                     |
| 25. 03. | Testovaní                                                      |
| 01. 04. | ASP.NET Core Blazor (Radzen)                                   |
| 08. 04. | Web frontend                                                   |
| 15. 04. | "Takhle napišete projekt"                                      |
| 22. 04. | Clean code v C# (Roslyn analyzers, dotnet tools, editorconfig) |
| 29. 04. | "Vývoj v praxi" (CI/CD, IaC, MVP, etika na code review)        |
| 06. 05. | Bonus                                                          |

---

# Cvičení 
Cvičení jsou demonstrační. Pokud možno, přineste si vlastní zařízení na kterém budete moct cvičení aktivně zúčastnit. Bude potřeba vývojové prostředí ideálně Visual Studio 2019 / Rider / VSCode.

| Typ                  | Místnost    | Čas            |
| -------------------- | ----------- | -------------- |
| Demonstrační cvičení | T12/SD 2.99 | Čt 17:00-18:50 |

+++

| Datum   | Téma cvičení                                                           |
| ------- | ---------------------------------------------------------------------- |
| 11. 02. | C# tooling, VS - založení projektu ASP.NET Core, založení Azure DevOps |
| 18. 02. | Objektovo orientované programování v C#                                |
| 25. 02. | LINQ, generika, async/await, Task                                      |
| 11. 03. | ASP.NET Core Web API, CI/CD                                            |
| 25. 03. | Testovaní                                                              |
| 01. 04. | ASP.NET Blazor + napojení na Web API                                   |

---

# Projekt
* Projekt bude vypracovaný v 3-členném týmu. 

| Fáze | Deadline   | Obsah                                   |
| ---- | ---------- | --------------------------------------- |
| 1    | 04.04.2021 | API                                     |
| 2    | 07.05.2020 | Finalizace aplikace a následná obhajoba |

* Při obhajobě:
  * musí být přítomni všichni členové týmu,
  * obhajovat projekt bude náhodně vybraný člen týmu,
  * nemusíte chodit v obleku...,
  * projekt musí bezpodmínečně obsahovat **Must have features!**

--- 
# Nástroje použity ve cvičeních

| Nástroj                                                                                              | Typ                | Popis                                                                                                                             |
| ---------------------------------------------------------------------------------------------------- | ------------------ | --------------------------------------------------------------------------------------------------------------------------------- |
| [Visual Studio 2019 Enterprise](https://aka.ms/devtoolsforteaching)                                  | Samostatný program | Hlavní vývojové prostředí pro .Net                                                                                                |
| [Resharper](https://www.jetbrains.com/resharper/)                                                    | Doplněk            | Nástroje na lepší produktivitu, refaktorování. Studentská licence je k dispozici zdarma [zde](https://www.jetbrains.com/student/) |
| [Code metrices](https://visualstudiogallery.msdn.microsoft.com/369d38e1-53d3-4f5c-9351-a0560162a6d9) | Doplněk            | Zobrazování složitosti jednotlivých metod                                                                                         |
| [Postifx templates](https://github.com/controlflow/resharper-postfix)                                | Doplněk            | Plynulé doplňování částí kódu bez nutnosti vracení se                                                                             |

+++

| Nástroj                                                                                                                                 | Typ                | Popis                                          |
| --------------------------------------------------------------------------------------------------------------------------------------- | ------------------ | ---------------------------------------------- |
| [Mnemonic Live Templates](https://github.com/JetBrains/mnemonics)                                                                       | Doplněk            | Doplňování částí kódu                          |
| [LinqPad](http://www.linqpad.net/)                                                                                                      | Samostatný program | Nástroj na přístup do databáze přes Linq, SQL… |
| [DotPeek](https://www.jetbrains.com/decompiler/)                                                                                        | Samostatný program | Dekompilátor C# kódu                           |
| [MarkdownEditor](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor)                                     | Doplněk            | Handy Markdown editor for VS                   |
| [Entity Framework 6 Power Tools](https://marketplace.visualstudio.com/items?itemName=ErikEJ.EntityFramework6PowerToolsCommunityEdition) | Doplněk            | View Entity Data Model                         |
| [OzCode](https://www.oz-code.com/)                                                                                                      | Doplněk            | Advanced debugging tools                       |
| [GitFlow](https://marketplace.visualstudio.com/items?itemName=vs-publisher-57624.GitFlowforVisualStudio2017)                            | Doplněk            | GitFlow                                        |

--- 
# Q&A

* Q: Slyšel jsem, že lze uznat místo projektu i bakalářskou práci nebo projekt do jiného předmětu napsaný v C#, je to pravda?
* A: Ano, ale projekt musí splňovat obecná kriteria (správný datový návrh, včetně dědičnosti a modifikátorů přístupu, SOLID a CleanCode) a musí být v C#. O tuto možnost žádejte indiviuálně po skončení přednášky.

---
# Výuka - bodové rozdělení

| Typ výuky | Maximální bodový zisk |
| --------- | --------------------- |
| Projekt   | 100                   |

--- 
# Vyučující
* [Martin Dybal](https://www.dybal.it/)
* [Tibor Jašek](mailto:tibor.jasek@gmail.com )
* [Patrik Švikruha](mailto:patrik.svikruha@gmail.com )
* [Michal Tichý](mailto:edu@tichymichal.net )

--- 
# Užitečné odkazy
* [Entity framework tutorial](http://www.entityframeworktutorial.net/code-first/entity-framework-code-first.aspx)
* [R. C. Martin SOLID](https://youtu.be/TMuno5RZNeE?t=757) Bob Martin SOLID Principles of Object Oriented and Agile Design 
* [Resharper features](https://www.jetbrains.com/resharper/features/) and how to use them.
* [Pro Git book](https://git-scm.com/book/en/v2)

--- 
# Užitečná literatura
* [C# 7.0 in a Nutshell](http://www.albahari.com/nutshell/about.aspx), Ben Albahari, Joseph Albahari
* [Clean Code: A Handbook of Agile Software Craftsmanship](https://books.google.cz/books?id=hjEFCAAAQBAJ), Robert C. Martin
* [Agile Principles, Patterns, and Practices in C#](https://books.google.cz/books?id=hckt7v6g09oC), Robert C. Martin
* [C# 3.0 Design Patterns](https://books.google.cz/books?id=pD2XMZLGUAYC), Judith Bishop
