using System;

namespace WebApiPrueba
{
    public class BOUser
    {
        public BOUser()
        {
            Id = 0;
            Name = string.Empty;
            LastName = string.Empty;
            Address = string.Empty;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
