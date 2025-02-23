using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Enums.Request;
using ECommerce.Core.Enums.User;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.User;

namespace ECommerce.Controllers
{
    public class ManagementUsersController : BaseController
    {
        private readonly IUserService _userService;

        public ManagementUsersController(IUserService userService) => 
            _userService = userService;

        [HttpGet]
        public async Task<ActionResult> Index(string searchByEmail = "", UserType userType = UserType.None, int page = 1, int usersPerPage = 20)
        {
            try
            {
                var response = await _userService.GetUsersAsync(searchByEmail, userType, page, usersPerPage);
                
                if (response.Status == OperationStatus.Success)
                    return View(new BaseResponse<List<UserDto>>(response.Data, OperationStatus.Success, "ok"));
                
                return Redirect("/Home/Error/500");
            }
            catch (Exception)
            {
                return Redirect("/Home/Error/500");
            }
        }
        
        [HttpGet]
        public async Task<ActionResult> ViewUser(int id)
        {
            try
            {
                var response  = await _userService.GetUserByIdAsync(id);
                
                if (response.Status == OperationStatus.Success)
                    return View(new BaseResponse<UserDto>(response.Data,OperationStatus.Success, "ok"));
                
                return Redirect("/Home/Error/500");
            }
            catch (Exception)
            {
                return Redirect("/Home/Error/500");
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser(UserDto userDto)
        {

            try
            {
                var response  = await _userService.UpdateUserAsync(userDto);
                 
                if (response.Status== OperationStatus.Success)
                    return RedirectToAction("ViewUser", new { id = userDto.Id });
                return Redirect("/Home/Error/500");
            }
            catch (Exception)
            {
                return Redirect("/Home/Error/500");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserByIdAsync(id);

                return RedirectToAction("Index", "ManagementUsers");
            }
            catch (Exception)
            {
                return Redirect("/Home/Error/500");
            }
        }
    }
}