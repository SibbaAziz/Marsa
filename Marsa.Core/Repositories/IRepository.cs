using Marsa.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Marsa.Core
{
    public interface IRepository
    {
        IEnumerable<Annonce> GetAnnonces();
        void AddAnnonce(Annonce annonce);
    }
}
