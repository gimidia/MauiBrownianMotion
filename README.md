# Movimento Browniano

Aplicação desenvolvida em .NET MAUI para simulação de Movimento Browniano.

## Arquitetura

O aplicativo segue o padrão de arquitetura MVVM (Model-View-ViewModel), que é o padrão recomendado para aplicativos .NET MAUI. Esta arquitetura separa a lógica de negócios e apresentação, melhorando a manutenção e testabilidade do código.

- **Model**: Representa os dados e a lógica de negócios da aplicação.
- **View**: Define a interface do usuário e a apresentação visual.
- **ViewModel**: Atua como intermediário entre a View e o Model, fornecendo dados e comandos para a View.

### Tecnologias Utilizadas

- **SkiaSharp**: Biblioteca de gráficos 2D de alto desempenho utilizada para renderizar a simulação do Movimento Browniano na interface do usuário. O SkiaSharp oferece uma API poderosa para desenho vetorial, manipulação de imagens e efeitos visuais, sendo ideal para aplicações que exigem renderização personalizada e de alta performance.

Esta estrutura facilita a separação de preocupaões e torna o código mais organizado e fácil de manter, enquanto aproveita o poder do SkiaSharp para renderização gráfica avançada.

### Pré-requisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) ou superior
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) com carga de trabalho MAUI
- (Opcional) [Visual Studio Code](https://code.visualstudio.com/) com extensão C# Dev Kit

## Como Executar a Aplicação

### Usando o Visual Studio 2022

1.  Clone o repositório para sua máquina local:
    ```bash
    git clone https://github.com/gimidia/MauiBrownianMotion.git
    ```
2.  Navegue até o diretório do projeto.
3.  Abra o arquivo da solução `MauiBrownianMotion.sln` com o Visual Studio 2022.
4.  Aguarde o Visual Studio restaurar todas as dependências do projeto (NuGet packages).
5.  Selecione o dispositivo de destino na barra de ferramentas (ex: `Windows Machine` para rodar no Windows ou um emulador Android).
6.  Pressione **F5** ou clique no botão **▶ Iniciar** para compilar e executar a aplicação.

### Usando o Visual Studio Code

1.  Clone o repositório para sua máquina local.
2.  Abra a pasta raiz do projeto (`MauiBrownianMotion`) no Visual Studio Code.
3.  Abra um novo terminal no VS Code (**Terminal > New Terminal**).
4.  Navegue até o diretório do projeto:
    ```bash
    cd MauiBrownianMotion
    ```
5.  Limpe o projeto para remover artefatos de compilações anteriores (Opcional, mas recomendado):
    ```bash
    dotnet clean
    ```
6.  Restaure as dependências do projeto executando o comando:
    ```bash
    dotnet restore
    ```
7.  Compile o projeto:
    ```bash
    dotnet build
    ```
8.  Execute a aplicação para a plataforma desejada. Por exemplo, para Windows:
    ```bash
    dotnet build -t:Run -f net9.0-windows10.0.19041.0
    ```
    *Você pode encontrar os frameworks de destino disponíveis no arquivo `MauiBrownianMotion.csproj`.*

## Testes Unitários

O projeto inclui um conjunto de testes unitários para garantir a qualidade e a corretude da lógica de negócio e do ViewModel. Os testes foram desenvolvidos utilizando o framework **xUnit**.

### Abrangência dos Testes

Os testes estão localizados no projeto `MauiBrownianMotion.Tests` e cobrem as seguintes áreas:

-   **`BrownianModel` (Lógica de Negócio):**
    -   **Caminhos Felizes:** Verificam se a simulação gera o número correto de pontos de dados e se todos os preços gerados são positivos.
    -   **Caminhos Infelizes:** Garantem que o sistema lança exceções (`ArgumentException`) quando recebe entradas inválidas, como:
        -   Número de dias negativo ou zero.
        -   Preço inicial negativo.
        -   Valor de Sigma (volatilidade) negativo.

-   **`BrownianViewModel` (ViewModel):**
    -   Verifica se o comando `GenerateCommand` popula corretamente a coleção de preços que é exibida na interface.
    -   Confirma que o tratamento de exceções está funcionando, exibindo um alerta para o usuário em caso de dados inválidos, em vez de travar a aplicação.

### Como Executar os Testes

Você pode executar os testes unitários diretamente pelo terminal.

1.  Abra um terminal na pasta raiz do projeto.
2.  Navegue até o diretório do projeto de testes:
    ```bash
    cd MauiBrownianMotion.Tests
    ```
3.  Execute o seguinte comando para rodar os testes:
    ```bash
    dotnet test
    ```
O resultado dos testes será exibido no terminal, mostrando o número de testes aprovados, reprovados ou ignorados.

## Interface do Aplicativo

![Tela do Aplicativo](TelaMovimentoBrowniano.jpg)

Este projeto é apenas para fins de estudo/demonstração.
