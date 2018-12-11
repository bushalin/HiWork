using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using HiWork.Models;
using HiWork.Models.SP_User;
using System.Web.Mvc;

using HiWork.Common;

namespace HiWork.Services
{
    public class SP_UserServices : ISP_UserServices
    {
        private readonly HiWorkDbContext _context;
        private readonly IEntityService<User> _services;
        public SP_UserServices()
        {
            _context = new HiWorkDbContext();
            _services = new EntityService<User>(_context);
        }


        private bool IsUsernameFound(string username)
        {
            var userId = _context.User.Where(u => u.Username == username).Select(x => x.Id).FirstOrDefault();

            if (userId> 0)
            {
                return true;
            }
            return false;
        }

        public JsonResult GetUserList()
        {
            var result = _context.User.Select(u => new
            {
                u.Id,
                u.FirstName,
                u.LastName,
                u.Address,
                u.Email,
                u.Gender,
                u.Username,
                u.Mobile
            }).ToList();

            return new JsonResult
            {
                Data = _context.User.Select(u => new
                {
                    u.Id,
                    u.FirstName,
                    u.LastName,
                    u.Address,
                    u.Email,
                    u.Gender,
                    u.Username,
                    u.Mobile
                }).ToList(),
            JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetUserDetailsById(int userId)
        {
            var result = _context.User.Where(u=> u.Id == userId)
                .Select(u => new
                {
                    u.Id,
                    u.FirstName,
                    u.LastName,
                    u.Address,
                    u.Email,
                    u.Gender,
                    u.Username,
                    u.Mobile
                }).FirstOrDefault();
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult EditUser(User obj)
        {
            var message = "";
            bool testReturn;

            List<object> avoidProperties = new List<object>();
            avoidProperties.Add(obj.Username);
            
            _services.Update(obj, avoidProperties);

            if (!IsUsernameFound(obj.Username))
            {
                message = "This User does not exist!";
                Generator.IsReport = "Warning";
            }
            else
            {
                try
                {
                    testReturn = _services.Update(obj, avoidProperties);
                    _services.SaveChanges();
                    message = "User Edited successfully !";
                    Generator.IsReport = "Ok";

                }
                catch (Exception ex)
                {
                    //message = "Something went wrong ! Please contact system administrator.";
                    message = ex.Message;
                    Generator.IsReport = "NotOk";
                }
            }
            return new JsonResult
            {
                Data = new
                {
                    Message = message,
                    Generator.IsReport

                },

                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult SaveUser(User obj)
        {
            var message = "";

            if (obj.Username == null || obj.Password == null)
            {
                message = "You did not provide username or password!";
                Generator.IsReport = "Warning";
            }
            else if (IsUsernameFound(obj.Username)){
                message = "Username exists ! Please choose a different username.";
                Generator.IsReport = "Warning";
            }
            else
            {
                try
                {
                    _services.Save(obj);
                    _services.SaveChanges();
                    message = "User saved successfully !";
                    Generator.IsReport = "Ok";

                }
                catch (Exception ex)
                {
                    //message = "Something went wrong ! Please contact system administrator.";
                    message = ex.Message;
                    Generator.IsReport = "NotOk";
                }
            }
            return new JsonResult
            {
                Data  = new
                {
                    Message = message,
                    Generator.IsReport

                },

                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }

    public interface ISP_UserServices
    {
        JsonResult GetUserList();
        JsonResult GetUserDetailsById(int userId);
        JsonResult SaveUser(User obj);
        JsonResult EditUser(User obj);
    }
}
