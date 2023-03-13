# Project Overview

## Important note

For successful completion of the course, both phases must be completed and the project must be successfully defended. The project must contain the functionality described above, or it will be classified with 0 points.

> For example, if you have completed 1 phase for 50 points, we require you to finish the second phase, or we will classify your project with 0 points.

## Goal of project


Your goal is to create a [minimum valuable product (MVP)](https://en.wikipedia.org/wiki/Minimum_viable_product) based on the specification. The application must be functional on presentation. We require you to ship a quality project that could be extended in the future. As it will be public on GitHub, try your best while working on this project as it could help you find your first or new job ;) So feel free to realize yourself and improve your project with any improvements outside of our specification. We have allowed you the flexibility to choose which part you would like to focus on (naive BE + FE or robust BE with a database).

## Specification

> Regarding the data with which you will work, we will require at least the following data.

## Data models 

### Commodity

- Name
- Image
- Description
- Price
- Weight
- Number of pieces in stock
- Category
- Manufacturer
- Reviews

### Category

- Name

### Manufacturer

- Name
- Description
- Image (logo)
- Country of origin
- List of commodities 

### Review

- Stars 
- Title
- Description

## Variants of the project

We have two variants of the projects. It is up to you which one you choose.

### Variant A - **backend + DB**
> This variant is intended for those who want to deep dive in BE and would like to figure out which problems they need to solve in the guts of the application. If you don't have a problem with abstract thinking, this will fit you.

- Create BE of an e-shop application with a database. (It is up to you whether you choose a relational or a NoSQL database.)

- Emphasis will be placed on the technical implementation, correct work with databases, and partially also on the architecture.

### Variant B - **frontend + backend + fake DB**

> This variant is intended for those who would like to have a general overview of both BE and FE. If you prefer to have a "nice visible" project that is pleasing to the user's eye, choose this variant.

- Creation of the backend of the e-shop using a fake database (that is, the data will not be persisted between application restarts).
- It will contain two parts:
  - BE with an API that contains your own `StorageService` that simulates a real DB (Create, read, update, delete) on a memory level.
  - FE that consumes this BE. It is up to you whether you choose web or desktop technologies.
    - Desktop - Avalonia UI / .NET MAUI
    - Web - Blazor / Vue / React

## Handover

### 1. phase - common for both variants

- Data model
- Functional Web API that persists data between calls
- CI build

### 2. phase - variant A - **backend + DB**

- Code will be in 2 layers (projects) DAL with DB access and API with the API itself
- Repository and Queue objects used for access to DB
- usage of [DTOs](https://en.wikipedia.org/wiki/Data_transfer_object)
    - with mapping between DTO and data models
- Integration tests of API
- CI that run tests

### 2. phase - variant B - **frontend + backend + fake DB**

- FE in the chosen technology stack
  - FE uses BE for data manipulation
- Integration tests of API

### Bonus

Bonus points are for
- Logging
- Codestyle check to CI pipeline
- usage of docker
- ...

## Project (repository) management in Github

Project will be hosted on GitHub in a public git repository. Right now we are not using any organization/team so feel free to use your hosting space.

There are several formal rules for repository:
> See sample project https://github.com/PadreSVK/xpc-mw5-2023-armagedon. 

* Project name must match regex `xpc-mw5-202[3-9]-(?!-)[a-z-]{4,20}$`, check your name https://regex101.com/r/jrW3fs/1
* contain proper gitignore file
* contain README.md
  * members of the team => (member's emails used in commits)
  * Choosen variant of the project (A||B)
* contain License MIT

From git history should be visible work of the whole team. If we figure out that some of the members are inactive we evaluate his score by 0. Collaboration will be done via *common repository with all members*, see [docs](https://docs.github.com/en/account-and-profile/setting-up-and-managing-your-personal-account-on-github/managing-access-to-your-personal-repositories/inviting-collaborators-to-a-personal-repository) or *via forks*, see [docs](https://docs.github.com/en/get-started/quickstart/fork-a-repo)


### Golden Path (happy path)

* work in one repository as collaborators
* for a chunk of functionality use pull requests
* make sure that you use the same email to create commits (if you do this, use rebase || ask for help)
* prepare PR for review 1
  * PR to branch with HEAD on 1. commit
  * tag finished commit with `release/2023/01`
* prepare PR for review 2
  * PR to branch with HEAD on commit with `release/2023/01` tag

## Suggested tools

### git

* [GitHub Desktop](https://desktop.github.com/)
* [others](https://git-scm.com/downloads/guis)

### IDE

* [Visual Studio](https://visualstudio.microsoft.com/) **free community edition**
* [Jetbrains Rider](https://www.jetbrains.com/community/education/#students) **free for students and teachers**

### others

* [GH student pack](https://education.github.com/pack?utm_source=github+jetbrains)
* [Azure for Students](https://azure.microsoft.com/en-us/free/students/)
  * [Azure education Hub](https://aka.ms/startEDU)

