using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;



public class GenericManager
{

    private Model1Container1 p_domainContext;
    public Model1Container1 DomainContext
    {
        get
        {
            if(p_domainContext == null)
            {
                p_domainContext = new Model1Container1();
            }
            return p_domainContext;
        }
      
    }
}






