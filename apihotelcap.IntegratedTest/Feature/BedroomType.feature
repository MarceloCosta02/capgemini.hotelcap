Funcionalidade: BedroomType
Testes integrados das funcionalidade relacionadas ao end-point BedroomType


Esquema do Cenario: Listar todos os tipos de quarto
	Dado que o endpoint bedroomType é 'BedroomType'
	E que o método http do bedroomType é 'GET'
	Quando obter o tipo de quarto
	Então a resposta de bedroomType será 200
	
Esquema do Cenario: Listar um tipo de quarto pelo Id
	Dado que o endpoint bedroomType é 'BedroomType/getById'
	E que o método http do bedroomType é 'GET'
	E que o id do tipo de quarto é 1
	Quando obter o tipo de quarto
	Então a resposta de bedroomType será 200	

Esquema do Cenario: Criar tipos de quarto
	Dado que o endpoint bedroomType é 'BedroomType'
	E que o método http do bedroomType é 'POST'
	E que a descricao é "Presidencial"
	E que o valor é 1200	
	Quando obter o tipo de quarto
	Então a resposta de bedroomType será 201	