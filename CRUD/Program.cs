using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CRUD.View;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;


namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDView view = new CRUDView();
            view.Start();
        }
    }

}


