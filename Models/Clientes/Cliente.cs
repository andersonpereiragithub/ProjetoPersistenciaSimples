using System;

namespace ProjetoPersistenciaSimples.Models.Clientes
{
    public abstract class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}