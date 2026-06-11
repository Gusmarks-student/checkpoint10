using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using IMCApp.Models;

namespace IMCApp.Controllers;

public class EnderecoController : Controller
{
    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(EnderecoViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        TempData["EnderecoModel"] = JsonSerializer.Serialize(model);
        return RedirectToAction(nameof(Confirmacao));
    }

    [HttpGet]
    public IActionResult Confirmacao(EnderecoViewModel model)
    {
        if (!string.IsNullOrWhiteSpace(model.CEP) ||
            !string.IsNullOrWhiteSpace(model.Logradouro) ||
            !string.IsNullOrWhiteSpace(model.Bairro) ||
            !string.IsNullOrWhiteSpace(model.Localidade) ||
            !string.IsNullOrWhiteSpace(model.UF) ||
            !string.IsNullOrWhiteSpace(model.Numero) ||
            !string.IsNullOrWhiteSpace(model.Complemento))
        {
            return View(model);
        }

        if (TempData["EnderecoModel"] is string serializedModel)
        {
            var storedModel = JsonSerializer.Deserialize<EnderecoViewModel>(serializedModel);
            return View(storedModel ?? new EnderecoViewModel());
        }

        return RedirectToAction(nameof(Cadastrar));
    }
}
