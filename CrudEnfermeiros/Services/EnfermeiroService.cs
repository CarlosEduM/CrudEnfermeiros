using CrudEnfermeiros.Data;
using CrudEnfermeiros.Models;
using CrudEnfermeiros.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEnfermeiros.Services
{
    public class EnfermeiroService
    {
        public CrudEnfermeirosContext _context { get; }

        public EnfermeiroService(CrudEnfermeirosContext context)
        {
            _context = context;
        }

        public async Task<List<Enfermeiro>> FindAllAsync()
        {
            return await _context.Enfermeiros.Include(x => x.Hospital).ToListAsync();
        }

        public async Task<Enfermeiro> FindByIdAsync(int id)
        {
            return await _context.Enfermeiros.Include(x => x.Hospital).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task InsertAsync(Enfermeiro obj)
        {
            if (!obj.ValidarCpf())
            {
                throw new ExcecaoDeIntegridade("CPF inválido");
            }

            obj.Hospital = _context.Hospitais.First();

            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Enfermeiro obj)
        {
            if (!obj.ValidarCpf())
            {
                throw new ExcecaoDeIntegridade("CPF inválido");
            }

            if (!(await _context.Enfermeiros.AnyAsync(x => x.Id == obj.Id)))
            {
                throw new ExcecaoNaoEncontrado("Id não encontrado");
            }

            obj.Hospital = _context.Hospitais.First();

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw new ExcecaoDeSimultaneidadeNoDb("Erro ao atualizar o banco de dados");
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Enfermeiros.FindAsync(id);
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new ExcecaoDeIntegridade("Objeto não pode ser removido");
            }
        }
    }
}
