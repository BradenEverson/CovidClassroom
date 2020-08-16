using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CovidClassroom
{
    public class timerModel : PageModel
    {
        public int time { get; set; }
        public void OnGet(string time)
        {
            this.time = Int32.Parse(time);
        }
    }
}