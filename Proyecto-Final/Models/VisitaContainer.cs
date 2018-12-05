using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data.Entity;

namespace FullCalendar_MVC
{
    public class DiaryContainer : DbContext
    {
        public DiaryContainer();

        public DbSet<AppointmentDiary> AppointmentDiary { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder);
    }
}