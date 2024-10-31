using ProjetoPersistenciaSimples.Models.Clientes;

namespace ProjetoPersistenciaSimples.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository = new ClienteRepository();

        public void CadastrarCliente(Cliente cliente)
        {
            _clienteRepository.SaveCliente(cliente);
        }

        public List<Cliente> ObterClientes()
        {
            return _clienteRepository.GetAllClientes();
        }
    }
}
