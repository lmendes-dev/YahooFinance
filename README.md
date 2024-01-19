# Yahoo Finance

Visão Geral da Implementação de uma API que Recupera o Histórico de Negociações da Moeda Selecionada nos Últimos 30 Dias.
![image](https://github.com/lmendes-dev/YahooFinance/assets/69693189/01a113f5-4dc1-4e75-95ae-afe04b69e1d1)
![image](https://github.com/lmendes-dev/YahooFinance/assets/69693189/7963ea4b-1e6c-442d-9e17-42d6b3fff0fc)
![image](https://github.com/lmendes-dev/YahooFinance/assets/69693189/2afd5066-e4d3-46be-bc11-3f13d82f0424)
![image](https://github.com/lmendes-dev/YahooFinance/assets/69693189/2d97e85e-53f9-491f-907b-78e11331e684)

# O que está incluído neste repositório

Microserviço de YahooFinance, que inclui:

- Aplicação ASP.NET Core Web API
- Princípios de REST API, operações CRUD
- Conexão e containerização de banco de dados Redis
- Implementação do Padrão Repository
- Implementação do Swagger Open API

Configuração do Docker Compose para o Microsserviço no Docker

- Containerização do microsserviço
- Containerização do bancos de dados
- Sobreposição de variáveis de ambiente

Executar o Projeto

- Você precisará das seguintes ferramentas:
- Visual Studio 2022
- .NET 8
- Docker Desktop

# Instalação

Siga estes passos para configurar o seu ambiente de desenvolvimento: 
- Clone o repositório
- No diretório raiz, que inclui os arquivos docker-compose.yml, execute o seguinte comando:

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

Você pode iniciar o microsserviço na seguinte URL:

- Yahoo Finance API -> http://localhost:59208/swagger/index.html
