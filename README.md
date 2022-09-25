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

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Indíce</summary>
  <ol>
    <li>
      <a href="#sobre-o-sistema">Sobre o Sistema</a>
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

Aplicação backend responsável pelo registro de pagamentos e integração com entidades externas como cartões de crédito e etc.
* Realizar pagamento
* Cadastrar Cliente
* Alterar Cliente
* Buscar Cliente
* Consultar pagamento
* Consultar pagamentos por cliente
* Consultar pagamentos por cliente e período

![Big Picture](/docs/big_picture/big_picture.png)

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
6. Links das api's abaixo:
* [Api BFF](https://localhost:5001/swagger)
* [Api Payment](https://localhost:5004/swagger)  