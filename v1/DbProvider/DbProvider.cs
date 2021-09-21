using DbProvider.VirtualDTO;
using Mapster;
using Myapp.Data;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbProvider
{
    public class DbProvider<T> : ISingletonService<T> where T : VirtualDTOMain
    {
        private IEmployeeRepository _repo;
        private IEmployeePhoneRepository _empPhonerepo;
        private IPhoneRepository _phonerepo;

        public DbProvider(IEmployeeRepository repo, IEmployeePhoneRepository empPhonerepo, IPhoneRepository phonerepo)
        {
            _repo = repo;
            _empPhonerepo = empPhonerepo;
            _phonerepo = phonerepo;
        }

        //public DbProvider(IEmployeeRepository repo)
        //{
        //    _repo = repo;

        //}


        private List<T> Mylist {get;set;}

        public int IdCounter { get; set; } = 0;

        

     

        public async Task<Employee> GetAsync(int id)
        {
            var xx = await _repo.GetAsync(id);

            var empl = xx.Adapt<Employee>();
            return empl;

        }

        

        public async Task<List<Employee>> GetAllAsync()
        {
            var xx = await _repo.GetAllAsync();
            
            var empl = xx.Adapt<List<Employee>>();
            return empl;
        }


        public async Task<int> CreateAsync(Employee emp)
        {
            var empl = emp.Adapt<Employees>();

            var xx = await _repo.CreateAsync(empl);
    
            return xx;
        }


        public async Task<string> DeleteAsync(int id)
        {
            var emp = await _repo.GetAsync(id);
            if (emp == null)
            {
                return "Notfound";
            }

            foreach (var empPhone in emp.EmployeePhones)
            {
                if (!await _empPhonerepo.ExistsAnotherOwner(id, empPhone.PhoneId))
                    _phonerepo.SetDeleteState(empPhone.Phone);
            }

            await _repo.DeleteAsync(id);
            return $"Id: {id} Deleted";

        }


        public async Task<int> UpdateAsync(Employee emp)
        {
            //var empl = emp.Adapt<Employees>();
            

            //await _repo.UpdateAsync(empl);

            //return 1;

            if (!(await _repo.Exists(emp.Id)))
                return 404;

            var personToUpdate = emp.Adapt<Employees>();

            var existingPhoneIds = await _repo.GetRelatedPhoneIds(emp.Id);

            foreach (var personPhone in personToUpdate.EmployeePhones.Where(x => existingPhoneIds.Contains(x.PhoneId)))
            {
                _empPhonerepo.SetModifiedState(personPhone);
                _phonerepo.SetModifiedState(personPhone.Phone);
            }

            await _repo.UpdateAsync(personToUpdate);

            return 200;
        }





    }
}
