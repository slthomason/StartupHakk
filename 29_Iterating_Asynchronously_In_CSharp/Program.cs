using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApp.Controllers
{
    public async Task<ActionResult> Index(List<Users> users)
    {
        foreach (Users u in user)
        {
            await RegisterNewUser(u);
        }
        return View();
    }

    public async Task<ActionResult> Index(List<Users> users)
    {
        List<Task> listofTask = new List<Task>();
        foreach (Users u in user)
        {
            listofTask.Add(RegisterNewUser(u));
        }
        await Task.WhenAll(listofTask);
        return View();
    }

    public static Task RegisterNewUser(Users u)
    {
        Task.Run(() =>
        {
            if (ValidateUser(u)) WriteNewUsertoDB(u);

        });
        return Task.CompletedTask;
    }

    public static async Task<bool> ValidateUser(List<Users> ulist)
    {
        List<Task<bool>> validateTaskList = new List<Task<bool>>();
        foreach (Users u in ulist)
        {
            validateTaskList.Add(ServerSideValidate(u));
        }
        await Task.WhenAll(validateTaskList);
        for (int i = 0; i < validateTaskList.Count; i++)
        {
            if (validateTaskList[i].Result == true)
            {
                WriteNewUsertoDB(ulist[i]);
            }
        }
        return true;
    }

    public static async Task<bool> ServerSideValidate(Users u)
    {
        Task<Users> checking = Task<Users>.Run(() =>
        {
            Users isValid = QueryRemoteServer(u);
            return isValid;
        });
        var response = await checking;
        return response.isValid;
    }
}