
namespace ApiWithCleanArchitecture.Application.ModelViews.Error
{
    public  class ErrorResponse
    {
        public string RequestId { get; set; } 

        public DateTime Data { get; set; }

        public string Mensagem { get; set; }

        public ErrorResponse(string id)
        {
            RequestId = id;
            Data = DateTime.Now;
            Mensagem = "Erro inesperado";
        }

    }
}
