using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSMultifamilyProperty.Interfaces;
using WSMultifamilyProperty.Models;
using WSMultifamilyProperty.Models.Request;
using WSMultifamilyProperty.Models.Response;

namespace WSMultifamilyProperty.Services
{
    public class UserService : IUserService
    {

        public void Add(UserRequest request)
        {
            using(MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {
                var user = new User();
                try
                {
                    user.Username = request.Username;
                    user.Lastname = request.Lastname;
                    user.Firstname = request.Firstname;
                    user.Email = request.Email;
                    user.IdResidentialComplex = request.IdResidentialComplex;
                    user.IdRole = request.IdRole;
                    user.Password = request.Password;
                    user.Phonenumber = request.Phonenumber;


                    if(request.IdRole != 1)
                    {
                        user.IdDwelling = request.IdDwelling;
                        user.Tenure = request.Tenure;
                      
                        if(request.IdOptinalRole>0)
                        {
                            user.IdOptionalRole = request.IdOptinalRole;
                        }

                    }

                    db.User.Add(user);
                    db.SaveChanges();

                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }
            }
        }

        public void Update(UserRequest request)
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {
                var user = db.User.Find(request.Id);
                try
                {

                    user.Lastname = request.Lastname;
                    user.Firstname = request.Firstname;
                    user.Email = request.Email;
                    user.IdRole = request.IdRole;
                    user.Phonenumber = request.Phonenumber;


                    if (request.IdRole != 1)
                    {
                        user.IdDwelling = request.IdDwelling;
                        user.Tenure = request.Tenure;

                        if (request.IdOptinalRole > 0)
                        {
                            user.IdOptionalRole = request.IdOptinalRole;
                        }

                    }


                    db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }
            }
        }



        public void Delete(UserRequest request)
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {
                var user = db.User.Find(request.Id);
                try
                {

                    user.Active = false;
                 

                    db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }
            }
        }


        public List<UserResponse> Get()
        {
            using (MultifamilyPropertyContext db = new MultifamilyPropertyContext())
            {
                try
                {
                    var userList = db.User.Where(x => x.Active == true).ToList();
                    var dwelllingListFiltered =  userList.ConvertAll(x => new UserResponse(x.Id, x.Username, x.Lastname,x.Firstname, 
                                                                    x.Phonenumber,x.Email,x.IdRole,x.Tenure,x.IdResidentialComplex,x.IdOptionalRole,x.IdDwelling ));
                    return dwelllingListFiltered;
                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }
            }
        }


    }
}
