Funcionalidade: Client
Testes integrados das funcionalidade relacionadas ao end-point Client


Esquema do Cenario: Listar Clientes
	Dado que o endpoint é 'Client'
	E que o método http é 'GET'
	E que o id é 1
	Quando obter o cliente
	Então a resposta será 200	

Esquema do Cenario: Inserir Clientes
	Dado que o endpoint é 'Client'
	E que o método http é 'POST'
	E que o name é "Marcelo"
	E que o cpf é "44495985809"
	E que o hash é "GDUS11HDU"
	Quando obter o cliente
	Então a resposta será 201	