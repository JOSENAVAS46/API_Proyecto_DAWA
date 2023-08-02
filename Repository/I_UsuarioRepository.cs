﻿using API_Proyecto_DAWA.Context;
using API_Proyecto_DAWA.Models;
using Microsoft.EntityFrameworkCore;


namespace API_Proyecto_DAWA.Repository
{
    public interface I_UsuarioRepository
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task<Usuario> Create(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task Delete(int id);
        Task<bool> SaveChanges();
    }

    public class UsuarioRepository : I_UsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAll()
        {
            List<Usuario> lstUsuarios = _context.Usuarios.ToList();
            return lstUsuarios;
        }

        public async Task<Usuario> GetById(int id)
        {
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            return usuario;
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            var existingUsuario = await _context.Usuarios.FindAsync(usuario.Id);

            if (existingUsuario != null)
            {
                _context.Entry(existingUsuario).CurrentValues.SetValues(usuario);
                await _context.SaveChangesAsync();
                return existingUsuario;
            }
            else
            {
                throw new InvalidOperationException("La entidad con el Id especificado no existe en el contexto.");
            }
        }

        public async Task Delete(int id)
        {
            var usuarioToDelete = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            _context.Usuarios.Remove(usuarioToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
