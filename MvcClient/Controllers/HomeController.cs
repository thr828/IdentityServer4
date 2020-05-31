﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MvcClient.Models;

namespace MvcClient.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // var client=new HttpClient();
            // var disco =await client.GetDiscoveryDocumentAsync("http://localhost:5009");
            // if (disco.IsError)
            // {
            //     throw new Exception(disco.Error);
            //     throw new Exception(disco.Error);
            // }
            //
            // var accessToken =await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            // client.SetBearerToken(accessToken);
            // var response =await client.GetAsync("http://localhost:5002/identity");
            // if (!response.IsSuccessStatusCode)
            // {
            //    throw new Exception(response.ReasonPhrase);
            // }
            // else
            // {
            //     var content = await response.Content.ReadAsStringAsync();
            //     return View("Index", content);
            // }
            return View();

        }
        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var idToken =await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            var refreshToken=await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
           // var code=await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.Code);

           ViewData["accessToken"] = accessToken;
           ViewData["idToken"] = idToken;
           ViewData["refreshToken"] = refreshToken;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}