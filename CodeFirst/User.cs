using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CodeFirst
{
    public class User
    {
        [Key]
        public string Username
        {
            get;
            set;
        }

        public string DisplayName
        {
            get;
            set;
        }
    }
}