using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ShopManagementService.Application.Common.Controllers;

public interface IController<T> where T : class, IEntity
{
    Task<IActionResult> GetAll();
    Task<IActionResult> GetById(string id);
    Task<IActionResult> Create(T entity);
    Task<IActionResult> Update(T entity);
    Task<IActionResult> Delete(string id);
}