﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_05_Biblioteca.DAL
{
    internal interface IDal <T>
    {

        List<T> GetAll();

        bool Insert(T t);

        bool Update(T t);

        bool Delete(T t);
    }
}
