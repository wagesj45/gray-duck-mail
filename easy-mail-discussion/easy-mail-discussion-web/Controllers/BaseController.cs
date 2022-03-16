using EasyMailDiscussion.Common.Database;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EasyMailDiscussion.Web.Controllers
{
    public class BaseController : Controller
    {
        private Lazy<SqliteDatabase> sqliteDatabase = new Lazy<SqliteDatabase>(() =>
        {
            return new SqliteDatabase("");
        });
    }
}
