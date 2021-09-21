using Microsoft.EntityFrameworkCore;
using Myapp.Data;
using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.DataEF
{
    public class PhoneRepository : IPhoneRepository
    {
        readonly IBaseRepository<Phone> _repo;


        public PhoneRepository(IBaseRepository<Phone> repo)
        {
            _repo = repo;
        }

        public void SetDeleteState(Phone entity)
        {
            _repo.SetState(entity, EntityState.Deleted);
        }

        public void SetModifiedState(Phone entity)
        {
            _repo.SetState(entity, EntityState.Modified);
        }
    }
}
