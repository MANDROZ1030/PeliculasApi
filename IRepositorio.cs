using Microsoft.AspNetCore.Mvc;
using PeliculasApi.Entidades;

namespace PeliculasApi
{
    public interface IRepositorio
    {
        public List<Genero> ObtenerTodosLosGeneros();
        public Task<Genero?> ObtenerPorId(int id);
        public bool Existe(string nombre);
        void Crear(Genero genero);
    }
}
