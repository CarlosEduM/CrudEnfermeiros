using CrudEnfermeiros.Data;
using CrudEnfermeiros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudEnfermeiros.Services.Exceptions;

namespace CrudEnfermeiros.Services
{
    public class HospitalService
    {
        public CrudEnfermeirosContext _context { get; }

        public HospitalService(CrudEnfermeirosContext context)
        {
            _context = context;
        }

        public async Task<List<Hospital>> FindAllAsync()
        {
            return await _context.Hospitais.ToListAsync();
        }

        public async Task<Hospital> FindByIdasync(int id)
        {
            return await _context.Hospitais.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Hospital obj)
        {
            if (!obj.validarCnpj())
            {
                throw new ExcecaoDeIntegridade("CNPJ inválido");
            }

            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Hospital obj)
        {
            if (!obj.validarCnpj())
            {
                throw new ExcecaoDeIntegridade("CNPJ inválido");
            }

            if (!(await _context.Hospitais.AnyAsync(x => x.Id == obj.Id)))
            {
                throw new ExcecaoNaoEncontrado("Hospital não encontrado");
            }

            try
            {
                _context.Hospitais.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ExcecaoDeSimultaneidadeNoDb("Erro ao atualizar o Banco de dados");
            }
        }

        public async Task Remove(int id)
        {
            try
            {
                var obj = await _context.Hospitais.FindAsync(id);
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new ExcecaoDeSimultaneidadeNoDb("Objeto não pode ser removido");
            }
        }
    }
}
