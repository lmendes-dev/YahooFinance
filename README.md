# Yahoo Finance

Visão Geral da Implementação de uma API que Recupera o Histórico de Negociações da Moeda Selecionada nos Últimos 30 Dias.
![image](https://github.com/lmendes-dev/YahooFinance/assets/69693189/cd8ce277-5aa1-4485-a95a-fc2dd3a57877)
![image](https://github.com/lmendes-dev/YahooFinance/assets/69693189/7963ea4b-1e6c-442d-9e17-42d6b3fff0fc)

# O que está incluído neste repositório

Microserviço de YahooFinance, que inclui:

Aplicação ASP.NET Core Web API
Princípios de REST API, operações CRUD
Conexão e containerização de banco de dados Redis
Implementação do Padrão Repository
Implementação do Swagger Open API

Configuração do Docker Compose para o Microsserviço no Docker

Containerização do microsserviço
Containerização do bancos de dados
Sobreposição de variáveis de ambiente

Executar o Projeto

Você precisará das seguintes ferramentas:
Visual Studio 2022
.NET 8
Docker Desktop

# Instalação

Siga estes passos para configurar o seu ambiente de desenvolvimento: 
Clone o repositório
No diretório raiz, que inclui os arquivos docker-compose.yml, execute o seguinte comando:

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

Você pode iniciar o microsserviço na seguinte URL:

Yahoo Finance API -> http://localhost:8080/swagger/index.html
