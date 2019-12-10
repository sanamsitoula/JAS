using JAS.Crypto;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace JAS.Authorization
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var checkuser = CheckUser.IsUserExist(context.UserName);
            if (checkuser != null)
            {
                var password = CryptoMethod.Hash(context.Password);
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                if (context.UserName == checkuser.user_name && password == checkuser.Password)
                {
                    if (checkuser.role_name == "admin" && checkuser.isEmailVerified == true)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, checkuser.role_name));
                        identity.AddClaim(new Claim(checkuser.user_name, checkuser.role_name));
                        identity.AddClaim(new Claim(ClaimTypes.Name, checkuser.first_name));
                        identity.AddClaim(new Claim(ClaimTypes.Sid, checkuser.user_id.ToString()));
                      identity.AddClaim(new Claim(ClaimTypes.Email, checkuser.email_id));

                        try
                        {
                            context.Validated(identity);
                        }
                        catch(Exception e)
                        {
                            throw e;
                        }
                      
                       
                    }

                    else if (checkuser.role_name == "customers"  && checkuser.isEmailVerified == true)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, checkuser.role_name));
                        identity.AddClaim(new Claim(checkuser.user_name, checkuser.role_name));
                        identity.AddClaim(new Claim(ClaimTypes.Name, checkuser.first_name + " " + checkuser.last_name));
                        identity.AddClaim(new Claim(ClaimTypes.Sid, checkuser.user_id.ToString()));

                        identity.AddClaim(new Claim(ClaimTypes.Email, checkuser.email_id));
                        context.Validated(identity);

                    }
                }

            }
            else
            {
                context.SetError("Invalid Grant Check", "Provided username and password is incorrect");
            }
        }


    }
        }