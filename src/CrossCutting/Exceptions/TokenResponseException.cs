using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Exceptions;
public class TokenResponseException(string message) : BaseException(message)
{   
        public override string Title => "Token Response Exception";
    
}
