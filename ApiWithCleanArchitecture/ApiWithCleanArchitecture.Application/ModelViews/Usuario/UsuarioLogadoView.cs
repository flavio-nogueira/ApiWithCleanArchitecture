namespace ApiWithCleanArchitecture.Application.ModelViews.Usuario
{
    public class UsuarioLogadoView
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataHoraLogin { get; set; }
        public string Token { get; set; }
        public DateTime ValidadeLogin { get; set; }
    }
}
