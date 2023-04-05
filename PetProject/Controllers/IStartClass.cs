using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetProject.Extensions;

namespace PetProject.Controllers
{
    public interface IStartClass
    {
        int Value { get; }
    }
}