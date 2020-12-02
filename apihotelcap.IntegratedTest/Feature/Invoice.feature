Funcionalidade: Invoice
Testes integrados das funcionalidade relacionadas ao end-point Invoice


Esquema do Cenario: Enviar uma solicitacao da fatura para as ocupacoes nao pagas
	Dado que o endpoint invoice é 'Invoice'
	E que o método http da invoice é 'GET'
	Quando obter a fatura
	Então a resposta de invoice será <resposta>

	Exemplos: 
		| resposta |
		| 200      |
