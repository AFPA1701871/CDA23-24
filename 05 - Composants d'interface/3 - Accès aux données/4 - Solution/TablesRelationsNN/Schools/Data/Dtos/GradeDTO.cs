using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public partial class GradeDTOIn
    {
        public GradeDTOIn()
        {
        }

        public string GradeName { get; set; }

    }

    public partial class GradeDTOOut
    {
        public GradeDTOOut()
        {
        }

        public string GradeName { get; set; }
    }


    public partial class GradeDTOAvecStudents
    {
        public GradeDTOAvecStudents()
        {
            Students = new HashSet<StudentDTOOut>();
        }

        public string GradeName { get; set; }

        public virtual ICollection<StudentDTOOut> Students { get; set; }
    }
}
