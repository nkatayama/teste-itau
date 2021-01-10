# ApiItau.Api
ApiItau é uma aplicação em .net 5.0 que disponibiliza uma API para validação de senhas.
O objetivo é enviar uma string e a API realiza a validação, retornando um boleano indicando se o formato da string enviada atende as regras.

# Tecnologias:
 - .net 5.0 
- Fluentvalidation 8.6.2
- Swagger

# Arquitetura:
- Separação de responsabilidades
- Para a validação da senha, foi utilizado o Fluentvalidation, onde todas a regras de validação são realizadas e o objeto ValidationResult é retornado 
com a propriedade IsValid determindando se a senha informada é válida ou não.
- Implentação de teste unitário da validação e teste de integração.
- A API conta com uma implementação de resposta customizada, preparada para receber um ValidationResult e gerar uma resposta com as mensagens da validação.

# Como usar:
- Necessário última versão do .NET Core SDK.
- Executar o comando dotnet run na pasta do projeto ApiItau.Api
- Executar o comando a seguir, substituido <senha> pela senha que deseja validar:
	curl -X GET "https://localhost:5001/api/Login/password-check" -H  "accept: text/plain" -H  "Content-Type: application/json" -H "password: \"<senha>\"" --insecure
	Ou impoortar o arquivo diponibilizado itau api.postman_collection.json no postman e enviar a requisição.
	O retorno será um  json {"isValid":boolean} 

