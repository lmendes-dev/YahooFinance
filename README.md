# Yahoo Finance

Visão Geral da Implementação de uma API que Recupera o Histórico de Negociações da Moeda Selecionada nos Últimos 30 Dias.

# O que está incluído neste repositório

# Microserviço de YahooFinance, que inclui:

Aplicação ASP.NET Core Web API
Princípios de REST API, operações CRUD
Conexão e containerização de banco de dados Redis
Implementação do Padrão Repository
Implementação do Swagger Open API

# Configuração do Docker Compose para o Microsserviço no Docker

Containerização do microsserviço
Containerização do bancos de dados
Sobreposição de variáveis de ambiente

# Executar o Projeto

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
