Funcionalidade: Client
Testes integrados das funcionalidade relacionadas ao end-point Client


Esquema do Cenario: Listar Clientes
	Dado que o endpoint client é 'Client'
	E que o método http do client é 'GET'
	E que o id é <id>
	Quando obter o cliente
	Então a resposta de client será <resposta>

	Exemplos: 
		| id | resposta |
		| 1  | 200      |
		| 2317313  | 400      |
	
Esquema do Cenario: Inserir Clientes com sucesso
	Dado que o endpoint client é 'Client'
	E que o método http do client é 'POST'
	E que o name é "Marcelo"
	E que o cpf é "44495985809"
	E que o hash é "GDUS11HDU"
	Quando obter o cliente
	Então a resposta de client será 201	

Esquema do Cenario: Inserir Clientes com cpf vazio
	Dado que o endpoint client é 'Client'
	E que o método http do client é 'POST'
	E que o name é "Marcelo"
	E que o cpf é ""
	E que o hash é "GDUS11HDU"
	Quando obter o cliente
	Então a resposta de client será 400
