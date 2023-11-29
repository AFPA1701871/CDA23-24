using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public  class GradeDTOIn
    {
        public GradeDTOIn()
        {
        }

        public string GradeName { get; set; }

    }

    public  class GradeDTOOut
    {
        public GradeDTOOut()
        {
        }

        public string GradeName { get; set; }
    }


    public  class GradeDTOAvecStudents
    {
        public GradeDTOAvecStudents()
        {
            Students = new HashSet<StudentDTOOut>();
        }

        public string GradeName { get; set; }

        public virtual ICollection<StudentDTOOut> Students { get; set; }
    }
}
