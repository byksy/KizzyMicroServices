using FreeCourse.Services.Discount.Services;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Discount.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DiscountsController : CustomBaseController
{
    private readonly ISharedIdentityService _sharedIdentityService;
    private readonly IDiscountService _discountService;

    public DiscountsController(ISharedIdentityService sharedIdentityService, IDiscountService discountService)
    {
        _sharedIdentityService = sharedIdentityService;
        _discountService = discountService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResultInstance(await _discountService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var discount = await _discountService.GetById(id);
        return CreateActionResultInstance(discount);
    }

    [HttpGet]
    [Route("/api/[controller]/[action]/{code}")]
    public async Task<IActionResult> GetByCode(string code)
    {
       var userId =  _sharedIdentityService.GetUserId!;

       return CreateActionResultInstance(await _discountService.GetByCodeAndUserId(code, userId));
    }

    [HttpPost]
    public async Task<IActionResult> Save(Models.Discount discount)
    {
        return CreateActionResultInstance(await _discountService.Save(discount: discount));
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(Models.Discount discount)
    {
        return CreateActionResultInstance(await _discountService.Update(discount: discount));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return CreateActionResultInstance(await _discountService.Delete(id));
    }

}