# Zadání projektu

TODO - zjednotiť jazyk

## Důležité upozornění
Pro hodnocení projektu (a úspěšné absolvování předmětu) je nutno dokončit **obě 2 fáze projektu** a projekt **obhájit**. Pokud projekt nebude při obhajobě obsahovat základní funkcionalitu uvedenou v zadání, bude hodnocen 0 body. **Nespokojíme se tedy s nedokončeným projektem**. Tuhle poznámku sem dáváme proto, že se v předchozích  ročnících vyskytly týmy, které po dosáhnutí součtu 50 bodů za předmět po 1. fázi rozhodly nedokončit projekt a poté byly nemile překvapeni, když se po nich vyžadovala plná funkcionalita při obhajobě. Dejte si na to tedy prosím pozor.

## Cíl
Cílem je vytvořit použitelnou a snadno rozšiřitelnou aplikaci, která splňuje požadavky zadání. Aplikace nemá padat nebo zamrzávat.

Zadání úmyslně není striktní, je Vám ponechána volnost, pro vlastní realizaci. Při hodnocení je kladen důraz na technické zpracování a kvalitu kódu. Pokud Vám přijde, že v zadání chybí nějaká funkcionalita, neváhejte ji doplnit. Pište aplikaci tak, aby jste ji sami chtěli používat.

## Zadanie

Jednoduchý e-shop

## Data

V rámci dat, se kterými se bude pracovat budeme požadovat minimálně následující data.

### Zboží

- Název
- Fotografie
- Textový popis
- Cena
- Hmotnost
- Počet kusů na skladě
- Kategorie
- Výrobce
- Hodnocení

### Kategorie

- Název

### Výrobce

- Název
- Textový popis
- Obrázek (logo)
- Země
- Seznam zboží

### Hodnocení

- Číselné hodnocení
- Textové hodnocení

## Varianty projektu

Projekt má dve varianty a je na vás akú z nich si vyberiete. Od vybranej varianty sa ďalej odvíja čo sa po vás bude vyžadovať v jednotlivých fázach odovzdania

### Varianta A - **backend + DB**

- Vytvorenie backendu e-shopu s využití skutočnej databáze (napr. MSSQL)
- Dôraz sa bude dbať na technické prevedenie, správnu prácu s databázov a čiastočne aj na architektúru

### Varianta B - **frontend + backend + fake DB**

- Vytvorenie backendu e-shopu s využití fake databáze (čiže dáta budú uložené iba na úrovni kódu a po vypnutí aplikácie budú stratené)
- Bude nutné si vytvoriť vlastný `StorageService` ktorý bude simulovať skutočnú DB
- Vytvorenie frontendu ktorý bude konzumovať vytvorené Web API
- Samotný frontend je možné robiť pre
    - Desktop - .NET MAUI / Avalonia UI
    - Web - Blazor / Vue / React

## Odovzdanie

### 1. fáza - spoločná pre obe varianty

- Dátový model
- Web API ktoré bude spĺňať požadovanú funkcionalitu
- CI build

### 2. fáza - varianta A - **backend + DB**

- Kód štrukturalizovaný min. do dvoch vrstiev (DAL a API)
- Repositories a QueryObjects
- Mapovanie entít na DTOs
- Integračné testy
- CI test

### 2. fáza - varianta B - **frontend + backend + fake DB**

- Vytvorenie frontendu v zvolenej technológii
- Napojenie frontendu na API
- Integračné testy

TODO - je dobre robiť integračné testy keď to API bude pravedpodobne shit code?

## Bonusy

Bonusové body je možné získať za:
- Logging
- Zakomponovanie code style policy do CI
