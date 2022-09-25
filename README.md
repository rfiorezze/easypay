<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

<!-- PROJECT LOGO -->
<br />
<p align="center">
  <img src="https://ri.logcp.com.br/wp-content/themes/mziq_log_2021_ri/img/logo.png" alt="Logo" width="auto" height="80">

  <h1 align="center">Núcleo LIA</h1>

  <p align="center">
    Chatbot da LOG.
    <br />
    <a href="https://apiqas.logcp.com.br/v1.0/lia/nucleo/swagger"><strong>Explore a api »</strong></a>
    <br />
    <br />
    <a href="https://mrvengenharia.visualstudio.com/Arquitetura/_wiki/wikis/Arquitetura.wiki/4053/Squad-LIA">Squad LIA</a>
    ·
    <a href="https://dev.azure.com/mrvengenharia/LOG/_backlogs/backlog/Squad%20LOGCP%20Chatbot/Stories">Reportar Bug</a>
    ·
    <a href="https://dev.azure.com/mrvengenharia/LOG/_backlogs/backlog/Squad%20LOGCP%20Chatbot/Stories">Solicitar Feature</a>
  </p>

## Selos Qualidade
[![Selo DevOps][DevOps]][url] [![Selo seguranca][seguranca]][url] [![Selo Governança][governanca]][url] [![Selo Dados][dados]][url] [![Selo Privacidade][privacidade]][url] [![Selo Arch][arch]][url]

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Indíce</summary>
  <ol>
    <li>
      <a href="#sobre-o-sistema">Sobre o Sistema</a>
      <ul>
        <li><a href="#functions">Functions</a></li>
        <li><a href="#feito-com">Feito Com</a></li>
      </ul>
    </li>
    <li>
      <a href="#build-local">Build Local</a>
      <ul>
        <li><a href="#pré-requisitos">Pré-Requisitos</a></li>
        <li><a href="#build-and-run">Build and Run</a></li>
      </ul>
    </li>
    <li><a href="#arquitetura">Arquitetura</a></li>
    <li><a href="#devops-links">DevOps Links</a></li>
    <li><a href="#política-de-branches">Política de Branches</a></li>
    <li><a href="#dados">Dados</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## Sobre o Sistema

Chatbot responsável pelo atendimento aos clientes da LOG, onde é possível:
* Tirar dúvidas frequentes
* Abrir chamados para solicitar pequenos reparos
* Abrir chamados para relatar direção perigosa
* Solicitar Boletos de condominio
* Solicitar listas de fornecedores do estado de seu condominio
* Solicitar documentos

![Big Picture](/docs/big_picture/big_picture.png)

### Feito com

* [AutoFixture](https://github.com/AutoFixture/AutoFixture)
* [Autofac](https://autofac.org/)
* [AutoMapper](https://automapper.org/)
* [Azure.Data.Tables](https://github.com/Azure/azure-sdk-for-net)
* [Azure.Messaging.ServiceBus](https://github.com/Azure/azure-sdk-for-net)
* [Bogus](https://github.com/bchavez/Bogus)
* [coverlet.collector](https://github.com/coverlet-coverage/coverlet)
* [FluentAssertions](https://github.com/fluentassertions/fluentassertions)
* [Flurl](https://www.nuget.org/packages/Flurl.Http)
* [MediatR](https://github.com/jbogard/MediatR)
* [Moq](https://github.com/moq/moq4)
* [NCrontab](https://www.nuget.org/packages/NCrontab.Signed)
* [Newtonsoft.Json](https://www.newtonsoft.com/json)
* [Polly](https://www.nuget.org/packages/Polly)
* [System.Linq.Async](https://github.com/dotnet/reactive)
* [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
* [System.IdentityModel.Tokens.Jwt](https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt)
* [TimeZoneConverter](https://www.nuget.org/packages/TimeZoneConverter)
* [Xunit](https://xunit.net/)

## Build Local

### Pré-requisitos

* .Net Core
  ```sh
  npm install dotnet-sdk-3.1
  ```

### Build and Run
1. Clone o repositório
   ```sh
   git clone https://mrvengenharia@dev.azure.com/mrvengenharia/LOG/_git/log_nucleo_lia
   ```
2. Entre no diretório do repositório
   ```sh
   cd log_nucleo_lia
   ```
3. Faça o build da solução
   ```sh
   dotnet build LOG.Lia.sln
   ```
4. Rode a solução
   ```sh
   dotnet run --project src/LOG.Lia/LOG.Lia.csproj
   ```
## Arquitetura

| Informação |Valor  |
|--|--|
| ☁️ Nuvem/Datacenter |Azure  |
| 💵 Custo Mensal Estimado | R$900,00 + AKS  |
| 🔑 Autenticação | Azure B2C |
<!-- ACKNOWLEDGEMENTS -->
## DevOps Links
* [SonarQube](https://sonarcloud.io/summary/new_code?id=mrvengenharia_log_nucleo_lia)
* [Application Insights](https://portal.azure.com/#@mrvengenhariasa.onmicrosoft.com/resource/subscriptions/cd3e43e8-6d91-451c-963c-0bae7a664788/resourceGroups/RSG-LOG-INTEGRACAOWHATSAPP-PRD/providers/Microsoft.Insights/components/ainucleoliaprd/overview)
* [Pipeline CI](https://dev.azure.com/mrvengenharia/LOG/_build?definitionId=1562)
* [Pipeline CD](https://dev.azure.com/mrvengenharia/LOG/_build?definitionId=1570)

## Dados

| Informação |Valor  |
|--|--|
| Localização do Banco |Azure  |
| Nome do Banco |sanucleoliaprd  |
| Tecnologia |Storage Account  |


### ERD
![Estrutura de dados](/docs/erd/diagrama_erd.png)

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[url]:https://mrvengenhariasa.sharepoint.com/:x:/s/ArquiteturaMRV/ER0QaKRLbsBMoJe3qRUfTXgBJZWvbUdBmlQkhmScZ_4H1w?e=VnIaeb

[DevOps]: https://arquiteturamrv.azurewebsites.net/api/ObterSelos?selo=devops&style=true&projeto=nucleolia
[seguranca]: https://arquiteturamrv.azurewebsites.net/api/ObterSelos?selo=seguranca&style=true&projeto=nucleolia
[governanca]:https://arquiteturamrv.azurewebsites.net/api/ObterSelos?selo=governanca&style=true&projeto=nucleolia
[dados]: https://arquiteturamrv.azurewebsites.net/api/ObterSelos?selo=dados&style=true&projeto=nucleolia
[privacidade]: https://arquiteturamrv.azurewebsites.net/api/ObterSelos?selo=privacidade&style=true&projeto=nucleolia
[arch]: https://arquiteturamrv.azurewebsites.net/api/ObterSelos?selo=arquitetura&style=true&projeto=nucleolia
