# Projeto de Eficiência Energética API (.NET 8)

Este projeto é uma API RESTful desenvolvida em .NET 8 para monitoramento e otimização de eficiência energética e sustentabilidade. Ele permite o registro de leituras de sensores IoT, geração automática de alertas e consulta de dados históricos.

## Funcionalidades Principais

*   **Monitoramento de Sensores:** Endpoint para receber leituras de sensores (ex: temperatura, consumo de energia).
*   **Alertas Automáticos:** Lógica de negócio que verifica automaticamente se uma leitura ultrapassa o limite (threshold) configurado para o sensor e gera um alerta no sistema.
*   **Consultas Paginadas:** Endpoints otimizados para listar grandes volumes de leituras utilizando paginação.
*   **Segurança via API Key:** Proteção de endpoints críticos (escrita de dados e visualização de alertas sensíveis).
*   **Tratamento de Erros Global:** Middleware customizado para retornar respostas de erro padronizadas e amigáveis.

## Arquitetura

O projeto segue estritamente o padrão **MVVM** (Model-View-ViewModel) adaptado para APIs, garantindo a separação de responsabilidades:

*   **Models (Domínio):** Entidades do banco de dados (`Sensor`, `SensorReading`, `Alert`, `Equipment`).
*   **ViewModels (DTOs):** Modelos de entrada e saída da API (`ReadingInputModel`, `AlertViewModel`, `PagedResult`).
*   **Services/Repositories:** Camada de lógica de negócios e acesso a dados (Pattern Repository Genérico).
*   **Controllers:** Pontos de entrada da API.

## Tecnologias Utilizadas

*   **.NET 8.0**
*   **Entity Framework Core 8.0** (SQL Server)
*   **xUnit** (Testes Unitários)
*   **Swagger/OpenAPI** (Documentação da API)

## Configuração e Execução

### Pré-requisitos

*   .NET 8 SDK instalado.
*   SQL Server (LocalDB ou instância completa).

### Passos para Rodar

1.  **Clone o repositório** (ou navegue até a pasta do projeto).

2.  **Configurar Banco de Dados:**
    Certifique-se de que a Connection String em `appsettings.json` aponta para o seu servidor SQL.
    Execute as migrações para criar o banco:
    ```bash
    dotnet ef database update
    ```

3.  **Executar a Aplicação:**
    ```bash
    dotnet run
    ```
    A API estará disponível em `https://localhost:7232` (ou porta similar indicada no console).

4.  **Acessar Swagger:**
    Abra o navegador em `https://localhost:7232/swagger` para testar os endpoints.

## Autenticação (API Key)

Para acessar endpoints protegidos (como `POST /api/Sensors/readings` e `GET /api/Alerts/active`), você deve incluir o cabeçalho `X-Api-Key` na requisição.

*   **Chave Padrão (Dev):** `SecretKey12345` (Configurada no `appsettings.json`)

## Endpoints

### Sensores (`/api/Sensors`)
*   `POST /readings` (Requer Auth): Registra uma nova leitura.
    *   Body: `{ "sensorId": 1, "value": 55.5 }`
*   `GET /{id}/readings?page=1&pageSize=10`: Retorna histórico de leituras (Paginado).

### Alertas (`/api/Alerts`)
*   `GET /active` (Requer Auth): Lista todos os alertas não resolvidos.

## Testes

O projeto inclui testes unitários utilizando xUnit e Moq para validar a lógica dos controladores.

Para rodar os testes:
```bash
dotnet test
```
