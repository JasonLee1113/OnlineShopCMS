﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OnlineShopCMS.Areas.Identity.Data;

// Add profile data for application users by adding properties to the OnlineShopUser class
public class OnlineShopUser : IdentityUser
{
    public string Name { get; set; } = "";
    public DateTime DOB { get; set; }       //生日
    public GenderType Gender {  get; set; }    //性別
    public DateTime RegistrationDate { get; set; }   //註冊時間
    public enum GenderType
    {
        Male, Female, UnknownW
    }

}

