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
    public class EnfermeirosService
    {
        public CrudEnfermeirosContext _context { get; }

        public EnfermeirosService(CrudEnfermeirosContext context)
        {
            _context = context;
        }

        public async Task<List<Enfermeiro>> FindAllAsync()
        {
            return await _context.Enfermeiros.ToListAsync();
        }

        public async Task<Enfermeiro> FindByIdAsync(int id)
        {
            return await _context.Enfermeiros.Include(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(Enfermeiro obj)
        {
            if (!obj.ValidarCpf())
            {
                throw new ExcecaoDeIntegridade("CPF invalido");
            }

            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Enfermeiro obj)
        {
            if (obj.ValidarCpf())
            {
                throw new ExcecaoDeIntegridade("CpfInvalido");
            }

            bool verificar = await _context.Enfermeiros.AnyAsync(x => x.Id == obj.Id);
            if (!verificar)
            {
                throw new ExcecaoNaoEncontrado("Id não encontrado");
            }

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
