using Microsoft.AspNetCore.Mvc;
using kycdetails.Models;
namespace kycdetails.Controllers;

[ApiController]
[Route("api/Welcome")]
public class CustomerController : ControllerBase
{
    private readonly KycformContext DB;

    public CustomerController(KycformContext db)
    {
        this.DB = db;

    }
     [HttpGet("GetDetails")]
    public IQueryable<TbCustomerdetail> GetAllOT()

    {
        try{
            return DB.TbCustomerdetails;
        }
        catch(System.Exception)
        {
            throw;
        }
    }
  [HttpPost("InsertDetails")]
 public object Insertcustomerdetails(Register regObj)
    {
        Console.Write("postdata",regObj);
        string message="";
        try{
           TbCustomerdetail e2 =new TbCustomerdetail();
            if(e2.TbId==0){
                    e2.TbCustomerId=regObj.RegCustomerId;
                    e2.TbCustomername=regObj.RegCustomername;
                    e2.TbGender=regObj.RegGender;
                    e2.TbMobile=regObj.RegMobile;
                    e2.TbDocumentType=regObj.RegDocumentType;
                    e2.TbIdNumber=regObj.RegIdNumber;
                    
               

                DB.TbCustomerdetails.Add(e2);
                int result = this.DB.SaveChanges();
                    if (result > 0)
                    {
                        message = "User has been sucessfully added";
                    }
                    else
                    {
                        message = "failed";
                    }

                     return Ok(message);
            //Add

            //save it in the database
            DB.SaveChanges();

            return new Response{Status="Success" , Message = "Employee Added!"};

        }
    }
    catch(System.Exception)
    {
throw;
    }

    return new Response{Status="Error" , Message="Invalid Information"};
  }

               


// [HttpGet("GetUserDetailsById/{uid}")]
//     public IActionResult GetByID(int uid)
//     {
//             var users =this.DB.TbCustomerdetails.FirstOrDefault(o=>o.TbId==uid);
//             return Ok(users);
//     }
[HttpPut]
[Route("UpdateEmployeeDetails")]
public IActionResult putEmployee(Register user)
{
    Console.Write("user");
    string message = "";
    if(!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
    try{
         TbCustomerdetail obj = new TbCustomerdetail();
        // obj= DB.TbEmployees.Find(user.Id);
        obj = this.DB.TbCustomerdetails.Find(user.RegId);
        if(obj !=null){
                    obj.TbCustomerId=user.RegCustomerId;
                    obj.TbCustomername=user.RegCustomername;
                    obj.TbGender=user.RegGender;
                    obj.TbMobile=user.RegMobile;
                    obj.TbDocumentType=user.RegDocumentType;
                    obj.TbIdNumber=user.RegIdNumber;


        }
        int result=this.DB.SaveChanges();
        if(result>0){
            message="updated";
        }
        else{
            message="failed";
        }
       
    }
    catch(Exception){
        throw;
    }
    return Ok(message);
}




     [HttpDelete("DeleteCustomerDetails")]
    public IActionResult DeleteUser(int uid)
    {
        string message = "";
            var user = this.DB.TbCustomerdetails.Find(uid);
            if (user == null)
            {
                return NotFound();
            }

            this.DB.TbCustomerdetails.Remove(user);
            int result = this.DB.SaveChanges();
            if (result > 0)
            {
                message = "User has been sussfully deleted";
            }
            else
            {
                message = "failed";
            }

            return Ok(message);
        }

}
