# Welcome to the Giuffre Editore SIREG Project

SIREG is an acronym for Sistema Integrato Redazionale Giuffre.

## Install VPN
1. Install the RootCA and put it into the Trusted Certification Authorities.

> you can find all certificates in \\\fmserver\Setup\Giuffre\VPN

2. Install the personal certificate with password **Infrac0m**.
3. Open Internet Explorer and browse [here](https://vpn.infracom.it).
4. login with password **Factorymind01!**.
5. Accept and install the plugin.

## Dev box Setup
1. Ensure you have configured the [VPN correctly](#Install-VPN)
2. Install an oracle client

> We usually use the lightweight bin deployable **OracleClient**, you can find the folder on \\\fmserver\Setup\Setup\Development\Oracle\instantclient-basiclite-windows.x64-12.1.0.2.0.zip
After the you have copied the content of the zip on your drive (e.g. in C:\OracleClient), you have to put that folder inside the **PATH** environment variable.

3. Install TOAD or Sql Developer.
4. Install Visual Studio 2015 or newer.
5. Install VSCode latest version.
6. Install latest version of Node.js.
    * Install NPM version 2.10 or newer globally (`npm install npm -g`)
    * Install gulp globally (`npm install gulp -g`)
    * NPM install all packages in each front-end project (`npm install`)
    * Install bower globally (`npm install bower -g`)
    * Do a bower install in each front-end project (`bower install`)
7. Make visual studio use latest version of node and NPM.
8. Create a SqlServer database named `Giuffre.Hangfire` 

> To make visual studio use latest version of node, follow the instructions [here](http://josharepoint.com/2016/05/04/how-to-configure-visual-studio-2015-integration-with-latest-version-of-node-js-and-npm/)

Congrats, you are ready to go! :smile:

## Development flow
The solution (Giuffre.Sireg.sln) does not contains the front-end projects, so depending on what side of the project you are working on, you can either work only on VSCode or Visual Studio.

> The typical front-end development workflow is to open VS2015 compile and run the solution (F5), after this step you can detach VS2015 and leave IIS express running and even close VS2015..
> If you work on the back-end side and you have to launch the front-end you could use the provided **run_front_end.cmd** batch command.

## Unit Testing
We use xUnit 2.X as a unit test framework, we use the following convention for naming the unit test method _Should\_ExpectedBehavior\_When\_StateUnderTest_ and we usually put a `[CategoryAttribute]` on each test method to categorize tests.

---

## Oracle configuration
Sireg has 3 distinct databases environments, we identify those instances as **Development**, **Staging** and **Production**

### Development
| Configuration | Value |
|----|-----|
| User | teseo2 |
| Host | 10.1.0.231 |
| Port | 1526 |
| SID | SVGENLIN |

### Staging
| Configuration | Value |
|----|-----|
| User | teseo2 |
| Host | 10.1.0.230 |
| Port | 1521 |
| Service Name | DBGENLIN |

### Production
| Configuration | Value |
|----|-----|
| User | teseo2 |
| Host | 10.1.0.52 |
| Port | 1521 |
| Service Name | DBGENLIN |

---

## Prerequisite
* IIS url rewrite module 2.0 [here](https://www.microsoft.com/it-it/download/details.aspx?id=7435) (just for front-end projects)
* .NET Framework 4.6 or higher, you can download it from [here](https://www.microsoft.com/it-it/download/details.aspx?id=49982)
* Visual C++ Redistributable Package for Visual Studio 2013 [here](https://www.microsoft.com/it-it/download/details.aspx?id=40784)
* Microsoft Web Deploy 3.5 [here](https://www.microsoft.com/it-it/download/details.aspx?id=39277) (just needed for continuous deployment)
* SQLServer Express. During installation phase you have to enable the Mixed Authentication (provide a valid password).
* Create a folder named Documents in IoServices site directory and give all the privileges to the appPool user identity

```
sqlcmd -s .\SQLEXPRESS -E

USE MASTER 
GO

ALTER LOGIN [sa] WITH PASSWORD='sa', CHECK_POLICY=OFF
GO

ALTER LOGIN [sa] ENABLE
GO
``` 

A Database named Giuffre_Hangfire needs to be created (schema generation is automatic), it not necessary to have SqlServerManagement Studio installed. It is possibile to create the Database directly from command line.

```
sqlcmd -s .\SQLEXPRESS -U{username} -P{password}

USE MASTER 
GO

create database [Giuffre_Hangfire]
GO
``` 

---

## Glossary

The following table contains the vast majority of terms used throughout the Project

| Name | Meaning |
|----|-----|
| ActType | Tipo Atto |
| Bearings | Bussole |
| Breakouts | Neretti |
| Headword | Lemmario |
| LawComment | Commento a legge (Manuale IVA) |
| LawReference | Riferimenti Normativi |
| LegalFramework | Inquadramento |
| Maxim | Massima |
| Media | Media |
| Nested | Canguro |
| Preamble | Preambolo |
| RepertoireYear | Anno Rep. |
| Sanction | Sanzione (Manuale IVA) |
| Source | Fonte |
| SubExtension | Sottoestensione |
| Subject | Materia |
| VatManual | Manuale IVA |
| Verdict | Sentenza |

### Enums
The following table contains relation between db tables and model enums

| Name | Table |
|----|-----|
| DataBankType | ANAG_DATABANKS |
| DocumentType | ANAG\_TIPO_DOC |
| DocumentUnitType | ANAG\_TIPO_UD |
| JumpType | ANAG\_TIPO_JUMP |
| TextFormat | ANAG_FORMATO |
| ClassificationType | ANAG\_TIPO_LEMMARIO |