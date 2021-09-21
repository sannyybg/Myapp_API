using Myapp.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myapp.Data
{
    public interface IPhoneRepository
    {
        void SetModifiedState(Phone entity);
        void SetDeleteState(Phone entity);
    }
}
