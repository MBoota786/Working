using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accordia_Project.BusinessLogicLayer.NoticeBoard
{
    public class chatGroupsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
