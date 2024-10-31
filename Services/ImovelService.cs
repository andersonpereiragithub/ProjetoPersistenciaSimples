using ProjetoPersistenciaSimples.Repositories;

namespace ProjetoPersistenciaSimples.Services
{
    public class ImovelService
    {
        private readonly ImovelRepository _imovelRepository = new ImovelRepository();

        public void CadastrarImovel(Imovel imovel)
        {
            _imovelRepository.SaveImovel(imovel);
        }

        public List<Imovel> ObterImoveis()
        {
            return _imovelRepository.GetAllImoveis();
        }
    }
}
