using FizzBuzzSample.Mappers.Interfaces;
using FizzBuzzSample.Models;
using FizzBuzzSample.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FizzBuzzSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFizzBuzzService _fizzBuzzService;
        private readonly IFizzBuzzViewModelMapper _fizzBuzzViewModelMapper;

        public HomeController(ILogger<HomeController> logger, IFizzBuzzService fizzBuzzService, IFizzBuzzViewModelMapper fizzBuzzViewModelMapper)
        {
            _logger = logger;
            _fizzBuzzService = fizzBuzzService;
            _fizzBuzzViewModelMapper = fizzBuzzViewModelMapper;
        }

        public IActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Index(string commaSeparatedValues)
        {            
            List<FizzBuzzViewModel> results = _fizzBuzzViewModelMapper.MapFrom(_fizzBuzzService.Process(commaSeparatedValues));
            return View(results);                       
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}