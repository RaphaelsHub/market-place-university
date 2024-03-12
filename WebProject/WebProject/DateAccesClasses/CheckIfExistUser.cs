using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using WebProject.Models;

namespace WebProject.DateAccesClasses
{

public class CheckIfExistUser
{
    static public bool Check(RegistrationData data)
    {
        // Проверяем, что данные не пустые
        if (string.IsNullOrEmpty(data.Email) || 
            string.IsNullOrEmpty(data.Name) || 
            string.IsNullOrEmpty(data.Phone) || 
            string.IsNullOrEmpty(data.Password))
        {
            return true; // Если хотя бы одно поле пусто, то считаем, что пользователь существует
        }
        
        return false; // Если все поля заполнены, то считаем, что пользователь не существует
    }
}

}