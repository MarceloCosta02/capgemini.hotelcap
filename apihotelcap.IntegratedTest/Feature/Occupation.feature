Funcionalidade: Occupation
Testes integrados das funcionalidade relacionadas ao end-point Occupation


Esquema do Cenario: Criar ocupações
	Dado que o endpoint occupation é 'Occupation'
	E que o método http do occupation é 'POST'
	E que a quantidade de diarias é 3
	E que a data é 02/12/2020
	E que a situacao é "N"
	E que o Id do Cliente é 1
	E que o Id do Quarto é 1
	Quando obter a ocupacao
	Então a resposta de occupation será 201	