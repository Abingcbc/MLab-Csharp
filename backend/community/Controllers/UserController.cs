using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using community.Models;
using static community.Utils.ResponseUtils;
using Microsoft.Extensions.Logging;

namespace community.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/user
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<StandardResponse>> Register(User user)
        {
            return NewResponse(200, "注册成功",  await _context.User.ToListAsync());
        }


    }
}
