Funcionalidade: Bedroom
Testes integrados das funcionalidade relacionadas ao end-point Bedroom


Esquema do Cenario: Listar um quarto pelo Id
	Dado que o endpoint bedroom é 'Bedroom/getById'
	E que o método http do bedroom é 'GET'
	E que o id do quarto é 1
	Quando obter o quarto
	Então a resposta de bedroom será 200
	
Esquema do Cenario: Listar um quarto pelo Id do tipo de quarto
	Dado que o endpoint bedroom é 'Bedroom/getByIdBedroomType'
	E que o método http do bedroom é 'GET'
	E que o id do tipo de quarto referenciado com o quarto é 1
	Quando obter o quarto
	Então a resposta de bedroom será 200	

Esquema do Cenario: Criar quarto
	Dado que o endpoint bedroom é 'Bedroom'
	E que o método http do bedroom é 'POST'
	E que o andar é 9
	E que o numero do quarto é 12
	E que a situacao do quarto é A	
	E que o id do tipo de quarto referenciado com o quarto é 1
	Quando obter o quarto
	Então a resposta de bedroom será 201	

Esquema do Cenario: Atualizar situação do quarto
	Dado que o endpoint bedroom é 'Bedroom'
	E que o método http do bedroom é 'PATCH'
	E que a situacao do quarto é I
	E que o id do quarto é 1
	Quando obter o quarto
	Então a resposta de bedroom será 200