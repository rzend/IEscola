using IEscola.Application.Interfaces;

namespace IEscola.Application.Services
{
    public abstract class ServiceBase
    {
        private readonly INotificador _notificador;

        public ServiceBase(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool TemNotificacao()
        {
            return _notificador.TemNotificacao();
        }

    }
}
