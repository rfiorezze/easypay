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
  <h1 align="center">Easy Pay</h1>

  <p align="center">
    Facilitador de Pagamentos.
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

* [.NET 6](https://learn.microsoft.com/en-us/dotnet/core/install/)
* [Docker](https://docs.docker.com/get-started/)

### Build and Run
1. Clone o repositório
   ```sh
   git clone https://github.com/rfiorezze/easypay.git
   ```
2. Entre no diretório do repositório
   ```sh
   cd easypay
   ```
3. Entre no diretório do repositório
   ```sh
   cd easypay
   ```   
4. Entre no diretório do código fonte
   ```sh
   cd src
   ```
5. Execute o comando docker-compose para rodar toda a aplicação
   ```sh
   docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
   ```
6. * [Api BFF](https://localhost:5001/swagger)
* [Docker](https://docs.docker.com/get-started/)  