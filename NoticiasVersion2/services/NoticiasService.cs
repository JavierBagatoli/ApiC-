using Microsoft.EntityFrameworkCore;
using NoticiasVersion2.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoticiasVersion2.services
{
    public class NoticiasService
    {
        private readonly NotDbContext _notDbContext;
        public NoticiasService(NotDbContext noticiasDbContext) { 
            _notDbContext = noticiasDbContext; 
        }

        public List<Noticia> Obtener() {
            var resultado = _notDbContext.Noticia.Include(x => x.Autor).ToList();
            return resultado;
        }

        public bool AgregarNoticia(Noticia _noticia) {
            try {
                _notDbContext.Noticia.Add(_noticia);
                _notDbContext.SaveChanges();
                return true;
            } catch (Exception  error) {
                return false;
            }
        }

        public bool EditarNoticia(Noticia _noticia)
        {
            try {
                var noticiaBaseDatos = _notDbContext.Noticia.Where(busqueda => busqueda.NoticiaId == _noticia.NoticiaId).FirstOrDefault();
                noticiaBaseDatos.Titulo = _noticia.Titulo;
                noticiaBaseDatos.Descripcion = _noticia.Descripcion;
                noticiaBaseDatos.contenido = _noticia.contenido;
                noticiaBaseDatos.Fecha = _noticia.Fecha;
                noticiaBaseDatos.AutorID = _noticia.AutorID;

                _notDbContext.SaveChanges();

                return true;
            } catch (Exception error) {
                return false;
            }
        }

        public bool EliminarNoticia(int NoticiaID)
        {
            try
            {
                var noticiaBaseDatos = _notDbContext.Noticia.Where(busqueda => busqueda.NoticiaId == NoticiaID).FirstOrDefault();
                _notDbContext.Noticia.Remove(noticiaBaseDatos);
                _notDbContext.SaveChanges();
                return true;
            }
            catch (Exception error) {
                return false;
            }
        }
    }
}
