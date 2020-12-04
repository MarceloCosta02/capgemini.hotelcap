namespace apihotelcap.Domain.ResponseModels.ClientResponses
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }

        public ClientResponse(int id, string name, string cpf)
        {
            Id = id;
            Name = name;
            CPF = cpf;
        }
    }
}
